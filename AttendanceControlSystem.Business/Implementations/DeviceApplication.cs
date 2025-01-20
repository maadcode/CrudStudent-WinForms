using AttendanceControlSystem.Business.Interfaces;
using AttendanceControlSystem.Common.Dtos;
using AttendanceControlSystem.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceControlSystem.Business.Implementations
{
    public class DeviceApplication : IDeviceApplication
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceApplication(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public Task CreateDeviceAsync(DeviceDTO device)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteDeviceAsync(int deviceId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<DeviceDTO>> GetAllDevicesAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<DeviceDTO> GetDeviceByIdAsync(int device)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateDeviceAsync(DeviceDTO device)
        {
            throw new System.NotImplementedException();
        }
    }
}