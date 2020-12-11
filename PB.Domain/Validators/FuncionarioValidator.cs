using FluentValidation;

namespace PB.Domain.Validators
{
    public class FuncionarioValidator : AbstractValidator<Funcionario>
    {
        public FuncionarioValidator()
        {
            RuleSet("insert", () =>
            {
                RuleFor(x => x.nome).NotEmpty().WithMessage("É necessário um nome válido");
            });

            RuleSet("update", () =>
            {
                RuleFor(x => x.codigo).NotEmpty().WithMessage("É necessário um código válido.");
                RuleFor(x => x.nome).NotEmpty().WithMessage("É necessário um nome válido.");
            });
        }
    }
}
