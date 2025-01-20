using AttendanceControlSystem.Business.Interfaces;
using AttendanceControlSystem.Common.Dtos;
using AttendanceControlSystem.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceControlSystem.Business.Implementations
{
    public class ScheduleApplication : IScheduleApplication
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleApplication(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public Task CreateScheduleAsync(ScheduleDTO schedule)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteScheduleAsync(int scheduleId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ScheduleDTO>> GetAllSchedulesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ScheduleDTO> GetScheduleByIdAsync(int scheduleId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateScheduleAsync(ScheduleDTO schedule)
        {
            throw new System.NotImplementedException();
        }
    }
}