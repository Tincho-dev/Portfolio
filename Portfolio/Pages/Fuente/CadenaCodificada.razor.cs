using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;

namespace Portfolio.Pages.Fuente;

public partial class CadenaCodificada
{
    [Parameter]
    public Model.Fuente Fuente { get; set; }

    public async Task CopyToClipboard()
    {
        var text = Fuente.CodificarCadena();
        await _jsInterop.InvokeVoidAsync("navigator.clipboard.writeText", text);
    }

    void ShowNotification(NotificationMessage message)
    {
        NotificationService.Notify(message);
    }
}