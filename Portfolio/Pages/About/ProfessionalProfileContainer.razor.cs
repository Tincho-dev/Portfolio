using Microsoft.AspNetCore.Components;
using Model;

namespace Portfolio.Pages.About;

public partial class ProfessionalProfileContainer
{
    [Parameter]
    public Language Language { get; set; }

    [Parameter]
    public string? ProfessionalProfile { get; set; }

    [Parameter]
    public List<Tool>? Tools { get; set; }

    public List<Tool> ToolsWithLogoUrls { get; set; } = new List<Tool>();
    protected override async Task OnInitializedAsync()
    {
        foreach (var tool in Tools)
        {
            tool.LogoUrl = await GetLogoUrl(tool.LogoUrl);
            ToolsWithLogoUrls.Add(tool);
        }

        await base.OnInitializedAsync();
    }

    private async Task<string> GetLogoUrl(string logoUrl)
    {
        string baseLogoUrl = logoUrl.EndsWith(".webp") || logoUrl.EndsWith(".png") ? logoUrl.Substring(0, logoUrl.LastIndexOf('.')) : logoUrl;
        string webpUrl = baseLogoUrl + ".webp";
        string pngUrl = baseLogoUrl + ".png";
        // Intenta obtener el archivo con la extensión .webp
        var responseWebp = await Http.GetAsync(webpUrl);
        if (responseWebp.IsSuccessStatusCode)
        {
            return webpUrl; // Si existe, retorna la URL con la extensión .webp
        }

        // Intenta obtener el archivo con la extensión .png
        var responsePng = await Http.GetAsync(pngUrl);
        if (responsePng.IsSuccessStatusCode)
        {
            return pngUrl; // Si existe, retorna la URL con la extensión .png
        }

        // Si ambas extensiones fallan, puedes manejar el error como prefieras
        return "favicon.png";
    }
}