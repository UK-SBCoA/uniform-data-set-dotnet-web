
// wwwroot/js/js_controllers/autocomplete_controller.js
import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
  static targets = ["searchBox", "list", "item", "noResults"]

  showList(event) {
    this.listTarget.classList.remove("hidden")
  }

  hideList(event) {
    this.listTarget.classList.add("hidden")
  }

  handleOutsideClick = (event) => {
    if (!this.element.contains(event.target)) {
      this.hideList();
    }
  }
  filterList(event) {
    // we will call the rxNormDisplayNames controller (list is ~30K)
    if (this.searchBoxTarget.value != undefined && this.searchBoxTarget.value !== "") {
      if (this.searchBoxTarget.value.length == 1) {
        // this will trigger an event for rxNormDisplayNames to handle and load new entries (instead of all 30K at once)
        this.dispatch("newSearch", { detail: { content: this.searchBoxTarget.value } })
      }

      var startsWithMatcher = new RegExp("^" + this.searchBoxTarget.value, "i")
      this.itemTargets.map((item) => {
        if (startsWithMatcher.test(item.innerHTML)) {
          item.classList.remove("hidden")
        }
        else {
          item.classList.add("hidden")
        }
      });
    }
    // TODO check if list is empty and if so, display the no results
  }

  showNoResults(event) {
    this.noResultsTarget.remove("hidden")
  }

  hideNoResults(event) {
    this.noResultsTarget.add("hidden")
  }

  setSearchBox(event) {
    this.searchBoxTarget.value = event.target.innerHTML;
    this.hideList();
  }

  connect() {
    this.hideList()
    document.addEventListener("click", this.handleOutsideClick)
  }
}
