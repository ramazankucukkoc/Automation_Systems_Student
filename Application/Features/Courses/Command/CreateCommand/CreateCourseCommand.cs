using Application.Features.Courses.Dtos;
using Application.Features.Courses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Courses.Command.CreateCommand
{
    public class CreateCourseCommand : IRequest<CreateCourseDayHourDto>
    {
        public int HourId { get; set; }
        public int DayId { get; set; }
        public int CourseId { get; set; }

        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CreateCourseDayHourDto>
        {
            private readonly ICourseDayHourRepository _courseDayHourRepository;
            private readonly IMapper _mapper;
            private readonly CourseBusinessRules _courseBusinessRules;

            public CreateCourseCommandHandler(ICourseDayHourRepository courseDayHourRepository, IMapper mapper, CourseBusinessRules courseBusinessRules)
            {
                _courseDayHourRepository = courseDayHourRepository;
                _mapper = mapper;
                _courseBusinessRules = courseBusinessRules;
            }

            public async Task<CreateCourseDayHourDto> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
            {

                CourseDayHour courseDayHour = _mapper.Map<CourseDayHour>(request);
                await _courseBusinessRules.IsExists(courseDayHour);
                CourseDayHour? addedCourseDayHour = await _courseDayHourRepository.AddAsync(courseDayHour);
                CreateCourseDayHourDto createCourseDayHourDto = _mapper.Map<CreateCourseDayHourDto>(addedCourseDayHour);
                return createCourseDayHourDto;


            }
        }
    }
}
