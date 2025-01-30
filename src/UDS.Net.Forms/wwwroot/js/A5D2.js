/*Implemented on questions 6a1 6a2 and 6a3 form A5D2*/

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
        if (MENARCHEInput.value >= 5 && MENARCHEInput.value <= 25 | MENARCHEInput.value == 99) {
            NOMENSAGEInput.disabled = false
        } else {
            NOMENSAGEInput.disabled = true
            NOMENSAGEInput.value = "";
        }
    }

    function ToggleNOMENSAGECheckboxes() {
        if (NOMENSAGEInput.value >= 10 && NOMENSAGEInput.value <= 70 | NOMENSAGEInput.value == 99) {
            NOMENSAGECheckboxes.forEach((checkbox) => {
                checkbox.disabled = false
            })
        } else {
            NOMENSAGECheckboxes.forEach((checkbox) => {
                checkbox.disabled = true
            })
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


    //On load methods
    toggleDeprTreat();
    MENARCHEBehavior();
    ToggleNOMENSAGECheckboxes()
});
