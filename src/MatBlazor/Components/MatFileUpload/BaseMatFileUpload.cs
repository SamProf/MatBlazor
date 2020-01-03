using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor
{
    public class BaseMatFileUpload : BaseMatDomComponent
    {
        protected ElementReference InputRef;

        [Parameter]
        public EventCallback<IMatFileUploadEntry[]> OnChange { get; set; }

        [Parameter]
        public string Label { get; set; } = "Drop files here or Browse";

        [Parameter]
        public int MaxMessageSize { get; set; } = 20 * 1024; // TODO: Use SignalR default

        [Parameter]
        public int MaxBufferSize { get; set; } = 1024 * 1024;


        MatDotNetObjectReference<BaseMatFileUpload> jsHelper;

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

        public async Task<Stream> ReadAsStreamAsync(MatFileUploadEntry matFileUploadEntry)
        {
            return new MatBlazorRemoteStream(Js, Ref, matFileUploadEntry);
        }
    }
}