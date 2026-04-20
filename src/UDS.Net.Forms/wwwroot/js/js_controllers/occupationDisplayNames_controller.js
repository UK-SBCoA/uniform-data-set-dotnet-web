import { Controller } from "https://unpkg.com/@hotwired/stimulus/dist/stimulus.js"

export default class extends Controller {
  static targets = ["list", "progressIndicator"]
  static values = {
    url: String
  }

  connect() {
    this.fetchData({ detail: { content: "" } });
  }

  async fetchData({ detail: { content } }) {
    const search = content;
    
    if (this.hasProgressIndicatorTarget) {
      this.progressIndicatorTarget.classList.remove("hidden");
    }
    
    try {
      const url = new URL(this.urlValue, window.location.origin);
      url.searchParams.set("searchTerm", search);
      
      const response = await fetch(url.toString(), {
        method: "GET",
        headers: {
          "Accept": "text/vnd.turbo-stream.html"
        }
      });
      
      if (response.ok) {
        const html = await response.text();
        Turbo.renderStreamMessage(html);
        
        const options = document.getElementById("occupation-options");
        if (options) {
          options.scrollTop = 0;
        }
      }
    } catch (error) {
      console.error("GET error:", error);
    } finally {
      if (this.hasProgressIndicatorTarget) {
        this.progressIndicatorTarget.classList.add("hidden");
      }
    }
  }

  setItemCode(event) {
    const code = event.currentTarget.dataset.occupationCode;
    const searchBox = document.querySelector('[data-autocomplete-target="searchBox"]');
    if (searchBox && code) {
      searchBox.value = code;
      searchBox.dispatchEvent(new Event('change', { bubbles: true }));
      const list = document.querySelector('[data-autocomplete-target="list"]');
      if (list) {
        list.classList.add("hidden");
      }
    }
  }
}