using Model;

namespace Services;
public interface IProfessionalService
{
    Task<Professional?> GetProfessionalAsync(int id);
    Task<List<Skill>> GetSkillsFromExperienceAsync(int experinceId);
    Task<List<Detail>> GetAdditionalInfoFromProfessionalAsync(int professionalId);
    Task<List<Experience>> GetExperiencesFromProfessionalAsync(int professionalId);
    Task<List<Training>> GetTrainingsFromProfessionalAsync(int professionalId);
    Task<List<Interest>> GetInterestsFromProfessionalAsync(int professionalId);
    Task<List<Tool>> GetToolsFromProfessionalAsync(int professionalId);
    Task<Contact> GetContactFromProfessionalAsync(int professionalId);
}

