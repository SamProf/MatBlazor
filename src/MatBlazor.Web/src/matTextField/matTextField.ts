import {MDCTextField} from '@material/textfield';
import {getMatBlazorInstance, setMatBlazorInstance} from "../utils/base";

export interface MatTextFieldInstance {
    ref;
    componentRef: MDCTextField;
}

export function init(ref) {
    setMatBlazorInstance<MatTextFieldInstance>(ref, {
        ref: ref,
        componentRef: new MDCTextField(ref)
    });
}


export function layout(ref) {
    getMatBlazorInstance<MatTextFieldInstance>(ref).componentRef.layout();
}

