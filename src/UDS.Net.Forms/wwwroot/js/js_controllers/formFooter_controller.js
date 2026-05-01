import { Controller } from "https://unpkg.com/@hotwired/stimulus/dist/stimulus.js"

export default class extends Controller {
    static targets = ["modeSelect", "remoteFields", "notCompletedFields", "adminSelect", "adminHidden"]
    static values = { isA1a: Boolean }

    connect() {
        if (this.hasModeSelectTarget) {
            this.updateFormFooterFields(this.modeSelectTarget.value, { preserveValues: true })
        }
    }

    onModeChanged(event) {
        this.updateFormFooterFields(event.target.value)
    }

    updateFormFooterFields(modeValue, options = { preserveValues: false }) {
        const mode = parseInt(modeValue)

        if (mode === 2) {
            this.enableFields(this.remoteFieldsTargets)
        } else {
            if (options.preserveValues) {
                this.disableFields(this.remoteFieldsTargets)
            } else {
                this.resetAndDisableFields(this.remoteFieldsTargets)
            }
        }

        if (mode === 0) {
            this.enableFields(this.notCompletedFieldsTargets)
            this.updateAdminFieldForNotCompleted(options)
        } else {
            if (options.preserveValues) {
                this.disableFields(this.notCompletedFieldsTargets)
            } else {
                this.resetAndDisableFields(this.notCompletedFieldsTargets)
            }
            this.updateAdminFieldForCompleted(options)
        }
    }

    updateAdminFieldForNotCompleted(options) {
        if (this.isA1aValue && this.hasAdminSelectTarget && this.hasAdminHiddenTarget) {
            this.lockAdminField("2")
        }
    }

    updateAdminFieldForCompleted(options) {
        if (this.isA1aValue && this.hasAdminSelectTarget && this.hasAdminHiddenTarget) {
            this.unlockAdminField(options)
        }
    }

    lockAdminField(value = "2") {
        this.adminSelectTarget.value = value
        this.adminSelectTarget.disabled = true
        this.adminHiddenTarget.value = value
    }

    unlockAdminField(options) {
        this.adminSelectTarget.disabled = false
        this.adminHiddenTarget.value = ""

        if (!options.preserveValues) {
            this.adminSelectTarget.selectedIndex = 0
        }
    }

    resetAndDisableFields(fields) {
        fields.forEach((field) => {
            if (field.tagName === "SELECT") {
                field.selectedIndex = 0
            }
            field.disabled = true
        })
    }

    disableFields(fields) {
        fields.forEach((field) => {
            field.disabled = true
        })
    }

    enableFields(fields) {
        fields.forEach((field) => {
            field.disabled = false
        })
    }
}
