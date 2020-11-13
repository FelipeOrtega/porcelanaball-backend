using Microsoft.Extensions.DependencyInjection;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.InfraEstrutura.Data.Repository;
using PB.Service;
using PB.Service.Interface;

namespace PB.InfraEstrutura.CrossCutting
{
    public class Injection
    {
        public static void Configure(IServiceCollection services)
        {
            // Service
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            // Repository
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddScoped<NotificationContext>();
        }
    }
}
