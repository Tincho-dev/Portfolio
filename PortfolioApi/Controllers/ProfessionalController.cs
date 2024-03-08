using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalController : ControllerBase
    {
        private readonly IProfessionalService _professionalService;
        private const int _id = 1;

        public ProfessionalController(IProfessionalService professionalService)
        {
            _professionalService = professionalService;
        }

        //Task<Professional?> GetProfessionalAsync(int id);
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id = _id)
        {
            var result = await _professionalService.GetProfessionalAsync(id);
            if(result == null)
                return NotFound();
            //result.Interests = await _professionalService.GetInterestsFromProfessionalAsync(id);
            //result.Experiences = await _professionalService.GetExperiencesFromProfessionalAsync(id);
            //result.Trainings = await _professionalService.GetTrainingsFromProfessionalAsync(id);
            //result.Tools = await _professionalService.GetToolsFromProfessionalAsync(id);
            //result.Contact = await _professionalService.GetContactFromProfessionalAsync(id);
            return Ok(result);
        }

        //Task<List<Skill>> GetSkillsFromExperienceAsync(int experinceId);
        [HttpGet("experience/{experienceId}/skills")]
        public async Task<IActionResult> GetSkillsFromExperience(int experienceId)
        {
            var result = await _professionalService.GetSkillsFromExperienceAsync(experienceId);
            return Ok(result);
        }

        //Task<List<Detail>> GetAdditionalInfoFromProfessionalAsync(int professionalId);
        [HttpGet("{professionalId}/additionalInfo")]
        public async Task<IActionResult> GetAdditionalInfoFromProfessional(int professionalId = _id)
        {
            var result = await _professionalService.GetAdditionalInfoFromProfessionalAsync(professionalId);
            return Ok(result);
        }

        //Task<List<Experience>> GetExperiencesFromProfessionalAsync(int professionalId);
        [HttpGet("{professionalId}/experiences")]
        public async Task<IActionResult> GetExperiencesFromProfessional(int professionalId = _id)
        {
            var result = await _professionalService.GetExperiencesFromProfessionalAsync(professionalId);
            return Ok(result);
        }

        //Task<List<Training>> GetTrainingsFromProfessionalAsync(int professionalId);
        [HttpGet("{professionalId}/trainings")]
        public async Task<IActionResult> GetTrainingsFromProfessional(int professionalId = _id)
        {
            var result = await _professionalService.GetTrainingsFromProfessionalAsync(professionalId);
            return Ok(result);
        }

        //Task<List<Interest>> GetInterestsFromProfessionalAsync(int professionalId);
        [HttpGet("{professionalId}/interests")]
        public async Task<IActionResult> GetInterestsFromProfessional(int professionalId = _id)
        {
            var result = await _professionalService.GetInterestsFromProfessionalAsync(professionalId);
            return Ok(result);
        }

        //Task<List<Tool>> GetToolsFromProfessionalAsync(int professionalId);
        [HttpGet("{professionalId}/tools")]
        public async Task<IActionResult> GetToolsFromProfessional(int professionalId = _id)
        {
            var result = await _professionalService.GetToolsFromProfessionalAsync(professionalId);
            return Ok(result);
        }

        //Task<Contact> GetContactFromProfessionalAsync(int professionalId);
        [HttpGet("{professionalId}/contact")]
        public async Task<IActionResult> GetContactFromProfessional(int professionalId = _id)
        {
            var result = await _professionalService.GetContactFromProfessionalAsync(professionalId);
            return Ok(result);
        }
    }
}
