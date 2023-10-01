using global::Microsoft.AspNetCore.Components;
using Octokit;

namespace Portfolio.Pages.GitHub;

public partial class GithubProfile
{
    [Parameter]
    public string? UserName { get; set; }
    public string DefaultUserName { get; set; } = "Tincho-dev";
    public List<Repository>? Repositories { get; set; }
    public Repository? RepositorySelected { get; set; }
    public User? User { get; set; }
    private string Alert { get; set; } = "";
    private bool Visible { get; set; } = false;

    protected override async Task OnParametersSetAsync()
    {
        if (!await service.UserExists(UserName))
        {
            navigationManager.NavigateTo("/githubprofile/" + DefaultUserName);
        }

        await SearchUser();
        await SearchRepos();
    }

    private async Task SearchUser()
    {
        try
        {
            User = await service.GetUser(UserName);
        }
        catch (Exception e)
        {
            Alert = e.Message;
        }
    }

    private async Task SearchRepos()
    {
        try
        {
            Repositories = await service.GetRepositories(UserName);
        }
        catch (Exception e)
        {
            Alert = e.Message;
        }
    }
}