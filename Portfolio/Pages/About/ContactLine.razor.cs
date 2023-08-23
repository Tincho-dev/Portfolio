using Microsoft.AspNetCore.Components;
using Model;
using System.Reflection;

namespace Portfolio.Pages.About;

public partial class ContactLine
{
    [Parameter]
    public int ProfessionalId { get; set; }

    public Contact? Contact { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Contact = await service.GetContactFromProfessionalAsync(ProfessionalId);
        await base.OnInitializedAsync();
    }

    private bool IsVirtualProperty(PropertyInfo prop)
    {
        return prop.GetAccessors().Any(x => x.IsVirtual);
    }

    private string FindIcon(string propertyName)
    {
        var iconPack = new Dictionary<string, string> { { "PhoneNumber", "bi bi-telephone" }, { "Email", "bi bi-envelope" }, { "LinkedIn", "bi bi-linkedin" }, { "Github", "bi bi-github" }, { "City", "bi bi-geo-alt" } };
        return iconPack.ContainsKey(propertyName) ? iconPack[propertyName] : string.Empty;
    }
}