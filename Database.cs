using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;

namespace WeaponPaints
{
	public class Database(string dbConnectionString)
	{
		public async Task<SqliteConnection> GetConnectionAsync()
		{
			try
			{
				var connection = new SqliteConnection(dbConnectionString);
				await connection.OpenAsync();
				return connection;
			}
			catch (Exception ex)
			{
				WeaponPaints.Instance.Logger.LogError($"Unable to connect to database: {ex.Message}");
				throw;
			}
		}
	}
}