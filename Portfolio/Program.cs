using Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Services;
using Portfolio;
using Radzen;
using Controllers;
using Model;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddDbContext<EntropiaContext>(options => options.UseInMemoryDatabase("entropiadb"));
builder.Services.AddDbContext<ProfessionalContext>(options => options.UseInMemoryDatabase("professionaldb"));
builder.Services.AddScoped<IFuenteService, FuenteService>();
builder.Services.AddScoped<FuenteController>();
builder.Services.AddScoped<Repositorio<Professional>>(sp =>
{
    var dbContext = sp.GetRequiredService<ProfessionalContext>(); // Obtener el contexto de la base de datos
    return new Repositorio<Professional>(dbContext);
});
builder.Services.AddScoped<IProfessionalService, ProfessionalServiceInMemory>();
builder.Services.AddSingleton<IGeneradorService, GeneradorService>();
builder.Services.AddSingleton<IPruebasEstadisticasService, PruebasEstadisticasService>();
builder.Services.AddSingleton<IDistribucionesService, DistribucionesService>();
builder.Services.AddSingleton<ISimuladorColasEsperaService, SimuladorColasEsperaService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

await builder.Build().RunAsync();
