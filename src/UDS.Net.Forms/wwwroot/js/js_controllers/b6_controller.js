import { Controller } from '@hotwired/stimulus';

export default class extends Controller {

    static targets = [
        "radioTable",
        "GDSInput"
    ]

    connect() {
        //add on change to each radio input to run the calculation
    }

    CalculateGDS() {
        //check each checked radio value and set GDS. If any radios are 9 then GDS is automatically 88
    }
}