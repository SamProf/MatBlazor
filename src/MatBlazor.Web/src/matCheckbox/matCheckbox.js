import './matCheckbox.scss';
import {MDCFormField} from '@material/form-field';
import {MDCCheckbox} from '@material/checkbox';
import {matBlazorClassKey} from '../base';


export class MatCheckbox {
  constructor(ref, componentRef, value) {
    this.checkbox = new MDCCheckbox(componentRef);
    this.formField = new MDCFormField(ref);
    this.formField.input = this.checkbox;
    ref[matBlazorClassKey] = this;

    this.checkbox.checked = value == true;
    this.checkbox.indeterminate = value == null;
  }


  setIndeterminate() {
    this.checkbox.indeterminate = true;
  }

}


export function init(ref, componentRef, value) {
  new MatCheckbox(ref, componentRef, value);
}


export function setIndeterminate(ref) {
  ref[matBlazorClassKey].setIndeterminate();
}
