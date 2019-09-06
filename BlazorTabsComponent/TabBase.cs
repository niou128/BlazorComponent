using Microsoft.AspNetCore.Components;

namespace BlazorTabsComponent
{
    public class TabBase : ComponentBase, ITab
    {
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment TabHeader { get; set; }

        [CascadingParameter]
        public BlazorTabsBase ContainerTab { get; set; }

        protected string Active => ContainerTab.ActiveTab == this ? "active" : null;

        [Parameter]
        public string ClassCss { get; set; } = "nav-link";

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        protected void Activate()
        {
            ContainerTab.SetActiveTab(this);
        }

        protected override void OnInitialized()
        {
            ContainerTab.ActivetFirstTab(this);
        }
    }
}
