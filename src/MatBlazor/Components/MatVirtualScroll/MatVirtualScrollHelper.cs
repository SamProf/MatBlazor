namespace MatBlazor
{
    public class MatVirtualScrollHelper
    {
        private readonly IMatVirtualScrollHelperTarget _target;

        public MatVirtualScrollHelper(IMatVirtualScrollHelperTarget target)
        {
            _target = target;
        }

        public string GetClass()
        {
            return _target.VirtualScrollIsEnabled() ? "﻿mat-virtual-scroll" : null;
        }
    }
}