using Application.Features.Courses.Command.CreateCommand;
using Application.Features.Courses.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Courses.Profiles
{
    public class MapppingProfiles : Profile
    {
        public MapppingProfiles()
        {
            CreateMap<CourseList, Course>().ReverseMap();

            CreateMap<CourseDayHour, CreateCourseCommand>().ReverseMap();
            CreateMap<CourseDayHour, CreateCourseDayHourDto>().ReverseMap();

            CreateMap<CourseDayHour, GetByIdCourseNameDto>()
              .ForMember(x => x.CourseName, dest => dest.MapFrom(x => x.Course.Name)).ReverseMap();
        }
    }
}
