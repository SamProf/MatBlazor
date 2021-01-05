import { MDCSlider } from '@material/slider';

export let sliders = {}

export class MatSlider {
    OnChange(jsHelper) {
        jsHelper.invokeMethodAsync('OnChangeHandler', this.slider.value)
            .then(r => {
                // console.log(r);
            })
            .catch(e => console.error(e));
    }

    constructor(ref, jsHelper, immediate) {
        this.slider = new MDCSlider(ref);

        this.slider.listen('MDCSlider:change', () => this.OnChange(jsHelper));
        if (immediate) {
            this.slider.listen('MDCSlider:input', () => this.OnChange(jsHelper));
        }
    }
}


export function init(ref, jsHelper, immediate) {
    sliders[ref.id] = new MatSlider(ref, jsHelper, immediate);
}

export function updateValue(ref, value) {
    if (!sliders[ref.id]) {
        return;
    }
    sliders[ref.id].slider.value = value;
}

export function updateValueMin(ref, value) {
    if (!sliders[ref.id]) {
        return;
    }
    sliders[ref.id].slider.min = value;
}

export function updateValueMax(ref, value) {
    if (!sliders[ref.id]) {
        return;
    }
    sliders[ref.id].slider.max = value;
}

export function updateStep(ref, value) {
    if (!sliders[ref.id]) {
        return;
    }
    sliders[ref.id].slider.step = value;
}