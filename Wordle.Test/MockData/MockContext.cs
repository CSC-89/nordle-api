using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Wordle.Tests.MockData;

public class SqliteInMemory : WordleGameControllerTests, IDisposable
{
    private readonly DbConnection? _connection;
    public SqliteInMemory()
        : base(
            new DbContextOptionsBuilder<WordContext>()
                .UseSqlite(CreateInMemoryDatabase())
                .Options)
    {
        _connection = RelationalOptionsExtension.Extract(ContextOptions).Connection;
    }
    private static DbConnection CreateInMemoryDatabase()
    {
        var connection = new SqliteConnection("Filename=:memory:");
        connection.Open();
        return connection;
    }
    public void Dispose() => _connection.Dispose();
}