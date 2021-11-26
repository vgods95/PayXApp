using Microsoft.AspNetCore.Identity;
using PayxApp.Models;
using System.Security.Claims;
using System.Threading.Tasks;


namespace PayxApp.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorioGenerico<Usuario>
    {
        Task LogarUsuario(Usuario usuario);
        Task DeslogarUsuario();
        Task<IdentityResult> RegistrarUsuario(Usuario usuario, string senha);
        Task IncluirUsuarioEmFuncao(Usuario usuario, string funcao);
        Usuario RecuperarUsuarioPorCpf(string cpf);
        Task<Usuario> RecuperarUsuarioPorEmail(string email);
        Task<Usuario> RecuperarPorNome(ClaimsPrincipal usuario);
        Task<bool> VerificarEmailConfirmado(Usuario usuario);
        Task<string> GerarTokenConfirmacaoEmail(Usuario usuario);
        Task<IdentityResult> ConfirmarEmail(Usuario usuario, string token);
    }
}
