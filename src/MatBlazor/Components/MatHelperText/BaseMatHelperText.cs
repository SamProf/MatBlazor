using Microsoft.AspNetCore.Components;

namespace MatBlazor
{
    public class BaseMatHelperText : BaseMatDomComponent
    {
        public BaseMatHelperText()
        {            
            ClassMapper
                .Add("mdc-text-field-helper-text")
                .If("mdc-text-field-helper-text--persistent", () => HelperTextPersistent)
                .If("mdc-text-field-helper-text--validation-msg", () => HelperTextValidation);
        }

        [Parameter]
        public string HelperText { get; set; }

        [Parameter]
        public bool HelperTextPersistent { get; set; }
        
        [Parameter]
        public bool HelperTextValidation { get; set; }

        [Parameter]
        public string CharacterCount { get; set; }
    }
}
