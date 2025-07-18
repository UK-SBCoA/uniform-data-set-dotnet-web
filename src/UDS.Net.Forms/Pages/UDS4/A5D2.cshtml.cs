using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS4;

public class A5D2Model : FormPageModel
{
    [BindProperty]
    public A5D2 A5D2 { get; set; } = default!;

    public A5D2Model(IVisitService visitService, IParticipationService participationService) : base(visitService, participationService, "A5D2")
    {
    }

    public List<RadioListItem> BasicYesNoListItems { get; set; } = new List<RadioListItem>
    {
        new RadioListItem("No", "0"),
        new RadioListItem("Yes", "1"),
        new RadioListItem("UNK", "9")
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
        new RadioListItem("", ""),
        new RadioListItem("Unknown", "9")
    };

    public List<RadioListItem> SEIZNUMItems { get; set; } = new List<RadioListItem>
    {
        new RadioListItem("None", "0"),
        new RadioListItem("1 or 2", "1"),
        new RadioListItem("3 or more", "2"),
        new RadioListItem("Unknown", "9")
    };

    public List<RadioListItem> HeadInjuryUnconsciousItems { get; set; } = new List<RadioListItem>
    {
        new RadioListItem("Less than 5 minutes", "0"),
        new RadioListItem("5 minutes to less than 30 minutes", "1"),
        new RadioListItem("30 minutes to less than 24 hours", "2"),
        new RadioListItem("1 day to less than 7 days", "3"),
        new RadioListItem("7 days or more", "4"),
        new RadioListItem("Not applicable, no loss of consciousness", "8"),
        new RadioListItem("Unknown duration", "9")
    };

