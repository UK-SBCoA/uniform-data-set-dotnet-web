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

    selectOccupation(event) {
        const occupationCode = event.currentTarget.dataset.occupationCode;
        const occupationName = event.currentTarget.dataset.occupationName;

        if (occupationCode) {
            // Set the PRIOCC field (hidden input) to the code
            const prioccField = document.querySelector('input[name="A1.PRIOCC"]');
            if (prioccField) {
                prioccField.value = occupationCode;
            }

            // Clear the search box
            const searchBox = document.getElementById("occupationSearchBox");
            if (searchBox) {
                searchBox.value = "";
            }

            // Hide the autocomplete list
            const list = document.querySelector('[data-autocomplete-target="list"]');
            if (list) {
                list.classList.add("hidden");
            }
        }
    }
}