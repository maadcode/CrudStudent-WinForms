using CrossCutingLayer.Dto.Standard;
using DataLayer.Dao.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataLayer.Dao.Implementations
{
    public class StudentDao : IDao<Student>
    {
        private readonly SqlConnection _connection;

        public StudentDao()
        {
            _connection = Database.GetInstance().GetConnection();
        }

        private void ReadAndAddStudents(SqlCommand command, List<Student> students)
        {
            _connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Student student = new Student();
                    student.Id = reader.GetInt32(0);
                    student.Name = reader.GetString(1);
                    student.LastName = reader.GetString(2);
                    student.DNI = reader.GetString(3);
                    student.Email = reader.GetString(4);
                    student.PhotoUrl = !reader.IsDBNull(5) ? reader.GetString(5) : string.Empty;
                    students.Add(student);
                }
            }
            _connection.Close();
        }

        public List<Student> GetAll()
        {
            var students = new List<Student>();
            try
            {
                var query = "SELECT Id, Name, LastName, DNI, Email, PhotoUrl FROM Student";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    ReadAndAddStudents(command, students);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return students;
        }

        public ResponseDto Add(Student student)
        {
            var response = new ResponseDto();

            try
            {
                var query = "INSERT INTO Student(Name, LastName, DNI, Email) VALUES(@name, @lastName, @dni, @email)";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@name", student.Name);
                    command.Parameters.AddWithValue("@lastName", student.LastName);
                    command.Parameters.AddWithValue("@dni", student.DNI);
                    command.Parameters.AddWithValue("@email", student.Email);
                    _connection.Open();
                    command.ExecuteNonQuery();
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add(string.Empty, ex.Message.Substring(0, Math.Min(ex.Message.Length, 250)));
            }

            return response;
        }

        public ResponseDto Delete(int studentId)
        {
            var response = new ResponseDto();
            try
            {
                var query = "DELETE FROM Student WHERE Id = @id";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@id", studentId);
                    _connection.Open();
                    command.ExecuteNonQuery();
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add(string.Empty, ex.Message.Substring(0, Math.Min(ex.Message.Length, 250)));
            }
            return response;
        }

        public ResponseDto Update(Student student)
        {
            var response = new ResponseDto();
            try
            {
                var query = "UPDATE Student SET Name = @name, LastName = @lastName, DNI = @dni, Email = @email WHERE Id = @id";
                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@id", student.Id);
                    command.Parameters.AddWithValue("@name", student.Name);
                    command.Parameters.AddWithValue("@lastName", student.LastName);
                    command.Parameters.AddWithValue("@dni", student.DNI);
                    command.Parameters.AddWithValue("@email", student.Email);
                    _connection.Open();
                    command.ExecuteNonQuery();
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                response.Errors.Add(string.Empty, ex.Message.Substring(0, Math.Min(ex.Message.Length, 250)));
            }
            return response;
        }
    }
}