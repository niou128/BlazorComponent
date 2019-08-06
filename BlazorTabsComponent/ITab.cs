using Microsoft.AspNetCore.Components;

namespace BlazorTabsComponent
{
    public interface ITab
    {
        RenderFragment ChildContent { get; set; }
    }
}
