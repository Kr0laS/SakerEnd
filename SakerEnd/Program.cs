using CoreWCF;
using CoreWCF.Configuration;
using SakerEnd;
using System.Web.Services.Description;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddServiceModelServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MarsImplamentation>();

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
