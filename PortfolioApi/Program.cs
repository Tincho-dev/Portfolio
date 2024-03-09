using Data;
using Microsoft.EntityFrameworkCore;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddPolicy(name:"AngularOriginDev",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();   
    }));

builder.Services.AddDbContext<EntropiaContext>(options => options.UseInMemoryDatabase("entropiadb"));
builder.Services.AddDbContext<ProfessionalContext>(options => options.UseInMemoryDatabase("professionaldb"));

builder.Services.AddTransient<IFuenteService, FuenteService>();
builder.Services.AddSingleton<ISimuladorColasEsperaService, SimuladorColasEsperaService>();
builder.Services.AddScoped<IProfessionalService, ProfessionalServiceClassic>();
builder.Services.AddSingleton<IGeneradorService, GeneradorService>();
builder.Services.AddSingleton<IPruebasEstadisticasService, PruebasEstadisticasService>();
builder.Services.AddSingleton<IDistribucionesService, DistribucionesService>();

builder.Services.AddSingleton<GitHubConfiguration>();
builder.Services.AddScoped<IGitHubService, GitHubService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AngularOriginDev");   

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
