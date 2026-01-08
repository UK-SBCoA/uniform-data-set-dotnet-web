import { Controller } from "https://unpkg.com/@hotwired/stimulus/dist/stimulus.js"

export default class extends Controller {
    static targets = ["primaryDx", "dependent", "validationSpan", "input"]
    static classes = ["invalid", "disabled"]

    connect() {
        this.updateFields();
    }

    setRowEnabled(enabled) {
        this.element.classList.toggle('row-disabled', !enabled);

        this.inputTargets.forEach(input => {
            input.disabled = !enabled;
            if (!enabled) {
                input.value = '';
                this.invalidClasses.forEach(cls => input.classList.remove(cls));
                this.disabledClasses.forEach(cls => input.classList.add(cls));
            } else {
                this.disabledClasses.forEach(cls => input.classList.remove(cls));
            }
        });

        if (!enabled) {
            this.validationSpanTargets.forEach(span => span.textContent = '');
        }

        if (enabled) {
            this.updateFields();
        }
    }

    updateFields() {
        if (!this.hasPrimaryDxTarget) return;
        const value = this.primaryDxTarget.value.trim();
        const primaryValue = parseInt(value, 10);
        const shouldDisable = this.primaryDxTarget.disabled || value === '' || isNaN(primaryValue) || primaryValue === 0 || primaryValue === 99;
        this.dependentTargets.forEach(input => {
            input.disabled = shouldDisable;
            if (shouldDisable) {
                input.value = '';
                this.invalidClasses.forEach(cls => input.classList.remove(cls));
                this.disabledClasses.forEach(cls => input.classList.add(cls));

                const inputCell = input.closest('td');
                const validationSpan = this.validationSpanTargets.find(span =>
                    span.closest('td') === inputCell
                );
                if (validationSpan) {
                    validationSpan.textContent = '';
                }
            } else {
                this.disabledClasses.forEach(cls => input.classList.remove(cls));
            }

        });
    }

}