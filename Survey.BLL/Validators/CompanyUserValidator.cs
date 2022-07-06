using FluentValidation;
using Survey.ENTITIES.Entity;
using System;
using System.Text.RegularExpressions;

namespace Survey.COMMON.Validation
{
    public class CompanyUserValidator : AbstractValidator<CompanyUser>
    {
        public CompanyUserValidator()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("İsim alanı zorunludur.")
                .MaximumLength(50).WithMessage("İsim alanı 50 karakteri geçmemesi gereklidir.");
            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Soy İsim alanı zorunludur.")
                .MaximumLength(50).WithMessage("Soy İsim alanı 50 karakteri geçmemesi gereklidir.");
            RuleFor(c => c.CompanyId)
                .GreaterThan(0);
            RuleFor(c => c.CityId)
                .GreaterThan(0);
            RuleFor(c => c.Email)
                .EmailAddress().WithMessage("E-posta adresinizi kontrol ediniz.");
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Ünvan İsim alanı zorunludur.")
                .MaximumLength(50).WithMessage("Ünvan İsim alanı 50 karakteri geçmemesi gereklidir.");
            RuleFor(c => c.DateOfBirth)
                .Must(CheckUserAgeIsGreaterThan18).WithMessage("Kullanıcının yaşı 18'den büyük olmalı");
            RuleFor(c => c.CellPhone)
                .Must(CheckCellPhoneFormat).WithMessage("Telefon numarası bu format olması gerekmektedir 5xxxxxxxxx");
        }
        //Check The phone number format
        private bool CheckCellPhoneFormat(string arg)
        {
            return Regex.IsMatch(arg, @"^(5(\d{9}))$", RegexOptions.IgnoreCase);
        }
        //Check User age is greater than 18
        private bool CheckUserAgeIsGreaterThan18(DateTime arg)
        {
            return DateTime.Now.Year - arg.Year >= 18;
        }
    }

}
