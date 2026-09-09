import { Controller } from "https://unpkg.com/@hotwired/stimulus/dist/stimulus.js"

export default class extends Controller {
  static targets = [
    "modeSelect",
    "modalitySelect",
    "UDSFormSubmit",
    "formRemoteReason",
    "recall",
    "intrusion"
  ]

  connect() {
    setTimeout(() => {
        this.initializeRecallStates();
    }, 50);
  }

  //look for UDSForm connection, stimulus not reloaded on turbo partial switch
  UDSFormSubmitTargetConnected() {
    //call global javascript method from unobtrusive_custom to reapply disable states
    setInputStates();
    //handle dropdown state on load
    this.HandleDropdowns();
    this.initializeRecallStates();
  }

  ChangeView() {
    if (
        (this.modeSelectTarget.value == 1 || this.modeSelectTarget.value == 2) && this.modalitySelectTarget.value != "")
    {
        this.UDSFormSubmitTarget.click();
    }
  }

  HandleDropdowns() {
    if (this.modeSelectTarget.value == 1) {
      //Disable and default modality dropdown and C2FormFooter remote reason
      this.modalitySelectTarget.value = "";
      this.formRemoteReasonTarget.value = "";
      this.modalitySelectTarget.disabled = true;
      this.formRemoteReasonTarget.disabled = true;
    } else {
      //Enable modality dropdown and C2FormFooter remote reason
      this.modalitySelectTarget.disabled = false;
      this.formRemoteReasonTarget.disabled = false;
    }
  }

  initializeRecallStates() {
      for (const recall of this.recallTargets) {
          const value = Number(recall.value);

          if (value >= 95 && value <= 98) {
              this.handleRecallInputs({ target: recall });
              break;
          }
      }
  }

  //#region Rey Auditory Verbal Learning Section

  handleRecallInputs(event) {
    const currentRecall = event.target;
    const value = Number(currentRecall.value);

    const currentIndex = this.recallTargets.indexOf(currentRecall);

    const currentIntrusion = this.intrusionTargets[currentIndex];
    const nextRecall = this.recallTargets[currentIndex + 1];

    // 95-98 disables all remaining rows
    if (value >= 95 && value <= 98) {

      if (currentIntrusion) {
        currentIntrusion.disabled = true;
        currentIntrusion.value = "";
      }

      for (let i = currentIndex + 1; i < this.recallTargets.length; i++) {

        this.recallTargets[i].disabled = true;
        this.recallTargets[i].value = "";

        this.intrusionTargets[i].disabled = true;
        this.intrusionTargets[i].value = "";
      }

      return;
    }

    // 0-15 enables INT in current row and REC in next row
    if (value >= 0 && value <= 15) {

      if (currentIntrusion) {
        currentIntrusion.disabled = false;
      }

      if (nextRecall) {
        nextRecall.disabled = false;
      }
    }
  }
  // #endregion
}