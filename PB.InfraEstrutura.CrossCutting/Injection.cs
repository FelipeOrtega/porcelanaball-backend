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
            services.AddScoped<IValidator<PlanoAluno>, PlanoAlunoValidator>();
            services.AddScoped<IValidator<Funcionario>, FuncionarioValidator>();
            services.AddScoped<IValidator<Lancamento>, LancamentoValidator>();
            services.AddScoped<IValidator<AlunoTreino>, AlunoTreinoValidator>();
            services.AddScoped<IValidator<Modalidade>, ModalidadeValidator>();
            services.AddScoped<IValidator<FuncionarioModalidade>, FuncionarioModalidadeValidator>();
            services.AddScoped<IValidator<Plano>, PlanoValidator>();
            services.AddScoped<IValidator<Produto>, ProdutoValidator>();
            services.AddScoped<IValidator<ProdutoCategoria>, ProdutoCategoriaValidator>();
            services.AddScoped<IValidator<User>, UserValidator>();
            services.AddScoped<IValidator<Equipe>, EquipeValidator>();
            services.AddScoped<IValidator<Modulo>, ModuloValidator>();
            services.AddScoped<IValidator<EquipeAluno>, EquipeAlunoValidator>();

            // Service
            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<IPlanoService, PlanoService>();
            services.AddScoped<IModalidadeService, ModalidadeService>();
            services.AddScoped<IProdutoCategoriaService, ProdutoCategoriaService>();
            services.AddScoped<ILancamentoService, LancamentoService>();
            services.AddScoped<IFuncionarioModalidadeService, FuncionarioModalidadeService>();
            services.AddScoped<IAlunoTreinoService, AlunoTreinoService>();
            services.AddScoped<IPlanoAlunoService, PlanoAlunoService>();
            services.AddScoped<ILancamentoService, LancamentoService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEquipeService, EquipeService>();
            services.AddScoped<IModuloService, ModuloService>();
            services.AddScoped<IEquipeAlunoService, EquipeAlunoService>();

            // Repository
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IPlanoRepository, PlanoRepository>();
            services.AddScoped<IModalidadeRepository, ModalidadeRepository>();
            services.AddScoped<IProdutoCategoriaRepository, ProdutoCategoriaRepository>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
            services.AddScoped<IAlunoTreinoRepository, AlunoTreinoRepository>();
            services.AddScoped<IFuncionarioModalidadeRepository, FuncionarioModalidadeRepository>();
            services.AddScoped<IModuloRepository, ModuloRepository>();
            services.AddScoped<IPlanoAlunoRepository, PlanoAlunoRepository>();
            services.AddScoped<IFormaPagamentoRepository, FormaPagamentoRepository>();
            services.AddScoped<ILancamentoProdutoRepository, LancamentoProdutoRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEquipeRepository, EquipeRepository>();
            services.AddScoped<IEquipeAlunoRepository, EquipeAlunoRepository>();
            services.AddScoped<ILancamentoTipoRepository, LancamentoTipoRepository>();
            services.AddScoped<ILancamentoFormaPagamentoRepository, LancamentoFormaPagamentoRepository>();
            services.AddScoped<ILancamentoAlunoRepository, LancamentoAlunoRepository>();

            services.AddScoped<NotificationContext>();
        }
    }
}
