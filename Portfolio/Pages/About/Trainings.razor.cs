using Microsoft.AspNetCore.Components;
using Model;

namespace Portfolio.Pages.About;

public partial class Trainings
{
    [Parameter]
    public Language Language { get; set; }

    [Parameter]
    public int ProfessionalId { get; set; }

    private List<Training>? _trainings;
    protected override async Task OnInitializedAsync()
    {
        _trainings = await service.GetTrainingsFromProfessionalAsync(ProfessionalId);
        await base.OnParametersSetAsync();
    }
}