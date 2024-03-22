$(document).ready(function () {
    $('input[type=radio][name*="CARETRIAL"]').prop('disabled', true);
    $('input[type=radio][name*="TRIALGRP"]').prop('disabled', true);

    function toggleTreatmentTable(value) {
        var enable = (value == '1' || value == '9');
        $('.treatmentTable').prop('disabled', !enable);
        $('input[type=radio][name*="CARETRIAL"]').prop('disabled', !enable);
        $('input[type=radio][name*="TRIALGRP"]').prop('disabled', !enable);
    }

    $('input[type=radio][name*="A4a.TRTBIOMARK"]').change(function () {
        toggleTreatmentTable($(this).val());
    });

    var trtbiomarkValue = $('input[type=radio][name*="A4a.TRTBIOMARK"]:checked').val();
    toggleTreatmentTable(trtbiomarkValue);
});
