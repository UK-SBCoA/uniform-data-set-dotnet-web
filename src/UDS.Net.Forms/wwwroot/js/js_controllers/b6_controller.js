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

        //Only run calculations when all questions are answered
        if (answeredCheckedRadios.length + unansweredCheckedRadios.length == totalQuestionCount) {
            //if fewer than 12 questions were answered check NOGDS and auto set 88
            if (unansweredCheckedRadios.length > 3) {

                this.NOGDSInputTarget.checked = true
                this.GDSInputTarget.value = 88
            }
            else if(unansweredCheckedRadios.length <= 3) {
                //if 12 or more questions are answered, auto uncheck NOGDS and continue with calculations
                this.NOGDSInputTarget.checked = false

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
        }
        //if NOGDS selected, GDS score will always be 88
        else if (this.NOGDSInputTarget.checked) {
            this.GDSInputTarget.value = 88
        }
        //if not all radios are selected and NOGDS is not selected, clear GDS score
        else {
            this.GDSInputTarget.value = ""
        }
    }

    
    NOGDSBehavior() {
        this.CalculateGDS()
    }

    ProrateGDSScore(GDSScore, answeredCount, unansweredCount) {
        return Math.round(GDSScore + ((GDSScore / answeredCount) * unansweredCount))
    }
}