using AttendanceControlSystem.DataAccess.Entities;
using AttendanceControlSystem.DataAccess.Interfaces;
using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace AttendanceControlSystem.DataAccess.Implementations
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbConnection connection, IDbTransaction transaction)
            : base(connection, transaction, "Users")
        {
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            var query = "SELECT * FROM Users WHERE Username = @Username";
            return await _connection.QuerySingleOrDefaultAsync<User>(query, new { Username = username }, _transaction);
        }
    }
}