import { Controller } from "https://unpkg.com/@hotwired/stimulus/dist/stimulus.js"

export default class extends Controller {
  static targets = ["countInput"]
  static classes = ["invalid", "disabled"]
  static outlets = ["a3-enable-intra-row"]
  static values = {
    maxRows: Number,
    followupParent: String
  }

    connect() {
        this.updateRows();
    }

    updateRows() {
        if (!this.hasCountInputTarget) return;

        const value = this.countInputTarget.value;
        let count = parseInt(value, 10) || 0;

        //A follow-up Parent element will disable rows in FVP type visits when followupParent = 0
        let followupParent = $(`input[name="${this.followupParentValue}"]:checked`)

        if (followupParent.val() == 0) {
            count = 0;
        }
        else if (count === 77) {
            count = 0;
        }

        this.a3EnableIntraRowOutlets.forEach((outlet, index) => {
            const enabled = count > 0 && index < count;
            outlet.setRowEnabled(enabled);
        });
    }
}