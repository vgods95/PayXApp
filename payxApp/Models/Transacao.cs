using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayxApp.Models
{
    public class Transacao
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        
        [NotMapped]
        public virtual Usuario Usuario  { get; set; }
        public DateTime DataTransacao { get; set; }
        public double ValorFinalTransacao { get; set; }
        public double ValorTransacao { get; set; }
        public double ValorCusto { get; set; }
        public int Parcelamento { get; set; }
        public int? CartaoCreditoId { get; set; }

        [NotMapped]
        public virtual CartaoCredito CartaoCredito { get; set; }
        public int? BoletoId { get; set; }
        public int? ContaId { get; set; }

        [NotMapped]
        public virtual Boleto Boleto { get; set; }
        [NotMapped]
        public virtual Conta Conta { get; set; }
        public StatusTransacao StatusTransacao { get; set; }
        public bool CobrancaCriada { get; set; }
        public string DesmembramentoParcelasJson { get; set; }
        public string? TransactionIdJuno { get; set; }
        public bool PagamentoCriado { get; set; }
        public string? FalhaPagamento { get; set; }

        public bool Estorno { get; set; }
        public DateTime? DataEstorno { get; set; }
        public string? EstornoJson { get; set; }

        public DateTime? DataAprovacaoReprovacao { get; set; }
        public DateTime? DataProcessamento { get; set; }
        public string? MotivoReprovacao { get; set; }
        public string? UsuarioAprovacaoReprovacaoId { get; set; }
        
        [NotMapped]
        public virtual Usuario UsuarioAprovacaoReprovacao { get; set; }

        [NotMapped]
        public virtual IEnumerable<TransacaoDetalhe> TransacaoDetalhe { get; set; }
    }

    public enum StatusTransacao
    {
        EM_ABERTO,
        APROVADA,
        REJEITADA,
        EM_PROCESSAMENTO,
        PEDIDO_CANCELAMENTO,
        ESTORNO_APROVADO,
        ESTORNO_REJEITADO,
        ESTORNO_PARCIAL_APROVADO,
        CONCLUIDA
    }
}
