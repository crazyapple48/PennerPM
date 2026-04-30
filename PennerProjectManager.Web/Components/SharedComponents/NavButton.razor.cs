using Microsoft.AspNetCore.Components;

namespace PennerProjectManager.Web.Components.SharedComponents;

public partial class NavButton : ComponentBase
{
    [Parameter] public string Path { get; set; }
    [Parameter] public string Text { get; set; }
    [Parameter] public string Href { get; set; }
}
