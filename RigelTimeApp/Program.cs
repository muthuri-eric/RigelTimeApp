using DBHelper.Data;
using DBHelper.DataAccess;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RigelTimeApp.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDevExpressBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IDeviceData, DeviceData>();
builder.Services.AddSingleton<IAttendanceData, AttendanceData>();
builder.Services.AddSingleton<IDeviceUserData, DeviceUserData>();
builder.Services.AddSingleton<ITemplateData, TemplateData>();
builder.Services.AddSingleton<IDeviceAttlogData, DeviceAttlogData>();
builder.Services.AddSingleton<IEmployeeData, EmployeeData>();
builder.Services.Configure<DevExpress.Blazor.Configuration.GlobalOptions>(options =>
{
    options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
});
builder.WebHost.UseWebRoot("wwwroot");
builder.WebHost.UseStaticWebAssets();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();