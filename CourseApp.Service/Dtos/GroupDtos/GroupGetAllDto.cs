using FluentValidation;

namespace CourseApp.Service.Dtos.GroupDtos
{
    public class GroupGetAllDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }

    public class GroupGetAllDtoValidator : AbstractValidator<GroupGetAllDto>
    {
        public GroupGetAllDtoValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MaximumLength(20);
        }
    } 
   
}
