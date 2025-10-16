import { Controller } from '@hotwired/stimulus'

export default class extends Controller {
  static targets = ["button"]

  async submit(event) {

    if (this.hasButtonTarget) {
      this.buttonTarget.disabled = true
      this.buttonTarget.classList.remove('bg-indigo-600', 'hover:bg-indigo-700')
      this.buttonTarget.classList.add('bg-gray-400', 'cursor-not-allowed')
      this.buttonTarget.textContent = "Exporting..."
    }

    // Get form and endpoint URL
    const form = event.target.closest('form')
    const url = form.action
    const formData = new FormData(form)

    // Reset existing cookie
    document.cookie = "downloadComplete=false"

    try {
      const response = await fetch(url, {
        method: 'POST',
        body: formData,
      })

      if (response.ok) {
        const downloadCompleteChecker = setInterval(() => {
          if (document.cookie.includes("downloadComplete=true")) {
            clearInterval(downloadCompleteChecker);
            alert("Packet export complete!");
            window.location.reload();
          }
        }, 500)
      } else {
        alert("Export failed. Please try again.")
      }
    } catch (error) {
      alert("An error occurred. Please try again.")
    }
  }
}
