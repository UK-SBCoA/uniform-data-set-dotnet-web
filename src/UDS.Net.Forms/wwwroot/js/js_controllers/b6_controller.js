import { Controller } from '@hotwired/stimulus';

export default class extends Controller {

    static targets = [
        "GDSInput",
        "NOGDSInput",
        "radioInput"
    ]

    connect() {
        this.CalculateGDS()
        this.NOGDSBehavior()
    }

    CalculateGDS() {
        const totalQuestionCount = 15

        let skipCalculation = this.NOGDSInputTarget.checked ? true : false
        let GDSScore = 0;

        if (!skipCalculation) {
            let answeredCheckedRadios = this.radioInputTargets.filter(input => input.checked && input.value != 9)

            let unansweredCheckedRadios = this.radioInputTargets.filter(input => input.checked && input.value == 9)
           
            answeredCheckedRadios.forEach((radio) => {
                GDSScore += Number(radio.value)
            })

            //display the total only when all radios have been checked
            if (answeredCheckedRadios.length + unansweredCheckedRadios.length == totalQuestionCount) {
                // all questions are != 9, then do not prorate score
                if (unansweredCheckedRadios.length < 1) {
                    this.GDSInputTarget.value = GDSScore
                } else {
                    this.GDSInputTarget.value = this.ProrateGDSScore(GDSScore, answeredCheckedRadios.length, unansweredCheckedRadios.length)
                }
            }
        } else {
            this.GDSInputTarget.value = 88
        }
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