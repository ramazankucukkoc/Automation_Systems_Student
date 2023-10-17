using Application.Features.StudentCourses.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.StudentCourses.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<StudentCourseAddDto, StudentCourse>().ReverseMap();
            CreateMap<StudentCourseUpdateDto, StudentCourse>().ReverseMap();
            CreateMap<StudentCourseDeleteDto, StudentCourse>().ReverseMap();

        }

    }
}
