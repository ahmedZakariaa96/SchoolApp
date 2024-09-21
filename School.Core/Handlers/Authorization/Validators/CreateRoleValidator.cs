using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Application.Base.Shared.Resources;
using School.Application.Handlers.Authorization.Commends;
using School.Application.Handlers.Authorization.Services;

namespace School.Application.Handlers.Authorization.Validators
{
    public class CreateRoleValidator : AbstractValidator<CreateRole>
    {
        private readonly IRoleServices roleServices;

        public IStringLocalizer<ResourcesLocalization> Localizer { get; }

        public CreateRoleValidator(IRoleServices roleServices, IStringLocalizer<ResourcesLocalization> _Localizer)
        {
            this.roleServices = roleServices;
            Localizer = _Localizer;
            applyValidationRule();
            applyCustomeValidation();

        }

        public async void applyValidationRule()
        {
            var x = Localizer[ResourcesLocalizationKeys.NotEmpty];

            RuleFor(x => x.roleName)
                .NotEmpty().WithMessage(Localizer[ResourcesLocalizationKeys.NotEmpty])
                .MaximumLength(10).WithMessage(Localizer[ResourcesLocalizationKeys.ChractersLenght]);




        }
        public void applyCustomeValidation()
        {
            RuleFor(x => x.roleName).MustAsync(async (Key, CancellationToken) => !await this.roleServices.IsNameExist(Key))
                .WithMessage(Localizer[ResourcesLocalizationKeys.Exist]);
        }
    }
}
