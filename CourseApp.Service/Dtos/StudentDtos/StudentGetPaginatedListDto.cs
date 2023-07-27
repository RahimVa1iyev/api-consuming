using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Service.Dtos.StudentDtos
{
    public class StudentGetPaginatedListDto
    {
        public int Id { get; set; }

        public string Fullname { get; set; }

        public decimal Point { get; set; }

        public string GroupName { get; set; }

    }
}
