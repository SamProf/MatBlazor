import { MDCSlider } from '@material/slider';

export class MatSlider {

    constructor(ref, jsHelper, immediate) {
        this.slider = new MDCSlider(ref);

        this.slider.listen('MDCSlider:change', () => {
            //                        debugger;
            try {
                jsHelper.invokeMethodAsync('OnChangeHandler', this.slider.value)
                    .then(r => {
                        // console.log(r);
                    });
            } catch (e) {
                debugger;
                throw e;
            }
        });
        if (immediate) {
            this.slider.listen('MDCSlider:input', () => {
                //                        debugger;
                try {
                    jsHelper.invokeMethodAsync('OnChangeHandler', this.slider.value)
                        .then(r => {
                            // console.log(r);
                        });
                } catch (e) {
                    debugger;
                    throw e;
                }
            });
        }
    }
}


export function init(ref, jsHelper, immediate) {
    new MatSlider(ref, jsHelper, immediate);
}
