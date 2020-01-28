import {MDCSelect} from '@material/select';


export class MatSelect {
  constructor(ref, component, value) {
    this.select = new MDCSelect(ref);
    this.select.value = value;
    // var firstChange = true;
	this.select.listen('MDCSelect:change', () => {
      // console.log("MDCSelect:change", this.select.value);
	  // if (firstChange)
      // {
      //   console.log("firstChange", this.select.value);
      //   firstChange = false;
      //   return;
      // }
	  // console.log("invokeMethodAsync", this.select.value);

      return component.invokeMethodAsync('SetValue', this.select.value);
    });
  }
}


export function init(ref, component, value) {
  ref.__matBlazor_component = new MatSelect(ref, component, value);
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
  // console
  //   .log('setValue, ',value);
  ref.__matBlazor_component.select.value = value;
}
