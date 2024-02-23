//INSTRUCTION:
//this toggle logic was created for the a1a form question 39 logic. If the "not applicable" checkbox is checked, then disable all other checkboxes in section and disable the following #40 radio group.
//If a checkbox other than "not applicable" was checked, then disable the "not applicable" checkbox and enable the following #40 radio group.

class A1aDiscriminationToggle {

    OnLoad() {
        this.SetDisableProperties()
    }

    SetDisableProperties() {
        //preset select queries
        let notApplicableIsChecked = $('input[type="checkbox"][name="A1a.EXPNOTAPP"]').is(':checked')
        //a checkbox other than "not applicable" has been checked in the question 39 section
        let otherThanNotApplicableIsChecked = $("#discriminationReasonSection").find("input[type='checkbox']:not(input[type='checkbox'][name='A1a.EXPNOTAPP']").is(':checked')

        //if "Not Applicable" (39a14) is checked, disable all other checkboxes in section
        if (notApplicableIsChecked) {
            this.DisableAllCheckboxesButEXPNOTAPP(true)
            this.DisableEXPNOTAPPCheckbox(false)
            this.DisableEXPSTRSGroup(true)
        }

        //if another checkbox is besides "Not Applicable" (39a14) is checked, then disable "Not applicable"
        if (otherThanNotApplicableIsChecked) {
            this.DisableAllCheckboxesButEXPNOTAPP(false)
            this.DisableEXPNOTAPPCheckbox(true)
            this.DisableEXPSTRSGroup(false)
        }

        //if no checkbox is selected, then enable all the checkboxes
        if (!notApplicableIsChecked && !otherThanNotApplicableIsChecked) {
            this.DisableAllCheckboxesButEXPNOTAPP(false)
            this.DisableEXPNOTAPPCheckbox(false)
            this.DisableEXPSTRSGroup(false)
        }
    }

    DisableAllCheckboxesButEXPNOTAPP(disableValue) {
        $("#discriminationReasonSection").find("input[type='checkbox']:not(input[type='checkbox'][name='A1a.EXPNOTAPP'])").attr("disabled", disableValue)
    }

    DisableEXPNOTAPPCheckbox(disableValue) {
        $('input[type="checkbox"][name="A1a.EXPNOTAPP"]').attr("disabled", disableValue)
    }

    DisableEXPSTRSGroup(disableValue) {
        $('input[type="radio"][name="A1a.EXPSTRS"]').attr("disabled", disableValue)
    }
}

$(() => {
    a1aDiscriminationToggle = new A1aDiscriminationToggle()

    //run disable logic on initial form load
    a1aDiscriminationToggle.OnLoad()

    //run the disable logic when a checkbox in the question 39 section is changed
    $('#discriminationReasonSection input[type="checkbox"]').on("change", () => {
        a1aDiscriminationToggle.SetDisableProperties()
    })
})