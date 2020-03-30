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
            NotifyStateChanged();
        }

        public string Culture { get; private set; }

        public void SetCulture(string culture)
        {
            Culture = culture;
            NotifyStateChanged();
        }


        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
