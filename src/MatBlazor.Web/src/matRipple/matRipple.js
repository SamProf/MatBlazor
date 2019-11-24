import './matRipple.scss';
import {MDCRipple} from '@material/ripple/component';


export function init(ref) {
  ref.matBlazorRef = new MDCRipple(ref);
}
