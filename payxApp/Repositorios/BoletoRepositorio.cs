using PayxApp.Interfaces;
using PayxApp.Models;

namespace PayxApp.Repositorios
{
    public class BoletoRepositorio : RepositorioGenerico<Boleto>, IBoletoRepositorio
    {
        public BoletoRepositorio(Context contexto) : base(contexto)
        {
        }
    }
}
