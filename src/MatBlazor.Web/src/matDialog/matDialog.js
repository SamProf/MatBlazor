import {MDCDialog} from '@material/dialog';


export function init(ref, component) {
  ref.matBlazorRef = new MDCDialog(ref);

  ref.addEventListener('MDCDialog:closed', () => {
    component.invokeMethodAsync('MatDialogClosedHandler');
  });

  ref.addEventListener('MDCDialog:opened', () => {
    component.invokeMethodAsync('MatDialogOpenedHandler');
  });
}

export function setIsOpen(ref, v) {
  console.log('matdialog-log-setIsOpen', !!v);
  if (v) {
    ref.matBlazorRef.open();
  } else {
    ref.matBlazorRef.close();

  }
}

export function setCanBeClosed(ref, v) {
  console.log('matdialog-log-setCanBeClosed', !!v);
  if (v) {
    ref.matBlazorRef.escapeKeyAction = 'close';
    ref.matBlazorRef.scrimClickAction = 'close';
  } else {
    ref.matBlazorRef.escapeKeyAction = '';
    ref.matBlazorRef.scrimClickAction = '';
  }
}
