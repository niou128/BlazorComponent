using System;

namespace BlazorComponent.Services
{
    public class AppState
    {
        public event Action RefreshRequested;
        public void CallRequestRefresh()
        {
            RefreshRequested?.Invoke();
        }
    }
}