using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDataGrid
{
    public class BlazorDataGridBase : ComponentBase
    {       
        [Parameter]
        public bool ShowPageSelector { get; set; } = true;

        protected List<PageSizeStruct> PageSizeList { get; set; }

        public class PageSizeStruct
        {
            public string Label { get; set; }
            public int Value { get; set; }
        }

        public enum Direction
        {
            First,
            Previous,
            Next,
            PreviousSegment,
            NextSegment,
            Last
        }
    }
}
