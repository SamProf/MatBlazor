using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITMS.External.MatBlazor
{
    public class MatDialogService : IMatDialogService
    {
        private IMatPortalService PortalService { get; }

        public MatDialogService(IMatPortalService portalService)
        {
            PortalService = portalService;
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

            item.PortalReference = PortalService.Add(typeof(MatDialogServiceItem), new Dictionary<string, object>()
            {
                {"DialogReference", item}
            });


            return item.TaskCompletionSource.Task;
        }

        public async Task AlertAsync(string message)
        {
            await OpenAsync(typeof(MatDialogAlert), new MatDialogOptions()
            {
                Attributes = new Dictionary<string, object>()
                {
                    {nameof(MatDialogAlert.Message), message}
                }
            });
        }

        public async Task<bool> ConfirmAsync(string message)
        {
            var res = await OpenAsync(typeof(MatDialogConfirm), new MatDialogOptions()
            {
                Attributes = new Dictionary<string, object>()
                {
                    {nameof(MatDialogConfirm.Message), message}
                }
            }) as bool?;
            return res == true;
        }


        public async Task<T> AskAsync<T>(string message, IEnumerable<T> answers)
        {
            var res = await OpenAsync(typeof(MatDialogAsk), new MatDialogOptions()
            {
                Attributes = new Dictionary<string, object>()
                {
                    {nameof(MatDialogAsk.Message), message},
                    {nameof(MatDialogAsk.Answers), answers.Cast<object>()}
                }
            });
            return (T) res;
        }


        public async Task<string> PromptAsync(string message, string value)
        {
            var res = await OpenAsync(typeof(MatDialogPrompt), new MatDialogOptions()
            {
                Attributes = new Dictionary<string, object>()
                {
                    {nameof(MatDialogPrompt.Message), message},
                    {nameof(MatDialogPrompt.Value), value}
                }
            });
            return (string) res;
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

        public MatPortalReference PortalReference { get; set; }
        public bool IsOpen { get; set; }
        public Type ComponentType { get; set; }
        public MatDialogOptions Options { get; set; }
        public TaskCompletionSource<object> TaskCompletionSource { get; set; }

        public void Close(object result)
        {
            IsOpen = false;
            TaskCompletionSource.TrySetResult(result);
            PortalReference.Service.Remove(PortalReference);
        }
    }


    public interface IMatDialogService
    {
        Task<object> OpenAsync(Type componentType, MatDialogOptions options);

        Task AlertAsync(string message);

        Task<bool> ConfirmAsync(string message);

        Task<T> AskAsync<T>(string message, IEnumerable<T> answers);
        Task<string> PromptAsync(string message, string value = null);
    }
}