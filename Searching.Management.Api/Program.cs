using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Searching.Management.Api;
using Searching.Management.Api.Extensions;
using Searching.Management.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AppSettings>(builder.Configuration);
builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddDatabase(builder.Configuration).ExtendUnitOfWork().AddRepositories().ExtendHttpContextAccessor()
    .ExtendService();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.AddSeq();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.RegisterMiddleware();
app.UseAuthorization();


app.MapControllers();

app.Run();