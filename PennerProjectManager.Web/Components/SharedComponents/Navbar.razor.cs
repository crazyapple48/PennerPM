using Microsoft.AspNetCore.Components;
using PennerProjectManager.Web.Models;
using PennerProjectManager.Web.Services;

namespace PennerProjectManager.Web.Components.SharedComponents;

public partial class Navbar(ICategoryClientService client) : ComponentBase
{
    private IEnumerable<CategoryModel> _categories = [];

    private async Task FetchCategories()
    {
        _categories = await client.GetAllCategories() ?? [];
    }

    protected override async Task OnInitializedAsync()
    {
        await FetchCategories();
        await base.OnInitializedAsync();
    }
}
