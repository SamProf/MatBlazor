import {MDCSwitch} from '@material/switch';
import {setMatBlazorInstance} from "../utils/base";


interface MatSwitchInstance {
    component: MDCSwitch;
}


export function init(ref) {
    var instance = setMatBlazorInstance<MatSwitchInstance>(ref, {
        component: new MDCSwitch(ref),
    });
}
