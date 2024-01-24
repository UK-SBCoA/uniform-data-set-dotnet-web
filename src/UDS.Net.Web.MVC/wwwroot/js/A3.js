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

        for (let i = 1; i <= this.maxRows; i++) {
            const neruoHasValue = this.GetRow(i).find('input[name$=PrimaryNeurologicalProblemPsychiatricCondition]').first().val();
            if (neruoHasValue && neruoHasValue != 8 && neruoHasValue != 9) {
                this.EnableNeuroControls(i);
            } else {
                this.DisableNeuroControls(i);
            }
            this.AddNeruoPsychInputWatch(i);
        }
    }

    updateRows() {
        const rowCount = parseInt($(`#${this.inputId}`).val(), 10) || 0;
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

    EnableNeuroControls(relationshipIndex) {
        const jRow = this.GetRow(relationshipIndex);
        jRow.find('input[data-neurocon]').prop('readonly', false);
    }

    DisableNeuroControls(relationshipIndex) {
        const jRow = this.GetRow(relationshipIndex);
        jRow.find('input[data-neurocon]').prop('readonly', true);
    }

    AddNeruoPsychInputWatch(relationshipIndex) {
        const jRow = this.GetRow(relationshipIndex);
        const neuroWatch = jRow.find('input[name$="PrimaryNeurologicalProblemPsychiatricCondition"]').first();
        neuroWatch.on('keydown keyup', (events) => {
            if ($(events.target).val() == '' || $(events.target).val() == 8 || $(events.target).val() == 9) {
                this.DisableNeuroControls(relationshipIndex);
            } else {
                this.EnableNeuroControls(relationshipIndex);
            }
        });
    }

    GetRow(index) {
        return $(`#${this.tableId}_Row${index}`);
    }
}

$(document).ready(function () {
    const siblings = new RelationshipTable('A3_Siblings', 'A3_SIBS', 20);
    const children = new RelationshipTable('A3_Children', 'A3_KIDS', 15);
});
