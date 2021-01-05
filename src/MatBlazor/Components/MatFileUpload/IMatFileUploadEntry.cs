using System;
using System.IO;
using System.Threading.Tasks;

namespace MatBlazor
{
    public interface IMatFileUploadEntry
    {
        DateTime LastModified { get; }

        string Name { get; }

        long Size { get; }

        string Type { get; }
        Task WriteToStreamAsync(Stream stream);
    }
}