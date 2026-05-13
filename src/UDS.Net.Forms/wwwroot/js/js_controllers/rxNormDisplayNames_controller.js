import { Controller } from "https://unpkg.com/@hotwired/stimulus/dist/stimulus.js"

export default class extends Controller {
    static targets = ["search"]

    static values = {
        url: String
    }

    connect() {
        this.autocomplete =
            this.application.getControllerForElementAndIdentifier(
                this.element,
                "autocomplete"
            )

        this.debounceTimer = null
    }

    // -------------------------
    // INPUT HANDLING
    // -------------------------

    onInput() {
        const value = this.searchTarget.value.trim()

        clearTimeout(this.debounceTimer)

        if (!value) {
            this.autocomplete?.hide()
            return
        }

        this.debounceTimer = setTimeout(() => {
            this.fetch(value)
        }, 300)
    }

    // -------------------------
    // FETCH (FIXED)
    // -------------------------

    async fetch(search) {
        if (!this.urlValue) {
            console.error("Missing urlValue on controller")
            return
        }

        this.autocomplete?.show?.()
        this.autocomplete?.showLoading?.()

        try {
            // safer + simpler than URL constructor
            const url = `${this.urlValue}?searchTerm=${encodeURIComponent(search)}`

            const response = await fetch(url, {
                headers: {
                    "Accept": "text/vnd.turbo-stream.html"
                }
            })

            if (!response.ok) {
                throw new Error(`HTTP error: ${response.status}`)
            }

            const html = await response.text()

            if (window.Turbo?.renderStreamMessage) {
                Turbo.renderStreamMessage(html)
            } else {
                console.error("Turbo is not available")
            }

            this.autocomplete?.resetActive?.()
            this.autocomplete?.scrollTop?.()

        } catch (err) {
            console.error("Fetch failed:", err)

        } finally {
            this.autocomplete?.hideLoading?.()
        }
    }

    // -------------------------
    // SELECTION
    // -------------------------

    select(event) {
        const item = JSON.parse(event.currentTarget.dataset.item)

        this.searchTarget.value = `${item.code} - ${item.name}`

        this.autocomplete?.hide?.()
    }

    // -------------------------
    // KEYDOWN
    // -------------------------

    onKeydown(event) {
        if (event.key !== "Enter") return

        if (!this.autocomplete?.items?.length) {
            this.autocomplete?.hide?.()
        }
    }
}