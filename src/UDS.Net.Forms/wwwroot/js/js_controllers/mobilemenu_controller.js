import { Controller } from "@hotwired/stimulus";

export default class extends Controller {
    static targets = ['button', 'menu', 'openIcon', 'closeIcon']
    static values = { open: Boolean }

    toggle() {
        this.openValue = !this.openValue;
    }

    hide(event) {
        if (this.element.contains(event.target) === false && this.openValue) {
            this.openValue = false
        }
    }

    openValueChanged() {
        if (this.openValue) {
            this._show();
        } else {
            this._hide();
        }
    }

    _show() {
        if (this.hasMenuTarget) {
            this.menuTarget.style.display = "";
        }
        if (this.hasOpenIconTarget) {
            this.openIconTarget.classList.add('hidden');
            this.openIconTarget.classList.remove('block');
        }
        if (this.hasCloseIconTarget) {
            this.closeIconTarget.classList.add('block');
            this.closeIconTarget.classList.remove('hidden');
        }
    }

    _hide() {
        if (this.hasMenuTarget) {
            this.menuTarget.style.display = "none";
        }
        if (this.hasOpenIconTarget) {
            this.openIconTarget.classList.remove('hidden');
            this.openIconTarget.classList.add('block');
        }
        if (this.hasCloseIconTarget) {
            this.closeIconTarget.classList.remove('block');
            this.closeIconTarget.classList.add('hidden');
        }
    }
}