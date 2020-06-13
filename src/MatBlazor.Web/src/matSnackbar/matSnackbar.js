import {MDCSnackbar} from '@material/snackbar/component';


export function init(ref, component) {
  ref.matBlazorRef = new MDCSnackbar(ref);
  ref.matBlazorRef.timeoutMs = -1; // -1 ... disable, we do the timeout on .NET side for more control

  ref.addEventListener('MDCSnackbar:closed', () => {
    component.invokeMethodAsync('MatSnackbarClosedHandler');
  });
}

export function setIsOpen(ref, v) {
  if (v) {
    ref.matBlazorRef.open();
  } else {
    ref.matBlazorRef.close();
  }
}
