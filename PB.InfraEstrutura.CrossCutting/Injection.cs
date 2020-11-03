using Microsoft.Extensions.DependencyInjection;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.InfraEstrutura.Repository;

namespace PB.InfraEstrutura.CrossCutting
{
    public class Injection
    {
        public static void Configure(IServiceCollection services)
        {
            // Service
            //services.AddScoped<IUsuarioService, UsuarioService>();

            // Repository
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            //services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<NotificationContext>();
        }
    }
}
