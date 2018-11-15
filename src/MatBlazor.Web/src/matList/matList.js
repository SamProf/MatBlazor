import './matList.scss';
import {MDCList} from '@material/list';


export class MatList extends MDCList {
  constructor(ref, options) {
    super(ref);
    this.singleSelection = options.singleSelection;
  }
}


export function init(ref, options) {
  new MatList(ref, options);
}
