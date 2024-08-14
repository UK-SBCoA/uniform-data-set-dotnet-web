class MilestoneTypeBehavior {
  disableSectionOnChange() {
    let milestoneTypeValue = $(
      'input[name="Milestone.MILESTONETYPE"]:checked',
    ).val();
    if (milestoneTypeValue == 0) {
      this.disableBoxA();
    } else if (milestoneTypeValue == 1) {
      this.disableBoxB();
    }
  }

  disableBoxA() {
    $(".boxA input").prop("disabled", true);
    $(".boxB input").prop("disabled", false);
  }

  disableBoxB() {
    $(".boxA input").prop("disabled", false);
    $(".boxB input").prop("disabled", true);
  }
}

$(() => {
  const milestoneTypeBehavior = new MilestoneTypeBehavior();

  $("input[name='Milestone.MILESTONETYPE']").on("change", () => {
    milestoneTypeBehavior.disableSectionOnChange();
  });

  milestoneTypeBehavior.disableSectionOnChange();
});
