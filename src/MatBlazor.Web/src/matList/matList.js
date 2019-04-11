import './matList.scss';
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
}
