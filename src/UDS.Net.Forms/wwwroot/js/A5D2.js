/*
  Question 6a3 DEPRTREAT UI state is controlled by MAJORDEP and OTHERDEP, two parent inputs.
  MENARCHE child inputs are enabled/disabled based on range of MENARCHE
  NOMENSAGE checkboxes are enabled/disabled based on range of NOMENSAGE
*/
$(document).ready(function () {

  //element selectors
  var majorDepRadios = Array.from(document.getElementsByName("A5D2.MAJORDEP"));
  var otherDepRadios = Array.from(document.getElementsByName("A5D2.OTHERDEP"));
  var deprTreatRadios = Array.from(document.getElementsByName("A5D2.DEPRTREAT"));
  let NOMENSAGEInput = document.getElementById("A5D2_NOMENSAGE");
  let MENARCHEInput = document.getElementById("A5D2_MENARCHE");

  //Get NOMENSAGE checkboxes
  let NOMENSAGECheckboxSection = document.getElementById("NOMENSAGECheckboxSection");
  let NOMENSAGECheckboxes = NOMENSAGECheckboxSection.querySelectorAll('input[type="checkbox"]');

  function toggleDeprTreat() {
    const recentMajorDep = majorDepRadios.some(
      (radio) => radio.checked && radio.value == "1",
    );
    const recentOtherDep = otherDepRadios.some(
      (radio) => radio.checked && radio.value == "1",
    );

    deprTreatRadios.forEach((radio) => {
      radio.disabled = !(recentMajorDep || recentOtherDep);
    });
  }

  function MENARCHEBehavior() {
    if (MENARCHEInput.value >= 5 && MENARCHEInput.value <= 25 | MENARCHEInput.value == 999) {
      NOMENSAGEInput.disabled = false
    } else {
      NOMENSAGEInput.disabled = true
      NOMENSAGEInput.value = "";
      ToggleNOMENSAGECheckboxes();
      // WORKAROUND for resetting state of grandchildren
      $('input[name="A5D2.HRTYEARS"]').attr("disabled", "disabled").val("");
      $('input[name="A5D2.HRTSTRTAGE"]').attr("disabled", "disabled").val("");
      $('input[name="A5D2.HRTENDAGE"]').attr("disabled", "disabled").val("");
      $('input[name="A5D2.BCPILLSYR"]').attr("disabled", "disabled").val("");
      $('input[name="A5D2.BCSTARTAGE"]').attr("disabled", "disabled").val("");
      $('input[name="A5D2.BCENDAGE"]').attr("disabled", "disabled").val("");
    }
  }

  function ToggleNOMENSAGECheckboxes() {
    if (NOMENSAGEInput.value >= 10 && NOMENSAGEInput.value <= 70 | NOMENSAGEInput.value == 999) {
      NOMENSAGECheckboxes.forEach((checkbox) => {
        checkbox.disabled = false
      })
    } else {
      NOMENSAGECheckboxes.forEach((checkbox) => {
        checkbox.disabled = true
        checkbox.checked = false;
      })
      $('input[name="A5D2.NOMENSOTHX"]').attr("disabled", "disabled").val("");
    }
  }

  //Event listeners
  majorDepRadios.forEach((radio) =>
    radio.addEventListener("change", toggleDeprTreat),
  );

  otherDepRadios.forEach((radio) =>
    radio.addEventListener("change", toggleDeprTreat),
  );

  NOMENSAGEInput.addEventListener("change", ToggleNOMENSAGECheckboxes)

  MENARCHEInput.addEventListener("change", MENARCHEBehavior)

  //On load methods
  toggleDeprTreat();
  MENARCHEBehavior();
  ToggleNOMENSAGECheckboxes()
});
