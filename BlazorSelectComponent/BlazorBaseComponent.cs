using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSelectComponent
{
   public class BlazorBaseComponent : ComponentBase, IDisposable
    {
        [Parameter]
        public string Id { get; set; } = "_id_" + Guid.NewGuid();

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object> Attributes { get; set; }

        private ElementReference _ref;

        /// <summary>
        /// Returned ElementRef reference for DOM element.
        /// </summary>
        public virtual ElementReference Ref
        {
            get => _ref;
            set
            {
                _ref = value;
                RefBack?.Set(value);
            }
        }

        [Parameter]
        public ForwardRef RefBack { get; set; }

        [Inject]
        protected IJSRuntime Js { get; set; }

        protected async Task<T> JsInvokeAsync<T>(string code, params object[] args)
        {
            try
            {
                return await Js.InvokeAsync<T>(code, args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private Queue<Func<Task>> afterRenderCallQuene = new Queue<Func<Task>>();

        protected void CallAfterRender(Func<Task> action)
        {
            afterRenderCallQuene.Enqueue(action);
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await OnFirstAfterRenderAsync();
            }

            if (afterRenderCallQuene.Count > 0)
            {
                var actions = afterRenderCallQuene.ToArray();
                afterRenderCallQuene.Clear();

                foreach (var action in actions)
                {
                    if (Disposed)
                    {
                        return;
                    }

                    await action();
                }
            }
        }
        protected bool Disposed { get; private set; }

        public virtual void Dispose()
        {
            Disposed = true;
        }

        protected virtual Task OnFirstAfterRenderAsync()
        {
            return Task.CompletedTask;
        }
    }
}
