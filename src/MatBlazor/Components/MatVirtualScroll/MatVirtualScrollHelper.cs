using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor
{
    public class MatVirtualScrollHelper : IDisposable
    {
        private readonly IMatVirtualScrollHelperTarget _target;

        public MatVirtualScrollHelper(IMatVirtualScrollHelperTarget target)
        {
            _target = target;
        }


        public string GetClass()
        {
            return _target.GetVirtualScrollIsEnabled() ? "﻿mat-virtual-scroll-helper" : null;
        }


        private MatVirtualScrollView view;

        [JSInvokable]
        public void VirtualScrollingSetView(MatVirtualScrollView view)
        {
            this.view = view;
            _target.MarkStateHasChanged();
        }


//         private void Test1()
//         {
//             this.ScrollView = scrollView;
//             this.ScrollViewResult = new MatVirtualScrollViewResult();
//             this.ScrollViewResult.Height = Items.Count() * ItemHeight;
//             this.ScrollViewResult.SkipItems = scrollView.ScrollTop / this.ItemHeight;
//             this.ScrollViewResult.TakeItems =
//                 (int) Math.Ceiling((double) (scrollView.ScrollTop + scrollView.ClientHeight) / (double) ItemHeight) -
//                 this.ScrollViewResult.SkipItems;
// //            Console.WriteLine(ScrollViewResult.SkipItems + " " + ScrollViewResult.TakeItems);
//             this.StateHasChanged();
//         }


        public IEnumerable<TItem> GetContentItems<TItem>(IEnumerable<TItem> e)
        {
            if (_target.GetVirtualScrollIsEnabled())
            {
                if (view != null)
                {
                    var itemHeight = _target.GetVirtualScrollItemHeight();
                    var skipItems = view.ScrollTop / itemHeight;
                    var takeItems =
                        (int) Math.Ceiling((double) (view.ScrollTop + view.ClientHeight) /
                                           (double) itemHeight) - skipItems;

                    return
                        e.Skip(skipItems).Take(takeItems);
                }

                return Enumerable.Empty<TItem>();
            }

            return e;
        }

        public string GetContentStyle<TItem>(IEnumerable<TItem> e, int mult = 1)
        {
            if (_target.GetVirtualScrollIsEnabled())
            {
                if (view != null)
                {
                    var itemsCount = e.Count();
                    var itemsHeight = _target.GetVirtualScrollItemHeight();
                    var height = itemsCount * itemsHeight;
                    var skipItems = view.ScrollTop / itemsHeight;
                    // return
                    // $"height: {(height - skipItems * itemsHeight)}px; padding-top: {(skipItems * itemsHeight)}px;";
                    return $"transform: translateY({mult * skipItems * itemsHeight}px);";
                }
            }

            {
                return $"";
            }
        }


        public string GetScrollSpacerStyle<TItem>(IEnumerable<TItem> e)
        {
            if (_target.GetVirtualScrollIsEnabled())
            {
                if (view != null)
                {
                    var itemsCount = e.Count();
                    var itemsHeight = _target.GetVirtualScrollItemHeight();
                    return $"transform: scaleY({itemsCount * itemsHeight});";
                }
            }

            {
                return $"display: none;";
            }
        }

        private MatDotNetObjectReference<MatVirtualScrollHelper> jsHelper;

        public async Task InitAsync(IJSRuntime js, ElementReference @ref)
        {
            if (_target.GetVirtualScrollIsEnabled())
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