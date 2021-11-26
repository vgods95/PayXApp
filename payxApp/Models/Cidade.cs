using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayxApp.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public string NomeCidade { get; set; }
        public string CodigoCidade { get; set; }
        public string SiglaEstado { get; set; }
        public string CodigoEstado { get; set; }
        public string CodigoPais { get; set; }
        public string NomePais { get; set; }

        [NotMapped]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
