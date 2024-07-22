using CrossCutingLayer.Dto;
using DataLayer.Mapper.Interfaces;
using DataLayer.Models;

namespace DataLayer.Mapper.Implementations
{
    public class StudentMapper : IMapper<StudentDto, Student>
    {
        public StudentDto ToDTO(Student model)
        {
            if (model == null) return null;

            StudentDto dto = new StudentDto
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName,
                DNI = model.DNI,
                Email = model.Email,
            };
            return dto;
        }

        public Student FromDTO(StudentDto dto)
        {
            if (dto == null) return null;

            Student student = new Student
            {
                Id = dto.Id,
                Name = dto.Name,
                LastName = dto.LastName,
                DNI = dto.DNI,
                Email = dto.Email,
            };
            return student;
        }
    }
}