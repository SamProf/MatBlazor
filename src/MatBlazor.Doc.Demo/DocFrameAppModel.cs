using MatBlazor.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatBlazor.Doc.Demo
{
    public class DocFrameAppModel : AppModel
    {
        public DocFrameAppModel()
            : base(typeof(IndexPage), new NavModel("My Library - Documentation"), false)
        {
        }
    }
}
