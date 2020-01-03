import {MDCTopAppBar} from '@material/top-app-bar';


export class MatAppBar extends MDCTopAppBar {
}


export function init(ref) {
  new MatAppBar(ref);
}