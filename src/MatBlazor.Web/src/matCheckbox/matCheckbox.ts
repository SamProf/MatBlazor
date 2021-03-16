import {MDCFormField} from '@material/form-field';
import {MDCCheckbox} from '@material/checkbox';
import {getMatBlazorInstance, MatBlazorComponent, setMatBlazorInstance} from '../utils/base';


interface MatCheckboxInstance {
    ref;
    componentRef;
    checkbox;
}


export function init(ref, componentRef) {
    var self = setMatBlazorInstance<MatCheckboxInstance>(ref, {
        ref,
        componentRef,
        checkbox: null
    });

    self.checkbox = new MDCCheckbox(self.componentRef);
    let formField = new MDCFormField(self.ref);
    formField.input = self.checkbox;
}

export function setIndeterminate(ref, value) {
    var self = getMatBlazorInstance<MatCheckboxInstance>(ref);
    self.checkbox.indeterminate = value;
}
