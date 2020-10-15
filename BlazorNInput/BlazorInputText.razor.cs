using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorNInput
{
    public class BlazorInputTextBase : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> InputAttributes { get; set; }

        [Parameter]
        public object Placeholder { get; set; }

        private string _value;
        protected string Value
        {
            get => Placeholder?.ToString() ?? _value;
            set
            {
                _value = value;
                Placeholder = string.IsNullOrEmpty(value) ? "" : value;
                ValueChanged.InvokeAsync(Value);
            }
        }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        protected override void OnParametersSet()
        {
            //base.OnParametersSet();

            //Value = Placeholder?.ToString();
        }
    }
}
