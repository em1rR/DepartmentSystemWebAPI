using DepartmentSystemWebAPI.Models;
using DepartmentSystemWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<DBContext>();

//builder.Services.AddSingleton<IStudentRepository, StudentServices>();
builder.Services.AddScoped<IStudentServices, StudentServices>();
builder.Services.AddScoped<ICourseServices, CourseServices>();
builder.Services.AddScoped<ILecturerServices, LecturerServices>();
builder.Services.AddScoped<ILecturerCourseServices, LecturerCourseServices>();
builder.Services.AddScoped<IDepartmentServices, DepartmentServices>();
builder.Services.AddScoped<IGraduateServices, GraduateServices>();




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

app.UseExceptionHandler("/errorhandling");

app.Run();
