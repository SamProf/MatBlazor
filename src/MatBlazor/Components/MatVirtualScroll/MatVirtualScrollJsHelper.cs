using Microsoft.JSInterop;

namespace ITMS.External.MatBlazor
{
    public class MatVirtualScrollJsHelper
    {
        private readonly IMatVirtualScroll _host;

        public MatVirtualScrollJsHelper(IMatVirtualScroll host)
        {
            _host = host;
        }

        [JSInvokable]
        public void VirtualScrollingSetView(MatVirtualScrollView view)
        {
            _host.VirtualScrollingSetView(view);
        }
    }

    public interface IMatVirtualScroll
    {
        void VirtualScrollingSetView(MatVirtualScrollView view);
    }
}