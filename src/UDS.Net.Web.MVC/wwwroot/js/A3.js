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
    }

    updateRows() {
        const rowCount = parseInt($(`#${this.inputId}`).val(), 10) || 0;
        console.log(`Updating rows for ${this.tableId} with rowCount: ${rowCount}`);
        for (let i = 0; i < this.maxRows; i++) {
            if (i < rowCount) {
                $(`#${this.tableId}_${i}__MOB`).prop('disabled', false);
                $(`#${this.tableId}_${i}__YOB`).prop('disabled', false);
                $(`#${this.tableId}_${i}__AGD`).prop('disabled', false);
                $(`#${this.tableId}_${i}__NEU`).prop('disabled', false);

            } else {
                $(`#${this.tableId}_${i}__MOB`).prop('disabled', true);
                $(`#${this.tableId}_${i}__YOB`).prop('disabled', true);
                $(`#${this.tableId}_${i}__AGD`).prop('disabled', true);
                $(`#${this.tableId}_${i}__NEU`).prop('disabled', true);
            }
        }
    }
}

$(document).ready(function () {
    const siblings = new RelationshipTable('A3_Siblings', 'A3_SIBS', 20);
    const children = new RelationshipTable('A3_Children', 'A3_KIDS', 15);
});
