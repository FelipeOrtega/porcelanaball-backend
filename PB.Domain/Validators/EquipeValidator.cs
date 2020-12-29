using FluentValidation;

namespace PB.Domain.Validators
{
    public class EquipeValidator : AbstractValidator<Equipe>
    {
        public EquipeValidator()
        {
            RuleSet("insert", () =>
            {
                RuleFor(x => x.modalidade_codigo).NotEmpty().WithMessage("É necessário um código de modalidade válido.");
                RuleFor(x => x.modulo_codigo).NotEmpty().WithMessage("É necessário um código de modulo válido.");
            });

            RuleSet("update", () =>
            {
                RuleFor(x => x.codigo).NotEmpty().WithMessage("É necessário um código válido.");
                RuleFor(x => x.modalidade_codigo).NotEmpty().WithMessage("É necessário um código de modalidade válido.");
                RuleFor(x => x.modulo_codigo).NotEmpty().WithMessage("É necessário um código de modulo válido.");
            });
        }
    }
}
