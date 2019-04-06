import './matDialog.scss';

import {MDCDialog} from '@material/dialog';


export function init(ref, component) {
  ref.matBlazorRef = new MDCDialog(ref);
  // ref.addEventListener('MDCDrawer:closed', () => {
  //   component.invokeMethodAsync('ClosedHandler');
  // });
}


export function setIsOpen(ref, v) {
  if (v) {
    ref.matBlazorRef.open();
  } else {
    ref.matBlazorRef.close();

  }
}
