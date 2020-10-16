using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BlazorNInput
{
    public class BlazorInputTextBase : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> InputAttributes { get; set; }

        [Parameter]
        public object Placeholder { get; set; }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        [Parameter]
        public bool ReadOnly { get; set; }

        [Parameter]
        public string LabelError { get; set; } = "Le champ n'est pas correct";

        [Parameter]
        public string ValidationPattern { get; set; }

        protected string StyleError { get; set; } = "display: none";

        private string _value;
        protected string Value
        {
            get => Placeholder?.ToString() ?? _value;
            set
           {
                if(!string.IsNullOrEmpty(ValidationPattern))
                {
                    Validation(value, ValidationPattern);
                }
                _value = value;
                Placeholder = string.IsNullOrEmpty(value) ? "" : value;
                ValueChanged.InvokeAsync(Value);
            }
        }

        public void Validation(string value, string pattern)
        {
            Match match = Regex.Match(value, pattern, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                StyleError = "display: block";
                StateHasChanged();
            }
            else
            {
                StyleError = "display: none";
                StateHasChanged();
            }
        }

    }
}
