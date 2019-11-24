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
        [Parameter]
        public EventCallback<IMatFileEntry[]> OnChange { get; set; }

        [Parameter]
        public int MaxMessageSize { get; set; } = 20 * 1024; // TODO: Use SignalR default

        [Parameter]
        public int MaxBufferSize { get; set; } = 1024 * 1024;


        MatDotNetObjectReference<BaseMatFileUpload> jsHelper;

        public BaseMatFileUpload()
        {
            jsHelper = new MatDotNetObjectReference<BaseMatFileUpload>(this, false);
        }


        [JSInvokable]
        public Task NotifyChange(MatFileEntryImpl[] files)
        {
            foreach (var file in files)
            {
                // So that method invocations on the file can be dispatched back here
                file.Owner = (BaseMatFileUpload) (object) this;
            }

            return OnChange.InvokeAsync(files);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Js.InvokeAsync<object>("matBlazor.matFileUpload.init", Ref, jsHelper.Reference);
            }
        }

        internal Stream OpenFileStream(MatFileEntryImpl matFile)
        {
            return SharedMemoryFileListEntryStream.IsSupported(Js)
                ? (Stream) new SharedMemoryFileListEntryStream(Js, Ref, matFile)
                : new RemoteFileListEntryStream(Js, Ref, matFile, MaxMessageSize, MaxBufferSize);
        }

        public override void Dispose()
        {
            base.Dispose();
            jsHelper?.Dispose();
        }
    }
}