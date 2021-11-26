using System;

namespace PayxApp.Models
{
    public class ConfiguracaoJuno
    {
        public int Id { get; set; }
        public string Cnpj { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ClientResourceToken { get; set; }
        public DateTime ProximoToken { get; set; }
        public string Token { get; set; }
        public string PublicToken { get; set; }
    }
}
