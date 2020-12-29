using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PB.Domain;
using PB.Domain.Interface.Repository;
using PB.Domain.Notifications;
using PB.Domain.Validators;
using PB.InfraEstrutura.Data.Repository;
using PB.Service;
using PB.Service.Interface;

namespace PB.InfraEstrutura.CrossCutting
{
    public class Injection
    {
        public static void Configure(IServiceCollection services)
        {
            // Validator
            services.AddScoped<IValidator<Aluno>, AlunoValidator>();
            services.AddScoped<IValidator<AlunoPossuiPlano>, AlunoPossuiPlanoValidator>();
            services.AddScoped<IValidator<Funcionario>, FuncionarioValidator>();
            services.AddScoped<IValidator<Lancamento>, LancamentoValidator>();
            services.AddScoped<IValidator<AlunoTreino>, AlunoTreinoValidator>();
            services.AddScoped<IValidator<Modalidade>, ModalidadeValidator>();
            services.AddScoped<IValidator<ModalidadeFuncionario>, ModalidadeFuncionarioValidator>();
            services.AddScoped<IValidator<Plano>, PlanoValidator>();
            services.AddScoped<IValidator<Produto>, ProdutoValidator>();
            services.AddScoped<IValidator<ProdutoCategoria>, ProdutoCategoriaValidator>();
            services.AddScoped<IValidator<User>, UserValidator>();
            services.AddScoped<IValidator<Equipe>, EquipeValidator>();

            // Service
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoLoteService, ProdutoLoteService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IPlanoService, PlanoService>();
            services.AddScoped<IModalidadeService, ModalidadeService>();
            services.AddScoped<IProdutoCategoriaService, ProdutoCategoriaService>();
            services.AddScoped<ILancamentoService, LancamentoService>();
            services.AddScoped<IModalidadeFuncionarioService, ModalidadeFuncionarioService>();
            services.AddScoped<IAlunoTreinoService, AlunoTreinoService>();
            services.AddScoped<IAlunoPossuiPlanoService, AlunoPossuiPlanoService>();
            services.AddScoped<ILancamentoService, LancamentoService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEquipeService, EquipeService>();

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
            services.AddScoped<IAlunoPossuiPlanoRepository, AlunoPossuiPlanoRepository>();
            services.AddScoped<IFormaPagamentoRepository, FormaPagamentoRepository>();
            services.AddScoped<ILancamentoProdutoRepository, LancamentoProdutoRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEquipeRepository, EquipeRepository>();

            services.AddScoped<NotificationContext>();
        }
    }
}
