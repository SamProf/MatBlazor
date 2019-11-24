using System;
using System.IO;
using System.Threading.Tasks;

namespace MatBlazor
{
    public static class FileListEntryExtensions
    {
        /// <summary>
        /// Reads the entire uploaded file into a <see cref="MemoryStream"/>. This will allocate
        /// however much memory is needed to hold the entire file, or will throw if the client
        /// tries to supply more than <paramref name="maxSizeBytes"/> bytes. Be careful not to
        /// let clients allocate too much memory on the server.
        /// </summary>
        /// <param name="matFileEntry">The <see cref="IMatFileEntry"/>.</param>
        /// <param name="maxSizeBytes">The maximum amount of data to accept.</param>
        public static async Task<MemoryStream> ReadAllAsync(this IMatFileEntry matFileEntry, int maxSizeBytes = 1024*1024)
        {
            if (matFileEntry is null)
            {
                throw new ArgumentNullException(nameof(matFileEntry));
            }

            // We can trust .Length to be correct (and can't change later) because the implementation
            // won't supply more bytes than this, even if the JS-side code would send more data.
            var sourceData = matFileEntry.Data;
            if (sourceData.Length > maxSizeBytes)
            {
                throw new ArgumentOutOfRangeException(nameof(matFileEntry), $"The maximum allowed size is {maxSizeBytes}, but the supplied file is of length {matFileEntry.Size}.");
            }

            var result = new MemoryStream();
            await sourceData.CopyToAsync(result);
            result.Seek(0, SeekOrigin.Begin);
            return result;
        }
    }
}
