using Api.Context.Models;
using Api.Repository.Implement;
using Api.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository, Repository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/literal_a", (IRepository repository) =>
{
	return repository.GetInformation<Literal_a>();
})
.WithName("literal_a")
.WithDescription("Toda la Información de Proyectos por cada departamento")
.WithOpenApi();

app.MapGet("/literal_b", (IRepository repository) =>
{
	return repository.GetInformation<Literal_b>();
})
.WithName("literal_b")
.WithDescription(" Cantidad de Proyectos por departamento")
.WithOpenApi();

app.MapGet("/literal_c", (IRepository repository) =>
{
	return repository.GetInformation<Literal_c>();
})
.WithName("literal_c")
.WithDescription(" Departamentos con más de un (1) Proyecto")
.WithOpenApi();

app.MapGet("/literal_d", (IRepository repository) =>
{
	return repository.GetInformation<Literal_d>();
})
.WithName("literal_d")
.WithDescription(" Nombre Completo de cada empleado asignados a cada Proyecto")
.WithOpenApi();

app.Run();
