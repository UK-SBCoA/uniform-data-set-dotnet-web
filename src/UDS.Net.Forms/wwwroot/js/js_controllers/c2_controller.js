import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
    static targets = [
        "modeSelect",
        "modalitySelect",
        "UDSFormSubmit",
        "formRemoteReason"
    ]

    //look for UDSForm connection, stimulus not reinitialized on form switch
    UDSFormSubmitTargetConnected() {
        //call global javascript method from unobtrusive_custom to reapply disable states
        setInputStates()

        //handle dropdown state on load
        this.HandleDropdowns()
    }

    ChangeView() {
        if ((this.modeSelectTarget.value == 1 || this.modeSelectTarget.value == 2) && this.modalitySelectTarget.value != "") {
            this.UDSFormSubmitTarget.click()
        }
    }

    HandleDropdowns() {
        if (this.modeSelectTarget.value == 1) {
            //Disable and default modality dropdown and C2FormFooter remote reason
            this.modalitySelectTarget.value = ""
            this.formRemoteReasonTarget.value = ""
            this.modalitySelectTarget.disabled = true;
            this.formRemoteReasonTarget.disabled = true;
        } else {
            //Enable modality dropdown and C2FormFooter remote reason
            this.modalitySelectTarget.disabled = false;
            this.formRemoteReasonTarget.disabled = false;
        }
    }
}