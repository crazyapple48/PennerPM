using Microsoft.AspNetCore.Components;

namespace PennerProjectManager.Components.SharedComponents;

public partial class IconButton : ComponentBase
{
    [Parameter] public string Icon { get; set; }
    [Parameter] public string Text { get; set; }
    [Parameter] public string Href { get; set; }
}
