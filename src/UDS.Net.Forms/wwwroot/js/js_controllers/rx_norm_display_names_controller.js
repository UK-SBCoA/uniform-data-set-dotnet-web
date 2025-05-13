
// wwwroot/js/js_controllers/rx_norm_display_names_controller.js
import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
  static targets = ["list"]
  static values = {
    fetchedLetters: String
  }

  initialize() {
  }

  connect() {
    this.fetchData({ detail: { content: "a" } }); // initialize with "a" drugs
  }

  async fetchData({ detail: { content } }) {
    var search = content;
    if (!this.fetchedLettersValue.includes(search)) {
      this.fetchedLettersValue = this.fetchedLettersValue + search;
      //console.log("fetching for " + search)
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
    }
  }

}
