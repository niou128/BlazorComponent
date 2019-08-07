using Microsoft.AspNetCore.Components;

namespace BlazorTabsComponent
{
    public class TabBase : ComponentBase, ITab
    {
        [Parameter]
        protected string Title { get; set; }

        [Parameter]
        protected RenderFragment TabHeader { get; set; }

        [CascadingParameter]
        protected BlazorTabsBase ContainerTab { get; set; }

        protected string Active => ContainerTab.ActiveTab == this ? "active" : null;

        [Parameter]
        protected string ClassCss { get; set; } = "nav-link";

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected void Activate()
        {
            ContainerTab.SetActiveTab(this);
        }

        protected override void OnInit()
        {
            ContainerTab.ActivetFirstTab(this);
        }
    }
}
