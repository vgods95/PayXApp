using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayxApp.Models;
using PayxApp.Interfaces;
using PayxApp.ViewModels;

namespace PayxApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context _contexto;
        private readonly IConfiguracaoJunoRepositorio _configuracaoJunoRepositorio;

        public HomeController(Context contexto, IConfiguracaoJunoRepositorio configuracaoJunoRepositorio)
        {
            _contexto = contexto;
            _configuracaoJunoRepositorio = configuracaoJunoRepositorio;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            _contexto.Database.EnsureCreated();

            //ConfiguracaoJuno configuracaoJuno = new ConfiguracaoJuno()
            //{
            //    ClientId = "wzBpcAOFm0lHJcK9",
            //    ClientSecret = "@}@gw@PbgYFYH+,@(G%lUyXv7acI061$",
            //};
            //Requisicoes.RequisicoesJuno requisicoesJuno = new Requisicoes.RequisicoesJuno(_configuracaoJunoRepositorio);
            //configuracaoJuno = requisicoesJuno.obterTokenAcesso(configuracaoJuno);

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contato(ContatoViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (Utilidades.Funcoes.EnviarEmail(model))
                    return View("SucessoContato", "E-mail enviado com sucesso");
                else
                    return View("SucessoContato", "Falha ao enviar e-mail");
            }
            else
            {
                return View("SucessoContato", "Falha ao enviar e-mail");
            }
        }
    }
}
