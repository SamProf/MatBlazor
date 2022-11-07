using System.Runtime.Serialization;

namespace ITMS.External.MatBlazor
{
    [DataContract]
    public class MatSelectInitOptions
    {
        [DataMember]
        public bool FullWidth { get; set; }
    }
}