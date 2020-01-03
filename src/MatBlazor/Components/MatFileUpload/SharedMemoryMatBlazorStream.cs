// using System;
// using System.Reflection;
// using System.Runtime.InteropServices;
// using System.Threading;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Components;
// using Microsoft.JSInterop;
//
// namespace MatBlazor
// {
//     // This is used on WebAssembly
//     internal class SharedMemoryMatBlazorStream : BaseMatBlazorStream
//     {
//         private readonly static Type MonoWebAssemblyJSRuntimeType
//             = Type.GetType("Mono.WebAssembly.Interop.MonoWebAssemblyJSRuntime, Mono.WebAssembly.Interop");
//
//         private static MethodInfo _cachedInvokeUnmarshalledMethodInfo;
//
//         public SharedMemoryMatBlazorStream(IJSRuntime jsRuntime, ElementReference inputFileElement,
//             MatFileUploadEntry entry)
//             : base(jsRuntime, inputFileElement, entry)
//         {
//         }
//
//         public static bool IsSupported(IJSRuntime jsRuntime)
//         {
//             return MonoWebAssemblyJSRuntimeType != null
//                    && MonoWebAssemblyJSRuntimeType.IsAssignableFrom(jsRuntime.GetType());
//         }
//
//         protected override async Task<int> CopyFileDataIntoBuffer(long sourceOffset, byte[] destination,
//             int destinationOffset, int maxBytes, CancellationToken cancellationToken)
//         {
//             await _jsRuntime.InvokeAsync<string>(
//                 "matBlazor.matFileUpload.ensureArrayBufferReadyForSharedMemoryInterop",
//                 cancellationToken,
//                 _inputFileElement,
//                 _entry.Id);
//
//             var methodInfo = GetCachedInvokeUnmarshalledMethodInfo();
//             return (int) methodInfo.Invoke(_jsRuntime, new object[]
//             {
//                 "matBlazor.matFileUpload.readFileDataSharedMemory",
//                 new ReadRequest
//                 {
//                     InputFileElementReferenceId = _inputFileElement.Id,
//                     FileId = _entry.Id,
//                     SourceOffset = sourceOffset,
//                     Destination = destination,
//                     DestinationOffset = destinationOffset,
//                     MaxBytes = maxBytes,
//                 }
//             });
//         }
//
//         private static MethodInfo GetCachedInvokeUnmarshalledMethodInfo()
//         {
//             if (_cachedInvokeUnmarshalledMethodInfo == null)
//             {
//                 foreach (var possibleMethodInfo in MonoWebAssemblyJSRuntimeType.GetMethods())
//                 {
//                     if (possibleMethodInfo.Name == "InvokeUnmarshalled" &&
//                         possibleMethodInfo.GetParameters().Length == 2)
//                     {
//                         _cachedInvokeUnmarshalledMethodInfo = possibleMethodInfo
//                             .MakeGenericMethod(typeof(ReadRequest), typeof(int));
//                         break;
//                     }
//                 }
//
//                 if (_cachedInvokeUnmarshalledMethodInfo == null)
//                 {
//                     throw new InvalidOperationException("Could not find the 2-param overload of InvokeUnmarshalled");
//                 }
//             }
//
//             return _cachedInvokeUnmarshalledMethodInfo;
//         }
//
//         [StructLayout(LayoutKind.Explicit)]
//         struct ReadRequest
//         {
//             [FieldOffset(0)] public string InputFileElementReferenceId;
//             [FieldOffset(4)] public int FileId;
//             [FieldOffset(8)] public long SourceOffset;
//             [FieldOffset(16)] public byte[] Destination;
//             [FieldOffset(20)] public int DestinationOffset;
//             [FieldOffset(24)] public int MaxBytes;
//         }
//     }
// }