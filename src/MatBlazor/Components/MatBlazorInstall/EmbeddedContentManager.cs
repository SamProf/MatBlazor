using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MatBlazor
{
    public class EmbeddedContentManager
    {
        public static EmbeddedContentManager Instance = new EmbeddedContentManager();


        private Dictionary<Assembly, Dictionary<string, EmbeddedContentItem>> dic =
            new Dictionary<Assembly, Dictionary<string, EmbeddedContentItem>>();

        private object syncObj = new object();


        public IEnumerable<EmbeddedContentItem> GetItems(Assembly assembly)
        {
            lock (syncObj)
            {
                Dictionary<string, EmbeddedContentItem> value = null;
                if (!dic.TryGetValue(assembly, out value))
                {
                    value = new Dictionary<string, EmbeddedContentItem>();
                    foreach (var resourceName in assembly.GetManifestResourceNames())
                    {
                        EmbeddedContentItemType contentItemType = EmbeddedContentItemType.None;
                        var ext = Path.GetExtension(resourceName).ToUpper();
                        switch (ext)
                        {
                            case ".JS":
                            {
                                contentItemType = EmbeddedContentItemType.Js;
                                break;
                            }
                            case ".CSS":
                            {
                                contentItemType = EmbeddedContentItemType.Css;
                                break;
                            }
                        }

                        if (contentItemType != EmbeddedContentItemType.None)
                        {
                            using (var stream = assembly.GetManifestResourceStream(resourceName))
                            {
                                using (var streamReader = new StreamReader(stream))
                                {
                                    var content = streamReader.ReadToEnd();

                                    value.Add(resourceName, new EmbeddedContentItem()
                                    {
                                        Name = resourceName,
                                        Type = contentItemType,
                                        Content = content,
                                    });
                                }
                            }
                        }
                    }
                    dic.Add(assembly, value);
                }

                return value.Values.ToArray();
            }
        }
    }
}