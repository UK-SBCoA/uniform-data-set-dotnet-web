import { Controller } from 'https://unpkg.com/@hotwired/stimulus/dist/stimulus.js';

export default class extends Controller {
    static targets = ["submissionGroupConfirm"]

    connect() {
        this.submissionGroupConfirmTargets.forEach((group) => {
            if (group.checked) {
                document.querySelectorAll(`.submissionGroup-${group.dataset.submissionGroup}`).forEach((error) => {
                    error.checked = true
                })
            }
        })
    }

    ToggleConfirmImport(event) {
        document.querySelectorAll(`.submissionGroup-${event.params.submissionGroup}`).forEach((error) => {
            error.checked = event.target.checked 
            if (event.target.checked) error.checked = true
            else error.checked = false
        });
    }
}
