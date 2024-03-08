using Microsoft.AspNetCore.Mvc;
using Octokit;
using Services;

namespace PortfolioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubService _gitHubService;
        private const string _username = "Tincho-dev";

        public GitHubController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }
        
        //Task<User> GetUser(string? username);
        [HttpGet]
        public async Task<IActionResult> Get(string username = _username)
        {
            var result = await _gitHubService.GetUser(username);
            return Ok(result);
        }

        //Task<Repository> GetRepository(string username, string repositoryName);
        [HttpGet("{username}/{repositoryName}")]
        public async Task<IActionResult> Get(string repositoryName, string username = _username)
        {
            var result = await _gitHubService.GetRepository(username, repositoryName);
            return Ok(result);
        }

        //Task<List<Repository>> GetRepositories(string? username);
        [HttpGet("{username}/repositories")]
        public async Task<IActionResult> GetRepositories(string username = _username)
        {
            var result = await _gitHubService.GetRepositories(username);
            return Ok(result);
        }

        //Task<List<Repository>> GetRepositoriesFromOrganization(string organization);
        [HttpGet("organization/{organization}")]
        public async Task<IActionResult> GetRepositoriesFromOrganization(string organization)
        {
            var result = await _gitHubService.GetRepositoriesFromOrganization(organization);
            return Ok(result);
        }

        //Task<bool> UserExists(string? username);
        [HttpGet("exists/{username}")]
        public async Task<IActionResult> UserExists(string username)
        {
            var result = await _gitHubService.UserExists(username);
            return Ok(result);
        }
    }
}
