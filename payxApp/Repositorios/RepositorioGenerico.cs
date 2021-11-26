using Microsoft.EntityFrameworkCore;
using PayxApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayxApp.Repositorios
{
    public class RepositorioGenerico<TEntity> : IRepositorioGenerico<TEntity> where TEntity : class
    {
        private readonly Context _contexto;

        public RepositorioGenerico(Context contexto)
        {
            _contexto = contexto;
        }

        public async Task Alterar(TEntity entity)
        {
            try
            {
                _contexto.Set<TEntity>().Update(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Alterar(List<TEntity> entities)
        {
            try
            {
                _contexto.Set<TEntity>().UpdateRange(entities);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Excluir(int codigo)
        {
            try
            {
                var entity = await RecuperarPorCodigo(codigo);
                _contexto.Set<TEntity>().Remove(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Excluir(string codigo)
        {
            try
            {
                var entity = await RecuperarPorCodigo(codigo);
                _contexto.Set<TEntity>().Remove(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Excluir(TEntity entity)
        {
            try
            {
                _contexto.Set<TEntity>().Remove(entity);
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Inserir(TEntity entity)
        {
            try
            {
                await _contexto.AddAsync(entity);
                return await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> Inserir(List<TEntity> entities)
        {
            try
            {
                await _contexto.AddRangeAsync(entities);
                return await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TEntity>> ListarTodos()
        {
            try
            {
                return await _contexto.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<TEntity>> recuperarComFraseSql(string fraseSQL)
        {
            try
            {
                return await _contexto.Set<TEntity>().FromSqlRaw(fraseSQL).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> RecuperarPorCodigo(int codigo)
        {
            try
            {
                return await _contexto.Set<TEntity>().FindAsync(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> RecuperarPorCodigo(string codigo)
        {
            try
            {
                return await _contexto.Set<TEntity>().FindAsync(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
