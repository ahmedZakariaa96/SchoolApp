using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Application.Base.Shared.Resources;
using School.Application.Handlers.StudentFeature.Commends;
using School.Application.Handlers.StudentFeature.Services;

namespace School.Application.Handlers.StudentFeature.Validators
{
    public class CreateStudentValidator : AbstractValidator<CreateStudent>
    {
        private readonly IStudentService studentService;

        public IStringLocalizer<ResourcesLocalization> Localizer { get; }

        public CreateStudentValidator(IStudentService studentService, IStringLocalizer<ResourcesLocalization> _localizer)
        {
            this.studentService = studentService;
            Localizer = _localizer;
            applyValidationRule();
            applyCustomeValidation();

        }
        public async void applyValidationRule()
        {
            var x = Localizer[ResourcesLocalizationKeys.NotEmpty];

            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage(Localizer[ResourcesLocalizationKeys.NotEmpty])
                .MaximumLength(10).WithMessage(Localizer[ResourcesLocalizationKeys.ChractersLenght]);




        }
        public void applyCustomeValidation()
        {
            RuleFor(x => x.NameEn).MustAsync(async (Key, CancellationToken) => !await this.studentService.IsNameExist(Key))
                .WithMessage(Localizer[ResourcesLocalizationKeys.Exist]);
        }

    }
}
