import './matMenu.scss';
import {MDCMenu} from '@material/menu';

export class MatMenu extends MDCMenu {
  constructor(ref) {
    super(ref);
  }
}


export function init(ref) {
  try {
    var menu = new MatMenu(ref);
    menu.hoistMenuToBody();
    ref.matBlazorRef = menu;
  } catch (e) {
    debugger;
    throw e;
  }
}


export function open(mdcMenu, anchorElement) {
  debugger;
  var menu = mdcMenu.matBlazorRef;
  menu.setAnchorElement(anchorElement);
  menu.open = true;
}
