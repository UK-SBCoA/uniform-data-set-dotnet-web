using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UDS.Net.Forms.Models.PageModels;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services;

namespace UDS.Net.Forms.Pages.UDS4
{
    public class A1aModel : FormPageModel
    {
        [BindProperty]
        public A1a A1a { get; set; } = default!;

        public A1aModel(IVisitService visitService) : base(visitService, "A1a")
        {
        }

        public List<RadioListItem> NoToYesItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No", "0"),
            new RadioListItem("Yes", "1"),
            new RadioListItem("Prefer not to answer", "8")
        };

        public List<RadioListItem> OftenToNeverItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Often", "1"),
            new RadioListItem("Sometimes", "2"),
            new RadioListItem("Never", "3"),
            new RadioListItem("Prefer not to answer", "8")
        };

        public List<RadioListItem> INCOMEYRItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("$0 - $14,999", "1"),
            new RadioListItem("$15,000 - $29,999", "2"),
            new RadioListItem("$30,000 - $74,999", "3"),
            new RadioListItem("$75,000 and over", "4"),
            new RadioListItem("Prefer not to answer", "8"),
            new RadioListItem("Don't know", "9")
        };

        public List<RadioListItem> FINSATISItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Completely satisfied", "1"),
            new RadioListItem("Satisfied", "2"),
            new RadioListItem("Somewhat satisfied", "3"),
            new RadioListItem("Not very satisfied", "4"),
            new RadioListItem("Not at all satisfied", "5"),
            new RadioListItem("Prefer not to answer", "8")
        };

        public List<RadioListItem> BILLPAYItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Not at all", "1"),
            new RadioListItem("Slightly", "2"),
            new RadioListItem("Moderately", "3"),
            new RadioListItem("Very", "4"),
            new RadioListItem("Extremely", "5"),
            new RadioListItem("Prefer not to answer", "8")
        };

        public List<RadioListItem> FINUPSETItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("No financial problems for twelve months or longer", "1"),
            new RadioListItem("Yes, financial problems for twelve months or longer, but not upsetting to me", "2"),
            new RadioListItem("Yes, financial problems for twelve months or longer, and somewhat upsetting to me", "3"),
            new RadioListItem("Yes, financial problems for twelve months or longer, and very upsetting to me", "4"),
            new RadioListItem("Prefer not to answer", "8")
        };

        public List<RadioListItem> LadderItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("10", "10"),
            new RadioListItem("9", "9"),
            new RadioListItem("8", "8"),
            new RadioListItem("7", "7"),
            new RadioListItem("6", "6"),
            new RadioListItem("5", "5"),
            new RadioListItem("4", "4"),
            new RadioListItem("3", "3"),
            new RadioListItem("2", "2"),
            new RadioListItem("1", "1"),
        };

        public List<RadioListItem> GUARDEDUItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Never attended school or only attended kindergarten", "1"),
            new RadioListItem("Grades 1 through 8 (elementary)", "2"),
            new RadioListItem("Grades 9 through 11 (some high school)", "3"),
            new RadioListItem("Grade 12 or GED (high school graduate)", "4"),
            new RadioListItem("College 1 year to 3 years (some college)", "5"),
            new RadioListItem("College 4 years or more (college graduate)", "6"),
            new RadioListItem("Do not know", "9")
        };

        public List<RadioListItem> RelationshipItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Parent (biological, adoptive, foster, or step)", "1"),
            new RadioListItem("Grandparent", "2"),
            new RadioListItem("Sibling", "3"),
            new RadioListItem("Aunt or Uncle", "4"),
            new RadioListItem("Other relative", "5"),
            new RadioListItem("Legal guardian", "6"),
            new RadioListItem("Other (SPECIFY)", "8")
        };

        public Dictionary<string, UIBehavior> GUARDRELBehavior = new Dictionary<string, UIBehavior>
        {
			{ "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1a.GUARDRELX") } },
			{ "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1a.GUARDRELX") } },
			{ "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1a.GUARDRELX") } },
			{ "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1a.GUARDRELX") } },
			{ "5", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1a.GUARDRELX") } },
			{ "6", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1a.GUARDRELX") } },
			{ "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A1a.GUARDRELX") } }
		};

		public List<RadioListItem> GUARD2EDUItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Never attended school or only attended kindergarten", "1"),
            new RadioListItem("Grades 1 through 8 (elementary)", "2"),
            new RadioListItem("Grades 9 through 11 (some high school)", "3"),
            new RadioListItem("Grade 12 or GED (high school graduate)", "4"),
            new RadioListItem("College 1 year to 3 years (some college)", "5"),
            new RadioListItem("College 4 years or more (college graduate)", "6"),
            new RadioListItem("No second person (SKIP TO QUESTION 18)", "8"),
            new RadioListItem("Do not know", "9")
        };

		public Dictionary<string, UIBehavior> GUARD2EDUBehavior = new Dictionary<string, UIBehavior>
		{
			{ "8", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1a.GUARD2REL") } }
		};

		public Dictionary<string, UIBehavior> GUARD2RELBehavior = new Dictionary<string, UIBehavior>
		{
			{ "1", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1a.GUARD2RELX") } },
			{ "2", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1a.GUARD2RELX") } },
			{ "3", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1a.GUARD2RELX") } },
			{ "4", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1a.GUARD2RELX") } },
			{ "5", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1a.GUARD2RELX") } },
			{ "6", new UIBehavior { PropertyAttribute = new UIDisableAttribute("A1a.GUARD2RELX") } },
			{ "8", new UIBehavior { PropertyAttribute = new UIEnableAttribute("A1a.GUARD2RELX") } }
		};

		public List<RadioListItem> DisagreeToAgreeItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Strongly disagree", "1"),
            new RadioListItem("Disagree", "2"),
            new RadioListItem("Neither disagree or agree", "3"),
            new RadioListItem("Agree", "4"),
            new RadioListItem("Strongly agree", "5"),
            new RadioListItem("Prefer not to answer", "8")
        };

        public List<RadioListItem> SpendTimeParentsItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Parents not living", "0"),
            new RadioListItem("Once a year or less", "1"),
            new RadioListItem("Several times a year", "2"),
            new RadioListItem("Several times a month", "3"),
            new RadioListItem("Several times a week", "4"),
            new RadioListItem("Everyday or almost everyday", "5"),
            new RadioListItem("Prefer not to answer", "8")
        };

        public List<RadioListItem> SpendTimeChildrenItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Do not have children", "0"),
            new RadioListItem("Once a year or less", "1"),
            new RadioListItem("Several times a year", "2"),
            new RadioListItem("Several times a month", "3"),
            new RadioListItem("Several times a week", "4"),
            new RadioListItem("Everyday or almost everyday", "5"),
            new RadioListItem("Prefer not to answer", "8")
        };

        public List<RadioListItem> SpendTimeFriendsItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Do not have close friends", "0"),
            new RadioListItem("Once a year or less", "1"),
            new RadioListItem("Several times a year", "2"),
            new RadioListItem("Several times a month", "3"),
            new RadioListItem("Several times a week", "4"),
            new RadioListItem("Everyday or almost everyday", "5"),
            new RadioListItem("Prefer not to answer", "8")
        };

        public List<RadioListItem> SpendTimeActivitiesItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Do not participate in activities outside the home", "0"),
            new RadioListItem("Once a year or less", "1"),
            new RadioListItem("Several times a year", "2"),
            new RadioListItem("Several times a month", "3"),
            new RadioListItem("Several times a week", "4"),
            new RadioListItem("Everyday or almost everyday", "5"),
            new RadioListItem("Prefer not to answer", "8")
        };

        public List<RadioListItem> SafeToUnsafeItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Very safe", "1"),
            new RadioListItem("Mostly safe", "2"),
            new RadioListItem("Unsafe at times", "3"),
            new RadioListItem("Very unsafe", "4"),
            new RadioListItem("Prefer not to answer", "8")
        };

        public List<RadioListItem> AllTheTimeToNoneOfTheTime { get; } = new List<RadioListItem>
        {
            new RadioListItem("All of the time", "1"),
            new RadioListItem("Most of the time", "2"),
            new RadioListItem("Sometimes", "3"),
            new RadioListItem("None or almost none of the time", "4"),
            new RadioListItem("Not applicable", "5"),
            new RadioListItem("Prefer not to answer", "8")
        };

        public List<RadioListItem> HEALTHACCItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Not available to any extent", "1"),
            new RadioListItem("Below the level of my needs", "2"),
            new RadioListItem("Able to meet my needs", "3"),
            new RadioListItem("Exceeds my needs", "4"),
            new RadioListItem("Prefer not to answer", "8")
        };

        public List<RadioListItem> EverydayToNeverItems { get; } = new List<RadioListItem>
        {
            new RadioListItem("Almost every day", "1"),
            new RadioListItem("At least once a week", "2"),
            new RadioListItem("A few times a month", "3"),
            new RadioListItem("A few times a year", "4"),
            new RadioListItem("Less than once a year", "5"),
            new RadioListItem("Never", "6"),
            new RadioListItem("Prefer not to answer", "8")
        };
    }
}
