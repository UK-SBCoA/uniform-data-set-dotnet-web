import { Controller } from "https://unpkg.com/@hotwired/stimulus/dist/stimulus.js"

export default class extends Controller {
    static targets = ["searchBox", "list", "options", "loading"]
    static values = {
        url: String
    }

    connect() {
        this.activeIndex = -1
        this.items = []
        this.debounceTimer = null
        this.initialize()
    }

    // Override in subclasses for custom initialization
    initialize() {
    }

    onInput() {
        const value = this.searchBoxTarget.value.trim()
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
            this.optionsTarget.innerHTML = `<li class="px-4 py-2 text-gray-500 italic">${this.getNoResultsMessage()}</li>`
            return
        }

        data.forEach((item) => {
            const li = document.createElement("li")
            li.className = "cursor-pointer px-4 py-2 hover:bg-indigo-600 hover:text-white"
            li.textContent = this.formatItemText(item)

            this.setItemData(li, item)
            li.addEventListener("click", () => this.select(item))

            this.optionsTarget.appendChild(li)
            this.items.push(li)
        })

        this.activeIndex = -1
    }

    // Override in subclasses to customize item text formatting
    formatItemText(item) {
        return `${item.code} - ${item.name}`
    }

    // Override in subclasses to customize item data storage
    setItemData(element, item) {
        element.dataset.code = item.code
        element.dataset.name = item.name
    }

    // Override in subclasses to customize no results message
    getNoResultsMessage() {
        return "No results found"
    }

    select(item) {
        this.onSelect(item)
        this.hideList()
    }

    // Override in subclasses for custom select behavior
    onSelect(item) {
        this.searchBoxTarget.value = this.formatItemText(item)
    }

    onKeydown(event) {
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
                this.handleEnter()
                break

            case "Escape":
                this.hideList()
                break
        }
    }

    // Override in subclasses for custom Enter key behavior
    handleEnter() {
        if (this.activeIndex >= 0 && this.items[this.activeIndex]) {
            const el = this.items[this.activeIndex]
            this.select({ code: el.dataset.code, name: el.dataset.name })
        }
    }

    move(direction) {
        if (this.items.length === 0) return

        this.activeIndex = (this.activeIndex + direction + this.items.length) % this.items.length

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
        // Override in subclasses for custom blur behavior
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