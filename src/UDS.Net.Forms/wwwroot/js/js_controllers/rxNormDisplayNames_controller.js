import AutocompleteController from "./autocomplete_controller.js"

export default class extends AutocompleteController {
    static targets = ["searchBox", "list", "options", "loading"]
    static values = {
        url: String
    }

    connect() {
        // Call parent connect to initialize state
        super.connect()
        // Don't fetch on page load - wait for user interaction
    }

    async fetchData({ detail: { content } }) {
        const search = content
        if (search.length === 0) return

        this.showList()
        this.loadingTarget.classList.remove("hidden")

        try {
            const response = await fetch(this.urlValue + "&searchTerm=" + search, {
                method: "GET",
                headers: {
                    "Accept": "text/vnd.turbo-stream.html"
                }
            })

            const html = await response.text()
            Turbo.renderStreamMessage(html)

            // Reset scroll position
            const options = document.getElementById("options")
            if (options) {
                options.scrollTop = 0
            }
        } catch (error) {
            console.error("GET error:", error)
        } finally {
            this.loadingTarget.classList.add("hidden")
        }
    }

    onInput() {
        const value = this.searchBoxTarget.value.trim()
        clearTimeout(this.debounceTimer)

        if (!value) {
            this.reset()
            return
        }

        this.debounceTimer = setTimeout(() => {
            this.fetchData({ detail: { content: value } })
        }, 300)
    }

    getNoResultsMessage() {
        return "No medications found"
    }

    onSelect(item) {
        // Fill the search field with the selected medication name
        // This handles autocomplete list selections
        this.searchBoxTarget.value = item
        this.hideList()
    }

    handleEnter() {
        // RxNorm handles Enter key through Turbo Streams
        // Override to prevent default behavior
    }

    onBlur() {
        // Close the dropdown when focus leaves
        this.hideList()
    }
}