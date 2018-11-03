import './matSelect.scss';
import {MDCSelect} from '@material/select';

export class MatSelect {


  constructor(ref) {
    this.select = new MDCSelect(ref);
  }
}


export function init(ref) {
  new MatSelect(ref);
}
