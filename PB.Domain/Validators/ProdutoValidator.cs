using FluentValidation;

namespace PB.Domain.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleSet("insert", () =>
            {
                RuleFor(x => x.produto_categoria_codigo).NotEmpty().WithMessage("É necessário um código de produto válido.");
            });

            RuleSet("update", () =>
            {
                RuleFor(x => x.codigo).NotEmpty().WithMessage("É necessário um código válido.");
                RuleFor(x => x.produto_categoria_codigo).NotEmpty().WithMessage("É necessário um código de produto válido.");
            });
        }
    }
}
