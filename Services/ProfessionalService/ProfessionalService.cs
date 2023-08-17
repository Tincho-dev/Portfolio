using Data;
using Model;

namespace Services;

public class ProfessionalService : IProfessionalService
{
    private readonly Repositorio<Professional> _professionals;
    private readonly Repositorio<Tool> _tools;
    private readonly Repositorio<Interest> _interests;
    private readonly Repositorio<Skill> _skills;
    private readonly Repositorio<Detail> _details;
    private readonly Repositorio<Experience> _experiences;
    private readonly Repositorio<Training> _trainings;
    private readonly Repositorio<Contact> _contacts;

    public async Task<List<Tool>> GetToolsFromProfessionalAsync(int professionalId)
            => _tools.Where(t => t.ProfessionalId == professionalId).ToList();

    public async Task<List<Interest>> GetInterestsFromProfessionalAsync(int professionalId)
        => _interests.Where(t => t.ProfessionalId == professionalId).ToList();

    public async Task<List<Training>> GetTrainingsFromProfessionalAsync(int professionalId)
        => _trainings.Where(t => t.ProfessionalId == professionalId).ToList();

    public async Task<List<Experience>> GetExperiencesFromProfessionalAsync(int professionalId)
        => _experiences.Where(t => t.ProfessionalId == professionalId).ToList();

    public async Task<List<Detail>> GetAdditionalInfoFromProfessionalAsync(int professionalId)
        => _details.Where(t => t.ProfessionalId == professionalId).ToList();

    public async Task<List<Skill>> GetSkillsFromExperienceAsync(int experinceId)
        => _skills.Where(s => s.ExperinceId == experinceId).ToList();

    public async Task<Contact> GetContactFromProfessionalAsync(int professionalId)
        => _contacts.Where(t => t.ProfessionalId == professionalId).FirstOrDefault();

    public async Task<Training> GetTrainingAsync(int id)
        //=> _trainings.FirstOrDefault(t => t.Id == id);
        => _trainings.Get(id);

    public async Task<Professional?> GetProfessionalAsync(int id)
        //=> _professionals.FirstOrDefault(p => p.Id == id);
        => _professionals.Get(id);
}

