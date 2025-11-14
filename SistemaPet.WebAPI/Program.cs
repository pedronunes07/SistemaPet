using Microsoft.EntityFrameworkCore;
using SistemaPet.Repositorio;
using SistemaPet.Servico;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
    policy => policy
    .WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod()
    );
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurando InMemory DB
builder.Services.AddDbContext<PetDbContext>(options =>
    options.UseInMemoryDatabase("PetDb"));

// Registrando Repositórios
builder.Services.AddScoped<IPetRepositorio, PetRepositorio>();
builder.Services.AddScoped<IDonoRepositorio, DonoRepositorio>();

// Registrando Serviços
builder.Services.AddScoped<IPetServico, PetServico>();
builder.Services.AddScoped<IDonoServico, DonoServico>();

var app = builder.Build();
app.UseCors("AllowFrontend");

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

