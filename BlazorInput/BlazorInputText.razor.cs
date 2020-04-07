using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorInput
{
    public partial class BlazorInputText
    {
        [Parameter]
        public object Placeholder { get; set; }

        [Parameter]
        public string Input { get; set; }

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
        public object CurrentObject { get; set; }

        [Parameter]
        public string ObjectName { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> InputAttributes { get; set; }

        protected string LabelError { get; set; }

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
                Type type = CurrentObject.GetType().GetProperty(ObjectName).PropertyType;
                var elsa = Convert.ChangeType(ariel, type);
                StyleError = "display: none";
            }
            catch(Exception ex)
            {
                LabelError = "Format non valide";
                StyleError = "display: block";
            }
        }

        private void OnInputFocusOut()
        {
            //Type type = CurrentObject.GetType();
            //var elsa = Convert.ChangeType(Input, type);
            //LabelError = "Une petite erreur";
            //StyleError = "display: block";
        }
    }
}
