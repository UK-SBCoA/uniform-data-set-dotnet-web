import { Controller } from "https://unpkg.com/@hotwired/stimulus/dist/stimulus.js"

export default class extends Controller {
    static targets = ["searchBox", "hidden", "list", "options", "loading"]
    static values = {
        url: String,
        lookupUrl: String
    }

    connect() {
        this.activeIndex = -1
        this.items = []
        this.debounceTimer = null

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

    onInput() {
        const value = this.searchBoxTarget.value.trim()

        this.hiddenTarget.value = ""

        clearTimeout(this.debounceTimer)

        if (!value) {
            this.reset()
            return
        }

        this.debounceTimer = setTimeout(() => {
            this.fetchResults(value)
        }, 300)
    }

    async fetchResults(search) {
        this.showList()
        this.loadingTarget.classList.remove("hidden")

        try {
            const url = new URL(this.urlValue, window.location.origin)
            url.searchParams.set("searchTerm", search)

            const res = await fetch(url, {
                headers: { "Accept": "application/json" }
            })

            const data = await res.json()

            this.renderOptions(data)
        } catch (e) {
            console.error(e)
        } finally {
            this.loadingTarget.classList.add("hidden")
        }
    }

    renderOptions(data) {
        this.optionsTarget.innerHTML = ""
        this.items = []

        if (!data || data.length === 0) {
            this.optionsTarget.innerHTML =
                `<li class="px-4 py-2 text-gray-500 italic">No occupations found</li>`
            return
        }

        data.forEach((item, index) => {
            const li = document.createElement("li")
            li.className = "cursor-pointer px-4 py-2 hover:bg-indigo-600 hover:text-white"
            li.textContent = `${item.code} - ${item.name}`

            li.dataset.code = item.code
            li.dataset.name = item.name

            li.addEventListener("click", () => this.select(item))

            this.optionsTarget.appendChild(li)
            this.items.push(li)
        })

        this.activeIndex = -1
    }

    select(item) {
        this.hiddenTarget.value = item.code
        this.searchBoxTarget.value = `${item.code} - ${item.name}`
        this.hideList()
    }

    onKeydown(event) {
        const value = this.searchBoxTarget.value.trim()

        switch (event.key) {
            case "ArrowDown":
                event.preventDefault()
                this.move(1)
                break

            case "ArrowUp":
                event.preventDefault()
                this.move(-1)
                break

            case "Enter":
                event.preventDefault()

                if (this.activeIndex >= 0 && this.items[this.activeIndex]) {
                    const el = this.items[this.activeIndex]
                    this.select({
                        code: el.dataset.code,
                        name: el.dataset.name
                    })
                    return
                }

                if (/^\d{3}$/.test(value)) {
                    this.hiddenTarget.value = value
                    this.hideList()
                    return
                }

                this.hiddenTarget.value = ""
                this.hideList()
                break

            case "Escape":
                this.hideList()
                break
        }
    }

    move(direction) {
        if (this.items.length === 0) return

        this.activeIndex =
            (this.activeIndex + direction + this.items.length) % this.items.length

        this.items.forEach((el, i) => {
            if (i === this.activeIndex) {
                el.classList.add("bg-indigo-600", "text-white")
                el.scrollIntoView({ block: "nearest" })
            } else {
                el.classList.remove("bg-indigo-600", "text-white")
            }
        })
    }

    onBlur() {
        const value = this.searchBoxTarget.value.trim()

        if (/^\d{3}$/.test(value)) {
            this.hiddenTarget.value = value
            return
        }

        if (!value.includes(" - ")) {
            this.hiddenTarget.value = ""
        }
    }

    showList() {
        this.listTarget.classList.remove("hidden")
    }

    hideList() {
        setTimeout(() => {
            this.listTarget.classList.add("hidden")
        }, 150)
    }

    reset() {
        this.optionsTarget.innerHTML = ""
        this.items = []
        this.activeIndex = -1
        this.hideList()
    }
}