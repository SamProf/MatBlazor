import {MDCSlider} from '@material/slider';
import {getMatBlazorInstance, setMatBlazorInstance} from "../utils/base";
import {log} from "../utils/log";

export let sliders = {}


interface MatSliderInstance {
    component: MDCSlider;
    jsHelper;
}


function onChange(instance: MatSliderInstance) {
    instance.jsHelper.invokeMethodAsync('OnChangeHandler', instance.component.getValue())
        .then(r => {
            // console.log(r);
        })
        .catch(e => console.error(e));

}


export function init(ref: HTMLElement, jsHelper, immediate) {
    try {
        var inputRef : HTMLInputElement = <HTMLInputElement>ref.getElementsByClassName("mdc-slider__input")[0];
        inputRef.setAttribute('value', inputRef.value);
        var instance = setMatBlazorInstance<MatSliderInstance>(ref, {
            component: new MDCSlider(ref),
            jsHelper: jsHelper,
        });


        instance.component.listen('MDCSlider:change', () => onChange(instance));
        if (immediate) {
            instance.component.listen('MDCSlider:input', () => onChange(instance));
        }
    }
    catch (e)
    {
        log('MatSlider.error', ref, e);
    }
}


export function updateValue(ref, value) {
    getMatBlazorInstance<MatSliderInstance>(ref).component.setValue(value);
}

export function updateValueMin(ref, value) {
    //getMatBlazorInstance<MatSliderInstance>(ref).component
}

export function updateValueMax(ref, value) {
    // if (!sliders[ref.id]) {
    //     return;
    // }
    // sliders[ref.id].slider.max = value;
    // getMatBlazorInstance<MatSliderInstance>(ref).component
}

export function updateStep(ref, value) {
    // if (!sliders[ref.id]) {
    //     return;
    // }
    // sliders[ref.id].slider.step = value;
}
