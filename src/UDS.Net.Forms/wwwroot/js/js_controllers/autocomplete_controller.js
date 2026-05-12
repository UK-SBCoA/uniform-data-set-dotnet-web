import { Controller } from "https://unpkg.com/@hotwired/stimulus/dist/stimulus.js"

export default class extends Controller {

    static targets = [
        "searchBox",
        "list",
        "options",
        "loading",
        "item"
    ]

    connect() {

        this.activeIndex = -1
        this.debounceTimer = null
    }

    get items() {

        return this.optionsTarget.querySelectorAll(
            `[data-${this.identifier}-target="item"]`
        )
    }

    onInput() {

        const value = this.searchBoxTarget.value.trim()

        clearTimeout(this.debounceTimer)

        if (!value) {

            this.onEmptyInput()

            this.reset()

            return
        }

        this.debounceTimer = setTimeout(() => {
            this.fetchResults(value)
        }, 300)
    }

    onEmptyInput() {
    }

    async fetchResults(search) {

        if (!search) {
            return
        }

        this.showList()

        this.showLoading()

        try {

            const response = await this.performFetch(search)

            await this.handleResponse(response)

            this.activeIndex = -1

            this.scrollToTop()

        } catch (error) {

            console.error(error)

        } finally {

            this.hideLoading()
        }
    }

    async performFetch(search) {
        throw new Error("performFetch must be implemented")
    }

    async handleResponse(response) {
        throw new Error("handleResponse must be implemented")
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
                this.handleEnter(event)
                break

            case "Escape":
                this.hideList()
                break
        }
    }

    handleEnter(event) {

        if (this.activeIndex < 0) {
            return
        }

        event.preventDefault()

        const item = this.items[this.activeIndex]

        if (item) {

            item.dispatchEvent(
                new MouseEvent("mousedown", {
                    bubbles: true
                })
            )
        }
    }

    move(direction) {

        if (this.items.length === 0) {
            return
        }

        this.activeIndex =
            (this.activeIndex + direction + this.items.length)
            % this.items.length

        this.items.forEach((el, index) => {

            const active = index === this.activeIndex

            el.classList.toggle("bg-indigo-600", active)
            el.classList.toggle("text-white", active)

            if (active) {

                el.scrollIntoView({
                    block: "nearest"
                })
            }
        })
    }

    showLoading() {
        this.loadingTarget.classList.remove("hidden")
    }

    hideLoading() {
        this.loadingTarget.classList.add("hidden")
    }

    showList() {
        this.listTarget.classList.remove("hidden")
    }

    hideList() {
        this.listTarget.classList.add("hidden")
    }

    scrollToTop() {

        this.optionsTarget.scrollTop = 0
    }

    onBlur() {

        setTimeout(() => {
            this.hideList()
        }, 150)
    }

    reset() {

        this.activeIndex = -1

        this.hideList()
    }
}