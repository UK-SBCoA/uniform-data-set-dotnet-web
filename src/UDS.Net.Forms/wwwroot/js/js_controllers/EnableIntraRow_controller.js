import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
    static values = {
        tableId: String,
        maxRows: Number
    }

    connect() {
        if (this.hasTableIdValue) {
            this.setupRowListeners();
        }

        this.setupParentListeners();
    }

    setupRowListeners() {
        for (let i = 0; i < this.maxRowsValue; i++) {
            const primaryDxInput = document.querySelector(`#${this.tableIdValue}_${i}__ETPR`);
            if (primaryDxInput) {
                primaryDxInput.addEventListener('change', () => this.updateRow(i));
                primaryDxInput.addEventListener('input', () => this.updateRow(i));
                this.updateRow(i);
            }
        }
    }

    setupParentListeners() {
        this.setupParentField('A3_MOMETPR', ['A3_MOMETSEC', 'A3_MOMMEVAL', 'A3_MOMAGEO']);
        this.setupParentField('A3_DADETPR', ['A3_DADETSEC', 'A3_DADMEVAL', 'A3_DADAGEO']);
    }

    setupParentField(primaryId, dependentIds) {
        const primaryInput = document.querySelector(`#${primaryId}`);
        if (primaryInput) {
            const update = () => this.updateFields(primaryInput, dependentIds);
            primaryInput.addEventListener('change', update);
            primaryInput.addEventListener('input', update);
            update();
        }
    }

    updateRow(index) {
        const primaryInput = document.querySelector(`#${this.tableIdValue}_${index}__ETPR`);
        const dependentIds = [
            `${this.tableIdValue}_${index}__ETSEC`,
            `${this.tableIdValue}_${index}__MEVAL`,
            `${this.tableIdValue}_${index}__AGO`
        ];
        this.updateFields(primaryInput, dependentIds);
    }

    updateFields(primaryInput, dependentIds) {
        if (!primaryInput) return;

        const primaryValue = parseInt(primaryInput.value, 10);

        const shouldDisable = (primaryValue === 0 || primaryValue === 99);

        dependentIds.forEach(id => {
            const input = document.querySelector(`#${id}`);
            if (input) {
                input.disabled = shouldDisable;
                if (shouldDisable) input.value = '';
            }
        });
    }
}