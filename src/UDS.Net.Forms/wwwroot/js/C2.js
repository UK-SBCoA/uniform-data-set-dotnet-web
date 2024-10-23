

//handles the dropdowns to determine whether C2 or C2T is used
const mode = document.getElementById("modeselect");
const inputElement = document.getElementById("remote");

mode.addEventListener("change", function () {
  if (mode.value === "2") {
    inputElement.disabled = false;
  } else {
    inputElement.disabled = true
    inputElement.value = "";
  }
});