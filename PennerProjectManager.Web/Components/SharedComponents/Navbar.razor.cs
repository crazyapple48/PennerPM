using Microsoft.AspNetCore.Components;
using PennerProjectManager.Web.Models;

namespace PennerProjectManager.Components.SharedComponents;

public partial class Navbar : ComponentBase
{
    private List<CategoryModel> _categories = [];

    private void FetchCategories()
    {

    }

    protected override void OnInitialized()
    {
        FetchCategories();
        base.OnInitialized();
    }
}
