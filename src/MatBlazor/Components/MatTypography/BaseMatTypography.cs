using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public abstract class BaseMatTypography : BaseMatContainerComponent
    {

        [Parameter]
        public bool Anchor { get; set; }
        
        [Parameter]
        public string AnchorId { get; set; }

        protected BaseMatTypography(string tag, string className)
        {
            this.Tag = tag;
            ClassMapper
                .Add("mat")
                .Add(className);
        }
    }

    public class MatHeadline1 : BaseMatTypography
    {
        public MatHeadline1() : base("h1", "mat-h1")
        {
        }
    }
    public class MatHeadline2 : BaseMatTypography
    {
        public MatHeadline2() : base("h2", "mat-h2")
        {
        }
    }
    public class MatHeadline3 : BaseMatTypography
    {
        public MatHeadline3() : base("h3", "mat-h3")
        {
        }
    }

    public class MatHeadline4 : BaseMatTypography
    {
        public MatHeadline4() : base("h4", "mat-h4")
        {
        }
    }

    public class MatHeadline5 : BaseMatTypography
    {
        public MatHeadline5() : base("h5", "mat-h5")
        {
        }
    }

    public class MatHeadline6 : BaseMatTypography
    {
        public MatHeadline6() : base("h6", "mat-h6")
        {
        }
    }

    public class MatH1 : MatHeadline1
    {
    }

    public class MatH2 : MatHeadline2
    {
    }

    public class MatH3 : MatHeadline3
    {
    }

    public class MatH4 : MatHeadline4
    {
    }

    public class MatH5 : MatHeadline5
    {
    }

    public class MatH6 : MatHeadline6
    {
    }

    public class MatSubtitle1 : BaseMatTypography
    {
        public MatSubtitle1() : base("h6", "mat-subtitle1")
        {
        }
    }

    public class MatSubtitle2 : BaseMatTypography
    {
        public MatSubtitle2() : base("h6", "mat-subtitle2")
        {
        }
    }

    public class MatBody1 : BaseMatTypography
    {
        public MatBody1() : base("p", "mat-body1")
        {
        }
    }

    public class MatBody2 : BaseMatTypography
    {
        public MatBody2() : base("p", "mat-body2")
        {
        }
    }

    public class MatCaption : BaseMatTypography
    {
        public MatCaption() : base("span", "mat-caption")
        {
        }
    }

    public class MatOverline : BaseMatTypography
    {
        public MatOverline() : base("span", "mat-overline")
        {
        }
    }
}