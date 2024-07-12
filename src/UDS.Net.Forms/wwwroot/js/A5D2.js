/*Implemented on questions 6a1 6a2 and 6a3 or form A5D2*/


$(document).ready(function () {
  let majorDepRadio = document.querySelector('input[name="A5D2.MAJORDEP"]:checked');
  let otherDepRadio = document.querySelector('input[name="A5D2.OTHERDEP"]:checked');
  const deprTreatRadios = document.querySelectorAll('input[name="A5D2.DEPRTREAT"]');

  function toggleDeprTreat() {
    const majorDepChecked = majorDepRadio && majorDepRadio.value == '1';
    const otherDepChecked = otherDepRadio && otherDepRadio.value == '1';
    const enableDepTreat = majorDepChecked || otherDepChecked;

    deprTreatRadios.forEach(radio => {
      radio.disabled = !enableDepTreat;
    });
  }

  document.querySelectorAll('input[name="A5D2.MAJORDEP"]').forEach(radio => {
    radio.addEventListener('change', function () {
      majorDepRadio = this;
      toggleDeprTreat();
    });
  });

  document.querySelectorAll('input[name="A5D2.OTHERDEP"]').forEach(radio => {
    radio.addEventListener('change', function () {
      otherDepRadio = this;
      toggleDeprTreat();
    });
  });

  toggleDeprTreat();
});