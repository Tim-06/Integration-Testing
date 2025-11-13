using Dapper;
using demo.data;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace IntegrationTesting
{
    public class UserRepositoryTests
    {
        // 建立一個共享的 in-memory SQLite，測試期間活著
        private static SqliteConnection CreateOpenMemoryDb()
        {
            var conn = new SqliteConnection("Data Source=:memory:;Cache=Shared");
            conn.Open();
            return conn;
        }

        private static async Task InitSchemaAsync(IDbConnection conn)
        {
            await conn.ExecuteAsync("""
            CREATE TABLE users(
              id   INTEGER PRIMARY KEY AUTOINCREMENT,
              name TEXT NOT NULL
            );
        """);
        }

        [Fact]
        public async Task Create_and_Get_should_roundtrip()
        {
            using var conn = CreateOpenMemoryDb();
            await InitSchemaAsync(conn);

            var repo = new UserRepository(conn);

            var newId = await repo.CreateAsync(new User { Id=0,Name = "Alice" });
            var loaded = await repo.GetAsync(newId);

            Assert.NotNull(loaded);
            Assert.Equal("Alice", loaded!.Name);
        }
    }
}
