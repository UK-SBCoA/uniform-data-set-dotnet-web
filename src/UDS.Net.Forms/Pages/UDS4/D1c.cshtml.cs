using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS4
{
    public class D1cModel : FormPageModel
    {
        [BindProperty]
        public D1c D1c { get; set; } = default!;

        public D1cModel(IVisitService visitService, IParticipationService participationService, IPacketService packetService) : base(visitService, participationService, packetService, "D1c")
        {
        }

        public List<RadioListItem> SimpleNoYesListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1")
        };

        public List<RadioListItem> FindingsListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal", "0"),
            new RadioListItem("Abnormal", "1")
        };

        public List<RadioListItem> PETFindingsListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Not elevated", "0"),
            new RadioListItem("Elevated", "1")
        };

        public List<RadioListItem> AnalysisLocationListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Analyzed by NCRAD", "1"),
            new RadioListItem("Analyzed in-house or elsewhere", "2"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> DateWithinListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown", "9")
        };

        public List<RadioListItem> ASynAssayListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("CSF", "1"),
            new RadioListItem("Other", "2")
        };

        public List<RadioListItem> BioStageListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Stage A", "1"),
            new RadioListItem("Stage B", "2"),
            new RadioListItem("Stage C-D", "3"),
            new RadioListItem("Unable to determine stage (e.g., missing necessary biomarkers like tau PET)", "9")
        };

        public List<RadioListItem> ClinicalStageListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Stage 0", "0"),
            new RadioListItem("Stage 1", "1"),
            new RadioListItem("Stage 2", "2"),
            new RadioListItem("Stage 3", "3"),
            new RadioListItem("Stage 4", "4"),
            new RadioListItem("Stage 5", "5"),
            new RadioListItem("Stage 6", "6"),
            new RadioListItem("Unable to determine stage (e.g., missing biomarkers)", "9")
        };

        public Dictionary<string, UIBehavior> DXPLSMABIOUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1c.DXPTAU217"),
                    new UIDisableAttribute("D1c.PTAU217RS"),
                    new UIDisableAttribute("D1c.PT217ANLYS"),
                    new UIDisableAttribute("D1c.PT217INT"),
                    new UIDisableAttribute("D1c.DXPCPT217"),
                    new UIDisableAttribute("D1c.PCPT217RS"),
                    new UIDisableAttribute("D1c.PCPT217INT"),
                    new UIDisableAttribute("D1c.DXOTHPLSMA"),
                    new UIDisableAttribute("D1c.DXOTHPLSMX"),
                    new UIDisableAttribute("D1c.OTHPLSMARS"),
                    new UIDisableAttribute("D1c.OPLSMANLYS"),
                    new UIDisableAttribute("D1c.OPLSMAINT"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1c.DXPTAU217"),
                    new UIEnableAttribute("D1c.DXPCPT217"),
                    new UIEnableAttribute("D1c.DXOTHPLSMA"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> DXPTau217UIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1c.PTAU217RS"),
                    new UIDisableAttribute("D1c.PT217ANLYS"),
                    new UIDisableAttribute("D1c.PT217INT"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1c.PTAU217RS"),
                    new UIEnableAttribute("D1c.PT217ANLYS"),
                    new UIEnableAttribute("D1c.PT217INT"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> DXPCpt217UIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1c.PCPT217RS"),
                    new UIDisableAttribute("D1c.PCPT217INT"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1c.PCPT217RS"),
                    new UIEnableAttribute("D1c.PCPT217INT"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> DXOthPlsmaUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1c.DXOTHPLSMX"),
                    new UIDisableAttribute("D1c.OTHPLSMARS"),
                    new UIDisableAttribute("D1c.OPLSMANLYS"),
                    new UIDisableAttribute("D1c.OPLSMAINT"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1c.DXOTHPLSMX"),
                    new UIEnableAttribute("D1c.OTHPLSMARS"),
                    new UIEnableAttribute("D1c.OPLSMANLYS"),
                    new UIEnableAttribute("D1c.OPLSMAINT"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> DXCSFBIOUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1c.DXPT181AB"),
                    new UIDisableAttribute("D1c.PT181ABRS"),
                    new UIDisableAttribute("D1c.PT181ABAYS"),
                    new UIDisableAttribute("D1c.PT181ABINT"),
                    new UIDisableAttribute("D1c.DXTTABETA"),
                    new UIDisableAttribute("D1c.TTABETARS"),
                    new UIDisableAttribute("D1c.TTABETAINT"),
                    new UIDisableAttribute("D1c.DXAB42AB40"),
                    new UIDisableAttribute("D1c.AB42AB40RS"),
                    new UIDisableAttribute("D1c.AB42AB40AY"),
                    new UIDisableAttribute("D1c.AB42AB40IT"),
                    new UIDisableAttribute("D1c.DXOTHCSF"),
                    new UIDisableAttribute("D1c.DXOTHCSFX"),
                    new UIDisableAttribute("D1c.OTHCSFRS"),
                    new UIDisableAttribute("D1c.OCSFANLYS"),
                    new UIDisableAttribute("D1c.OCSFINT"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1c.DXPT181AB"),
                    new UIEnableAttribute("D1c.DXTTABETA"),
                    new UIEnableAttribute("D1c.DXAB42AB40"),
                    new UIEnableAttribute("D1c.DXOTHCSF"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> DXPt181ABUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1c.PT181ABRS"),
                    new UIDisableAttribute("D1c.PT181ABAYS"),
                    new UIDisableAttribute("D1c.PT181ABINT"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1c.PT181ABRS"),
                    new UIEnableAttribute("D1c.PT181ABAYS"),
                    new UIEnableAttribute("D1c.PT181ABINT"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> DXTtabetaUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1c.TTABETARS"),
                    new UIDisableAttribute("D1c.TTABETAINT"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1c.TTABETARS"),
                    new UIEnableAttribute("D1c.TTABETAINT"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> DXAb42Ab40UIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1c.AB42AB40RS"),
                    new UIDisableAttribute("D1c.AB42AB40AY"),
                    new UIDisableAttribute("D1c.AB42AB40IT"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1c.AB42AB40RS"),
                    new UIEnableAttribute("D1c.AB42AB40AY"),
                    new UIEnableAttribute("D1c.AB42AB40IT"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> DXOthCsfUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1c.DXOTHCSFX"),
                    new UIDisableAttribute("D1c.OTHCSFRS"),
                    new UIDisableAttribute("D1c.OCSFANLYS"),
                    new UIDisableAttribute("D1c.OCSFINT"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1c.DXOTHCSFX"),
                    new UIEnableAttribute("D1c.OTHCSFRS"),
                    new UIEnableAttribute("D1c.OCSFANLYS"),
                    new UIEnableAttribute("D1c.OCSFINT"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> DXApetUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1c.APETRS"),
                    new UIDisableAttribute("D1c.APETVIS"),
                    new UIDisableAttribute("D1c.APETQUANT"),
                    new UIDisableAttribute("D1c.APETANLYS"),
                    new UIDisableAttribute("D1c.APETINT"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1c.APETRS"),
                    new UIEnableAttribute("D1c.APETVIS"),
                    new UIEnableAttribute("D1c.APETQUANT"),
                    new UIEnableAttribute("D1c.APETANLYS"),
                    new UIEnableAttribute("D1c.APETINT"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> DXTaupetUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1c.TPETMTLRS"),
                    new UIDisableAttribute("D1c.TPETMTLVIS"),
                    new UIDisableAttribute("D1c.TPETMTLQNT"),
                    new UIDisableAttribute("D1c.TPETMTLAYS"),
                    new UIDisableAttribute("D1c.TPETNEORS"),
                    new UIDisableAttribute("D1c.TPETNEOVIS"),
                    new UIDisableAttribute("D1c.TPETNEOQNT"),
                    new UIDisableAttribute("D1c.TPETNEOAYS"),
                    new UIDisableAttribute("D1c.DXTAUPTINT"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1c.TPETMTLRS"),
                    new UIEnableAttribute("D1c.TPETMTLVIS"),
                    new UIEnableAttribute("D1c.TPETMTLQNT"),
                    new UIEnableAttribute("D1c.TPETMTLAYS"),
                    new UIEnableAttribute("D1c.TPETNEORS"),
                    new UIEnableAttribute("D1c.TPETNEOVIS"),
                    new UIEnableAttribute("D1c.TPETNEOQNT"),
                    new UIEnableAttribute("D1c.TPETNEOAYS"),
                    new UIEnableAttribute("D1c.DXTAUPTINT"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> InforischUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1c.IMGRSINF"),
                    new UIDisableAttribute("D1c.IMGRSINFLC"),
                    new UIDisableAttribute("D1c.IMGRSINFCT"),
                    new UIDisableAttribute("D1c.IMGRSMICR"),
                    new UIDisableAttribute("D1c.IMGRSWMH"),
                    new UIDisableAttribute("D1c.IMGRSSPSID"),
                    new UIDisableAttribute("D1c.IMGRSOTH"),
                    new UIDisableAttribute("D1c.IMGRSOTHX"),
                    new UIDisableAttribute("D1c.IMGRSINT"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1c.IMGRSINF"),
                    new UIEnableAttribute("D1c.IMGRSMICR"),
                    new UIEnableAttribute("D1c.IMGRSWMH"),
                    new UIEnableAttribute("D1c.IMGRSSPSID"),
                    new UIEnableAttribute("D1c.IMGRSOTH"),
                    new UIEnableAttribute("D1c.IMGRSINT"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> ImgrsothUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1c.IMGRSOTHX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1c.IMGRSOTHX") } },
        };

        public Dictionary<string, UIBehavior> DXAsynUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1c.ASYNRS"),
                    new UIDisableAttribute("D1c.ASYNASSAY"),
                    new UIDisableAttribute("D1c.ASYNASSAYX"),
                    new UIDisableAttribute("D1c.ASYNANLYSX"),
                    new UIDisableAttribute("D1c.ASYNINT"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1c.ASYNRS"),
                    new UIEnableAttribute("D1c.ASYNASSAY"),
                    new UIEnableAttribute("D1c.ASYNANLYSX"),
                    new UIEnableAttribute("D1c.ASYNINT"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> AsynassayUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1c.ASYNASSAYX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1c.ASYNASSAYX") } },
        };

        public Dictionary<string, UIBehavior> AacritmetUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1c.CR1APET"),
                    new UIDisableAttribute("D1c.CR1PTAU217"),
                    new UIDisableAttribute("D1c.CR1PCPT217"),
                    new UIDisableAttribute("D1c.CR1PT181AB"),
                    new UIDisableAttribute("D1c.CR1TTABETA"),
                    new UIDisableAttribute("D1c.C1AB42AB40"),
                    new UIDisableAttribute("D1c.CR1OTH"),
                    new UIDisableAttribute("D1c.CR1OTHX"),
                    new UIDisableAttribute("D1c.BIOSTAGE"),
                    new UIDisableAttribute("D1c.CLINSTAGE"),
                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1c.CR1APET"),
                    new UIEnableAttribute("D1c.CR1PTAU217"),
                    new UIEnableAttribute("D1c.CR1PCPT217"),
                    new UIEnableAttribute("D1c.CR1PT181AB"),
                    new UIEnableAttribute("D1c.CR1TTABETA"),
                    new UIEnableAttribute("D1c.C1AB42AB40"),
                    new UIEnableAttribute("D1c.CR1OTH"),
                    new UIEnableAttribute("D1c.BIOSTAGE"),
                    new UIEnableAttribute("D1c.CLINSTAGE"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> Cr1othUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1c.CR1OTHX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1c.CR1OTHX") } },
        };

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                D1c = (D1c)BaseForm;
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id, string? goNext = null)
        {
            BaseForm = D1c;
            Visit.Forms.Add(D1c);

            return await base.OnPostAsync(id, goNext);
        }
    }
}