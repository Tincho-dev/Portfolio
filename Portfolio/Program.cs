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
builder.Services.AddSingleton<ISimuladorColasEsperaService, SimuladorColasEsperaService>();
//builder.Services.AddScoped<IProfessionalService, ProfessionalService>();
//builder.Services.AddScoped<IProfessionalService, ProfessionalServiceInMemory>();
builder.Services.AddScoped<IProfessionalService, ProfessionalServiceClassic>();
builder.Services.AddSingleton<IGeneradorService, GeneradorService>();
builder.Services.AddSingleton<IPruebasEstadisticasService, PruebasEstadisticasService>();
builder.Services.AddSingleton<IDistribucionesService, DistribucionesService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

await builder.Build().RunAsync();
