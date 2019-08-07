using Microsoft.AspNetCore.Components;

namespace BlazorTabsComponent
{
    public class BlazorTabsBase : ComponentBase
    {
        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        [Parameter]
        protected RenderFragment TabContent { get; set; }

        public ITab ActiveTab { get; set; }

        public void SetActiveTab(ITab tab)
        {
            if (ActiveTab != tab)
            {
                ActiveTab = tab;
                StateHasChanged();
            }
        }

        public void ActivetFirstTab(ITab tab)
        {
            if (ActiveTab == null)
            {
                SetActiveTab(tab);
            }
        }
    }
}
