using FluentValidation;

namespace PB.Domain.Validators
{
    public class ModuloValidator : AbstractValidator<Modulo>
    {
        public ModuloValidator()
        {
            RuleSet("insert", () =>
            {
                RuleFor(x => x.descricao).NotEmpty().WithMessage("É necessário uma descrição.");
            });

            RuleSet("update", () =>
            {
                RuleFor(x => x.codigo).NotEmpty().WithMessage("É necessário um código válido.");
                RuleFor(x => x.descricao).NotEmpty().WithMessage("É necessário uma descrição.");
            });
        }
    }
}
