
// wwwroot/js/js_controllers/autocomplete_controller.js
import { Controller } from "https://unpkg.com/@hotwired/stimulus/dist/stimulus.js"

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
    clearTimeout(this.dispatchTimeout)

    if (this.searchBoxTarget.value != undefined && this.searchBoxTarget.value !== "") {
      // debounce input
      this.dispatchTimeout = setTimeout(() => {
        this.showList();
        this.dispatch("newSearch", { detail: { content: this.searchBoxTarget.value } })
      }, 300)
    }
    else {
      this.reset();
      this.dispatch("resetSearch");
    }

    this.activeIndex = -1;
  }

  showNoResults(event) {
    this.noResultsTarget.remove("hidden")
  }

  hideNoResults(event) {
    this.noResultsTarget.add("hidden")
  }

  setSearchBox(event) {
    event.preventDefault();
    if (event.type == "click") {
      this.searchBoxTarget.value = event.target.innerHTML;
    }
    else if (event.type == "keydown" && event.key == "Enter") {
      const visibleItems = this.itemTargets.filter(item => !item.classList.contains("hidden"));
      this.searchBoxTarget.value = visibleItems[this.activeIndex].innerHTML;
    }
    this.hideList();
  }

  connect() {
    this.hideList()

    this.activeIndex = -1;
    this.dispatchTimeout = null;
  }

  reset() {
    this.hideList();
    this.searchBoxTarget.value = "";
    this.activeIndex = -1;
    this.dispatchTimeout = null;
  }

  highlightItem(event) {
    event.preventDefault();
    const visibleItems = this.itemTargets.filter(item => !item.classList.contains("hidden"));
    if (visibleItems.length === 0) return;

    switch (event.key) {
      case "ArrowDown":
        this.activeIndex = (this.activeIndex + 1) % visibleItems.length;
        break;
      case "ArrowUp":
        this.activeIndex = (this.activeIndex - 1 + visibleItems.length) % visibleItems.length;
        break;
    }

    visibleItems.forEach((item, index) => {
      if (index === this.activeIndex) {
        item.classList.add("bg-indigo-600", "text-white");
        item.scrollIntoView({ block: "nearest" });
      } else {
        item.classList.remove("bg-indigo-600", "text-white");
      }
    });
  }

}
