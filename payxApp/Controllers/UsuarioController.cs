using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PayxApp.Interfaces;
using PayxApp.Models;
using PayxApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ICidadeRepositorio _cidadeRepositorio;
        private readonly ITransacaoRepositorio _transacaoRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, ICidadeRepositorio cidadeRepositorio, ITransacaoRepositorio transacaoRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _cidadeRepositorio = cidadeRepositorio;
            _transacaoRepositorio = transacaoRepositorio;
        }

        public async Task<IActionResult> Index()
        {
            Usuario usuario = await _usuarioRepositorio.RecuperarPorNome(User);
            IEnumerable<Transacao> transacoes = await _transacaoRepositorio.RecuperarPorUsuario(usuario.Id);
            return View(transacoes);
        }

        [HttpGet]
        public async Task<IActionResult> ListarTransacoes()
        {
            Usuario usuario = await _usuarioRepositorio.RecuperarPorNome(User);
            IEnumerable<Transacao> transacoes = await _transacaoRepositorio.RecuperarPorUsuario(usuario.Id);

            return PartialView("..\\Transacao\\_TransacoesUsuario", transacoes);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<string> Cidades(string estado)
        {
            try
            {
                return JsonConvert.SerializeObject(await _cidadeRepositorio.ListarCidadePorEstado(estado));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Analise(Usuario usuario)
        {
            return View(usuario);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registro(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario();
                IdentityResult usuarioCriado;

                usuario.UserName = Guid.NewGuid().ToString();
                usuario.Cpf = model.Cpf;
                usuario.NomeCompleto = model.Nome;
                usuario.Cep = model.Cep;
                usuario.Logradouro = model.Logradouro;
                usuario.Numero = model.Numero;
                usuario.Complemento = model.Complemento;
                usuario.Bairro = model.Bairro;
                usuario.CidadeId = Convert.ToInt32(model.Cidade);
                usuario.DataNascimento = Convert.ToDateTime(model.DataNascimento);
                usuario.Sexo = model.Sexo.Equals("Masculino") ? "M" : "F";
                usuario.Email = model.Email;
                usuario.PhoneNumber = model.Celular;

                usuarioCriado = await _usuarioRepositorio.RegistrarUsuario(usuario, model.Senha);

                if (usuarioCriado.Succeeded)
                {
                    if (model.Cpf.Equals("428.014.468-07") || model.Cpf.Equals("428.014.468-07"))
                        await _usuarioRepositorio.IncluirUsuarioEmFuncao(usuario, "Administrador");
                    else
                        await _usuarioRepositorio.IncluirUsuarioEmFuncao(usuario, "Usuario");

                    string token = await _usuarioRepositorio.GerarTokenConfirmacaoEmail(usuario);
                    var confirmacaoLink = Url.Action("ConfirmarEmail", "Usuario", new { token, email = usuario.Email }, Request.Scheme);
                    Utilidades.Funcoes.EnviarEmailTokenConfirmacao(usuario, confirmacaoLink);
                    return RedirectToAction("Analise", "Usuario", usuario); //Precisa mudar
                }
                else
                {
                    foreach (IdentityError erro in usuarioCriado.Errors)
                    {
                        string mensagem = "";
                        switch (erro.Description)
                        {
                            case "Passwords must be at least 8 characters.":
                                mensagem = "As senhas devem ter pelo menos 8 caracteres.";
                                break;
                            case "Passwords must have at least one non alphanumeric character.":
                                mensagem = "As senhas devem ter pelo menos um caractere não alfanumérico.";
                                break;
                            case "Passwords must have at least one lowercase(a - z).":
                                mensagem = "As senhas devem ter pelo menos uma letra minúscula ('a' - 'z').";
                                break;
                            case "Passwords must have at least one uppercase(A - Z).":
                                mensagem = "As senhas devem ter pelo menos uma letra maiúscula ('A' - 'Z').";
                                break;
                            case "Passwords must have at least one digit('0' - '9').":
                                mensagem = "As senhas devem ter pelo menos um número (0 - 9).";
                                break;
                            default:
                                mensagem = "";
                                break;
                        }

                        ModelState.AddModelError("", mensagem);
                    }
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ConfirmarEmail(string token, string email)
        {
            Usuario usuario = await _usuarioRepositorio.RecuperarUsuarioPorEmail(email);
            if (usuario == null)
                return BadRequest();

            var result = await _usuarioRepositorio.ConfirmarEmail(usuario, token);

            if (result.Succeeded)
            {
                await _usuarioRepositorio.LogarUsuario(usuario);
                return RedirectToAction(nameof(Index));
            }
            else
                return BadRequest();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
                await _usuarioRepositorio.DeslogarUsuario();

            return View();
        }

        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                Usuario usuario = _usuarioRepositorio.RecuperarUsuarioPorCpf(model.Cpf);
                
                if (usuario != null)
                {
                    if (await _usuarioRepositorio.VerificarEmailConfirmado(usuario))
                    {
                        PasswordHasher<Usuario> passwordHasher = new PasswordHasher<Usuario>();
                        if (passwordHasher.VerifyHashedPassword(usuario, usuario.PasswordHash, model.Senha) != PasswordVerificationResult.Failed)
                        {
                            await _usuarioRepositorio.LogarUsuario(usuario);
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Usuário e/ou senha inválidos!");
                            return View(model);
                        }
                    }
                    else
                    {
                        string token = await _usuarioRepositorio.GerarTokenConfirmacaoEmail(usuario);
                        var confirmacaoLink = Url.Action("ConfirmarEmail", "Usuario", new { token, email = usuario.Email }, Request.Scheme);
                        Utilidades.Funcoes.EnviarEmailTokenConfirmacao(usuario, confirmacaoLink);
                        ModelState.AddModelError("", "Confirme seu e-mail para prosseguir!");
                        //reenviar
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Usuário e/ou senha inválidos!");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Usuário e/ou senha inválidos!");
                return View(model);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _usuarioRepositorio.DeslogarUsuario();
            return RedirectToAction("Login");
        }
    }
}