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

    updateFields(primaryXd) {
        const primaryValue = parseInt(primaryXd.value, 10);
        const shouldDisable = (primaryValue === 0 || primaryValue === 99);

        const row = primaryXd.closest('tr');

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