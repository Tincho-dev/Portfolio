using Octokit;
using System.Reflection;

namespace Services;

public class GitHubService : IGitHubService
{
    private readonly GitHubClient _gitHub;

    public GitHubService(GitHubConfiguration configuration)
    {
        _gitHub = new GitHubClient(new ProductHeaderValue(Assembly.GetExecutingAssembly().GetName().Name));
        var basicAuth = new Credentials(configuration.Username, configuration.Password);
        _gitHub.Credentials = basicAuth;
    }

    public async Task<Repository> GetRepository(string username, string repositoryName) 
        => await _gitHub.Repository.Get(username, repositoryName);

    public async Task<User> GetUser(string? username)
    {
        if (string.IsNullOrEmpty(username))
            username = _gitHub.Credentials.Login;
            return await _gitHub.User.Get(username);
    }
    public async Task<bool> UserExists(string? username)
    {
        if (string.IsNullOrEmpty(username))
            return false;
        try
        {
            var result = await _gitHub.User.Get(username);
            if (result != null)
                return true;
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return false;
    }

    public async Task<List<Repository>> GetRepositories(string? username) 
        => (await _gitHub.Repository.GetAllForUser(username)).ToList();

    public async Task<List<Repository>> GetRepositoriesFromOrganization(string organization) 
        => (await _gitHub.Repository.GetAllForOrg(organization)).ToList();
}