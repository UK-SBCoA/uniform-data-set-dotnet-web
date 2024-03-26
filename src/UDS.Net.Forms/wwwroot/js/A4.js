$(document).ready(function () {
    function toggleCheckboxes(value) {
        if (value == '1') {
            $('input[type=checkbox]').prop('disabled', false);
        } else if (value == '0') {
            $('input[type=checkbox]').prop('disabled', true).prop('checked', false);
        }
    }

    $('input[type=radio][name="A4.ANYMEDS"]').change(function () {
        toggleCheckboxes(this.value);
    });

    var anymedsValue = $('input[type=radio][name="A4.ANYMEDS"]:checked').val();
    toggleCheckboxes(anymedsValue);
});
