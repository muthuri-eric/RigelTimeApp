using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DBHelper.DataAccess;
public class SqlDataAccess : ISqlDataAccess
{
	private readonly IConfiguration _config;

	public SqlDataAccess(IConfiguration config)
	{
		_config = config;
	}

	public async Task SaveDataAsync<T>(string storedProcedure, T parameters, string connectionId = "Default")
	{
		using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
		await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
	}
	public async Task<IEnumerable<T>> FetchData<T,U>(string storedProcedure, U parameters, string connectionId = "Default")
	{
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
		return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
    public async Task<IEnumerable<T>> FetchData<T, U>(string command, string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        return await connection.QueryAsync<T>(command, commandType: CommandType.Text);
    }
}
