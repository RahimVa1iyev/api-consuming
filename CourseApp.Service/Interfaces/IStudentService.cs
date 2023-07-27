using CourseApp.Service.Dtos.Common;
using CourseApp.Service.Dtos.StudentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Service.Interfaces
{
    public interface IStudentService
    {
        CreateResult Create(StudentCreateDto studentDto);

        List<StudentGetAllDto> GetAll();

        PaginatedListDto<StudentGetPaginatedListDto> GetPaginated(int page);

        StudentGetDto GetById(int id);

        void Update(int id, StudentUpdateDto studentDto);

        void Delete(int id);


    }
}
