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
    // debugger;
    // console.debug(menu);
    hoistMenuToBody(menu);
    ref.matBlazorRef = menu;
  } catch (e) {
    debugger;
    throw e;
  }
}

export function setAnchorElement(mdcMenu, anchorElement){
  var menu = mdcMenu.matBlazorRef;
  menu.setAnchorElement(anchorElement);
}

export function open(mdcMenu) {
  var menu = mdcMenu.matBlazorRef;
  menu.open = true;
}

export function close(mdcMenu) {
  var menu = mdcMenu.matBlazorRef;
  menu.open = false;
}

export function setState(mdcMenu, state) {
  var menu = mdcMenu.matBlazorRef;
  menu.open = state;
}

export function hoistMenuToBody(menu) {
  // debugger;
  document.body.appendChild(menu.root);
  menu.setIsHoisted(true);
}
