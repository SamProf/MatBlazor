import {MDCRipple} from '@material/ripple';


export class MatButton extends MDCRipple {

  constructor(ref) {
    super(ref);
  }
}


export function init(ref) {
  var button = new MatButton(ref);
}
