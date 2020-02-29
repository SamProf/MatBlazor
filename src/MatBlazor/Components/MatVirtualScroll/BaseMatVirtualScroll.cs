using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MatBlazor
{
    public class BaseMatVirtualScroll<ItemType> : BaseMatDomComponent, IMatVirtualScroll
    {
        [Parameter]
        public int ItemHeight { get; set; } = 50;


        [Parameter]
        public RenderFragment<ItemType> ChildContent { get; set; }

        [Parameter]
        public IEnumerable<ItemType> Items { get; set; }

        public MatDotNetObjectReference<MatVirtualScrollJsHelper> JsHelperReference { get; set; }


        public BaseMatVirtualScroll()
        {

            ClassMapper.Add("﻿mat-virtual-scroll");
            
            CallAfterRender(async () =>
            {
                JsHelperReference = new MatDotNetObjectReference<MatVirtualScrollJsHelper>(new MatVirtualScrollJsHelper(this));
                var scrollView = await Js.InvokeAsync<MatVirtualScrollView>("matBlazor.matVirtualScroll.init", Ref,
                    JsHelperReference.Reference);
                this.SetScrollView(scrollView);
            });
        }

        public void VirtualScrollingSetView(MatVirtualScrollView scrollView)
        {
            this.SetScrollView(scrollView);
        }


        public override void Dispose()
        {
            base.Dispose();
            // todo call js to dispose events (window resize)
            JsHelperReference?.Dispose();
        }

        private void SetScrollView(MatVirtualScrollView scrollView)
        {
            this.ScrollView = scrollView;
            this.ScrollViewResult = new MatVirtualScrollViewResult();
            this.ScrollViewResult.Height = Items.Count() * ItemHeight;
            this.ScrollViewResult.SkipItems = scrollView.ScrollTop / this.ItemHeight;
            this.ScrollViewResult.TakeItems =
                (int) Math.Ceiling((double) (scrollView.ScrollTop + scrollView.ClientHeight) / (double) ItemHeight) -
                this.ScrollViewResult.SkipItems;
//            Console.WriteLine(ScrollViewResult.SkipItems + " " + ScrollViewResult.TakeItems);
            this.StateHasChanged();
        }

        public MatVirtualScrollViewResult ScrollViewResult { get; set; }

        public MatVirtualScrollView ScrollView { get; set; }
    }
}