import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
    static targets = [
        "modeSelect",
        "modalitySelect",
        "formMode",
        "formModality",
        "UDSFormSubmit",
        "formRemoteReason"
    ]

    //look for UDSForm connection, stimulus not reinitialized on form switch
    UDSFormSubmitTargetConnected() {
        //call global javascript method from unobtrusive_custom to reapply disable states
        setInputStates()

        //set modality values for hidden fields when new view loads a partial
        this.UpdateModalityValues()

        //handle dropdown state on load
        this.HandleDropdowns()
    }

    UpdateModalityValues() {
        this.formModeTarget.value = this.modeSelectTarget.value
        this.formModalityTarget.value = this.modalitySelectTarget.value
    }

    ChangeView() {
        if ((this.modeSelectTarget.value == 1 || this.modeSelectTarget.value == 2) && this.modalitySelectTarget.value != "") {
            this.UDSFormSubmitTarget.click()
        }
    }

    HandleDropdowns() {
        if (this.modeSelectTarget.value == 1) {
            this.modalitySelectTarget.value = ""
            this.formRemoteReasonTarget.value = ""
            this.modalitySelectTarget.disabled = true;
            this.formRemoteReasonTarget.disabled = true;
        } else {
            this.modalitySelectTarget.disabled = false;
            this.formRemoteReasonTarget.disabled = false;
        }
    }
}