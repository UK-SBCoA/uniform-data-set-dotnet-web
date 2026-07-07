import { Controller } from 'https://unpkg.com/@hotwired/stimulus/dist/stimulus.js';

export default class extends Controller {
    static targets = ["window", "packetStatus", "ignoreResolvedCheckbox", "ptidGroup", "errorStatus"]

    ToggleErrorDisplay(event) {
        console.log("initiating toggle error display")
        this.windowTargets.forEach((group) => {
            if (String(event.params.submissionIndex) == group.dataset.submissionIndex) {
                group.toggleAttribute("hidden")
            }
        })
    }

    //DEVNOTE: currently only closes all
    ToggleAll() {
        this.windowTargets.forEach((group) => {
            group.hidden = true
        })
    }

    SetPacketStatusByAlertStatus() {
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

        //if any of the statuses are error = set to FailedErrorChecks
    }

    ResetStatuses() {
        // uncheck the update ignored/resolved checkbox
        this.ignoreResolvedCheckboxTarget.checked = false

        // Set all packet statuses back to FailedErrorChecks
        this.packetStatusTargets.forEach((status) => {
            status.value = "FailedErrorChecks"
        });
    }
}
