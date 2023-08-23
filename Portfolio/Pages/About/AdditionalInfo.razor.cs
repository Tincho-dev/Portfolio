using Microsoft.AspNetCore.Components;
using Model;

namespace Portfolio.Pages.About;

public partial class AdditionalInfo
{
    [Parameter]
    public int ProfessionalId { get; set; }

    private List<Detail>? _details;
    protected override async Task OnInitializedAsync()
    {
        _details = await service.GetAdditionalInfoFromProfessionalAsync(ProfessionalId);
        await base.OnParametersSetAsync();
    }
}