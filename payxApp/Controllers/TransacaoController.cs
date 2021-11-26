using Microsoft.AspNetCore.Mvc;
using PayxApp.ViewModels;
using PayxApp.Models;
using System;
using System.Threading.Tasks;
using PayxApp.Interfaces;
using PayxApp.Requisicoes;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PayxApp.Controllers
{
    public class TransacaoController : Controller
    {
        private readonly ITransacaoRepositorio _transacaoRepositorio;
        private readonly ICartaoCreditoRepositorio _cartaoCreditoRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IBoletoRepositorio _boletoRepositorio;
        private readonly IContaRepositorio _contaRepositorio;
        private readonly IConfiguracaoJunoRepositorio _configuracaoJunoRepositorio;
        private readonly ICidadeRepositorio _cidadeRepositorio;
        private readonly ITransacaoDetalheRepositorio _transacaoDetalheRepositorio;


        public TransacaoController(ITransacaoRepositorio transacaoRepositorio, ICartaoCreditoRepositorio cartaoCreditoRepositorio, IUsuarioRepositorio usuarioRepositorio, IConfiguracaoJunoRepositorio configuracaoJunoRepositorio, IBoletoRepositorio boletoRepositorio, IContaRepositorio contaRepositorio, ICidadeRepositorio cidadeRepositorio, ITransacaoDetalheRepositorio transacaoDetalheRepositorio)
        {
            _transacaoRepositorio = transacaoRepositorio;
            _cartaoCreditoRepositorio = cartaoCreditoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _configuracaoJunoRepositorio = configuracaoJunoRepositorio;
            _contaRepositorio = contaRepositorio;
            _boletoRepositorio = boletoRepositorio;
            _cidadeRepositorio = cidadeRepositorio;
            _transacaoDetalheRepositorio = transacaoDetalheRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> VisualizarTransacao(int transacaoId)
        {
            Transacao transacao = await _transacaoRepositorio.RecuperarPorCodigo(transacaoId);
            TransacaoDetalheViewModel transacaoDetalheViewModel = TransformarTransacaoEmDetalheViewModel(transacao);
            return View("VisualizarTransacao", transacaoDetalheViewModel);

        }

        public TransacaoDetalheViewModel TransformarTransacaoEmDetalheViewModel(Transacao transacao)
        {
            return new TransacaoDetalheViewModel();
        }

        [HttpPost]
        public async Task<bool> EstornarTransacao(int transacaoId)
        {
            try
            {
                RequisicoesJuno requisicoesJuno = new RequisicoesJuno(_configuracaoJunoRepositorio, _cidadeRepositorio, _transacaoDetalheRepositorio, _transacaoRepositorio);
                ConfiguracaoJuno configuracaoJuno = await _configuracaoJunoRepositorio.RecuperarPorCodigo(1);

                //Realizar as requisições
                Transacao transacao = await requisicoesJuno.SolicitarEstorno(transacaoId, configuracaoJuno);

                if (transacao != null && transacao.StatusTransacao == StatusTransacao.ESTORNO_APROVADO || transacao.StatusTransacao == StatusTransacao.ESTORNO_PARCIAL_APROVADO)
                    return true;
                    
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        public async Task<bool> ReprovarTransacao(int transacaoId, string motivoReprovacao)
        {
            Transacao transacao = await _transacaoRepositorio.RecuperarPorCodigo(transacaoId);
            Usuario usuario = await _usuarioRepositorio.RecuperarPorNome(User);

            if (transacao != null && transacao.StatusTransacao == StatusTransacao.EM_PROCESSAMENTO)
            {
                transacao.DataAprovacaoReprovacao = DateTime.Now;
                transacao.StatusTransacao = StatusTransacao.REJEITADA;
                transacao.MotivoReprovacao = motivoReprovacao;
                transacao.UsuarioAprovacaoReprovacaoId = usuario.Id;
                await _transacaoRepositorio.Alterar(transacao);
                return true;
            }

            return false;
        }

        [HttpPost]
        public async Task<bool> AprovarTransacao(int transacaoId)
        {
            Transacao transacao = await _transacaoRepositorio.RecuperarPorCodigo(transacaoId);
            Usuario usuario = await _usuarioRepositorio.RecuperarPorNome(User);

            if (transacao != null && transacao.StatusTransacao == StatusTransacao.EM_PROCESSAMENTO)
            {
                transacao.DataAprovacaoReprovacao = DateTime.Now;
                transacao.StatusTransacao = StatusTransacao.APROVADA;
                transacao.UsuarioAprovacaoReprovacaoId = usuario.Id;
                await _transacaoRepositorio.Alterar(transacao);
                return true;
            }

            return false;
        }

        [HttpPost]
        public async Task<bool> ProcessarTransacao(int transacaoId)
        {
            Transacao transacao = await _transacaoRepositorio.RecuperarPorCodigo(transacaoId);
            
            if (transacao != null && transacao.StatusTransacao == StatusTransacao.EM_ABERTO)
            {
                transacao.DataProcessamento = DateTime.Now;
                transacao.StatusTransacao = StatusTransacao.EM_PROCESSAMENTO;
                await _transacaoRepositorio.Alterar(transacao);
                return true;
            }
                
            return false;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastrarTransacao(TransacaoViewModel model)
        {
            try
            {
                //Recuperando o usuário logado e instanciando uma nova transação
                Usuario usuario = await _usuarioRepositorio.RecuperarPorNome(User);
                Transacao transacao = new Transacao();

                //Verificando se o usuário utilizou um cartão de crédito já existente na nossa base
                transacao.CartaoCredito = await _cartaoCreditoRepositorio.RecuperarPeloHash(model.HashCartao, usuario.Id);
                if (transacao.CartaoCredito == null)
                {
                    //Como não foi encontrado nenhum cartão em nossa base iremos instanciar e salvar um novo.
                    transacao.CartaoCredito = new CartaoCredito();
                    transacao.CartaoCredito.UltimosQuatroDigitos = model.NumeroCartao.Substring(model.NumeroCartao.Length - 4);
                    transacao.CartaoCredito.MesExpiracao = model.MesExpiracao;
                    transacao.CartaoCredito.AnoExpiracao = model.AnoExpiracao;
                    transacao.CartaoCredito.HashCartao = model.HashCartao;
                    if (!string.IsNullOrEmpty(model.Bandeira))
                        transacao.CartaoCredito.Bandeira = model.Bandeira;
                    transacao.CartaoCredito.UsuarioId = usuario.Id;
                    await _cartaoCreditoRepositorio.Inserir(transacao.CartaoCredito);
                }

                transacao.CartaoCreditoId = transacao.CartaoCredito.Id;
                transacao.Parcelamento = model.Parcelas;
                transacao.DesmembramentoParcelasJson = model.ParcelasJson;
                transacao.StatusTransacao = StatusTransacao.EM_ABERTO;
                transacao.ValorTransacao = Convert.ToDouble(model.ValorPedido.Replace(".", ","));

                //Testa se o tipo de transação é o pagamento de um boleto para preencher os campos próprios
                if (model.TipoTransacao.Equals("boleto"))
                {
                    transacao.Boleto = new Boleto();
                    transacao.Boleto.CodigoBarras = model.LinhaDigitavel;
                    transacao.Boleto.DescricaoDoPagamento = model.DescricaoPagto;
                    transacao.Boleto.CnpjBeneficiario = model.CnpjBeneficiario;
                    transacao.Boleto.DataEmissao = model.DataEmissao;
                    transacao.Boleto.DataVencimento = model.DataVencimento;

                    transacao.Boleto.UsuarioId = usuario.Id;
                    //Salvar Boleto no banco de dados
                    await _boletoRepositorio.Inserir(transacao.Boleto);
                    transacao.BoletoId = transacao.Boleto.Id;
                } //Caso seja uma transferência
                else
                {
                    transacao.Conta = await _contaRepositorio.RecuperarDadosUsuario(Convert.ToInt32(model.Banco), model.Agencia, model.NumConta, model.CpfCnpjConta, usuario.Id);
                    if (transacao.Conta == null) //Caso a conta não exista, instancia uma nova e a grava no banco
                    {
                        transacao.Conta = new Conta();
                        transacao.Conta.NomeCompletoDestinatario = model.NomeConta;
                        transacao.Conta.BancoId = Convert.ToInt32(model.Banco);
                        transacao.Conta.AgenciaDestino = model.Agencia;
                        transacao.Conta.NumeroContaDestino = model.NumConta;

                        if (model.TipoConta.Equals("CORRENTE"))
                            transacao.Conta.TipoConta = TipoConta.CORRENTE;
                        else
                            transacao.Conta.TipoConta = TipoConta.POUPANCA;

                        if (model.Operacao != null)
                            transacao.Conta.NumeroOperacaoCaixa = model.Operacao;

                        transacao.Conta.CpfCnpjDestino = model.CpfCnpjConta;
                        transacao.Conta.UsuarioId = usuario.Id;

                        await _contaRepositorio.Inserir(transacao.Conta);
                        transacao.ContaId = transacao.Conta.Id;
                    }
                    else //Se existir verificar os campos e alterá-la  
                    {
                        transacao.ContaId = transacao.Conta.Id;
                        transacao.Conta.NomeCompletoDestinatario = model.NomeConta;
                        transacao.Conta.BancoId = Convert.ToInt32(model.Banco);
                        transacao.Conta.AgenciaDestino = model.Agencia;
                        transacao.Conta.NumeroContaDestino = model.NumConta;

                        if (model.TipoConta.Equals("CORRENTE"))
                            transacao.Conta.TipoConta = TipoConta.CORRENTE;
                        else
                            transacao.Conta.TipoConta = TipoConta.POUPANCA;

                        if (model.Operacao != null)
                            transacao.Conta.NumeroOperacaoCaixa = model.Operacao;

                        transacao.Conta.CpfCnpjDestino = model.CpfCnpjConta;
                        transacao.Conta.UsuarioId = usuario.Id;
                        await _contaRepositorio.Alterar(transacao.Conta);
                    }
                }

                List<DesmembramentoParcelasViewModel> desmembramento = JsonConvert.DeserializeObject<List<DesmembramentoParcelasViewModel>>(transacao.DesmembramentoParcelasJson);
                transacao.ValorFinalTransacao = Math.Round((desmembramento[transacao.Parcelamento - 1].ValorParcela * transacao.Parcelamento), 2);
                transacao.UsuarioId = usuario.Id;
                transacao.DataTransacao = DateTime.Now;
                transacao.ValorCusto = transacao.ValorTransacao;

                //Salvar a transação no BD
                await _transacaoRepositorio.Inserir(transacao);

                //Instanciar as dependencias da Juno
                RequisicoesJuno requisicoesJuno = new RequisicoesJuno(_configuracaoJunoRepositorio, _cidadeRepositorio, _transacaoDetalheRepositorio, _transacaoRepositorio);
                ConfiguracaoJuno configuracaoJuno = await _configuracaoJunoRepositorio.RecuperarPorCodigo(1);

                //Realizar as requisições
                transacao = await requisicoesJuno.criarCobranca(transacao, configuracaoJuno);
                await _transacaoRepositorio.Alterar(transacao);

                transacao = await requisicoesJuno.criarPagamento(transacao, configuracaoJuno);
                await _transacaoRepositorio.Alterar(transacao);

                return RedirectToAction("Index", "Usuario");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
