using CourseApp.Service.Dtos.Common;
using CourseApp.Service.Dtos.GroupDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Service.Interfaces
{
    public interface IGroupService
    {
        CreateResult Create(GroupCreateDto groupDto);

        List<GroupGetAllDto> GetAll();

        GroupGetDto GetById(int id);

        void Update(int id , GroupUpdateDto groupDto);

        void Delete(int id);

    }
}
