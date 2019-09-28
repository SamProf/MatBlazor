using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    /// <summary>
    ///     Text fields allow users to input, edit, and select text.
    /// </summary>
    public class BaseMatTextFieldType<T> : BaseMatTextInputComponent<T>
    {
        protected MatTextFieldView TextFieldView { get; set; }
        public override ElementReference Ref
        {
            get => TextFieldView.Ref;
        }
    }
}