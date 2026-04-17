using Microsoft.AspNetCore.Components;
using PennerProjectManager.Models;
using PennerProjectManager.Repositories;

namespace PennerProjectManager.Components.Pages;

public partial class Home : ComponentBase
{
    private CategoryModel? _selectedCategory;
    [Inject] private ICategoryRepository CategoryRepository { get; set; }

    [Parameter] public int? CategoryId { get; set; }

    protected override void OnParametersSet()
    {
        _selectedCategory = CategoryId.HasValue ? CategoryRepository.GetCategoryById(CategoryId.Value) : null;
    }
}
