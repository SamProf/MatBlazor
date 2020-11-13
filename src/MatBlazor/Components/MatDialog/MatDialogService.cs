using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class MatDialogService : IMatDialogService
    {
        private List<MatDialogReference> items = new List<MatDialogReference>();

        public IEnumerable<MatDialogReference> Items
        {
            get { return items; }
        }

        public void StateHasChanged()
        {
            OnItemsChanged(items);
        }

        public event EventHandler<IEnumerable<MatDialogReference>> ItemsChanged;

        //private object LockObj = new object();
        private int ItemCounter = 1;

        public Task<object> OpenAsync(Type componentType, MatDialogOptions options)
        {
            var attributes = new Dictionary<string, object>(options?.Attributes ?? new Dictionary<string, object>());
            var item = new MatDialogReference()
            {
                Service = this,
                Id = ++ItemCounter,
                ComponentType = componentType,
                Options = options,
                IsOpen = true,
                TaskCompletionSource = new TaskCompletionSource<object>(),
                Attributes = attributes,
            };

            attributes["DialogReference"] = item;

            items.Add(item);
            this.StateHasChanged();
            return item.TaskCompletionSource.Task;
        }

        protected virtual void OnItemsChanged(IEnumerable<MatDialogReference> e)
        {
            ItemsChanged?.Invoke(this, e);
        }
    }


    public class MatDialogOptions
    {
        public bool CanBeClosed { get; set; } = BaseMatDialog.CanBeClosedDefault;

        public string SurfaceStyle { get; set; }
        
        public string SurfaceClass { get; set; }
        public Dictionary<string, object> Attributes { get; set; }
    }

    public class MatDialogReference
    {
        public MatDialogService Service { get; set; }
        public int Id { get; set; }
        public bool IsOpen { get; set; }
        public Type ComponentType { get; set; }

        public MatDialogOptions Options { get; set; }
        public TaskCompletionSource<object> TaskCompletionSource { get; set; }

        public Dictionary<string, object> Attributes { get; set; }


        public void Close(object result)
        {
            IsOpen = false;
            TaskCompletionSource.TrySetResult(result);
            this.Service.StateHasChanged();
        }
    }


    public interface IMatDialogService
    {
        IEnumerable<MatDialogReference> Items { get; }

        void StateHasChanged();

        event EventHandler<IEnumerable<MatDialogReference>> ItemsChanged;
        Task<object> OpenAsync(Type componentType, MatDialogOptions options);
    }
}