//a target will have actions and recievers. actions toggle the state and recievers are toggled

//right now stimulus attributes on a single checkbox will disable a single radio group.
//check to see if we can have this disable working in 2 seperate areas on the form

//check to see if we can flip the logic with parameters (may need to get the onload data correctly set first)

import { Controller } from '@hotwired/stimulus';

export default class extends Controller {
    static targets = ["parent", "child"]

    initialize() {
        console.log("checkboxDisable is loaded")
        //do the loading code here to set the disables on page load
    }

    //DEVNOTE: parameters cannot have capital case in name
    ToggleGroup({ params: { targetname, disable } }) {

        //use the target value = the element in context
        var isChecked = this.parentTarget.checked

        var targetElements = document.getElementsByName(targetname)
        targetElements.forEach((element) => {
            if (isChecked) {
                element.disabled = disable
            } else {
                element.disabled = !disable
            }
        })
    }
}