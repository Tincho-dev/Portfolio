using Microsoft.AspNetCore.Components;

namespace Portfolio.Pages.Fuente;

public partial class TablaFuentes
{
    protected override async Task OnInitializedAsync()
    {
        await FuenteService.Load();
    }

    void ShowFuente(string id)
    {
        NavigationManager.NavigateTo($"Fuente/{id}");
    }

    void CreateNewFuente()
    {
        NavigationManager.NavigateTo("Fuente");
    }
}