using AttendanceControlSystem.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceControlSystem.Business.Interfaces
{
    public interface IUserApplication
    {
        Task<UserDTO> AuthenticateAsync(string username, string password);

        Task CreateUserAsync(UserDTO user);

        Task UpdateUserAsync(UserDTO user);

        Task DeleteUserAsync(int userId);

        Task<UserDTO> GetUserByIdAsync(int userId);

        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
    }
}