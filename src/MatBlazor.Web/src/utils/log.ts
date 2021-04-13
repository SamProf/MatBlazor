import {environment} from "./environment";

export function log(...a: any[]) {
    if (environment.debugMode) {
        console.log.apply(console.log, a);
    }
}
