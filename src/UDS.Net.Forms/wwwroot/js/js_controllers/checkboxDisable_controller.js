/*
DESCRIPTION:
checkboxDisable_controller.js is for custom UI behavior for disabling and enabling inputs by their name attribute when a checkbox is checked, using stimulus.js

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

  /*
    There are only two states to a checkbox. We need:
    1. Which state will control the toggle (currently named disable)
    2. When the toggle is activated then EnableGroup inputs will be enabled
    3. When the toggle is activated then DisableGroup inputs will be disabled
  */

  IterateAndSetDisable(group, disableValue) {
    //split the group parameter into an array of property names
    if (group == undefined) {
      return console.log('Nothing here to change the state to');
    }
    var propertyNames = group.split(',')

    propertyNames.forEach(propertyName => {
      //get all elements that are to be affected by checkbox using javascript
      var targetElements = document.getElementsByName(propertyName.trim());

      if (targetElements.length < 1) {
        return console.warn('No targets found to be affected by checkbox of id: ${checkbox.id} for property: ${propertyName}')
      }

      targetElements.forEach((element) => {
        element.disabled = disableValue;
      })
    });
  }

  ToggleGroup(event) {
    const { enablegroup, disablegroup, togglestate } = event.params;
    const checkbox = event.currentTarget;
    console.log(event.params);

    if (togglestate == undefined || enablegroup == undefined || disablegroup == undefined) {
      return console.error('Missing required parameters on a target element with id: ${this.checkboxTriggerTarget.id}')
    }

    var isChecked = checkbox.checked
    //apply disable value if the checkbox is checked and the opposite when unchecked
    //var disableValue = isChecked ? disable : !disable

    if (isChecked == togglestate) {
      this.IterateAndSetDisable(enablegroup, false);
      this.IterateAndSetDisable(disablegroup, true);
    }
    else {
      this.IterateAndSetDisable(enablegroup, true);
      this.IterateAndSetDisable(disablegroup, false);
    }




  }

  OnLoad() {
    for (let checkbox of this.checkboxTriggerTargets) {
      let toggleStateString = checkbox.dataset.checkboxdisableTogglestateParam
      let enableGroup = checkbox.dataset.checkboxdisableEnablegroupParam
      let disableGroup = checkbox.dataset.checkboxdisableDisablegroupParam

      console.log(toggleStateString);
      console.log(enableGroup);
      console.log(disableGroup);
      //due to javascript typing, a boolean needs to be set manually to the destructured parameter or it will read as a string
      //Stimulus only assumes type when using params with an action
      let toggleState = new Boolean()

      if (toggleStateString == "false")
        toggleState = false

      if (toggleStateString == "true")
        toggleState = true

      if (checkbox.checked) {
        this.ToggleGroup({ params: { enableGroup, disableGroup, toggleState }, currentTarget: checkbox })
        break;
      }
    }
  }
}