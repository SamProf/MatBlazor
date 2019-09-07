import './matAutocomplete.scss';

export class MatAutocomplete {
  handleKeyEvent(e) {
    e = e || window.event;
    // get popup
    const list = document.querySelector('.mat-autocomplete-popup').children[0];

    if (list) {
      // arrows up/down and enter
      if (e.keyCode === 38 || e.keyCode === 40 || e.keyCode === 13) {
        // ENTER select item
        if (e.keyCode === 13) {
          const selectedItem = list.querySelector('.mdc-list-item--selected');
          if (selectedItem) {
            // TODO refactor, how compatible is this?
            const dispatchMouseEvent = function (target, var_args) {
              const e = document.createEvent('MouseEvents');
              e.initEvent(...Array.prototype.slice.call(arguments, 1));
              target.dispatchEvent(e);
            };
            dispatchMouseEvent(selectedItem, 'mousedown', true, true);
          }
        } else {
          // Arrow keys
          let selectedItem = list.querySelector('.mdc-list-item--selected');
          let index = -1;
          if (selectedItem) {
            // get selected index and deselect
            index = Array.prototype.indexOf.call(
              list.querySelectorAll('.mdc-list-item'),
              selectedItem
            );
            selectedItem.classList.remove('mdc-list-item--selected');
          }
          // handle up/down
          if (e.keyCode === 38 && index > 0) {
            index--;
          } else if (e.keyCode === 40 && index < list.querySelectorAll('.mdc-list-item').length - 1) {
            index++;
          }

          selectedItem = list.querySelectorAll('.mdc-list-item')[index];
          selectedItem.classList.add('mdc-list-item--selected');
        }

        // prevent event bubbling
        if (e && e.preventDefault) {
          e.preventDefault();
          e.stopPropagation();
        } else if (window.event && window.event.returnValue) {
          window.event.returnValue = false;
        }
      }
    }
  }

  constructor(textFieldRef) {
    textFieldRef.onkeydown = (e) => this.handleKeyEvent(e);
  }
}

export function init(textFieldRef) {
  new MatAutocomplete(textFieldRef);
}
