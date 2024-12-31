using CatalogoAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Services
var connetionString = builder.Configuration.GetConnectionString("MySqlConnectionString");

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseMySql(connetionString,ServerVersion.AutoDetect(connetionString)));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
