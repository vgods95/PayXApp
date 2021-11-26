using PayxApp.Interfaces;
using PayxApp.Models;

namespace PayxApp.Repositorios
{
    public class SimulacaoRepositorio : RepositorioGenerico<Simulacao>, ISimulacaoRepositorio
    {
        public SimulacaoRepositorio(Context contexto) : base(contexto)
        {
        }
    }
}
