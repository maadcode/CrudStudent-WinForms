using AttendanceControlSystem.DataAccess.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceControlSystem.DataAccess.Implementations
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly IDbConnection _connection;
        protected readonly IDbTransaction _transaction;
        private readonly string _tableName;

        public RepositoryBase(IDbConnection connection, IDbTransaction transaction, string tableName)
        {
            _connection = connection;
            _transaction = transaction;
            _tableName = tableName;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = $"SELECT * FROM {_tableName}";
            return await _connection.QueryAsync<T>(query, transaction: _transaction);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var query = $"SELECT * FROM {_tableName} WHERE Id = @Id";
            return await _connection.QuerySingleOrDefaultAsync<T>(query, new { Id = id }, _transaction);
        }

        public async Task AddAsync(T entity)
        {
            var query = $"INSERT INTO {_tableName} ({GetColumns()}) VALUES ({GetParameters()})";
            await _connection.ExecuteAsync(query, entity, _transaction);
        }

        public async Task UpdateAsync(T entity)
        {
            var query = $"UPDATE {_tableName} SET {GetUpdateColumns()} WHERE Id = @Id";
            await _connection.ExecuteAsync(query, entity, _transaction);
        }

        public async Task DeleteAsync(int id)
        {
            var query = $"DELETE FROM {_tableName} WHERE Id = @Id";
            await _connection.ExecuteAsync(query, new { Id = id }, _transaction);
        }

        private string GetColumns()
        {
            var properties = typeof(T).GetProperties();
            return string.Join(", ", properties.Select(p => p.Name));
        }

        private string GetParameters()
        {
            var properties = typeof(T).GetProperties();
            return string.Join(", ", properties.Select(p => $"@{p.Name}"));
        }

        private string GetUpdateColumns()
        {
            var properties = typeof(T).GetProperties().Where(p => p.Name != "Id");
            return string.Join(", ", properties.Select(p => $"{p.Name} = @{p.Name}"));
        }
    }
}