using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.ViewModels
{
    public class TransacaoDetalheViewModel
    {
        public int Id { get; set; }
        public DateTime DataTransacao { get; set; }
        public double ValorSolicitado { get; set; }
        public double ValorFinal { get; set; }
        public string Parcelamento { get; set; }
        public string QuatroUltimosDigitos { get; set; }
        public string Bandeira { get; set; }
        public string CodigoBarrasBoleto { get; set; }
        public string DescricaoDoPagamento { get; set; }
        public string CnpjBeneficiario { get; set; }
        public string DataEmissao { get; set; }
        public string DataVencimento { get; set; }
        public string NomeCompletoDestinatario { get; set; }
        public string BancoDestino { get; set; }
        public string AgenciaDestino { get; set; }
        public string DigitoAgencia { get; set; }
        public string NumeroContaDestino { get; set; }
        public string DigitoConta { get; set; }
        public string TipoConta { get; set; }
        public string NumeroOperacaoCaixa { get; set; }
        public string CpfCnpjDestino { get; set; }
        public string StatusAtual { get; set; }
        public List<Evento> ListaEventos { get; set; }
        //Status e suas alterações
        //Cobranca criada = 0 - falha_pagamento tem um json de retorno
        //pagamento criado = 0 - falha_pagamento tem um json de retorno
        //data estorno se estorno = 1
        //se estorno parcial tem um estorno json
        //data de porocessamento
        //aprovacao_reprovacao (usuario, data e motivo)
        //conclusao
    }

    public class Evento
    {
        /// <summary>
        /// COBRANÇA CRIADA, PAGAMENTO CRIADO, ESTORNO, ESTORNO PARCIAL, PROCESSAMENTO, APROVAÇÃO, REPROVAÇÃO, CONCLUSÃO
        /// </summary>
        public string NomeEvento { get; set; }
        public DateTime DataEvento { get; set; }
        /// <summary>
        /// Desmembrar os jsons (falha_pagamento, estorno_parcial_json, motivo_reprovação)
        /// </summary>
        public string Detalhes { get; set; }
    }
}
