using DBHelper.Data;
using DBHelper.Models;
using System.Net;
using System.Text;

namespace DeviceAccess;
public class Push
{
    public string SerialNumber { get; set; } //Does not need to be accessed externally
    public Push()
    {

    }
    public Push(string serialNumber)
    {
        SerialNumber = serialNumber;
    }

    private DeviceModel _device = new();
    private AttendanceModel _attendance = new();
    private DeviceAttlogInfoModel _deviceAttlogInfo = new();
    private TemplateModel _templateModel = new();
    private EmployeeModel _employeeModel = new();
    public IEnumerable<DeviceAttlogInfoModel> DeviceAttlogInfo { get; set; }

    public IEnumerable<TemplateModel> TemplateInfo { get; set; }

    public Dictionary<string, string> DeviceInfo { get; set; } = new();

    public Dictionary<string, string> OperLogInfo { get; set; } = new();
    public Dictionary<string, string> EmployeeInfo { get; set; } = new();

    public List<TemplateModel> Templates { get; set; }

    public List<EmployeeModel> Employees { get; set; } = new();

    public async Task VerifyRequest(HttpListenerContext context, string route, string data, IDeviceData deviceData, 
        IAttendanceData attendanceData, IDeviceUserData deviceUserData, ITemplateData templateData, 
        IDeviceAttlogData deviceAttlogData, IEmployeeData employeeData, List<string> dataToSend)
    {
        SerialNumber = context.Request.QueryString["SN"];
        
        bool isFoundDevice;
        if (SerialNumber == null)
        {
            return;
        }
        else
        {
            isFoundDevice = true;//Add logic to determine whether the serial number is among the devices allowed
            if (isFoundDevice)
            {
                if (route.Contains("options=all"))
                {
                    string qry = context.Request.Url.Query;
                    string query = qry.Substring(1, qry.Length -1);
                    var queryItems = query.Split("&");
                    foreach (var item in queryItems)
                    {
                        var dictionaryItems = item.Split('=');
                        DeviceInfo.Add(dictionaryItems[0], dictionaryItems[1]);
                    }
                    _device.SerialNumber = DeviceInfo["SN"];
                    _device.Name = "ZKteco IClock S900";
                    
                    await deviceData.DeviceDataAsync(_device);

                    DeviceInfo.Clear();

                    AnswerRequest(context, ConfigureParameters(deviceAttlogData).Result);
                }
                if (route.Contains($"/iclock/getrequest?SN={SerialNumber}") && dataToSend.Count > 0)
                {
                    //Database logic to check if they is any new infromation to send to device
                    //This includes adding/deleting/updating employees/device users
                    //You can also query for user information from the device
                    //StringBuilder sb = new StringBuilder();
                    //sb.AppendLine("C:1:DATA QUERY USERINFO PIN=2");
                    AnswerRequest(context, dataToSend[0]);
                    dataToSend.Clear();

                }
                else if (route.Contains($"/iclock/getrequest?SN={SerialNumber}"))
                {
                    //Check whether there is a command waiting
                    //Wire up the request command and clear the command list
                    //else
                    //if (!querySent)
                    //{
                    //    AnswerRequest(context, "OK");
                    //}
                    //else
                    //{
                        AnswerRequest(context, "OK");
                    //}
                    
                }
                if (route.Contains("INFO=Ver"))
                {
                    //Read Terminal Info from Url and Store it/Do some logic with it
                    AnswerRequest(context, "OK");
                }
                else if (route.Contains("table=OPERLOG"))
                {
                    //Read theoperation log in the body data and store.Do some logic with it
                    //Respond with number of rows read
                    var operLogItems = data.Split('\n');

                    foreach (var operLogItem in operLogItems)
                    {
                        //Console.WriteLine(operLogItem);
                        if (operLogItem.StartsWith("F"))
                        {
                            var dictionaryItems = operLogItem.Split('\t');
                            foreach (var item in dictionaryItems)
                            {
                                var dict = item.Split('=');
                                OperLogInfo.Add(dict[0], dict[1]);
                            }
                            if (OperLogInfo["FP PIN"] != "")
                            {
                                _templateModel.EmployeeId = Convert.ToInt32(OperLogInfo["FP PIN"]);
                                _templateModel.FID = Convert.ToInt32(OperLogInfo["FID"]);
                                _templateModel.Size = Convert.ToInt32(OperLogInfo["Size"]);
                                _templateModel.Valid = Convert.ToInt32(OperLogInfo["Valid"]);
                                _templateModel.Template = OperLogInfo["TMP"];
                                try
                                {
                                    await templateData.SaveTemplateDataAsync(_templateModel);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                //var template = await templateData.GetTemplatesAsync(_templateModel.EmployeeId);
                                //Templates.Add(template);
                                //AnswerRequest(context, "OK");
                                OperLogInfo.Clear();
                            }

                            else
                            {
                                AnswerRequest(context, "OK");
                            }
                            //AnswerRequest(context, "OK");
                            //OperLogInfo.Add(dictionaryItems[0], dictionaryItems[1]);
                        }
                        if (operLogItem.StartsWith("U"))
                        {
                            var dictionaryItems = operLogItem.Split('\t');
                            foreach (var item in dictionaryItems)
                            {
                                var dict = item.Split('=');
                                OperLogInfo.Add(dict[0], dict[1]);
                            }
                            if (OperLogInfo["USER PIN"] != "")
                            {
                                _employeeModel.EmployeeId = Convert.ToInt32(OperLogInfo["USER PIN"]);
                                _employeeModel.EmployeeName = OperLogInfo["Name"];
                                _employeeModel.IsDeviceSynced = true;
                                _employeeModel.LastChanged = DateTime.Now;
                                try
                                {
                                    await employeeData.SaveEmployeeDataAsync(_employeeModel);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                //var template = await templateData.GetTemplatesAsync(_templateModel.EmployeeId);
                                //Templates.Add(template);
                                //AnswerRequest(context, "OK");
                                OperLogInfo.Clear();
                            }

                            else
                            {
                                AnswerRequest(context, "OK");
                            }

                        }

                    }
                    AnswerRequest(context, "OK");
                    //if (OperLogInfo.Count > 0)
                    //{
                    //    _templateModel.EmployeeId = Convert.ToInt32(OperLogInfo["FP PIN"]);
                    //    _templateModel.FID = Convert.ToInt32(OperLogInfo["FID"]);
                    //    _templateModel.Size = Convert.ToInt32(OperLogInfo["Size"]);
                    //    _templateModel.Valid = Convert.ToInt32(OperLogInfo["Valid"]);
                    //    _templateModel.Template = OperLogInfo["TMP"];
                    //}
                    //
                }

                else if (route.Contains("table=ATTLOG"))
                {
                    string qry = context.Request.Url.Query;
                    string query = qry.Substring(1, qry.Length - 1);
                    var queryItems = query.Split("&");
                    foreach (var item in queryItems)
                    {
                        var dictionaryItems = item.Split('=');
                        DeviceInfo.Add(dictionaryItems[0], dictionaryItems[1]);
                    }
                    var attlogItems = data.Split('\n');

                    

                    _deviceAttlogInfo.SerialNumber = DeviceInfo["SN"];

                    _deviceAttlogInfo.Stamp = DeviceInfo["Stamp"];

                    _deviceAttlogInfo.NumberOfLines = attlogItems.Length - 1;

                    DeviceAttlogInfo = await deviceAttlogData.GetDeviceAttlogInfoAsync();
                    
                    if((DeviceAttlogInfo.Count() > 0))
                    {
                        //if (DeviceAttlogInfo.Last().Stamp == _deviceAttlogInfo.Stamp)
                        //{
                            //if(DeviceAttlogInfo.Last().NumberOfLines != _deviceAttlogInfo.NumberOfLines)
                            //{
                            //    List<string> deviceAttlog = new();
                            //    for (int i = DeviceAttlogInfo.Last().NumberOfLines; i < attlogItems.Length; i++)
                            //    {
                            //        deviceAttlog.Add(attlogItems[i]);
                            //    }
                            //    await deviceAttlogData.SaveDeviceAttlogInfoAsync(_deviceAttlogInfo);
                            //    AnswerRequest(context, (attlogItems.Length - 1).ToString());
                            //    foreach (string attlog in deviceAttlog)
                            //    {
                            //        var attlogline = attlog.Split('\t');
                            //        _attendance.EmployeeId = Convert.ToInt32(attlogline[0]);
                            //        _attendance.ClockDateTime = Convert.ToDateTime(attlogline[1]);
                            //        _attendance.Status = Convert.ToInt32(attlogline[2]);
                            //        _attendance.Verify = Convert.ToInt32(attlogline[3]);
                            //        _attendance.WorkCode = Convert.ToInt32(attlogline[4]);

                            //        await attendanceData.SaveAttendanceDataAsync(_attendance);
                            //    }

                            //}

                            //AnswerRequest(context, "OK");
                            //return;
                        //}
                        //else
                        //{
                            await deviceAttlogData.SaveDeviceAttlogInfoAsync(_deviceAttlogInfo);
                            AnswerRequest(context, "OK");
                            var attlogItemsList = attlogItems.ToList();
                            //attlogItemsList.RemoveRange(0, DeviceAttlogInfo.LastOrDefault().NumberOfLines);
                            foreach (string attlog in attlogItemsList)
                            {
                                var attlogline = attlog.Split('\t');
                                _attendance.EmployeeId = Convert.ToInt32(attlogline[0]);
                                _attendance.ClockDateTime = Convert.ToDateTime(attlogline[1]);
                                _attendance.Status = Convert.ToInt32(attlogline[2]);
                                _attendance.Verify = Convert.ToInt32(attlogline[3]);
                                _attendance.WorkCode = Convert.ToInt32(attlogline[4]);

                                await attendanceData.SaveAttendanceDataAsync(_attendance);
                            }
                        //}
                    }
                    else
                    {
                        await deviceAttlogData.SaveDeviceAttlogInfoAsync(_deviceAttlogInfo);
                        AnswerRequest(context, "OK");
                        foreach (string attlog in attlogItems)
                        {
                            var attlogline = attlog.Split('\t');
                            _attendance.EmployeeId = Convert.ToInt32(attlogline[0]);
                            _attendance.ClockDateTime = Convert.ToDateTime(attlogline[1]);
                            _attendance.Status = Convert.ToInt32(attlogline[2]);
                            _attendance.Verify = Convert.ToInt32(attlogline[3]);
                            _attendance.WorkCode = Convert.ToInt32(attlogline[4]);

                            await attendanceData.SaveAttendanceDataAsync(_attendance);
                        }
                        
                    }

                    //Read the attendance log and store data from it
                    //Respond with the number of rows read 
                }
                else if (route.Contains("table=USERINFO"))
                {
                    //Read the User Info and Do some logic with it
                    //User has been requested from server with Command

                    AnswerRequest(context, "OK");
                }
                else if (route.Contains($"/iclock/devicecmd?SN={SerialNumber}"))
                {
                    //Read return response command
                    AnswerRequest(context, "OK");
                }
            }
            else
            {
                if (route.Contains("options=all"))
                    AnswerRequest(context, ConfigureParameters(deviceAttlogData).Result);
                else if (route.Contains("/iclock/getrequest"))
                {
                    AnswerRequest(context, "OK");
                }
            }
        }

        //if (Device != null && Device.IsActive)
        //{

        //}


        //if (route.Contains("options=all"))
        //{
        //    AnswerRequest(context, ConfigureParameters());
        //}
        //if (route.Contains("/iclock/getrequest"))
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("C:1:DATA QUERY USERINFO PIN=23");
        //    AnswerRequest(context, sb.ToString());
        //    //AnswerRequest(context, "OK");
        //}
        //if (route.Contains("USERINFO"))
        //{
        //    var urldata = data.Split("\t");
        //    Dictionary<string, string> values = new Dictionary<string, string>();
        //    //Dictionary<string, string> parameters = new Dictionary<string, string>();
        //    //System.IO.Stream body = context.Request.InputStream;
        //    //System.Text.Encoding encoding = context.Request.ContentEncoding;
        //    //System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
        //    //string s = reader.ReadToEnd
        //    foreach(string s in urldata)
        //    {
        //        var secondSplit = s.Split('=');
        //        values.Add(secondSplit[0], secondSplit[1]);
        //    }
        //    foreach(KeyValuePair<string, string> userkey in values)
        //    {
        //        Console.WriteLine("Key = {0}, Value = {1}", userkey.Key, userkey.Value);
        //    }
            
        //}
    }

    private async Task<string> ConfigureParameters(IDeviceAttlogData deviceAttlogData)
    {
        DeviceAttlogInfo = await deviceAttlogData.GetDeviceAttlogInfoAsync();
        var pushParameters = new StringBuilder();

        pushParameters.AppendLine("GET OPTION FROM: "+ SerialNumber);
        if(DeviceAttlogInfo.Count() != 0)
        {
            //pushParameters.AppendLine($"ATTLOGStamp={DeviceAttlogInfo.Last().Stamp}");//{DeviceAttlogInfo.Last().Stamp}
            pushParameters.AppendLine("ATTLOGStamp=0");
        }
        else
        {
            pushParameters.AppendLine("ATTLOGStamp=None");
        }
        pushParameters.AppendLine("OPERLOGStamp=0");
        pushParameters.AppendLine("ATPHOTOStamp=None");
        pushParameters.AppendLine("ServerVersion=3.0.1");
        pushParameters.AppendLine("ServerName=ADMS");
        pushParameters.AppendLine("PushVersion=2.4.1");
        pushParameters.AppendLine("ErrorDelay=2");
        pushParameters.AppendLine("RequestDelay=3");
        //pushParameters.AppendLine("Delay=10");
        //pushParameters.AppendLine("TransTimes=00:00;14:05");
        pushParameters.AppendLine("TransInterval=1");
        pushParameters.AppendLine("TransFlag=1111111111");
       // pushParameters.AppendLine("TransTables=User Transaction Facev7 templatev10");
        pushParameters.AppendLine("TimeZone=3");
        pushParameters.AppendLine("RealTime=1");
        pushParameters.AppendLine("TimeoutSec=10");

        return pushParameters.ToString();
    }

    public void AnswerRequest(HttpListenerContext context, string data)
    {
        var bytes = Encoding.ASCII.GetBytes(data);

        context.Response.Headers.Add("Connection", "close");
        context.Response.ContentType = "text/plain;charset=UTF-8";
        context.Response.ContentLength64 = bytes.Length;
        context.Response.OutputStream.Write(bytes, 0, bytes.Length);
        context.Response.OutputStream.Close();
    }
    public async Task ProcessRequest(HttpListenerContext context, IDeviceData deviceData, IAttendanceData attendanceData,
        IDeviceUserData deviceUserData, ITemplateData templateData, IDeviceAttlogData deviceAttlogData, IEmployeeData employeeData,
        List<string> deviceCommands)
    {
        var bytes = new byte[262144]; // 256 kb

        var bytesRead = context.Request.InputStream.Read(bytes, 0, bytes.Length);

        var data = Encoding.ASCII.GetString(bytes, 0, bytesRead);

        var rawUrl = context.Request.RawUrl;

        await VerifyRequest(context, rawUrl, data, deviceData, attendanceData, deviceUserData, templateData, 
            deviceAttlogData, employeeData, deviceCommands);
    }
}
