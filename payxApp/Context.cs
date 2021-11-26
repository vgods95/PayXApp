using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PayxApp.Mapeamentos;
using PayxApp.Models;

namespace PayxApp
{
    public class Context : IdentityDbContext<Usuario, Funcao, string>
    {
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Funcao> Funcoes { get; set; }
        public DbSet<Simulacao> Simulacoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ConfiguracaoJuno> ConfiguracoesJuno { get; set; }
        public DbSet<Conta> Contas { get; set; }
        public DbSet<Boleto> Boletos { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<CartaoCredito> Cartoes { get; set; }
        public DbSet<TransacaoDetalhe> TransacoesDetalhe { get; set; }

        public Context(DbContextOptions<Context> opcoes) : base(opcoes)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CidadeMap());
            builder.ApplyConfiguration(new FuncaoMap());
            builder.ApplyConfiguration(new SimulacaoMap());
            builder.ApplyConfiguration(new UsuarioMap());
            builder.ApplyConfiguration(new ConfiguracaoJunoMap());
            builder.ApplyConfiguration(new ContaMap());
            builder.ApplyConfiguration(new BoletoMap());
            builder.ApplyConfiguration(new TransacaoMap());
            builder.ApplyConfiguration(new BancoMap());
            builder.ApplyConfiguration(new CartaoCreditoMap());
            builder.ApplyConfiguration(new TransacaoDetalheMap());
        }
    }
}
