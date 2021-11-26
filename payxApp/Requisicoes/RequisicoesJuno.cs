using Newtonsoft.Json;
using PayxApp.Interfaces;
using PayxApp.Models;
using PayxApp.Models.Juno;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PayxApp.Requisicoes
{
    public class RequisicoesJuno
    {
        //TRUE: Está em produção. FALSE: Está em homologação.
        private const bool AMBIENTE_PRODUCAO = false;
        private IConfiguracaoJunoRepositorio _configuracaoJunoRepositorio;
        private ICidadeRepositorio _cidadeRepositorio;
        private ITransacaoDetalheRepositorio _transacaoDetalheRepositorio;
        private ITransacaoRepositorio _transacaoRepositorio;

        public RequisicoesJuno(IConfiguracaoJunoRepositorio configuracaoJunoRepositorio, ICidadeRepositorio cidadeRepositorio, ITransacaoDetalheRepositorio transacaoDetalheRepositorio, ITransacaoRepositorio transacaoRepositorio)
        {
            _configuracaoJunoRepositorio = configuracaoJunoRepositorio;
            _cidadeRepositorio = cidadeRepositorio;
            _transacaoDetalheRepositorio = transacaoDetalheRepositorio;
            _transacaoRepositorio = transacaoRepositorio;
        }

        public ConfiguracaoJuno obterTokenAcesso(ConfiguracaoJuno configuracaoJuno)
        {
            Token token;
            HttpWebRequest httpWebRequest = null;

            if (AMBIENTE_PRODUCAO)
                httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri("https://api.juno.com.br/authorization-server/oauth/token"));
            else
                httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri("https://sandbox.boletobancario.com/authorization-server/oauth/token"));


            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";

            using (WebClient webCliente = new WebClient())
            {
                NameValueCollection data = new NameValueCollection();
                data["client_id"] = configuracaoJuno.ClientId;
                data["client_secret"] = configuracaoJuno.ClientSecret;
                data["grant_type"] = "client_credentials";

                string retorno = null;

                if (AMBIENTE_PRODUCAO)
                    retorno = (Encoding.UTF8.GetString(webCliente.UploadValues("https://api.juno.com.br/authorization-server/oauth/token", "POST", data)));
                else
                    retorno = (Encoding.UTF8.GetString(webCliente.UploadValues("https://sandbox.boletobancario.com/authorization-server/oauth/token", "POST", data)));

                if (!string.IsNullOrWhiteSpace(retorno))
                {
                    token = JsonConvert.DeserializeObject<Token>(retorno);
                    configuracaoJuno.Token = token.access_token;
                    configuracaoJuno.ProximoToken = DateTime.Now.AddSeconds(token.expires_in);
                }
                return configuracaoJuno;
            }
        }

        public async Task<Transacao> criarCobranca(Transacao transacao, ConfiguracaoJuno configuracaoJuno)
        {
            if (DateTime.Now > configuracaoJuno.ProximoToken)
            {
                configuracaoJuno = obterTokenAcesso(configuracaoJuno);
                await _configuracaoJunoRepositorio.Alterar(configuracaoJuno);
            }

            CobrancaJunoEntrada cobranca = new CobrancaJunoEntrada();

            cobranca.charge = new Charge();
            cobranca.charge.description = transacao.Usuario.NomeCompleto; //referencia cobrança
            cobranca.charge.totalAmount = transacao.ValorFinalTransacao;//valor da parcela
            cobranca.charge.dueDate = Utilidades.Funcoes.TransformarDataJuno(DateTime.Today); //vcto
            cobranca.charge.installments = transacao.Parcelamento;
            cobranca.charge.maxOverdueDays = 1; //dias após vcto
            cobranca.charge.fine = 0;//multa
            cobranca.charge.interest = "0";//juros
            cobranca.charge.discountAmount = "0";//desconto
            cobranca.charge.discountDays = -1;//Dias desconto
            cobranca.charge.paymentTypes = new List<string>();
            cobranca.charge.paymentTypes.Add("CREDIT_CARD");//tipo pagamento CARTÃO
            cobranca.charge.paymentAdvance = false;//adiantar parcela (se cartão)

            cobranca.billing = new Billing();
            cobranca.billing.name = transacao.Usuario.NomeCompleto;
            cobranca.billing.document = transacao.Usuario.Cpf.Replace(".", "").Replace("-", "");
            cobranca.billing.email = transacao.Usuario.Email;
            cobranca.billing.phone = transacao.Usuario.PhoneNumber;
            cobranca.billing.notify = true;
            string json = JsonConvert.SerializeObject(cobranca);


            RestClient client = null;
            if (AMBIENTE_PRODUCAO)
                client = new RestClient("https://api.juno.com.br/charges");
            else
                client = new RestClient("https://sandbox.boletobancario.com/api-integration/charges");


            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("X-Resource-Token", configuracaoJuno.ClientResourceToken);
            request.AddHeader("authorization", string.Concat("Bearer ", configuracaoJuno.Token));
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("X-Api-Version", "2");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            CobrancaJunoSaida cobrancaJunoSaida = JsonConvert.DeserializeObject<CobrancaJunoSaida>(response.Content);
            if (cobrancaJunoSaida != null)
                if (cobrancaJunoSaida._embedded != null)
                    if (cobrancaJunoSaida._embedded.charges != null && cobrancaJunoSaida._embedded.charges.Count > 0)
                    {
                        List<TransacaoDetalhe> listaDetalhe = new List<TransacaoDetalhe>();
                        foreach (ChargeOut charge in cobrancaJunoSaida._embedded.charges)
                        {
                            TransacaoDetalhe detalhe = new TransacaoDetalhe();
                            detalhe.ChargeId = charge.id;
                            detalhe.ChargeCode = charge.code.ToString();
                            detalhe.ValorParcela = charge.amount;
                            detalhe.TransacaoId = transacao.Id;
                            listaDetalhe.Add(detalhe);
                        }
                        await _transacaoDetalheRepositorio.Inserir(listaDetalhe);
                        transacao.CobrancaCriada = true;
                        return transacao;
                    }
                    else
                    {
                        transacao.CobrancaCriada = false;
                        return transacao;
                    }
                else
                {
                    transacao.CobrancaCriada = false;
                    return transacao;
                }
            else
            {
                transacao.CobrancaCriada = false;
                return transacao;
            }
        }


        public async Task<Transacao> criarPagamento(Transacao transacao, ConfiguracaoJuno configuracaoJuno)
        {
            if (DateTime.Now > configuracaoJuno.ProximoToken)
            {
                configuracaoJuno = obterTokenAcesso(configuracaoJuno);
                await _configuracaoJunoRepositorio.Alterar(configuracaoJuno);
            }

            List<TransacaoDetalhe> listaDetalhe = await _transacaoDetalheRepositorio.RecuperarPorTransacao(transacao.Id);

            PagamentoJunoEntrada pagamento = new PagamentoJunoEntrada();
            pagamento.chargeId = listaDetalhe[0].ChargeId;
            pagamento.billing = new BillingPagamento();
            pagamento.billing.email = transacao.Usuario.Email;
            pagamento.billing.address = new Address();
            pagamento.billing.address.street = transacao.Usuario.Logradouro;
            pagamento.billing.address.number = transacao.Usuario.Numero;
            pagamento.billing.address.complement = transacao.Usuario.Complemento;
            pagamento.billing.address.neighborhood = transacao.Usuario.Bairro;

            if (transacao.Usuario.Cidade == null)
                transacao.Usuario.Cidade = await _cidadeRepositorio.RecuperarPorCodigo(transacao.Usuario.CidadeId);

            pagamento.billing.address.city = transacao.Usuario.Cidade.NomeCidade;
            pagamento.billing.address.state = transacao.Usuario.Cidade.SiglaEstado;
            pagamento.billing.address.postCode = transacao.Usuario.Cep.Replace(".", "").Replace("-", "");
            pagamento.billing.delayed = false;
            pagamento.creditCardDetails = new CreditCardDetails();
            pagamento.creditCardDetails.creditCardHash = transacao.CartaoCredito.HashCartao;

            string json = JsonConvert.SerializeObject(pagamento);

            RestClient client = null;
            if (AMBIENTE_PRODUCAO)
                client = new RestClient("https://api.juno.com.br/payments");
            else
                client = new RestClient("https://sandbox.boletobancario.com/api-integration/payments");


            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("X-Resource-Token", configuracaoJuno.ClientResourceToken);
            request.AddHeader("authorization", string.Concat("Bearer ", configuracaoJuno.Token));
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("X-Api-Version", "2");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            PagamentoJunoSaida pagamentoJunoSaida = JsonConvert.DeserializeObject<PagamentoJunoSaida>(response.Content);
            if (pagamentoJunoSaida != null)
            {
                transacao.TransactionIdJuno = pagamentoJunoSaida.transactionId;

                if (pagamentoJunoSaida.payments != null && pagamentoJunoSaida.payments.Count > 0)
                {
                    foreach (Payment payment in pagamentoJunoSaida.payments)
                    {
                        TransacaoDetalhe detalhe = await _transacaoDetalheRepositorio.RecuperarPorChargeId(payment.chargeId);

                        if (payment.status.Equals("CONFIRMED"))
                        {
                            if (detalhe != null)
                            {
                                detalhe.PagamentoIdJuno = payment.id;
                                detalhe.TaxaJuno = payment.fee;
                                detalhe.DataCompensacao = Utilidades.Funcoes.TransformarDataJuno(payment.releaseDate);
                                detalhe.PagamentoCriado = true;
                            }
                            else
                            {
                                transacao.FalhaPagamento += string.Concat("DETALHE CÓD: ", payment.chargeId, " NÃO ENCONTRADO NO BANCO DE DADOS: ", response.Content);
                                transacao.PagamentoCriado = false;
                            }
                        }
                        else
                        {
                            if (detalhe != null)
                            {
                                detalhe.PagamentoCriado = false;
                                detalhe.FalhaPagamento = response.Content;
                            }
                            else
                            {
                                transacao.PagamentoCriado = false;
                                transacao.FalhaPagamento = response.Content;
                            }
                        }

                        if (detalhe != null)
                            await _transacaoDetalheRepositorio.Alterar(detalhe);
                    }
                }
                else
                {
                    transacao.PagamentoCriado = false;
                    transacao.FalhaPagamento = response.Content;
                    transacao.StatusTransacao = StatusTransacao.REJEITADA;
                }
            }
            else
            {
                transacao.PagamentoCriado = false;
                transacao.FalhaPagamento = response.Content;
                transacao.StatusTransacao = StatusTransacao.REJEITADA;
            }

            return transacao;
        }

        public async Task<Transacao> SolicitarEstorno(int transacaoId, ConfiguracaoJuno configuracaoJuno)
        {
            try
            {


                if (DateTime.Now > configuracaoJuno.ProximoToken)
                {
                    configuracaoJuno = obterTokenAcesso(configuracaoJuno);
                    await _configuracaoJunoRepositorio.Alterar(configuracaoJuno);
                }

                //Encontrar o primeiro pay_code e concatenar no restClient.
                List<TransacaoDetalhe> listaTransacaoDetalhe = await _transacaoDetalheRepositorio.RecuperarPorTransacao(transacaoId);
                Transacao transacao = await _transacaoRepositorio.RecuperarPorCodigo(transacaoId);
                string paymentId = "";
                if (listaTransacaoDetalhe != null && listaTransacaoDetalhe.Count > 0)
                    paymentId = listaTransacaoDetalhe[0].PagamentoIdJuno;

                RestClient client = null;
                if (AMBIENTE_PRODUCAO)
                    client = new RestClient(string.Concat("https://api.juno.com.br/payments/", paymentId, "/refunds"));
                else
                    client = new RestClient(string.Concat("https://sandbox.boletobancario.com/api-integration/payments/", paymentId, "/refunds"));


                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("X-Resource-Token", configuracaoJuno.ClientResourceToken);
                request.AddHeader("authorization", string.Concat("Bearer ", configuracaoJuno.Token));
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("X-Api-Version", "2");
                request.AddHeader("Content-Type", "application/json");

                IRestResponse response = client.Execute(request);

                EstornoJunoSaida estornoJunoSaida = JsonConvert.DeserializeObject<EstornoJunoSaida>(response.Content);
                if (estornoJunoSaida != null)
                {
                    List<TransacaoDetalhe> listaTransacaoDetalheEstornado = new List<TransacaoDetalhe>();
                    if (estornoJunoSaida.transactionId.Equals(transacao.TransactionIdJuno))
                    {
                        foreach (Refund refund in estornoJunoSaida.refunds)
                        {
                            TransacaoDetalhe transacaoDetalhe = listaTransacaoDetalhe.Find(x => x.PagamentoIdJuno.Equals(refund.id));
                            if (refund.status.Equals("CUSTOMER_PAID_BACK"))
                            {
                                transacaoDetalhe.Estorno = true;
                                transacaoDetalhe.DataEstorno = DateTime.Now;
                                listaTransacaoDetalheEstornado.Add(transacaoDetalhe);
                            }
                            else
                            {
                                transacaoDetalhe.Estorno = false;
                            }
                        }

                        //Verificar quantas parcelas foram estornadas para dar o status de estorno parcial ou total
                        if (listaTransacaoDetalheEstornado.Count > 0 && listaTransacaoDetalhe.Count != listaTransacaoDetalheEstornado.Count)
                        {
                            transacao.StatusTransacao = StatusTransacao.ESTORNO_PARCIAL_APROVADO;
                            transacao.Estorno = true;
                            transacao.DataEstorno = DateTime.Now;
                        }
                        else if (listaTransacaoDetalheEstornado.Count > 0 && listaTransacaoDetalhe.Count == listaTransacaoDetalheEstornado.Count)
                        {
                            transacao.StatusTransacao = StatusTransacao.ESTORNO_APROVADO;
                            transacao.Estorno = true;
                            transacao.DataEstorno = DateTime.Now;
                        }
                        else
                        {
                            transacao.Estorno = false;
                            transacao.StatusTransacao = StatusTransacao.ESTORNO_REJEITADO;
                        }

                        //Salvar o json de retorno
                        transacao.EstornoJson = response.Content;

                        //Realizar as alterações no banco de dados
                        await _transacaoRepositorio.Alterar(transacao);
                        await _transacaoDetalheRepositorio.Alterar(listaTransacaoDetalheEstornado);

                        return transacao;
                    }
                    else
                    {
                        transacao.Estorno = false;
                        transacao.StatusTransacao = StatusTransacao.ESTORNO_REJEITADO;
                        return transacao;
                    }
                }
                else
                {
                    transacao.Estorno = false;
                    transacao.StatusTransacao = StatusTransacao.ESTORNO_REJEITADO;
                    return transacao;
                }
            }
            catch (Exception)
            {
                Transacao transacao = await _transacaoRepositorio.RecuperarPorCodigo(transacaoId);
                if (transacao != null)
                {
                    transacao.Estorno = false;
                    transacao.StatusTransacao = StatusTransacao.ESTORNO_REJEITADO;
                    return transacao;
                }
                else
                    return new Transacao();
            }
        }

    }
}
