using Microsoft.AspNetCore.Components;

namespace BlazorNtabs
{
    public class BlazorTabsBase : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public ITab ActiveTab { get; private set; }

        public void AddTab(ITab tab)
        {
            if (ActiveTab == null)
            {
                SetActivateTab(tab);
            }
        }

        public void RemoveTab(ITab tab)
        {
            if (ActiveTab == tab)
            {
                SetActivateTab(null);
            }
        }

        public void SetActivateTab(ITab tab)
        {
            if (ActiveTab != tab)
            {
                ActiveTab = tab;
                StateHasChanged();
            }
        }
    }
}

