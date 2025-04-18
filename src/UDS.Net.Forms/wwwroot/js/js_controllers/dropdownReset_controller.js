//Implemenation found at UDS.Net.Forms\Pages\Shared\_FormFooter.cshtml

import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
  static targets = ["trigger", "remote", "notCompleted"]

  connect() {
    this.setDropdowns(this.triggerTarget.value)
  }

  update(event) {
    this.setDropdowns(event.target.value)
  }

  setDropdowns(value) {
    const val = parseInt(value)

    this.resetAndDisable(this.remoteTargets)
    this.resetAndDisable(this.notCompletedTargets)

    if (val === 2) {
      this.enableTargets(this.remoteTargets)
    }

    if (val === 3) {
      this.enableTargets(this.notCompletedTargets)
    }
  }
  resetAndDisable(targets) {

    targets.forEach((target) => {
      target.selectedIndex = 0
      target.disabled = true
    })
  }
  enableTargets(targets) {
    targets.forEach((target) => {
      target.disabled = false
    })
  }
}