import {MDCTextField} from '@material/textfield';

export class MatNumericUpDownField {
  constructor(ref) {
    const textField = new MDCTextField(ref);
  }
}

export function init(ref) {
  new MatNumericUpDownField(ref);
}

export function clearAndInvalid(ref) {
  // console.log( ref.getElementsByTagName('input')[0].value );
  ref.getElementsByTagName('input')[0].value ="";
  ref.classList.add("mdc-text-field--invalid");
}

export function setValue(ref, value) {
  // console.log( ref.getElementsByTagName('input')[0].value );
  ref.getElementsByTagName('input')[0].value = value;
}