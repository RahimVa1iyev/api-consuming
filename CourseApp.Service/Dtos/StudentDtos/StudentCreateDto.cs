using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace CourseApp.Service.Dtos.StudentDtos
{
    public class StudentCreateDto
    {
        public string Fullname { get; set; }

        public decimal Point { get; set; }

        public int GroupId { get; set; }

        public IFormFile ImageFile { get; set; }
    }

    public class StudentCreateDtoValidator : AbstractValidator<StudentCreateDto>
    {
        public StudentCreateDtoValidator()
        {
            RuleFor(x => x.Fullname).NotEmpty().MaximumLength(30);
            RuleFor(x => x.Point).GreaterThanOrEqualTo(0);
            RuleFor(x=>x.GroupId).GreaterThanOrEqualTo(0);

            RuleFor(x => x.ImageFile).NotNull();

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.ImageFile != null)
                {
                    if (x.ImageFile.Length > 2 * 1024 * 1024)
                    {
                        context.AddFailure("ImageFile", "ImageFile file must be less or equal that 2MB");
                     
                    }
                    if (x.ImageFile.ContentType != "image/jpeg" && x.ImageFile.ContentType != "image/png")
                    {
                        context.AddFailure("ImageFile", "ImageFile must be png , jpg or jpeg file");

                    }

                }
            });
        }
    }
}
