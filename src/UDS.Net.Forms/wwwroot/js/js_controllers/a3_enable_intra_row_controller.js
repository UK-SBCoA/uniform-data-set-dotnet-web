import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
    static targets = ["primaryDx", "dependent"]

    connect() {
        this.updateAllFields();
    }

    updateAllFields() {
        this.primaryDxTargets.forEach(element => {
            this.updateFields(element);
        });
    }

    updateFields(primaryDx) {
        const value = primaryDx.value.trim();
        const primaryValue = parseInt(value, 10);

        const shouldDisable = value === '' || isNaN(primaryValue) || primaryValue === 0 || primaryValue === 99;

        const row = primaryDx.closest('tr');
        if (!row) return;

        const dependentInputs = this.dependentTargets.filter(input =>
            row.contains(input)
        );

        dependentInputs.forEach(input => {
            input.disabled = shouldDisable;
            if (shouldDisable) {
                input.value = '';
            }
        });
    }

    handlePrimaryChange(event) {
        this.updateFields(event.target);
    }
}