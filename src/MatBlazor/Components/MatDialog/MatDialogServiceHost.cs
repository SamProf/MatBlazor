using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace MatBlazor
{
    public class MatDialogServiceHost : ComponentBase, IDisposable
    {
        [Inject]
        private IMatDialogService MatDialogService { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            MatDialogService.ItemsChanged += OnItemsChanged;
        }

        private void OnItemsChanged(object sender, IEnumerable<MatDialogReference> e)
        {
            this.InvokeAsync(() => { this.StateHasChanged(); });
        }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            foreach (var item in MatDialogService.Items)
            {
                builder.OpenComponent<MatBlazor.MatDialog>(0);


                builder.AddAttribute(1, "CanBeClosed",
                    Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean?>(
                        item.Options?.CanBeClosed ?? BaseMatDialog.CanBeClosedDefault
                    ));

                builder.AddAttribute(2, "IsOpen",
                    Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
                        item.IsOpen
                    ));


                builder.AddAttribute(3, "SurfaceClass",
                    Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
                        item.Options?.SurfaceClass
                    ));

                builder.AddAttribute(4, "SurfaceStyle",
                    Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
                        item.Options?.SurfaceStyle
                    ));
                builder.AddAttribute(5, "IsOpenChanged",
                    Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers
                        .TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(
                            Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this,
                                b =>
                                {
                                    item.IsOpen = b;
                                    if (!b)
                                    {
                                        item.Close(null);
                                    }
                                }
                            )));


                builder.AddAttribute(6, "ChildContent",
                    (RenderFragment) ((builder2) =>
                        {
                            builder2.OpenComponent(7, item.ComponentType);
                            builder2.AddMultipleAttributes(8,
                                Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers
                                    .TypeCheck<System.Collections.Generic.IEnumerable<
                                        System.Collections.Generic.KeyValuePair<string, object>>>(
                                        item.Attributes
                                    ));
                            builder2.CloseComponent();
                        }
                    ));
                builder.SetKey(
                    item.Id
                );
                builder.CloseComponent();
            }
        }

        public void Dispose()
        {
            MatDialogService.ItemsChanged -= OnItemsChanged;
        }
    }
}