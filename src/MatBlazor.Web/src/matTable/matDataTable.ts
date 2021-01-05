import {MatBlazorComponent} from "../utils/base";
import {MDCDataTable} from '@material/data-table';

class MatDataTable extends MatBlazorComponent {

    table: MDCDataTable;

    constructor(ref: HTMLElement) {
        super(ref);
        this.table = new MDCDataTable(ref);
    }
}

export function init(ref) {
    new MatDataTable(ref);
}
