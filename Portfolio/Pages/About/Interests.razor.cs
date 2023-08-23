using Microsoft.AspNetCore.Components;
using Model;
namespace Portfolio.Pages.About;

public partial class Interests
{
    [Parameter]
    public int ProfessionalId { get; set; }

    private List<Interest>? _interests;
    protected override async Task OnInitializedAsync()
    {
        _interests = await service.GetInterestsFromProfessionalAsync(ProfessionalId);
        await base.OnParametersSetAsync();
    }
}