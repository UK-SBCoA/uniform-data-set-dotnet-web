import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
  //static targets = ["dropdown"]
  //static values = { visitId: Number }

  //remoteModeDropdown(event) {
  //  const dropdown = this.dropdownTarget;
  //  const dropdownValue = dropdown.value;
  //  const visitId = this.visitIdValue;

  //  const turboFrameId = dropdown.dataset.turboframe;
  //  const turboFrame = document.querySelector(`turbo-frame#${turboFrameId}`);

  //  const remoteEndPoint = dropdown.dataset.remoteEndPoint;
  //  const inPersonEndPoint = dropdown.dataset.inPersonEndPoint;

  //  if (visitId) {
  //    if (dropdownValue == 1) {
  //      turboFrame.src = `${remoteEndPoint}`;
  //    } else {
  //      turboFrame.src = `${inPersonEndPoint}`;
  //    }
  //  }
  //}
  //modeDropdown(event) {
  //  const dropdown = this.dropdownTarget;
  //  const dropdownValue = dropdown.value;
  //  const visitId = this.visitIdValue;

  //  const turboFrameId = dropdown.dataset.turboframe;
  //  const turboFrame = document.querySelector(`turbo-frame#${turboFrameId}`);

  //  const inPersonEndPoint = dropdown.dataset.inPersonEndPoint;

  //  if (visitId) {
  //    if (dropdownValue == 1) {
  //      turboFrame.src = `${inPersonEndPoint}`;
  //    }
  //  }
  //}
}