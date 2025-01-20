using System;
using System.Threading.Tasks;

namespace AttendanceControlSystem.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>(string tableName) where T : class;
        Task CommitAsync();
        void Rollback();
    }
}
