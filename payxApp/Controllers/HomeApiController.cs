using Microsoft.AspNetCore.Mvc;
using PayxApp.Interfaces;
using PayxApp.Models;
using PayxApp.ViewModels;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace PayxApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeApiController : ControllerBase
    {
        private readonly IBancoRepositorio _bancoRepositorio;

        public HomeApiController(IBancoRepositorio bancoRepositorio)
        {
            _bancoRepositorio = bancoRepositorio;
        }

        [Route("bancos")]
        [AcceptVerbs("GET")]
        public async Task<string> ListarBancos()
        {
            IEnumerable<Banco> listaBancos = await _bancoRepositorio.ListarTodos();
            return JsonSerializer.Serialize(listaBancos);
        }

        [Route("parcelas")]
        [AcceptVerbs("GET")]
        public IEnumerable<DesmembramentoParcelasViewModel> ListarParcelas([FromHeader]double valorSolicitado)
        {
            return Utilidades.Funcoes.GerarDesmembramentoParcelas(valorSolicitado);
        }
    }
}
