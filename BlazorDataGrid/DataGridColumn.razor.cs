using Microsoft.AspNetCore.Components;
using System;
using System.Threading;

namespace BlazorDataGrid
{
    public class BlazorGridColumnBase : ComponentBase
    {

        private Timer DebounceTimerInterval { get; set; }
        private Action<object> DebounceAction { get; set; }
        private object LastObjectDebounced { get; set; }

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
