using Application.Features.Teachers.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Hashing;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teachers.Command.CreateCommand
{
    public class CreateTeacherCommand : IRequest<CreateTeacherDto>
    {
        public string TCNo { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, CreateTeacherDto>
        {
            private readonly IMapper _mapper;
            private readonly ITeacherRepository _teacherRepository;

            public CreateTeacherCommandHandler(IMapper mapper, ITeacherRepository teacherRepository)
            {
                _mapper = mapper;
                _teacherRepository = teacherRepository;
            }

            public async Task<CreateTeacherDto> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                Teacher teacher = new()
                {
                    Email = request.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Active = true,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    BirthDay = request.BirthDay,
                    PhoneNo = request.PhoneNo,
                    TCNo = request.TCNo,
                    
                };

                await _teacherRepository.AddAsync(teacher);
                CreateTeacherDto createTeacherDto = _mapper.Map<CreateTeacherDto>(teacher);
                return createTeacherDto;


            }
        }
    }
}
