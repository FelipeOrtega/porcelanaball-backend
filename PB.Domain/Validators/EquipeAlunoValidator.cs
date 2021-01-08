using FluentValidation;

namespace PB.Domain.Validators
{
    public class EquipeAlunoValidator : AbstractValidator<EquipeAluno>
    {
        public EquipeAlunoValidator()
        {
            RuleSet("insert", () =>
            {
                RuleFor(x => x.aluno_codigo).NotEmpty().WithMessage("É necessário um aluno válido.");
                RuleFor(x => x.equipe_codigo).NotEmpty().WithMessage("É necessário uma equipe válido");
            });

            RuleSet("update", () =>
            {
                RuleFor(x => x.codigo).NotEmpty().WithMessage("É necessário um código válido.");
                RuleFor(x => x.aluno_codigo).NotEmpty().WithMessage("É necessário uma aluno válido.");
                RuleFor(x => x.equipe_codigo).NotEmpty().WithMessage("É necessário uma equipe válido");
            });
        }
    }
}
