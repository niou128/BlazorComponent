using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BlazorDataGrid
{
    public class BlazorDataGridBase : ComponentBase
    {
        [Parameter]
        public bool ShowPageSelector { get; set; } = true;

        [Parameter]
        public Dictionary<string, int> PageSelector { get; set; }

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
