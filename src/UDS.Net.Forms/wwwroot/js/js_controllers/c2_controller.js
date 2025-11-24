import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
    static targets = [
        "modeSelect",
        "modalitySelect",
        "formMode",
        "formModality",
        "UDSFormSubmit"
    ]

    //look for UDSForm connection instad of target because stimulus does not reinitialize for the c2.cshtml
    UDSFormSubmitTargetConnected() {
        //call global javascript method from unobtrusive_custom to reapply disable states
        setInputStates()

        //set modality values for hidden fields when new view loads a partial
        this.UpdateModalityValues()
    }

    UpdateModalityValues() {
        this.formModeTarget.value = this.modeSelectTarget.value
        this.formModalityTarget.value = this.modalitySelectTarget.value
    }

    ChangeView() {
        if (this.modeSelectTarget.value == 2 && this.modalitySelectTarget.value == "--") {
            console.log("not changing view yet")
        } else {
            this.UDSFormSubmitTarget.click()
        }
    }

    SubmitUDSForm() {
        // will need to run action when either 1. InPerson mode is selected or 2. mode is remote & modality is selected
    }
}