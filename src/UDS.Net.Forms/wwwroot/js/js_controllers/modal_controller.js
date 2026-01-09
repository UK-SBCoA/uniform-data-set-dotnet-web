import { Controller } from 'https://unpkg.com/@hotwired/stimulus/dist/stimulus.js';

export default class extends Controller {
    static targets = ['modal'];

    show() {
        this.modalTarget.classList.remove('hidden');
        this.modalTarget.classList.add('flex');
    }

    hide() {
        this.modalTarget.classList.remove('flex');
        this.modalTarget.classList.add('hidden');
    }
}
