import {windowInnerWidth} from '../utils/utils';


export var subscriptions = {};


window.addEventListener('resize', () => {
  for (var s in subscriptions) {
    if (!subscriptions.hasOwnProperty(s)) {
      continue;
    }
    var cmp = subscriptions[s];
    cmp.invokeMethodAsync('MatHiddenUpdateHandler', windowInnerWidth());
  }
});


export function init(id, cmp) {
  subscriptions[id] = cmp;
}


export function destroy(id) {
  delete subscriptions[id];
}
