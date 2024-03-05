using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Extensions;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS4
{
    public class A3Model : FormPageModel
    {
        [BindProperty]
        public A3 A3 { get; set; } = default!;

        //public List<RadioListItem> AffectedRelativesListItems { get; } = new List<RadioListItem>
        //{
        //    new RadioListItem("Yes", "0"),
        //    new RadioListItem("No", "1"),
        //    new RadioListItem("Unknown", "9")
        //};

        //public List<RadioListItem> SinceLastVisitAffectedRelativesListItems { get; } = new List<RadioListItem>
        //{
        //    new RadioListItem("No (skip to question 5)", "0"),
        //    new RadioListItem("Yes", "1"),
        //    new RadioListItem("Unknown (skip to question 5)", "9")
        //};

        //public List<RadioListItem> EvidenceOfADMutationListItems { get; set; } = new List<RadioListItem>
        //{
        //    new RadioListItem("No","0"),
        //    new RadioListItem("Yes, APP","1"),
        //    new RadioListItem("Yes, PS-1 (PSEN-1)","2"),
        //    new RadioListItem("Yes, PS-2 (PSEN-2)","3"),
        //    new RadioListItem("Yes, other (specify)","8"),
        //    new RadioListItem("Unknown whether mutation exists","9"),
        //};


        //public List<RadioListItem> EvidenceOfFTLDMutationListItems { get; set; } = new List<RadioListItem>
        //{
        //    new RadioListItem("No (skip to question 4a)", "0"),
        //    new RadioListItem("Yes, MAPT", "1"),
        //    new RadioListItem("Yes, PGRN", "2"),
        //    new RadioListItem("Yes, C9orf72", "3"),
        //    new RadioListItem("Yes, FUS", "4"),
        //    new RadioListItem("Yes, other (specify)", "8"),
        //    new RadioListItem("Unknown whether mutation exists (skip to question 4a)", "9"),
        //};

        //public List<RadioListItem> EvidenceOfOtherMutationListItems { get; set; } = new List<RadioListItem>
        //{
        //    new RadioListItem("No (skip to question 5)", "0"),
        //    new RadioListItem("Yes (specify)", "1"),
        //    new RadioListItem("Unknown (skip to question 5)", "9")
        //};

        ///// <summary>
        ///// These are used for AD, FTLD, and Other
        ///// </summary>
        //public List<RadioListItem> SourceOfMutationListItems { get; set; } = new List<RadioListItem>
        //{
        //    new RadioListItem("Family report (no test documentation available)", "1"),
        //    new RadioListItem("Commerical test documentation", "2"),
        //    new RadioListItem("Research lab test documentation", "3"),
        //    new RadioListItem("Other (specify)", "8"),
        //    new RadioListItem("Unknown", "9"),
        //};

        //public List<RadioListItem> NewInformationSinceLastVisit { get; set; } = new List<RadioListItem>
        //{
        //    new RadioListItem("No", "0"),
        //    new RadioListItem("Yes", "1")
        //};

        //public List<RadioListItem> NeurologicalProblemsListItems { get; set; } = new List<RadioListItem>
        //{
        //    new RadioListItem("Cognitive impairment/behavior change", "1"),
        //    new RadioListItem("Parkinsonism", "2"),
        //    new RadioListItem("ALS", "3"),
        //    new RadioListItem("Other neurologic condition such as multiple sclerosis or stroke", "4"),
        //    new RadioListItem("Psychiatric condition such as schizophrenia, bipolar disorder, alcoholism, or depression", "5"),
        //    new RadioListItem("N/A - no neurological problem or psychiatric condition", "8"),
        //    new RadioListItem("Unknown", "9"),
        //};

        //public List<RadioListItem> MethodOfEvaluationListItems { get; set; } = new List<RadioListItem>
        //{
        //    new RadioListItem("Autopsy", "1"),
        //    new RadioListItem("Examination", "2"),
        //    new RadioListItem("Medical record review from formal dementia evaluation", "3"),
        //    new RadioListItem("Review of general medical records AND co-participant and/or participant telephone interview", "4"),
        //    new RadioListItem("Review of general medical records only", "5"),
        //    new RadioListItem("Participant and/or co-participant telephone interview", "6"),
        //    new RadioListItem("Family report", "7"),
        //};

        //public List<RadioListItem> PrimaryDiagnosisListItems { get; set; } = new List<RadioListItem>
        //{
        //    new RadioListItem("Mild cognitive impairment (MCI), not otherwise specified", "040"),
        //    new RadioListItem("MCI — amnestic, single domain", "041"),
        //    new RadioListItem("MCI — multiple domain with amnesia", "042"),
        //    new RadioListItem("MCI — single domain nonamnestic", "043"),
        //    new RadioListItem("MCI — multiple domain nonamnestic", "044"),
        //    new RadioListItem("Impaired, but not MCI", "045"),
        //    new RadioListItem("Alzheimer’s disease dementia", "050"),
        //    new RadioListItem("Dementia with Lewy bodies", "070"),
        //    new RadioListItem("Vascular cognitive impairment or dementia", "080"),
        //    new RadioListItem("Impairment due to alcohol abuse", "100"),
        //    new RadioListItem("Dementia of undetermined etiology", "110"),
        //    new RadioListItem("Behavioral variant frontotemporal dementia", "120"),
        //    new RadioListItem("Primary progressive aphasia, semantic variant", "130"),
        //    new RadioListItem("Primary progressive aphasia, nonfluent/agrammatic variant", "131"),
        //    new RadioListItem("Primary progressive aphasia, logopenic variant", "132"),
        //    new RadioListItem("Primary progressive aphasia, not otherwise specified", "133"),
        //    new RadioListItem("Clinical progressive supranuclear palsy", "140"),
        //    new RadioListItem("Clinical corticobasal syndrome/corticobasal degeneration", "150"),
        //    new RadioListItem("Huntington’s disease", "160"),
        //    new RadioListItem("Clinical prion disease", "170"),
        //    new RadioListItem("Cognitive dysfunction from medications", "180"),
        //    new RadioListItem("Cognitive dysfunction from medical illness", "190"),
        //    new RadioListItem("Depression", "200"),
        //    new RadioListItem("Other major psychiatric illness", "210"),
        //    new RadioListItem("Down syndrome", "220"),
        //    new RadioListItem("Parkinson’s disease", "230"),
        //    new RadioListItem("Stroke", "240"),
        //    new RadioListItem("Hydrocephalus", "250"),
        //    new RadioListItem("Traumatic brain injury", "260"),
        //    new RadioListItem("CNS neoplasm", "270"),
        //    new RadioListItem("Other", "280"),
        //    new RadioListItem("Amyotrophic lateral sclerosis", "310"),
        //    new RadioListItem("Multiple sclerosis", "320"),
        //    new RadioListItem("Specific diagnosis unknown (acceptable if method of evaluation is not by autopsy, examination, or dementia evaluation)", "999")
        //};

        //public List<RadioListItem> NeuropathologyDiagnosisListItems { get; set; } = new List<RadioListItem>
        //{
        //    new RadioListItem("Alzheimer’s disease neuropathology", "400"),
        //    new RadioListItem("Lewy body disease - neuropathology", "410"),
        //    new RadioListItem("Gross infarct(s) neuropathology", "420"),
        //    new RadioListItem("Hemorrhage(s) neuropathology", "421"),
        //    new RadioListItem("Other cerebrovascular disease neuropathology", "422"),
        //    new RadioListItem("ALS/MND", "430"),
        //    new RadioListItem("FTLD with Tau pathology — Pick’s disease", "431"),
        //    new RadioListItem("FTLD with Tau pathology — CBD", "432"),
        //    new RadioListItem("FTLD with Tau pathology — PSP", "433"),
        //    new RadioListItem("FTLD with Tau pathology — argyrophyllic grains", "434"),
        //    new RadioListItem("FTLD with Tau pathology — other", "435"),
        //    new RadioListItem("FTLD with TDP-43", "436"),
        //    new RadioListItem("FTLD other (FTLD-FUS, FTLD-UPS, FTLD NOS)", "439"),
        //    new RadioListItem("Hippocampal sclerosis", "440"),
        //    new RadioListItem("Prion disease neuropathology", "450"),
        //    new RadioListItem("Other neuropathologic diagnosis not listed above", "490")
        //};

        public A3Model(IVisitService visitService) : base(visitService, "A3")
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                A3 = (A3)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public new async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = A3; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(A3); // visit needs updated form as well

            if (A3 != null)
            {
                if (A3.Siblings != null)
                {
                    foreach (var sibling in A3.Siblings)
                    {
                        if (sibling != null)
                        {

                            if (sibling.YOB.HasValue && !sibling.AGD.HasValue)
                            {
                                ModelState.AddModelError($"A3.Siblings[{A3.Siblings.IndexOf(sibling)}].AGD", "Please provide a value for age at death.");
                            }

                            if (sibling.YOB.HasValue && !sibling.ETPR.HasValue)

                            {
                                ModelState.AddModelError($"A3.Siblings[{A3.Siblings.IndexOf(sibling)}].ETPR", "Please provide a value for primary dx.");
                            }
                        }
                    }
                }

                if (A3.Children != null)
                {
                    foreach (var child in A3.Children)
                    {
                        if (child != null)
                        {
                            {
                                if (child.ETPR.HasValue && !child.AGD.HasValue)
                                {
                                    ModelState.AddModelError($"A3.Children[{A3.Children.IndexOf(child)}].AGD", "Please provide a value for age at death.");
                                }
                            }
                            if (child.YOB.HasValue && !child.ETPR.HasValue)

                            {
                                ModelState.AddModelError($"A3.Siblings[{A3.Children.IndexOf(child)}].ETPR", "Please provide a value for primary dx.");
                            }


                        }
                    }
                }
                return await base.OnPostAsync(id); // checks for validation, etc.
            }
            return RedirectToPage();
        }
    }
}
