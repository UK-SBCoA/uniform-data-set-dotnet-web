import { Controller } from '@hotwired/stimulus';

export default class extends Controller {
    static targets = ['checkbox']

    connect() {
        this.checkboxTargets.forEach((checkbox) => {
            checkbox.addEventListener('change', () => this.checkboxChange(checkbox))
        })
    }

    checkboxChange(selectedCheckbox) {
        this.checkboxTargets.forEach((checkbox) => {
            if (checkbox !== selectedCheckbox) {
                checkbox.checked = false;
                checkbox.disabled = false;
            }
        })

        if (selectedCheckbox.checked) {
            selectedCheckbox.disabled = false;
        }
    }
}