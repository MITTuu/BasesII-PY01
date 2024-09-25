using API_Core.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configura la cadena de conexión
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
builder.Services.AddDbContext<AppDbContext>(options =>
                                                    options.UseSqlServer(connectionString));

// Configura CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin() // Permite cualquier origen
               .AllowAnyMethod() // Permite cualquier método (GET, POST, etc.)
               .AllowAnyHeader(); // Permite cualquier encabezado
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//app.UseHttpsRedirection();

// Usa la política CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
                 c.SwaggerEndpoint("/swagger/v1/swagger.json", "RESTful API"));

app.Run();