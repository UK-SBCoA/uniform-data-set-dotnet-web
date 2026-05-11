import { Controller } from "https://unpkg.com/@hotwired/stimulus/dist/stimulus.js"

export default class extends Controller {
    static targets = [
        "searchBox",
        "list",
        "options",
        "loading"
    ]

    connect() {
        this.activeIndex = -1
        this.items = []
        this.debounceTimer = null

        this.hideList()
    }

    onInput() {
        const value = this.searchBoxTarget.value.trim()

        clearTimeout(this.debounceTimer)

        if (!value) {
            this.reset()

            this.dispatch("reset")

            return
        }

        this.debounceTimer = setTimeout(() => {
            this.showList()

            this.dispatch("search", {
                detail: {
                    value
                }
            })
        }, 300)
    }

    rebuildItems() {
        this.items = Array.from(
            this.optionsTarget.querySelectorAll("li")
        )

        this.activeIndex = -1
    }

    showList() {
        if (this.hasListTarget) {
            this.listTarget.classList.remove("hidden")
        }
    }

    hideList() {
        if (this.hasListTarget) {
            this.listTarget.classList.add("hidden")
        }
    }

    reset() {
        this.items = []
        this.activeIndex = -1

        this.hideList()

        if (this.hasOptionsTarget) {
            this.optionsTarget.scrollTop = 0
        }
    }

    onBlur(event) {
        if (!this.element.contains(event.relatedTarget)) {
            this.hideList()
        }
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
                this.selectActive()
                break

            case "Escape":
                this.hideList()
                break
        }
    }

    move(direction) {
        if (this.items.length === 0) {
            return
        }

        this.activeIndex =
            (this.activeIndex + direction + this.items.length) %
            this.items.length

        this.items.forEach((item, index) => {
            item.classList.toggle(
                "bg-indigo-600",
                index === this.activeIndex
            )

            item.classList.toggle(
                "text-white",
                index === this.activeIndex
            )

            if (index === this.activeIndex) {
                item.scrollIntoView({
                    block: "nearest"
                })
            }
        })
    }

    selectActive() {
        const item = this.items[this.activeIndex]

        if (!item) {
            return
        }

        item.click()
    }
}