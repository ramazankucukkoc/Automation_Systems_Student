using Application.Features.Courses.Dtos;
using Application.Features.Courses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Types;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Courses.Queries.GetById
{
    public class GetByIdCourseQuery : IRequest<List<GetByIdCourseNameDto>>
    {
        public class GetByIdCourseQueryHandler : IRequestHandler<GetByIdCourseQuery, List<GetByIdCourseNameDto>>
        {
            private readonly ICourseDayHourRepository _courseDayHourRepository;
            private readonly CourseBusinessRules _courseBusinessRules;
            private readonly ICourseRepository _courseRepository;
            private readonly IMapper _mapper;

            public GetByIdCourseQueryHandler(ICourseDayHourRepository courseDayHourRepository, IMapper mapper,
                CourseBusinessRules courseBusinessRules, ICourseRepository courseRepository)
            {
                _courseDayHourRepository = courseDayHourRepository;
                _courseBusinessRules = courseBusinessRules;
                _courseRepository = courseRepository;
                _mapper = mapper;
            }

            public async Task<List<GetByIdCourseNameDto>> Handle(GetByIdCourseQuery request, CancellationToken cancellationToken)
            {
                List<CourseDayHour>? courseDayHour = await _courseDayHourRepository.GetListAsync(include: x => x.Include(x => x.Course));
                if (courseDayHour == null) throw new BusinessException("Kayıt Bulunamadı...");

                List<GetByIdCourseNameDto> getByIdCourseNameDtos = _mapper.Map<List<GetByIdCourseNameDto>>(courseDayHour);

                return getByIdCourseNameDtos;


            }
        }
    }
}
