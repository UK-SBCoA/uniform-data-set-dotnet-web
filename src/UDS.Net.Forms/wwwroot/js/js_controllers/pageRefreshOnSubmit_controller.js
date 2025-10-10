import { Controller } from '@hotwired/stimulus'

export default class extends Controller {
  static targets = ["button"]
  static values = { delay: Number }

  submit(event) {
    if (this.hasButtonTarget) {
      this.buttonTarget.disabled = true
      this.buttonTarget.classList.remove('bg-indigo-600', 'hover:bg-indigo-700')
      this.buttonTarget.classList.add('bg-gray-400', 'cursor-not-allowed')
      this.buttonTarget.textContent = "Exporting..."
    }

    const delay = this.delayValue || 5000

    setTimeout(() => {
      window.location.reload()
    }, delay)
  }
}
