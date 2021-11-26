using System;

namespace PayxApp.ViewModels
{
    public class TransacaoViewModel
    {
        //Cabeçalho
        public string ValorPedido { get; set; }
        public int Parcelas { get; set; }
        public string TipoTransacao { get; set; }
        public string ParcelasJson { get; set; }

        //Conta
        public string NomeConta { get; set; }
        public string CpfCnpjConta { get; set; }
        public string Banco { get; set; }
        public string TipoConta { get; set; }
        public string Agencia { get; set; }
        public string DigitoAgencia { get; set; }
        public string NumConta { get; set; }
        public string DigitoConta { get; set; }
        public string Operacao { get; set; }

        //Boleto
        public string LinhaDigitavel { get; set; }
        public string DescricaoPagto { get; set; }
        public string CnpjBeneficiario { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }

        //Cartão
        public string HashCartao { get; set; }
        public string NumeroCartao { get; set; }
        public string MesExpiracao { get; set; }
        public string AnoExpiracao { get; set; }
        public string Bandeira { get; set; }
    }
}
