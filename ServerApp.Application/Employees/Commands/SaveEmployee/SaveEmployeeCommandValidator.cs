using FluentValidation;
using System;

namespace ServerApp.Application.Employees.Commands.SaveEmployee
{
    public class SaveEmployeeCommandValidator : AbstractValidator<SaveEmployeeRequest>
    {
        private const int IdadeMinima = 18;

        public SaveEmployeeCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("(*) Campo nome completo obrigatório");

            RuleFor(x => x.Salary)
                .GreaterThanOrEqualTo(0)
                .WithMessage("(*) Campo salário inválido");

            RuleFor(x => x.Ssn)
                .NotEmpty()
                .WithMessage("(*) Campo cpf obrigatório");

            RuleFor(x => x.Ssn)
                .Matches(@"\d{9,11}")
                .WithMessage("(*) Campo cpf inválido");

            RuleFor(x => x.Dob)
                .Must(dob => DateTime.Now.Year - dob.Year >= IdadeMinima)
                .WithMessage($"(*) O funcionário deve possuir a idade mínima de {IdadeMinima} anos");
        }
    }
}
