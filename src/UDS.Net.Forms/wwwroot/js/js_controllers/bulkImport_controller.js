import { Controller } from 'https://unpkg.com/@hotwired/stimulus/dist/stimulus.js';

export default class extends Controller {
    static targets = ["window", "packetStatus", "ignoreResolvedCheckbox", "ptidGroup", "errorStatus"]

    ToggleErrorDisplay(event) {
        this.windowTargets.forEach((group) => {
            if (String(event.params.submissionIndex) == group.dataset.submissionIndex) {
                group.toggleAttribute("hidden")
            }
        })
    }

    ToggleWindows({ params: { openWindows }}) {
        this.windowTargets.forEach((group) => {
            group.hidden = !openWindows
        })
    }

    SetPacketStatusByAlertStatus() {
        //check if checkbox is selected
        if (this.ignoreResolvedCheckboxTarget.checked) {
            //Search all submission groups
            this.ptidGroupTargets.forEach((group) => {
                let groupIndex = group.dataset.bulkErrorSubmissionItemIndex

                //find all error statuses pertaining to that group
                let groupErrors = this.errorStatusTargets.filter(e => e.dataset.bulkErrorSubmissionItemIndex == groupIndex)

                if (groupErrors.length > 0) {
                    let statusForPacket = groupErrors.some(e => e.value == 0) ? "FailedErrorChecks" : "PassedErrorChecks";

                    this.packetStatusTargets.filter(p => p.dataset.bulkErrorSubmissionItemIndex == groupIndex).forEach((e) => {
                        e.value = statusForPacket
                    })
                }
            })
        }
    }

    HandleIgnoredResolved() {
        if (this.ignoreResolvedCheckboxTarget.checked == false) {
            //if ignored/resolved is unchecked, set all packets to failedErrorChecks
            this.packetStatusTargets.forEach((status) => {
                status.value = "FailedErrorChecks"
            });
        }
    }
}
