using PayxApp.Models;
using PayxApp.Interfaces;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;

namespace PayxApp.Repositorios
{
    public class UsuarioRepositorio : RepositorioGenerico<Usuario>, IUsuarioRepositorio
    {
        private readonly Context _contexto;
        private readonly UserManager<Usuario> _gerenciadorUsuarios;
        private readonly SignInManager<Usuario> _gerenciadorLogin;

        public UsuarioRepositorio(Context contexto, UserManager<Usuario> gerenciadorUsuarios, SignInManager<Usuario> gerenciadorLogin) : base(contexto)
        {
            _contexto = contexto;
            _gerenciadorUsuarios = gerenciadorUsuarios;
            _gerenciadorLogin = gerenciadorLogin;
        }

        public async Task IncluirUsuarioEmFuncao(Usuario usuario, string funcao)
        {
            try
            {
                await _gerenciadorUsuarios.AddToRoleAsync(usuario, funcao);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task LogarUsuario(Usuario usuario)
        {
            try
            {
                await _gerenciadorLogin.SignInAsync(usuario, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> VerificarEmailConfirmado(Usuario usuario)
        {
            try
            {
                return await _gerenciadorUsuarios.IsEmailConfirmedAsync(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeslogarUsuario()
        {
            try
            {
                await _gerenciadorLogin.SignOutAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Usuario RecuperarUsuarioPorCpf(string cpf)
        {
            try
            {
                return _contexto.Usuarios.Where(x => x.Cpf.Equals(cpf)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IdentityResult> RegistrarUsuario(Usuario usuario, string senha)
        {
            try
            {
                return await _gerenciadorUsuarios.CreateAsync(usuario, senha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Usuario> RecuperarPorNome(ClaimsPrincipal usuario)
        {
            try
            {
                return await _gerenciadorUsuarios.FindByNameAsync(usuario.Identity.Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GerarTokenConfirmacaoEmail(Usuario usuario)
        {
            try
            {
                return await _gerenciadorUsuarios.GenerateEmailConfirmationTokenAsync(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Usuario> RecuperarUsuarioPorEmail(string email)
        {
            try
            {
                return await _gerenciadorUsuarios.FindByEmailAsync(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IdentityResult> ConfirmarEmail(Usuario usuario, string token)
        {
            try
            {
                return await _gerenciadorUsuarios.ConfirmEmailAsync(usuario, token);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
