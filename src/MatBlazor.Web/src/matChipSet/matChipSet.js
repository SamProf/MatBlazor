//import {MDCChipSet} from '@material/chips';
import {MDCChipSetFoundation} from '@material/chips/chip-set/foundation';

// export class MatChipSet extends MDCChipSetFoundation {
//
// }


export function init(ref, component) {
  ref.matBlazorRef = new MDCChipSetFoundation(ref);
}

// export function select(ref, chipId) {
//   // console.debug("select", {ref, chipId});
//   ref.matBlazorRef.handleChipSelection({chipId, selected: true});
// }
//
// export function deselect(ref, chipId) {
//   ref.matBlazorRef.handleChipSelection({chipId, selected: false});
// }