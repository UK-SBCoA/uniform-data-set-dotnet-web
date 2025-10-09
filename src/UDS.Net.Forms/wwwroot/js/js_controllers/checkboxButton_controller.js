import { Controller } from '@hotwired/stimulus';

export default class extends Controller {
  static targets = ['checkbox', 'button']

  connect() {
    this.updateButtonState()
  }

  toggle() {
    this.updateButtonState()
  }

  updateButtonState() {
    const anyChecked = this.checkboxTargets.some(cb => cb.checked)

    if (anyChecked) {
      this.buttonTarget.disabled = false
      this.buttonTarget.classList.remove('bg-gray-400', 'cursor-not-allowed')
      this.buttonTarget.classList.add('bg-indigo-600', 'hover:bg-indigo-700', 'cursor-pointer')
    } else {
      this.buttonTarget.disabled = true
      this.buttonTarget.classList.remove('bg-indigo-600', 'hover:bg-indigo-700', 'cursor-pointer')
      this.buttonTarget.classList.add('bg-gray-400', 'cursor-not-allowed')
    }
  }
}
