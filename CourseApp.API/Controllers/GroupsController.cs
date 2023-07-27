using CourseApp.Service.Dtos.GroupDtos;
using CourseApp.Core.Entities;
using CourseApp.Core.Repositories;
using CourseApp.Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseApp.Service.Interfaces;
using CourseApp.Service.Exceptions;

namespace CourseApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupService _groupService;

        public GroupsController(IGroupRepository groupRepository, IGroupService groupService)
        {
            _groupRepository = groupRepository;
            _groupService = groupService;
        }

        [HttpGet("all")]
        public ActionResult<GroupGetAllDto> GetAll()
        {

            var groups = _groupService.GetAll();
            return Ok(groups);
        }

        [HttpGet("{id}")]
        public ActionResult<GroupGetDto> Get(int id)
        {

            return Ok(_groupService.GetById(id));

        }

        [HttpPost("")]
        public IActionResult Create(GroupCreateDto groupDto)
        {
            var result = _groupService.Create(groupDto);
            return StatusCode(201, result);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, GroupUpdateDto groupDto)
        {
            _groupService.Update(id, groupDto);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            _groupService.Delete(id);
            return NoContent();

        }
    }
}
