using AttendanceControlSystem.Business.Interfaces;
using AttendanceControlSystem.Common.Dtos;
using AttendanceControlSystem.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceControlSystem.Business.Implementations
{
    public class DepartmentApplication : IDepartmentApplication
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentApplication(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public Task CreateDepartmentAsync(DepartmentDTO department)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteDepartmentAsync(int departmentId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<DepartmentDTO> GetDepartmentByIdAsync(int departmentId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateDepartmentAsync(DepartmentDTO department)
        {
            throw new System.NotImplementedException();
        }
    }
}