using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayxApp.Models
{
    public class TransacaoDetalhe
    {
        public int Id { get; set; }
        public string ChargeId { get; set; }
        public string ChargeCode { get; set; }
        public int TransacaoId { get; set; }
        public double ValorParcela { get; set; }

        
        public string? PagamentoIdJuno { get; set; }
        public double? TaxaJuno { get; set; }
        public bool PagamentoCriado { get; set; }
        public string? FalhaPagamento { get; set; }
        public DateTime? DataCompensacao { get; set; }

        public bool Estorno { get; set; }
        public DateTime? DataEstorno { get; set; }

        [NotMapped]
        public virtual Transacao Transacao { get; set; }
    }
}
