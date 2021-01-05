import {MDCRipple} from '@material/ripple';
import {MatButton} from '../matButton/matButton';


export class MatIconButton extends MDCRipple {
  constructor(ref) {
    super(ref);
    this.unbounded = true;
  }
}


export function init(ref) {
  var button = new MatIconButton(ref);
}
