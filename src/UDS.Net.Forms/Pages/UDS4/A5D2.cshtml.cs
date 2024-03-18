using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS4;

public class A5D2Model : FormPageModel
{
    [BindProperty]
    public A5D2 A5D2 { get; set; } = default!;

    public A5D2Model(IVisitService visitService) : base(visitService, "A5D2")
    {
    }

    public List<RadioListItem> BasicYesNoListItems { get; set; } = new List<RadioListItem>
    {
        new RadioListItem("No", "0"),
        new RadioListItem("Yes", "1"),
        new RadioListItem("Unknown", "9")
    };

    public Dictionary<string, UIBehavior> TOBAC100UIBehavior = new Dictionary<string, UIBehavior>
    {
        // { "0", new UIBehavior{
        // PropertyAttributes = new List<UIPropertyAttributes>
        // {
        //     new UIDisableAttribute("A5.SMOKYRS"),
        //     new UIDisableAttribute("A5.PACKSPER"),
        //     new UIDisableAttribute("A5.QUITSMOK"),
        // },
        // InstructionalMessage = "skip to question 1F"

        // } },
    };

    public List<RadioListItem> SmokingFrequencyListItems { get; set; } = new List<RadioListItem>
    {
        new RadioListItem("1 cigarette to less than 1/2 pack", "1"),
        new RadioListItem("1/2 pack to less than 1 pack", "2"),
        new RadioListItem("1 pack to less than 1 1/2 packs", "3"),
        new RadioListItem("1 1/2 packs to less than 2 packs", "4"),
        new RadioListItem("2 packs or more", "5"),
        new RadioListItem("Unknown", "9")
    };

    public List<RadioListItem> ALCFREQYRItems { get; set; } = new List<RadioListItem>
    {
        new RadioListItem("Never", "0"),
        new RadioListItem("Monthly or less", "1"),
        new RadioListItem("2-4 times a month", "2"),
        new RadioListItem("2-3 times a week", "3"),
        new RadioListItem("4 or more times a week", "4"),
        new RadioListItem("Unknown", "9")
    };

    public List<RadioListItem> ALCDRINKSItems { get; set; } = new List<RadioListItem>
    {
        new RadioListItem("1 or 2", "1"),
        new RadioListItem("3 to 4", "2"),
        new RadioListItem("5 to 6", "3"),
        new RadioListItem("7 to 9", "4"),
        new RadioListItem("10 or more", "5"),
        new RadioListItem("Unknown", "9")
    };

    public List<RadioListItem> ALCBINGEItems { get; set; } = new List<RadioListItem>
    {
        new RadioListItem("Never", "0"),
        new RadioListItem("Less than once a month", "1"),
        new RadioListItem("Monthly", "2"),
        new RadioListItem("Weekly", "3"),
        new RadioListItem("Daily or almost daily", "4"),
        new RadioListItem("Unknown", "9")
    };

    public List<RadioListItem> CANNABISItems { get; set; } = new List<RadioListItem>
    {
        new RadioListItem("Never", "0"),
        new RadioListItem("Monthly or less", "1"),
        new RadioListItem("2-4 times a month", "2"),
        new RadioListItem("2-3 times a week", "3"),
        new RadioListItem("4 or more times a week", "4"),
        new RadioListItem("Unknown", "9")
    };

    public List<RadioListItem> ConditionsListItems { get; set; } = new List<RadioListItem>
    {
        new RadioListItem("Absent", "0"),
        new RadioListItem("Recent/active", "1"),
        new RadioListItem("Remote/inactive", "2"),
        new RadioListItem("Unknown", "9")
    };

    public List<RadioListItem> ConditionsListNoRemoteItems { get; set; } = new List<RadioListItem>
    {
        new RadioListItem("Absent", "0"),
        new RadioListItem("Recent/active", "1"),
        new RadioListItem("Unknown", "9")
    };

    public List<RadioListItem> SEIZNUMItems { get; set; } = new List<RadioListItem>
    {
        new RadioListItem("None", "0"),
        new RadioListItem("1 or 2", "1"),
        new RadioListItem("3 or more", "2"),
        new RadioListItem("Unknown", "9")
    };

    public List<RadioListItem> HeadInjuryPeriodItems { get; set; } = new List<RadioListItem>
    {
        new RadioListItem("Less than 5 minutes", "0"),
        new RadioListItem("5 minutes to less than 30 minutes", "1"),
        new RadioListItem("30 minutes to less than 24 hours", "2"),
        new RadioListItem("1 day to less than 7 days", "3"),
        new RadioListItem("7 days or more", "4"),
        new RadioListItem("7 days or more", "4"),
        new RadioListItem("Not applicable, no loss of consciousness", "8"),
        new RadioListItem("Unknown duration", "9")
    };

    public List<RadioListItem> HEADINJNUMItems { get; set; } = new List<RadioListItem>
    {
        new RadioListItem("None", "0"),
        new RadioListItem("1-2", "1"),
        new RadioListItem("3-5", "2"),
        new RadioListItem("6-12", "3"),
        new RadioListItem("13 or more", "4"),
        new RadioListItem("Unknown", "9"),
    };

    public List<RadioListItem> DIABTYPEItems { get; set; } = new List<RadioListItem>
    {
        new RadioListItem("Type 1", "1"),
        new RadioListItem("Type 2", "2"),
        new RadioListItem("Other (diabetes insipidus, latent autoimmune diabetes/type 1.5, gestational diabetes", "3"),
        new RadioListItem("Unknown", "9")
    };

    public List<RadioListItem> HoursPerNightItems{ get; set; } = new List<RadioListItem>
    {
        new RadioListItem("None", "0"),
        new RadioListItem("< 4 hours per night", "1"),
        new RadioListItem("> 4 hours per night", "2"),
        new RadioListItem("Unknown", "9")
    };

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        await base.OnGetAsync(id);

        if (BaseForm != null)
        {
            A5D2 = (A5D2)BaseForm;
        }

        return Page();
    }

    [ValidateAntiForgeryToken]
    public async Task<IActionResult> OnPostAsync(int id)
    {
        BaseForm = A5D2; // reassign bounded and derived form to base form for base method

        Visit.Forms.Add(A5D2); // visit needs updated form as well

        return await base.OnPostAsync(id); // checks for validation, etc.
    }
}
