using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace PayxApp.Extensions
{
    public static class ConfiguracaoIdentityExtension
    {
        public static void ConfigurarUsuario(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(opcoes =>
            {
                opcoes.User.RequireUniqueEmail = true;
            });
        }

        public static void ConfigurarSenhaUsuario(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(opcoes =>
            {
                opcoes.Password.RequiredLength = 8;
                opcoes.Password.RequireDigit = true;
                opcoes.Password.RequireLowercase = true;
                opcoes.Password.RequireUppercase = true;
                opcoes.Password.RequireNonAlphanumeric = true;
                opcoes.SignIn.RequireConfirmedEmail = true;
            });
        }
    }
}
