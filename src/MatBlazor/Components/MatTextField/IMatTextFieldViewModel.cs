using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace MatBlazor.Components.MatTextFieldView
{
    public interface IMatTextFieldViewModel : IBaseMatComponent
    {
        ElementReference InputRef { get; set; }


        EventCallback<MouseEventArgs> IconOnClick { get; set; }


        EventCallback<FocusEventArgs> OnFocus { get; set; }


        EventCallback<FocusEventArgs> OnFocusOut { get; set; }


        EventCallback<KeyboardEventArgs> OnKeyPress { get; set; }


        EventCallback<KeyboardEventArgs> OnKeyDown { get; set; }


        EventCallback<KeyboardEventArgs> OnKeyUp { get; set; }


        EventCallback<ChangeEventArgs> OnInput { get; set; }
        string Label { get; set; }


        string Icon { get; set; }


        bool IconTrailing { get; set; }


        bool Box { get; set; }

        bool TextArea { get; set; }


        bool Dense { get; set; }


        bool Outlined { get; set; }


        bool Disabled { get; set; }


        bool ReadOnly { get; set; }


        bool FullWidth { get; set; }


        bool Required { get; set; }


        string HelperText { get; set; }


        bool HelperTextPersistent { get; set; }


        bool HelperTextValidation { get; set; }


        string PlaceHolder { get; set; }


        bool HideClearButton { get; set; }

        string Type { get; set; }
        string InputClass { get; set; }
        string InputStyle { get; set; }
        
        string CurrentValueAsString { get; set; }
    }
}