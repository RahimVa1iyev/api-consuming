using CourseApp.Core.Entities;
using CourseApp.Core.Repositories;
using CourseApp.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Data.Repositories
{
    public class StudentRepository : Repository<Student> , IStudentRepository
    {
        public StudentRepository(CourseDbContext context) : base(context)
        {

        }
    }
}
