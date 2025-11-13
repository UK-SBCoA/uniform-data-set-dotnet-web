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
                    el.classList.add("opacity-50", "cursor-not-allowed");
                    el.value = '';
                } else {
                    el.classList.remove("opacity-50", "cursor-not-allowed");
                }
            });

            if (rowInputs.length > 0) {
                const row = rowInputs[0].closest('tr');
                if (row) {
                    if (!enabled) {
                        row.classList.add("bg-gray-100");
                        row.style.opacity = "0.6";
                    } else {
                        row.classList.remove("bg-gray-100");
                        row.style.opacity = "1";
                    }
                }
            }
        }
    }
}