using Microsoft.AspNetCore.Components;
using Microsoft.Net.Http.Headers;

namespace BlazorNTooltip
{
    public class TooltipBase : ComponentBase
    {
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public string Text { get; set; }
        [Parameter] public string Position { get; set; }

        protected string ClassTooltip => Position switch
        {
            "bottom" => "tooltipbottom",
            "right" => "tooltipright",
            "left" => "tooltipleft",
            _ => "tooltiptop",
        };
    }
}
