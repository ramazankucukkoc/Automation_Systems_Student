using Application.Features.Teachers.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teachers.Command.UpdateCommand
{
    public class UpdateTeacherCommand : IRequest<UpdateTeacherDto>
    {
        public string TCNo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }

        public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, UpdateTeacherDto>
        {
            private readonly IMapper _mapper;
            private readonly ITeacherRepository _teacherRepository;

            public UpdateTeacherCommandHandler(IMapper mapper, ITeacherRepository teacherRepository)
            {
                _mapper = mapper;
                _teacherRepository = teacherRepository;
            }

            public async Task<UpdateTeacherDto> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
            {
                // Teacher? teacher = await _teacherRepository.GetAsync(x=>x.TCNo== request.TCNo);

                Teacher? getById = await _teacherRepository.GetAsync(s => s.TCNo == request.TCNo);

                _mapper.Map(request, getById);
                await _teacherRepository.UpdateAsync(getById);
                UpdateTeacherDto updateStudentDto = _mapper.Map<UpdateTeacherDto>(getById);
                return updateStudentDto;
            }
        }
    }
}