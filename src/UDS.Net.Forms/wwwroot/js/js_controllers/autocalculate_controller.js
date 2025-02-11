// wwwroot/js/js_controllers/autocalculate_controller.js
import { Controller } from "@hotwired/stimulus"

export default class extends Controller {
    static targets = ["CDRSUM", "CDRGLOB", "MEMORY", "ORIENT", "JUDGMENT", "COMMUN", "HOMEHOBB", "PERSCARE"];

    connect() {
        console.log("Connected!");

        if (this.MEMORYTarget) {
            this.MEMORYTarget.addEventListener("change", this.updateCDRSUM.bind(this));
        }
        console.log("MEMORYTarget1:", this.MEMORYTarget);


        this.MEMORYTarget.addEventListener("change", this.updateCDRSUM.bind(this))

        console.log("MEMORYTarget2:", this.MEMORYTarget);


        //  this.updateCDRSUM();
    }

    updateCDRSUM() {
        const memoryValue = this.MEMORYTarget.querySelectorAll("cells");

        console.log("memoryValue:", memoryValue);

        //const sum = parseInt(memoryValue) 

        //this.CDRSUMTarget.value = MEMORYTarget;
    }


}
