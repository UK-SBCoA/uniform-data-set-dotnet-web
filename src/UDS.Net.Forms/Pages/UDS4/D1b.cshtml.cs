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
    public class D1bModel : FormPageModel
    {
        [BindProperty]
        public D1b D1b { get; set; } = default!;

        public D1bModel(IVisitService visitService, IParticipationService participationService) : base(visitService, participationService, "D1b")
        {
        }

        public List<RadioListItem> BIOMARKDXListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 12)", "0"),
            new RadioListItem("Yes (CONTINUE TO QUESTION 2)", "1")
        };

        public List<RadioListItem> FLUIDBIOMListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 5)", "0"),
            new RadioListItem("Yes, only blood-based biomarkers were used (CONTINUE TO QUESTION 3, and SKIP QUESTIONS 4 – 4d)", "1"),
            new RadioListItem("Yes, only CSF-based biomarkers were used (SKIP TO QUESTION 4)", "2"),
            new RadioListItem("Yes, both blood- and CSF-based biomarkers were used", "3")
        };

        public List<RadioListItem> FindingsListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No, inconsistent", "0"),
            new RadioListItem("Yes, consistent", "1"),
            new RadioListItem("Indeterminate", "9"),
            new RadioListItem("Not assessed", "8")
        };

        // If IMAGWMH yes, choose the severity
        public List<RadioListItem> IMAGWMHSEVListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Moderate white-matter hyperintensity (CHS score 5-6)", "1"),
            new RadioListItem("Extensive white-matter hyperintensity (CHS score 7-8+)", "2")
        };

        public List<RadioListItem> IMAGINGDXListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 8)", "0"),
            new RadioListItem("Yes, only PET/SPECT imaging was used (CONTINUE TO QUESTION 6, and SKIP QUESTIONS 7 – 7a3f)", "1"),
            new RadioListItem("Yes, only MR imaging was used (SKIP TO QUESTION 7)", "2"),
            new RadioListItem("Yes, both PET/SPECT and MR imaging were used", "3")
        };

        public List<RadioListItem> PETDXListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 6b)", "0"),
            new RadioListItem("Yes, results were normal or abnormal", "1"),
            new RadioListItem("Yes, results were indeterminate", "2")
        };

        public List<RadioListItem> FDGPETDXListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 6c)", "0"),
            new RadioListItem("Yes, results were normal or abnormal", "1"),
            new RadioListItem("Yes, results were indeterminate", "2")
        };

        public List<RadioListItem> DATSCANDXListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes, results were normal or abnormal", "1"),
            new RadioListItem("Yes, results were indeterminate", "2")
        };

        public List<RadioListItem> TRACOTHDXListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 7a)", "0"),
            new RadioListItem("Yes, results were normal or abnormal", "1"),
            new RadioListItem("Yes, results were indeterminate", "2")
        };

        public List<RadioListItem> STRUCTDXListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 8)", "0"),
            new RadioListItem("Yes, results were normal or abnormal", "1"),
            new RadioListItem("Yes, results were indeterminate", "2")
        };

        public List<RadioListItem> OTHBIOMListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (SKIP TO QUESTION 11)", "0"),
            new RadioListItem("Yes, results were normal or abnormal", "1"),
            new RadioListItem("Yes, results were indeterminate", "2")
        };

        public List<RadioListItem> AUTDOMMUTListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Unknown/Not disclosed", "2")
        };

        public List<RadioListItem> EtiologyListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Primary", "1"),
            new RadioListItem("Contributing", "2"),
            new RadioListItem("Non-contributing", "3")
        };

        public List<RadioListItem> FTLDSUBTListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Tauopathy", "1"),
            new RadioListItem("TDP-43 proteinopathy", "2"),
            new RadioListItem("Other", "3"),
            new RadioListItem("Unknown", "9"),
        };

        public List<RadioListItem> CTECERTListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Suggestive CTE", "1"),
            new RadioListItem("Possible CTE", "2"),
            new RadioListItem("Probable CTE", "3"),
        };

        public Dictionary<string, UIBehavior> BIOMARKDXUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.FLUIDBIOM"),
                    new UIDisableAttribute("D1b.BLOODAD"),
                    new UIDisableAttribute("D1b.BLOODFTLD"),
                    new UIDisableAttribute("D1b.BLOODLBD"),
                    new UIDisableAttribute("D1b.BLOODOTH"),
                    new UIDisableAttribute("D1b.CSFAD"),
                    new UIDisableAttribute("D1b.CSFFTLD"),
                    new UIDisableAttribute("D1b.CSFLBD"),
                    new UIDisableAttribute("D1b.CSFOTH"),
                    new UIDisableAttribute("D1b.IMAGINGDX"),
                    new UIDisableAttribute("D1b.PETDX"),
                    new UIDisableAttribute("D1b.AMYLPET"),
                    new UIDisableAttribute("D1b.TAUPET"),
                    new UIDisableAttribute("D1b.FDGPETDX"),
                    new UIDisableAttribute("D1b.FDGAD"),
                    new UIDisableAttribute("D1b.FDGFTLD"),
                    new UIDisableAttribute("D1b.FDGLBD"),
                    new UIDisableAttribute("D1b.FDGOTH"),
                    new UIDisableAttribute("D1b.TRACERAD"),
                    new UIDisableAttribute("D1b.TRACERFTLD"),
                    new UIDisableAttribute("D1b.TRACERLBD"),
                    new UIDisableAttribute("D1b.TRACEROTH"),
                    new UIDisableAttribute("D1b.STRUCTDX"),
                    new UIDisableAttribute("D1b.STRUCTAD"),
                    new UIDisableAttribute("D1b.STRUCTFTLD"),
                    new UIDisableAttribute("D1b.STRUCTCVD"),
                    new UIDisableAttribute("D1b.OTHBIOM1"),
                    new UIDisableAttribute("D1b.OTHBIOM2"),
                    new UIDisableAttribute("D1b.OTHBIOM3"),
                    new UIDisableAttribute("D1b.AUTDOMMUT"),
                    new UIDisableAttribute("D1b.FLUIDBIOM"),
                    new UIDisableAttribute("D1b.FLUIDBIOM"),
                    new UIDisableAttribute("D1b.FLUIDBIOM"),
                    new UIDisableAttribute("D1b.FLUIDBIOM"),

                },
                InstructionalMessage = "SKIP TO QUESTION 12"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.FLUIDBIOM"),
                    new UIEnableAttribute("D1b.STRUCTDX"),
                    new UIEnableAttribute("D1b.OTHBIOM1"),
                    new UIEnableAttribute("D1b.AUTDOMMUT"),
                },
                InstructionalMessage = "CONTINUE TO QUESTION 2"
            } },
        };

        public Dictionary<string, UIBehavior> FLUIDBIOMUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.BLOODAD"),
                    new UIDisableAttribute("D1b.BLOODFTLD"),
                    new UIDisableAttribute("D1b.BLOODLBD"),
                    new UIDisableAttribute("D1b.BLOODOTH"),
                    new UIDisableAttribute("D1b.CSFAD"),
                    new UIDisableAttribute("D1b.CSFFTLD"),
                    new UIDisableAttribute("D1b.CSFLBD"),
                    new UIDisableAttribute("D1b.CSFOTH"),
                    new UIEnableAttribute("D1b.IMAGINGDX")

                },
                InstructionalMessage = "SKIP TO QUESTION 5"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.BLOODAD"),
                    new UIEnableAttribute("D1b.BLOODFTLD"),
                    new UIEnableAttribute("D1b.BLOODLBD"),
                    new UIEnableAttribute("D1b.BLOODOTH"),
                    new UIDisableAttribute("D1b.CSFAD"),
                    new UIDisableAttribute("D1b.CSFFTLD"),
                    new UIDisableAttribute("D1b.CSFLBD"),
                    new UIDisableAttribute("D1b.CSFOTH"),
                    new UIEnableAttribute("D1b.IMAGINGDX")
                },
                InstructionalMessage = "CONTINUE TO QUESTION 3, and SKIP QUESTIONS 4 – 4d"
            } },
             { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.BLOODAD"),
                    new UIDisableAttribute("D1b.BLOODFTLD"),
                    new UIDisableAttribute("D1b.BLOODLBD"),
                    new UIDisableAttribute("D1b.BLOODOTH"),
                    new UIEnableAttribute("D1b.CSFAD"),
                    new UIEnableAttribute("D1b.CSFFTLD"),
                    new UIEnableAttribute("D1b.CSFLBD"),
                    new UIEnableAttribute("D1b.CSFOTH"),
                    new UIEnableAttribute("D1b.IMAGINGDX")
                },
                InstructionalMessage = "SKIP TO QUESTION 4"
            } },
             { "3", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.BLOODAD"),
                    new UIEnableAttribute("D1b.BLOODFTLD"),
                    new UIEnableAttribute("D1b.BLOODLBD"),
                    new UIEnableAttribute("D1b.BLOODOTH"),
                    new UIEnableAttribute("D1b.CSFAD"),
                    new UIEnableAttribute("D1b.CSFFTLD"),
                    new UIEnableAttribute("D1b.CSFLBD"),
                    new UIEnableAttribute("D1b.CSFOTH"),
                    new UIEnableAttribute("D1b.IMAGINGDX")
                }
            } },
        };

        public Dictionary<string, UIBehavior> BLOODOTHXUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.BLOODOTHX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.BLOODOTHX") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.BLOODOTHX") } }

        };

        public Dictionary<string, UIBehavior> CSFOTHUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.CSFOTHX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.CSFOTHX") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.CSFOTHX") } }

        };

        public Dictionary<string, UIBehavior> IMAGINGDXUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.PETDX"),
                    new UIDisableAttribute("D1b.FDGPETDX"),
                    new UIDisableAttribute("D1b.DATSCANDX"),
                    new UIDisableAttribute("D1b.TRACOTHDX"),
                    new UIDisableAttribute("D1b.STRUCTDX"),
                },
                InstructionalMessage = "SKIP TO QUESTION 8"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.PETDX"),
                    new UIDisableAttribute("D1b.STRUCTDX"),

                },
                InstructionalMessage = "CONTINUE TO QUESTION 6, and SKIP QUESTIONS 7 – 7a3f"
            } },
             { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.PETDX"),
                    new UIDisableAttribute("D1b.FDGPETDX"),
                    new UIDisableAttribute("D1b.DATSCANDX"),
                    new UIDisableAttribute("D1b.TRACOTHDX"),
                    new UIEnableAttribute("D1b.STRUCTDX")
                },
                InstructionalMessage = "SKIP TO QUESTION 7"
            } },
             { "3", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.PETDX"),
                    new UIEnableAttribute("D1b.STRUCTDX")
                }
            } },
        };

        public Dictionary<string, UIBehavior> PETDXUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.AMYLPET"),
                    new UIDisableAttribute("D1b.TAUPET"),
                    new UIEnableAttribute("D1b.FDGPETDX")
                },
                InstructionalMessage = ""
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.AMYLPET"),
                    new UIEnableAttribute("D1b.TAUPET"),
                    new UIEnableAttribute("D1b.FDGPETDX")
                }
            } },
             { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.AMYLPET"),
                    new UIEnableAttribute("D1b.TAUPET"),
                    new UIEnableAttribute("D1b.FDGPETDX")
                }
            } },
        };

        public Dictionary<string, UIBehavior> FDGPETDXUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.FDGAD"),
                    new UIDisableAttribute("D1b.FDGFTLD"),
                    new UIDisableAttribute("D1b.FDGLBD"),
                    new UIDisableAttribute("D1b.FDGOTH"),
                    new UIEnableAttribute("D1b.DATSCANDX"),
                     new UIEnableAttribute("D1b.TRACOTHDX")

                },
                InstructionalMessage = "SKIP TO QUESTION 6c"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.FDGAD"),
                    new UIEnableAttribute("D1b.FDGFTLD"),
                    new UIEnableAttribute("D1b.FDGLBD"),
                    new UIEnableAttribute("D1b.FDGOTH"),
                    new UIEnableAttribute("D1b.DATSCANDX"),
                    new UIEnableAttribute("D1b.TRACOTHDX")

                }
            } },
             { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.FDGAD"),
                    new UIEnableAttribute("D1b.FDGFTLD"),
                    new UIEnableAttribute("D1b.FDGLBD"),
                    new UIEnableAttribute("D1b.FDGOTH"),
                    new UIEnableAttribute("D1b.DATSCANDX"),
                    new UIEnableAttribute("D1b.TRACOTHDX")
                }
            } },
        };

        public Dictionary<string, UIBehavior> FDGOTHUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.FDGOTHX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.FDGOTHX") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.FDGOTHX") } }

        };

        public Dictionary<string, UIBehavior> TRACOTHDXUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.TRACOTHDXX"),
                    new UIDisableAttribute("D1b.TRACERAD"),
                    new UIDisableAttribute("D1b.TRACERFTLD"),
                    new UIDisableAttribute("D1b.TRACERLBD"),
                    new UIDisableAttribute("D1b.TRACEROTH"),

                },
                InstructionalMessage = "SKIP TO QUESTION 7a"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.TRACOTHDXX"),
                    new UIEnableAttribute("D1b.TRACERAD"),
                    new UIEnableAttribute("D1b.TRACERFTLD"),
                    new UIEnableAttribute("D1b.TRACERLBD"),
                    new UIEnableAttribute("D1b.TRACEROTH"),

                }
            } },
             { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.TRACOTHDXX"),
                    new UIEnableAttribute("D1b.TRACERAD"),
                    new UIEnableAttribute("D1b.TRACERFTLD"),
                    new UIEnableAttribute("D1b.TRACERLBD"),
                    new UIEnableAttribute("D1b.TRACEROTH"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> STRUCTDXUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.STRUCTAD"),
                    new UIDisableAttribute("D1b.STRUCTFTLD"),
                    new UIDisableAttribute("D1b.STRUCTCVD"),

                },
                InstructionalMessage = "SKIP TO QUESTION 8"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.STRUCTAD"),
                    new UIEnableAttribute("D1b.STRUCTFTLD"),
                    new UIEnableAttribute("D1b.STRUCTCVD"),

                }
            } },
             { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.STRUCTAD"),
                    new UIEnableAttribute("D1b.STRUCTFTLD"),
                    new UIEnableAttribute("D1b.STRUCTCVD"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> STRUCTCVDUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.IMAGLINF"),
                    new UIDisableAttribute("D1b.IMAGLAC"),
                    new UIDisableAttribute("D1b.IMAGMACH"),
                    new UIDisableAttribute("D1b.IMAGMICH"),
                    new UIDisableAttribute("D1b.IMAGWMH"),

                }
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.IMAGLINF"),
                    new UIEnableAttribute("D1b.IMAGLAC"),
                    new UIEnableAttribute("D1b.IMAGMACH"),
                    new UIEnableAttribute("D1b.IMAGMICH"),
                    new UIEnableAttribute("D1b.IMAGWMH"),

                }
            } },
             { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.IMAGLINF"),
                    new UIEnableAttribute("D1b.IMAGLAC"),
                    new UIEnableAttribute("D1b.IMAGMACH"),
                    new UIEnableAttribute("D1b.IMAGMICH"),
                    new UIEnableAttribute("D1b.IMAGWMH"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> IMAGWMHUIBehavior = new Dictionary<string, UIBehavior>
        {

            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.IMAGWMHSEV") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.IMAGWMHSEV") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.IMAGWMHSEV") } },
            { "8", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.IMAGWMHSEV") } }
        };

        public Dictionary<string, UIBehavior> OTHBIOM1UIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.OTHBIOMX1"),
                    new UIDisableAttribute("D1b.BIOMAD1"),
                    new UIDisableAttribute("D1b.BIOMFTLD1"),
                    new UIDisableAttribute("D1b.BIOMLBD1"),
                    new UIDisableAttribute("D1b.BIOMOTH1"),
                    new UIDisableAttribute("D1b.OTHBIOM2"),
                    new UIDisableAttribute("D1b.OTHBIOM3"),

                },
                InstructionalMessage = "SKIP TO QUESTION 11"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.OTHBIOMX1"),
                    new UIEnableAttribute("D1b.BIOMAD1"),
                    new UIEnableAttribute("D1b.BIOMFTLD1"),
                    new UIEnableAttribute("D1b.BIOMLBD1"),
                    new UIEnableAttribute("D1b.BIOMOTH1"),
                    new UIEnableAttribute("D1b.OTHBIOM2"),

                }
            } },
             { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.OTHBIOMX1"),
                    new UIEnableAttribute("D1b.BIOMAD1"),
                    new UIEnableAttribute("D1b.BIOMFTLD1"),
                    new UIEnableAttribute("D1b.BIOMLBD1"),
                    new UIEnableAttribute("D1b.BIOMOTH1"),
                    new UIEnableAttribute("D1b.OTHBIOM2"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> OTHBIOM2UIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.OTHBIOMX2"),
                    new UIDisableAttribute("D1b.BIOMAD2"),
                    new UIDisableAttribute("D1b.BIOMFTLD2"),
                    new UIDisableAttribute("D1b.BIOMLBD2"),
                    new UIDisableAttribute("D1b.BIOMOTH2"),
                    new UIDisableAttribute("D1b.OTHBIOM3"),

                },
                InstructionalMessage = "SKIP TO QUESTION 11"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.OTHBIOMX2"),
                    new UIEnableAttribute("D1b.BIOMAD2"),
                    new UIEnableAttribute("D1b.BIOMFTLD2"),
                    new UIEnableAttribute("D1b.BIOMLBD2"),
                    new UIEnableAttribute("D1b.BIOMOTH2"),
                    new UIEnableAttribute("D1b.OTHBIOM3"),

                }
            } },
             { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.OTHBIOMX2"),
                    new UIEnableAttribute("D1b.BIOMAD2"),
                    new UIEnableAttribute("D1b.BIOMFTLD2"),
                    new UIEnableAttribute("D1b.BIOMLBD2"),
                    new UIEnableAttribute("D1b.BIOMOTH2"),
                    new UIEnableAttribute("D1b.OTHBIOM3"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> OTHBIOM3UIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.OTHBIOMX3"),
                    new UIDisableAttribute("D1b.BIOMAD3"),
                    new UIDisableAttribute("D1b.BIOMFTLD3"),
                    new UIDisableAttribute("D1b.BIOMLBD3"),
                    new UIDisableAttribute("D1b.BIOMOTH3"),

                },
                InstructionalMessage = "SKIP TO QUESTION 11"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.OTHBIOMX3"),
                    new UIEnableAttribute("D1b.BIOMAD3"),
                    new UIEnableAttribute("D1b.BIOMFTLD3"),
                    new UIEnableAttribute("D1b.BIOMLBD3"),
                    new UIEnableAttribute("D1b.BIOMOTH3"),

                }
            } },
             { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.OTHBIOMX3"),
                    new UIEnableAttribute("D1b.BIOMAD3"),
                    new UIEnableAttribute("D1b.BIOMFTLD3"),
                    new UIEnableAttribute("D1b.BIOMLBD3"),
                    new UIEnableAttribute("D1b.BIOMOTH3"),
                }
            } },
        };

        public Dictionary<string, UIBehavior> BIOMOTH1UIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.BIOMOTHX1") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.BIOMOTHX1") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.BIOMOTHX1") } }

        };

        public Dictionary<string, UIBehavior> BIOMOTH2UIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.BIOMOTHX2") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.BIOMOTHX2") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.BIOMOTHX2") } }

        };

        public Dictionary<string, UIBehavior> BIOMOTH3UIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.BIOMOTHX3") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.BIOMOTHX3") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.BIOMOTHX3") } }

        };

        public Dictionary<string, UIBehavior> FTLDSUBTUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.FTLDSUBX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.FTLDSUBX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.FTLDSUBX") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.FTLDSUBX") } }

        };

        public Dictionary<string, UIBehavior> TRACEROTHUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.TRACEROTHX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.TRACEROTHX") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.TRACEROTHX") } }

        };

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                D1b = (D1b)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id, string? goNext = null)
        {
            BaseForm = D1b; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(D1b); // visit needs updated form as well

            return await base.OnPostAsync(id, goNext); // checks for validation, etc.
        }
    }
}
