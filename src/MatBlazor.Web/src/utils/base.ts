export var matBlazorInstance = '$matBlazorInstance';

export function getMatBlazorInstance<T>(element : HTMLElement): T {
    if (element) {
        return element[matBlazorInstance];
    }
}


export function setMatBlazorInstance<T>(element : HTMLElement, instance: T): T {
    if (element) {
        element[matBlazorInstance] = instance;
        return instance;
    }
}


export class MatBlazorComponent {
    constructor(public ref : HTMLElement) {
        setMatBlazorInstance(ref, this);
    }
}



