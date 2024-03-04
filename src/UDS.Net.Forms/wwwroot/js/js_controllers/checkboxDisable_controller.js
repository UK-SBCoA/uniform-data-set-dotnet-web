/*
DESCRIPTION:
checkboxDisable_controller.js is a custom front end validation for disabling and enabling inputs by their name attribute when a checkbox is checked, using stimulus.js

HTML USAGE:
<div>
    @Html.CheckBox("A1a.EXPNOTAPP", Model.A1a.EXPNOTAPP, new {@class = "h-4 w-4 rounded border-gray-300 text-indigo-600 focus:ring-indigo-600",
        data_checkBoxDisable_target = "checkboxTrigger",
        data_action = "input->checkboxDisable#ToggleGroup",
        data_checkBoxDisable_group_param = "A1a.EXPSTRS",
        data_checkboxDisable_disable_param = "true"})
</div>

STIMULUS PARAMETERS:
data_checkboxDisable_group_param = the name of the input(s) you are wanting to disable
data_checkboxDisable_disable_param = a flag for if clicking the checkbox disables or enables the group. true = disable on check and false = enable on check
*/

import { Controller } from '@hotwired/stimulus';

export default class extends Controller {
    static targets = ["checkboxTrigger"]

    initialize() {
        this.OnLoad()
    }

    ToggleGroup({ params: { group, disable } }) {

        if (group == undefined || disable == undefined) {
            return console.error(`Missing required parameter of group or disable on a target element with id: ${this.checkboxTriggerTarget.id}`)
        }

        var isChecked = this.checkboxTriggerTarget.checked
        //apply disable value if the checkbox is checked and the opposite when unchecked
        var disableValue = isChecked ? disable : !disable
        //get all elements that are to be effected by checkbox using javascript
        var targetElements = document.getElementsByName(group)

        if (targetElements.length < 1) {
            return console.warn(`No targets found to be effected by checkbox of id: ${this.checkboxTriggerTarget.id}`)
        }

        targetElements.forEach((element) => {
            element.disabled = disableValue
        })
    }

    OnLoad() {
        this.checkboxTriggerTargets.forEach(() => {

            let disableString = this.checkboxTriggerTarget.dataset.checkboxdisableDisableParam
            let group = this.checkboxTriggerTarget.dataset.checkboxdisableGroupParam

            //due to javascript typing, a boolean needs to be set manually to the destructured parameter or it will read as a string
            //Stimulus only assumes type when using params with an action
            let disable = new Boolean()

            if (disableString == "false")
                disable = false

            if (disableString == "true")
                disable = true

            this.ToggleGroup({ params: { group, disable } })
        })
    }
}