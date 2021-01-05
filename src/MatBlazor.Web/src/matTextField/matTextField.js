import {MDCTextField} from '@material/textfield';

export class MatTextField {


  constructor(ref) {
    const textField = new MDCTextField(ref);

  }
}

export function init(ref) {
  new MatTextField(ref);
}

