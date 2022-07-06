using FluentValidation;
using Survey.ENTITIES.Dto;
using Survey.ENTITIES.Entity;
using System;
using System.Text.RegularExpressions;

namespace Survey.COMMON.Validation
{
    public class RegisterValidator : AbstractValidator<RegistrationAsAdmin>
    {
        public RegisterValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("İsim alanı zorunludur.")
                .MaximumLength(50).WithMessage("İsim alanı 50 karakteri geçmemesi gereklidir.");
            RuleFor(c => c.Surname)
                .NotEmpty().WithMessage("Soy İsim alanı zorunludur.")
                .MaximumLength(50).WithMessage("Soy İsim alanı 50 karakteri geçmemesi gereklidir.");
            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("E-posta adresinizi kontrol ediniz.");
            RuleFor(c => c.Password)
                .MinimumLength(6).WithMessage("Şifreniz En az 6 Haneli olmalıdır")
                .MaximumLength(50).WithMessage("Şifre alanı 50 karakteri geçmemesi gereklidir.");
            RuleFor(c => c.PasswordAgain)
                .MinimumLength(6).WithMessage("Şifre tekrarınız en az 6 haneli olmalıdır")
                .MaximumLength(50).WithMessage("Şifre tekrar alanı 50 karakteri geçmemesi gereklidir.");
            
            }
    }

}
