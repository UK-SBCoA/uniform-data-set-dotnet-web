
$('input[type=radio][name="A4a.TRBTIOMARK"]').change(function () {

    if ($(this).val() === '1' || $(this).val() === '9') {
        $('.treatmentTable').prop('disabled', false);
    } else {
        $('.treatmentTable').prop('disabled', true);
    }
});

