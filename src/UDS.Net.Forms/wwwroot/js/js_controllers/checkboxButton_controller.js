import { Controller } from '@hotwired/stimulus';

export default class extends Controller {
  static targets = ['checkbox', 'button']

  connect() {
    this.restoreCheckedStates()
    this.updateButtonState()
  }

  toggle(event) {
    const checkbox = event.target
    const id = checkbox.value
    const checked = checkbox.checked

    let selected = this.getSelectedPackets()

    if (checked && !selected.includes(id)) {
      selected.push(id)
    } else if (!checked) {
      selected = selected.filter(x => x !== id)
    }

    sessionStorage.setItem('selectedPackets', JSON.stringify(selected))

    this.updateButtonState()
  }

  updateButtonState() {
    const anyChecked = this.getSelectedPackets().length > 0

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

  restoreCheckedStates() {
    const selected = this.getSelectedPackets()
    this.checkboxTargets.forEach(cb => {
      cb.checked = selected.includes(cb.value)
    })
  }

  getSelectedPackets() {
    return JSON.parse(sessionStorage.getItem('selectedPackets') || '[]')
  }

  clearSelected() {
    sessionStorage.removeItem('selectedPackets')
    this.checkboxTargets.forEach(cb => cb.checked = false)
    this.updateButtonState()
  }

  prepareSubmission(event) {
    const form = event.target.closest('form')
    const selected = this.getSelectedPackets()

    form.querySelectorAll('input[name="packetId"][data-generated="true"]').forEach(el => el.remove())

    selected.forEach(id => {
      const existing = form.querySelector(`input[name="packetId"][value="${id}"]`)
      if (existing && existing.type !== 'hidden') return

      const input = document.createElement('input')
      input.type = 'hidden'
      input.name = 'packetId'
      input.value = id
      input.dataset.generated = 'true'
      form.appendChild(input)
    })
  }

}
