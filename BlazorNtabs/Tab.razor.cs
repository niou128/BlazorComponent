using Microsoft.AspNetCore.Components;
using System;

namespace BlazorNtabs
{
    public class TabBase : ComponentBase, ITab, IDisposable
    {
        [CascadingParameter]
        public BlazorTabsBase ContainerTabSet { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public RenderFragment TabHeader { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }

        protected string TitleCssClass => ContainerTabSet.ActiveTab == this ? "active" : null;

        protected override void OnInitialized()
        {
            ContainerTabSet.AddTab(this);
        }

        public void Dispose()
        {
            ContainerTabSet.RemoveTab(this);
        }

        protected void Activate()
        {
            ContainerTabSet.SetActivateTab(this);
        }
    }
}
