using FluentValidation;

namespace PB.Domain.Validators
{
    public class AlunoPossuiPlanoValidator : AbstractValidator<AlunoPossuiPlano>
    {
        public AlunoPossuiPlanoValidator()
        {
            RuleSet("insert", () =>
            {
                RuleFor(x => x.aluno_codigo).NotEmpty().WithMessage("É necessário um aluno válido.");
                RuleFor(x => x.plano_codigo).NotEmpty().WithMessage("É necessário um plano válido");
            });

            RuleSet("update", () =>
            {
                RuleFor(x => x.codigo).NotEmpty().WithMessage("É necessário um código válido.");
                RuleFor(x => x.aluno_codigo).NotEmpty().WithMessage("É necessário um aluno válido.");
                RuleFor(x => x.plano_codigo).NotEmpty().WithMessage("É necessário um plano válido");
            });
        }
    }
}
