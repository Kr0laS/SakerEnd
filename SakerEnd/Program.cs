using CoreWCF;
using CoreWCF.Configuration;
using Microsoft.AspNetCore.Identity;
using SakerEnd.Services.DeviceService;
using SakerEnd.Services.ValidationService;
using System.Web.Services.Description;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddServiceModelServices();
builder.Services.AddControllers();

builder.Services.AddSingleton<MarsImplamentation>();
builder.Services.AddScoped<IValidationService, ValidationService>();
builder.Services.AddSingleton<IDeviceService,DeviceService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseServiceModel(builder =>
{
    builder.AddService<MarsImplamentation>((serviceOptions) => { })
    // Add a BasicHttpBinding at a specific endpoint
    .AddServiceEndpoint<MarsImplamentation, SNSR_STDSOAPPort>(new BasicHttpBinding(), "/SNSR_STD-SOAP");
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
