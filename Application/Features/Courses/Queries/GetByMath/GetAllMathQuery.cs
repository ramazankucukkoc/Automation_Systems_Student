using Application.Features.StudentCourses.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Types;
using MediatR;

namespace Application.Features.Courses.Queries.GetByMath
{
    public class GetAllMathQuery : IRequest<List<StudentCourseMath>>
    {
        public class GetAllMathQueryHandler : IRequestHandler<GetAllMathQuery, List<StudentCourseMath>>
        {
            private readonly IMapper _mapper;
            private readonly IStudentCourseRepository _courseRepository;

            public GetAllMathQueryHandler(IMapper mapper, IStudentCourseRepository courseRepository)
            {
                _mapper = mapper;
                _courseRepository = courseRepository;
            }

            public async Task<List<StudentCourseMath>> Handle(GetAllMathQuery request, CancellationToken cancellationToken)
            {
                List<StudentCourseMath> studentCourseLists = await _courseRepository.GetStudentCourseMathOrderBy();
                if (studentCourseLists is null) throw new BusinessException("Kayıt Bulunamadı");

                return studentCourseLists;



            }
        }
    }
}
