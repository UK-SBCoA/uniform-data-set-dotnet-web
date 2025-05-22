/*
 * js/js_controllers/checkbox_disable_controller.js
 * DESCRIPTION:
 * Disabling and enabling child inputs by their name attribute when a checkbox is checked

HTML USAGE:
     <div class="flex h-6 items-center">
          @Html.CheckBox("A1.GENNOANS", Model.A1.GENNOANS, new
              {
                  @class = "h-4 w-4 rounded border-gray-400 text-indigo-600 focus:ring-indigo-600 disabled:bg-slate-50 disabled:text-slate-500 disabled:border-slate-200 disabled:shadow-none",
                  data_checkbox_disable_target = "trigger",
                  data_action = "input->checkbox-disable#ToggleGroup",
                  data_checkbox_disable_enableGroup_param = "",
                  data_checkbox_disable_disableGroup_param = "A1.GENMAN,A1.GENWOMAN,A1.GENTRMAN,A1.GENTRWOMAN,A1.GENNONBI,A1.GENOTH,A1.GENDKN,A1.GENOTH",
                  data_checkbox_disable_toggleState_param = "true"
              })
      </div>

*/

/*
 TODO This controller was initally created to support the A1a form. The complexity grew when the code was modified to support the A1 form as well.
 We should be able to refactor this so that it uses the stimulus targets instead of the the group params that are currently used.
*/

import { Controller } from '@hotwired/stimulus';

export default class extends Controller {
  static targets = ["trigger"]

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
      return; //DEBUG console.log('Nothing here to change the state to');
    }
    var propertyNames = group.split(',')

    propertyNames.forEach(propertyName => {
      //get all elements that are to be affected by checkbox using javascript
      var targetElements = document.getElementsByName(propertyName.trim());

      if (targetElements.length == undefined) {
        return; //DEBUG console.warn('No targets found to be affected by checkbox of id: ${checkbox.id} for property: ${propertyName}')
      }

      targetElements.forEach((element) => {
        element.disabled = disableValue;
      })
    });
  }

  /*
    ToggleGroup is called when the checkbox is changed
  */
  ToggleGroup(event) {
    const { enablegroup, disablegroup, togglestate } = event.params;
    const checkbox = event.currentTarget;

    var isChecked = checkbox.checked

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
    for (let checkbox of this.triggerTargets) {
      let toggleStateString = checkbox.dataset.checkboxDisableTogglestateParam
      let enablegroup = checkbox.dataset.checkboxDisableEnablegroupParam
      let disablegroup = checkbox.dataset.checkboxDisableDisablegroupParam

      //due to javascript typing, a boolean needs to be set manually to the destructured parameter or it will read as a string
      //Stimulus only assumes type when using params with an action
      let togglestate = new Boolean()

      if (toggleStateString == "false")
        togglestate = false

      if (toggleStateString == "true")
        togglestate = true

      // Need to call toggle group on each checkboxDisable checkbox
      // console.log("Setting up state for " + checkbox.id);
      // if checkbox is disabled, don't run togglegroup
      if (checkbox.disabled == false) {
        this.ToggleGroup({ params: { enablegroup, disablegroup, togglestate }, currentTarget: checkbox });
      }
    }
  }
}