

//handles the dropdowns to determine whether C2 or C2T is used

$(document).ready(function () {
  const modality = document.getElementById("modalityselect");
  const inputElement = document.getElementById("remote");

  function handleDropdownChange() {
    if (modality.value === "2") {
      inputElement.disabled = false;
    } else {
      inputElement.disabled = true;
      inputElement.value = "";
    }
  }
  handleDropdownChange();

  modality.addEventListener("change", handleDropdownChange);
});
