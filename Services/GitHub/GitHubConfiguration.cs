namespace Services;

public class GitHubConfiguration
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;

    public GitHubConfiguration()
    {
        Username = Environment.GetEnvironmentVariable("GITHUB_USERNAME") ?? "Tincho-dev";
        Password = Environment.GetEnvironmentVariable("GITHUB_PASSWORD") ?? "YouApiKey";
    }
}
