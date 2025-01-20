using AttendanceControlSystem.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceControlSystem.Business.Interfaces
{
    public interface IDeviceApplication
    {
        Task<IEnumerable<DeviceDTO>> GetAllDevicesAsync();

        Task CreateDeviceAsync(DeviceDTO device);

        Task UpdateDeviceAsync(DeviceDTO device);

        Task DeleteDeviceAsync(int deviceId);

        Task<DeviceDTO> GetDeviceByIdAsync(int device);
    }
}