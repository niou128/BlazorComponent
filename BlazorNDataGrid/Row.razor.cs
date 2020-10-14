using BlazorDataGrid.Helpers;
using BlazorDataGrid.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BlazorDataGrid
{
    public partial class Row<TItem>
    {
        [Parameter]
        public IEnumerable<TItem> Items { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Content { get; set; }

        [CascadingParameter(Name = "BlazorDataTable")]
        protected BlazorDataGrid<TItem> BlazorDataTable { get; set; }

        [CascadingParameter(Name = "CurrentItem")]
        protected TItem CurrentItem { get; set; }

        protected override void OnInitialized()
        {
            var ariel = BlazorDataTable;
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
                foreach(var elt in typeof(TItem).GetProperties())
                {
                    if (elt.Name == match.Groups[2].Value)
                    {
                        if (elt.PropertyType == typeof(DateTime))
                        {
                            result = text.Replace(match.Groups[1].Value, DisplayHelper.DisplayDate(CurrentItem.GetType().GetProperty(elt.Name).GetValue(CurrentItem, null), Format(elt.Name), Culture(elt.Name)));
                        }
                        else
                        {
                            result = text.Replace(match.Groups[1].Value, CurrentItem.GetType().GetProperty(elt.Name).GetValue(CurrentItem, null).ToString());
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
    }
}
