using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    /// Buttons communicate an action a user can take. They are typically placed throughout your UI, in places like dialogs, forms, cards, and toolbars.
    /// </summary>
    public class BaseMatRadioButtonType<T> : BaseMatDomComponent
    {

        protected MatBlazorSwitchT<T> SwitchT = MatBlazorSwitchT<T>.Get();


        [CascadingParameter()]
        protected BaseMatRadioGroupType<T> Group { get; set; }
        
        [Parameter()]
        public RenderFragment ChildContent{ get; set; }

        protected ElementReference FormFieldRef;

        protected bool Checked
        {
            get => EqualityComparer<T>.Default.Equals(Group.Value, Value);
        }


        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public T Value { get; set; }


        protected string ValueAsString
        {
            get
            {
                if (SwitchT == null)
                {
                    return Id.ToString();
                }

                return SwitchT.FormatValueAsString(Value, null);
            }
        }

        [Parameter]
        public string Label { get; set; }

        protected void OnChangeHandler(ChangeEventArgs e)
        {
            Group.SetCurrentValue(this.Value);
            //Checked = (bool)e.Value;
        }

        protected async override Task OnFirstAfterRenderAsync()
        {
            await base.OnFirstAfterRenderAsync();
            await JsInvokeAsync<object>("matBlazor.matRadioButton.init", Ref, FormFieldRef);
        }

        public BaseMatRadioButtonType()
        {
            ClassMapper
                .Add("mdc-radio")
                .If("mdc-radio--disabled", () => Disabled);
        }
    }
}