import './matDatePicker.scss';

import flatpickr from 'flatpickr';

export function init(ref, cmp, defaultDate) {
  // console.log('defaultDate', defaultDate)

  ref.$flatpickr = flatpickr(ref, {
    defaultDate: defaultDate,
    // wrap: true,
    // allowInput: true,
    // clickOpens: false,
    onChange: function (value) {
      // console.log(value);
      cmp.invokeMethodAsync('MatDatePickerOnChangeHandler', value);
    }
  });


  ref.$iconRef = iconRef;

  // ref.addEventListener('focus', (i) => {
  //
  //   ref.$flatpickr.close();
  // });
}


export function setDate(ref, value) {
  ref.$flatpickr.setDate(value);
}
