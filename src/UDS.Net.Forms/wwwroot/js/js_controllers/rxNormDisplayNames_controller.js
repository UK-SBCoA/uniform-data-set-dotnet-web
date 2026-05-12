import AutocompleteController from "./autocomplete_controller.js"

export default class extends AutocompleteController {

    static targets = [
        "searchBox",
        "list",
        "options",
        "loading",
        "item"
    ]

    static values = {
        url: String
    }

    connect() {

        super.connect()

        document.addEventListener(
            "turbo:before-stream-render",
            () => {
                this.activeIndex = -1
            }
        )
    }

    async performFetch(search) {

        return fetch(
            `${this.urlValue}&searchTerm=${encodeURIComponent(search)}`,
            {
                method: "GET",
                headers: {
                    "Accept": "text/vnd.turbo-stream.html"
                }
            }
        )
    }

    async handleResponse(response) {

        const html = await response.text()

        Turbo.renderStreamMessage(html)
    }

    select(event) {

        const item = JSON.parse(
            event.currentTarget.dataset.item
        )

        this.searchBoxTarget.value = item

        this.hideList()
    }
}