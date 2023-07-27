using CourseApp.Service.Dtos.StudentDtos;
using CourseApp.Core.Entities;
using CourseApp.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CourseApp.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace CourseApp.API.Controllers
{
    [Authorize(Roles ="Admin")]

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
       
        private readonly IStudentService _studentService;

        public StudentsController( IStudentService studentService)
        {
          
            _studentService = studentService;
        }

        [HttpGet("all")]
        public ActionResult<List<StudentGetAllDto>> GetAll()
        {

            return Ok(_studentService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<StudentGetDto> Get(int id)
        {
           
            return Ok(_studentService.GetById(id));

        }

        [HttpPost]
        public IActionResult Create([FromForm]StudentCreateDto studentDto)
        {
            var result = _studentService.Create(studentDto);

            return StatusCode(201, result);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,[FromForm] StudentUpdateDto studentDto)
        {
            _studentService.Update(id,studentDto);

            return NoContent();
        }

        [HttpGet("")]
        public IActionResult GetPaginated(int page)
        {
            return Ok(_studentService.GetPaginated(page));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentService.Delete(id);

            return NoContent();
        }






    }
}
