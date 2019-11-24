using System;
using System.IO;

namespace MatBlazor
{
    public interface IMatFileEntry
    {
        DateTime LastModified { get; }

        string Name { get; }

        long Size { get; }

        string Type { get; }

        Stream Data { get; }

        event EventHandler OnDataRead;
    }
}
