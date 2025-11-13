using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.data
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _conn;
        public UserRepository(IDbConnection conn) => _conn = conn;

        public async Task<int> CreateAsync(User u)
        {
            var id = await _conn.ExecuteScalarAsync<long>(
                "INSERT INTO users(name) VALUES (:Name); SELECT last_insert_rowid();",
                new { u.Name });
            return (int)id;
        }

        public Task<User?> GetAsync(int id) =>
           
        _conn.QuerySingleOrDefaultAsync<User>(
    "SELECT id AS Id, name AS Name FROM users WHERE id = :id;", new { id
    });


        public async Task<IReadOnlyList<User>> ListAsync()
        {
            var rows = await _conn.QueryAsync<User>("SELECT id, name FROM users ORDER BY id;");
            return rows.AsList();
        }
    }
}
