(function () {

  const modeSelect = document.querySelector('[name$=".MODE"]');
  const remoteReasonSelect = document.querySelector('[name$=".RMREAS"]');
  const remoteMode = document.querySelector('[name$=".RMMODE"]');
  const notCompletedReason = document.querySelector('[name$=".NOT"]')

  function resetToDefault(select) {
    if (select) {
      select.selectedIndex = 0
      select.disabled = true
    }
  }
  function setValues(mode) {

    if (mode === 1) { //In person
      resetToDefault(remoteReasonSelect);
      resetToDefault(remoteMode);
      resetToDefault(notCompletedReason);

    }
    if (mode === 2) { //Remote
      resetToDefault(notCompletedReason);
      remoteReasonSelect.disabled = false;
      remoteMode.disabled = false;

    }
    if (mode === 3) { //Not Completed
      resetToDefault(remoteReasonSelect);
      resetToDefault(remoteMode);
      notCompletedReason.disabled = false;
    }
  }

  if (modeSelect) {
    // Handle initial state
    const initialMode = parseInt(modeSelect.value);
    setValues(initialMode);

    // Listen for changes
    modeSelect.addEventListener('change', function () {
      const selectedMode = parseInt(this.value);
      setValues(selectedMode);
    });
  }
})();
