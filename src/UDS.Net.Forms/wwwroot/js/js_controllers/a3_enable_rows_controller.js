import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
  static targets = ["row", "countInput", "input", "validationSpan"]
  static classes = ["invalid", "disabled"]
  static outlets = ["a3-enable-intra-row"]
  static values = {
    maxRows: Number 
  }

    connect() {
        setTimeout(() => this.updateRows(), 0);
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
            row.classList.toggle('row-disabled', !enabled);
            this.toggleRowInputs(row, enabled);
        });
        }

        toggleRowInputs(row, enabled) {
        this.inputTargets.forEach(input => {
            if (row.contains(input)) {
            this.updateInput(input, enabled);
            }
        });

        this.validationSpanTargets.forEach(span => {
            if (row.contains(span) && !enabled) {
            span.textContent = '';
            }
        });

        this.a3EnableIntraRowOutlets.forEach(outlet => {
            const rowElement = outlet.element;
            const enabled = !rowElement.classList.contains('row-disabled');
            if (enabled) {
                outlet.updateFields();
            }
        });
    }

    updateInput(input, enabled) {
    input.disabled = !enabled;
    if (!enabled) {
        input.value = '';
        this.invalidClasses.forEach(cls => input.classList.remove(cls));
        this.disabledClasses.forEach(cls => input.classList.add(cls));

    } else {
        this.disabledClasses.forEach(cls => input.classList.remove(cls));
    }
  }
}