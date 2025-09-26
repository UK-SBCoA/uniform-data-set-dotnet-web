import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
    static targets = ["trigger", "remote", "notCompleted"]

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
