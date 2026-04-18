using Microsoft.AspNetCore.Components;
using PennerProjectManager.Web.Models;

namespace PennerProjectManager.Components.Pages;

public partial class Home : ComponentBase
{
    private CategoryModel? _selectedCategory;

    [Parameter] public int? CategoryId { get; set; }

    protected override void OnParametersSet()
    {
    }
}
