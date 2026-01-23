import { Controller } from 'https://unpkg.com/@hotwired/stimulus/dist/stimulus.js';

export default class extends Controller {

    inputModified({ params: { target } }) {
        $(`input[name="${target}"]`).val(1)
    }
}