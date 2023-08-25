using Microsoft.AspNetCore.Components;

namespace Portfolio.Pages.Fuente;

public partial class Fuente
{
    [Parameter]
    public string? Id { get; set; }

    string btnText = string.Empty;
    Model.Fuente fuente = new();
    protected override void OnInitialized()
    {
        btnText = Id == null ? "Save New Fuente" : "Update Fuente";
    }

    protected override async Task OnParametersSetAsync()
    {
        if (Id != null)
        {
            fuente = await controller.GetSingle((string)Id);
            fuente = new Model.Fuente(fuente.CadenaFuente);
        }
    }

    async Task HadleSubmit()
    {
        if (Id == null)
        {
            await controller.Create(fuente);
        }
        else
        {
            await controller.Update(fuente, (string)Id);
        }
    }

    private void MostrarMensaje(string message)
    {
        Console.WriteLine(message);
    }

    async Task DeleteFuente()
    {
        try
        {
            await controller.Delete(fuente.IdFuente);
        }
        catch (Exception e)
        {
            MostrarMensaje(e.Message);
        }
    }
}