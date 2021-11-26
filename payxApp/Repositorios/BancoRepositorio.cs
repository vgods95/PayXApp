using PayxApp.Interfaces;
using PayxApp.Models;

namespace PayxApp.Repositorios
{
    public class BancoRepositorio : RepositorioGenerico<Banco>, IBancoRepositorio
    {
        public BancoRepositorio(Context contexto) : base(contexto)
        {
        }
    }
}
