namespace MatBlazor
{
    public class EmbeddedContentItem
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public EmbeddedContentItemType Type { get; set; }

        public string Html
        {
            get
            {
                switch (Type)
                {
                    case EmbeddedContentItemType.None:
                        break;
                    case EmbeddedContentItemType.Css:
                        return $"<style>{Content}</style>";
                        break;
                    case EmbeddedContentItemType.Js:
                        return $"<script>{Content}</script>";
                        break;
                    default:
                        return "";
                }

                return "";
            }
        }
    }
}