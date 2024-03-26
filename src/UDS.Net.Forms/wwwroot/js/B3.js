$(document).ready(function () {
  $('#pdNormalCheckbox').change(function () {
    if ($(this).is(':checked')) {
      defaultToZero();
    }
  });
  function defaultToZero() {
    $('input[type="radio"][name^="B3"]').each(function () {
      if ($(this).val() === "0") {
        $(this).prop('checked', true).trigger('change');
      }
    });
  } 
});