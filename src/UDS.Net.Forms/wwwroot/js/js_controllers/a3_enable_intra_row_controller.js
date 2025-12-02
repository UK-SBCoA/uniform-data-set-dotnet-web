import { Controller } from "@hotwired/stimulus"

export default class extends Controller {

    static targets = ["primaryDx", "dependent", "validationSpan"]
    static classes = ["invalid", "disabled"]

    connect() {
        this.updateFields();
    }

    updateFields() {
        const value = this.primaryDxTarget.value.trim();
        const primaryValue = parseInt(value, 10);
        const shouldDisable = this.primaryDxTarget.disabled || value === '' || isNaN(primaryValue) || primaryValue === 0 || primaryValue === 99;
        this.dependentTargets.forEach(input => {
            input.disabled = shouldDisable;
            if (shouldDisable) {
                input.value = '';
                this.invalidClasses.forEach(cls => input.classList.remove(cls));
                this.disabledClasses.forEach(cls => input.classList.add(cls));
            } else {
                this.disabledClasses.forEach(cls => input.classList.remove(cls));
            }

        });

        if (shouldDisable) {
            this.validationSpanTargets.forEach(span => span.textContent = '');
        }
    }

    primaryDxTargetConnected(element) {
        const observer = new MutationObserver(() => this.updateFields());
        observer.observe(element, {
            attributes: true,
            attributeFilter: ['disabled']
        });
    }
}