using Microsoft.EntityFrameworkCore;
using PayxApp.Interfaces;
using PayxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Repositorios
{
    public class TransacaoRepositorio : RepositorioGenerico<Transacao>, ITransacaoRepositorio
    {
        private readonly Context _contexto;

        public TransacaoRepositorio(Context contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Transacao>> RecuperarPorUsuario(string usuarioId)
        {
            try
            {
                return await _contexto.Transacoes.Where(x => x.UsuarioId.Equals(usuarioId)).OrderByDescending(x => x.Id).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
