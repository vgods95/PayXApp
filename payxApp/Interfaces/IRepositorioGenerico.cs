using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayxApp.Interfaces
{
    public interface IRepositorioGenerico<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> ListarTodos();
        Task<TEntity> RecuperarPorCodigo(int codigo);
        Task<TEntity> RecuperarPorCodigo(string codigo);
        Task<int> Inserir(TEntity entity);
        Task<int> Inserir(List<TEntity> entities);
        Task Alterar(List<TEntity> entities);
        Task Alterar(TEntity entity);
        Task Excluir(int codigo);
        Task Excluir(string codigo);
        Task Excluir(TEntity entity);
        Task<IEnumerable<TEntity>> recuperarComFraseSql(string fraseSQL);
    }
}
