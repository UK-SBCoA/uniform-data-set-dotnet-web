import { Controller } from '@hotwired/stimulus'

export default class extends Controller {
  static targets = ["button"]

  submit(event) {
    if (this.hasButtonTarget) {
      this.buttonTarget.disabled = true
      this.buttonTarget.classList.remove('bg-indigo-600', 'hover:bg-indigo-700')
      this.buttonTarget.classList.add('bg-gray-400', 'cursor-not-allowed')
      this.buttonTarget.textContent = "Exporting..."
    }

    document.cookie = "udsPacketExportComplete=false"

    const downloadChecker = setInterval(() => {
      if (document.cookie.includes("udsPacketExportComplete=true")) {
        clearInterval(downloadChecker)
        alert("Packet export complete!")
        window.location.reload()
      }
    }, 500)
  }
}

