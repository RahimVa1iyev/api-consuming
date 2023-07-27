using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Service.Dtos.StudentDtos
{
    public class StudentUpdateDto
    {
        public string Fullname { get; set; }

        public decimal Point { get; set; }

        public int GroupId { get; set; }

        public IFormFile ImageFile { get; set; }
    }

    public class StudentUpdateDtoValidator : AbstractValidator<StudentUpdateDto>
    {
        public StudentUpdateDtoValidator()
        {
            RuleFor(x => x.Fullname).NotEmpty().WithMessage("Fullname is not empty").MaximumLength(30).WithMessage("Fullname length must not be great than 30");
            RuleFor(x => x.Point).GreaterThanOrEqualTo(0);
            RuleFor(x => x.GroupId).GreaterThanOrEqualTo(0);

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
