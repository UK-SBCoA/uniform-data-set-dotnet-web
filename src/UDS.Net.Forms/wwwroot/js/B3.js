$(document).ready(function () {
  $('#pdNormalCheckbox').change(function () {
    if ($(this).is(':checked')) {
      defaultToZero();
    }
  });

  $('input[type="radio"][name^="B3"]').change(function () {
    updateTotal();
  });

  function defaultToZero() {
    $('input[type="radio"][name^="B3"]').each(function () {
      if ($(this).val() === "0") {
        $(this).prop('checked', true).trigger('change');
      }
    });
  }
  function updateTotal() {
    var total = 0;
    var untestable = false
    $('input[type="radio"][name^="B3"]:checked').each(function () {
      total += parseInt($(this).val());
      if ($(this).val() === "8") {
        untestable = true;
      }
    });
    if (untestable) {
      $('#B3_TOTALUPDRS').val("888");
    } else {
      $('#B3_TOTALUPDRS').val(total);
    }
    if (total > 0) {
      $('#pdNormalCheckbox').prop('checked', false);

    }

  }
});