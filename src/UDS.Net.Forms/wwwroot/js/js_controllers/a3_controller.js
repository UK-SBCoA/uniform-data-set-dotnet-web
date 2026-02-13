import { Controller } from 'https://unpkg.com/@hotwired/stimulus/dist/stimulus.js';

export default class extends Controller {

    static targets = [
        "parentsModified",
        "siblingsModified",
        "kidsModified"
    ]

    ParentsModified() {
        this.parentsModifiedTarget.value = 1
    }

    SiblingsModified() {
        console.log("siblings changed")
        this.siblingsModifiedTarget.value = 1
    }

    KidsModified() {
        this.kidsModifiedTarget.value = 1
    }
}