/*Implemented on questions 6a1 6a2 and 6a3 form A5D2*/

$(document).ready(function () {
  var majorDepRadios = Array.from(document.getElementsByName("A5D2.MAJORDEP"));
  var otherDepRadios = Array.from(document.getElementsByName("A5D2.OTHERDEP"));
  var deprTreatRadios = Array.from(
    document.getElementsByName("A5D2.DEPRTREAT"),
  );

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
  majorDepRadios.forEach((radio) =>
    radio.addEventListener("change", toggleDeprTreat),
  );
  otherDepRadios.forEach((radio) =>
    radio.addEventListener("change", toggleDeprTreat),
  );

  toggleDeprTreat();
});
