namespace MatBlazor.DevUtils
{
    public class Config
    {
        public static Config GetConfig()
        {
            return new Config();
        }


        public string Path
        {
            get { return System.IO.Path.GetFullPath(_path); }
        }

        private readonly string _path = "../../../..";

        public string RepositoryPath
        {
            get { return System.IO.Path.GetDirectoryName(Path); }
        }

        public string DemoContainerTag = "DemoContainer";
        public string ContentTag = "Content";
        public string SourceContentTag = "SourceContent";
        public string FileMask = "*.razor";
    }
}