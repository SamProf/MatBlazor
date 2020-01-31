import * as matRipple from '../matRipple/matRipple';
import '../utils/base';
import {getMatBlazorInstance, MatBlazorComponent} from "../utils/base";


export interface IMatFileUploadEntry {
    info: IMatFileUploadEntryInfo;
    file: any;
    arrayBufferPromise?: Promise<ArrayBuffer>;
}

export interface IMatFileUploadEntryInfo {
    id: number;
    lastModified: Date;
    name: string;
    size: number;
    type: string;
}

export class MatFileUpload extends MatBlazorComponent {

    files: IMatFileUploadEntry[] = [];

    constructor(ref, private inputRef: HTMLInputElement, private componentRef) {
        super(ref);
        matRipple.init(this.ref);

        this.inputRef.addEventListener('change', (event) => {

            // console.log('this.inputRef', this.inputRef);
            var items = Array.from(this.inputRef.files).map((file) => {
                var info = <IMatFileUploadEntryInfo>{
                    id: this.files.length,
                    lastModified: new Date(file.lastModified),
                    name: file.name,
                    size: file.size,
                    type: file.type
                };
                this.files.push(<IMatFileUploadEntry>{
                    info: info,
                    file: file,
                });

                return info;
            });

            this.componentRef.invokeMethodAsync('NotifyChange', items).then(null, function (err) {
                throw new Error(err);
            });
        });


    }


    readDataAsArrayBufferAsync(entry: IMatFileUploadEntry): Promise<ArrayBuffer> {
        if (!entry.arrayBufferPromise) {
            entry.arrayBufferPromise = readAsArrayBufferAsync(entry.file);
        }
        return entry.arrayBufferPromise;
    }


    async readDataAsync(fileId: number, position: number, count: number): Promise<string> {
        // console.log('readDataAsync2 1');
        var entry = this.files[fileId];
        // console.log('readDataAsync2 11', entry);
        var arrayBuffer = await this.readDataAsArrayBufferAsync(entry);
        // console.log('readDataAsync2 2', arrayBuffer);
        var uint8Array = new Uint8Array(arrayBuffer, position, Math.min(count, arrayBuffer.byteLength - position));
        var data = uint8ToBase64()(uint8Array);
        // console.log('readDataAsync 3', data);
        return data;

    }
}


export function init(ref, inputRef, componentRef) {
    new MatFileUpload(ref, inputRef, componentRef);
}


export async function readDataAsync(ref, fileId: number, position: number, count: number): Promise<string> {
    try {
        // console.log("Request", position.toLocaleString());
        var componentRef = getMatBlazorInstance<MatFileUpload>(ref);
        // console.log("readDataAsync getMatBlazorInstance", componentRef)
        var result = await componentRef.readDataAsync(fileId, position, count);
        // console.log("readDataAsync readDataAsync", result)
        // console.log(result);
        // console.log("Response", position.toLocaleString());
        return result;
    } catch (e) {
        // console.log('readDataAsync error', e);
        throw e;
    }
}

// export function readDataAsync2(ref, fileId: number, position: number, count: number): Promise<string> {
//     return new Promise<string>((resolve, reject)=>{
//         resolve("qqq");
//     });
// }


export function readAsArrayBufferAsync(file): Promise<ArrayBuffer> {
    return new Promise<ArrayBuffer>((resolve, reject) => {
        var reader = new FileReader();
        reader.onload = function () {
            resolve(<ArrayBuffer>reader.result);
        };
        reader.onerror = function (err) {
            reject(err);
        };
        reader.readAsArrayBuffer(file);
    });
}

