
// wwwroot/js/js_controllers/rxNormDisplayNames_controller.js
import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
  static targets = ["list"]

  connect() {
    this.fetchData()

  }

  async fetchData() {
    try {
      const response = await fetch("https://rxnav.nlm.nih.gov/REST/displaynames.json")
      const data = await response.json()
      console.log(data.displayTermsList)
      // Update the target element with the received data
      //this.resultTarget.textContent = data.message
      data.displayTermsList.term.map((item) => {
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
        newLi.id = "option"
        newLi.role = "option"
        newLi.tabIndex = -1
        this.listTarget.appendChild(newLi)
      })

    } catch (error) {
      console.error("Error fetching data:", error)
    }
  }

}
