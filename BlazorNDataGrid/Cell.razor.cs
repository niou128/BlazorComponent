using BlazorDataGrid.Helpers;
using BlazorDataGrid.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorDataGrid
{
    public partial class Cell<TItem>
    {
        [Inject]
        IJSRuntime JSRuntime { get; set; }

        [Parameter]
        public IEnumerable<TItem> Items { get; set; }

        private RenderFragment<TItem> childContent;
        [Parameter]
        public RenderFragment<TItem> ChildContent
        {
            get => childContent;
            set
            {
                childContent = value;
                if (value != null)
                {
                    Content = null;
                }
            }
        }

        [Parameter]
        public string Content { get; set; }

        [Parameter]
        public string ValidationPattern { get; set; }

        [Parameter]
        public string LabelError { get; set; } = "error";

        [CascadingParameter(Name = "BlazorDataTable")]
        protected BlazorDataGrid<TItem> BlazorDataTable { get; set; }

        [CascadingParameter(Name = "CurrentItem")]
        protected TItem CurrentItem { get; set; }

        public string NameItem { get; set; }

        protected string Id { get; set; }

        protected int RowNumber { get; set; } = 0;

        private Task<IJSObjectReference> _module;

        const string ImportPath = "./_content/BlazorDataGrid/tools.js";
        private Task<IJSObjectReference> Module => _module ??= JSRuntime.InvokeAsync<IJSObjectReference>("import", ImportPath).AsTask();

        protected override void OnInitialized()
        {
            Id = $"cell-{AppState.IdCell++}";

            if (Content != null)
            {
                const string pattern = ".*({{(.*)}}).*";
                Match match = Regex.Match(Content, pattern, RegexOptions.IgnoreCase);
                if (match.Success)
                {
                    foreach (var elt in typeof(TItem).GetProperties())
                    {
                        if (elt.Name == match.Groups[2].Value)
                        {
                            NameItem = elt.Name;
                        }
                    }
                }
            }
            AppState.RefreshCell += async () => await UpdateCell();
        }

        public string ConvertParamToValue(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            string result = text;
            const string pattern = ".*({{(.*)}}).*";
            Match match = Regex.Match(text, pattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                foreach (var elt in typeof(TItem).GetProperties())
                {
                    if (elt.Name == match.Groups[2].Value)
                    {
                        NameItem = elt.Name;
                        if (elt.PropertyType == typeof(DateTime))
                        {
                            result = text.Replace(match.Groups[1].Value, DisplayHelper.DisplayDate(CurrentItem.GetType().GetProperty(elt.Name).GetValue(CurrentItem, null), Format(elt.Name), Culture(elt.Name)));
                        }
                        else
                        {
                            result = text.Replace(match.Groups[1].Value, CurrentItem.GetType().GetProperty(elt.Name).GetValue(CurrentItem, null)?.ToString());
                        }
                    }
                }
            }

            return result;
        }

        public string Culture(string colunmName)
        {
            var attributValue = AppState.GetAttribut(colunmName, "Culture");

            return (string)attributValue;
        }

        public string Format(string colunmName)
        {
            var attributValue = AppState.GetAttribut(colunmName, "Format");

            return (string)attributValue;
        }

        public bool ReadOnly(string colunmName, string attribut)
        {
            var attributValue = AppState.GetAttribut(colunmName, attribut);
            if (attributValue == null)
            {
                return false;
            }
            else
            {
                try
                {
                    return (bool)attributValue;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public string InputValue
        {
            get => CurrentItem.GetType().GetProperty(NameItem).GetValue(CurrentItem, null)?.ToString();
            set
            {
                BlazorDataTable.ContentEditableText = value;
                if (string.IsNullOrEmpty(value))
                {
                    PlaceHolderValue = "";
                }
                else
                {
                    PlaceHolderValue = value;
                }
                Items = BlazorDataTable.Items;
                StateHasChanged();
            }
        }

        private string _placeHolderValue;
        public string PlaceHolderValue
        {
            get => _placeHolderValue ?? CurrentItem.GetType().GetProperty(NameItem).GetValue(CurrentItem, null)?.ToString();
            set
            {
                _placeHolderValue = value;
                StateHasChanged();
            }
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            PlaceHolderValue = null;
        }

        public async Task UpdateCell()
        {
            if (ChildContent != null)
            {
                try
                {
                    string ariel = null;
                    var module = await Module;
                    ariel = await module.InvokeAsync<string>("GetHtmlFromId", Id);
                    Content = ConvertParamToValue(ariel);
                    StateHasChanged();
                }
                catch (Exception)
                {
                    Debug.WriteLine("Echec de récupération du contenu HTML");
                }
            }
        }
    }
}
