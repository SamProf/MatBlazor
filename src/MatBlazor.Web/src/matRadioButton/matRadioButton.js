import {MDCFormField} from '@material/form-field';
import {MDCRadio} from '@material/radio';


export class MatRadioButton {

  constructor(ref, formFieldRef) {
    const radio = new MDCRadio(ref);
    const formField = new MDCFormField(formFieldRef);
    formField.input = radio;
  }
}


export function init(ref, formFieldRef) {
  new MatRadioButton(ref, formFieldRef);
}
