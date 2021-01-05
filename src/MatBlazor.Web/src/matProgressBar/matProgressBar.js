import {MDCLinearProgress} from '@material/linear-progress/component';


export function init(ref) {
  ref.matBlazorRef = new MDCLinearProgress(ref);
}

export function setProgress(ref, value) {
  // console.log("setProgress", value);
  ref.matBlazorRef.progress = value;
}

export function setBuffer(ref, value) {
  // console.log("setBuffer", value);
  ref.matBlazorRef.buffer = value;
}
