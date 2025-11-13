import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
    static values = {
        countInputId: String,
        tableId: String,
        maxRows: Number
    }

    connect() {
        const input = document.querySelector(`#${this.countInputIdValue}`);
        this.boundUpdateRows = this.updateRows.bind(this);
        input.addEventListener("input", this.boundUpdateRows);
        input.addEventListener("change", this.boundUpdateRows);
        this.updateRows();
    }

    disconnect() {
        const input = document.querySelector(`#${this.countInputIdValue}`);
        if (input && this.boundUpdateRows) {
            input.removeEventListener("input", this.boundUpdateRows);
            input.removeEventListener("change", this.boundUpdateRows);
        }
    }

    updateRows() {
        const input = document.querySelector(`#${this.countInputIdValue}`);
        const value = input?.value;

        let count = parseInt(value, 10) || 0;

        if ((this.tableIdValue === 'A3_Siblings' || this.tableIdValue === 'A3_Children') && count === 77) {
            count = 0;
        }

        for (let i = 0; i < this.maxRowsValue; i++) {
            const enabled = count > 0 && i < count;

            const rowInputs = [
                document.querySelector(`#${this.tableIdValue}_${i}__YOB`),
                document.querySelector(`#${this.tableIdValue}_${i}__AGD`),
                document.querySelector(`#${this.tableIdValue}_${i}__ETPR`),
                document.querySelector(`#${this.tableIdValue}_${i}__ETSEC`),
                document.querySelector(`#${this.tableIdValue}_${i}__MEVAL`),
                document.querySelector(`#${this.tableIdValue}_${i}__AGO`)
            ].filter(el => el !== null); 
            
            rowInputs.forEach(el => {
                el.disabled = !enabled;

                if (!enabled) {
                    el.value = '';
                }
            });
        }
    }
}