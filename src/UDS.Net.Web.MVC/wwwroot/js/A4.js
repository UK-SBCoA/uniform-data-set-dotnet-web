$(document).ready(function () {
    $('input[type=radio][name="A4.ANYMEDS"]').change(function () {
        if (this.value == '1') {
            $('input[type=checkbox]').prop('disabled', false);
        }
        else if (this.value == '0') {
            $('input[type=checkbox]').prop('disabled', true).prop('checked', false);
        }
    });
});