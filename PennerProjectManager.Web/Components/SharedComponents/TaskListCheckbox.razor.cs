using Microsoft.AspNetCore.Components;

namespace PennerProjectManager.Web.Components.SharedComponents;

public partial class TaskListCheckbox : ComponentBase
{
    [Parameter] public bool IsChecked { get; set; }
    [Parameter] public string TaskName { get; set; } = string.Empty;

    private void OnClicked()
    {
        IsChecked = !IsChecked;
    }
}
