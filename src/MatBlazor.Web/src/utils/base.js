export var matBlazorInstance = '$matBlazorInstance';

export function getMatBlazorInstance(element) {
  if (element) {
    return element[matBlazorInstance];
  }
}

export function setMatBlazorInstance(element, instance) {
  if (element) {
    element[matBlazorInstance] = instance;
    return instance;
  }
}
