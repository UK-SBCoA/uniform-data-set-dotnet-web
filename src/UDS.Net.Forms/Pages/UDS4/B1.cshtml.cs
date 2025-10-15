using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS4
{
    public class B1Model : FormPageModel
    {
        [BindProperty]
        public B1 B1 { get; set; } = default!;

        public List<RadioListItem> BasicYesNoListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown", "9")
        };

        public Dictionary<string, UIBehavior> VISCORRUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B1.VISWCORR") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B1.VISWCORR") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B1.VISWCORR") } }
        };

        public Dictionary<string, UIBehavior> HEARAIDUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B1.HEARWAID") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B1.HEARWAID") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B1.HEARWAID") } }
        };

        public B1Model(IVisitService visitService, IParticipationService participationService, IPacketService packetService) : base(visitService, participationService, packetService, "B1")
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                B1 = (B1)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public new async Task<IActionResult> OnPostAsync(int id, string? goNext = null)
        {
            BaseForm = B1;

            Visit.Forms.Add(B1);

            return await base.OnPostAsync(id, goNext); // checks for domain-level business rules validation
        }
    }
}
