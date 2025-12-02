import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
    static targets = ["row", "countInput", "input", "validationSpan"]
    static classes = ["invalid", "disabled"]
    static values = {
        maxRows: Number
    }

    connect() {
        this.updateRows();
    }

    updateRows() {
        if (!this.hasCountInputTarget) return;

        const value = this.countInputTarget.value;
        let count = parseInt(value, 10) || 0;

        if (count === 77) {
            count = 0;
        }

        this.rowTargets.forEach((row, index) => {
            const enabled = count > 0 && index < count;

            const rowInputs = this.inputTargets.filter(input =>
                row.contains(input)
            );

            rowInputs.forEach(input => {

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
                const rowValidationSpans = this.validationSpanTargets.filter(span =>
                    row.contains(span)
                );
                rowValidationSpans.forEach(span => {
                    span.textContent = '';
                });
            }
        });
    }
}