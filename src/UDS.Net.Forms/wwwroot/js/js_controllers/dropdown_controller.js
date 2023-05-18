import { Controller } from '@hotwired/stimulus';

export default class extends Controller {
    static targets = ['menu', 'button']
    static values = { open: Boolean }

    toggle() {
        this.openValue = !this.openValue;
    }

    hide(event) {
        if (this.element.contains(event.target) === false && this.openValue) {
            this.openValue = false
        }
    }

    // subscribe to value event change
    openValueChanged() {
        if (this.openValue) {
            this._show();
        } else {
            this._hide();
        }
    }

    _show() {
        if (this.hasMenuTarget) {
            this.menuTarget.classList.remove('scale-95');
            this.menuTarget.classList.add('scale-100');
            this.menuTarget.classList.remove('opacity-0');
            this.menuTarget.classList.add('opacity-100');
        }
    }

    _hide() {
        if (this.hasMenuTarget) {
            this.menuTarget.classList.remove('scale-100');
            this.menuTarget.classList.add('scale-95');
            this.menuTarget.classList.add('opacity-0');
            this.menuTarget.classList.remove('opacity-100');
        }
    }
}