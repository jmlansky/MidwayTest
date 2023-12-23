using Helpers;
using Helpers.Contracts;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();
builder.Services.AddScoped<IEmployeesService, EmployeesService>();
builder.Services.AddSingleton<IHelpers, Operations>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var connection = string.Empty;
builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.json");
connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connection, b => b.MigrationsAssembly("Repositories")));


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
