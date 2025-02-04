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

        let skipCalculation = this.NOGDSInputTarget.checked ? true : false

        //reset values for recalculation
        this.GDSInputTarget.value = ""

        if (!skipCalculation) {
            this.radioTableTarget.querySelectorAll('input[type="radio"]:checked').forEach((radio) => {
                if (Number(radio.value) != 9) {
                    this.GDSInputTarget.value = Number(this.GDSInputTarget.value) + Number(radio.value)
                }
            })
        } else {
            this.GDSInputTarget.value = 88
        }
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
        } else {
            //recalculate GDS with enabled radios
            this.CalculateGDS()
        }
    }
}