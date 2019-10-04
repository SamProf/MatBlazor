using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    ///     Text fields allow users to input, edit, and select text.
    /// </summary>
    public class BaseMatTextFieldType<T> : BaseMatInputTextComponent<T>
    {
        protected MatTextFieldView TextFieldView { get; set; }
        public override ElementReference Ref => TextFieldView.Ref;
    }
}