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
        this.addParentNeuroChangeWatch(); 
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
        this.updateParentControls(); 
    }

    adjustRowCountForSpecialCases(rowCount) {
        if (this.tableId === 'A3_Siblings' && rowCount === 77) {
            return 0; 
        }
        return rowCount; 
    }

    updateNeuroControls(index) {
        const neuValue = parseInt($(`#${this.tableId}_${index}__NEU`).val(), 10);
        const isEnabled = neuValue >= 1 && neuValue <= 5;
        $(`#${this.tableId}_${index}__PDX, #${this.tableId}_${index}__MOE, #${this.tableId}_${index}__AGO`).prop('disabled', !isEnabled);
    }

    addNeuroChangeWatch(index) {
        $(`#${this.tableId}_${index}__NEU`).change(() => {
            this.updateNeuroControls(index);
        });
    }

    addParentNeuroChangeWatch() {
        $(`#A3_MOMNEUR, #A3_DADNEUR`).change(() => {
            this.updateParentControls();
        });
    }

    updateParentControls() {
        const momNeurValue = parseInt($(`#A3_MOMNEUR`).val(), 10);
        const isMomEnabled = momNeurValue >= 1 && momNeurValue <= 5;
        $(`#A3_MOMPRDX, #A3_MOMMOE, #A3_MOMAGEO`).prop('disabled', !isMomEnabled);

        const dadNeurValue = parseInt($(`#A3_DADNEUR`).val(), 10);
        const isDadEnabled = dadNeurValue >= 1 && dadNeurValue <= 5;
        $(`#A3_DADPRDX, #A3_DADMOE, #A3_DADAGEO`).prop('disabled', !isDadEnabled);
    }
}

$(document).ready(function () {
    const siblings = new RelationshipTable('A3_Siblings', 'A3_SIBS', 20);
    const children = new RelationshipTable('A3_Children', 'A3_KIDS', 15);
});
