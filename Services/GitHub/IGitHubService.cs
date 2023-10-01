using Octokit;

namespace Services;

public interface IGitHubService
{
    Task<Repository> GetRepository(string username, string repositoryName);

    Task<User> GetUser(string? username);

    Task<List<Repository>> GetRepositories(string? username);

    Task<List<Repository>> GetRepositoriesFromOrganization(string organization);

    Task<bool> UserExists(string? username);

}
