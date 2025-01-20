using AttendanceControlSystem.Business.Interfaces;
using AttendanceControlSystem.Common.Dtos;
using AttendanceControlSystem.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttendanceControlSystem.Business.Implementations
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserRepository _userRepository;

        public UserApplication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserDTO> AuthenticateAsync(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task CreateUserAsync(UserDTO user)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteUserAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserDTO> GetUserByIdAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateUserAsync(UserDTO user)
        {
            throw new System.NotImplementedException();
        }
    }
}