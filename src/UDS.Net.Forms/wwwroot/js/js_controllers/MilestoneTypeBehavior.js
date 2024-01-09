//MilestoneTypeBehavior.js is an alternative to the edit/create pageModel Behavior for Milestone.
//This file will disable and enable fields based on the milestoneType while also
//setting the milestoneType value when loading an existing form by checking the Deceased and Discont values
//if either deceased or discont are select, milestoneType == NO FURTHER CONTACT

class MilestoneTypeBehavior {
    SetMilestoneType() {
        let milestoneTypes = $("input[name='Milestone.MilestoneType']")
        let deceasedInput = $("#Milestone_DECEASED")
        let discontInput = $("#Milestone_DISCONT")
    
        if ($(deceasedInput).is(':checked') || $(discontInput).is(':checked')) {
            $(milestoneTypes[0]).prop("checked", true)
            this.DisableBoxA()
        } else {
            $(milestoneTypes[1]).prop("checked", true)
            this.DisableBoxB()
        }
    }

    DisableSectionOnChange() {
        let milestoneTypeValue = $('input[name="Milestone.MilestoneType"]:checked').val()
        if (milestoneTypeValue == 0) {
            this.DisableBoxA()
        }
        if (milestoneTypeValue == 1) {
            this.DisableBoxB()
        }
    }

    DisableBoxA() {
        $(".boxA input").prop("disabled", true)
        $(".boxB input").prop("disabled", false)
    }

    DisableBoxB() {
        $(".boxA input").prop("disabled", false)
        $(".boxB input").prop("disabled", true)
    }
}

$(() => {
    const milestoneTypeBehavior = new MilestoneTypeBehavior()

    milestoneTypeBehavior.SetMilestoneType()

    $("input[name='Milestone.MilestoneType']").on("change", () => {
        milestoneTypeBehavior.DisableSectionOnChange()
    })
})