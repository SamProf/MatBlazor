import './matCheckbox.scss';
import {MDCFormField} from '@material/form-field';
import {MDCCheckbox} from '@material/checkbox';


export class MatCheckbox {
  constructor(ref, formFieldRef) {
    this.checkbox = new MDCCheckbox(ref);
    this.formField = new MDCFormField(formFieldRef);
    this.formField.input = this.checkbox;
    ref.blazorClass = this;
  }

}


export function init(ref, formFieldRef) {
  new MatCheckbox(ref, formFieldRef);
}
