using AttendanceControlSystem.Business.Interfaces;
using AttendanceControlSystem.Common.Dtos;
using AttendanceControlSystem.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceControlSystem.Business.Implementations
{
    public class WorkstationApplication : IWorkstationApplication
    {
        private readonly IWorkstationRepository _workstationRepository;

        public WorkstationApplication(IWorkstationRepository workstationRepository)
        {
            _workstationRepository = workstationRepository;
        }

        public Task CreateWorkstationAsync(WorkstationDTO workstation)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteWorkstationAsync(int workstationId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<WorkstationDTO>> GetAllWorkstationsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<WorkstationDTO> GetWorkstationByIdAsync(int workstationId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateWorkstationAsync(WorkstationDTO workstation)
        {
            throw new System.NotImplementedException();
        }
    }
}