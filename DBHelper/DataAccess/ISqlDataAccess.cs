namespace DBHelper.DataAccess;

public interface ISqlDataAccess
{
    Task SaveDataAsync<T>(string storedProcedure, T parameters, string connectionId = "Default");
    Task<IEnumerable<T>> FetchData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
    Task<IEnumerable<T>> FetchData<T, U>(string command, string connectionId = "Default");
}