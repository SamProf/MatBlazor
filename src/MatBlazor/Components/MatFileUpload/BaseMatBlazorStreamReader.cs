using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor
{
    // TODO: When ReadAsync is called, don't just fetch the segment of data that's being requested.
    // That will be very slow, as you may be doing a separate round-trip for each 1KB or so of data.
    // Instead, have a larger buffer whose size == SignalR.MaxMessageSize and populate that. Then
    // many of the ReadAsync calls can return immediately with already-loaded data.
    //
    // This is still not as fast as allowing the client to send as much data as it wants, and using
    // TCP to apply backpressure. In the future we could achieve something closer to that by having
    // an even larger buffer, and telling the client to send N messages in parallel. The ReadAsync
    // calls would return whenever their portion of the buffer was populated. This is much more
    // complicated to implement.

    public class BaseMatBlazorStreamReader
    {
        protected readonly IJSRuntime _jsRuntime;
        protected readonly ElementReference _reference;
        protected readonly MatFileUploadEntry _entry;
        protected readonly BaseMatFileUpload _component;

        public BaseMatBlazorStreamReader(IJSRuntime jsRuntime, ElementReference reference, MatFileUploadEntry entry,
            BaseMatFileUpload component)
        {
            _jsRuntime = jsRuntime;
            _reference = reference;
            _entry = entry;
            _component = component;
        }
    }
}