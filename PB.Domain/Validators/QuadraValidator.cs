using FluentValidation;

namespace PB.Domain.Validators
{
    public class QuadraValidator : AbstractValidator<Quadra>
    {
        public QuadraValidator()
        {
            RuleSet("insert", () =>
            {
                RuleFor(x => x.codigo).NotEmpty().WithMessage("É necessário um código de quadra válido.");
            });

            RuleSet("update", () =>
            {
                RuleFor(x => x.codigo).NotEmpty().WithMessage("É necessário um código válido.");
            });
        }
    }
}
