using FluentValidation;


namespace PB.Domain.Validators
{
    public class PagamentoValidator : AbstractValidator<Pagamento>
    {
        public PagamentoValidator()
        {
            RuleSet("insert", () =>
            {
                RuleFor(x => x.observacao).NotEmpty().WithMessage("É necessário uma observacao.");
            });

            RuleSet("update", () =>
            {
                RuleFor(x => x.codigo).NotEmpty().WithMessage("É necessário um código válido.");
                RuleFor(x => x.observacao).NotEmpty().WithMessage("É necessário uma observacao.");
            });
        }
    }
}
