/*
This custom js is for handling the repeating child rows in the A4a. Other enabling/disabling of other fields is handled with UIBehaviors.
*/

$(document).ready(function () {

  function toggleTreatmentTable(value) {
    var enable = (value == '1' || value == '9');
    var fields = $('.treatmentTable, input[type=radio][name*="CARETRIAL"], input[type=radio][name*="TRIALGRP"]');

    fields.prop('disabled', !enable);
    if (!enable) {
      fields.each(function (f) {
        if ($(this).is(":radio") || $(this).is(":checkbox")) {
          $(this).prop("checked", false);
        }
        else {
          $(this).val("");
        }
      });
      var otherFields = $('input[name *= "TARGETOTX"], input[name *= "ADVERSEOTX"]');
      otherFields.prop('disabled', 'disabled').val("");
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

  /* Set up event handlers */
  $('input[type=radio][name*="A4a.TRTBIOMARK"]').change(function () {
    toggleTreatmentTable($(this).val());
  });


  $('input[name*="TARGETOTH"]').change(function () {
    toggleTargetotxInput(this);
  });

  /* Initialize */
  var trtbiomarkValue = $('input[type=radio][name*="A4a.TRTBIOMARK"]:checked').val();

  /* Determine how child rows should load based on TRTBIOMARK value */
  toggleTreatmentTable(trtbiomarkValue);

  /* Determine how child Other text fields should load based on that row's TARGETOTH value */
  toggleTargetotxInput($('input[name*="TARGETOTH"]:checked'));
});