
// wwwroot/js/js_controllers/rxNormDisplayNames_controller.js
import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
  static targets = ["list", "progressIndicator"]
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
    if (content.length > 0) {
      // only get new results from rxnorm when the first letter has not already been added to the list
      var search = content[0];
      if (!this.fetchedLettersValue.includes(search)) {
        if (this.hasProgressIndicatorTarget) {
          this.progressIndicatorTarget.classList.remove("hidden");
        }
        this.fetchedLettersValue = this.fetchedLettersValue + search;
        try {
          const response = await fetch("https://rxnav.nlm.nih.gov/REST/displaynames.json")
          const data = await response.json()

          // Update the list with the received data
          data.displayTermsList.term.forEach(item => {
            var startsWithMatcher = new RegExp("^" + search, "i")
            if (startsWithMatcher.test(item)) {
              const newLi = document.createElement("li")
              newLi.textContent = item // Set the content of the new list item
              newLi.classList.add("cursor-default")
              newLi.classList.add("rounded-md")
              newLi.classList.add("px-4")
              newLi.classList.add("py-2")
              newLi.classList.add("select-none")
              newLi.classList.add("hover:bg-indigo-600")
              newLi.classList.add("hover:text-white")
              newLi.setAttribute("data-autocomplete-target", "item")
              newLi.setAttribute("data-action", "click->autocomplete#setSearchBox")
              newLi.role = "option"
              newLi.tabIndex = -1
              this.listTarget.appendChild(newLi)
            }
          })

        } catch (error) {
          console.error("Error fetching data:", error)
        }
        if (this.hasProgressIndicatorTarget) {
          this.progressIndicatorTarget.classList.add("hidden");
        }
      }
    })
      .then(response => response.text())
      .then(html => {
        Turbo.renderStreamMessage(html)
      })
      .catch(error => console.error("POST error:", error));
  }

}
