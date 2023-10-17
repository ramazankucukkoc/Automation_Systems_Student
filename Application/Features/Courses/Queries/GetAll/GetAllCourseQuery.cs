using Application.Features.Courses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Types;
using Domain.Entities;
using MediatR;

namespace Application.Features.Courses.Queries.GetAll
{
    public class GetAllCourseQuery : IRequest<List<CourseList>>
    {
        public class GetAllCourseHandler : IRequestHandler<GetAllCourseQuery, List<CourseList>>
        {
            private readonly IMapper _mapper;
            private readonly ICourseRepository _courseRepository;

            public GetAllCourseHandler(IMapper mapper, ICourseRepository courseRepository)
            {
                _mapper = mapper;
                _courseRepository = courseRepository;
            }

            public async Task<List<CourseList>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
            {
                List<Course> courses = await _courseRepository.GetListAsync();
                if (courses == null) throw new BusinessException("Kayıt yok....");

                List<CourseList> courseLists = _mapper.Map<List<CourseList>>(courses);
                return courseLists;


            }
        }

    }
}
