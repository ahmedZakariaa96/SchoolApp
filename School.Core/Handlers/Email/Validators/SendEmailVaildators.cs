using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Application.Base.Shared.Resources;
using School.Application.Handlers.Email.Commends;
using School.Application.Handlers.StudentFeature.Services;

namespace School.Application.Handlers.Email.Validators
{
    public class SendEmailVaildators : AbstractValidator<SendEmail>
    {
        public IStringLocalizer<ResourcesLocalization> Localizer { get; }

        public SendEmailVaildators(IStudentService studentService, IStringLocalizer<ResourcesLocalization> Localizer)
        {
            this.Localizer = Localizer;
            applyValidationRule();

        }

        public void applyValidationRule()
        {

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(Localizer[ResourcesLocalizationKeys.NotEmpty])
                .NotNull().WithMessage(Localizer[ResourcesLocalizationKeys.Required]);

            RuleFor(x => x.Message)
               .NotEmpty().WithMessage(Localizer[ResourcesLocalizationKeys.NotEmpty])
                .NotNull().WithMessage(Localizer[ResourcesLocalizationKeys.Required]);


            RuleFor(x => x.Subject)
               .NotEmpty().WithMessage(Localizer[ResourcesLocalizationKeys.NotEmpty])
               .NotNull().WithMessage(Localizer[ResourcesLocalizationKeys.Required]);



        }
    }
}
