import {MDCSelect} from '@material/select';
import MDCSelectFoundation from '@material/select/foundation';
import {hoistMenuToBody} from '../matMenu/matMenu';


//
//
// class MDCSelectFoundation2 extends  MDCSelectFoundation
// {
//
// }
//
//
//
// class MDCSelect2 extends  MDCSelect
// {
//
// }


export class MatSelect {
  constructor(ref, component, value) {

    this.select = new MDCSelect(ref);


    // var c = this.select;
    //
    //
    // var oldOpenMenu = c.foundation_.adapter_.openMenu;
    //
    // c.foundation_.adapter_.openMenu = function () {
    //   console.log('openMenu');
    //
    //   oldOpenMenu();
    //   c.menu_.setFixedPosition(true);
    // };


    // this.select.menu_.setFixedPosition(true);
    // this.select.menu_.setIsHoisted(true)
    // this.select.menu_.foundation_.handleMenuSurfaceOpened();


    // console.debug(this.select);
    // debugger;
    hoistMenuToBody(this.select.menu);


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
