using Microsoft.AspNetCore.Components;

namespace PennerProjectManager.Web.Components.Dialogs;

public partial class DialogShell : ComponentBase
{
    [Parameter] public string Title { get; set; } = "";
    [Parameter] public string ConfirmLabel { get; set; } = "Create";
    [Parameter] public RenderFragment ChildContent { get; set; } = default!;
    [Parameter] public EventCallback OnCancelClick { get; set; }
    [Parameter] public EventCallback OnConfirm { get; set; }
}
