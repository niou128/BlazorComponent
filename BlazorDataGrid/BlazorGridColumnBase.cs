using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorDataGrid
{
    public class BlazorGridColumnBase : ComponentBase
    {
        Timer DebounceTimerInterval { get; set; }
        Action<object> DebounceAction { get; set; }
        object LastObjectDebounced { get; set; }

        protected void Debounce(object obj, int interval, Action<object> debounceAction)
        {
            LastObjectDebounced = obj;
            DebounceAction = debounceAction;

            DebounceTimerInterval?.Dispose();

            DebounceTimerInterval = new Timer(DebounceTimerIntervalOnTick, obj, interval, interval);
        }

        protected void DebounceTimerIntervalOnTick(object state)
        {
            DebounceTimerInterval?.Dispose();

            if (DebounceTimerInterval != null)
            {
                DebounceAction?.Invoke(LastObjectDebounced);
            }

            DebounceTimerInterval = null;
        }
    }
}
