import './matDatePicker.scss';

import flatpickr from 'flatpickr';
import {getMatBlazorInstance, setMatBlazorInstance} from '../utils/base';


export function init(ref, flatpickrInputRef, cmp, options) {
  var self = setMatBlazorInstance(ref, {});

  self.flatpickr = flatpickr(flatpickrInputRef, {
    positionElement: ref,
    onChange: function (value) {
      cmp.invokeMethodAsync('MatDatePickerOnChangeHandler', value);
    }
  });


}

export function open(ref, value) {
  var self = getMatBlazorInstance(ref);
  self.flatpickr.setDate(value);
  self.flatpickr.open();
}


export function setDate(ref, value) {
  var self = getMatBlazorInstance(ref);
  self.flatpickr.setDate(value);
}


// export function init_old(ref, cmp, defaultDate, options) {
//   console.log('defaultDate', options);
//
//   ref.$flatpickr = flatpickr(ref, {
//     defaultDate: defaultDate,
//     enableTime: options.enableTime,
//     time_24hr: options.enable24hours,
//     dateFormat: options.dateFormat,
//     noCalendar: options.noCalendar,
//     enableSeconds: options.enableSeconds,
//     weekNumbers: options.enableWeekNumbers,
//
//     allowInput: options.allowInput,
//     altFormat: options.altFormat,
//     mode: options.mode,
//     position: options.position,
//     inline: options.inline,
//     altInputClass: options.altInputClass,
//     disableMobile: options.disableMobile,
//
//     // wrap: true,
//     // allowInput: true,
//     // clickOpens: false,
//     onChange: function (value) {
//       // console.log(value);
//       cmp.invokeMethodAsync('MatDatePickerOnChangeHandler', value);
//     }
//   });


  // ref.$iconRef = iconRef;

  // ref.addEventListener('focus', (i) => {
  //
  //   ref.$flatpickr.close();
  // });
// }


