using Microsoft.Extensions.DependencyInjection;

namespace PB.InfraEstrutura.CrossCutting
{
    public class Injection
    {
        public static void Configure(IServiceCollection services)
        {
            // EXEMPLOS:

            // Service
            //services.AddScoped<IUsuarioService, UsuarioService>();

            // Repository
            //services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            //services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
    }
}
