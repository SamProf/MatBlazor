using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor
{
    // This class streams data from JS within the existing API limits of IJSRuntime.
    // To produce good throughput, it prefetches up to buffer_size data from JS
    // even when the consumer isn't asking for that much data, and does so by making
    // N parallel requests in parallel (N ~= buffer_size / max_message_size).
    //
    // This should be understood as a TEMPORARY way to achieve the desired API and
    // reasonable performance. Longer term we can surely replace this with something
    // simpler and cleaner, either:
    //
    //  - Extending JS interop to allow streaming responses via SignalR's built-in
    //    binary streaming support. That should reduce all of this to triviality.
    //  - Or, failing that, at least use something like System.IO.Pipelines to manage
    //    the supply/consumption of byte data with less custom code.

    internal class MatBlazorRemoteStream : BaseMatBlazorStream
    {
//         private readonly int _maxMessageSize;
//         private readonly PreFetchingSequence<Block> _blockSequence;
//         private Block? _currentBlock;
//         private byte[] _currentBlockDecodingBuffer;
//         private int _currentBlockDecodingBufferConsumedLength;
//
//         public MatBlazorRemoteStream(IJSRuntime jsRuntime, ElementReference inputFileElement, MatFileUploadEntry entry,
//             int maxMessageSize, int maxBufferSize)
//             : base(jsRuntime, inputFileElement, entry)
//         {
//             _maxMessageSize = maxMessageSize;
//             _blockSequence = new PreFetchingSequence<Block>(
//                 FetchBase64Block,
//                 (entry.Size + _maxMessageSize - 1) / _maxMessageSize,
//                 Math.Max(1, maxBufferSize / _maxMessageSize)); // Degree of parallelism on fetch
//             _currentBlockDecodingBuffer = new byte[_maxMessageSize];
//         }
//
//         protected override async Task<int> CopyFileDataIntoBuffer(long sourceOffset, byte[] destination,
//             int destinationOffset, int maxBytes, CancellationToken cancellationToken)
//         {
//             var totalBytesCopied = 0;
//
//             while (maxBytes > 0)
//             {
//                 // If we don't yet have a block, or it's fully consumed, get the next one
//                 if (!_currentBlock.HasValue ||
//                     _currentBlockDecodingBufferConsumedLength == _currentBlock.Value.LengthBytes)
//                 {
//                     // If we've already read some data, and the next block is still pending,
//                     // then just return now rather than awaiting
//                     if (totalBytesCopied > 0
//                         && _blockSequence.TryPeekNext(out var nextBlock)
//                         && !nextBlock.Base64.IsCompleted)
//                     {
//                         break;
//                     }
//
//                     _currentBlock = _blockSequence.ReadNext(cancellationToken);
//                     var currentBlockBase64 = await _currentBlock.Value.Base64;
//
//                     // As a possible future optimisation, if we know the current block will fit entirely in
//                     // the remaining destination space, we could decode directly into the destination without
//                     // going via _currentBlockDecodingBuffer. However that complicates the logic a lot.
//                     DecodeBase64ToBuffer(currentBlockBase64, _currentBlockDecodingBuffer, 0,
//                         _currentBlock.Value.LengthBytes);
//                     _currentBlockDecodingBufferConsumedLength = 0;
//                 }
//
//                 // How much of the current block can we fit into the destination?
//                 var numUnconsumedBytesInBlock =
//                     _currentBlock.Value.LengthBytes - _currentBlockDecodingBufferConsumedLength;
//                 var numBytesToTransfer = Math.Min(numUnconsumedBytesInBlock, maxBytes);
//                 if (numBytesToTransfer == 0)
//                 {
//                     break;
//                 }
//
//                 // Perform the copy
//                 Array.Copy(_currentBlockDecodingBuffer, _currentBlockDecodingBufferConsumedLength, destination,
//                     destinationOffset, numBytesToTransfer);
//                 maxBytes -= numBytesToTransfer;
//                 destinationOffset += numBytesToTransfer;
//                 _currentBlockDecodingBufferConsumedLength += numBytesToTransfer;
//                 totalBytesCopied += numBytesToTransfer;
//             }
//
//             return totalBytesCopied;
//         }
//
//         private Block FetchBase64Block(long index, CancellationToken cancellationToken)
//         {
//             var sourceOffset = index * _maxMessageSize;
//             var blockLength = (int) Math.Min(_maxMessageSize, _entry.Size - sourceOffset);
//             var task = _jsRuntime.InvokeAsync<string>(
//                 "matBlazor.matFileUpload.readFileData",
//                 cancellationToken,
//                 _inputFileElement,
//                 _entry.Id,
//                 index * _maxMessageSize,
//                 blockLength).AsTask();
//             return new Block(task, blockLength);
//         }
//
//         private int DecodeBase64ToBuffer(string base64, byte[] buffer, int offset, int maxBytesToRead)
//         {
// #if NETSTANDARD2_1
//             var bufferWithOffset = new Span<byte>(buffer, offset, maxBytesToRead);
//             return Convert.TryFromBase64String(base64, bufferWithOffset, out var actualBytesRead)
//                 ? actualBytesRead
//                 : throw new InvalidOperationException("Failed to decode base64 data");
// #else
//             var bytes = Convert.FromBase64String(base64);
//             if (bytes.Length > maxBytesToRead)
//             {
//                 throw new InvalidOperationException($"Requested a maximum of {maxBytesToRead}, but received {bytes.Length}");
//             }
//             Array.Copy(bytes, 0, buffer, offset, bytes.Length);
//             return bytes.Length;
// #endif
//         }
//
//         private readonly struct Block
//         {
//             public readonly Task<string> Base64;
//             public readonly int LengthBytes;
//
//             public Block(Task<string> base64, int lengthBytes)
//             {
//                 Base64 = base64;
//                 LengthBytes = lengthBytes;
//             }
//         }
        public MatBlazorRemoteStream(IJSRuntime jsRuntime, ElementReference reference, MatFileUploadEntry entry)
            : base(jsRuntime, reference, entry)
        {
        }
        
        public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            var base64 = await _jsRuntime.InvokeAsync<string>("matBlazor.matFileUpload.readDataAsync",  _reference, _entry.Id, _position, count);
            var buffer2 = Convert.FromBase64String(base64);
            Array.Copy(buffer2, 0, buffer, offset, buffer2.Length);
            Seek(buffer2.Length, SeekOrigin.Current);
            return buffer2.Length;
        }
    }
}