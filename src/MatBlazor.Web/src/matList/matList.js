import {MDCList} from '@material/list';
import {MDCRipple} from '@material/ripple';

export class MatList extends MDCList {
  constructor(ref, options) {
    super(ref);
    this.singleSelection = options.singleSelection;
  }
}

export function init(ref, options) {
  const list = new MatList(ref, options);
  list.listElements.map((listItemEl) => new MDCRipple(listItemEl));
  ref.$list = list;
}

export function getSelectedIndex(ref) {
  let currentIndex = ref.$list.foundation.getSelectedIndex();
  return currentIndex;
}

export function setSelectedIndex(ref, index) {
  ref.$list.foundation.setSelectedIndex(index);
}

export function confirmSelection(ref) {
  const selectedItem = ref.querySelector('.mdc-list-item--selected');

  if (selectedItem) {
    // send the click. this seems to be the most compatible method of doing so.
    const dispatchMouseEvent = function (target, var_args) {
      const e = document.createEvent('MouseEvents');
      e.initEvent(...Array.prototype.slice.call(arguments, 1));
      target.dispatchEvent(e);
    };
    dispatchMouseEvent(selectedItem, 'mousedown', true, true);
  }
}
