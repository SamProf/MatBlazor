using System.Runtime.Serialization;

namespace MatBlazor
{
    [DataContract]
    public class MatSelectInitOptions
    {
        [DataMember]
        public bool FullWidth { get; set; }
    }
}