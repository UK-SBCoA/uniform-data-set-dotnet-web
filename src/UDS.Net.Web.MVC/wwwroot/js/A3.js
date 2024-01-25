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
        const rowCount = parseInt($(`#${this.inputId}`).val(), 10) || 0;
        for (let i = 0; i < this.maxRows; i++) {
            const enabled = i < rowCount;
            $(`#${this.tableId}_${i}__MOB`).prop('disabled', !enabled);
            $(`#${this.tableId}_${i}__YOB`).prop('disabled', !enabled);
            $(`#${this.tableId}_${i}__AGD`).prop('disabled', !enabled);
            $(`#${this.tableId}_${i}__NEU`).prop('disabled', !enabled);
            this.updateNeuroControls(i);
        }
    }

    updateNeuroControls(index) {
        const neuValue = parseInt($(`#${this.tableId}_${index}__NEU`).val(), 10);
        const isEnabled = neuValue >= 1 && neuValue <= 7;
        $(`#${this.tableId}_${index}__PDX`).prop('disabled', !isEnabled);
        $(`#${this.tableId}_${index}__MOE`).prop('disabled', !isEnabled);
        $(`#${this.tableId}_${index}__AGO`).prop('disabled', !isEnabled);
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
