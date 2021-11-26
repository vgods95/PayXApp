using Microsoft.EntityFrameworkCore;
using PayxApp.Interfaces;
using PayxApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PayxApp.Repositorios
{
    public class ContaRepositorio : RepositorioGenerico<Conta>, IContaRepositorio
    {
        private readonly Context _contexto;
        public ContaRepositorio(Context contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<Conta> RecuperarDadosUsuario(int codigoBanco, string agencia, string numeroConta, string cpfCnpj, string codigoUsuario)
        {
            try
            {
                return await _contexto.Contas
                    .Where(x => x.UsuarioId == codigoUsuario && x.AgenciaDestino.Equals(agencia) && x.NumeroContaDestino.Equals(numeroConta)
                    && x.CpfCnpjDestino.Equals(cpfCnpj) && x.BancoId == codigoBanco).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
