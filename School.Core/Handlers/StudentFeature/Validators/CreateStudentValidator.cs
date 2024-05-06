using FluentValidation;
using School.Application.Handlers.StudentFeature.Commends;
using School.Application.Handlers.StudentFeature.Services;

namespace School.Application.Handlers.StudentFeature.Validators
{
    public class CreateStudentValidator : AbstractValidator<CreateStudent>
    {
        private readonly IStudentService studentService;

        public CreateStudentValidator(IStudentService studentService)
        {
            applyValidationRule();
            applyCustomeValidation();
            this.studentService = studentService;
        }
        public async void applyValidationRule()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{PropertyName} is NotEmpty")
                .NotNull().WithMessage("{PropertyName} is NotNull")
                .MaximumLength(10).WithMessage("{PropertyName} should have 10 chracters");




        }
        public void applyCustomeValidation()
        {
            RuleFor(x => x.Name).MustAsync(async (Key, CancellationToken) => !await this.studentService.IsNameExist(Key))
                .WithMessage("Name is exist ");
        }

    }
}
