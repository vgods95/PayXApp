using PayxApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayxApp.Interfaces
{
    public interface ITransacaoRepositorio : IRepositorioGenerico<Transacao>
    {
        Task<IEnumerable<Transacao>> RecuperarPorUsuario(string usuarioId);
    }
}
