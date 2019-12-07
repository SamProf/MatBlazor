using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace MatBlazor
{
    public class StyleMapper : BaseMapper
    {
        public string AsString()
        {
            return string.Join("; ", Items.Select(i => i()).Where(i => i != null));
        }


        public override string ToString()
        {
            return AsString();
        }
    }
}