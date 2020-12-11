using FluentValidation;

namespace PB.Domain.Validators
{
    public class ModalidadeValidator : AbstractValidator<Modalidade>
    {
        public ModalidadeValidator()
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
