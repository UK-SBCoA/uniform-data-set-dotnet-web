using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Pages.UDS4
{
    public class C2Model : FormPageModel
    {
        [BindProperty]
        public C2 C2 { get; set; } = default!;

        public UIRangeToggle OTRAILABehavior { get; } = new()
        {
            Behaviors =
            {
                new()
                {
                    Low = 0,
                    High = 100,
                    PropertyAttributes =
                    {
                        new UIEnableAttribute("C2.OTRLARR"),
                        new UIEnableAttribute("C2.OTRLALI")
                    }
                },

                new()
                {
                    Low = 888,
                    High = 888,
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.OTRLARR"),
                        new UIDisableAttribute("C2.OTRLALI")
                    }
                },

                new()
                {
                    Low = 995,
                    High = 998,
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.OTRLARR"),
                        new UIDisableAttribute("C2.OTRLALI")
                    },
                    InstructionalMessage = "If test was not completed, enter reason code, 995-998. If test was skipped because optional, enter 888, and SKIP TO QUESTION 7b."
                }
            }
        };

        public UIRangeToggle OTRAILBBehavior { get; } = new()
        {
            Behaviors =
    {
        new()
        {
            Low = 0,
            High = 300,
            PropertyAttributes =
            {
                new UIEnableAttribute("C2.OTRLBRR"),
                new UIEnableAttribute("C2.OTRLBLI")
            }
        },

        new()
        {
            Low = 888,
            High = 888,
            PropertyAttributes =
            {
                new UIDisableAttribute("C2.OTRLBRR"),
                new UIDisableAttribute("C2.OTRLBLI")
            }
        },

        new()
        {
            Low = 995,
            High = 998,
            PropertyAttributes =
            {
                new UIDisableAttribute("C2.OTRLBRR"),
                new UIDisableAttribute("C2.OTRLBLI")
            },
            InstructionalMessage = "If test was not completed, enter reason code, 995-998. If test was skipped because optional, enter 888, and SKIP TO QUESTION 8a."
        }
    }
        };

        public UIRangeToggle CERAD1RECBehavior { get; } = new()
        {
            Behaviors =
            {
                new()
                {
                    Low = 0,
                    High = 10,
                    InstructionalMessage = "If test was not completed, enter reason code, 95-98. SKIP TO QUESTION 16a.",
                    PropertyAttributes =
                    {
                        new UIEnableAttribute("C2.CERAD1READ"),
                        new UIEnableAttribute("C2.CERAD1INT"),
                        new UIEnableAttribute("C2.CERAD2REC"),
                        new UIEnableAttribute("C2.CERAD2READ"),
                        new UIEnableAttribute("C2.CERAD2INT"),
                        new UIEnableAttribute("C2.CERAD3REC"),
                        new UIEnableAttribute("C2.CERAD3READ"),
                        new UIEnableAttribute("C2.CERAD3INT"),
                        new UIEnableAttribute("C2.CERADDTI"),
                        new UIEnableAttribute("C2.CERADJ6REC"),
                        new UIEnableAttribute("C2.CERADJ6INT"),
                        new UIEnableAttribute("C2.CERADJ7YES"),
                        new UIEnableAttribute("C2.CERADJ7NO")
                    }
                },

                new()
                {
                    Low = 95,
                    High = 98,
                    InstructionalMessage = "If test was not completed, enter reason code, 95-98. SKIP TO QUESTION 16a.",
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.CERAD1READ"),
                        new UIDisableAttribute("C2.CERAD1INT"),
                        new UIDisableAttribute("C2.CERAD2REC"),
                        new UIDisableAttribute("C2.CERAD2READ"),
                        new UIDisableAttribute("C2.CERAD2INT"),
                        new UIDisableAttribute("C2.CERAD3REC"),
                        new UIDisableAttribute("C2.CERAD3READ"),
                        new UIDisableAttribute("C2.CERAD3INT"),
                        new UIDisableAttribute("C2.CERADDTI"),
                        new UIDisableAttribute("C2.CERADJ6REC"),
                        new UIDisableAttribute("C2.CERADJ6INT"),
                        new UIDisableAttribute("C2.CERADJ7YES"),
                        new UIDisableAttribute("C2.CERADJ7NO")
                    }
                }
            }
        };

        public UIRangeToggle CERADJ6RECBehavior { get; } = new()
        {
            Behaviors =
            {
                new()
                {
                    Low = 0,
                    High = 10,
                    InstructionalMessage = "If test was not completed, enter reason code, 95-98. SKIP TO QUESTION 15d.",
                    PropertyAttributes =
                    {
                        new UIEnableAttribute("C2.CERADJ6INT")
                    }
                },

                new()
                {
                    Low = 95,
                    High = 98,
                    InstructionalMessage = "If test was not completed, enter reason code, 95-98. SKIP TO QUESTION 15d.",
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.CERADJ6INT")
                    }
                }
            }
        };

        public UIRangeToggle CERADJ7YESBehavior { get; } = new()
        {
            Behaviors =
            {
                new()
                {
                    Low = 0,
                    High = 10,
                    InstructionalMessage = "If test was not completed, enter reason code, 95-98. SKIP TO QUESTION 16a.",
                    PropertyAttributes =
                    {
                        new UIEnableAttribute("C2.CERADJ7NO")
                    }
                },

                new()
                {
                    Low = 95,
                    High = 98,
                    InstructionalMessage = "If test was not completed, enter reason code, 95-98. SKIP TO QUESTION 16a.",
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.CERADJ7NO")
                    }
                }
            }
        };


        public UIRangeToggle REYDRECBehavior { get; } = new()
        {
            Behaviors =
            {
                new()
                {
                    Low = 0,
                    High = 15,
                    PropertyAttributes =
                    {
                        new UIEnableAttribute("C2.REYDINT"),
                        new UIEnableAttribute("C2.REYDTI"),
                        new UIEnableAttribute("C2.REYMETHOD"),
                        new UIEnableAttribute("C2.REYTCOR"),
                        new UIEnableAttribute("C2.REYFPOS")
                    }
                },

                new()
                {
                    Low = 88,
                    High = 88,
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.REYDINT"),
                        new UIDisableAttribute("C2.REYDTI"),
                        new UIDisableAttribute("C2.REYMETHOD"),
                        new UIDisableAttribute("C2.REYTCOR"),
                        new UIDisableAttribute("C2.REYFPOS")
                    }
                },

                new()
                {
                    Low = 95,
                    High = 98,
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.REYDINT"),
                        new UIDisableAttribute("C2.REYDTI"),
                        new UIDisableAttribute("C2.REYMETHOD"),
                        new UIDisableAttribute("C2.REYTCOR"),
                        new UIDisableAttribute("C2.REYFPOS")
                    }
                }
            }
        };

        public UIRangeToggle C2TREYDRECBehavior { get; } = new()
        {
            Behaviors =
            {
                new()
                {
                    Low = 0,
                    High = 15,
                    InstructionalMessage = "If test not completed, enter reason code, 95-98, and SKIP TO QUESTION 14a.",
                    PropertyAttributes =
                    {
                        new UIEnableAttribute("C2.REYDINT"),
                        new UIEnableAttribute("C2.REYDTI"),
                        new UIEnableAttribute("C2.REYTCOR"),
                        new UIEnableAttribute("C2.REYFPOS")
                    }
                },

                new()
                {
                    Low = 88,
                    High = 88,
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.REYDINT"),
                        new UIDisableAttribute("C2.REYDTI"),
                        new UIDisableAttribute("C2.REYTCOR"),
                        new UIDisableAttribute("C2.REYFPOS")
                    }
                },

                new()
                {
                    Low = 95,
                    High = 98,
                    InstructionalMessage = "If test not completed, enter reason code, 95-98, and SKIP TO QUESTION 14a.",
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.REYDINT"),
                        new UIDisableAttribute("C2.REYDTI"),
                        new UIDisableAttribute("C2.REYTCOR"),
                        new UIDisableAttribute("C2.REYFPOS")
                    }
                }
            }
        };

        public List<RadioListItem> RESPVALListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Very valid, probably accurate indication of participant’s cognitive abilities (END FORM HERE)", "1"),
            new RadioListItem("Questionably valid, possibly inaccurate indication of participant’s cognitive abilities (CONTINUE)", "2"),
            new RadioListItem("Invalid, probably inaccurate indication of participant’s cognitive abilities (CONTINUE)", "3")
        };

        public Dictionary<string, UIBehavior> RESPVALBehavior = new Dictionary<string, UIBehavior>
        {
             { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {

                    new UIDisableAttribute("C2.RESPHEAR"),
                    new UIDisableAttribute("C2.RESPDIST"),
                    new UIDisableAttribute("C2.RESPINTR"),
                    new UIDisableAttribute("C2.RESPDISN"),
                    new UIDisableAttribute("C2.RESPFATG"),
                    new UIDisableAttribute("C2.RESPEMOT"),
                    new UIDisableAttribute("C2.RESPASST"),
                    new UIDisableAttribute("C2.RESPOTH"),
                    new UIDisableAttribute("C2.RESPOTHX")
                },
                InstructionalMessage = "End form here."
            } },
            { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {

                    new UIEnableAttribute("C2.RESPHEAR"),
                    new UIEnableAttribute("C2.RESPDIST"),
                    new UIEnableAttribute("C2.RESPINTR"),
                    new UIEnableAttribute("C2.RESPDISN"),
                    new UIEnableAttribute("C2.RESPFATG"),
                    new UIEnableAttribute("C2.RESPEMOT"),
                    new UIEnableAttribute("C2.RESPASST"),
                    new UIEnableAttribute("C2.RESPOTH")
                },
                InstructionalMessage = "continue to question 14b"
            } },
            { "3", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {

                    new UIEnableAttribute("C2.RESPHEAR"),
                    new UIEnableAttribute("C2.RESPDIST"),
                    new UIEnableAttribute("C2.RESPINTR"),
                    new UIEnableAttribute("C2.RESPDISN"),
                    new UIEnableAttribute("C2.RESPFATG"),
                    new UIEnableAttribute("C2.RESPEMOT"),
                    new UIEnableAttribute("C2.RESPASST"),
                    new UIEnableAttribute("C2.RESPOTH")
                },
                InstructionalMessage = "continue to question 14b"
            } }
        };

        public List<RadioListItem> SimpleNoYesListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1")
        };

        public List<RadioListItem> MoCACompletedListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("No (skip to question 2a)", "0"),
            new RadioListItem("Yes (continue to question 1b)", "1")
        };

        public List<RadioListItem> LocationListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("In ADC/clinic", "1"),
            new RadioListItem("In home", "2"),
            new RadioListItem("In person - other", "3")
        };

        public List<RadioListItem> LanguageListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("English", "1"),
            new RadioListItem("Spanish", "2"),
            new RadioListItem("Other (specify)", "3")
        };

        public List<RadioListItem> OverallListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Better than normal for age", "1"),
            new RadioListItem("Normal for age", "2"),
            new RadioListItem("One or two test scores are abnormal", "3"),
            new RadioListItem("Three or more scores are abnormal or lower than expected", "4"),
            new RadioListItem("Clinician unable to render opinion", "0")
        };

        public Dictionary<string, UIBehavior> MOCACOMPBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C2.MOCAREAS"),
                    new UIDisableAttribute("C2.MOCALOC"),
                    new UIDisableAttribute("C2.MOCALAN"),
                    new UIDisableAttribute("C2.MOCALANX"),
                    new UIDisableAttribute("C2.MOCAVIS"),
                    new UIDisableAttribute("C2.MOCAHEAR"),
                    new UIDisableAttribute("C2.MOCATOTS"),
                    new UIDisableAttribute("C2.MOCBTOTS"),
                    new UIDisableAttribute("C2.MOCATRAI"),
                    new UIDisableAttribute("C2.MOCACUBE"),
                    new UIDisableAttribute("C2.MOCACLOC"),
                    new UIDisableAttribute("C2.MOCACLON"),
                    new UIDisableAttribute("C2.MOCACLOH"),
                    new UIDisableAttribute("C2.MOCANAMI"),
                    new UIDisableAttribute("C2.MOCAREGI"),
                    new UIDisableAttribute("C2.MOCADIGI"),
                    new UIDisableAttribute("C2.MOCALETT"),
                    new UIDisableAttribute("C2.MOCASER7"),
                    new UIDisableAttribute("C2.MOCAREPE"),
                    new UIDisableAttribute("C2.MOCAFLUE"),
                    new UIDisableAttribute("C2.MOCAABST"),
                    new UIDisableAttribute("C2.MOCARECN"),
                    new UIDisableAttribute("C2.MOCARECC"),
                    new UIDisableAttribute("C2.MOCARECR"),
                    new UIDisableAttribute("C2.MOCAORDT"),
                    new UIDisableAttribute("C2.MOCAORMO"),
                    new UIDisableAttribute("C2.MOCAORYR"),
                    new UIDisableAttribute("C2.MOCAORDY"),
                    new UIDisableAttribute("C2.MOCAORPL"),
                    new UIDisableAttribute("C2.MOCAORCT")
                },
                InstructionalMessage = "skip to question 2a"
            } },
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("C2.MOCAREAS"),
                    new UIEnableAttribute("C2.MOCALOC"),
                    new UIEnableAttribute("C2.MOCALAN"),
                    new UIEnableAttribute("C2.MOCAVIS"),
                    new UIEnableAttribute("C2.MOCAHEAR"),
                    new UIEnableAttribute("C2.MOCATOTS"),
                    new UIEnableAttribute("C2.MOCBTOTS"),
                    new UIEnableAttribute("C2.MOCATRAI"),
                    new UIEnableAttribute("C2.MOCACUBE"),
                    new UIEnableAttribute("C2.MOCACLOC"),
                    new UIEnableAttribute("C2.MOCACLON"),
                    new UIEnableAttribute("C2.MOCACLOH"),
                    new UIEnableAttribute("C2.MOCANAMI"),
                    new UIEnableAttribute("C2.MOCAREGI"),
                    new UIEnableAttribute("C2.MOCADIGI"),
                    new UIEnableAttribute("C2.MOCALETT"),
                    new UIEnableAttribute("C2.MOCASER7"),
                    new UIEnableAttribute("C2.MOCAREPE"),
                    new UIEnableAttribute("C2.MOCAFLUE"),
                    new UIEnableAttribute("C2.MOCAABST"),
                    new UIEnableAttribute("C2.MOCARECN"),
                    new UIEnableAttribute("C2.MOCARECC"),
                    new UIEnableAttribute("C2.MOCARECR"),
                    new UIEnableAttribute("C2.MOCAORDT"),
                    new UIEnableAttribute("C2.MOCAORMO"),
                    new UIEnableAttribute("C2.MOCAORYR"),
                    new UIEnableAttribute("C2.MOCAORDY"),
                    new UIEnableAttribute("C2.MOCAORPL"),
                    new UIEnableAttribute("C2.MOCAORCT")
                },
                InstructionalMessage = "continue to question 1b"
            } }
        };

        public Dictionary<string, UIBehavior> MOCALANBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("C2.MOCALANX")} },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("C2.MOCALANX")} },
            { "3", new UIBehavior { PropertyAttribute = new UIEnableAttribute("C2.MOCALANX")} }
        };

        public Dictionary<string, UIBehavior> NPSYLANBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("C2.NPSYLANX")} },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("C2.NPSYLANX")} },
            { "3", new UIBehavior { PropertyAttribute = new UIEnableAttribute("C2.NPSYLANX")} }
        };

        public UIRangeToggle UDSVERFCBehavior { get; } = new()
        {
            Behaviors =
            {
                new()
                {
                    Low = 0,
                    High = 40,
                    InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 12d.",
                    PropertyAttributes =
                    {
                        new UIEnableAttribute("C2.UDSVERFN"),
                        new UIEnableAttribute("C2.UDSVERNF")
                    }
                },

                new()
                {
                    Low = 95,
                    High = 98,
                    InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 12d.",
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.UDSVERFN"),
                        new UIDisableAttribute("C2.UDSVERNF")
                    }
                }
            }
        };

        public UIRangeToggle UDSVERLCBehavior { get; } = new()
        {
            Behaviors =
            {
                new()
                {
                    Low = 0,
                    High = 40,
                    InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 13a.",
                    PropertyAttributes =
                    {
                        new UIEnableAttribute("C2.UDSVERLR"),
                        new UIEnableAttribute("C2.UDSVERLN"),
                        new UIEnableAttribute("C2.UDSVERTN"),
                        new UIEnableAttribute("C2.UDSVERTE"),
                        new UIEnableAttribute("C2.UDSVERTI")
                    }
                },

                new()
                {
                    Low = 95,
                    High = 98,
                    InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 13a.",
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.UDSVERLR"),
                        new UIDisableAttribute("C2.UDSVERLN"),
                        new UIDisableAttribute("C2.UDSVERTN"),
                        new UIDisableAttribute("C2.UDSVERTE"),
                        new UIDisableAttribute("C2.UDSVERTI")
                    }
                }
            }
        };

        public List<RadioListItem> VERBALTESTListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Rey AVLT (COMPLETE SECTIONS 12 & 13, SKIP SECTIONS 14 & 15)", "1"),
            new RadioListItem("CERAD (SKIP TO SECTION 14)", "2"),

        };

        public List<RadioListItem> VERBALTESTC2TListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Rey AVLT (COMPLETE SECTIONS 6 & 13, SKIP SECTIONS 7 & 9)", "1"),
            new RadioListItem("CERAD (COMPLETE SECTIONS 7 & 9 SKIP SECTIONS 6 & 13)", "2"),

        };

        public Dictionary<string, UIBehavior> VERBALTESTBehavior = new Dictionary<string, UIBehavior>
        {
            { "1", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("C2.REY1REC"),
                    new UIEnableAttribute("C2.REYDREC"),
                    new UIEnableAttribute("C2.REYDINT"),
                    new UIEnableAttribute("C2.REYDTI"),
                    new UIEnableAttribute("C2.REYMETHOD"),
                    new UIEnableAttribute("C2.REYTCOR"),
                    new UIEnableAttribute("C2.REYFPOS"),
                    new UIDisableAttribute("C2.CERAD1REC"),
                    new UIDisableAttribute("C2.CERAD1READ"),
                    new UIDisableAttribute("C2.CERAD1INT"),
                    new UIDisableAttribute("C2.CERAD2REC"),
                    new UIDisableAttribute("C2.CERAD2READ"),
                    new UIDisableAttribute("C2.CERAD2INT"),
                    new UIDisableAttribute("C2.CERAD3REC"),
                    new UIDisableAttribute("C2.CERAD3READ"),
                    new UIDisableAttribute("C2.CERAD3INT"),
                    new UIDisableAttribute("C2.CERADDTI"),
                    new UIDisableAttribute("C2.CERADJ6REC"),
                    new UIDisableAttribute("C2.CERADJ6INT"),
                    new UIDisableAttribute("C2.CERADJ7YES"),
                    new UIDisableAttribute("C2.CERADJ7NO")
                },
                InstructionalMessage = "Complete sections 12 & 13, skip sections 14 & 15"
            } },
            { "2", new UIBehavior {
                PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("C2.REY1REC"),
                    new UIDisableAttribute("C2.REY1INT"),
                    new UIDisableAttribute("C2.REY2REC"),
                    new UIDisableAttribute("C2.REY2INT"),
                    new UIDisableAttribute("C2.REY3REC"),
                    new UIDisableAttribute("C2.REY3INT"),
                    new UIDisableAttribute("C2.REY4REC"),
                    new UIDisableAttribute("C2.REY4INT"),
                    new UIDisableAttribute("C2.REY5REC"),
                    new UIDisableAttribute("C2.REY5INT"),
                    new UIDisableAttribute("C2.REYBREC"),
                    new UIDisableAttribute("C2.REYBINT"),
                    new UIDisableAttribute("C2.REY6REC"),
                    new UIDisableAttribute("C2.REY6INT"),
                    new UIDisableAttribute("C2.REYDREC"),
                    new UIDisableAttribute("C2.REYDINT"),
                    new UIDisableAttribute("C2.REYDTI"),
                    new UIDisableAttribute("C2.REYMETHOD"),
                    new UIDisableAttribute("C2.REYTCOR"),
                    new UIDisableAttribute("C2.REYFPOS"),
                    new UIEnableAttribute("C2.CERAD1REC"),
                    new UIEnableAttribute("C2.CERAD1READ"),
                    new UIEnableAttribute("C2.CERAD1INT"),
                    new UIEnableAttribute("C2.CERAD2REC"),
                    new UIEnableAttribute("C2.CERAD2READ"),
                    new UIEnableAttribute("C2.CERAD2INT"),
                    new UIEnableAttribute("C2.CERAD3REC"),
                    new UIEnableAttribute("C2.CERAD3READ"),
                    new UIEnableAttribute("C2.CERAD3INT"),
                    new UIEnableAttribute("C2.CERADDTI"),
                    new UIEnableAttribute("C2.CERADJ6REC"),
                    new UIEnableAttribute("C2.CERADJ6INT"),
                    new UIEnableAttribute("C2.CERADJ7YES"),
                    new UIEnableAttribute("C2.CERADJ7NO")
                },
                InstructionalMessage = "Skip to section 14"
            } }
        };

        public List<RadioListItem> REYMETHODListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("List shown", "1"),
            new RadioListItem("List read", "2"),

        };

        public UIRangeToggle MINTTOTSBehavior { get; } = new()
        {
            Behaviors =
            {
                new()
                {
                    Low = 0,
                    High = 32,
                    InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 12a.",
                    PropertyAttributes =
                    {
                        new UIEnableAttribute("C2.MINTTOTW"),
                        new UIEnableAttribute("C2.MINTSCNG"),
                        new UIEnableAttribute("C2.MINTSCNC"),
                        new UIEnableAttribute("C2.MINTPCNG"),
                        new UIEnableAttribute("C2.MINTPCNC")
                    }
                },

                new()
                {
                    Low = 95,
                    High = 98,
                    InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 12a.",
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.MINTTOTW"),
                        new UIDisableAttribute("C2.MINTSCNG"),
                        new UIDisableAttribute("C2.MINTSCNC"),
                        new UIDisableAttribute("C2.MINTPCNG"),
                        new UIDisableAttribute("C2.MINTPCNC")
                    }
                }
            }
        };

        public UIRangeToggle UDSBENTDBehavior { get; } = new()
        {
            Behaviors =
            {
                new()
                {
                    Low = 0,
                    High = 17,
                    InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 11a.",
                    PropertyAttributes =
                    {
                        new UIEnableAttribute("C2.UDSBENRS")
                    }
                },

                new()
                {
                    Low = 95,
                    High = 98,
                    InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 11a.",
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.UDSBENRS")
                    }
                }
            }
        };

        public UIRangeToggle CRAFTDVRBehavior { get; } = new()
        {
            Behaviors =
            {
                new()
                {
                    Low = 0,
                    High = 44,
                    InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 10a.",
                    PropertyAttributes =
                    {
                        new UIEnableAttribute("C2.CRAFTDRE"),
                        new UIEnableAttribute("C2.CRAFTDTI"),
                        new UIEnableAttribute("C2.CRAFTCUE")
                    }
                },

                new()
                {
                    Low = 95,
                    High = 98,
                    InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 10a.",
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.CRAFTDRE"),
                        new UIDisableAttribute("C2.CRAFTDTI"),
                        new UIDisableAttribute("C2.CRAFTCUE")
                    }
                }
            }
        };

        public UIRangeToggle TRAILABehavior { get; } = new()
        {
            Behaviors =
            {
                new()
                {
                    Low = 0,
                    High = 150,
                    InstructionalMessage = "if test not completed, enter reason code, 995-998, and skip to question 8b.",
                    PropertyAttributes =
                    {
                        new UIEnableAttribute("C2.TRAILARR"),
                        new UIEnableAttribute("C2.TRAILALI")
                    }
                },

                new()
                {
                    Low = 995,
                    High = 998,
                    InstructionalMessage = "if test not completed, enter reason code, 995-998, and skip to question 8b.",
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.TRAILARR"),
                        new UIDisableAttribute("C2.TRAILALI")
                    }
                }
            }
        };

        public UIRangeToggle TRAILBBehavior { get; } = new()
        {
            Behaviors =
            {
                new()
                {
                    Low = 0,
                    High = 300,
                    InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 9a.",
                    PropertyAttributes =
                    {
                        new UIEnableAttribute("C2.TRAILBRR"),
                        new UIEnableAttribute("C2.TRAILBLI")
                    }
                },

                new()
                {
                    Low = 995,
                    High = 998,
                    InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 9a.",
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.TRAILBRR"),
                        new UIDisableAttribute("C2.TRAILBLI")
                    }
                }
            }
        };

        public UIRangeToggle DIGBACCTBehavior { get; } = new()
        {
            Behaviors =
            {
                new()
                {
                    Low = 0,
                    High = 14,
                    InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 7a.",
                    PropertyAttributes =
                    {
                        new UIEnableAttribute("C2.DIGBACLS")
                    }
                },

                new()
                {
                    Low = 95,
                    High = 98,
                    InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 7a.",
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.DIGBACLS")
                    }
                }
            }
        };

        public UIRangeToggle DIGFORCTBehavior { get; } = new()
        {
            Behaviors =
            {
                new()
                {
                    Low = 0,
                    High = 14,
                    InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 6a.",
                    PropertyAttributes =
                    {
                        new UIEnableAttribute("C2.DIGFORSL")
                    }
                },

                new()
                {
                    Low = 95,
                    High = 98,
                    InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 6a.",
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.DIGFORSL")
                    }
                }
            }
        };

        public UIRangeToggle CRAFTVRSBehavior { get; } = new()
        {
            Behaviors =
            {
                new()
                {
                    Low = 0,
                    High = 44,
                    InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 4a.",
                    PropertyAttributes =
                    {
                        new UIEnableAttribute("C2.CRAFTURS")
                    }
                },

                new()
                {
                    Low = 95,
                    High = 98,
                    InstructionalMessage = "if test not completed, enter reason code, 95-98, and skip to question 4a.",
                    PropertyAttributes =
                    {
                        new UIDisableAttribute("C2.CRAFTURS")
                    }
                }
            }
        };

        public C2Model(IVisitService visitService, IParticipationService participationService, IPacketService packetService) : base(visitService, participationService, packetService, "C2")
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                C2 = (C2)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        public async Task<IActionResult> OnPostChangeMode()
        {
            FormMode modeSwitch = C2.MODE;
            RemoteModality? modalitySwitch = C2.RMMODE;

            //Get relevant base form data
            await base.OnGetAsync(Visit.Id);

            if (BaseForm != null)
            {
                C2 = (C2)BaseForm;
            }

            //Apply change to mode and modality based on form switch data
            C2.MODE = modeSwitch;
            C2.RMMODE = C2.MODE == FormMode.InPerson ? null : modalitySwitch;

            //Form returns model errors on switch, clearing them before load
            ModelState.Clear();

            if (C2.MODE == FormMode.Remote && C2.RMMODE == RemoteModality.Telephone)
            {
                return Partial("_C2T", this);
            }
            else
            {
                return Partial("_C2", this);
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync(int id, string? goNext = null)
        {
            BaseForm = C2; // reassign bounded and derived form to base form for base method

            Visit.Forms.Add(C2); // visit needs updated form as well

            return await base.OnPostAsync(id, goNext); // checks for validation, etc.          
        }
    }
}
