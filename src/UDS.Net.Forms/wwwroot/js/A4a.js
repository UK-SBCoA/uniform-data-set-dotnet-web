$(document).ready(function () {

    function toggleTreatmentTable(value) {
        var enable = (value == '1' || value == '9');
        var fields = $('.treatmentTable, input[type=radio][name*="CARETRIAL"], input[type=radio][name*="TRIALGRP"]');

        fields.prop('disabled', !enable);

        if (!enable) {
            fields.val(''); 
        }
    }
    $('input[type=radio][name*="A4a.TRTBIOMARK"]').change(function () {
        toggleTreatmentTable($(this).val());
    });

    var trtbiomarkValue = $('input[type=radio][name*="A4a.TRTBIOMARK"]:checked').val();
    toggleTreatmentTable(trtbiomarkValue);

    function toggleTargetotxInput(checkbox) {
        var isChecked = $(checkbox).is(':checked');
        var row = $(checkbox).closest('tr');
        var targetOtxInput = row.find('input[name$="TARGETOTX"]');
        targetOtxInput.prop('disabled', !isChecked); 
    }

    $('input[name*="TARGETOTH"]').each(function () {
        toggleTargetotxInput(this);
    });

    $('input[name*="TARGETOTH"]').change(function () {
        toggleTargetotxInput(this);
    });

    toggleTargetotxInput($('input[name*="TARGETOTH"]:checked'));
});