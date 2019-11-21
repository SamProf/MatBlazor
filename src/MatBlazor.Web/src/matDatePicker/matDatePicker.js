import './matDatePicker.scss';

import flatpickr from 'flatpickr';

export function init(ref, cmp, defaultDate, options) {
    console.log('defaultDate', options)

    ref.$flatpickr = flatpickr(ref, {
        defaultDate: defaultDate,
        enableTime: options.enableTime,
        time_24hr: options.enable24hours,
        dateFormat: options.dateFormat,
        noCalendar: options.noCalendar,
        enableSeconds: options.enableSeconds,
        weekNumbers: options.enableWeekNumbers,

        allowInput: options.allowInput,
        altFormat: options.altFormat,
        mode: options.mode,
        position: options.position,
        inline: options.inline,
        altInputClass: options.altInputClass,
        disableMobile: options.disableMobile,
        locale: options.locale,
        
        // wrap: true,
        // allowInput: true,
        // clickOpens: false,
        onChange: function (value) {
            // console.log(value);
            cmp.invokeMethodAsync('MatDatePickerOnChangeHandler', value);
        }
    });


    // ref.$iconRef = iconRef;

    // ref.addEventListener('focus', (i) => {
    //
    //   ref.$flatpickr.close();
    // });
}


export function setDate(ref, value) {
    ref.$flatpickr.setDate(value);
}
