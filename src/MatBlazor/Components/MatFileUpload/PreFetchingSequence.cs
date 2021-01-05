// using System;
// using System.Collections.Generic;
// using System.Threading;
//
// namespace MatBlazor
// {
//     internal class PreFetchingSequence<T>
//     {
//         private readonly Func<long, CancellationToken, T> _fetchCallback;
//         private readonly int _maxBufferCapacity;
//         private readonly long _totalFetchableItems;
//         private readonly Queue<T> _buffer;
//         private long _maxFetchedIndex;
//
//         public PreFetchingSequence(Func<long, CancellationToken, T> fetchCallback, long totalFetchableItems, int maxBufferCapacity)
//         {
//             _fetchCallback = fetchCallback;
//             _buffer = new Queue<T>();
//             _maxBufferCapacity = maxBufferCapacity;
//             _totalFetchableItems = totalFetchableItems;
//         }
//
//         public T ReadNext(CancellationToken cancellationToken)
//         {
//             EnqueueFetches(cancellationToken);
//             if (_buffer.Count == 0)
//             {
//                 throw new InvalidOperationException("There are no more entries to read");
//             }
//
//             var next = _buffer.Dequeue();
//             EnqueueFetches(cancellationToken);
//             return next;
//         }
//
//         public bool TryPeekNext(out T result)
//         {
//             if (_buffer.Count > 0)
//             {
//                 result = _buffer.Peek();
//                 return true;
//             }
//             else
//             {
//                 result = default;
//                 return false;
//             }
//         }
//
//         private void EnqueueFetches(CancellationToken cancellationToken)
//         {
//             while (_buffer.Count < _maxBufferCapacity && _maxFetchedIndex < _totalFetchableItems)
//             {
//                 _buffer.Enqueue(_fetchCallback(_maxFetchedIndex++, cancellationToken));
//             }
//         }
//     }
// }
