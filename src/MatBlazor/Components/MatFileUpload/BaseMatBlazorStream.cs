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

    public class BaseMatBlazorStream : Stream
    {
        protected readonly IJSRuntime _jsRuntime;
        protected readonly ElementReference _reference;
        protected readonly MatFileUploadEntry _entry;
        protected long _position;


        public BaseMatBlazorStream(IJSRuntime jsRuntime, ElementReference reference, MatFileUploadEntry entry)
        {
            _jsRuntime = jsRuntime;
            _reference = reference;
            _entry = entry;
            _position = 0;
        }

        //
        // public long Length => MatFileUpload.Size;
        // public long Position { private set; get; }
        //
        //
        // public async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        // {
        //     var maxBytesToRead = (int) Math.Min(count, Length - Position);
        //     if (maxBytesToRead == 0)
        //     {
        //         return 0;
        //     }
        //
        //     var actualBytesRead =
        //         await CopyFileDataIntoBuffer(Position, buffer, offset, maxBytesToRead, cancellationToken);
        //     Position += actualBytesRead;
        //     MatFileUpload.RaiseOnDataRead();
        //     return actualBytesRead;
        // }
        //
        // protected abstract Task<int> CopyFileDataIntoBuffer(long sourceOffset, byte[] destination,
        //     int destinationOffset, int maxBytes, CancellationToken cancellationToken);
        //
        // public async Task CopyToStreamAsync(Stream stream)
        // {
        //     var buffer = new byte[MatFileUpload.Owner.MaxBufferSize];
        //     while (true)
        //     {
        //         var readed = await this.ReadAsync(buffer, 0, buffer.Length, CancellationToken.None);
        //         if (readed == 0)
        //         {
        //             break;
        //         }
        //
        //         await stream.WriteAsync(buffer, 0, readed);
        //     }
        // }
        public override void Flush()
        {
            throw new NotImplementedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            // return ReadAsync(buffer, offset, count).Result;
            throw new NotSupportedException("Synchronous reads are not supported");
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    _position = offset;
                    break;
                case SeekOrigin.Current:
                    _position = _position + offset;
                    break;
                case SeekOrigin.End:
                    _position = _entry.Size + offset;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(origin), origin, null);
            }

            return _position;
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override bool CanRead => true;

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length => _entry.Size;

        public override long Position
        {
            get => _position;
            set => _position = value;
        }
    }
}