using AttendanceControlSystem.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceControlSystem.Business.Interfaces
{
    public interface IAttendanceApplication
    {
        Task RegisterAttendanceAsync(AttendanceDTO attendance);
    }
}