using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Application.Base.Shared.Resources;
using School.Application.Handlers.ApplicationUser.Commands;

namespace School.Application.Handlers.ApplicationUser.Validators
{
    public class ChangePasswordValidator : AbstractValidator<ChangePassword>
    {
        public IStringLocalizer<ResourcesLocalization> Localizer { get; }
        public ChangePasswordValidator(IStringLocalizer<ResourcesLocalization> _Localizer)
        {
            Localizer = _Localizer;
            applyValidationRule();
            applyCustomeRule();

        }
        public async void applyValidationRule()
        {


            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(Localizer[ResourcesLocalizationKeys.NotEmpty])
                .NotNull().WithMessage(Localizer[ResourcesLocalizationKeys.Required])
                .MaximumLength(100).WithMessage(Localizer[ResourcesLocalizationKeys.MaxLengthis100]);

            RuleFor(x => x.OldPaasword)
                 .NotEmpty().WithMessage(Localizer[ResourcesLocalizationKeys.NotEmpty])
                 .NotNull().WithMessage(Localizer[ResourcesLocalizationKeys.Required])
                 .MaximumLength(100).WithMessage(Localizer[ResourcesLocalizationKeys.MaxLengthis100]);

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage(Localizer[ResourcesLocalizationKeys.NotEmpty])
                .NotNull().WithMessage(Localizer[ResourcesLocalizationKeys.Required])
                .MaximumLength(100).WithMessage(Localizer[ResourcesLocalizationKeys.MaxLengthis100]);



        }
        public async void applyCustomeRule()
        {
            RuleFor(x => x.OldPaasword).NotEqual(x => x.NewPassword).WithMessage(Localizer[ResourcesLocalizationKeys.PasswordNotEqual]);
        }

    }
}
