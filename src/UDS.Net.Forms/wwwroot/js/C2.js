

//handles the dropdowns to determine whether C2 or C2T is used
const modality = document.getElementById("modalityselect");
const inputElement = document.getElementById("remote");

modality.addEventListener("change", function () {
  if (modality.value === "2") {
    inputElement.disabled = false;
  } else {
    inputElement.disabled = true
    inputElement.value = "";
  }
});