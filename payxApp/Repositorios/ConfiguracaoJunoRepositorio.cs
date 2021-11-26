using PayxApp.Interfaces;
using PayxApp.Models;

namespace PayxApp.Repositorios
{
    public class ConfiguracaoJunoRepositorio : RepositorioGenerico<ConfiguracaoJuno>, IConfiguracaoJunoRepositorio
    {
        public ConfiguracaoJunoRepositorio(Context contexto) : base(contexto)
        {
        }
    }
}
