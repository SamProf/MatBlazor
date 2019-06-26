import './matSelect.scss';
import {MDCSelect} from '@material/select';


export class MatSelect {
  constructor(ref) {
    this.select = new MDCSelect(ref);
  }
}


export function init(ref) {
  ref.__matBlazor_component = new MatSelect(ref);
}


export function getValid(ref) {
  return ref.__matBlazor_component.select.valid;
}


export function setValid(ref, value) {
  ref.__matBlazor_component.select.valid = value;
}


export function getValue(ref) {
  return ref.__matBlazor_component.select.value;
}


export function setValue(ref, value) {
  ref.__matBlazor_component.select.value = value;
}
