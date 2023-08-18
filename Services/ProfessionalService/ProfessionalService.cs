using Data;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Services;

public class ProfessionalService : IProfessionalService
{
    #region Properties
    private readonly DbSet<Professional> _professionals;
    private readonly DbSet<Tool> _tools;
    private readonly DbSet<Interest> _interests;
    private readonly DbSet<Skill> _skills;
    private readonly DbSet<Detail> _details;
    private readonly DbSet<Experience> _experiences;
    private readonly DbSet<Training> _trainings;
    private readonly DbSet<Contact> _contacts;
    #endregion

    public ProfessionalService(ProfessionalContext context)
    {
        _professionals = context.Professionals;
        _tools = context.Tools;
        _interests = context.Interests;
        _skills = context.Skills;
        _details = context.Details;
        _experiences = context.Experiences;
        _trainings = context.Trainings;
        _contacts = context.Contacts;
    }

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
        => _skills.Where(s => s.ExperienceId == experinceId).ToList();

    public async Task<Contact> GetContactFromProfessionalAsync(int professionalId)
        => _contacts.Where(t => t.ProfessionalId == professionalId).FirstOrDefault();

    public async Task<Training> GetTrainingAsync(int id)
        => _trainings.FirstOrDefault(t => t.Id == id);

    public async Task<Professional?> GetProfessionalAsync(int id)
        => _professionals.FirstOrDefault(p => p.Id == id);
}