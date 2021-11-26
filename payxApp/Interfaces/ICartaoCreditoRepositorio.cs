using PayxApp.Models;
using System.Threading.Tasks;

namespace PayxApp.Interfaces
{
    public interface ICartaoCreditoRepositorio : IRepositorioGenerico<CartaoCredito>
    {
        Task<CartaoCredito> RecuperarPelosQuatroUltimosDigitos(string ultimosDigitos, string codigoUsuario);
        Task<CartaoCredito> RecuperarPeloHash(string hashCartao, string codigoUsuario);
    }
}
