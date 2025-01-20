using AttendanceControlSystem.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceControlSystem.Business.Interfaces
{
    public interface IScheduleApplication
    {
        Task<IEnumerable<ScheduleDTO>> GetAllSchedulesAsync();

        Task CreateScheduleAsync(ScheduleDTO schedule);

        Task UpdateScheduleAsync(ScheduleDTO schedule);

        Task DeleteScheduleAsync(int scheduleId);

        Task<ScheduleDTO> GetScheduleByIdAsync(int scheduleId);
    }
}