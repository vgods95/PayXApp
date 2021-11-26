using Microsoft.Extensions.DependencyInjection;
using System;

namespace PayxApp.Extensions
{
    public static class ConfiguracaoCookiesExtension
    {
        public static void ConfigurarCookies(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(opcoes =>
            {
                opcoes.Cookie.Name = "PayXIdentityCookie";
                opcoes.Cookie.IsEssential = true;
                opcoes.ExpireTimeSpan = TimeSpan.FromHours(24);
                opcoes.LoginPath = "/Usuario/Login";
            });
        }
    }
}
