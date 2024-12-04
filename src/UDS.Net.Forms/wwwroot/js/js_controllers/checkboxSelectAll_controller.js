import { Controller } from "@hotwired/stimulus";

export default class extends Controller {
    static targets = ['checkBox','toggleAll']
    
    connect() {
        this.SetToggleAllCheckbox();
    }

    SetToggleAllCheckbox() {
        //if all checkboxes are checked, check will be checked runs once on connect
        let checkboxCount = this.checkBoxTargets.length;
        let checkedCount = 0;

        this.checkBoxTargets.forEach((checkbox) => {
            if (checkbox.checked) {
                checkedCount++
            }
        })

        if (checkboxCount == checkedCount) this.toggleAllTarget.checked = true
    }

    ToggleAllCheckboxes() {
        let checkAll = false

        if (this.toggleAllTarget.checked) checkAll = true;

        this.checkBoxTargets.forEach((checkbox) => {
            checkbox.checked = checkAll
        })
    }

    //if an item is selected, unselect the select all item
    ItemSelected() {
        this.toggleAllTarget.checked = false;
    }
}