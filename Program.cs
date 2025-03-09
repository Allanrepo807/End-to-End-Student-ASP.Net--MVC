using Microsoft.EntityFrameworkCore;
using WApp.Filters;
using WApp.Infrastructure.Data;
using WApp.Services;
using WApp.Domain.Interfaces;
using WApp.Application.UseCases;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StudentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers(options =>
{
    options.Filters.Add<StudentValidationFilter>();
});
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<GetStudentsUseCase>()
                .AddScoped<GetStudentUseCase>()
                .AddScoped<AddStudentUseCase>()
                .AddScoped<UpdateStudentUseCase>()
                .AddScoped<DeleteStudentUseCase>()
                .AddScoped<DeleteAllStudentsUseCase>();

builder.Services.AddLogging();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllers();

app.Run();
