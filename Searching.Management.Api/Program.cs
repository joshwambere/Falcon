using Searching.Management.Api.Extensions;
using Searching.Management.Api.Middlewares;
using OpenTelemetry.Resources;
using System.Diagnostics;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddDatabase(builder.Configuration).ExtendUnitOfWork().AddRepositories().ExtendService();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.AddSeq();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.RegisterMiddleware();
app.UseAuthorization();


app.MapControllers();

app.Run();
