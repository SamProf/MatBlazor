import {MDCMenu} from '@material/menu';
import {Corner} from '@material/menu-surface/constants';

export class MatMenu extends MDCMenu {
  constructor(ref) {
    super(ref);
  }
}


export function init(ref) {
  try {
    var menu = new MatMenu(ref);
    hoistMenuToBody(menu);
    ref.matBlazorRef = menu;
  } catch (e) {
    debugger;
    throw e;
  }
}


export function open(mdcMenu, anchorElement) {
  var menu = mdcMenu.matBlazorRef;
  menu.setAnchorElement(anchorElement);
  menu.open = true;
}

export function hoistMenuToBody(menu) {
  document.body.appendChild(menu.root_);
  menu.setIsHoisted(true);
}
