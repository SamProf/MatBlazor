import {MDCTextField} from '@material/textfield';
import {getMatBlazorInstance, setMatBlazorInstance} from "../utils/base";

export interface MatTextFieldDescriptor {
    ref;
    componentRef: MDCTextField;
}

export function init(ref) {
    setMatBlazorInstance<MatTextFieldDescriptor>(ref, {
        ref: ref,
        componentRef: new MDCTextField(ref)
    });
}


export function layout(ref) {
    getMatBlazorInstance<MatTextFieldDescriptor>(ref).componentRef.layout();
}

