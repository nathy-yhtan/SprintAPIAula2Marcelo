using Aula2Marcelo.Data;
using Aula2Marcelo.Repositories;
using Aula2Marcelo.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


//❗ P/ O SWAGGER -> ADICIONE ANTES DO builder.Build()
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//❗ P/ O ENTITY:
var connectionString = builder.Configuration.GetConnectionString("ConexaoPadrao");

//❗questoes de segurança
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

//❗REGISTRO INJEÇÕES DE DEPENDENCIA: (p/ cada repository faz uma)
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

//❗REGISTROS DOS SERVIÇOS
builder.Services.AddScoped<ILivroService, LivroService>();

//❗CONFIGURAÇÃO DO JWT
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true, //verifica se o token foi assinado corretamente
            IssuerSigningKey = new SymmetricSecurityKey(key), //usa chave secreta p/ validar o token
            ValidateIssuer = true, //valida quem criou o token
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true, //valida p/ quem o token foi criado
            ValidAudience = builder.Configuration["Jwt:Audience"]
        };
    });

//❗CONFIGURAÇÃO DO BOTÃO NO SWAGGER
builder.Services.AddSwaggerGen(c =>
{

    //criando botao uthorize no swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme="Bearer",
        BearerFormat="JWT",
        In=ParameterLocation.Header,
        Description="Bearer {seu token}"
    });


    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {

        {

            new OpenApiSecurityScheme
            {
                
                Reference = new OpenApiReference
                {
                Type = ReferenceType.SecurityScheme,
                Id="Bearer"
                } //define a chave do dicionario

            },

            new String[]{}

        }

    });

});


var app = builder.Build();

//  Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//front
app.UseDefaultFiles();
app.UseStaticFiles();

//na ordem
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();