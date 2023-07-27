using FluentValidation;

namespace CourseApp.Service.Dtos.GroupDtos
{
    public class GroupGetDto
    {
        public string Name { get; set; }

        public int StudentsCount { get; set; }
    }


    public class GroupGetDtoValidator : AbstractValidator<GroupGetDto>
    {
        public GroupGetDtoValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MaximumLength(20);
        }
    }
}
