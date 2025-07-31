using Microsoft.AspNetCore.Mvc;
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
            new RadioListItem("Yes, only MR/CT imaging was used (SKIP TO QUESTION 7)", "2"),
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
            new RadioListItem("Unknown/Not disclosed", "9")
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

        /****************** Question 1 ******************/
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
                    new UIDisableAttribute("D1b.BLOODOTHX"),
                    new UIDisableAttribute("D1b.CSFAD"),
                    new UIDisableAttribute("D1b.CSFFTLD"),
                    new UIDisableAttribute("D1b.CSFLBD"),
                    new UIDisableAttribute("D1b.CSFOTH"),
                    new UIDisableAttribute("D1b.CSFOTHX"),
                    new UIDisableAttribute("D1b.IMAGINGDX"),
                    new UIDisableAttribute("D1b.PETDX"),
                    new UIDisableAttribute("D1b.AMYLPET"),
                    new UIDisableAttribute("D1b.TAUPET"),
                    new UIDisableAttribute("D1b.FDGPETDX"),
                    new UIDisableAttribute("D1b.FDGAD"),
                    new UIDisableAttribute("D1b.FDGFTLD"),
                    new UIDisableAttribute("D1b.FDGLBD"),
                    new UIDisableAttribute("D1b.FDGOTH"),
                    new UIDisableAttribute("D1b.FDGOTHX"),
                    new UIDisableAttribute("D1b.DATSCANDX"),
                    new UIDisableAttribute("D1b.TRACOTHDX"),
                    new UIDisableAttribute("D1b.TRACOTHDXX"),
                    new UIDisableAttribute("D1b.TRACERAD"),
                    new UIDisableAttribute("D1b.TRACERFTLD"),
                    new UIDisableAttribute("D1b.TRACERLBD"),
                    new UIDisableAttribute("D1b.TRACEROTH"),
                    new UIDisableAttribute("D1b.TRACEROTHX"),
                    new UIDisableAttribute("D1b.STRUCTDX"),
                    new UIDisableAttribute("D1b.STRUCTAD"),
                    new UIDisableAttribute("D1b.STRUCTFTLD"),
                    new UIDisableAttribute("D1b.STRUCTCVD"),
                    new UIDisableAttribute("D1b.IMAGLINF"),
                    new UIDisableAttribute("D1b.IMAGLAC"),
                    new UIDisableAttribute("D1b.IMAGMACH"),
                    new UIDisableAttribute("D1b.IMAGMICH"),
                    new UIDisableAttribute("D1b.IMAGWMH"),
                    new UIDisableAttribute("D1b.IMAGWMHSEV"),
                    new UIDisableAttribute("D1b.OTHBIOM1"),
                    new UIDisableAttribute("D1b.OTHBIOMX1"),
                    new UIDisableAttribute("D1b.BIOMAD1"),
                    new UIDisableAttribute("D1b.BIOMFTLD1"),
                    new UIDisableAttribute("D1b.BIOMLBD1"),
                    new UIDisableAttribute("D1b.BIOMOTH1"),
                    new UIDisableAttribute("D1b.BIOMOTHX1"),
                    new UIDisableAttribute("D1b.OTHBIOM2"),
                    new UIDisableAttribute("D1b.OTHBIOMX2"),
                    new UIDisableAttribute("D1b.BIOMAD2"),
                    new UIDisableAttribute("D1b.BIOMFTLD2"),
                    new UIDisableAttribute("D1b.BIOMLBD2"),
                    new UIDisableAttribute("D1b.BIOMOTH2"),
                    new UIDisableAttribute("D1b.BIOMOTHX2"),
                    new UIDisableAttribute("D1b.OTHBIOM3"),
                    new UIDisableAttribute("D1b.OTHBIOMX3"),
                    new UIDisableAttribute("D1b.BIOMAD3"),
                    new UIDisableAttribute("D1b.BIOMFTLD3"),
                    new UIDisableAttribute("D1b.BIOMLBD3"),
                    new UIDisableAttribute("D1b.BIOMOTH3"),
                    new UIDisableAttribute("D1b.BIOMOTHX3"),
                    new UIDisableAttribute("D1b.AUTDOMMUT"),

                },
                InstructionalMessage = "SKIP TO QUESTION 12"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.FLUIDBIOM"),
                    new UIEnableAttribute("D1b.IMAGINGDX"),
                    new UIEnableAttribute("D1b.OTHBIOM1"),
                    new UIEnableAttribute("D1b.AUTDOMMUT"),
                },
                InstructionalMessage = "CONTINUE TO QUESTION 2"
            } },
        };

        /****************** Question 2 ******************/
        public Dictionary<string, UIBehavior> FLUIDBIOMUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.BLOODAD"),
                    new UIDisableAttribute("D1b.BLOODFTLD"),
                    new UIDisableAttribute("D1b.BLOODLBD"),
                    new UIDisableAttribute("D1b.BLOODOTH"),
                    new UIDisableAttribute("D1b.BLOODOTHX"),
                    new UIDisableAttribute("D1b.CSFAD"),
                    new UIDisableAttribute("D1b.CSFFTLD"),
                    new UIDisableAttribute("D1b.CSFLBD"),
                    new UIDisableAttribute("D1b.CSFOTH"),
                    new UIDisableAttribute("D1b.CSFOTHX"),

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
                    new UIDisableAttribute("D1b.CSFOTHX"),
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
                    new UIDisableAttribute("D1b.BLOODOTHX"),
                    new UIEnableAttribute("D1b.CSFAD"),
                    new UIEnableAttribute("D1b.CSFFTLD"),
                    new UIEnableAttribute("D1b.CSFLBD"),
                    new UIEnableAttribute("D1b.CSFOTH"),
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
                }
            } },
        };

        /****************** Question 3d ******************/
        public Dictionary<string, UIBehavior> BLOODOTHXUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.BLOODOTHX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.BLOODOTHX") } },
            { "9", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.BLOODOTHX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.BLOODOTHX") } }

        };

        /****************** Question 4d ******************/
        public Dictionary<string, UIBehavior> CSFOTHUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.CSFOTHX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.CSFOTHX") } },
            { "9", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.CSFOTHX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.CSFOTHX") } }

        };

        /****************** Question 5 ******************/
        public Dictionary<string, UIBehavior> IMAGINGDXUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.PETDX"),
                    new UIDisableAttribute("D1b.AMYLPET"),
                    new UIDisableAttribute("D1b.TAUPET"),
                    new UIDisableAttribute("D1b.FDGPETDX"),
                    new UIDisableAttribute("D1b.FDGAD"),
                    new UIDisableAttribute("D1b.FDGFTLD"),
                    new UIDisableAttribute("D1b.FDGLBD"),
                    new UIDisableAttribute("D1b.FDGOTH"),
                    new UIDisableAttribute("D1b.FDGOTHX"),
                    new UIDisableAttribute("D1b.DATSCANDX"),
                    new UIDisableAttribute("D1b.TRACOTHDX"),
                    new UIDisableAttribute("D1b.TRACOTHDXX"),
                    new UIDisableAttribute("D1b.TRACERAD"),
                    new UIDisableAttribute("D1b.TRACERFTLD"),
                    new UIDisableAttribute("D1b.TRACERLBD"),
                    new UIDisableAttribute("D1b.TRACEROTH"),
                    new UIDisableAttribute("D1b.TRACEROTHX"),
                    new UIDisableAttribute("D1b.STRUCTDX"),
                    new UIDisableAttribute("D1b.STRUCTAD"),
                    new UIDisableAttribute("D1b.STRUCTFTLD"),
                    new UIDisableAttribute("D1b.STRUCTCVD"),
                    new UIDisableAttribute("D1b.IMAGLINF"),
                    new UIDisableAttribute("D1b.IMAGLAC"),
                    new UIDisableAttribute("D1b.IMAGMACH"),
                    new UIDisableAttribute("D1b.IMAGMICH"),
                    new UIDisableAttribute("D1b.IMAGWMH"),
                    new UIDisableAttribute("D1b.IMAGWMHSEV"),
                },
                InstructionalMessage = "SKIP TO QUESTION 8"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.PETDX"),
                    new UIEnableAttribute("D1b.FDGPETDX"),
                    new UIEnableAttribute("D1b.DATSCANDX"),
                    new UIEnableAttribute("D1b.TRACOTHDX"),
                    new UIDisableAttribute("D1b.STRUCTDX"),
                    new UIDisableAttribute("D1b.STRUCTAD"),
                    new UIDisableAttribute("D1b.STRUCTFTLD"),
                    new UIDisableAttribute("D1b.STRUCTCVD"),
                    new UIDisableAttribute("D1b.IMAGLINF"),
                    new UIDisableAttribute("D1b.IMAGLAC"),
                    new UIDisableAttribute("D1b.IMAGMACH"),
                    new UIDisableAttribute("D1b.IMAGMICH"),
                    new UIDisableAttribute("D1b.IMAGWMH"),
                    new UIDisableAttribute("D1b.IMAGWMHSEV"),

                },
                InstructionalMessage = "CONTINUE TO QUESTION 6, and SKIP QUESTIONS 7 – 7a3f"
            } },
             { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.PETDX"),
                    new UIDisableAttribute("D1b.AMYLPET"),
                    new UIDisableAttribute("D1b.TAUPET"),
                    new UIDisableAttribute("D1b.FDGPETDX"),
                    new UIDisableAttribute("D1b.FDGAD"),
                    new UIDisableAttribute("D1b.FDGFTLD"),
                    new UIDisableAttribute("D1b.FDGLBD"),
                    new UIDisableAttribute("D1b.FDGOTH"),
                    new UIDisableAttribute("D1b.FDGOTHX"),
                    new UIDisableAttribute("D1b.DATSCANDX"),
                    new UIDisableAttribute("D1b.TRACOTHDX"),
                    new UIDisableAttribute("D1b.TRACOTHDXX"),
                    new UIDisableAttribute("D1b.TRACERAD"),
                    new UIDisableAttribute("D1b.TRACERFTLD"),
                    new UIDisableAttribute("D1b.TRACERLBD"),
                    new UIDisableAttribute("D1b.TRACEROTH"),
                    new UIDisableAttribute("D1b.TRACEROTHX"),
                    new UIEnableAttribute("D1b.STRUCTDX")
                },
                InstructionalMessage = "SKIP TO QUESTION 7"
            } },
             { "3", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.PETDX"),
                    new UIEnableAttribute("D1b.FDGPETDX"),
                    new UIEnableAttribute("D1b.DATSCANDX"),
                    new UIEnableAttribute("D1b.TRACOTHDX"),
                    new UIEnableAttribute("D1b.STRUCTDX")
                }
            } },
        };

        /****************** Question 6a ******************/
        public Dictionary<string, UIBehavior> PETDXUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.AMYLPET"),
                    new UIDisableAttribute("D1b.TAUPET"),
                },
                InstructionalMessage = "SKIP TO QUESTION 6b"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.AMYLPET"),
                    new UIEnableAttribute("D1b.TAUPET"),
                }
            } },
             { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.AMYLPET"),
                    new UIEnableAttribute("D1b.TAUPET"),
                }
            } },
        };

        /****************** Question 6b ******************/
        public Dictionary<string, UIBehavior> FDGPETDXUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.FDGAD"),
                    new UIDisableAttribute("D1b.FDGFTLD"),
                    new UIDisableAttribute("D1b.FDGLBD"),
                    new UIDisableAttribute("D1b.FDGOTH"),
                    new UIDisableAttribute("D1b.FDGOTHX"),

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

                }
            } },
             { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("D1b.FDGAD"),
                    new UIEnableAttribute("D1b.FDGFTLD"),
                    new UIEnableAttribute("D1b.FDGLBD"),
                    new UIEnableAttribute("D1b.FDGOTH"),
                }
            } },
        };

        /****************** Question 6b4 ******************/
        public Dictionary<string, UIBehavior> FDGOTHUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.FDGOTHX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.FDGOTHX") } },
            { "9", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.FDGOTHX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.FDGOTHX") } }

        };

        /****************** Question 6d ******************/
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
                    new UIDisableAttribute("D1b.TRACEROTHX"),

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

        /****************** Question 6d4 ******************/
        public Dictionary<string, UIBehavior> TRACEROTHUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.TRACEROTHX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.TRACEROTHX") } },
            { "9", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.TRACEROTHX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.TRACEROTHX") } }

        };

        /****************** Question 7a ******************/
        public Dictionary<string, UIBehavior> STRUCTDXUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.STRUCTAD"),
                    new UIDisableAttribute("D1b.STRUCTFTLD"),
                    new UIDisableAttribute("D1b.STRUCTCVD"),
                    new UIDisableAttribute("D1b.IMAGLINF"),
                    new UIDisableAttribute("D1b.IMAGLAC"),
                    new UIDisableAttribute("D1b.IMAGMACH"),
                    new UIDisableAttribute("D1b.IMAGMICH"),
                    new UIDisableAttribute("D1b.IMAGWMH"),
                    new UIDisableAttribute("D1b.IMAGWMHSEV"),
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

        /****************** Question 7a3 ******************/
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
                    new UIDisableAttribute("D1b.IMAGWMHSEV"),

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
             { "8", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.IMAGLINF"),
                    new UIDisableAttribute("D1b.IMAGLAC"),
                    new UIDisableAttribute("D1b.IMAGMACH"),
                    new UIDisableAttribute("D1b.IMAGMICH"),
                    new UIDisableAttribute("D1b.IMAGWMH"),
                    new UIDisableAttribute("D1b.IMAGWMHSEV"),
                }
            } },
             { "9", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("D1b.IMAGLINF"),
                    new UIDisableAttribute("D1b.IMAGLAC"),
                    new UIDisableAttribute("D1b.IMAGMACH"),
                    new UIDisableAttribute("D1b.IMAGMICH"),
                    new UIDisableAttribute("D1b.IMAGWMH"),
                    new UIDisableAttribute("D1b.IMAGWMHSEV"),
                }
            } },
        };

        /****************** Question 7a3e ******************/
        public Dictionary<string, UIBehavior> IMAGWMHUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.IMAGWMHSEV") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.IMAGWMHSEV") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.IMAGWMHSEV") } },
            { "8", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.IMAGWMHSEV") } }
        };

        /****************** Question 8 ******************/
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
                    new UIDisableAttribute("D1b.BIOMOTHX1"),
                    new UIDisableAttribute("D1b.OTHBIOM2"),
                    new UIDisableAttribute("D1b.OTHBIOMX2"),
                    new UIDisableAttribute("D1b.BIOMAD2"),
                    new UIDisableAttribute("D1b.BIOMFTLD2"),
                    new UIDisableAttribute("D1b.BIOMLBD2"),
                    new UIDisableAttribute("D1b.BIOMOTH2"),
                    new UIDisableAttribute("D1b.BIOMOTHX2"),
                    new UIDisableAttribute("D1b.OTHBIOM3"),
                    new UIDisableAttribute("D1b.OTHBIOMX3"),
                    new UIDisableAttribute("D1b.BIOMAD3"),
                    new UIDisableAttribute("D1b.BIOMFTLD3"),
                    new UIDisableAttribute("D1b.BIOMLBD3"),
                    new UIDisableAttribute("D1b.BIOMOTH3"),
                    new UIDisableAttribute("D1b.BIOMOTHX3"),

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

        /****************** Question 8d ******************/
        public Dictionary<string, UIBehavior> BIOMOTH1UIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.BIOMOTHX1") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.BIOMOTHX1") } },
            { "9", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.BIOMOTHX1") } },
            { "8", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.BIOMOTHX1") } }

        };

        /****************** Question 9 ******************/
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
                    new UIDisableAttribute("D1b.BIOMOTHX2"),
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

        /****************** Question 9d ******************/
        public Dictionary<string, UIBehavior> BIOMOTH2UIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.BIOMOTHX2") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.BIOMOTHX2") } },
            { "9", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.BIOMOTHX2") } },
            { "8", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.BIOMOTHX2") } }

        };
        /****************** Question 10 ******************/
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
                    new UIDisableAttribute("D1b.BIOMOTHX3"),

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

        /****************** Question 10d ******************/
        public Dictionary<string, UIBehavior> BIOMOTH3UIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.BIOMOTHX3") } },
            { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.BIOMOTHX3") } },
            { "9", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.BIOMOTHX3") } },
            { "8", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.BIOMOTHX3") } }

        };

        /****************** Question 14e ******************/
        public Dictionary<string, UIBehavior> FTLDSUBTUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.FTLDSUBX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.FTLDSUBX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIEnableAttribute("D1b.FTLDSUBX") } },
            { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("D1b.FTLDSUBX") } }

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
