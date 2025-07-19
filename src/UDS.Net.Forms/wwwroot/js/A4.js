$(document).ready(function () {
  function toggleCheckboxes(value) {
    if (value == '1') {
      $('input[type=checkbox]').prop('disabled', false);
    } else if (value == '0') {
      $('input[type=checkbox]').prop('disabled', true).prop('checked', false);
    }
  }

  function toggleRxNorm(value) {
    if (value == '1') {
      $('input[name="SearchTerm"]').prop('disabled', false);
      $('input[name="RxNormSearch"]').prop('disabled', false);
    } else if (value == '0') {
      $('input[name="SearchTerm"]').prop('disabled', true);
      $('input[name="RxNormSearch"]').prop('disabled', true);
    }
  }

  $('input[type=radio][name="A4.ANYMEDS"]').change(function () {
    toggleCheckboxes(this.value);
    toggleRxNorm(this.value);
  });

  // initialize
  var anymedsValue = $('input[type=radio][name="A4.ANYMEDS"]:checked').val();

  if (anymedsValue === undefined) {
    anymedsValue = '0'; // if anymeds has not been selected yet, disable checkboxes
  }

  toggleCheckboxes(anymedsValue);
  toggleRxNorm(anymedsValue);
});
