import AutocompleteController from "./autocomplete_controller.js"

export default class extends AutocompleteController {
    static targets = ["searchBox", "hidden", "list", "options", "loading"]
    static values = {
        url: String,
        lookupUrl: String
    }

    initialize() {
        this.restoreValue()
    }

    async restoreValue() {
        const code = this.hiddenTarget.value
        if (!code) return

        try {
            const url = new URL(this.lookupUrlValue, window.location.origin)
            url.searchParams.set("code", code)

            const res = await fetch(url)
            if (!res.ok) throw new Error()

            const data = await res.json()

            if (data) {
                this.searchBoxTarget.value = `${data.code} - ${data.name}`
            } else {
                this.searchBoxTarget.value = code
            }
        } catch {
            this.searchBoxTarget.value = code
        }
    }

    getNoResultsMessage() {
        return "No occupations found"
    }

    onSelect(item) {
        this.hiddenTarget.value = item.code
        this.searchBoxTarget.value = `${item.code} - ${item.name}`
    }

    handleEnter() {
        const value = this.searchBoxTarget.value.trim()

        // If an item is highlighted, select it
        if (this.activeIndex >= 0 && this.items[this.activeIndex]) {
            const el = this.items[this.activeIndex]
            this.select({
                code: el.dataset.code,
                name: el.dataset.name
            })
            return
        }

        // Allow 3-digit codes to be entered directly
        if (/^\d{3}$/.test(value)) {
            this.hiddenTarget.value = value
            this.hideList()
            return
        }

        // Invalid entry
        this.hiddenTarget.value = ""
        this.hideList()
    }

    onBlur() {
        const value = this.searchBoxTarget.value.trim()

        // Allow 3-digit codes to be stored on blur
        if (/^\d{3}$/.test(value)) {
            this.hiddenTarget.value = value
            return
        }

        // If the format doesn't match "code - name", clear the hidden value
        if (!value.includes(" - ")) {
            this.hiddenTarget.value = ""
        }
    }
}