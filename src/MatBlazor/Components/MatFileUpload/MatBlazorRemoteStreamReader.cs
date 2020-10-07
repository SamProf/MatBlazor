using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace MatBlazor
{
    internal class MatBlazorRemoteStreamReader : BaseMatBlazorStreamReader
    {
        private readonly int _messageSize;
        private readonly int _messageLength;


        public MatBlazorRemoteStreamReader(IJSRuntime jsRuntime, ElementReference reference, MatFileUploadEntry entry,
            int messageSize, int messageLength, BaseMatFileUpload component)
            : base(jsRuntime, reference, entry, component)
        {
            _messageSize = messageSize;
            _messageLength = messageLength;
        }



       
        
        public Task WriteToStreamAsync(Stream stream, CancellationToken cancellationToken)
        {
          
            return Task.Run(async () =>
            {
                await _component.UpdateProgressAsync(0, 0, _entry.Size);
                var position = 0;
                long qPosition = 0;

                try
                {
                    var q = new Queue<ValueTask<string>>();

                    while (position < _entry.Size)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        while (q.Count < _messageLength && qPosition < _entry.Size)
                        {
                            cancellationToken.ThrowIfCancellationRequested();
                            var taskPosition = qPosition;
                            var taskSize = Math.Min(_messageSize, (_entry.Size - qPosition));
                            // Log2("Request "+taskPosition);
                            var task = _jsRuntime.InvokeAsync<string>("matBlazor.matFileUpload.readDataAsync", 
                                cancellationToken,
                                _reference,
                                _entry.Id, taskPosition, taskSize);
                            q.Enqueue(task);
                            qPosition += taskSize;
                            await _component.UpdateProgressAsync(0, taskSize, 0);
                        }

                        cancellationToken.ThrowIfCancellationRequested();

                        if (q.Count == 0)
                        {
                            continue;
                        }

                        
                        var task2 = q.Dequeue();


                        ThreadPool.GetAvailableThreads(out var q1, out var q2);
                        // Log2("Wait " + position+ " " + q1 +" " + q2);
                        var base64 = await task2.ConfigureAwait(true);
                        // Log2("Response " + position);Progress
                        var buffer2 = Convert.FromBase64String(base64);
                        await stream.WriteAsync(buffer2, cancellationToken);
                       position += buffer2.Length;
                        await _component.UpdateProgressAsync(buffer2.Length, 0, 0);
                    }
                }
                finally
                {
                    await _component.UpdateProgressAsync(-position, -qPosition, -_entry.Size);
                }
            });
        }
    }
}