using BusinessLayer.Interfaces;
using CrossCutingLayer.Dto;
using CrossCutingLayer.Dto.Standard;
using CrossCutingLayer.Utils;
using DataLayer.Dao.Implementations;
using DataLayer.Dao.Interfaces;
using DataLayer.Mapper.Implementations;
using DataLayer.Mapper.Interfaces;
using DataLayer.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Implementations
{
    public class ServiceStudent : IServiceStudent
    {
        public IDao<Student> _repository;
        public IMapper<StudentDto, Student> _mapper;

        public ServiceStudent()
        {
            _repository = new StudentDao();
            _mapper = new StudentMapper();
        }

        private void ValidateFieldsRequired(ResponseDto response, StudentDto student)
        {
            if (string.IsNullOrEmpty(student.Name))
                response.Errors.Add(nameof(student.Name), "Este campo es obligatorio");

            if (string.IsNullOrEmpty(student.LastName))
                response.Errors.Add(nameof(student.LastName), "Este campo es obligatorio");

            if (string.IsNullOrEmpty(student.DNI))
                response.Errors.Add(nameof(student.DNI), "Este campo es obligatorio");

            if (string.IsNullOrEmpty(student.Email))
                response.Errors.Add(nameof(student.Email), "Este campo es obligatorio");
        }

        public ResponseDto RegisterStudent(StudentDto student)
        {
            var response = new ResponseDto();

            ValidateFieldsRequired(response, student);
            if (!response.IsValid) return response;

            var entity = _mapper.FromDTO(student);
            response = _repository.Add(entity);

            return response;
        }

        public List<StudentDto> GetAllStudents()
        {
            return GetAllStudents(string.Empty);
        }

        public List<StudentDto> GetAllStudents(string content)
        {
            var response = new List<StudentDto>();
            var studentsEntity = _repository.GetAll();

            if (!string.IsNullOrEmpty(content))
                studentsEntity = studentsEntity.Where(x => x.DNI.Contains(content) || x.Name.Contains(content) || x.LastName.Contains(content)).ToList();

            foreach (var student in studentsEntity)
            {
                var studentDto = _mapper.ToDTO(student);
                response.Add(studentDto);
            }
            return response;
        }

        public PaginatedList<StudentDto> GetAllPaginatedStudents(string filter, int pageNumber = 1, int pageSize = 10)
        {
            var students = new List<StudentDto>();
            var studentsEntity = _repository.GetAll();

            if (!string.IsNullOrEmpty(filter))
                studentsEntity = studentsEntity.Where(x => x.DNI.Contains(filter) || x.Name.Contains(filter) || x.LastName.Contains(filter)).ToList();

            foreach (var student in studentsEntity)
            {
                var studentDto = _mapper.ToDTO(student);
                students.Add(studentDto);
            }
            var paginatedList = new PaginatedList<StudentDto>(students, pageNumber, pageSize);
            return paginatedList;
        }

        public ResponseDto DeleteStudent(int studentId)
        {
            return _repository.Delete(studentId);
        }

        public ResponseDto UpdateStudent(StudentDto student)
        {
            var response = new ResponseDto();

            ValidateFieldsRequired(response, student);
            if (!response.IsValid) return response;

            var entity = _mapper.FromDTO(student);
            response = _repository.Update(entity);

            return response;
        }
    }
}