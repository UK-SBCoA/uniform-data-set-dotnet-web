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
            new RadioListItem("Hemiparetic gait (spastic)", "1"),
            new RadioListItem("Foot drop gait (lower motor neuron)", "2"),
            new RadioListItem("Ataxic gait", "3"),
            new RadioListItem("Apractic magnetic gait", "4"),
            new RadioListItem("Hypokinetic/parkinsonian gait", "5"),
            new RadioListItem("Antalgic gait", "6")
        };

        public List<RadioListItem> GaitFindingListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No abnormal signs in this section are present (END FORM HERE)", "0"),
            new RadioListItem("Yes (IF YES - complete question 5a and consider completing additional measures as described on page 3)", "1"),
            new RadioListItem("Not assessed (END FORM HERE)", "8")
        };

        public Dictionary<string, UIBehavior> NORMEXAMUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B8.PARKSIGN"),
                    new UIDisableAttribute("B8.CVDSIGNS"),
                    new UIDisableAttribute("B8.POSTCORT"),
                    new UIDisableAttribute("B8.PSPCBS"),
                    new UIDisableAttribute("B8.ALSFIND"),
                    new UIDisableAttribute("B8.GAITNPH"),
                    new UIDisableAttribute("B8.OTHNEUR")
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B8.PARKSIGN"),
                    new UIEnableAttribute("B8.CVDSIGNS"),
                    new UIEnableAttribute("B8.POSTCORT"),
                    new UIEnableAttribute("B8.PSPCBS"),
                    new UIEnableAttribute("B8.ALSFIND"),
                    new UIEnableAttribute("B8.GAITNPH"),
                    new UIEnableAttribute("B8.OTHNEUR")
                }
            } },
            { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B8.PARKSIGN"),
                    new UIDisableAttribute("B8.CVDSIGNS"),
                    new UIDisableAttribute("B8.POSTCORT"),
                    new UIDisableAttribute("B8.PSPCBS"),
                    new UIDisableAttribute("B8.ALSFIND"),
                    new UIDisableAttribute("B8.GAITNPH"),
                    new UIEnableAttribute("B8.OTHNEUR"),
                    new UIPropertyAttributes("B8.OTHNEUR", new Dictionary<string, string>
                    {
                        { "val", "1" }
                    })
                }
            } }
        };

        public Dictionary<string, UIBehavior> PARKSIGNUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B8.RESTTRL"),
                    new UIDisableAttribute("B8.RESTTRR"),
                    new UIDisableAttribute("B8.RESTTRL"),
                    new UIDisableAttribute("B8.SLOWINGL"),
                    new UIDisableAttribute("B8.SLOWINGR"),
                    new UIDisableAttribute("B8.RIGIDL"),
                    new UIDisableAttribute("B8.RIGIDR"),
                    new UIDisableAttribute("B8.BRADY"),
                    new UIDisableAttribute("B8.PARKGAIT"),
                    new UIDisableAttribute("B8.POSTINST")
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B8.RESTTRL"),
                    new UIEnableAttribute("B8.RESTTRR"),
                    new UIEnableAttribute("B8.RESTTRL"),
                    new UIEnableAttribute("B8.SLOWINGL"),
                    new UIEnableAttribute("B8.SLOWINGR"),
                    new UIEnableAttribute("B8.RIGIDL"),
                    new UIEnableAttribute("B8.RIGIDR"),
                    new UIEnableAttribute("B8.BRADY"),
                    new UIEnableAttribute("B8.PARKGAIT"),
                    new UIEnableAttribute("B8.POSTINST")
                }
            } }
        };

        public Dictionary<string, UIBehavior> CVDSIGNSUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B8.CORTDEF"),
                    new UIDisableAttribute("B8.SIVDFIND"),
                    new UIDisableAttribute("B8.CVDMOTL"),
                    new UIDisableAttribute("B8.CVDMOTR"),
                    new UIDisableAttribute("B8.CORTVISL"),
                    new UIDisableAttribute("B8.CORTVISR"),
                    new UIDisableAttribute("B8.SOMATL"),
                    new UIDisableAttribute("B8.SOMATR")
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B8.CORTDEF"),
                    new UIEnableAttribute("B8.SIVDFIND"),
                    new UIEnableAttribute("B8.CVDMOTL"),
                    new UIEnableAttribute("B8.CVDMOTR"),
                    new UIEnableAttribute("B8.CORTVISL"),
                    new UIEnableAttribute("B8.CORTVISR"),
                    new UIEnableAttribute("B8.SOMATL"),
                    new UIEnableAttribute("B8.SOMATR")
                }
            } }
        };
        public Dictionary<string, UIBehavior> PSPCBSUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("B8.EYEPSP"),
                    new UIDisableAttribute("B8.DYSPSP"),
                    new UIDisableAttribute("B8.AXIALPSP"),
                    new UIDisableAttribute("B8.GAITPSP"),
                    new UIDisableAttribute("B8.APRAXSP"),
                    new UIDisableAttribute("B8.APRAXL"),
                    new UIDisableAttribute("B8.APRAXR"),
                    new UIDisableAttribute("B8.CORTSENL"),
                    new UIDisableAttribute("B8.CORTSENR"),
                    new UIDisableAttribute("B8.ATAXL"),
                    new UIDisableAttribute("B8.ATAXR"),
                    new UIDisableAttribute("B8.ALIENLML"),
                    new UIDisableAttribute("B8.ALIENLMR"),
                    new UIDisableAttribute("B8.DYSTONL"),
                    new UIDisableAttribute("B8.DYSTONR"),
                    new UIDisableAttribute("B8.MYOCLLT"),
                    new UIDisableAttribute("B8.MYOCLRT")
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("B8.EYEPSP"),
                    new UIEnableAttribute("B8.DYSPSP"),
                    new UIEnableAttribute("B8.AXIALPSP"),
                    new UIEnableAttribute("B8.GAITPSP"),
                    new UIEnableAttribute("B8.APRAXSP"),
                    new UIEnableAttribute("B8.APRAXL"),
                    new UIEnableAttribute("B8.APRAXR"),
                    new UIEnableAttribute("B8.CORTSENL"),
                    new UIEnableAttribute("B8.CORTSENR"),
                    new UIEnableAttribute("B8.ATAXL"),
                    new UIEnableAttribute("B8.ATAXR"),
                    new UIEnableAttribute("B8.ALIENLML"),
                    new UIEnableAttribute("B8.ALIENLMR"),
                    new UIEnableAttribute("B8.DYSTONL"),
                    new UIEnableAttribute("B8.DYSTONR"),
                    new UIEnableAttribute("B8.MYOCLLT"),
                    new UIEnableAttribute("B8.MYOCLRT")
                }
            } }
        };

        public Dictionary<string, UIBehavior> OTHNEURUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B8.OTHNEURX")} },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B8.OTHNEURX")} }
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
