//Implemenation found at UDS.Net.Forms\Pages\Shared\_FormFooter.cshtml

import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
  static targets = ["trigger"]

  connect() {
    this.applyRules(this.triggerTarget.value)
  }

  update(event) {
    this.applyRules(event.target.value)
  }

  applyRules(value) {
    const val = parseInt(value)

    // Reset all dependent dropdowns first
    const allTargets = this.element.querySelectorAll("[data-reset-target]")
    allTargets.forEach(target => {
      target.disabled = true
      target.selectedIndex = 0
    })

    // Find elements that should be enabled for this value
    const matchingTargets = this.element.querySelectorAll(`[data-show-if~="${val}"]`)
    matchingTargets.forEach(target => {
      target.disabled = false
    })
  }
}