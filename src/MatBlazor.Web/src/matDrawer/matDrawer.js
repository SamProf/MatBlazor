import './matDrawer.scss';
import {MDCDrawer} from '@material/drawer';


export class MatDrawer extends MDCDrawer {
  constructor(ref, options) {
    super(ref);
  }
}


export function init(ref, options) {
  new MatDrawer(ref, options);
}
