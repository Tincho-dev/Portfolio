using EntropiaBlazor.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Services;
using Portfolio;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddDbContext<EntropiaContext>(options => options.UseInMemoryDatabase("entropiadb"));
builder.Services.AddScoped<IFuenteService, FuenteService>();
builder.Services.AddSingleton<IGeneradorService, GeneradorService>();
builder.Services.AddSingleton<IPruebasEstadisticasService, PruebasEstadisticasService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

await builder.Build().RunAsync();
