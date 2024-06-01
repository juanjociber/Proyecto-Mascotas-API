using BACKEND_CRUD.Models;
using BACKEND_CRUD.Models.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add Cors
builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
                         builder => builder.AllowAnyOrigin()
                                           .AllowAnyHeader()
                                           .AllowAnyMethod()));

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//Add Services Respository para Inyección de Dependencias
builder.Services.AddScoped<IMascotaRepository,MascotaRepository>();


//Add DbContext
builder.Services.AddDbContext<AplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexionSQL"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseCors(misReglasCors);
app.UseCors("AllowWebapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
