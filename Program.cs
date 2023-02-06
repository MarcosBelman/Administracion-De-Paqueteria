using AdministracionDePaqueteria.Services;
using AdministracionDePaqueteria;
//using static AdministracionDePaqueteria.Services.PaqueteService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IestadosPaqueteService, estadosPaqueteService>();
builder.Services.AddScoped<IPaqueteService, PaqueteService>();
builder.Services.AddSqlServer<PaquetesContext>(builder.Configuration.GetConnectionString("cnPaqueteria"));


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
