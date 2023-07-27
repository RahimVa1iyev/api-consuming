using AutoMapper;
using CourseApp.Core.Entities;
using CourseApp.Core.Repositories;
using CourseApp.Service.Dtos.Common;
using CourseApp.Service.Dtos.GroupDtos;
using CourseApp.Service.Exceptions;
using CourseApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Service.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository groupRepository,IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public CreateResult Create(GroupCreateDto groupDto)
        {
            if (_groupRepository.IsExist(x => x.Name == groupDto.Name))
            {
                throw new RestException(System.Net.HttpStatusCode.BadRequest,"Name","Name has already taken");
               
            }

            Group group = _mapper.Map<Group>(groupDto);

            _groupRepository.Add(group);
            _groupRepository.IsCommit();

            return new CreateResult { Id = group.Id};
        }

        public void Delete(int id)
        {
            var group = _groupRepository.Get(x => x.Id == id);

            if (group == null) 
            throw new RestException(System.Net.HttpStatusCode.NotFound, "Group not found");

            _groupRepository.Remove(group);
            _groupRepository.IsCommit();
        }

        public List<GroupGetAllDto> GetAll()
        {
            var groups = _groupRepository.GetQueryable(x=> true).ToList();

            return _mapper.Map<List<GroupGetAllDto>>(groups);
        }

        public GroupGetDto GetById(int id)
        {
            var group = _groupRepository.Get(x => x.Id == id , "Students");

            if (group == null)
            {
                throw new RestException(System.Net.HttpStatusCode.NotFound, $"Group not found by Id {id}");

            }

            var groupDto = _mapper.Map<GroupGetDto>(group);

            return groupDto;
        }

        public void Update(int id, GroupUpdateDto groupDto)
        {
             var group = _groupRepository.Get(x => x.Id == id);

            if (group == null)
                throw new RestException(System.Net.HttpStatusCode.NotFound, "Group not found");


            if (group.Name != groupDto.Name && _groupRepository.IsExist(x => x.Name == groupDto.Name))
            {
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "Name", "Name has already taken");
                
            }

            group.Name = groupDto.Name;

            _groupRepository.IsCommit(); 
        }
    }
}
