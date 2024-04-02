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
    public class B8Model : FormPageModel
    {
        [BindProperty]
        public B8 B8 { get; set; } = default!;

        public List<RadioListItem> NEUREXAMListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No neurologic examination (END FORM HERE)", "0"),
            new RadioListItem("Comprehensive neurologic examination as suggested in the UDS Coding Guidebook", "1"),
            new RadioListItem("Focused or partial neurologic examination performed in-person", "2"),
            new RadioListItem("Focused or partial neurologic examination performed via telehealth", "3")
        };

        public List<RadioListItem> NORMNREXAMListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No abnormal findings (END FORM HERE; If this box is checked, all items will default to 0 = Absent in the database)", "0"),
            new RadioListItem("Yes", "1")
        };

        public List<RadioListItem> PARKSIGNListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No abnormal signs in this section are present (SKIP TO SECTION 2B; If this box is checked, Q3a through Q3n will default to 0 = Absent in the database)", "0"),
            new RadioListItem("Yes (IF YES – complete questions 3a–3n and consider completing additional measures as described on page 3)", "1"),
            new RadioListItem("Not assessed (SKIP TO SECTION 2B; If this box is checked, Q3a through Q3n will default to 8 = Not Assessed in the database)", "8")
        };

        public List<RadioListItem> SignsListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Absent", "0"),
            new RadioListItem("Focal or Unilatera", "1"),
            new RadioListItem("Bilateral & Largely Symmetric", "2"),
            new RadioListItem("Bilateral & Largely Asymmetric", "3"),
            new RadioListItem("Not Assessed", "8")
        };

        public List<RadioListItem> AssessmentListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Absent", "0"),
            new RadioListItem("Present", "1"),
            new RadioListItem("Not Assessed", "8")
        };

        public List<RadioListItem> OTHERSIGNListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No abnormal signs in this section are present (SKIP TO SECTION 2C; If this box is checked, Q4a through Q4q will default to 0=Absent in the database)", "0"),
            new RadioListItem("Yes (IF YES – complete questions 4a–4q and consider completing additional measures as described on page 3)", "1"),
            new RadioListItem("Not assessed (SKIP TO SECTION 2C; If this box is checked, Q4a through Q4q will default to 8 = Not Assessed in the database)", "8")
        };

        public List<RadioListItem> GaitListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No abnormal signs in this section are present (END FORM HERE)", "0"),
            new RadioListItem("Yes (IF YES - complete question 5a and consider completing additional measures as described on page 3)", "1"),
            new RadioListItem("Not assessed (END FORM HERE)", "8")
        };


        public List<RadioListItem> GaitFindingListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Hemiparetic gait (spastic)", "1"),
            new RadioListItem("Foot drop gait (lower motor neuron)", "2"),
            new RadioListItem("Ataxic gait", "3"),
            new RadioListItem("Apractic magnetic gait", "4"),
            new RadioListItem("Hypokinetic/parkinsonian gait", "5"),
            new RadioListItem("Antalgic gait", "6"),
            new RadioListItem("Other (SPECIFY)", "7")
        };

        public Dictionary<string, UIBehavior> GaitUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B8.GAITFIND") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B8.GAITFIND")  } },
            { "8", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B8.GAITFIND") } }
        };

        public Dictionary<string, UIBehavior> GaitFindUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B8.GAITOTHRX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B8.GAITOTHRX")  } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B8.GAITOTHRX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B8.GAITOTHRX") } },
            { "5", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B8.GAITOTHRX")  } },
            { "6", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B8.GAITOTHRX") } },
            { "7", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B8.GAITOTHRX") } }
        };

        public Dictionary<string, UIBehavior> NEUREXAMUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B8.NORMNREXAM"),
                    new UIDisableAttribute("B8.PARKSIGN"),
                    new UIDisableAttribute("B8.SLOWINGFM"),
                    new UIDisableAttribute("B8.TREMREST"),
                    new UIDisableAttribute("B8.TREMPOST"),
                    new UIDisableAttribute("B8.TREMKINE"),
                    new UIDisableAttribute("B8.RIGIDARM"),
                    new UIDisableAttribute("B8.RIGIDLEG"),
                    new UIDisableAttribute("B8.DYSTARM"),
                    new UIDisableAttribute("B8.DYSTLEG"),
                    new UIDisableAttribute("B8.CHOREA"),
                    new UIDisableAttribute("B8.AMPMOTOR"),
                    new UIDisableAttribute("B8.AXIALRIG"),
                    new UIDisableAttribute("B8.POSTINST"),
                    new UIDisableAttribute("B8.MASKING"),
                    new UIDisableAttribute("B8.STOOPED"),
                    new UIDisableAttribute("B8.OTHERSIGN"),
                    new UIDisableAttribute("B8.LIMBAPRAX"),
                    new UIDisableAttribute("B8.UMNDIST"),
                    new UIDisableAttribute("B8.LMNDIST"),
                    new UIDisableAttribute("B8.VFIELDCUT"),
                    new UIDisableAttribute("B8.LIMBATAX"),
                    new UIDisableAttribute("B8.MYOCLON"),
                    new UIDisableAttribute("B8.UNISOMATO"),
                    new UIDisableAttribute("B8.APHASIA"),
                    new UIDisableAttribute("B8.ALIENLIMB"),
                    new UIDisableAttribute("B8.HSPATNEG"),
                    new UIDisableAttribute("B8.PSPOAGNO"),
                    new UIDisableAttribute("B8.SMTAGNO"),
                    new UIDisableAttribute("B8.OPTICATAX"),
                    new UIDisableAttribute("B8.APRAXGAZE"),
                    new UIDisableAttribute("B8.VHGAZEPAL"),
                    new UIDisableAttribute("B8.DYSARTH"),
                    new UIDisableAttribute("B8.APRAXSP"),
                    new UIDisableAttribute("B8.GAITABN")
                },
                InstructionalMessage = ""
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B8.NORMNREXAM"),
                    new UIEnableAttribute("B8.PARKSIGN"),
                    new UIEnableAttribute("B8.SLOWINGFM"),
                    new UIEnableAttribute("B8.TREMREST"),
                    new UIEnableAttribute("B8.TREMPOST"),
                    new UIEnableAttribute("B8.TREMKINE"),
                    new UIEnableAttribute("B8.RIGIDARM"),
                    new UIEnableAttribute("B8.RIGIDLEG"),
                    new UIEnableAttribute("B8.DYSTARM"),
                    new UIEnableAttribute("B8.DYSTLEG"),
                    new UIEnableAttribute("B8.CHOREA"),
                    new UIEnableAttribute("B8.AMPMOTOR"),
                    new UIEnableAttribute("B8.AXIALRIG"),
                    new UIEnableAttribute("B8.POSTINST"),
                    new UIEnableAttribute("B8.MASKING"),
                    new UIEnableAttribute("B8.STOOPED"),
                    new UIEnableAttribute("B8.OTHERSIGN"),
                    new UIEnableAttribute("B8.LIMBAPRAX"),
                    new UIEnableAttribute("B8.UMNDIST"),
                    new UIEnableAttribute("B8.LMNDIST"),
                    new UIEnableAttribute("B8.VFIELDCUT"),
                    new UIEnableAttribute("B8.LIMBATAX"),
                    new UIEnableAttribute("B8.MYOCLON"),
                    new UIEnableAttribute("B8.UNISOMATO"),
                    new UIEnableAttribute("B8.APHASIA"),
                    new UIEnableAttribute("B8.ALIENLIMB"),
                    new UIEnableAttribute("B8.HSPATNEG"),
                    new UIEnableAttribute("B8.PSPOAGNO"),
                    new UIEnableAttribute("B8.SMTAGNO"),
                    new UIEnableAttribute("B8.OPTICATAX"),
                    new UIEnableAttribute("B8.APRAXGAZE"),
                    new UIEnableAttribute("B8.VHGAZEPAL"),
                    new UIEnableAttribute("B8.DYSARTH"),
                    new UIEnableAttribute("B8.APRAXSP"),
                    new UIEnableAttribute("B8.GAITABN")
                },
                InstructionalMessage = ""
            } },
            { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B8.NORMNREXAM"),
                    new UIEnableAttribute("B8.PARKSIGN"),
                    new UIEnableAttribute("B8.SLOWINGFM"),
                    new UIEnableAttribute("B8.TREMREST"),
                    new UIEnableAttribute("B8.TREMPOST"),
                    new UIEnableAttribute("B8.TREMKINE"),
                    new UIEnableAttribute("B8.RIGIDARM"),
                    new UIEnableAttribute("B8.RIGIDLEG"),
                    new UIEnableAttribute("B8.DYSTARM"),
                    new UIEnableAttribute("B8.DYSTLEG"),
                    new UIEnableAttribute("B8.CHOREA"),
                    new UIEnableAttribute("B8.AMPMOTOR"),
                    new UIEnableAttribute("B8.AXIALRIG"),
                    new UIEnableAttribute("B8.POSTINST"),
                    new UIEnableAttribute("B8.MASKING"),
                    new UIEnableAttribute("B8.STOOPED"),
                    new UIEnableAttribute("B8.OTHERSIGN"),
                    new UIEnableAttribute("B8.LIMBAPRAX"),
                    new UIEnableAttribute("B8.UMNDIST"),
                    new UIEnableAttribute("B8.LMNDIST"),
                    new UIEnableAttribute("B8.VFIELDCUT"),
                    new UIEnableAttribute("B8.LIMBATAX"),
                    new UIEnableAttribute("B8.MYOCLON"),
                    new UIEnableAttribute("B8.UNISOMATO"),
                    new UIEnableAttribute("B8.APHASIA"),
                    new UIEnableAttribute("B8.ALIENLIMB"),
                    new UIEnableAttribute("B8.HSPATNEG"),
                    new UIEnableAttribute("B8.PSPOAGNO"),
                    new UIEnableAttribute("B8.SMTAGNO"),
                    new UIEnableAttribute("B8.OPTICATAX"),
                    new UIEnableAttribute("B8.APRAXGAZE"),
                    new UIEnableAttribute("B8.VHGAZEPAL"),
                    new UIEnableAttribute("B8.DYSARTH"),
                    new UIEnableAttribute("B8.APRAXSP"),
                    new UIEnableAttribute("B8.GAITABN")
                },
                InstructionalMessage = ""
            } },
            { "3", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B8.NORMNREXAM"),
                    new UIEnableAttribute("B8.PARKSIGN"),
                    new UIEnableAttribute("B8.SLOWINGFM"),
                    new UIEnableAttribute("B8.TREMREST"),
                    new UIEnableAttribute("B8.TREMPOST"),
                    new UIEnableAttribute("B8.TREMKINE"),
                    new UIEnableAttribute("B8.RIGIDARM"),
                    new UIEnableAttribute("B8.RIGIDLEG"),
                    new UIEnableAttribute("B8.DYSTARM"),
                    new UIEnableAttribute("B8.DYSTLEG"),
                    new UIEnableAttribute("B8.CHOREA"),
                    new UIEnableAttribute("B8.AMPMOTOR"),
                    new UIEnableAttribute("B8.AXIALRIG"),
                    new UIEnableAttribute("B8.POSTINST"),
                    new UIEnableAttribute("B8.MASKING"),
                    new UIEnableAttribute("B8.STOOPED"),
                    new UIEnableAttribute("B8.OTHERSIGN"),
                    new UIEnableAttribute("B8.LIMBAPRAX"),
                    new UIEnableAttribute("B8.UMNDIST"),
                    new UIEnableAttribute("B8.LMNDIST"),
                    new UIEnableAttribute("B8.VFIELDCUT"),
                    new UIEnableAttribute("B8.LIMBATAX"),
                    new UIEnableAttribute("B8.MYOCLON"),
                    new UIEnableAttribute("B8.UNISOMATO"),
                    new UIEnableAttribute("B8.APHASIA"),
                    new UIEnableAttribute("B8.ALIENLIMB"),
                    new UIEnableAttribute("B8.HSPATNEG"),
                    new UIEnableAttribute("B8.PSPOAGNO"),
                    new UIEnableAttribute("B8.SMTAGNO"),
                    new UIEnableAttribute("B8.OPTICATAX"),
                    new UIEnableAttribute("B8.APRAXGAZE"),
                    new UIEnableAttribute("B8.VHGAZEPAL"),
                    new UIEnableAttribute("B8.DYSARTH"),
                    new UIEnableAttribute("B8.APRAXSP"),
                    new UIEnableAttribute("B8.GAITABN")
                },
                InstructionalMessage = ""
            } }
        };

        public B8Model(IVisitService visitService) : base(visitService, "B8")
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                B8 = (B8)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = B8;

            Visit.Forms.Add(B8);

            return await base.OnPostAsync(id); // checks for domain-level business rules validation

        }
    }
}
