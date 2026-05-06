using Microsoft.AspNetCore.Components;

namespace PennerProjectManager.Web.Components.SharedComponents;

public partial class TaskListCheckbox : ComponentBase
{
    private bool _isChecked;
    [Parameter] public string TaskName { get; set; } = string.Empty;

    private void OnCheckboxClicked()
    {
        _isChecked = !_isChecked;
        StateHasChanged();
    }
}
