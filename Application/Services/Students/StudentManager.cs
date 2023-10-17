using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Types;
using Domain.Entities;

namespace Application.Services.Students
{
    public class StudentManager : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> GetById(int id)
        {
            Student? student = await _studentRepository.GetAsync(s => s.Id == id);
            if (student is null) throw new BusinessException("Kullanıcı Mevcut değildir.");

            return student;
        }

        public async Task<Student> GetByTCNo(string tcNo)
        {
            Student? student = await _studentRepository.GetAsync(s => s.TCNo.ToLower().Trim() == tcNo.Trim());
            if (student is null) throw new BusinessException("Kullanıcı Mevcut değildir.");

            return student;
        }
    }
}
