
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

  handleOutsideClick(event) {
    if (!this.searchBoxTarget.contains(event.target)) {
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
      this.activeIndex = -1;
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
    document.addEventListener("approvedPersonnelList:updated", this.showList()); //custom event from approverPersonnel stimulus controller 
    this.searchBoxTarget.addEventListener("keydown", this.onKeyDown.bind(this));
    this.activeIndex = -1
  }

  onKeyDown(event) {
    const visibleItems = this.itemTargets.filter(item => !item.classList.contains("hidden"));
    if (visibleItems.length === 0) return;

    switch (event.key) {
      case "ArrowDown":
        event.preventDefault();
        this.activeIndex = (this.activeIndex + 1) % visibleItems.length;
        this.updateActiveItem(visibleItems);
        break;
      case "ArrowUp":
        event.preventDefault();
        this.activeIndex = (this.activeIndex - 1 + visibleItems.length) % visibleItems.length;
        this.updateActiveItem(visibleItems);
        break;
      case "Enter":
        event.preventDefault();
        if (this.activeIndex >= 0 && visibleItems[this.activeIndex]) {
          visibleItems[this.activeIndex].click(); // Triggers setSearchBox
        }
        break;
    }
  }

  updateActiveItem(items) {
    items.forEach((item, index) => {
      if (index === this.activeIndex) {
        item.classList.add("bg-indigo-600", "text-white");
        item.scrollIntoView({ block: "nearest" });
      } else {
        item.classList.remove("bg-indigo-600", "text-white");
      }
    });
  }

}
