using Microsoft.EntityFrameworkCore;
using PayxApp.Interfaces;
using PayxApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Repositorios
{
    public class CidadeRepositorio : RepositorioGenerico<Cidade>, ICidadeRepositorio
    {
        public readonly Context _contexto;
        public CidadeRepositorio(Context contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Cidade>> ListarCidadePorEstado(string estado)
        {
            try
            {
                return await _contexto.Set<Cidade>()
                    .Where(x => x.SiglaEstado.Equals(estado))
                    .OrderBy(x => x.NomeCidade)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
