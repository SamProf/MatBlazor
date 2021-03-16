import {MDCSelect} from '@material/select';
import MDCSelectFoundation from '@material/select/foundation';
import {hoistMenuToBody} from '../matMenu/matMenu';
import {getMatBlazorInstance, setMatBlazorInstance} from "../utils/base";


interface MatSelectInstance {
    ref: Element;
    component: MDCSelect;
}


export function init(ref, component, value, options) {
    var instance = setMatBlazorInstance<MatSelectInstance>(ref, {
        ref: ref,
        component: new MDCSelect(ref)
    });

    instance.component.value = value;

    if (!options.fullWidth) {
        hoistMenuToBody((<any>instance.component).menu);
    }

    instance.component.listen('MDCSelect:change', () => {

        return component.invokeMethodAsync('SetValue', instance.component.value);
    });
}

export function getValid(ref) {
    return getMatBlazorInstance<MatSelectInstance>(ref).component.valid;
}

export function setValid(ref, value) {
    getMatBlazorInstance<MatSelectInstance>(ref).component.valid = value;
}

export function getValue(ref) {
    return getMatBlazorInstance<MatSelectInstance>(ref).component.value;
}

export function setValue(ref, value) {
    var instance = getMatBlazorInstance<MatSelectInstance>(ref);
    instance.component.value = value;
    instance.component.layout();
}
