using System;
using System.Collections.Generic;
using System.Linq;

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

        public bool ReadOnly { get; private set; }

        public void SetReadOnly(bool readOnly)
        {
            ReadOnly = readOnly;
            NotifyStateChanged();
        }

        public bool RowSelector { get; private set; }

        public void SetRowSelector (bool ShowSelector)
        {
            RowSelector = ShowSelector;
            NotifyStateChanged();
        }

        public event Action OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();

        public Dictionary<string, object> Attributs { get; private set; }
        public void SetAttributs(string NameAttribut, object ValueAttribut)
        {
            (Attributs ?? (Attributs = new Dictionary<string, object>())).Add(NameAttribut, ValueAttribut);
        }

        public Dictionary<string, List<Dictionary<string, object>>> ListAttributs { get; private set; }

        public void SetListAttributs(string nameColumn, string nameAttribut, object valueAttribut)
        {
            if (ListAttributs == null)
            {
                ListAttributs = new Dictionary<string, List<Dictionary<string, object>>>();
            }

            if (ListAttributs.ContainsKey(nameColumn))
            {
                ListAttributs[nameColumn].Add(new Dictionary<string, object>()
                {
                    {nameAttribut, valueAttribut }
                });
            }
            else
            {
                ListAttributs.Add(nameColumn, new List<Dictionary<string, object>>()
                {
                    new Dictionary<string, object>()
                    {
                        {nameAttribut, valueAttribut }
                    }
                });
            }

            NotifyStateChanged();
        }

        public object GetAttribut(string columnName, string attribut)
        {
            if (ListAttributs == null)
            {
                return null;
            }

            if (!ListAttributs.ContainsKey(columnName))
            {
                return null;
            }

            return ListAttributs[columnName].Find(x => x.ContainsKey(attribut))?.Values.FirstOrDefault();
        }
    }
}
