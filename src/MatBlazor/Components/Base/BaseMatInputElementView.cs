using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MatBlazor.Components.MatTextFieldView;
using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatInputElementView<T, TViewModel> : BaseMatInputComponent<T>
        where TViewModel : IMatInputElementViewModel<T>
    {
        [Parameter]
        public TViewModel Model { get; set; }

        protected ClassMapper inputClassMapper = new ClassMapper();
        protected StyleMapper inputStyleMapper = new StyleMapper();


        protected virtual string GetDefaultInputType()
        {
            var t = typeof(T);
            if (t == typeof(string))
            {
                return "text";
            }

            if (t == typeof(bool) || t == typeof(bool?))
            {
                return "checkbox";
            }

            return null;
        }

        protected string GetInputType()
        {
            if (Model.Type == null)
            {
                return GetDefaultInputType();
            }
            else
            {
                return Model.Type;
            }
        }


        public BaseMatInputElementView()
        {
            inputClassMapper
                .Get(() => Model.InputClass);
            inputStyleMapper
                .Get(() => Model.InputStyle);
        }
    }
}