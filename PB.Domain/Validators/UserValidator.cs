using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace PB.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleSet("insert", () =>
            {
                RuleFor(x => x.username).NotEmpty().WithMessage("É necessário um usuario.");
                RuleFor(x => x.password).NotEmpty().WithMessage("É necessário uma senha.");
                RuleFor(x => x.role).NotEmpty().WithMessage("É necessário definir o nivel da conta.");
            });

            RuleSet("update", () =>
            {
                RuleFor(x => x.codigo).NotEmpty().WithMessage("É necessário um código válido.");
                RuleFor(x => x.username).NotEmpty().WithMessage("É necessário um usuario.");
            });
        }
    }
}
