import { Controller } from "@hotwired/stimulus";

export default class extends Controller {
    static targets = ['statusCheckbox', 'currentStatusString', 'newStatusString', 'apply', 'toggleAll']

    connect() {
        this.SetCheckboxes();
        this.SetToggleAllCheckbox();
        this.BuildStatusListString();
    }

    SetCheckboxes() {
        let statusList = this.currentStatusStringTarget.value.split(",")

        this.statusCheckboxTargets.forEach((checkbox) => {
            if (statusList.includes(checkbox.value)) {
                checkbox.checked = true;
            }
        })
    }

    SetToggleAllCheckbox() {
        //if all checkboxes are checked, check will be checked runs once on connect
        let statusCount = this.statusCheckboxTargets.length;
        let checkedCount = 0;

        this.statusCheckboxTargets.forEach((checkbox) => {
            if (checkbox.checked) {
                checkedCount++
            }
        })

        if (statusCount == checkedCount) this.toggleAllTarget.checked = true
    }

    ToggleAllStatuses() {
        let checkAll = false

        if (this.toggleAllTarget.checked) checkAll = true;

        this.statusCheckboxTargets.forEach((checkbox) => {
            checkbox.checked = checkAll
        })

        this.CheckStatusFilterCount()
    }

    CheckStatusFilterCount() {
        //if no status is selected, disable apply button
        let checkedCount = 0;
        let disableApply = true;

        this.statusCheckboxTargets.forEach((checkbox) => {
            if (checkbox.checked) checkedCount++

            if (checkedCount > 0) disableApply = false

            this.DisableApply(disableApply)
        })
    }

    DisableApply(disable) {
        this.applyTarget.disabled = disable;
    }

    //create comma delimeted string of statuses from checkbox interaction
    BuildStatusListString() {
        let statusListString = ""

        this.statusCheckboxTargets.forEach((checkbox) => {
            if (checkbox.checked) {
                statusListString += checkbox.value + ','
            }
        })

        //remove trailing comma
        statusListString = statusListString.slice(0, -1);

        this.newStatusStringTarget.value = statusListString
    }
}