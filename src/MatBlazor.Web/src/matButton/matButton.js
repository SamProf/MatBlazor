import {MDCRipple} from '@material/ripple';

export class MatButton extends MDCRipple {
  constructor(ref) {
    super(ref);
  }
}

export function init(ref) {
  var button = new MatButton(ref);
}

export function openLink(args) {
    window.open(args);
}
