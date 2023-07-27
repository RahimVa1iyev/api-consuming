using FluentValidation;

namespace CourseApp.Service.Dtos.GroupDtos
{
    public class GroupUpdateDto
    {
        public string Name { get; set; }
    }

    public class GroupUpdateDtoValidator : AbstractValidator<GroupUpdateDto>
    {
        public GroupUpdateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Fullname is not empty").MaximumLength(20).WithMessage("Fullname length must not be great than 20");

        }
    }
}
