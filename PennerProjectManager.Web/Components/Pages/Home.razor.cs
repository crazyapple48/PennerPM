using Microsoft.AspNetCore.Components;
using PennerProjectManager.Web.Models;
using PennerProjectManager.Web.Services;

namespace PennerProjectManager.Web.Components.Pages;

public partial class Home : ComponentBase
{
    private CategoryModel? _selectedCategory;
    [Inject] public required ICategoryClientService CategoryClientService { get; set; }

    [Parameter] public int? CategoryId { get; set; }


    protected override async Task OnParametersSetAsync()
    {
        if (CategoryId is not null)
            _selectedCategory = await CategoryClientService.GetCategoryById(CategoryId.Value);
        else
            _selectedCategory = null;
    }
}
