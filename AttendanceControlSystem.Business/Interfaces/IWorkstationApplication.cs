using AttendanceControlSystem.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceControlSystem.Business.Interfaces
{
    public interface IWorkstationApplication
    {
        Task<IEnumerable<WorkstationDTO>> GetAllWorkstationsAsync();

        Task CreateWorkstationAsync(WorkstationDTO workstation);

        Task UpdateWorkstationAsync(WorkstationDTO workstation);

        Task DeleteWorkstationAsync(int workstationId);

        Task<WorkstationDTO> GetWorkstationByIdAsync(int workstationId);
    }
}