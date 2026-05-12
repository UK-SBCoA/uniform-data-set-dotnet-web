import AutocompleteController from "./autocomplete_controller.js"

export default class extends AutocompleteController {

    static targets = [
        "searchBox",
        "hidden",
        "list",
        "options",
        "loading",
        "item"
    ]

    static values = {
        url: String,
        lookupUrl: String
    }

    connect() {

        super.connect()

        this.restoreValue()
    }

    async restoreValue() {

        const code = this.hiddenTarget.value

        if (!code) {
            return
        }

        try {

            const url = new URL(
                this.lookupUrlValue,
                window.location.origin
            )

            url.searchParams.set("code", code)

            const res = await fetch(url)

            if (!res.ok) {
                throw new Error()
            }

            const data = await res.json()

            this.searchBoxTarget.value = data
                ? `${data.code} - ${data.name}`
                : code

        } catch {

            this.searchBoxTarget.value = code
        }
    }

    onEmptyInput() {

        this.hiddenTarget.value = ""
    }

    async performFetch(search) {

        const url = new URL(
            this.urlValue,
            window.location.origin
        )

        url.searchParams.set("searchTerm", search)

        return fetch(url, {
            headers: {
                "Accept": "application/json"
            }
        })
    }

    async handleResponse(response) {

        const data = await response.json()

        this.renderOptions(data)
    }

    renderOptions(data) {

        this.optionsTarget.innerHTML = ""

        if (!data?.length) {

            this.optionsTarget.innerHTML = `
                <li class="px-4 py-2 text-gray-500 italic">
                    No occupations found
                </li>
            `

            return
        }

        data.forEach((item) => {

            const li = document.createElement("li")

            li.className =
                "cursor-pointer px-4 py-2 hover:bg-indigo-600 hover:text-white"

            li.textContent =
                `${item.code} - ${item.name}`

            li.dataset.code = item.code
            li.dataset.name = item.name

            li.setAttribute(
                "data-occupation-autocomplete-target",
                "item"
            )

            li.addEventListener("mousedown", (e) => {

                e.preventDefault()

                this.select(item)
            })

            this.optionsTarget.appendChild(li)
        })
    }

    select(item) {

        this.hiddenTarget.value = item.code

        this.searchBoxTarget.value =
            `${item.code} - ${item.name}`

        this.hideList()
    }

    handleEnter(event) {

        const value = this.searchBoxTarget.value.trim()

        if (
            this.activeIndex >= 0 &&
            this.items[this.activeIndex]
        ) {

            event.preventDefault()

            const el = this.items[this.activeIndex]

            this.select({
                code: el.dataset.code,
                name: el.dataset.name
            })

            return
        }

        if (/^\d{3}$/.test(value)) {

            event.preventDefault()

            this.hiddenTarget.value = value

            this.hideList()

            return
        }

        event.preventDefault()

        this.hiddenTarget.value = ""

        this.hideList()
    }

    onBlur() {

        setTimeout(() => {

            const value =
                this.searchBoxTarget.value.trim()

            if (/^\d{3}$/.test(value)) {

                this.hiddenTarget.value = value

                this.hideList()

                return
            }

            if (!value.includes(" - ")) {

                this.hiddenTarget.value = ""
            }

            this.hideList()

        }, 150)
    }
}