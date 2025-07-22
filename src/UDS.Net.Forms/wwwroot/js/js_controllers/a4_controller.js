import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
  static targets = ["anyMeds", "search", "popularDrug", "otcDrug", "customDrug"];

  connect() {
    this.setEnabledDisabledState();
  }

  setEnabledDisabled(disable) {
    if (this.hasSearchTarget) {
      this.searchTargets.forEach(component => {
        component.disabled = disable;
      });
    }
    if (this.hasPopularDrugTarget) {
      this.popularDrugTargets.forEach(drug => {
        drug.disabled = disable;
      });
    }
    if (this.hasOtcDrugTarget) {
      this.otcDrugTargets.forEach(drug => {
        drug.disabled = disable;
      });
    }
    if (this.hasCustomDrugTarget) {
      this.customDrugTargets.forEach(drug => {
        drug.disabled = disable;
      });
    }
  }

  setEnabledDisabledState() {
    if (this.hasAnyMedsTarget) {
      const selectedAnyMeds = this.anyMedsTargets.find(radio => radio.checked);

      // Disabled if nothing or 0 is selected
      if (selectedAnyMeds == null) {
        this.setEnabledDisabled(true);
      }
      else if (selectedAnyMeds.value == '0') {
        this.setEnabledDisabled(true);
      }
      else {
        this.setEnabledDisabled(false);
      }
    }
  }
}