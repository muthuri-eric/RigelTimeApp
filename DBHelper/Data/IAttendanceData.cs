using DBHelper.Models;
using System.Threading.Tasks;

namespace DBHelper.Data;
public interface IAttendanceData
{
    Task SaveAttendanceDataAsync(AttendanceModel attendance);
    Task<IEnumerable<AttendanceModel?>> GetAllAttendanceAsync();
}