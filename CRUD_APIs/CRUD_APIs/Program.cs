using CRUD_APIs.DataAccess;
using CRUD_APIs.DataService;
using CRUD_APIs.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<EmployeesDAL>();
builder.Services.AddSingleton<EmployeesDSL>();
builder.Services.AddSingleton<ConfigurationHelper>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

app.Run();
