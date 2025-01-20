using AttendanceControlSystem.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceControlSystem.Business.Interfaces
{
    public interface IDepartmentApplication
    {
        Task<IEnumerable<DepartmentDTO>> GetAllDepartmentsAsync();

        Task CreateDepartmentAsync(DepartmentDTO department);

        Task UpdateDepartmentAsync(DepartmentDTO department);

        Task DeleteDepartmentAsync(int departmentId);

        Task<DepartmentDTO> GetDepartmentByIdAsync(int departmentId);
    }
}