import { MDCCircularProgress } from '@material/circular-progress';

export function init(ref) {
    ref.matBlazorRef = new MDCCircularProgress(ref);
}

export function setProgress(ref, value) {
    ref.matBlazorRef.progress = value;
}