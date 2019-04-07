import './matRipple.scss';
import {MDCRipple} from '@material/ripple/component';


export function init(ref, component) {
  ref.matBlazorRef = new MDCRipple(ref);
}
