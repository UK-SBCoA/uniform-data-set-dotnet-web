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

  populateModal() {
    const tbody = document.querySelector('[data-modal-target="selectedList"]')
    const form = this.buttonTarget.closest('form') 

    // clear old content
    tbody.innerHTML = ''
    form.querySelectorAll("input[name='packetId']").forEach(el => el.remove())

    const checked = this.checkboxTargets.filter(cb => cb.checked)

    checked.forEach(cb => {
      const tr = document.createElement('tr')
      tr.innerHTML = `
      <td class="border-b py-2">${cb.dataset.packetId}</td>
      <td class="border-b py-2">${cb.dataset.packetParticipation}</td>
      <td class="border-b py-2">${cb.dataset.packetVisitnum}</td>
      <td class="border-b py-2">${cb.dataset.packetKind}</td>
      <td class="border-b py-2">${cb.dataset.packetInitials}</td>
      <td class="border-b py-2">${cb.dataset.packetVisitdate}</td>
    `
      tbody.appendChild(tr)

      // add hidden input so form submits IDs
      const hidden = document.createElement('input')
      hidden.type = 'hidden'
      hidden.name = 'packetId'
      hidden.value = cb.dataset.packetId
      form.appendChild(hidden)
    })
  }
}
