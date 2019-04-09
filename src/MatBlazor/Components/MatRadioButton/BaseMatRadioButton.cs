using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatBlazor.Components.Base;
using MatBlazor.Components.MatRadioGroup;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Components;

namespace MatBlazor.Components.MatRadioButton
{
    /// <summary>
    /// Buttons communicate an action a user can take. They are typically placed throughout your UI, in places like dialogs, forms, cards, and toolbars.
    /// </summary>
    public class BaseMatRadioButton : BaseMatComponent
    {
        [CascadingParameter]
        protected BaseMatRadioGroup Group { get; set; }

        protected ElementRef FormFieldRef;

        private bool _disabled;


        protected bool Checked
        {
            get => Group.Value == Value;
        }

        
        [Parameter]
        public bool Disabled
        {
            get => _disabled;
            set
            {
                _disabled = value;
                ClassMapper.MakeDirty();
            }
        }

        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public string Label { get; set; }

        protected void OnChangeHandler(UIChangeEventArgs e)
        {

            Group.Value = this.Value;
            //Checked = (bool)e.Value;
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await Js.InvokeAsync<object>("matBlazor.matRadioButton.init", Ref, FormFieldRef);
        }

        public BaseMatRadioButton()
        {
            ClassMapper
                .Add("mdc-radio")
                .If("mdc-radio--disabled", () => Disabled);
        }
    }
}