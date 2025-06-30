// wwwroot/js/js_controllers/formlessSubmit_controller.js
// Page must have Html.AntiForgeryToken() rendered
import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
  static targets = ["input"]

  static values = {
    url: String
  }

  async submit() {
    console.log(this.inputTargets);
    console.log(this.urlValue);
    const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value;
    console.log(token);
    const formData = new FormData();
    this.inputTargets.forEach(input => {
      formData.append(input.name, input.value);
    });
    if (token) {
      formData.append("__RequestVerificationToken", token);
    }

    await fetch(this.urlValue, {
      method: "POST",
      body: formData,
      headers: {
        "X-Requested-With": "XMLHttpRequest"
      }
    });
  }
}