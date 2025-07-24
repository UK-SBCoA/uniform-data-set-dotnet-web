import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
  static targets = ["anyMeds", "search", "searchResult", "popularDrug", "otcDrug", "customDrug", "checkbox"];

  static values = {
    url: String,
    reset: String
  }

  connect() {
    this.setEnabledDisabledState();
  }

  setEnabledDisabled(disable) {
    if (this.hasSearchTarget) {
      this.searchTargets.forEach(component => {
        component.disabled = disable;
      });
    }
    if (this.hasCheckboxTarget) {
      this.checkboxTargets.forEach(checkbox => {
        checkbox.disabled = disable;
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

  findDrug(rxCUI) {
    let isExisting = false;
    if (this.hasCheckboxTarget) {
      this.checkboxTargets.forEach(checkbox => {
        if (checkbox.value == rxCUI) {
          checkbox.checked = true;
          isExisting = true;
        }
      })
    }
    return isExisting;
  }

  //customDrugTargetConnected(element) {
  //  console.log("connected ", element);
  //}

  async selectDrug(event) {
    const selectedResult = event.target.value; // the rxCUI
    // figure out if the rxcui is existing or new
    const existingDrug = this.findDrug(selectedResult);
    if (existingDrug == true) {
      // reset _RxNorm turbo frame back to search input
      fetch(this.resetValue, {
        method: "GET",
        headers: {
          "Accept": "text/vnd.turbo-stream.html"
        }
      }).then(response => response.text())
        .then(html => {
          Turbo.renderStreamMessage(html)
        })
        .catch(error => console.error("POST error:", error));
    }
    else {
      // post with all drug lists

      const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value;
      const formData = new FormData();

      // add existing checkboxes to form body
      this.popularDrugTargets.forEach(input => {
        formData.append(input.name, input.value);
      });
      this.otcDrugTargets.forEach(input => {
        formData.append(input.name, input.value);
      });
      this.customDrugTargets.forEach(input => {
        formData.append(input.name, input.value);
      });
      if (this.hasCheckboxTarget) {
        this.checkboxTargets.forEach(checkbox => {
          if (checkbox.checked) {
            formData.append(checkbox.name, checkbox.value);
          }
        })
      }

      // add new drug to form body
      formData.append("rxCUI", selectedResult);
      if (this.hasSearchResultTarget) {
        let drugName = selectedResult;
        this.searchResultTargets.forEach(drug => {
          const rxCUIInput = drug.querySelector("input[name='rxCUI']");
          const drugNameInput = drug.querySelector("input[name='drugName']");
          if (rxCUIInput.value == selectedResult) {
            drugName = drugNameInput.value;
          }
        })
        formData.append("drugName", drugName);
      }

      if (token) {
        formData.append("__RequestVerificationToken", token);
      }

      fetch(this.urlValue, {
        method: "POST",
        body: formData,
        headers: {
          "Accept": "text/vnd.turbo-stream.html"
        }
      })
        .then(response => response.text())
        .then(html => {
          Turbo.renderStreamMessage(html)
        })
        .catch(error => console.error("POST error:", error));
    }
  }
}