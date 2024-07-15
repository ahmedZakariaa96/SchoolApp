using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Application.Base.Shared.Resources;
using School.Application.Handlers.ApplicationUser.Commands;

namespace School.Application.Handlers.ApplicationUser.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUser>
    {
        public IStringLocalizer<ResourcesLocalization> Localizer { get; }
        public CreateUserValidator(IStringLocalizer<ResourcesLocalization> _Localizer)
        {
            Localizer = _Localizer;
            applyValidationRule();
            applyCustomeValidation();

        }
        public async void applyValidationRule()
        {



            RuleFor(x => x.FullName)
                 .NotEmpty().WithMessage(Localizer[ResourcesLocalizationKeys.NotEmpty])
                 .NotNull().WithMessage(Localizer[ResourcesLocalizationKeys.Required])
                 .MaximumLength(100).WithMessage(Localizer[ResourcesLocalizationKeys.MaxLengthis100]);

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(Localizer[ResourcesLocalizationKeys.NotEmpty])
                .NotNull().WithMessage(Localizer[ResourcesLocalizationKeys.Required])
                .MaximumLength(100).WithMessage(Localizer[ResourcesLocalizationKeys.MaxLengthis100]);

            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage(Localizer[ResourcesLocalizationKeys.NotEmpty])
                 .NotNull().WithMessage(Localizer[ResourcesLocalizationKeys.Required]);

            RuleFor(x => x.Password)
                 .NotEmpty().WithMessage(Localizer[ResourcesLocalizationKeys.NotEmpty])
                 .NotNull().WithMessage(Localizer[ResourcesLocalizationKeys.Required]);
            RuleFor(x => x.ConfirmPassword)
                 .Equal(x => x.Password).WithMessage(Localizer[ResourcesLocalizationKeys.PasswordNotEqualConfirmPass]);


        }
        public void applyCustomeValidation()
        {

        }
    }
}
