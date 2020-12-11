using FluentValidation;

namespace PB.Domain.Validators
{
    public class ProdutoCategoriaValidator : AbstractValidator<ProdutoCategoria>
    {
        public ProdutoCategoriaValidator()
        {
            RuleSet("insert", () =>
            {
                RuleFor(x => x.descricao).NotEmpty().WithMessage("É necessário uma descricao válida.");
            });

            RuleSet("update", () =>
            {
                RuleFor(x => x.codigo).NotEmpty().WithMessage("É necessário um código válido.");
                RuleFor(x => x.descricao).NotEmpty().WithMessage("É necessário uma descricao válida.");
            });
        }
    }
}
