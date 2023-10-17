using Application.Features.Courses.Dtos;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Types;
using MediatR;

namespace Application.Features.Courses.Queries.GetAll
{
    public class GetAllStudentCourseQuery : IRequest<List<StudentCourseList>>
    {
        public class GetAllStudentCourseQueryHandler : IRequestHandler<GetAllStudentCourseQuery, List<StudentCourseList>>
        {
            private readonly IMapper _mapper;
            private readonly IStudentCourseRepository _courseRepository;
            private readonly StudentBusinessRules _studentBusinessRules;

            public GetAllStudentCourseQueryHandler(IMapper mapper, IStudentCourseRepository courseRepository, StudentBusinessRules studentBusinessRules)
            {
                _mapper = mapper;
                _courseRepository = courseRepository;
                _studentBusinessRules = studentBusinessRules;
            }

            public async Task<List<StudentCourseList>> Handle(GetAllStudentCourseQuery request, CancellationToken cancellationToken)
            {
                List<StudentCourseList> students = await _courseRepository.GetStudentCourseLists();
                if (students == null) throw new BusinessException("Kayıt Sisteminde Kayıt Mevcut değil...");

                return students;


            }
        }
    }
}
