using FluentValidation;

namespace CourseApp.Service.Dtos.GroupDtos
{
    public class GroupCreateDto
    {
        public string Name { get; set; }
    }

    public class GroupCreateDtoValidator : AbstractValidator<GroupCreateDto>
    {
        public GroupCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
        }
    }
}
