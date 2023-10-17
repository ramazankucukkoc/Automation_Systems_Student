using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Types;
using Domain.Entities;

namespace Application.Features.Students.Rules
{
    public class StudentBusinessRules
    {
        private readonly IStudentRepository _studentRepository;

        public StudentBusinessRules(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> StudentIsExists(string tcNo)
        {
            Student? student = await _studentRepository.GetAsync(s => s.TCNo.ToLower().Trim() == tcNo.ToLower().Trim());

            if (student is null) throw new BusinessException("Bu TC Kimlik Numarasına ait kullanıcı yoktur.Numaranızı tekrar girin... ");

            return student;
        }
        public async Task StudentIsExistsCreate(string tcNo)
        {
            Student? student = await _studentRepository.GetAsync(s => s.TCNo.ToLower().Trim() == tcNo.ToLower().Trim());
            if (student is not null) throw new BusinessException($"Bu {student.TCNo} TC Kimlik Numarasına ait kullanıcı vardır.Numaranızı tekrar girin... ");

        }
        public async Task StudentIsExistsEmail(string email)
        {
            Student? student = await _studentRepository.GetAsync(s => s.Email.ToLower().Trim() == email.ToLower().Trim());
            if (student.Email.ToLower().Trim() == email.ToLower().Trim())
                throw new BusinessException($"{student.Email} Bu email ait kullanıcı vardır.Başka email giriniz... ");

        }
        public async Task StudentIsExistsEmail(string email, int id)
        {
            Student? student = await _studentRepository.GetAsync(s => s.Email.ToLower().Trim() == email.ToLower().Trim());
            if (student == null)
                return;
            if (student.Id != id && student.Email.ToLower().Trim() == email.ToLower().Trim())
                throw new BusinessException($"{student.Email} Bu email ait kullanıcı vardır.Başka email giriniz... ");


        }
        public Task GetAllOrNull(List<Student> students)
        {
            if (students.Count == 0) throw new BusinessException("Ögrenci Kaydı Yoktur. !!!!");

            return Task.FromResult(students);

        }

    }
}
