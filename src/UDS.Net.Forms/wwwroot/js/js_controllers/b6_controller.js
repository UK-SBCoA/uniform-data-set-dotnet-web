import { Controller } from '@hotwired/stimulus';

export default class extends Controller {

    static targets = [
        "radioTable",
        "GDSInput",
        "NOGDSInput"
    ]

    connect() { 
        this.CreateRadioButtonEvents()
        this.CalculateGDS()
        this.NOGDSBehavior()
    }

    CalculateGDS() {
        //If "Did not answer" radio detected, stop calculation loop
        let noCompleteFlag = false

        //reset values for recalculation
        this.GDSInputTarget.value = ""

        this.radioTableTarget.querySelectorAll('input[type="radio"]:checked').forEach((radio) => {
            if (!noCompleteFlag) {
                if (radio.value == 9) {
                    this.GDSInputTarget.value = 88
                    noCompleteFlag = true
                } else {
                    this.GDSInputTarget.value = Number(this.GDSInputTarget.value) + Number(radio.value)
                }
            }
        })
    }

    CreateRadioButtonEvents() {
        this.radioTableTarget.querySelectorAll('input[type="radio"]').forEach((radio) => {
            radio.addEventListener("change", () => {
                this.CalculateGDS()
            })
        })
    }

    //GDS must be 88 if NOGDS checkbox is checked. Auto set for user on check
    NOGDSBehavior() {
        if (this.NOGDSInputTarget.checked) {
            this.GDSInputTarget.value = 88
            this.radioTableTarget.querySelectorAll('input[type="radio"]').forEach((radio) => {
                radio.disabled = true
            })
        } else {
            this.radioTableTarget.querySelectorAll('input[type="radio"]').forEach((radio) => {
                radio.disabled = false
            })

            //recalculate GDS with enabled radios
            this.CalculateGDS()
        }
    }
}