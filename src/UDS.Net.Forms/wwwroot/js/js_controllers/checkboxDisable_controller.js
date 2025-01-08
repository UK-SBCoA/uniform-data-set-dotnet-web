﻿/*
DESCRIPTION:
checkboxDisable_controller.js is for custom UI behavior for disabling and enabling inputs by their name attribute when a checkbox is checked, using stimulus.js

HTML USAGE:
     <div class="flex h-6 items-center">
                 @Html.CheckBox("A1.GENNOANS", Model.A1.GENNOANS, new
                     {
                         @class = "h-4 w-4 rounded border-gray-300 text-indigo-600 focus:ring-indigo-600 disabled:bg-slate-50 disabled:text-slate-500 disabled:border-slate-200 disabled:shadow-none",
                         data_checkBoxDisable_target = "checkboxTrigger",
                         data_action = "input->checkboxDisable#ToggleGroup",
                         data_checkBoxDisable_enableGroup_param = "",
                         data_checkBoxDisable_disableGroup_param = "A1.GENMAN,A1.GENWOMAN,A1.GENTRMAN,A1.GENTRWOMAN,A1.GENNONBI,A1.GENOTH,A1.GENDKN,A1.GENOTH",
                         data_checkboxDisable_toggleState_param = "true"
                     })
             </div>

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

      if (targetElements.length == undefined) {
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
    /*    console.log(event.params);*/

    //if (togglestate == undefined || enablegroup == undefined || disablegroup == undefined) {
    //  return console.error($'Missing required parameters on a target element with id: this.event.checkbox')
    //}

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
    for (let checkbox of this.checkboxTriggerTargets) {
      let toggleStateString = checkbox.dataset.checkboxdisableTogglestateParam
      let enablegroup = checkbox.dataset.checkboxdisableEnablegroupParam
      let disablegroup = checkbox.dataset.checkboxdisableDisablegroupParam

      console.log(toggleStateString);
      console.log(enablegroup);
      console.log(disablegroup);
      //due to javascript typing, a boolean needs to be set manually to the destructured parameter or it will read as a string
      //Stimulus only assumes type when using params with an action
      let togglestate = new Boolean()

      if (toggleStateString == "false")
        togglestate = false

      if (toggleStateString == "true")
        togglestate = true

      if (checkbox.checked) {
        this.ToggleGroup({ params: { enablegroup, disablegroup, togglestate }, currentTarget: checkbox })
        break;
      }
    }
  }
}