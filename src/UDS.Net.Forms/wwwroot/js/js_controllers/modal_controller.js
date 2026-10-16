import { Controller } from 'https://unpkg.com/@hotwired/stimulus/dist/stimulus.js';

export default class extends Controller {
    static targets = [
        'modal',
        'exportConfirmButtons',
        'returnToSubmissionsButton',
        'exportMessage',
        'exportHeader'
    ];

    show() {
        this.modalTarget.classList.remove('hidden');
        this.modalTarget.classList.add('flex');
    }

    hide() {
        this.modalTarget.classList.remove('flex');
        this.modalTarget.classList.add('hidden');
    }

    swapModalButtons() {
        this.exportConfirmButtonsTarget.classList.add("hidden")
        this.returnToSubmissionsButtonTarget.classList.remove("hidden")
        this.exportMessageTarget.textContent = "Your packet is being downloaded to your browser. After your download is complete, select Back to Submissions to close modal."
        this.exportHeaderTarget.textContent = "Downloading Export"
    }
}
