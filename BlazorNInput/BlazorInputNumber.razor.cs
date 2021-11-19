using Microsoft.AspNetCore.Components;
using System.Text.RegularExpressions;

namespace BlazorNInput
{
    public partial class BlazorInputNumber : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> InputAttributes { get; set; }

        [Parameter]
        public EventCallback<int> ValueChanged { get; set; }

        [Parameter]
        public string ValidationPattern { get; set; }

        [Parameter]
        public string LabelError { get; set; } = "Le champ n'est pas correct";

        private int _value;
        protected int Value
        {
            get => _value;
            set
            {
                if (!string.IsNullOrEmpty(ValidationPattern))
                {
                    Validation(value.ToString(), ValidationPattern);
                }
                _value = value;
                //Placeholder = string.IsNullOrEmpty(value) ? "" : value;
                ValueChanged.InvokeAsync(Value);
            }
        }

        protected string StyleError { get; set; } = "display: none";

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
