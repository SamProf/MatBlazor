using System;
using System.Globalization;
using System.Text;

namespace MatBlazor
{
    public class MatTheme
    {
        public string Id { get; private set; } = IdGeneratorHelper.Generate("matBlazor_theme_");

        public string Primary { get; set; }
        public string Secondary { get; set; }

        public string GetClass()
        {
            return Id;
        }


        public event EventHandler<EventArgs> Changed;


        public void ThemeHasChanged()
        {
            OnChanged();
        }


        protected virtual void GenerateStyle(StringBuilder sb)
        {
            if (!string.IsNullOrEmpty(Primary))
            {
                sb.AppendLine($"--mdc-theme-primary: {Primary};");
            }

            if (!string.IsNullOrEmpty(Secondary))
            {
                sb.AppendLine($"--mdc-theme-secondary: {Secondary};");
            }
        }

        public string GetStyle()
        {
            var sb = new StringBuilder();
            GenerateStyle(sb);
            return sb.ToString();
        }


        public string GetStyleTag()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<style>");
            sb.Append(".");
            sb.AppendLine(Id);
            sb.AppendLine("{");
            GenerateStyle(sb);
            sb.AppendLine("}");
            sb.AppendLine("</style>");
            return sb.ToString();
        }

        protected virtual void OnChanged()
        {
            Changed?.Invoke(this, EventArgs.Empty);
        }
    }
}