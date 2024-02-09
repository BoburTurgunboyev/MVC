using FirstMvcProject.Application.ExtentionFunctions;
using FirstMvcProject.Domain.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMvcProject.Application.FluentValidation
{
    public class LoginValidator:AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email)
           .NotEmpty().WithMessage("Email is required.")
           .EmailAddress().WithMessage("Wrong email address.");

            RuleFor(x => x.Password)
           .NotEmpty().WithMessage("Password is required.")
           .MinimumLength(4).WithMessage("Password must be at least 4 characters.")
           .Must(ForPassword.CaptalLetter).WithMessage("Password must contain at least one capital letter.");
        }
    }
}
