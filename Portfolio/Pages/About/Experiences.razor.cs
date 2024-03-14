using Microsoft.AspNetCore.Components;
using Model;

namespace Portfolio.Pages.About;

public partial class Experiences
{
    [Parameter]
    public Language Language { get; set; }
    [Parameter]
    public int ProfessionalId { get; set; }

    private List<Experience>? _experiences;
    private List<Skill>? _skills;
    protected override async Task OnInitializedAsync()
    {
        _experiences = await service.GetExperiencesFromProfessionalAsync(ProfessionalId);
        _skills = new List<Skill>();
        foreach (var experience in _experiences)
        {
            _skills.AddRange((IEnumerable<Skill>)await service.GetSkillsFromExperienceAsync(experience.Id));
        }

        base.OnInitialized();
    }
}