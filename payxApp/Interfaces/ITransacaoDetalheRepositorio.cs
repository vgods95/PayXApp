using PayxApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayxApp.Interfaces
{
    public interface ITransacaoDetalheRepositorio : IRepositorioGenerico<TransacaoDetalhe>
    {
        Task<List<TransacaoDetalhe>> RecuperarPorTransacao(int transacaoId);
        Task<TransacaoDetalhe> RecuperarPorChargeId(string ChargeId);
    }
}
