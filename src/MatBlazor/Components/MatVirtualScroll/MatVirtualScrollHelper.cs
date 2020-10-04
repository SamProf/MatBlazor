using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatBlazor
{
    public class MatVirtualScrollHelper : IDisposable
    {
        private readonly IMatVirtualScrollHelperTarget _target;
        private MatVirtualScrollView _view;

        public bool Enabled { get; private set; }

        public MatVirtualScrollHelper(IMatVirtualScrollHelperTarget target)
        {
            this._target = target;
        }


        public MatVirtualScrollViewResult GetResult<TItem>(IEnumerable<TItem> e, int itemHeight, int topHeight, bool topSticky)
        {
            

            var minHeight = 0;

            int skipItems;
            int takeItems;

            if (Enabled)
            {
                var itemsCount = e.Count();
                
                if (_view != null)
                {
                    skipItems = Math.Max(0, _view.ScrollTop - (topSticky ? 0 : topHeight)) / itemHeight;
                    takeItems =
                        (int) Math.Ceiling(
                            (double) (_view.ScrollTop + _view.ClientHeight - topHeight) / (double) itemHeight) - skipItems +
                        10;
                    minHeight = itemsCount * itemHeight + topHeight;
                }
                else
                {
                    skipItems = 0;
                    takeItems = 0;
                }
            }
            else
            {
                skipItems = 0;
                takeItems = Int32.MaxValue;
            }
                


            return new MatVirtualScrollViewResult()
            {
                Height = minHeight,
                SkipItems = skipItems,
                TakeItems = takeItems,
                ScrollContainerStyle = $"min-height: {minHeight}px; --matVirtualScrollHelperPadding: {skipItems * itemHeight}px;",
            };
        }

        public string GetClass()
        {
            return Enabled ? "mat-virtual-scroll-helper" : "";
        }

        [JSInvokable]
        public void VirtualScrollingSetView(MatVirtualScrollView view)
        {
            this._view = view;
            _target.StateHasChangedFromVirtualScrollHelper();
        }

        // public string GetContentStyle<TItem>(IEnumerable<TItem> e, int mult = 1)
        // {
        //     if (_target.GetVirtualScrollIsEnabled())
        //     {
        //         if (_view != null)
        //         {
        //             var itemsCount = e.Count();
        //             var itemsHeight = _target.GetVirtualScrollItemHeight();
        //             var height = itemsCount * itemsHeight;
        //             var skipItems = _view.ScrollTop / itemsHeight;
        //             // return
        //             // $"height: {(height - skipItems * itemsHeight)}px; padding-top: {(skipItems * itemsHeight)}px;";
        //             return $"transform: translateY({mult * skipItems * itemsHeight}px);";
        //         }
        //     }
        //
        //     {
        //         return $"";
        //     }
        // }
        //
        //
        // public IEnumerable<TItem> GetContentItems<TItem>(IEnumerable<TItem> e)
        // {
        //     if (_target.GetVirtualScrollIsEnabled())
        //     {
        //         if (_view != null)
        //         {
        //             var itemHeight = _target.GetVirtualScrollItemHeight();
        //             var skipItems = Math.Max(0, _view.ScrollTop) / itemHeight;
        //             var takeItems =
        //                 (int) Math.Ceiling(
        //                     (double) (_view.ScrollTop + _view.ClientHeight - this.GetVirtualScrollTopHeight()) /
        //                     (double) itemHeight) - skipItems + 10;
        //
        //             takeItems = int.MaxValue;
        //
        //             return
        //                 e.Skip(skipItems).Take(takeItems);
        //         }
        //
        //         return Enumerable.Empty<TItem>();
        //     }
        //
        //     return e;
        // }
        //
        // public string GetContentPadding<TItem>(IEnumerable<TItem> e)
        // {
        //     if (_target.GetVirtualScrollIsEnabled())
        //     {
        //         if (_view != null)
        //         {
        //             var itemsCount = e.Count();
        //             var itemsHeight = _target.GetVirtualScrollItemHeight();
        //             var skipItems = Math.Max(0, _view.ScrollTop) / itemsHeight;
        //             // skipItems = 0;
        //             // return
        //             // $"height: {(height - skipItems * itemsHeight)}px; padding-top: {(skipItems * itemsHeight)}px;";
        //             return $"--matVirtualScrollTablePadding: {skipItems * itemsHeight}px;";
        //         }
        //     }
        //
        //     {
        //         return $"";
        //     }
        // }
        //
        //
        // public string GetScrollSpacerStyle<TItem>(IEnumerable<TItem> e)
        // {
        //     if (_target.GetVirtualScrollIsEnabled())
        //     {
        //         if (_view != null)
        //         {
        //             var itemsCount = e.Count();
        //             var itemsHeight = _target.GetVirtualScrollItemHeight();
        //             return $"transform: scaleY({itemsCount * itemsHeight + GetVirtualScrollTopHeight()});";
        //         }
        //     }
        //
        //     {
        //         return $"display: none;";
        //     }
        // }
        //
        // public string GetScrollContainerStyle<TItem>(IEnumerable<TItem> e)
        // {
        //     if (_target.GetVirtualScrollIsEnabled())
        //     {
        //         if (_view != null)
        //         {
        //             var itemsCount = e.Count();
        //             var itemsHeight = _target.GetVirtualScrollItemHeight();
        //             return $"min-height: {itemsCount * itemsHeight + GetVirtualScrollTopHeight()}px;";
        //         }
        //     }
        //
        //     {
        //         return $"display: none;";
        //     }
        // }

        private MatDotNetObjectReference<MatVirtualScrollHelper> jsHelper;

        public async Task InitAsync(IJSRuntime js, ElementReference @ref, bool enabled)
        {
            Enabled = enabled;
            if (this.Enabled)
            {
                jsHelper =
                    new MatDotNetObjectReference<MatVirtualScrollHelper>(this, false);
                var scrollView = await js.InvokeAsync<MatVirtualScrollView>("matBlazor.matVirtualScroll.init", @ref,
                    jsHelper.Reference);
                this.VirtualScrollingSetView(scrollView);
            }
        }

        public void Dispose()
        {
            jsHelper?.Dispose();
        }
    }
}