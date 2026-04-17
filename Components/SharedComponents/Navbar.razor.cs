using Microsoft.AspNetCore.Components;
using PennerProjectManager.Models;
using PennerProjectManager.Repositories;

namespace PennerProjectManager.Components.SharedComponents;

public partial class Navbar : ComponentBase
{
    private List<CategoryModel> _categories = [];
    [Inject] public ICategoryRepository CategoryRepository { get; set; }

    private void FetchCategories()
    {
        var result = CategoryRepository.GetAllCategories();

        _categories = result;
    }

    protected override void OnInitialized()
    {
        FetchCategories();
        base.OnInitialized();
    }
}
