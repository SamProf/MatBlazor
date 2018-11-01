var matBlazor =
{
    matRadioButton: {
        init: function (mdcRadioRef, mdcFormFieldRef) {
            var radio = new window.mdc.radio.MDCRadio(mdcRadioRef);
            var formField = new window.mdc.formField.MDCFormField(mdcFormFieldRef);
            formField.input = radio;
        },
    },
    matSelect: {
        init: function (mdcSelectRef) {
            
            try {
                var select = new window.mdc.select.MDCSelect(mdcSelectRef);
            } catch (e) {
                debugger;
            }

            
        },
    },
};