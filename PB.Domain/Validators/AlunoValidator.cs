using FluentValidation;

namespace PB.Domain.Validators
{
    public class AlunoValidator : AbstractValidator<Aluno>
    {
        public AlunoValidator()
        {
            RuleSet("insert", () =>
            {
                RuleFor(x => x.nome).NotEmpty().WithMessage("É necessário um nome válido");
            });

            RuleSet("update", () =>
            {
                RuleFor(x => x.nome).NotEmpty().WithMessage("É necessário um nome válido.");
                RuleFor(x => x.codigo).NotEmpty().WithMessage("É necessário um código válido.");
            });
        }
    }
}
