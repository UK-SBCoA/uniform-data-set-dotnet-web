import { Controller } from 'https://unpkg.com/@hotwired/stimulus/dist/stimulus.js';

export default class extends Controller {
    static targets = ["window"]

    ToggleErrorDisplay(event) {
        this.windowTargets.forEach((group) => {
            if (String(event.params.submissionIndex) == group.dataset.submissionIndex) {
                group.toggleAttribute("hidden")
            }
        })
    }

    ToggleAll() {
        this.windowTargets.forEach((group) => {
            group.hidden = true
        })
    }
}
