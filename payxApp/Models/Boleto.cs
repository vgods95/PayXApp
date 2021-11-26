using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayxApp.Models
{
    public class Boleto
    {
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public string DescricaoDoPagamento { get; set; }
        public string CnpjBeneficiario { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public string UsuarioId { get; set; }

        [NotMapped]
        public virtual Usuario Usuario { get; set; }

        [NotMapped]
        public virtual Transacao Transacao { get; set; }
    }
}
