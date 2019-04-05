using System;
using System.Collections.Generic;
using System.Text;

namespace MatBlazor.DevUtils
{
    public class Config
    {
        public static Config GetConfig()
        {
            return new Config();
        }


        public string Path = "../../../..";

        public string RepositoryPath
        {
            get { return System.IO.Path.GetDirectoryName(System.IO.Path.GetFullPath(Path)); }
        }
        public string DemoContainerTag = "DemoContainer";
        public string ContentTag = "Content";
        public string SourceContentTag = "SourceContent";
        public string FileMask = "*.cshtml";
    }
}