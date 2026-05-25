using System.Linq.Expressions;
using Microsoft.AspNetCore.Components;

namespace PennerProjectManager.Web.Components.SharedComponents;

public partial class TextField : ComponentBase
{
    [Parameter] public string? PlaceholderText { get; set; }
    [Parameter] public string? Value { get; set; }
    [Parameter] public EventCallback<string?> ValueChanged { get; set; }
    [Parameter] public Expression<Func<string?>>? ValueExpression { get; set; }

    public async void OnInput(ChangeEventArgs e)
    {
        await ValueChanged.InvokeAsync(e.Value?.ToString());
    }
}