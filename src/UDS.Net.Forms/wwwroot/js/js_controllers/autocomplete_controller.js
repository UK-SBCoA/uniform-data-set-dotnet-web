import { Controller } from "https://unpkg.com/@hotwired/stimulus/dist/stimulus.js"

export default class extends Controller {

    static targets = [
        "search",
        "list",
        "options",
        "loading",
        "item"
    ]

    connect() {
        this.activeIndex = -1
    }

    get items() {
        return this.itemTargets
    }

    // -------------------------
    // UI STATE
    // -------------------------

    show() {
        this.listTarget.classList.remove("hidden")
    }

    hide() {
        this.listTarget.classList.add("hidden")
    }

    blur() {
        setTimeout(() => this.hide(), 150)
    }

    showLoading() {
        this.loadingTarget.classList.remove("hidden")
    }

    hideLoading() {
        this.loadingTarget.classList.add("hidden")
    }

    resetActive() {
        this.activeIndex = -1
    }

    scrollTop() {
        this.optionsTarget.scrollTop = 0
    }

    // -------------------------
    // KEYBOARD
    // -------------------------

    keydown(event) {

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
                this.enter(event)
                break

            case "Escape":
                this.hide()
                break
        }
    }

    enter(event) {

        if (this.activeIndex < 0) return

        event.preventDefault()

        const item = this.items[this.activeIndex]
        if (!item) return

        item.dispatchEvent(
            new MouseEvent("mousedown", {
                bubbles: true
            })
        )
    }

    move(direction) {

        if (this.items.length === 0) return

        this.activeIndex =
            (this.activeIndex + direction + this.items.length)
            % this.items.length

        this.items.forEach((el, index) => {

            const active = index === this.activeIndex

            el.classList.toggle("bg-indigo-600", active)
            el.classList.toggle("text-white", active)

            if (active) {
                el.scrollIntoView({ block: "nearest" })
            }
        })
    }
}