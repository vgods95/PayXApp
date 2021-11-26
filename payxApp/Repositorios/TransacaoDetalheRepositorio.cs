using Microsoft.EntityFrameworkCore;
using PayxApp.Interfaces;
using PayxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Repositorios 
{
    public class TransacaoDetalheRepositorio : RepositorioGenerico<TransacaoDetalhe>, ITransacaoDetalheRepositorio
    {
        private readonly Context _contexto;

        public TransacaoDetalheRepositorio(Context contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<TransacaoDetalhe> RecuperarPorChargeId(string ChargeId)
        {
            try
            {
                return await _contexto.TransacoesDetalhe.Where(x => x.ChargeId == ChargeId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TransacaoDetalhe>> RecuperarPorTransacao(int transacaoId)
        {
            try
            {
                return await _contexto.TransacoesDetalhe.Where(x => x.TransacaoId == transacaoId).OrderBy(x => x.Id).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
