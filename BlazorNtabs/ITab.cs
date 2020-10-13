using Microsoft.AspNetCore.Components;

namespace BlazorNtabs
{
    public interface ITab
    {
        RenderFragment ChildContent { get; set; }
    }
}
