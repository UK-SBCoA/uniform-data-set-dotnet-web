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

        console.log("RxNorm controller connected with URL:", this.urlValue)
    }

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

    async fetch(search) {
        if (!this.urlValue) {
            console.error("Missing urlValue on controller")
            return
        }

        this.autocomplete?.show?.()
        this.autocomplete?.showLoading?.()

        try {
            const url = `${this.urlValue}&searchTerm=${encodeURIComponent(search)}`

            console.log("Fetching RxNorm results from:", url)

            const response = await fetch(url, {
                headers: {
                    "Accept": "text/vnd.turbo-stream.html"
                }
            })

            if (!response.ok) {
                throw new Error(`HTTP error: ${response.status}`)
            }

            const html = await response.text()

            console.log("Received HTML response:", html.substring(0, 200))

            if (window.Turbo?.renderStreamMessage) {
                window.Turbo.renderStreamMessage(html)
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

    select(event) {
        const item = JSON.parse(event.currentTarget.dataset.item)

        this.searchTarget.value = item.name

        this.autocomplete?.hide?.()
    }

    onKeydown(event) {
        if (event.key !== "Enter") return

        if (!this.autocomplete?.items?.length) {
            this.autocomplete?.hide?.()
        }
    }
}