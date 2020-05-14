using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorDataGrid.Tools
{
    public partial class BlazorInputText
    {
        [Parameter]
        public object Placeholder { get; set; }

        private string oldinput;

        private string _input;
        [Parameter]
        public string Input
        {
            get => _input;
            set
            {
                oldinput = _input;
                _input = value;
                if (secondpass && oldinput != _input && _input != null)
                {
                    InputChanged.InvokeAsync(_input);
                }
            }
        }

        [Parameter]
        public EventCallback<string> InputChanged { get; set; }

        [Parameter]
        public bool ReadOnly { get; set; }

        [Parameter]
        public bool DisplayLabelError
        {
            get => DisplayLabelError;
            set
            {
                DisplayLabelError = value;
                StyleError = "display: block";
            }
        }

        [Parameter]
        public object InputObject { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> InputAttributes { get; set; }

        [Parameter]
        public string LabelError { get; set; }

        private bool secondpass = false;

        protected string StyleError { get; set; } = "display: none";

        private Task OnInputChanged(ChangeEventArgs e)
        {
            Input = e.Value.ToString();

            return InputChanged.InvokeAsync(Input);
        }

        private void OnchangedEvent(ChangeEventArgs e)
        {
            try
            {
                var ariel = e.Value;
                Type type = InputType;
                if (type != typeof(string) && string.IsNullOrEmpty(e.Value.ToString()))
                {
                    ariel = null;
                }
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>) && ariel != null)
                {
                    type = Nullable.GetUnderlyingType(type);
                    Convert.ChangeType(ariel, type);
                }
                else if (type.IsGenericType && type.GetGenericTypeDefinition() != typeof(Nullable<>) && ariel != null)
                {
                    Convert.ChangeType(ariel, type);
                }
                else if (type.IsGenericType && type.GetGenericTypeDefinition() != typeof(Nullable<>) && ariel == null)
                {
                    StyleError = "display: block";
                }

                StyleError = "display: none";
            }
            catch (Exception)
            {
                if (string.IsNullOrEmpty(e.Value.ToString()))
                {
                    StyleError = "display: none";
                }
                else
                {
                    StyleError = "display: block";
                }
            }
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            Input = Placeholder?.ToString();
            secondpass = true;
        }

        [Parameter]
        public Type InputType { get; set; }
    }
}
