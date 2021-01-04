using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MatBlazor
{
    public class BaseMatFileUpload : BaseMatDomComponent
    {
        protected ElementReference InputRef;

        [Parameter]
        public EventCallback<IMatFileUploadEntry[]> OnChange { get; set; }

        [Parameter]
        public bool AllowMultiple { get; set; } = false; 

        [Parameter]
        public string Label { get; set; } = "Drop files here or Browse";

        [Parameter]
        public int MaxMessageSize { get; set; } = 20 * 1024; // TODO: Use SignalR default

        [Parameter]
        public int MaxMessageLength { get; set; } = 3;

        private readonly MatDotNetObjectReference<BaseMatFileUpload> jsHelper;


        protected long ProgressProgress;
        protected long ProgressBuffer;
        protected long ProgressTotal;
        protected double Progress;


        public async Task UpdateProgressAsync(long progressProgress, long progressBuffer, long progressTotal)
        {
            // return;
            await InvokeAsync(() =>
            {
                ProgressProgress += progressProgress;
                ProgressBuffer += progressBuffer;
                ProgressTotal += progressTotal;
                var progress = Math.Round((double) ProgressProgress / ProgressTotal, 3);
                if (Math.Abs(progress - Progress) > double.Epsilon)
                {
                    // Console.WriteLine($"Progress\t{progress}\t{ProgressProgress}\t{ProgressBuffer}\t{ProgressTotal}");
                    Progress = progress;
                    this.StateHasChanged();
                }
            });
        }

        public BaseMatFileUpload()
        {
            ClassMapper
                .Add("mat-file-upload")
                .Add("mdc-ripple-surface");
            jsHelper = new MatDotNetObjectReference<BaseMatFileUpload>(this, false);
        }


        [JSInvokable]
        public Task NotifyChange(MatFileUploadEntry[] files)
        {
            foreach (var file in files)
            {
                file.Init(this);
            }

            return OnChange.InvokeAsync(files);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Js.InvokeAsync<object>("matBlazor.matFileUpload.init", Ref, InputRef, jsHelper.Reference);
            }
        }

        // internal async Task<Stream> ReadAsStreamAsync(MatFileUploadEntry entry)
        // {
        //     // SharedMemoryMatBlazorStream.IsSupported(Js)
        //     // ? (BaseMatBlazorStream)new SharedMemoryMatBlazorStream(Js, InputRef, entry)
        //     
        // }

        public override void Dispose()
        {
            base.Dispose();
            jsHelper?.Dispose();
        }

        public async Task WriteToStreamAsync(MatFileUploadEntry matFileUploadEntry, Stream stream)
        {
            await new MatBlazorRemoteStreamReader(Js, Ref, matFileUploadEntry, MaxMessageSize, MaxMessageLength, this)
                .WriteToStreamAsync(stream, CancellationToken.None);
        }
    }
}