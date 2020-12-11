using FluentValidation;

namespace PB.Domain.Validators
{
    public class AlunoTreinoValidator : AbstractValidator<AlunoTreino>
    {
        public AlunoTreinoValidator()
        {
            RuleSet("insert", () =>
            {
                RuleFor(x => x.aluno_codigo).NotEmpty().WithMessage("É necessário um aluno para o cadastro do treino.");
            });

            RuleSet("update", () =>
            {
                RuleFor(x => x.codigo).NotEmpty().WithMessage("É necessário um código válido.");
                RuleFor(x => x.aluno_codigo).NotEmpty().WithMessage("É necessário um aluno para o cadastro do treino.");
            });
        }
    }
}
