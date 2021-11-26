using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayxApp.Interfaces;
using PayxApp.Models;
using System.Threading.Tasks;
using System;
using PayxApp.Utilidades;
using System.Text.Json;
using PayxApp.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace PayxApp.Controllers
{
    public class SimulacaoController : Controller
    {
        private readonly ISimulacaoRepositorio _simulacaoRepositorio;
        private readonly SignInManager<Usuario> _gerenciadorLogin;

        public SimulacaoController(ISimulacaoRepositorio simulacaoRepositorio, SignInManager<Usuario> gerenciadorLogin)
        {
            _simulacaoRepositorio = simulacaoRepositorio;
            _gerenciadorLogin = gerenciadorLogin;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AlterarSimulacao([FromBody] Simulacao simulacao)
        {
            try
            {
                await _simulacaoRepositorio.Alterar(simulacao);

                if (_gerenciadorLogin.IsSignedIn(User))
                    return Json("USER_LOGADO");
                else
                    return Json("USER_DESLOGADO");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult _Simulacao()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> _Simulacao(SimulacaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                Simulacao simulacao = new Simulacao();
                simulacao.NomeCompleto = model.NomeCompleto;
                simulacao.Email = model.Email;
                simulacao.Celular = model.Celular;
                simulacao.Valor = Convert.ToDouble(model.Valor.Replace(".", ","));
                simulacao.Parcelas = Convert.ToInt32(model.Parcelas);
                simulacao.DataHora = DateTime.Now;
                model.listaParcelas = Funcoes.GerarDesmembramentoParcelas(Convert.ToDouble(model.Valor.Replace(".", ",")));
                simulacao.DesmembramentoParcelasJson = JsonSerializer.Serialize(model.listaParcelas);

                int retorno = await _simulacaoRepositorio.Inserir(simulacao);

                if (retorno > 0)
                {
                    TempData["Simulacao"] = JsonSerializer.Serialize(simulacao);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Home"); //Colocar um bad request aqui
                }
            }
            else
            {
                return RedirectToAction("Index", "Home"); //Colocar um bad request aqui
            }
        }
    }
}
