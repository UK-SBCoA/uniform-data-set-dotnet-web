
// wwwroot/js/js_controllers/rxNormDisplayNames_controller.js
import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
  static targets = ["list"]
  static values = {
    fetchedLetters: String,
    url: String
  }

  initialize() {
  }

  connect() {
    this.fetchData({ detail: { content: "a" } }); // initialize with "a" drugs
  }

  async fetchData({ detail: { content } }) {
    var search = content;
    console.log("search for " + search);

    fetch(this.urlValue + "&searchTerm=" + search, {
      method: "GET",
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
