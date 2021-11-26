using Microsoft.EntityFrameworkCore;
using PayxApp.Interfaces;
using PayxApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Repositorios
{
    public class CartaoCreditoRepositorio : RepositorioGenerico<CartaoCredito>, ICartaoCreditoRepositorio
    {
        private readonly Context _contexto;

        public CartaoCreditoRepositorio(Context contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<CartaoCredito> RecuperarPeloHash(string hashCartao, string codigoUsuario)
        {
            try
            {
                return await _contexto.Cartoes
                    .Where(x => x.UsuarioId == codigoUsuario && x.HashCartao == hashCartao).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CartaoCredito> RecuperarPelosQuatroUltimosDigitos(string ultimosDigitos, string codigoUsuario)
        {
            try
            {
                return await _contexto.Cartoes
                    .Where(x => x.UsuarioId == codigoUsuario && x.UltimosQuatroDigitos == ultimosDigitos).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
