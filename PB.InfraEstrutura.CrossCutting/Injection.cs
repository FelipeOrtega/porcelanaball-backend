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
            services.AddScoped<IProdutoLoteService, ProdutoLoteService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IPlanoService, PlanoService>();
            services.AddScoped<IModalidadeService, ModalidadeService>();
            services.AddScoped<IProdutoCategoriaService, ProdutoCategoriaService>();
            services.AddScoped<ILancamentoService, LancamentoService>();

            // Repository
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoLoteRepository,ProdutoLoteRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IPlanoRepository, PlanoRepository>();
            services.AddScoped<IModalidadeRepository, ModalidadeRepository>();
            services.AddScoped<IProdutoCategoriaRepository, ProdutoCategoriaRepository>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
            services.AddScoped<IAlunoTreinoRepository, AlunoTreinoRepository>();
            services.AddScoped<IModalidadeFuncionarioRepository, ModalidadeFuncionarioRepository>();
            services.AddScoped<IModuloRepository, ModuloRepository>();

            services.AddScoped<NotificationContext>();
        }
    }
}
