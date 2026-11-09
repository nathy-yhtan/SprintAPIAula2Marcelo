using Microsoft.EntityFrameworkCore;
using Aula2Marcelo.Data;
using Aula2Marcelo.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//  P/ O SWAGGER -> ADICIONE ANTES DO builder.Build()
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//  P/ O ENTITY:
var connectionString = builder.Configuration.GetConnectionString("ConexaoPadrao");

//questoes de segurança
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//INJEÇÕES DE DEPENDENCIA: (p/ cada repository faz uma)
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

var app = builder.Build();

//  Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();