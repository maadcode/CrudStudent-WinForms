using AttendanceControlSystem.Business.Interfaces;
using AttendanceControlSystem.Common.Dtos;
using AttendanceControlSystem.Common.Enums;
using AttendanceControlSystem.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceControlSystem.Business.Implementations
{
    public class AttendanceApplication : IAttendanceApplication
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceApplication(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public Task RegisterAttendanceAsync(AttendanceDTO attendance)
        {
            throw new NotImplementedException();
        }
    }
}