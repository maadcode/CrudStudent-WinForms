using AttendanceControlSystem.DataAccess.Factories;
using AttendanceControlSystem.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace AttendanceControlSystem.DataAccess.Implementations
{
    public class DapperUnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;
        private readonly Dictionary<string, object> _repositories;

        private bool _disposed;

        public DapperUnitOfWork(DbConnectionFactory dbConnectionFactory)
        {
            _connection = dbConnectionFactory.CreateConnection();
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            _repositories = new Dictionary<string, object>();
        }

        public IRepository<T> GetRepository<T>(string tableName) where T : class
        {
            if (!_repositories.ContainsKey(tableName))
            {
                var repository = new RepositoryBase<T>(_connection, _transaction, tableName);
                _repositories.Add(tableName, repository);
            }
            return (IRepository<T>)_repositories[tableName];
        }

        public async Task CommitAsync()
        {
            _transaction.Commit();
            await Task.CompletedTask;
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            if (_disposed) return;

            _transaction.Dispose();
            _connection.Dispose();
            _disposed = true;
        }
    }
}