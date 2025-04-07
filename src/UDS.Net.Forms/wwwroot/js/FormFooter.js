document.addEventListener('DOMContentLoaded', function () {
  const modeSelect = document.querySelector('[name$=".MODE"]');
  const remoteReasonSelect = document.querySelector('[name$=".RMREAS"]');
  const remoteMode = document.querySelector('[name$=".RMMODE"]');
  const notCompletedReason = document.querySelector('[name$=".NOT"]')

  function resetToDefault(select) {
    if (select) select.selectedIndex = 0
  }
  modeSelect.addEventListener('change', function () {

    const mode = parseInt(this.value);

    if (mode === 1) { //In person
      resetToDefault(remoteReasonSelect);
      resetToDefault(remoteMode);
      resetToDefault(notCompletedReason);

    }
    if (mode === 2) { //Remote
      resetToDefault(notCompletedReason);
    }
    if (mode === 3) { //Not Completed
      resetToDefault(remoteReasonSelect);
      resetToDefault(remoteMode);
    }
  });
});
