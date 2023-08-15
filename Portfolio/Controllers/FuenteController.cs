using Microsoft.AspNetCore.Components;
using Services;
using Model;

namespace Controllers;
public class FuenteController
{
    private readonly IFuenteService _fuenteService;
    private readonly NavigationManager _navigationManager;

    public FuenteController(IFuenteService fuenteService, NavigationManager navigationManager)
    {
        _fuenteService = fuenteService;
        _navigationManager = navigationManager;
    }

    public async Task Create(Fuente fuente)
    {
        await _fuenteService.Create(fuente);
        _navigationManager.NavigateTo("fuentes");
    }

    public async Task Delete(string id)
    {
        await _fuenteService.Delete(id);
        _navigationManager.NavigateTo("fuentes");
    }

    public async Task Update(Fuente fuente, string id)
    {
        await _fuenteService.Update(fuente, id);
        _navigationManager.NavigateTo("fuentes");
    }

    public async Task<Fuente> GetSingle(string id)
    {
        return await _fuenteService.GetSingle(id);
    }
    // Otros métodos, según sean necesarios
}