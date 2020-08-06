using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace MatBlazor
{
    /// <summary>
    /// Chips are compact elements that allow users to enter information, select a choice, filter content, or trigger an action.
    /// </summary>
    public partial class MatChip
    {

        /// <summary>
        /// Optional icon, displayed before the label.
        /// </summary>
        [Parameter]
        public string LeadingIcon { get; set; }

        /// <summary>
        /// A trailing icon comes with the functionality to remove the chip from the set, so the natural value for this would be "clear".
        /// </summary>
        [Parameter]
        public string TrailingIcon { get; set; }

        [Parameter]
        public EventCallback<MatChip> TrailingIconClick { get; set; }

        /// <summary>
        /// The chip's text.
        /// </summary>
        [Parameter]
        public string Label { get; set; }

        /// <summary>
        /// A user-defined value assigned to the chip.
        /// </summary>
        [Parameter]
        public object Value { get; set; }

        /// <summary>
        /// Reflects the selection state of a choice- or filter-chip (parent chipset has either Choice or Filter set to true).
        ///
        /// When you set this in markup, it pre-selects the chip.
        /// </summary>
        [Parameter]
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected == value)
                {
                    return;
                }
                _isSelected = value;
                this.StateHasChanged();
                if (ChipSet != null && _isSelected)
                {
                    ChipSet.HandleChipSelected(this);
                }
                IsSelectedChanged.InvokeAsync(_isSelected);
            }
        }

        /// <summary>
        /// Allows two-way binding of IsSelected
        /// </summary>
        [Parameter]
        public EventCallback<bool> IsSelectedChanged { get; set; }

        /// <summary>
        /// Checkable chips show a check-mark when selected
        /// </summary>
        [Parameter]
        public bool IsCheckable { get; set; }

        private DotNetObjectReference<MatChip> _dotNetObjectRef;
        private bool _isSelected;

        public MatChip()
        {
            ClassMapper
                .Add("mdc-chip")
                .If("mdc-chip--selected", () => this.IsSelected);
        }

        [CascadingParameter]
        public MatChipSet ChipSet { get; set; }

        protected override void OnInitialized()
        {
            if (ChipSet == null)
            {
                return;
            }
            ChipSet.RegisterChip(this);
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            _dotNetObjectRef ??= CreateDotNetObjectRef(this); // needed to call into this object from Javascript
            await JsInvokeAsync<object>("matBlazor.matChip.init", Ref, _dotNetObjectRef);
            if (_isSelected && ChipSet != null)
            {
                await ChipSet.HandleChipSelected(this);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            DisposeDotNetObjectRef(_dotNetObjectRef);
        }

        [JSInvokable]
        public async Task MatChipInteractionHandler(string chipId)
        {
            if (ChipSet == null)
            {
                return;
            }
            await ChipSet.HandleChipClicked(this);
        }

        //[JSInvokable]
        //public async Task MatChipSelectionHandler(string chipId, bool selected)
        //{
        //    ;
        //}

        //[JSInvokable]
        //public async Task MatChipRemovalHandler(string chipId, string removedAnnouncement)
        //{
        //    ; 
        //}

        [JSInvokable]
        public async Task MatChipTrailingIconInteractionHandler(string chipId)
        {
            await TrailingIconClick.InvokeAsync(this);
        }

        //[JSInvokable]
        //public async Task MatChipNavigationHandler(string chipId, string key)
        //{
        //    ;
        //}
    }
}