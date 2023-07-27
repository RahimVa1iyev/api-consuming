using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Service.Dtos.GroupDtos
{
    public class AdminLoginDto
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class AdminLoginDtoValidator : AbstractValidator<AdminLoginDto>
    {
        public AdminLoginDtoValidator()
        {
            RuleFor(x=>x.Username).NotEmpty().MaximumLength(25).MinimumLength(6);
            RuleFor(x=>x.Password).NotEmpty().MaximumLength(25).MinimumLength(8);
        }
    }
}
