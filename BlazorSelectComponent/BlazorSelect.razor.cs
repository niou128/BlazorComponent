using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorSelectComponent
{
    public class BlazorSelectBase : BlazorBaseComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Name { get; set; }

        public string Show { get; set; } = string.Empty;

        public void DropdownClick()
        {
            Show = string.IsNullOrEmpty(Show) ? "show" : string.Empty;
        }

        private List<string> _value;
        [Parameter]
        public List<string> Value
        {
            get => _value;
            set
            {
                if (value != _value)
                {
                    _value = value;
                    ValueChanged.InvokeAsync(value);
                    StateHasChanged();
                }
            }
        }

        [Parameter]
        public EventCallback<List<string>> ValueChanged { get; set; }

        public void Ariel()
        {
            ValueChanged.InvokeAsync(_value);
            StateHasChanged();
        }


        //private string _value;
        //[Parameter]
        //public string Value
        //{
        //    get => _value;
        //    set
        //    {
        //        if (value != _value)
        //        {
        //            _value = value;
        //            StateHasChanged();
        //            ValueChanged.InvokeAsync(value);
        //        }
        //    }
        //}

        //[Parameter]
        //public EventCallback<string> ValueChanged { get; set; }
    }

}
