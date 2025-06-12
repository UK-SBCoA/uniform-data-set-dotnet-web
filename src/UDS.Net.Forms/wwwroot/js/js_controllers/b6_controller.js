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
        let GDSScore = 0;

        let answeredCheckedRadios = this.radioInputTargets.filter(input => input.checked && input.value != 9)
        let unansweredCheckedRadios = this.radioInputTargets.filter(input => input.checked && input.value == 9)

        //if fewer than 12 questions were answered check NOGDS, auto set 88, and end CalculateGDS method
        if (unansweredCheckedRadios.length > 3) {
            this.NOGDSInputTarget.checked = true
            this.NOGDSBehavior()

            return
        }
        else {
            //if 12 or more questions are answered, auto uncheck NOGDS and continue with calculations
            this.NOGDSInputTarget.checked = false
        }

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