    public List<RadioListItem> HeadInjuryDazedItems { get; set; } = new List<RadioListItem>
    {
        new RadioListItem("Less than 5 minutes", "0"),
        new RadioListItem("5 minutes to less than 30 minutes", "1"),
        new RadioListItem("30 minutes to less than 24 hours", "2"),
        new RadioListItem("1 day to less than 7 days", "3"),
        new RadioListItem("7 days or more", "4"),
        new RadioListItem("Not applicable, never dazed and confused", "8"),
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

    public List<RadioListItem> HoursPerNightItems { get; set; } = new List<RadioListItem>
    {
        new RadioListItem("None", "0"),
        new RadioListItem("< 4 hours per night", "1"),
        new RadioListItem("> 4 hours per night", "2"),
        new RadioListItem("Unknown", "9")
    };

    public List<RadioListItem> UntreadedTreatedItems { get; set; } = new List<RadioListItem>
    {
        new RadioListItem("Untreaded", "0"),
        new RadioListItem("Treated with medication and/or counseling", "1")
    };

    /****************** Question 1 ******************/
    public Dictionary<string, UIBehavior> TOBAC100UIBehavior = new Dictionary<string, UIBehavior>
    {
        { "0", new UIBehavior {
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIDisableAttribute("A5D2.SMOKYRS"),
                new UIDisableAttribute("A5D2.PACKSPER"),
                new UIDisableAttribute("A5D2.TOBAC30"),
                new UIDisableAttribute("A5D2.QUITSMOK"),
            },
            InstructionalMessage = "SKIP TO QUESTION 1f"
        }},
        { "1", new UIBehavior {
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A5D2.SMOKYRS"),
                new UIEnableAttribute("A5D2.PACKSPER"),
                new UIEnableAttribute("A5D2.TOBAC30"),
                new UIEnableAttribute("A5D2.QUITSMOK"),
            }
        } },
        { "9", new UIBehavior {
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIDisableAttribute("A5D2.SMOKYRS"),
                new UIDisableAttribute("A5D2.PACKSPER"),
                new UIDisableAttribute("A5D2.TOBAC30"),
                new UIDisableAttribute("A5D2.QUITSMOK"),
            },
            InstructionalMessage = "SKIP TO QUESTION 1f"
        } },
    };

    /****************** Question 1f ******************/
    public Dictionary<string, UIBehavior> ALCFREQYRBehavior = new Dictionary<string, UIBehavior>
    {
         { "0", new UIBehavior {
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIDisableAttribute("A5D2.ALCDRINKS"),
                new UIDisableAttribute("A5D2.ALCBINGE"),
            },
            InstructionalMessage = "SKIP TO QUESTION 1i"
         } },
         { "1", new UIBehavior {
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A5D2.ALCDRINKS"),
                new UIEnableAttribute("A5D2.ALCBINGE"),
            }
         } },
         { "2", new UIBehavior {
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A5D2.ALCDRINKS"),
                new UIEnableAttribute("A5D2.ALCBINGE"),
            }
         } },
         { "3", new UIBehavior {
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A5D2.ALCDRINKS"),
                new UIEnableAttribute("A5D2.ALCBINGE"),
            }
         } },
         { "4", new UIBehavior {
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A5D2.ALCDRINKS"),
                new UIEnableAttribute("A5D2.ALCBINGE"),
            }
         } },
         { "9", new UIBehavior {
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIDisableAttribute("A5D2.ALCDRINKS"),
                new UIDisableAttribute("A5D2.ALCBINGE"),
            },
            InstructionalMessage = "SKIP TO QUESTION 1i"
         } },
    };

    /****************** Question 2a ******************/
    public Dictionary<string, UIBehavior> HRTATTACKBehavior = new Dictionary<string, UIBehavior>
    {
         { "0", new UIBehavior {
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIDisableAttribute("A5D2.HRTATTMULT"),
                new UIDisableAttribute("A5D2.HRTATTAGE")
            },
            InstructionalMessage = "SKIP TO QUESTION 2b"
         } },
         { "1", new UIBehavior {
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A5D2.HRTATTMULT"),
                new UIEnableAttribute("A5D2.HRTATTAGE")
            }
         } },
         { "2", new UIBehavior {
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIEnableAttribute("A5D2.HRTATTMULT"),
                new UIEnableAttribute("A5D2.HRTATTAGE")
            }
         } },
         { "9", new UIBehavior {
            PropertyAttributes = new List<UIPropertyAttributes>
            {
                new UIDisableAttribute("A5D2.HRTATTMULT"),
                new UIDisableAttribute("A5D2.HRTATTAGE")
            },
            InstructionalMessage = "SKIP TO QUESTION 2b"
         } },
    };

    /****************** Question 2a ******************/
    public Dictionary<string, UIBehavior> CARDARRESTBehavior = new Dictionary<string, UIBehavior>
    {
         { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5D2.CARDARRAGE") } },
         { "1", new UIBehavior { PropertyAttribute =new UIEnableAttribute("A5D2.CARDARRAGE") } },
         { "2", new UIBehavior {  PropertyAttribute = new UIEnableAttribute("A5D2.CARDARRAGE") } },
         { "9", new UIBehavior {  PropertyAttribute = new UIDisableAttribute("A5D2.CARDARRAGE") } }
    };

    /****************** Question 2e ******************/
    public Dictionary<string, UIBehavior> CVBYPASSBehavior = new Dictionary<string, UIBehavior>
    {
         { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5D2.BYPASSAGE") } },
         { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5D2.BYPASSAGE") } },
         { "2", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5D2.BYPASSAGE") } },
         { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5D2.BYPASSAGE") } }
    };

    /****************** Question 2f ******************/
    public Dictionary<string, UIBehavior> CVPACDEFBehavior = new Dictionary<string, UIBehavior>
    {
         { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5D2.PACDEFAGE") } },
         { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5D2.PACDEFAGE")} },
         { "2", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5D2.PACDEFAGE") } },
         { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5D2.PACDEFAGE") } }
    };

    /****************** Question 2h ******************/
    public Dictionary<string, UIBehavior> CVHVALVEBehavior = new Dictionary<string, UIBehavior>
    {
         { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5D2.VALVEAGE") } },
         { "1", new UIBehavior {  PropertyAttribute = new UIEnableAttribute("A5D2.VALVEAGE") } },
         { "2", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5D2.VALVEAGE") } },
         { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5D2.VALVEAGE") } }
    };

    /****************** Question 2i ******************/
    public Dictionary<string, UIBehavior> CVOTHRBehavior = new Dictionary<string, UIBehavior>
    {
         { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5D2.CVOTHRX") } },
         { "1", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5D2.CVOTHRX") } },
         { "2", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A5D2.CVOTHRX") } },
         { "9", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A5D2.CVOTHRX") } }
    };

    /****************** Question 3a ******************/
    public Dictionary<string, UIBehavior> CBSTROKEBehavior = new Dictionary<string, UIBehavior>
    {
         { "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A5D2.STROKMUL"),
                    new UIDisableAttribute("A5D2.STROKAGE"),
                    new UIDisableAttribute("A5D2.STROKSTAT"),
                    new UIDisableAttribute("A5D2.ANGIOCP"),
                    new UIDisableAttribute("A5D2.CAROTIDAGE"), //HACK Disable grandchild input
                }
            } },
         { "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("A5D2.STROKMUL"),
                    new UIEnableAttribute("A5D2.STROKAGE"),
                    new UIEnableAttribute("A5D2.STROKSTAT"),
                    new UIEnableAttribute("A5D2.ANGIOCP"),
                }
            } },
         { "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("A5D2.STROKMUL"),
                    new UIEnableAttribute("A5D2.STROKAGE"),
                    new UIEnableAttribute("A5D2.STROKSTAT"),
                    new UIEnableAttribute("A5D2.ANGIOCP"),
                }
            } },
         { "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIDisableAttribute("A5D2.STROKMUL"),
                    new UIDisableAttribute("A5D2.STROKAGE"),
                    new UIDisableAttribute("A5D2.STROKSTAT"),
                    new UIDisableAttribute("A5D2.ANGIOCP"),
                    new UIDisableAttribute("A5D2.CAROTIDAGE"), //HACK Disable grandchild input
                }
            } },
    };

    /****************** Question 3a4 ******************/
    public Dictionary<string, UIBehavior> ANGIOCPBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                 {
                         new UIDisableAttribute("A5D2.CAROTIDAGE"),
                 }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                 {
                         new UIEnableAttribute("A5D2.CAROTIDAGE"),

                 }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                 {
                         new UIDisableAttribute("A5D2.CAROTIDAGE"),

                 }
            }
         },
    };

    /****************** Question 3b ******************/
    public Dictionary<string, UIBehavior> CBTIABehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.TIAAGE"),
                     }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.TIAAGE"),
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.TIAAGE"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.TIAAGE"),
                     }
            }
         },
    };

    /****************** Question 4a ******************/
    public Dictionary<string, UIBehavior> PDbehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.PDAGE"),
                     }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.PDAGE"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.PDAGE"),
                     }
            }
         },
    };

    /****************** Question 3b ******************/
    public Dictionary<string, UIBehavior> PDOTHRBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.PDOTHRAGE"),
                     }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.PDOTHRAGE"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.PDOTHRAGE"),
                     }
            }
         },
    };

    /****************** Question 4c ******************/
    public Dictionary<string, UIBehavior> SEIZURESBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.SEIZNUM"),
                         new UIDisableAttribute("A5D2.SEIZAGE"),
                     }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.SEIZNUM"),
                         new UIEnableAttribute("A5D2.SEIZAGE"),
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.SEIZNUM"),
                         new UIEnableAttribute("A5D2.SEIZAGE"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.SEIZNUM"),
                         new UIDisableAttribute("A5D2.SEIZAGE"),
                     }
            }
         },
    };

    /****************** Question 4g ******************/
    public Dictionary<string, UIBehavior> HEADIMPCheckboxBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                        new UIDisableAttribute("A5D2.IMPAMFOOT"),
                        new UIDisableAttribute("A5D2.IMPSOCCER"),
                        new UIDisableAttribute("A5D2.IMPHOCKEY"),
                        new UIDisableAttribute("A5D2.IMPBOXING"),
                        new UIDisableAttribute("A5D2.IMPSPORT"),
                        new UIDisableAttribute("A5D2.IMPIPV"),
                        new UIDisableAttribute("A5D2.IMPMILIT"),
                        new UIDisableAttribute("A5D2.IMPASSAULT"),
                        new UIDisableAttribute("A5D2.IMPOTHER"),
                        new UIDisableAttribute("A5D2.IMPOTHERX"),
                        new UIDisableAttribute("A5D2.IMPYEARS"),
                     },
                 InstructionalMessage = "SKIP TO QUESTION 4h"
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                        new UIEnableAttribute("A5D2.IMPAMFOOT"),
                        new UIEnableAttribute("A5D2.IMPSOCCER"),
                        new UIEnableAttribute("A5D2.IMPHOCKEY"),
                        new UIEnableAttribute("A5D2.IMPBOXING"),
                        new UIEnableAttribute("A5D2.IMPSPORT"),
                        new UIEnableAttribute("A5D2.IMPIPV"),
                        new UIEnableAttribute("A5D2.IMPMILIT"),
                        new UIEnableAttribute("A5D2.IMPASSAULT"),
                        new UIEnableAttribute("A5D2.IMPOTHER"),
                        new UIEnableAttribute("A5D2.IMPYEARS")
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                        new UIDisableAttribute("A5D2.IMPAMFOOT"),
                        new UIDisableAttribute("A5D2.IMPSOCCER"),
                        new UIDisableAttribute("A5D2.IMPHOCKEY"),
                        new UIDisableAttribute("A5D2.IMPBOXING"),
                        new UIDisableAttribute("A5D2.IMPSPORT"),
                        new UIDisableAttribute("A5D2.IMPIPV"),
                        new UIDisableAttribute("A5D2.IMPMILIT"),
                        new UIDisableAttribute("A5D2.IMPASSAULT"),
                        new UIDisableAttribute("A5D2.IMPOTHER"),
                        new UIDisableAttribute("A5D2.IMPOTHERX"),
                        new UIDisableAttribute("A5D2.IMPYEARS"),
                     },
                 InstructionalMessage = "SKIP TO QUESTION 4h"
            }
         },
    };

    /****************** Question 4h ******************/
    public Dictionary<string, UIBehavior> HEADINJURYBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.HEADINJUNC"),
                         new UIDisableAttribute("A5D2.HEADINJCON"),
                         new UIDisableAttribute("A5D2.HEADINJNUM"),
                         new UIDisableAttribute("A5D2.FIRSTTBI"),
                         new UIDisableAttribute("A5D2.LASTTBI"),
                     },
                 InstructionalMessage = "SKIP TO QUESTION 5a"
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.HEADINJUNC"),
                         new UIEnableAttribute("A5D2.HEADINJCON"),
                         new UIEnableAttribute("A5D2.HEADINJNUM"),
                         new UIEnableAttribute("A5D2.FIRSTTBI"),
                         new UIEnableAttribute("A5D2.LASTTBI"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.HEADINJUNC"),
                         new UIDisableAttribute("A5D2.HEADINJCON"),
                         new UIDisableAttribute("A5D2.HEADINJNUM"),
                         new UIDisableAttribute("A5D2.FIRSTTBI"),
                         new UIDisableAttribute("A5D2.LASTTBI"),
                     },
                 InstructionalMessage = "SKIP TO QUESTION 5a"
            }
         },
    };

    /****************** Question 5a ******************/
    public Dictionary<string, UIBehavior> DIABETESBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.DIABTYPE"),
                         new UIDisableAttribute("A5D2.DIABINS"),
                         new UIDisableAttribute("A5D2.DIABMEDS"),
                         new UIDisableAttribute("A5D2.DIABGLP1"),
                         new UIDisableAttribute("A5D2.DIABRECACT"),
                         new UIDisableAttribute("A5D2.DIABDIET"),
                         new UIDisableAttribute("A5D2.DIABUNK"),
                         new UIDisableAttribute("A5D2.DIABAGE"),
                     },
                 InstructionalMessage = "SKIP TO QUESTION 5b"
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.DIABTYPE"),
                         new UIEnableAttribute("A5D2.DIABINS"),
                         new UIEnableAttribute("A5D2.DIABMEDS"),
                         new UIEnableAttribute("A5D2.DIABGLP1"),
                         new UIEnableAttribute("A5D2.DIABRECACT"),
                         new UIEnableAttribute("A5D2.DIABDIET"),
                         new UIEnableAttribute("A5D2.DIABUNK"),
                         new UIEnableAttribute("A5D2.DIABAGE"),
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.DIABTYPE"),
                         new UIEnableAttribute("A5D2.DIABINS"),
                         new UIEnableAttribute("A5D2.DIABMEDS"),
                         new UIEnableAttribute("A5D2.DIABGLP1"),
                         new UIEnableAttribute("A5D2.DIABRECACT"),
                         new UIEnableAttribute("A5D2.DIABDIET"),
                         new UIEnableAttribute("A5D2.DIABUNK"),
                         new UIEnableAttribute("A5D2.DIABAGE"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.DIABTYPE"),
                         new UIDisableAttribute("A5D2.DIABINS"),
                         new UIDisableAttribute("A5D2.DIABMEDS"),
                         new UIDisableAttribute("A5D2.DIABGLP1"),
                         new UIDisableAttribute("A5D2.DIABRECACT"),
                         new UIDisableAttribute("A5D2.DIABDIET"),
                         new UIDisableAttribute("A5D2.DIABUNK"),
                         new UIDisableAttribute("A5D2.DIABAGE"),
                     },
                 InstructionalMessage = "SKIP TO QUESTION 5b"
            }
         },
    };

    /****************** Question 5b ******************/
    public Dictionary<string, UIBehavior> HYPERTENBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.HYPERTAGE"),
                     }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.HYPERTAGE"),
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.HYPERTAGE"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.HYPERTAGE"),
                     }
            }
         },
    };

    /****************** Question 5c ******************/
    public Dictionary<string, UIBehavior> HYPERCHOBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.HYPERCHAGE"),
                     }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.HYPERCHAGE"),
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.HYPERCHAGE"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.HYPERCHAGE"),
                     }
            }
         },
    };

    /****************** Question 5f ******************/
    public Dictionary<string, UIBehavior> ARTHRITCheckboxBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                        new UIDisableAttribute("A5D2.ARTHRRHEUM"),
                        new UIDisableAttribute("A5D2.ARTHROSTEO"),
                        new UIDisableAttribute("A5D2.ARTHROTHR"),
                        new UIDisableAttribute("A5D2.ARTHTYPX"),
                        new UIDisableAttribute("A5D2.ARTHTYPUNK"),
                        new UIDisableAttribute("A5D2.ARTHUPEX"),
                        new UIDisableAttribute("A5D2.ARTHLOEX"),
                        new UIDisableAttribute("A5D2.ARTHSPIN"),
                        new UIDisableAttribute("A5D2.ARTHUNK"),
                     },
                 InstructionalMessage = "SKIP TO QUESTION 5g"
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                        new UIEnableAttribute("A5D2.ARTHRRHEUM"),
                        new UIEnableAttribute("A5D2.ARTHROSTEO"),
                        new UIEnableAttribute("A5D2.ARTHROTHR"),
                        new UIEnableAttribute("A5D2.ARTHTYPUNK"),
                        new UIEnableAttribute("A5D2.ARTHUPEX"),
                        new UIEnableAttribute("A5D2.ARTHLOEX"),
                        new UIEnableAttribute("A5D2.ARTHSPIN"),
                        new UIEnableAttribute("A5D2.ARTHUNK")
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                        new UIEnableAttribute("A5D2.ARTHRRHEUM"),
                        new UIEnableAttribute("A5D2.ARTHROSTEO"),
                        new UIEnableAttribute("A5D2.ARTHROTHR"),
                        new UIEnableAttribute("A5D2.ARTHTYPUNK"),
                        new UIEnableAttribute("A5D2.ARTHUPEX"),
                        new UIEnableAttribute("A5D2.ARTHLOEX"),
                        new UIEnableAttribute("A5D2.ARTHSPIN"),
                        new UIEnableAttribute("A5D2.ARTHUNK")
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                        new UIDisableAttribute("A5D2.ARTHRRHEUM"),
                        new UIDisableAttribute("A5D2.ARTHROSTEO"),
                        new UIDisableAttribute("A5D2.ARTHROTHR"),
                        new UIDisableAttribute("A5D2.ARTHTYPX"),
                        new UIDisableAttribute("A5D2.ARTHTYPUNK"),
                        new UIDisableAttribute("A5D2.ARTHUPEX"),
                        new UIDisableAttribute("A5D2.ARTHLOEX"),
                        new UIDisableAttribute("A5D2.ARTHSPIN"),
                        new UIDisableAttribute("A5D2.ARTHUNK"),
                     },
                 InstructionalMessage = "SKIP TO QUESTION 5g"
            }
         },
    };

    /****************** Question 5i ******************/
    public Dictionary<string, UIBehavior> APNEABehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.CPAP"),
                         new UIDisableAttribute("A5D2.APNEAORAL")
                     }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.CPAP"),
                         new UIEnableAttribute("A5D2.APNEAORAL")
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.CPAP"),
                         new UIEnableAttribute("A5D2.APNEAORAL")
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.CPAP"),
                         new UIDisableAttribute("A5D2.APNEAORAL")
                     }
            }
         },
    };

    /****************** Question 5l ******************/
    public Dictionary<string, UIBehavior> OTHSLEEPBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.OTHSLEEX"),
                     }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.OTHSLEEX"),
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.OTHSLEEX"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.OTHSLEEX"),
                     }
            }
         },
    };

    /****************** Question 5m ******************/
    public Dictionary<string, UIBehavior> CANCERACTVBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.CANCERPRIM"),
                         new UIDisableAttribute("A5D2.CANCERMETA"),
                         new UIDisableAttribute("A5D2.CANCMETBR"),
                         new UIDisableAttribute("A5D2.CANCMETOTH"),
                         new UIDisableAttribute("A5D2.CANCERUNK"),
                         new UIDisableAttribute("A5D2.CANCBLOOD"),
                         new UIDisableAttribute("A5D2.CANCBREAST"),
                         new UIDisableAttribute("A5D2.CANCCOLON"),
                         new UIDisableAttribute("A5D2.CANCLUNG"),
                         new UIDisableAttribute("A5D2.CANCPROST"),
                         new UIDisableAttribute("A5D2.CANCOTHER"),
                         new UIDisableAttribute("A5D2.CANCOTHERX"),
                         new UIDisableAttribute("A5D2.CANCRAD"),
                         new UIDisableAttribute("A5D2.CANCRESECT"),
                         new UIDisableAttribute("A5D2.CANCIMMUNO"),
                         new UIDisableAttribute("A5D2.CANCBONE"),
                         new UIDisableAttribute("A5D2.CANCCHEMO"),
                         new UIDisableAttribute("A5D2.CANCHORM"),
                         new UIDisableAttribute("A5D2.CANCTROTH"),
                         new UIDisableAttribute("A5D2.CANCTROTHX"),
                         new UIDisableAttribute("A5D2.CANCERAGE"),
                     },
                 InstructionalMessage = "SKIP TO QUESTION 5n"
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.CANCERPRIM"),
                         new UIEnableAttribute("A5D2.CANCERMETA"),
                         new UIEnableAttribute("A5D2.CANCERUNK"),
                         new UIEnableAttribute("A5D2.CANCBLOOD"),
                         new UIEnableAttribute("A5D2.CANCBREAST"),
                         new UIEnableAttribute("A5D2.CANCCOLON"),
                         new UIEnableAttribute("A5D2.CANCLUNG"),
                         new UIEnableAttribute("A5D2.CANCPROST"),
                         new UIEnableAttribute("A5D2.CANCOTHER"),
                         new UIEnableAttribute("A5D2.CANCRAD"),
                         new UIEnableAttribute("A5D2.CANCRESECT"),
                         new UIEnableAttribute("A5D2.CANCIMMUNO"),
                         new UIEnableAttribute("A5D2.CANCBONE"),
                         new UIEnableAttribute("A5D2.CANCCHEMO"),
                         new UIEnableAttribute("A5D2.CANCHORM"),
                         new UIEnableAttribute("A5D2.CANCTROTH"),
                         new UIEnableAttribute("A5D2.CANCERAGE")
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.CANCERPRIM"),
                         new UIEnableAttribute("A5D2.CANCERMETA"),
                         new UIEnableAttribute("A5D2.CANCERUNK"),
                         new UIEnableAttribute("A5D2.CANCBLOOD"),
                         new UIEnableAttribute("A5D2.CANCBREAST"),
                         new UIEnableAttribute("A5D2.CANCCOLON"),
                         new UIEnableAttribute("A5D2.CANCLUNG"),
                         new UIEnableAttribute("A5D2.CANCPROST"),
                         new UIEnableAttribute("A5D2.CANCOTHER"),
                         new UIEnableAttribute("A5D2.CANCRAD"),
                         new UIEnableAttribute("A5D2.CANCRESECT"),
                         new UIEnableAttribute("A5D2.CANCIMMUNO"),
                         new UIEnableAttribute("A5D2.CANCBONE"),
                         new UIEnableAttribute("A5D2.CANCCHEMO"),
                         new UIEnableAttribute("A5D2.CANCHORM"),
                         new UIEnableAttribute("A5D2.CANCTROTH"),
                         new UIEnableAttribute("A5D2.CANCERAGE")
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.CANCERPRIM"),
                         new UIDisableAttribute("A5D2.CANCERMETA"),
                         new UIDisableAttribute("A5D2.CANCMETBR"),
                         new UIDisableAttribute("A5D2.CANCMETOTH"),
                         new UIDisableAttribute("A5D2.CANCERUNK"),
                         new UIDisableAttribute("A5D2.CANCBLOOD"),
                         new UIDisableAttribute("A5D2.CANCBREAST"),
                         new UIDisableAttribute("A5D2.CANCCOLON"),
                         new UIDisableAttribute("A5D2.CANCLUNG"),
                         new UIDisableAttribute("A5D2.CANCPROST"),
                         new UIDisableAttribute("A5D2.CANCOTHER"),
                         new UIDisableAttribute("A5D2.CANCOTHERX"),
                         new UIDisableAttribute("A5D2.CANCRAD"),
                         new UIDisableAttribute("A5D2.CANCRESECT"),
                         new UIDisableAttribute("A5D2.CANCIMMUNO"),
                         new UIDisableAttribute("A5D2.CANCBONE"),
                         new UIDisableAttribute("A5D2.CANCCHEMO"),
                         new UIDisableAttribute("A5D2.CANCHORM"),
                         new UIDisableAttribute("A5D2.CANCTROTH"),
                         new UIDisableAttribute("A5D2.CANCTROTHX"),
                         new UIDisableAttribute("A5D2.CANCERAGE"),
                     },
                 InstructionalMessage = "SKIP TO QUESTION 5n"
            }
         },
    };

    /****************** Question 5n ******************/
    public Dictionary<string, UIBehavior> COVID19Behavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.COVIDHOSP"),
                     }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.COVIDHOSP"),
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.COVIDHOSP"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.COVIDHOSP"),
                     }
            }
         },
    };

    /****************** Question 5p ******************/
    public Dictionary<string, UIBehavior> KIDNEYBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.KIDNEYAGE"),
                     }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.KIDNEYAGE"),
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.KIDNEYAGE"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.KIDNEYAGE"),
                     }
            }
         },
    };

    /****************** Question 5q ******************/
    public Dictionary<string, UIBehavior> LIVERBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.LIVERAGE"),
                     }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.LIVERAGE"),
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.LIVERAGE"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.LIVERAGE"),
                     }
            }
         },
    };

    /****************** Question 5r ******************/
    public Dictionary<string, UIBehavior> PVDBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.PVDAGE"),
                     }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.PVDAGE"),
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.PVDAGE"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.PVDAGE"),
                     }
            }
         },
    };

    /****************** Question 5s ******************/
    public Dictionary<string, UIBehavior> HIVDIAGBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.HIVAGE"),
                     }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.HIVAGE"),
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.HIVAGE"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.HIVAGE"),
                     }
            }
         },
    };

    /****************** Question 5t ******************/
    public Dictionary<string, UIBehavior> OTHCONDBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.OTHCONDX"),
                     }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.OTHCONDX"),
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.OTHCONDX"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.OTHCONDX"),
                     }
            }
         },
    };

    /****************** Question 6d ******************/
    public Dictionary<string, UIBehavior> ANXIETYBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.GENERALANX"),
                         new UIDisableAttribute("A5D2.PANICDIS"),
                         new UIDisableAttribute("A5D2.OCD"),
                         new UIDisableAttribute("A5D2.OTHANXDIS"),
                         new UIDisableAttribute("A5D2.OTHANXDISX"),
                     },
                 InstructionalMessage = "SKIP TO QUESTION 6e"
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.GENERALANX"),
                         new UIEnableAttribute("A5D2.PANICDIS"),
                         new UIEnableAttribute("A5D2.OCD"),
                         new UIEnableAttribute("A5D2.OTHANXDIS"),
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.GENERALANX"),
                         new UIEnableAttribute("A5D2.PANICDIS"),
                         new UIEnableAttribute("A5D2.OCD"),
                         new UIEnableAttribute("A5D2.OTHANXDIS"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.GENERALANX"),
                         new UIDisableAttribute("A5D2.PANICDIS"),
                         new UIDisableAttribute("A5D2.OCD"),
                         new UIDisableAttribute("A5D2.OTHANXDIS"),
                         new UIDisableAttribute("A5D2.OTHANXDISX"),
                     },
                 InstructionalMessage = "SKIP TO QUESTION 6e"
            }
         },
    };

    /****************** Question 6d4 ******************/
    public Dictionary<string, UIBehavior> OTHANXDISBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.OTHANXDISX"),
                     }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.OTHANXDISX"),
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.OTHANXDISX"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.OTHANXDISX"),
                     }
            }
         },
    };

    /****************** Question 6g ******************/
    public Dictionary<string, UIBehavior> PSYCDISBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.PSYCDISX"),
                     }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.PSYCDISX"),
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.PSYCDISX"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.PSYCDISX"),
                     }
            }
         },
    };

    /****************** Question 7b ******************/
    /****************** NOMENSAGE chekcboxes controlled in A5D2.js ******************/
    public UIRangeToggle MENARCHEBehavior = new UIRangeToggle
    {
        Low = 5,
        High = 999,
        UIBehavior = new UIBehavior
        {
            PropertyAttributes = new List<UIPropertyAttributes>
                {
                    new UIEnableAttribute("A5D2.HRT"),
                    new UIEnableAttribute("A5D2.BCPILLS"),
                },
        }
    };

    /****************** Question 7d ******************/
    public Dictionary<string, UIBehavior> HRTBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.HRTYEARS"),
                         new UIDisableAttribute("A5D2.HRTSTRTAGE"),
                         new UIDisableAttribute("A5D2.HRTENDAGE"),
                     }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.HRTYEARS"),
                         new UIEnableAttribute("A5D2.HRTSTRTAGE"),
                         new UIEnableAttribute("A5D2.HRTENDAGE"),
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.HRTYEARS"),
                         new UIEnableAttribute("A5D2.HRTSTRTAGE"),
                         new UIEnableAttribute("A5D2.HRTENDAGE"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.HRTYEARS"),
                         new UIDisableAttribute("A5D2.HRTSTRTAGE"),
                         new UIDisableAttribute("A5D2.HRTENDAGE"),
                     }
            }
         },
    };

    /****************** Question 7e ******************/
    public Dictionary<string, UIBehavior> BCPILLSBehavior = new Dictionary<string, UIBehavior>
    {
         {
            "0", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.BCPILLSYR"),
                         new UIDisableAttribute("A5D2.BCSTARTAGE"),
                         new UIDisableAttribute("A5D2.BCENDAGE"),
                     }
            }
         },
         {
            "1", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.BCPILLSYR"),
                         new UIEnableAttribute("A5D2.BCSTARTAGE"),
                         new UIEnableAttribute("A5D2.BCENDAGE"),
                     }
            }
         },
         {
            "2", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIEnableAttribute("A5D2.BCPILLSYR"),
                         new UIEnableAttribute("A5D2.BCSTARTAGE"),
                         new UIEnableAttribute("A5D2.BCENDAGE"),
                     }
            }
         },
         {
            "9", new UIBehavior
            {
                 PropertyAttributes = new List<UIPropertyAttributes>
                     {
                         new UIDisableAttribute("A5D2.BCPILLSYR"),
                         new UIDisableAttribute("A5D2.BCSTARTAGE"),
                         new UIDisableAttribute("A5D2.BCENDAGE"),
                     }
            }
         },
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
    public async Task<IActionResult> OnPostAsync(int id, string? goNext = null)
    {
        BaseForm = A5D2; // reassign bounded and derived form to base form for base method

        Visit.Forms.Add(A5D2); // visit needs updated form as well

        return await base.OnPostAsync(id, goNext); // checks for validation, etc.
    }
}
