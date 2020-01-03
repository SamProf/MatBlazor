import {MDCTabBar} from '@material/tab-bar/component';
import {MDCTabScroller} from '@material/tab-scroller/component';

// alert('WAW');

export function init(ref, component) {
  // console.log('matTabBar init');
  // ref.matBlazorRef = new MDCTabBar(ref);
  var scrollers = ref.getElementsByClassName('mdc-tab-scroller');
  // console.log('scrollers', scrollers);
  if (scrollers && scrollers.length) {
    // console.log('scroller activated', scrollers[0]);
    new MDCTabScroller(scrollers[0]);
  }

  // ref.addEventListener('MDCDialog:closed', () => {
  //   component.invokeMethodAsync('MatDialogClosedHandler');
  // });
}
