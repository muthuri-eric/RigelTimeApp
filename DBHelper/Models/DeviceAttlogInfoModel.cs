using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper.Models;
public class DeviceAttlogInfoModel
{
    public int Id { get; set; }
    public string SerialNumber { get; set; }
    public string Stamp { get; set; }
    public int NumberOfLines { get; set; }
}
