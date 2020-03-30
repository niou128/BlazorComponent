using System;

namespace BlazorDataGrid.Services
{
    public class AppState
    {
        public event Action RefreshRequested;
        public void CallRequestRefresh()
        {
            RefreshRequested?.Invoke();
        }

        public string Format { get; private set; }

        public void SetFormat(string format)
        {
            Format = format;
            //StateHasChanged();
            NotifyStateChanged();
        }

        public event EventHandler StateChanged;

        private void StateHasChanged()
        {
            StateChanged?.Invoke(this, EventArgs.Empty);
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
