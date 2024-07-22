using CrossCutingLayer.Dto;
using CrossCutingLayer.Dto.Standard;
using CrossCutingLayer.Utils;
using System.Collections.Generic;

namespace BusinessLayer.Interfaces
{
    public interface IServiceStudent
    {
        ResponseDto RegisterStudent(StudentDto student);
        List<StudentDto> GetAllStudents();
        List<StudentDto> GetAllStudents(string content);
        PaginatedList<StudentDto> GetAllPaginatedStudents(string filter, int pageNumber = 1, int pageSize = 10);
        ResponseDto DeleteStudent(int studentId);
        ResponseDto UpdateStudent(StudentDto student);
    }
}