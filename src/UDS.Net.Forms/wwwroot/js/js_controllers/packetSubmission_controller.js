import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
    static targets = ["row", "unresolvedButton", "resolvedButton", "ignoredButton"]

    static values = {
        showUnresolved: { type: Boolean, default: false },
        showResolved: { type: Boolean, default: false },
        showIgnored: { type: Boolean, default: false }
    }

    connect() {
        this.ToggleUnresolved()
    }

    FilterError(event) {
        if (event.params.status == "unresolved") {
            this.ToggleUnresolved()
        }
        if (event.params.status == "resolved") {
            this.ToggleResolved()
        }
        if (event.params.status == "ignored") {
            this.ToggleIgnored()
        }
    }

    ToggleUnresolved() {
        this.showUnresolvedValue = !this.showUnresolvedValue;

        if (this.showUnresolvedValue) {
            this.unresolvedButtonTarget.classList.add("border", "border-2", "border-blue-800")

            this.ShowRowsByStatus("pending")
        } else {
            this.unresolvedButtonTarget.classList.remove("border", "border-2", "border-blue-800")

            this.HideRowsByStatus("pending")
        }
    }

    ToggleResolved() {
        this.showResolvedValue = !this.showResolvedValue;

        if (this.showResolvedValue) {
            this.resolvedButtonTarget.classList.add("border", "border-2", "border-blue-800")

            this.ShowRowsByStatus("resolved")
        } else {
            this.resolvedButtonTarget.classList.remove("border", "border-2", "border-blue-800")

            this.HideRowsByStatus("resolved")
        }
    }

    ToggleIgnored() {
        this.showIgnoredValue = !this.showIgnoredValue;

        if (this.showIgnoredValue) {
            this.ignoredButtonTarget.classList.add("border", "border-2", "border-blue-800")

            this.ShowRowsByStatus("ignored")
        } else {
            this.ignoredButtonTarget.classList.remove("border", "border-2", "border-blue-800")

            this.HideRowsByStatus("ignored")
        }
    }

    HideRowsByStatus(status) {
        this.rowTargets.forEach((row) => {
            if (row.dataset.status == status) {
                row.classList.add("hidden")
            }
        })
    }

    ShowRowsByStatus(status) {
        this.rowTargets.forEach((row) => {
            if (row.dataset.status == status) {
                row.classList.remove("hidden")
            }
        })
    }
}