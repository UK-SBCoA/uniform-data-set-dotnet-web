import { Controller } from "https://unpkg.com/@hotwired/stimulus/dist/stimulus.js"

export default class extends Controller {

    static targets = ["hidden"]

    static values = {
        url: String,
        lookupUrl: String
    }

    connect() {

        this.autocomplete =
            this.application.getControllerForElementAndIdentifier(
                this.element,
                "autocomplete"
            )

        this.debounceTimer = null

        this.restoreValue()
    }

    async lookupCode(code) {

        const url = new URL(
            this.lookupUrlValue,
            window.location.origin
        )

        url.searchParams.set("code", code)

        const response = await fetch(url)

        if (!response.ok) {
            throw new Error()
        }

        return await response.json()
    }

    async restoreValue() {

        const code = this.hiddenTarget.value

        if (!code) return

        try {

            const data = await this.lookupCode(code)

            this.autocomplete.searchTarget.value =
                data ? `${data.code} - ${data.name}` : code

        } catch {

            this.autocomplete.searchTarget.value = code
        }
    }

    clearValidation() {

        this.autocomplete.searchTarget.setCustomValidity("")
    }

    showValidation(message) {

        this.autocomplete.searchTarget.setCustomValidity(message)
        this.autocomplete.searchTarget.reportValidity()
    }

    search() {

        const value =
            this.autocomplete.searchTarget.value.trim()

        this.clearValidation()

        clearTimeout(this.debounceTimer)

        if (!value) {

            this.hiddenTarget.value = ""
            this.autocomplete.hide()

            return
        }

        this.debounceTimer = setTimeout(() => {
            this.fetch(value)
        }, 300)
    }

    async fetch(search) {

        this.autocomplete.show()
        this.autocomplete.showLoading()

        try {

            const url = new URL(
                this.urlValue,
                window.location.origin
            )

            url.searchParams.set("searchTerm", search)

            const response = await fetch(url, {
                headers: {
                    "Accept": "application/json"
                }
            })

            const data = await response.json()

            this.render(data)

            this.autocomplete.resetActive()
            this.autocomplete.scrollTop()

        } catch (err) {

            console.error(err)

        } finally {

            this.autocomplete.hideLoading()
        }
    }

    render(data) {

        this.autocomplete.optionsTarget.innerHTML = ""

        if (!data?.length) {

            this.autocomplete.optionsTarget.innerHTML = `
                <li class="px-4 py-2 text-gray-500 italic">
                    No occupations found
                </li>
            `

            return
        }

        data.forEach(item => {

            const li = document.createElement("li")

            li.className =
                "cursor-pointer px-4 py-2 hover:bg-indigo-600 hover:text-white"

            li.textContent =
                `${item.code} - ${item.name}`

            li.dataset.code = item.code
            li.dataset.name = item.name

            li.setAttribute(
                "data-autocomplete-target",
                "item"
            )

            li.addEventListener("mousedown", (e) => {

                e.preventDefault()

                this.select(item)
            })

            this.autocomplete.optionsTarget.appendChild(li)
        })
    }

    select(item) {

        this.hiddenTarget.value = item.code

        this.autocomplete.searchTarget.value =
            `${item.code} - ${item.name}`

        this.clearValidation()

        this.autocomplete.hide()
    }

    keydown(event) {

        if (event.key !== "Enter") return

        const value =
            this.autocomplete.searchTarget.value.trim()

        if (this.autocomplete.activeIndex >= 0) return

        event.preventDefault()
        event.stopPropagation()
        event.stopImmediatePropagation()

        if (/^\d{3}$/.test(value)) {

            this.resolveManualCode(value)

            return
        }

        this.hiddenTarget.value = ""

        this.showValidation(
            "Please select an occupation from the list or enter a valid 3-digit occupation code."
        )

        this.autocomplete.hide()
    }

    async resolveManualCode(code) {

        try {

            const data = await this.lookupCode(code)

            if (!data) {

                this.hiddenTarget.value = ""

                this.showValidation(
                    "Please enter a valid occupation code."
                )

                return
            }

            this.hiddenTarget.value = data.code

            this.autocomplete.searchTarget.value =
                `${data.code} - ${data.name}`

            this.clearValidation()

        } catch {

            this.hiddenTarget.value = ""

            this.showValidation(
                "Unable to validate occupation code."
            )
        }

        this.autocomplete.hide()
    }

    async validateOnBlur() {

        const value =
            this.autocomplete.searchTarget.value.trim()

        if (!value) {
            this.hiddenTarget.value = ""
            this.clearValidation()
            return
        }

        if (this.hiddenTarget.value) {
            this.clearValidation()
            return
        }

        if (/^\d{3}$/.test(value)) {

            await this.resolveManualCode(value)

            return
        }

        this.hiddenTarget.value = ""

        this.showValidation(
            "Please select an occupation from the list or enter a valid 3-digit occupation code."
        )
    }
}