using AutoMapper;
using CourseApp.Core.Entities;
using CourseApp.Core.Repositories;
using CourseApp.Service.Dtos.Common;
using CourseApp.Service.Dtos.StudentDtos;
using CourseApp.Service.Exceptions;
using CourseApp.Service.Helpers;
using CourseApp.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Service.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IGroupRepository groupRepository , IStudentRepository studentRepository , IMapper mapper )
        {
            _groupRepository = groupRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public CreateResult Create(StudentCreateDto studentDto)
        {
            if (!_groupRepository.IsExist(x => x.Id == studentDto.GroupId))
            {
               throw new RestException(System.Net.HttpStatusCode.NotFound ,$"Group not found by İd {studentDto.GroupId}");
                
            }

            Student student = _mapper.Map<Student>(studentDto);
            var rootPath = Directory.GetCurrentDirectory()+"/wwwroot";

            student.ImageName = FileManager.Save(studentDto.ImageFile, rootPath, "uploads/students");

            _studentRepository.Add(student);
            _studentRepository.IsCommit();

            return new CreateResult { Id = student.Id };
        }

        public void Delete(int id)
        {
            var student = _studentRepository.Get(x => x.Id == id);

            if (student == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Group not found by Id {id}");


            _studentRepository.Remove(student);
            _studentRepository.IsCommit();
        }

        public List<StudentGetAllDto> GetAll()
        {
            var students = _studentRepository.GetQueryable(x => true,"Group").ToList();
            
            return _mapper.Map<List<StudentGetAllDto>>(students);
        }

        public StudentGetDto GetById(int id)
        {
            var student = _studentRepository.Get(x => x.Id == id, "Group");

            if (student == null) 
               throw new RestException(System.Net.HttpStatusCode.NotFound , $"Group not found by Id {id}") ;

            var studentDto = _mapper.Map<StudentGetDto>(student);

            return studentDto;
        }

        
        public PaginatedListDto<StudentGetPaginatedListDto> GetPaginated(int page)
        {
            if (page<1)
            {
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "Page" , "Page not found");
            }

            var query = _studentRepository.GetQueryable(x => true, "Group");
            var entity = query.Skip((page - 1) * 2).Take(2).ToList();
            var items = _mapper.Map<List<StudentGetPaginatedListDto>>(entity);
            return new PaginatedListDto<StudentGetPaginatedListDto>(items, page, 2, query.Count());
        }

        public void Update(int id,  StudentUpdateDto studentDto)
        {
            var student = _studentRepository.Get(x=>x.Id == id);

            if (student == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Group not found by Id {id}");

            if (!_groupRepository.IsExist(x=>x.Id == studentDto.GroupId))
                throw new RestException(System.Net.HttpStatusCode.NotFound, "Name", "Name has already taken");

            student.Fullname = studentDto.Fullname;
            student.Point = studentDto.Point;
            student.GroupId = studentDto.GroupId;

            string removableImage = null;

            if (studentDto.ImageFile != null)
            {
                removableImage = student.ImageName;
                var root = Directory.GetCurrentDirectory() + "/wwwroot";
                student.ImageName = FileManager.Save(studentDto.ImageFile, root, "uploads/students");

            }

            _studentRepository.IsCommit();

            if (removableImage !=null)
            {
                var root = Directory.GetCurrentDirectory() + "/wwwroot";

                FileManager.Delete(root, "uploads/students", removableImage);
            }



        }
    }
}
