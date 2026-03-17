import { Controller } from "https://unpkg.com/@hotwired/stimulus/dist/stimulus.js"

export default class extends Controller {
    static targets = ["trigger", "remote", "notCompleted", "admin", "adminHidden"]
    static values = { a1a: Boolean }

    connect() {
        if (this.hasTriggerTarget) {
            this.setDropdowns(this.triggerTarget.value, { preserveValues: true })
        }
    }

    update(event) {
        this.setDropdowns(event.target.value)
    }

    setDropdowns(value, options = { preserveValues: false }) {
        const val = parseInt(value)

        if (options.preserveValues) {
            this.disableTargets(this.remoteTargets)
            this.disableTargets(this.notCompletedTargets)
        } else {
            this.resetAndDisable(this.remoteTargets)
            this.resetAndDisable(this.notCompletedTargets)
        }

        if (val === 2) {
            this.enableTargets(this.remoteTargets)
        }

        if (val === 0) {
            this.enableTargets(this.notCompletedTargets)

            if (this.a1aValue && this.hasAdminTarget && this.hasAdminHiddenTarget) {
                this.lockAdmin("2")
            }
        } else {
            if (this.a1aValue && this.hasAdminTarget && this.hasAdminHiddenTarget) {
                this.unlockAdmin(options)
            }
        }
    }

    lockAdmin(value = "2") {
        this.adminTarget.value = value
        this.adminTarget.disabled = true
        this.adminHiddenTarget.value = value
    }

    unlockAdmin(options) {
        this.adminTarget.disabled = false
        this.adminHiddenTarget.value = ""

        if (!options.preserveValues) {
            this.adminTarget.selectedIndex = 0
        }
    }


    resetAndDisable(targets) {
        targets.forEach((target) => {
            if (target.tagName === "SELECT") {
                target.selectedIndex = 0
            }
            target.disabled = true
        })
    }

    disableTargets(targets) {
        targets.forEach((target) => {
            target.disabled = true
        })
    }

    enableTargets(targets) {
        targets.forEach((target) => {
            target.disabled = false
        })
    }
}
