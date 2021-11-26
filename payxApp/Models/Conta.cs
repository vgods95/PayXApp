using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayxApp.Models
{
    public class Conta
    {
        public int Id { get; set; }
        public string NomeCompletoDestinatario { get; set; }
        public int BancoId { get; set; }

        [NotMapped]
        public virtual Banco Banco { get; set; }

        public string AgenciaDestino { get; set; }
        public string DigitoAgencia { get; set; }
        public string NumeroContaDestino { get; set; }
        public string DigitoConta { get; set; }
        public TipoConta TipoConta { get; set; }
        public string? NumeroOperacaoCaixa { get; set; }
        public string CpfCnpjDestino { get; set; }
        public string UsuarioId { get; set; }

        [NotMapped]
        public virtual Usuario Usuario { get; set; }

        [NotMapped]
        public virtual IEnumerable<Transacao> Transacoes { get; set; }
    }

    public enum TipoConta
    {
        CORRENTE,
        POUPANCA
    }
}
