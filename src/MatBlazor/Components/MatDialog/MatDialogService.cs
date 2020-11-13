using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using MatBlazor.Components.MatDialog;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class MatDialogService : IMatDialogService
    {
        private readonly IMatPortalService _portalService;

        public MatDialogService(IMatPortalService portalService)
        {
            _portalService = portalService;
        }

        public Task<object> OpenAsync(Type componentType, MatDialogOptions options)
        {
            var item = new MatDialogReference()
            {
                Service = this,
                ComponentType = componentType,
                Options = options,
                IsOpen = true,
                TaskCompletionSource = new TaskCompletionSource<object>(),                
            };
            
            _portalService.Add(typeof(MatDialogServiceItem), new Dictionary<string, object>()
            {
                {"DialogReference", item}
            });
            
           
            return item.TaskCompletionSource.Task;
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
        public bool IsOpen { get; set; }
        public Type ComponentType { get; set; }
        public MatDialogOptions Options { get; set; }
        public TaskCompletionSource<object> TaskCompletionSource { get; set; }
        
        public void Close(object result)
        {
            IsOpen = false;
            TaskCompletionSource.TrySetResult(result);
        }
    }


    public interface IMatDialogService
    {
        Task<object> OpenAsync(Type componentType, MatDialogOptions options);
    }
}