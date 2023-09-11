using CoreWCF;
using CoreWCF.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using SakerEnd.Services;
using SakerEnd.Services.ValidationService;
using System.Web.Services.Description;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddServiceModelServices();
//builder.Services.AddSignalR();
builder.Services.AddControllers();

builder.Services.AddScoped<MarsImplamentation>();
builder.Services.AddSingleton<DeviceService>();
//builder.Services.AddSingleton<DevicesNotificationsHub>();
builder.Services.AddTransient<IDeviceResponseHandler, DeviceResponseHandler>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseServiceModel(builder =>
{
    builder.AddService<MarsImplamentation>()
    .AddServiceEndpoint<MarsImplamentation, SNSR_STDSOAPPort>(new BasicHttpBinding(), "/SNSR_STD-SOAP");
});


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();
//app.MapHub<DevicesNotificationsHub>("/StatusReport");

app.Run();
