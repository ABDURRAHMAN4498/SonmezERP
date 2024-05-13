using FluentValidation;
using System.Data;

namespace SonmezERP.ViewModels
{
    public class RegisterVMValidator : AbstractValidator<RegisterVM>
    {
        public RegisterVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez!");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanaı boş geçilemez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrar alanı boş geçlilemez!");

            RuleFor(x => x.Name).MaximumLength(30).WithMessage("En fazla 30 karalter");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("En fazla 30 karalter");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("En fazla 30 karalter");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("En fazla 30 karalter");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Parolarınız eşleşmıyor");

        }
    }
}
