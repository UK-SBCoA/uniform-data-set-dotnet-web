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

        const totalQuestionCount = 15

        let skipCalculation = this.NOGDSInputTarget.checked ? true : false
        let GDSScore = 0;
        let unansweredCount = 0

        if (!skipCalculation) {

            let checkedRadios = this.radioTableTarget.querySelectorAll('input[type="radio"]:checked')

            checkedRadios.forEach((radio) => {
                if (Number(radio.value) != 9) {
                    GDSScore += Number(radio.value)
                } else {
                    unansweredCount++
                }
            })

            //display the total only when all questions have been answered
            if (checkedRadios.length == totalQuestionCount) {
                if (unansweredCount == 0) {
                    this.GDSInputTarget.value = GDSScore
                } else {
                    this.GDSInputTarget.value = this.ProrateGDSScore(GDSScore, checkedRadios.length, unansweredCount)
                }
            }
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

    ProrateGDSScore(GDSScore, answeredCount, unansweredCount) {
        return Math.round(GDSScore + ((GDSScore / answeredCount) * unansweredCount))
    }
}