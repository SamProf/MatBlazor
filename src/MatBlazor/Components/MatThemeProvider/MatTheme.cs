using System;
using System.Text;

namespace MatBlazor
{
    public class MatTheme
    {
        internal string Id { get; private set; } = IdGeneratorHelper.Generate("matBlazor_theme_");

        /// <summary>
        /// The theme primary color
        /// </summary>
        public string Primary { get; set; }

        /// <summary>
        /// The theme secondary color
        /// </summary>
        public string Secondary { get; set; }

        /// <summary>
        /// The theme background color
        /// </summary>
        public string Background { get; set; }

        /// <summary>
        /// The theme surface color
        /// </summary>
        public string Surface { get; set; }

        /// <summary>
        /// Text color on top of a primary background
        /// </summary>
        public string OnPrimary { get; set; }

        /// <summary>
        /// Text color on top of a secondary background
        /// </summary>
        public string OnSecondary { get; set; }

        /// <summary>
        /// Text color on top of a surface background
        /// </summary>
        public string OnSurface { get; set; }

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

            if (!string.IsNullOrEmpty(Background))
            {
                sb.AppendLine($"--mdc-theme-background: {Background};");
            }

            if (!string.IsNullOrEmpty(Surface))
            {
                sb.AppendLine($"--mdc-theme-surface: {Surface};");
            }

            if (!string.IsNullOrEmpty(OnPrimary))
            {
                sb.AppendLine($"--mdc-theme-on-primary: {OnPrimary};");
            }

            if (!string.IsNullOrEmpty(OnSecondary))
            {
                sb.AppendLine($"--mdc-theme-on-secondary: {OnSecondary};");
            }

            if (!string.IsNullOrEmpty(OnSurface))
            {
                sb.AppendLine($"--mdc-theme-on-surface: {OnSurface};");
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