//
// /**
//  * @property {MatFileUploadItem[]} items
//  */
// class MatFileUpload {
//   ref;
//   inputRef;
//   jsHelper;
//   items;
//   nextItemId;
//
//   constructor(ref, inputRef, jsHelper) {
//     this.ref = ref;
//     this.inputRef = inputRef;
//     this.jsHelper = jsHelper;
//     this.items = {};
//     this.nextItemId = 0;
//   }
//
//
//   init() {
//     matRipple.init(this.ref);
//
//
//     // this.inputRef.addEventListener('change', (event) => {
//     //
//     //   var items = this.inputRef.files.map((file) => {
//     //     var item = {
//     //       id: ++this.nextItemId,
//     //       lastModified: new Date(file.lastModified).toISOString(),
//     //       name: file.name,
//     //       size: file.size,
//     //       type: file.type
//     //     };
//     //     elem._blazorFilesById[result.id] = result;
//     //
//     //     // Attach the blob data itself as a non-enumerable property so it doesn't appear in the JSON
//     //     Object.defineProperty(result, 'blob', {value: file});
//     //
//     //     return result;
//     //   });
//     //
//     //   componentInstance.invokeMethodAsync('NotifyChange', fileList).then(null, function (err) {
//     //     throw new Error(err);
//     //   });
//     // });
//
//
//   }
//
//
// }
//
//
// class MatFileUploadItem {
//
//   entry;
//   file;
//
//   /**
//    * @param {MatFileUploadItem} config
//    */
//
//   constructor(config) {
//     Object.assign(this, config);
//   }
// }
//
//
// class MatFileUploadEntry {
//   id;
//   lastModified;
//   name;
//   size;
//   type;
// }
//
//
// export function init(ref, inputRef, jsHelper) {
//   var instance = setMatBlazorInstance(ref, new MatFileUpload(ref, inputRef, jsHelper));
//   return instance.init();
// };
//
// export function readFileData(elem, fileId, startOffset, count) {
//
//   return '123';
//   var readPromise = getArrayBufferFromFileAsync(elem, fileId);
//
//   return readPromise.then(function (arrayBuffer) {
//
//     var uint8Array = new Uint8Array(arrayBuffer, startOffset, count);
//     var base64 = uint8ToBase64(uint8Array);
//     console.log('readFileData', base64);
//     return base64;
//   });
// };
//
// export function ensureArrayBufferReadyForSharedMemoryInterop(elem, fileId) {
//   return getArrayBufferFromFileAsync(elem, fileId).then(function (arrayBuffer) {
//     getFileById(elem, fileId).arrayBuffer = arrayBuffer;
//   });
// };
//
// export function readFileDataSharedMemory(readRequest) {
//   // This uses various unsupported internal APIs. Beware that if you also use them,
//   // your code could become broken by any update.
//   var inputFileElementReferenceId = Blazor.platform.readStringField(readRequest, 0);
//   var inputFileElement = document.querySelector('[_bl_' + inputFileElementReferenceId + ']');
//   var fileId = Blazor.platform.readInt32Field(readRequest, 4);
//   var sourceOffset = Blazor.platform.readUint64Field(readRequest, 8);
//   var destination = Blazor.platform.readInt32Field(readRequest, 16);
//   var destinationOffset = Blazor.platform.readInt32Field(readRequest, 20);
//   var maxBytes = Blazor.platform.readInt32Field(readRequest, 24);
//
//   var sourceArrayBuffer = getFileById(inputFileElement, fileId).arrayBuffer;
//   var bytesToRead = Math.min(maxBytes, sourceArrayBuffer.byteLength - sourceOffset);
//   var sourceUint8Array = new Uint8Array(sourceArrayBuffer, sourceOffset, bytesToRead);
//
//   var destinationUint8Array = Blazor.platform.toUint8Array(destination);
//   destinationUint8Array.set(sourceUint8Array, destinationOffset);
//
//   return bytesToRead;
// };
//
// function getFileById(elem, fileId) {
//   var file = elem._blazorFilesById[fileId];
//   if (!file) {
//     throw new Error('There is no file with ID ' + fileId + '. The file list may have changed');
//   }
//
//   return file;
// }
//
// function getArrayBufferFromFileAsync(elem, fileId) {
//   var file = getFileById(elem, fileId);
//
//   // On the first read, convert the FileReader into a Promise<ArrayBuffer>
//   if (!file.readPromise) {
//     file.readPromise = new Promise(function (resolve, reject) {
//       var reader = new FileReader();
//       reader.onload = function () {
//         resolve(reader.result);
//       };
//       reader.onerror = function (err) {
//         reject(err);
//       };
//       reader.readAsArrayBuffer(file.blob);
//     });
//   }
//
//   return file.readPromise;
// }
//
var uint8ToBase64 = (function () {
    // Code from https://github.com/beatgammit/base64-js/
    // License: MIT
    var lookup = [];

    var code = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/';
    for (var i = 0, len = code.length; i < len; ++i) {
        lookup[i] = code[i];
    }

    function tripletToBase64(num) {
        return lookup[num >> 18 & 0x3F] +
            lookup[num >> 12 & 0x3F] +
            lookup[num >> 6 & 0x3F] +
            lookup[num & 0x3F];
    }

    function encodeChunk(uint8, start, end) {
        var tmp;
        var output = [];
        for (var i = start; i < end; i += 3) {
            tmp =
                ((uint8[i] << 16) & 0xFF0000) +
                ((uint8[i + 1] << 8) & 0xFF00) +
                (uint8[i + 2] & 0xFF);
            output.push(tripletToBase64(tmp));
        }
        return output.join('');
    }

    return function fromByteArray(uint8) {
        var tmp;
        var len = uint8.length;
        var extraBytes = len % 3; // if we have 1 byte left, pad 2 bytes
        var parts = [];
        var maxChunkLength = 16383; // must be multiple of 3

        // go through the array every three bytes, we'll deal with trailing stuff later
        for (var i = 0, len2 = len - extraBytes; i < len2; i += maxChunkLength) {
            parts.push(encodeChunk(
                uint8, i, (i + maxChunkLength) > len2 ? len2 : (i + maxChunkLength)
            ));
        }

        // pad the end with zeros, but make sure to not forget the extra bytes
        if (extraBytes === 1) {
            tmp = uint8[len - 1];
            parts.push(
                lookup[tmp >> 2] +
                lookup[(tmp << 4) & 0x3F] +
                '=='
            );
        } else if (extraBytes === 2) {
            tmp = (uint8[len - 2] << 8) + uint8[len - 1];
            parts.push(
                lookup[tmp >> 10] +
                lookup[(tmp >> 4) & 0x3F] +
                lookup[(tmp << 2) & 0x3F] +
                '='
            );
        }

        return parts.join('');
    };
});

