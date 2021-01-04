using System;
using System.IO;
using System.Threading.Tasks;

namespace MatBlazor
{
    public class MatFileUploadEntry : IMatFileUploadEntry
    {
        private BaseMatFileUpload Owner { get; set; }
        
        public async Task WriteToStreamAsync(Stream stream)
        {
            await Owner.WriteToStreamAsync(this, stream);
        }

        
        // public event EventHandler OnDataRead;

        public int Id { get; set; }

        public DateTime LastModified { get; set; }

        public string Name { get; set; }

        public long Size { get; set; }

        public string Type { get; set; }


        // internal void RaiseOnDataRead()
        // {
        //     OnDataRead?.Invoke(this, null);
        // }

        public void Init(BaseMatFileUpload fileUpload)
        {
            Owner = fileUpload;
        }
    }
}