using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseApp.Core.Entities;
using CourseApp.Service.Dtos.GroupDtos;
using CourseApp.Service.Dtos.StudentDtos;
using Microsoft.AspNetCore.Http;

namespace CourseApp.Service.Profiles
{
    public class MappingProfile : Profile
    {  

        public MappingProfile(IHttpContextAccessor _httpContextAccessor)
        {

            var baseUrl = new UriBuilder(_httpContextAccessor.HttpContext.Request.Scheme, _httpContextAccessor.HttpContext.Request.Host.Host, _httpContextAccessor.HttpContext.Request.Host.Port ?? -1);

            CreateMap<GroupCreateDto, Group>();
            CreateMap<Group, GroupGetAllDto>();
            CreateMap<Group, GroupGetDto>();

            CreateMap<Group, GroupInStudentGetDto>();

            CreateMap<Group, GroupInStudentGetAllDto>();



            CreateMap<StudentCreateDto, Student>();
            CreateMap<Student, StudentGetAllDto>()
               .ForMember(d => d.ImageUri, s => s.MapFrom(m => string.IsNullOrWhiteSpace(m.ImageName) ? null : (baseUrl + "uploads/students/" + m.ImageName)));
            CreateMap<Student, StudentGetDto>()
                .ForMember(d => d.ImageUri, s => s.MapFrom(m => baseUrl + "uploads/students/" + m.ImageName));

            CreateMap<Student, StudentGetPaginatedListDto>();


        }
    }
}
