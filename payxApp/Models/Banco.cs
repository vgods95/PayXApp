using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayxApp.Models
{
    public class Banco
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }

        [NotMapped]
        public virtual IEnumerable<Conta> Contas { get; set; }
    }
}
