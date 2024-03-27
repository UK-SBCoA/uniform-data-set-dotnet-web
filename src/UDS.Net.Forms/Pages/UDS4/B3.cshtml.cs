using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS4
{
    public class B3Model : FormPageModel
    {
        [BindProperty]
        public B3 B3 { get; set; } = default!;

        public List<RadioListItem> SpeechListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal", "0"),
            new RadioListItem("Slight loss of expression, diction and/or volume", "1"),
            new RadioListItem("Monotone, slurred but understandable; moderately impaired", "2"),
            new RadioListItem("Marked impairment, difficult to understand", "3"),
            new RadioListItem("Unintelligible", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public Dictionary<string, UIBehavior> SpeechUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.SPEECHX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.SPEECHX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.SPEECHX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.SPEECHX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.SPEECHX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.SPEECHX") } },
        };

        public List<RadioListItem> FACEXPListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal", "0"),
            new RadioListItem("Minimal hypomimia, could be normal “poker face”", "1"),
            new RadioListItem("Slight but definitely abnormal diminution of facial expression", "2"),
            new RadioListItem("Moderate hypomimia; lips parted some of the time", "3"),
            new RadioListItem("Masked or fixed facies with severe or complete loss of facial expression; lips parted ¼ inches or more", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public Dictionary<string, UIBehavior> FACEXPUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.FACEXPX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.FACEXPX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.FACEXPX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.FACEXPX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.FACEXPX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.FACEXPX") } },
        };

        public List<RadioListItem> TremorListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Absent", "0"),
            new RadioListItem("Slight and infrequently present", "1"),
            new RadioListItem("Mild in amplitude and persistent; or moderate in amplitude, but only intermittently present", "2"),
            new RadioListItem("Moderate in amplitude and present most of the time", "3"),
            new RadioListItem("Marked in amplitude and present most of the time", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public Dictionary<string, UIBehavior> TRESTFACUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTFAX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTFAX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTFAX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTFAX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTFAX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.TRESTFAX") } },
        };

        public Dictionary<string, UIBehavior> TRESTRHDUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTRHX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTRHX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTRHX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTRHX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTRHX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.TRESTRHX") } },
        };

        public Dictionary<string, UIBehavior> TRESTLHDUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTLHX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTLHX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTLHX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTLHX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTLHX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.TRESTLHX") } },
        };

        public Dictionary<string, UIBehavior> TRESTRFTUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTRFX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTRFX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTRFX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTRFX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTRFX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.TRESTRFX") } },
        };

        public Dictionary<string, UIBehavior> TRESTLFTUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTLFX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTLFX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTLFX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTLFX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRESTLFX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.TRESTLFX") } },
        };

        public List<RadioListItem> HandListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Absent", "0"),
            new RadioListItem("Slight; present with action", "1"),
            new RadioListItem("Moderate in amplitude, present with action", "2"),
            new RadioListItem("Moderate in amplitude with posture holding as well as action", "3"),
            new RadioListItem("Marked in amplitude; interferes with feeding", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public Dictionary<string, UIBehavior> TRACTRHDUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRACTRHX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRACTRHX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRACTRHX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRACTRHX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRACTRHX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.TRACTRHX") } },
        };

        public Dictionary<string, UIBehavior> TRACTLHDUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRACTLHX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRACTLHX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRACTLHX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRACTLHX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TRACTLHX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.TRACTLHX") } },
        };

        public List<RadioListItem> RigidityListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Absent", "0"),
            new RadioListItem("Slight or detectable only when activated by mirror or other movements", "1"),
            new RadioListItem("Mild to moderate", "2"),
            new RadioListItem("Marked, but full range of motion easily achieved", "3"),
            new RadioListItem("Severe; range of motion achieved with difficulty", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public Dictionary<string, UIBehavior> RIGDNECKUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDNEX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDNEX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDNEX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDNEX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDNEX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.RIGDNEX") } },
        };

        public Dictionary<string, UIBehavior> RIGDUPRTUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDUPRX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDUPRX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDUPRX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDUPRX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDUPRX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.RIGDUPRX") } },
        };

        public Dictionary<string, UIBehavior> RIGDUPLFUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDUPLX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDUPLX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDUPLX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDUPLX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDUPLX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.RIGDUPLX") } },
        };

        public Dictionary<string, UIBehavior> RIGDLORTUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDLORX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDLORX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDLORX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDLORX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDLORX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.RIGDLORX") } },
        };

        public Dictionary<string, UIBehavior> RIGDLOLFUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDLOLX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDLOLX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDLOLX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDLOLX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.RIGDLOLX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.RIGDLOLX") } },
        };

        public List<RadioListItem> FingerListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal ", "0"),
            new RadioListItem("Mild slowing and/or reduction in amplitude", "1"),
            new RadioListItem("Moderately impaired; definite and early fatiguing; may have occasional arrests in movement", "2"),
            new RadioListItem("Severely impaired; frequent hesitation in initiating movements or arrests in ongoing movement", "3"),
            new RadioListItem("Can barely perform the task.", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public Dictionary<string, UIBehavior> TAPSRTUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TAPSRTX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TAPSRTX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TAPSRTX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TAPSRTX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TAPSRTX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.TAPSRTX") } },
        };

        public Dictionary<string, UIBehavior> TAPSLFUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TAPSLFX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TAPSLFX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TAPSLFX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TAPSLFX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.TAPSLFX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.TAPSLFX") } },
        };

        public List<RadioListItem> HandMovementsListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal ", "0"),
            new RadioListItem("Mild slowing and/or reduction in amplitude", "1"),
            new RadioListItem("Moderately impaired; definite and early fatiguing; may have occasional arrests in movement", "2"),
            new RadioListItem("Severely impaired; frequent hesitation in initiating movements or arrests in ongoing movement", "3"),
            new RadioListItem("Can barely perform the task.", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public Dictionary<string, UIBehavior> HANDMOVRUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDMVRX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDMVRX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDMVRX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDMVRX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDMVRX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.HANDMVRX") } },
        };

        public Dictionary<string, UIBehavior> HANDMOVLUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDMVLX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDMVLX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDMVLX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDMVLX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDMVLX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.HANDMVLX") } },
        };

        public List<RadioListItem> RapidHandsListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal ", "0"),
            new RadioListItem("Mild slowing and/or reduction in amplitude", "1"),
            new RadioListItem("Moderately impaired; definite and early fatiguing; may have occasional arrests in movement", "2"),
            new RadioListItem("Severely impaired; frequent hesitation in initiating movements or arrests in ongoing movement", "3"),
            new RadioListItem("Can barely perform the task.", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public Dictionary<string, UIBehavior> HANDALTRUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDATRX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDATRX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDATRX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDATRX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDATRX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.HANDATRX") } },
        };

        public Dictionary<string, UIBehavior> HANDALTLUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDATLX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDATLX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDATLX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDATLX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.HANDATLX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.HANDATLX") } },
        };

        public List<RadioListItem> LegListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal ", "0"),
            new RadioListItem("Mild slowing and/or reduction in amplitude", "1"),
            new RadioListItem("Moderately impaired; definite and early fatiguing; may have occasional arrests in movement", "2"),
            new RadioListItem("Severely impaired; frequent hesitation in initiating movements or arrests in ongoing movement", "3"),
            new RadioListItem("Can barely perform the task.", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public Dictionary<string, UIBehavior> LEGRTUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.LEGRTX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.LEGRTX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.LEGRTX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.LEGRTX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.LEGRTX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.LEGRTX") } },
        };

        public Dictionary<string, UIBehavior> LEGLFUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.LEGLFX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.LEGLFX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.LEGLFX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.LEGLFX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.LEGLFX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.LEGLFX") } },
        };

        public List<RadioListItem> ArisingListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal ", "0"),
            new RadioListItem("Slow; or may need more than one attempt", "1"),
            new RadioListItem("Pushes self up from arms of seat.", "2"),
            new RadioListItem(" Tends to fall back and may have to try more than one time, but can get up without help", "3"),
            new RadioListItem("Unable to arise without help.", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public Dictionary<string, UIBehavior> ARISINGUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.ARISINGX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.ARISINGX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.ARISINGX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.ARISINGX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.ARISINGX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.ARISINGX") } },
        };

        public List<RadioListItem> PostureListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal ", "0"),
            new RadioListItem("Not quite erect, slightly stooped posture; could be normal for older person", "1"),
            new RadioListItem("Moderately stooped posture, definitely abnormal; can be slightly leaning to one side", "2"),
            new RadioListItem("Severely stooped posture with kyphosis; can be moderately leaning to one side", "3"),
            new RadioListItem("Marked flexion with extreme abnormality of posture", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public Dictionary<string, UIBehavior> POSTUREUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.POSTUREX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.POSTUREX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.POSTUREX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.POSTUREX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.POSTUREX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.POSTUREX") } },
        };

        public List<RadioListItem> GaitListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal ", "0"),
            new RadioListItem("Walks slowly; may shuffle with short steps, but no festination (hastening steps) or propulsion", "1"),
            new RadioListItem("Walks with difficulty, but requires little or no assistance; may have some festination, short steps, nor propulsion", "2"),
            new RadioListItem("Severe disturbance of gait requiring assistance", "3"),
            new RadioListItem("Cannot walk at all, even with assistance", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public Dictionary<string, UIBehavior> GAITUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.GAITX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.GAITX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.GAITX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.GAITX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.GAITX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.GAITX") } },
        };

        public List<RadioListItem> PostureStabilityListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("Normal erect", "0"),
            new RadioListItem("Retropulsion, but recovers unaided", "1"),
            new RadioListItem("Absence of postural response; would fall if not caught by examiner", "2"),
            new RadioListItem("Very unstable, tends to lose balance spontaneously", "3"),
            new RadioListItem("Unable to stand without assistance", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public Dictionary<string, UIBehavior> POSSTABUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.POSSTABX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.POSSTABX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.POSSTABX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.POSSTABX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.POSSTABX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.POSSTABX") } },
        };


        public List<RadioListItem> BodyListItems { get; set; } = new List<RadioListItem>
        {
            new RadioListItem("None", "0"),
            new RadioListItem("Minimal slowness, giving movement a deliberate character; could be normal for some persons; possibly reduced amplitude", "1"),
            new RadioListItem("Mild degree of slowness and poverty of movement which is definitely abnormal; alternatively, some reduced amplitude", "2"),
            new RadioListItem("Moderate slowness, poverty or small amplitude of movement", "3"),
            new RadioListItem("Marked slowness, poverty or small amplitude of movement", "4"),
            new RadioListItem("Untestable (SPECIFY)", "8"),
        };

        public Dictionary<string, UIBehavior> BRADYKINUIBehavior = new Dictionary<string, UIBehavior>
        {
            { "0", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.BRADYKIX") } },
            { "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.BRADYKIX") } },
            { "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.BRADYKIX") } },
            { "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.BRADYKIX") } },
            { "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("B3.BRADYKIX") } },
            { "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("B3.BRADYKIX") } },
        };

        public B3Model(IVisitService visitService) : base(visitService, "B3")
        {
        }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            await base.OnGetAsync(id);

            if (BaseForm != null)
            {
                B3 = (B3)BaseForm; // class library should always handle new instances
            }

            return Page();
        }

        [ValidateAntiForgeryToken]
        public new async Task<IActionResult> OnPostAsync(int id)
        {
            BaseForm = B3;

            Visit.Forms.Add(B3);

            return await base.OnPostAsync(id); // checks for domain-level business rules validation
        }

    }
}
