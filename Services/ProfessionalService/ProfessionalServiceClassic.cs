using Data;
using Model;

namespace Services;
public class ProfessionalServiceClassic : IProfessionalService
{
    private readonly ProfessionalContext _context;
    public ProfessionalServiceClassic(ProfessionalContext context)
    {
        _context = context;
    }

    public async Task<List<Detail>> GetAdditionalInfoFromProfessionalAsync(int professionalId)
        => _context.Details.Where(d => d.ProfessionalId == professionalId).ToList();

    public Task<Contact> GetContactFromProfessionalAsync(int professionalId)
        => Task.FromResult(_context.Contacts.SingleOrDefault(c => c.ProfessionalId == professionalId));

    public Task<List<Experience>> GetExperiencesFromProfessionalAsync(int professionalId)
        => Task.FromResult(_context.Experiences.Where(e => e.ProfessionalId == professionalId).ToList());

    public Task<List<Interest>> GetInterestsFromProfessionalAsync(int professionalId)
        => Task.FromResult(_context.Interests.Where(i => i.ProfessionalId == professionalId).ToList());

    public Task<Professional?> GetProfessionalAsync(int id)
        => Task.FromResult(_context.Professionals.Find(id));

    public Task<List<Skill>> GetSkillsFromExperienceAsync(int experienceId)
        => Task.FromResult(_context.Skills.Where(s => s.ExperienceId == experienceId).ToList());

    public Task<List<Tool>> GetToolsFromProfessionalAsync(int professionalId)
        => Task.FromResult(_context.Tools.Where(t => t.ProfessionalId == professionalId).ToList());

    public Task<List<Training>> GetTrainingsFromProfessionalAsync(int professionalId)
        => Task.FromResult(_context.Trainings.Where(t => t.ProfessionalId == professionalId).ToList());
}