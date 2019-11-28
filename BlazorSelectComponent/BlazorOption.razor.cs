using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlazorSelectComponent
{
    public class BlazorOptionBase : BlazorBaseComponent
    {
        [CascadingParameter()]
        public BlazorSelectBase Parent { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string Value { get; set; }

        public void ClickInput()
        {
            if (Parent.Value.SingleOrDefault(r => r == Value) != null)
            {
                Parent.Value.Remove(Value);
            }
            else
            {
                Parent.Value.Add(Value);
            }
            Parent.Ariel();
        }
    }
}
