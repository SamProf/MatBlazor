import {MDCChip} from '@material/chips';


export function init(ref, component) {
  ref.matBlazorRef = new MDCChip(ref);
  ref.matBlazorRef.shouldRemoveOnTrailingIconClick = false; // handle Chip removal in .NET

  ref.addEventListener('MDCChip:interaction', (ev) => {
    component.invokeMethodAsync('MatChipInteractionHandler', ev.detail.chipId);
  });
  // ref.addEventListener('MDCChip:selection', (ev) => {
  //   component.invokeMethodAsync('MatChipSelectionHandler', ev.detail.chipId, ev.detail.selected);
  // });
  // ref.addEventListener('MDCChip:removal', (ev) => {
  //   component.invokeMethodAsync('MatChipRemovalHandler', ev.detail.chipId, ev.detail.removedAnnouncement);
  // });
  ref.addEventListener('MDCChip:trailingIconInteraction', (ev) => {
    component.invokeMethodAsync('MatChipTrailingIconInteractionHandler', ev.detail.chipId);
  });
  // ref.addEventListener('MDCChip:navigation', (ev) => {
  //   component.invokeMethodAsync('MatChipNavigationHandler', ev.detail.chipId, ev.detail.key);
  // });
}

// export function setSelected(ref, selected) {
//   console.debug("setSelected", selected);
//   ref.matBlazorRef.setSelectedFromChipSet(selected, false);
// }