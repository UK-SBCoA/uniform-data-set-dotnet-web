import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
    static targets = ["unresolvedError", "resolvedError", "ignoredError"]

    connect() {
        console.log("hello from the packetsubmission controller")
    }
}