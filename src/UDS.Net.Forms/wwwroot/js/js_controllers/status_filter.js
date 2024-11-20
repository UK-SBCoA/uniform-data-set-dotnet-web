import { Controller } from "@hotwired/stimulus";

export default class extends Controller {
    static targets = ['statusCheckbox', 'statusString', 'apply']

    connect() {
        this.SetCheckboxes();
    }

    SetCheckboxes() {
        let checkboxElements = this.statusCheckboxTargets
        let statusList = this.statusStringTarget.value.split(",")

        checkboxElements.forEach((checkbox) => {
            if (statusList.includes(checkbox.value)) {
                checkbox.checked = true;
            }
        })
    }

    CheckStatusFilterCount() {
        let checkboxElements = this.statusCheckboxTargets
        let checkedCount = 0;
        let disableApply = true;

        checkboxElements.forEach((checkbox) => {
            if (checkbox.checked) checkedCount++

            if (checkedCount > 0) disableApply = false

            this.DisableApply(disableApply)
        })
    }

    DisableApply(disable) {
        this.applyTarget.disabled = disable;
    }
}