/*
This custom js is for handling the repeating child rows in the A4a. Other enabling/disabling of other fields is handled with UIBehaviors.
*/

$(document).ready(function () {

  function toggleTreatmentTable(value) {
    var enable = (value == '1');
    var fields = $('.treatmentTable, input[type=radio][name*="CARETRIAL"], input[type=radio][name*="TARGETOTX"]');
    fields.prop('disabled', !enable);
    if (!enable) {
      fields.each(function () {
        if ($(this).is(":radio") || $(this).is(":checkbox")) {
          $(this).prop("checked", false);
        } else {
          $(this).val("");
        }
      });

      $('input[type=radio][name*="TRIALGRP"]').prop('disabled', true).prop('checked', false);
    }
  }

  /* Child row TARGETOTH checkbox and TARGETOTX input */
  function toggleTargetotxInput(checkbox) {
    var isChecked = $(checkbox).is(':checked');
    var row = $(checkbox).closest('tr');
    var targetOtxInput = row.find('input[name$="TARGETOTX"]');
    targetOtxInput.prop('disabled', !isChecked);
    if (!isChecked) {
      targetOtxInput.val("");
    }
  }

  // Enable/disable TRIALGRP based on CARETRIAL radio selection
  function toggleTrialGroupRadioGroup(row) {
    var careTrialValue = row.find('input[type=radio][name*="CARETRIAL"]:checked').val();
    var trialGroupRadios = row.find('input[type=radio][name*="TRIALGRP"]');

    if (careTrialValue === '2' || careTrialValue === '3') {
      trialGroupRadios.prop('disabled', false);
    } else {
      trialGroupRadios.prop('disabled', true).prop('checked', false);
    }
  }

  /* Set up event handlers */
  $('input[type=radio][name*="A4a.TRTBIOMARK"]').change(function () {
    toggleTreatmentTable($(this).val());
  });
  $('input[type=radio][name*="A4a.NEWTREAT"]').change(function () {
    toggleTreatmentTable($(this).val());
  });

  $('input[name*="TARGETOTH"]').change(function () {
    toggleTargetotxInput(this);
  });

  $('input[type=radio][name*="CARETRIAL"]').change(function () {
    var row = $(this).closest('tr');
    toggleTrialGroupRadioGroup(row);
  });

  /* Initialize */
  var trtbiomarkValue = $('input[type=radio][name*="A4a.TRTBIOMARK"]:checked').val();

  /* Determine how child rows should load based on TRTBIOMARK value */
  toggleTreatmentTable(trtbiomarkValue);

  // Loop through rows to initialize TARGETOTX and TRIALGRP fields
  $('tr').each(function () {
    // Initialize TARGETOTX (Other checkbox/text pairing)
    var targetOthCheckbox = $(this).find('input[name*="TARGETOTH"]');
    if (targetOthCheckbox.length) {
      toggleTargetotxInput(targetOthCheckbox);
    }

    // Initialize TRIALGRP based on CARETRIAL
    toggleTrialGroupRadioGroup($(this));
  });


  //#region Handles UI Behaviors of NEWTREAT && NEWADEVENT
  function setNewTreatAndAdEvent() {
    if (!a4ainputs) {
      return;
    }

    const inputs = Array.from(a4ainputs.querySelectorAll("input"));

    const excludedNames = ["A4a.ARIAE", "A4a.ARIAH", "A4a.ADVERSEOTH", "A4a.ADVERSEOTX"];

    const newTreatInputs = inputs.filter(input =>
      !excludedNames.includes(input.name)
    );
    const newAdEventInputs = inputs.filter(input =>
      excludedNames.includes(input.name)
    );

    const newTreat = a4ainputs.querySelectorAll('input[type=radio][name="A4a.NEWTREAT"]');
    const newAdEvent = a4ainputs.querySelectorAll('input[name="A4a.NEWADEVENT"]');

    if (newTreat.length === 0 || newAdEvent.length === 0) {
      return;
    }

    let newTreatHasChanged = false;
    let newAdEventHasChanged = false;

    function setInitialState() {
      newTreat.forEach(radio => {
        if (radio.value === "1") {
          radio.checked = false;
        } else if (radio.value === "0" || radio.value === "9") {
          radio.disabled = false;
        }
      });

      newAdEvent.forEach(radio => {
        if (radio.value === "1") {
          radio.checked = false;
        } else if (radio.value === "0" || radio.value === "9") {
          radio.disabled = false;
        }
      });
    }

    function setNewTreatChangedState() {
      newTreat.forEach(radio => {
        if (radio.value === "1") {
          radio.checked = true;
          radio.disabled = false;
        }
      });
    }
    function setNewAdEventChangedState() {
      newAdEvent.forEach(radio => {
        if (radio.value === "1") {
          radio.checked = true;
          radio.disabled = false;
        }
      });
    }

    setInitialState();

    newTreatInputs.forEach(input => {
      input.addEventListener('input', (event) => {

        if (event.target.name === "A4a.NEWTREAT") return;
        if (event.target.name === "A4a.NEWADEVENT") return;

        if (!newTreatHasChanged) {
          newTreatHasChanged = true;
          setNewTreatChangedState();
        }
      });
    });
    newAdEventInputs.forEach(input => {
      input.addEventListener('input', (event) => {

        if (event.target.name === "A4a.NEWTREAT") return;
        if (event.target.name === "A4a.NEWADEVENT") return;

        if (!newAdEventHasChanged) {
          newAdEventHasChanged = true;
          setNewAdEventChangedState();
        }
      });
    });
  }

  setNewTreatAndAdEvent();
  //#endregion
});
