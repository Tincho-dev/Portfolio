using Microsoft.AspNetCore.Components;
using Model;

namespace Portfolio.Pages.About;

public partial class AboutMe
{
    [Parameter]
    public int ProfessionalId { get; set; }

    Professional? professional { get; set; }

    private List<Tool>? _tools;
    private List<Interest>? _interests;
    private List<Detail>? _aditionalInfo;
    private List<Experience>? _experiences;
    private List<Training>? _trainings;
    private Contact? _contacts;
    protected override async Task OnInitializedAsync()
    {
        professional = await service.GetProfessionalAsync(ProfessionalId);
        if (professional != null)
        {
            professional.Tools = _tools = await service.GetToolsFromProfessionalAsync(ProfessionalId);
            professional.Interests = _interests = await service.GetInterestsFromProfessionalAsync(ProfessionalId);
            professional.AdditionalInfo = _aditionalInfo = await service.GetAdditionalInfoFromProfessionalAsync(ProfessionalId);
            professional.Experiences = _experiences = await service.GetExperiencesFromProfessionalAsync(ProfessionalId);
            professional.Trainings = _trainings = await service.GetTrainingsFromProfessionalAsync(ProfessionalId);
        }

        base.OnInitialized();
    }
}