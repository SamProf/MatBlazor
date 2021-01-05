import {MDCSelect} from '@material/select';
import MDCSelectFoundation from '@material/select/foundation';
import {hoistMenuToBody} from '../matMenu/matMenu';


export class MatSelect {
  constructor(ref, component, value, options) {

    this.select = new MDCSelect(ref);

    this.select.value = value;

    console.log('MatSelect.init', options);

    if (!options.fullWidth) {
      hoistMenuToBody(this.select.menu);
    }


    this.select.listen('MDCSelect:change', () => {

      return component.invokeMethodAsync('SetValue', this.select.value);
    });
  }
}


export function init(ref, component, value, options) {
  ref.__matBlazor_component = new MatSelect(ref, component, value, options);
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
