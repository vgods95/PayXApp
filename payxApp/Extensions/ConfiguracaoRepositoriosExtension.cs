using Microsoft.Extensions.DependencyInjection;
using PayxApp.Interfaces;
using PayxApp.Repositorios;

namespace PayxApp.Extensions
{
    public static class ConfiguracaoRepositoriosExtension
    {
        public static void ConfigurarRepositorios(this IServiceCollection services)
        {
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddTransient<ICidadeRepositorio, CidadeRepositorio>();
            services.AddTransient<ISimulacaoRepositorio, SimulacaoRepositorio>();
            services.AddTransient<IConfiguracaoJunoRepositorio, ConfiguracaoJunoRepositorio>();
            services.AddTransient<IBancoRepositorio, BancoRepositorio>();
            services.AddTransient<IBoletoRepositorio, BoletoRepositorio>();
            services.AddTransient<IContaRepositorio, ContaRepositorio>();
            services.AddTransient<ITransacaoRepositorio, TransacaoRepositorio>();
            services.AddTransient<ICartaoCreditoRepositorio, CartaoCreditoRepositorio>();
            services.AddTransient<ITransacaoDetalheRepositorio, TransacaoDetalheRepositorio>();
        }
    }
}
