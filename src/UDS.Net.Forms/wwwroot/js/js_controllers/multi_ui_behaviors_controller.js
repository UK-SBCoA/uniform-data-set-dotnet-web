
import { Controller } from '@hotwired/stimulus';

export default class extends Controller {
  static targets = ["trigger"]
  static values = {
    activeGroup: String,
    inactiveGroup: String
  }

  setDisabledAttribute(inputNames, disabledValue) {

    inputNames.forEach(inputName => {
      console.log(inputName);
      var targetElements = document.getElementsByName(inputName.trim());

      if (targetElements.length == undefined) {
        return; //DEBUG console.warn('No targets found to be affected by checkbox of id: ${checkbox.id} for property: ${propertyName}')
      }

      targetElements.forEach((element) => {
        console.log(element.id + " disabled to " + disabledValue);
        element.disabled = disabledValue;
      })
    });
  }


  activeGroupValueChanged(value, previousValue) {
    console.log("active group changed from " + previousValue + " to " + value);
    if (value == undefined) {
      return; //DEBUG console.log('Nothing here to change the state to');
    }
    var inputNames = value.split(',');
    this.setDisabledAttribute(inputNames, false);
  }

  inactiveGroupValueChanged(value, previousValue) {
    console.log("inactive group changed from " + previousValue + " to " + value);
    if (value == undefined) {
      return; //DEBUG console.log('Nothing here to change the state to');
    }
    var inputNames = value.split(',');
    this.setDisabledAttribute(inputNames, true);
  }

  updateValues(params) {
    console.log("updateValues() " + params);
    //this.activeGroupValue = activegroup;
    //this.inactiveGroupValue = inactivegroup;
  }

  updateStates(event) {
    // this is called when a trigger is changed

    let currentTrigger = event.target.id;

    this.triggerTargets.forEach(trigger => {
      if (trigger.id === currentTrigger) {
        console.log("this is the trigger causing the state change, we need to save this for last " + trigger.id);
        console.log("if value is equal to activeState " + trigger.id);
        console.log(event.params);
      }
      else {
        // change active and inactive values so all sibling triggers are reset
        this.inactiveGroupValue = trigger.dataset.multiUiBehaviorsActivegroupParam;
        this.activeGroupValue = trigger.dataset.multiUiBehaviorsInactivegroupParam;
      }
    });


  }
}