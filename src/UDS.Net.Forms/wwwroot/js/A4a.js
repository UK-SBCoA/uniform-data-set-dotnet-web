/*
This custom js is for handling the repeating child rows in the A4a. Other enabling/disabling of other fields is handled with UIBehaviors.
*/

$(document).ready(function () {

    function toggleTreatmentTable(value) {
        var enable = (value == '1' || value == '9');
        var fields = $('.treatmentTable, input[type=radio][name*="CARETRIAL"], input[type=radio][name*="TRIALGRP"]');

        fields.prop('disabled', !enable);
        if (!enable) {
            fields.each(function () {
                if ($(this).is(":radio") || $(this).is(":checkbox")) {
                    $(this).prop("checked", false);
                } else {
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

    // Enable/disable TRIALGRP based on CARETRIAL radio selection
    function toggleTrialGroupRadioGroup(row) {
        var careTrialValue = row.find('input[type=radio][name*="CARETRIAL"]:checked').val();
        var trialGroupRadios = row.find('input[type=radio][name*="TRIALGRP"]');

        if (careTrialValue === '1') {
            trialGroupRadios.prop('disabled', true).prop('checked', false);
        } else {
            trialGroupRadios.prop('disabled', false);
        }
    }

    /* Set up event handlers */
    $('input[type=radio][name*="A4a.TRTBIOMARK"]').change(function () {
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

});
