import './matTabBar.scss';


export function init(ref, component) {
  ref.matBlazorRef = new MDCTabBar(ref);

  // ref.addEventListener('MDCDialog:closed', () => {
  //   component.invokeMethodAsync('MatDialogClosedHandler');
  // });
}
