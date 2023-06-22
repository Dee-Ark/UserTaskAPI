using Microsoft.EntityFrameworkCore;
using UserTaskShared.Model;
using UserTaskShared.Respository.UnitofWork;
using UserTaskShared.Respository;
using UserTaskShared.Service;
using UserTaskShared.Service.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(
    p => p.UseNpgsql(builder.Configuration.GetConnectionString("TaskDB")));

builder.Services.AddScoped<IStudentManagerService, StudentManagerService>();
builder.Services.AddScoped<ITeachersManagerService, TeachersManagerService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
