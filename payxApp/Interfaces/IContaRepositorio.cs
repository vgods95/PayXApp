using PayxApp.Models;
using System.Threading.Tasks;

namespace PayxApp.Interfaces
{
    public interface IContaRepositorio : IRepositorioGenerico<Conta>
    {
        Task<Conta> RecuperarDadosUsuario(int codigoBanco, string agencia, string numeroConta, string cpfCnpj, string codigoUsuario);
    }
}
