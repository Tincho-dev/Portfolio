using Microsoft.AspNetCore.Components;
using Radzen;
using Octokit;
using System.Reflection;

namespace Portfolio.Pages.GitHub;

public partial class RepositoryCard
{
    [Parameter]
    public Repository? Repository { get; set; }
    private int PropertiesCount { get; set; }



    private IEnumerable<PropertyInfo> GetFilteredProperties()
    {
        if(Repository == null)
        {
            PropertiesCount = 0;
            return Enumerable.Empty<PropertyInfo>();
        }
        PropertiesCount = Repository.GetType().GetProperties().Count();
        return Repository.GetType().GetProperties().OrderBy(p => p.Name)
            .Where(prop => prop.GetValue(Repository) != null 
            && prop.PropertyType != typeof(bool? ) 
            && prop.PropertyType != typeof(bool) 
            && prop.PropertyType != typeof(Octokit.User) 
            && prop.PropertyType != typeof(Octokit.RepositoryPermissions) 
            && !prop.Name.Contains("Name") 
            && !prop.Name.Contains("Topic") 
            && !prop.Name.Contains("Id"));
    }
}