
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

  filterList(event) {
    clearTimeout(this.dispatchTimeout)
    if (this.searchBoxTarget.value != undefined && this.searchBoxTarget.value !== "") {
      
      this.dispatchTimeout = setTimeout(() => {
          this.dispatch("newSearch", { detail: { content: this.searchBoxTarget.value } })
        }, 300)

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
    this.dispatchTimeout = null
  }
}
