var matBlazor =
{
    matRadioButton: {
        init: function(mdcRadioRef, mdcFormFieldRef) {
            var radio = new window.mdc.radio.MDCRadio(mdcRadioRef);
            var formField = new window.mdc.formField.MDCFormField(mdcFormFieldRef);
            formField.input = radio;
        },
    },
    matSelect: {
        init: function(mdcSelectRef) {
            try {
                var select = new window.mdc.select.MDCSelect(mdcSelectRef);
            } catch (e) {
                debugger;
                throw e;
            }
        },
    },
    matSlider: {
        init: function(mdcSliderRef, jsHelper) {
            try {
                var slider = new window.mdc.slider.MDCSlider(mdcSliderRef);
                slider.listen('MDCSlider:change',
                    function() {
//                        debugger;
                        try {
                            jsHelper.invokeMethodAsync('OnChangeHandler', slider.value)
                                .then(r => console.log(r));
                        } catch (e) {
                            debugger;
                            throw e;
                        }

                    });
            } catch (e) {
                debugger;
                throw e;
            }
        },
    },

    matMenu: {
        init: function(mdcMenu) {
            try {
                var menu = new window.mdc.menu.MDCMenu(mdcMenu);
                menu.hoistMenuToBody(); 
                mdcMenu.matBlazorRef = menu;
            } catch (e) {
                debugger;
                throw e;
            }
        },
        open: function (mdcMenu, anchorElement) {
            debugger;
            var menu = mdcMenu.matBlazorRef;
            menu.setAnchorElement(anchorElement);
            menu.open = true;
        },
    },
    matAppBar: {
        init: function(ref) {
            try {
                var topAppBar = new window.mdc.topAppBar.MDCTopAppBar(ref);
            } catch (e) {
                debugger;
                throw e;
            }
        },
    },
};