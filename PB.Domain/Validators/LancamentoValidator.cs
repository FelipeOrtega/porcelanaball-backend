using FluentValidation;

namespace PB.Domain.Validators
{
    public class LancamentoValidator : AbstractValidator<Lancamento>
    {
        public LancamentoValidator()
        {
            RuleSet("insert", () =>
            {
                RuleFor(x => x.funcionario_codigo).NotEmpty().WithMessage("É necessário um código de funcionário.");
                RuleFor(x => x.forma_pagamento_codigo).NotEmpty().WithMessage("É necessário uma forma de pagamento válida.");
            });

            RuleSet("update", () =>
            {
                RuleFor(x => x.codigo).NotEmpty().WithMessage("É necessário um código válido.");
                RuleFor(x => x.funcionario_codigo).NotEmpty().WithMessage("É necessário um código de funcionário.");
                RuleFor(x => x.forma_pagamento_codigo).NotEmpty().WithMessage("É necessário uma forma de pagamento válida.");
            });
        }
    }
}
