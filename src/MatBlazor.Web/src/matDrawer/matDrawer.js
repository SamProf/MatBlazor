import './matDrawer.scss';
import {MDCDrawer} from '@material/drawer/index';



export class MatDrawer extends MDCDrawer {
  constructor(ref, options) {
    super(ref);
    this.open = true;
  }
}


export function init(ref, options) {
  new MatDrawer(ref);
}
