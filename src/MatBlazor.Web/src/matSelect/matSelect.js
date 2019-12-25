import {MDCSelect} from '@material/select';


export class MatSelect {
  constructor(ref, component) {
    this.select = new MDCSelect(ref);
	this.select.listen('MDCSelect:change', () => component.invokeMethodAsync("SetValue", this.select.value));
  }
}


export function init(ref, component) {
  ref.__matBlazor_component = new MatSelect(ref, component);
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
