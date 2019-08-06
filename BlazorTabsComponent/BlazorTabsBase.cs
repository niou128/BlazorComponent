using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace BlazorTabsComponent
{
    public class BlazorTabsBase : ComponentBase
    {
        public string BlazorRocksText { get; set; } =
            "Blazor rocks the browser!";
    }
}
