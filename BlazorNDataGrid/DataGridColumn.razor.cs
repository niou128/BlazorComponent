using BlazorDataGrid.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDataGrid
{
    public partial class DataGridColumn<TableItem>
    {
        #region Parameters
        [Parameter]
        public string ColumnName { get; set; }
        [Parameter]
        public string DisplayColumnName { get; set; } = string.Empty;

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public bool Filter { get; set; } = false;

        [Parameter]
        public bool DropdownFilter { get; set; } = false;

        [Parameter]
        public IEnumerable<TableItem> Items { get; set; }

        private string _format;
        [Parameter]
        public string Format
        {
            get => _format;
            set
            {
                _format = value;
                AppState.SetListAttributs(ColumnName, "Format", value);
            }
        }

        [Parameter]
        public string Culture
        {
            set => AppState.SetListAttributs(ColumnName, "Culture", value);
        }

        [Parameter]
        public bool ReadOnly
        {
            set => AppState.SetListAttributs(ColumnName, "ReadOnly", value);
            
        }

        [CascadingParameter]
        BlazorDataGrid<TableItem> BlazorDataTable { get; set; }
        #endregion

        [Inject]
        public AppState AppState { get; set; }

        private Timer DebounceTimerInterval { get; set; }
        private Action<object> DebounceAction { get; set; }
        private object LastObjectDebounced { get; set; }

        protected override void OnInitialized()
        {
            Items ??= BlazorDataTable.Items;
        }

        protected void Debounce(object obj, int interval, Action<object> debounceAction)
        {
            LastObjectDebounced = obj;
            DebounceAction = debounceAction;

            DebounceTimerInterval?.Dispose();

            DebounceTimerInterval = new Timer(DebounceTimerIntervalOnTick, obj, interval, interval);
        }

        protected void DebounceTimerIntervalOnTick(object state)
        {
            DebounceTimerInterval?.Dispose();

            if (DebounceTimerInterval != null)
            {
                DebounceAction?.Invoke(LastObjectDebounced);
            }

            DebounceTimerInterval = null;
        }

        private bool IsSortedAscending;

        protected int DebounceMilliseconds { get; set; } = 800;

        private string PreviousValue { get; set; } = string.Empty;

        private string _selectedDropdownFilter;
        protected string SelectedDropdownFilter
        {
            get => _selectedDropdownFilter;
            set
            {
                _selectedDropdownFilter = value;
                Filtering(value, ColumnName, true);
            }
        }

        private void SortTable(string columnName)
        {
            if (columnName != BlazorDataTable.CurrentSortColumn)
            {
                BlazorDataTable.CurrentSortColumn = columnName;
                IsSortedAscending = true;
                BlazorDataTable.ChangeSorting = true;
                AppState.CallRequestRefresh();
            }
            else
            {
                BlazorDataTable.ChangeSorting = true;
                AppState.CallRequestRefresh();
                IsSortedAscending = !IsSortedAscending;
            }
        }

        private string GetSortStyle(string columnName)
        {
            if (BlazorDataTable.CurrentSortColumn != columnName)
            {
                return string.Empty;
            }
            if (IsSortedAscending)
            {
                return "oi-arrow-thick-top";
            }
            else
            {
                return "oi-arrow-thick-bottom";
            }
        }

        private void Filtering(string value, string columnName, bool fromlist = false)
        {
            BlazorDataTable.FilterDictionary[columnName] = value;

            if (fromlist || value.Length < PreviousValue.Length)
            {
                BlazorDataTable.Items = Items;
            }

            AppState.CallRequestRefresh();
            PreviousValue = value;
        }

        private List<string> CreateFilterList()
        {
            List<string> filterList = new List<string>();

            var properties = typeof(TableItem).GetProperties();
            if (Items != null)
            {
                foreach (var item in Items)
                {
                    foreach (var property in properties)
                    {
                        if (string.Equals(property.Name, ColumnName, StringComparison.OrdinalIgnoreCase))
                        {
                            if (!filterList.Any(x => x == property.GetValue(item, null).ToString()))
                            {
                                filterList.Add(property.GetValue(item, null).ToString());
                            }
                        }
                    }
                }
            }
            filterList.Sort();
            return filterList;
        }

        private void OnInput(ChangeEventArgs eventArgs)
        {
            var filterValue = eventArgs.Value?.ToString();
            Debounce(eventArgs, DebounceMilliseconds, async (_) =>
            {
                await InvokeAsync(async () =>
                {
                    await Task.Delay(1);
                    Filtering(filterValue, ColumnName);
                }).ConfigureAwait(false);
            });
        }
    }
}
