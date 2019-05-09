import './matTabBar.scss';
import {MDCTabBar} from '@material/tab-bar/component';


export function init(ref, component) {
  ref.matBlazorRef = new MDCTabBar(ref);

  // ref.addEventListener('MDCDialog:closed', () => {
  //   component.invokeMethodAsync('MatDialogClosedHandler');
  // });
}
