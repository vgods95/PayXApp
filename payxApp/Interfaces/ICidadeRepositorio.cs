using PayxApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayxApp.Interfaces
{
    public interface ICidadeRepositorio : IRepositorioGenerico<Cidade>
    {
        Task<IEnumerable<Cidade>> ListarCidadePorEstado(string estado);
    }
}
