// wwwroot/js/js_controllers/formlessSubmit_controller.js
// Page must have Html.AntiForgeryToken() rendered
import { Controller } from "https://unpkg.com/@hotwired/stimulus/dist/stimulus.js"

export default class extends Controller {
  static targets = ["input"]

  static values = {
    url: String
  }

  async submit() {
    event.preventDefault();
    console.log("POST " + url);
    const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value;

    const formData = new FormData();
    this.inputTargets.forEach(input => {
      formData.append(input.name, input.value);
    });
    if (token) {
      formData.append("__RequestVerificationToken", token);
    }

    fetch(this.urlValue, {
      method: "POST",
      body: formData,
      headers: {
        //"Accept": "text/vnd.turbo-stream.html"
      }
    });
    //.then(response => response.text())
    //.then(html => {
    //  Turbo.renderStreamMessage(html)
    //})
    //.catch(error => console.error("POST error:", error));

  }
}