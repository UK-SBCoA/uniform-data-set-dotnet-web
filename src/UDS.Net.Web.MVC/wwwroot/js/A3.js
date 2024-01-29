class RelationshipTable {
    constructor(tableId, inputId, maxRows) {
        this.tableId = tableId;
        this.inputId = inputId;
        this.maxRows = maxRows;
        this.initialize();
    }

    initialize() {
        this.updateRows();
        $(`#${this.inputId}`).on('change', () => this.updateRows());
        for (let i = 0; i < this.maxRows; i++) {
            this.updateNeuroControls(i);
            this.addNeuroChangeWatch(i);
        }
    }

    updateRows() {
        let rowCount = parseInt($(`#${this.inputId}`).val(), 10) || 0;
        rowCount = this.adjustRowCountForSpecialCases(rowCount);

        for (let i = 0; i < this.maxRows; i++) {
            const enabled = i < rowCount;
            const rowInputs = $(`#${this.tableId}_${i}__MOB, #${this.tableId}_${i}__YOB, #${this.tableId}_${i}__AGD, #${this.tableId}_${i}__NEU`);
            rowInputs.prop('disabled', !enabled);
            if (!enabled) {
                rowInputs.val(''); 
            }
            this.updateNeuroControls(i);
        }
    }

    updateNeuroControls(index) {
        const neuValue = parseInt($(`#${this.tableId}_${index}__NEU`).val(), 10);
        const isEnabled = neuValue >= 1 && neuValue <= 7;
        $(`#${this.tableId}_${index}__PDX, #${this.tableId}_${index}__MOE, #${this.tableId}_${index}__AGO`).prop('disabled', !isEnabled);
    }

    addNeuroChangeWatch(index) {
        $(`#${this.tableId}_${index}__NEU`).change(() => {
            this.updateNeuroControls(index);
        });
    }
}

$(document).ready(function () {
    const siblings = new RelationshipTable('A3_Siblings', 'A3_SIBS', 20);
    const children = new RelationshipTable('A3_Children', 'A3_KIDS', 15);
});
