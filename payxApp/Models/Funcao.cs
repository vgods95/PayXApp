using Microsoft.AspNetCore.Identity;

namespace PayxApp.Models
{
    public class Funcao : IdentityRole<string>
    {
        public string Descricao { get; set; }
    }
}
