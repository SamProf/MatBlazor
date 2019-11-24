using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
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

    public abstract class FileListEntryStream : Stream
    {
        protected readonly IJSRuntime _jsRuntime;
        protected readonly ElementReference _inputFileElement;
        protected readonly MatFileEntryImpl MatFile;
        private long _position;

        public FileListEntryStream(IJSRuntime jsRuntime, ElementReference inputFileElement, MatFileEntryImpl matFile)
        {
            _jsRuntime = jsRuntime;
            _inputFileElement = inputFileElement;
            MatFile = matFile;
        }

        public override bool CanRead => true;

        public override bool CanSeek => false;

        public override bool CanWrite => false;

        public override long Length => MatFile.Size;

        public override long Position
        {
            get => _position;
            set => throw new NotSupportedException();
        }

        public override void Flush()
            => throw new NotSupportedException();

        public override int Read(byte[] buffer, int offset, int count)
            => throw new NotSupportedException("Synchronous reads are not supported");

        public override long Seek(long offset, SeekOrigin origin)
            => throw new NotSupportedException();

        public override void SetLength(long value)
            => throw new NotSupportedException();

        public override void Write(byte[] buffer, int offset, int count)
            => throw new NotSupportedException();

        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            var maxBytesToRead = (int)Math.Min(count, Length - Position);
            if (maxBytesToRead == 0)
            {
                return 0;
            }

            var actualBytesRead = await CopyFileDataIntoBuffer(_position, buffer, offset, maxBytesToRead, cancellationToken);
            _position += actualBytesRead;
            MatFile.RaiseOnDataRead();
            return actualBytesRead;
        }

        protected abstract Task<int> CopyFileDataIntoBuffer(long sourceOffset, byte[] destination, int destinationOffset, int maxBytes, CancellationToken cancellationToken);
    }
}
