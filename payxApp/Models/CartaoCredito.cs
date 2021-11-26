using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Models
{
    public class CartaoCredito
    {
        public int Id { get; set; }
        public string UltimosQuatroDigitos { get; set; }
        public string MesExpiracao { get; set; }
        public string AnoExpiracao { get; set; }
        public string HashCartao { get; set; }
        public string UsuarioId { get; set; }
        public string Bandeira { get; set; }

        [NotMapped]
        public virtual Usuario Usuario { get; set; }

        [NotMapped]
        public virtual IEnumerable<Transacao> Transacoes { get; set; }
    }
}
