using AttendanceControlSystem.DataAccess.Entities;
using System.Threading.Tasks;

namespace AttendanceControlSystem.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUsernameAsync(string username);
    }
}