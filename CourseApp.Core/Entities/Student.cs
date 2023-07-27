using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Core.Entities
{
    public class Student : BaseEntity
    {
        public int GroupId { get; set; }

        public string Fullname { get; set; }

        public decimal Point { get; set; }

        public string ImageName { get; set; }

        public Group Group { get; set; }

    }
}
