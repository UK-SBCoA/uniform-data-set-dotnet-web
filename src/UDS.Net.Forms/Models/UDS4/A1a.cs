using System.ComponentModel.DataAnnotations;

namespace UDS.Net.Forms.Models.UDS4
{
    public class A1a : FormModel
    {

        [Display(Name = "Do you or someone in your household currently own a car?")]
        [Range(0, 8)]
        public int? OWNSCAR { get; set; }

        [Display(Name = "Do you have consistent access to transportation?")]
        [Range(0, 8)]
        public int? TRSPACCESS { get; set; }

        [Display(Name = "In the past 30 days, how often were you not able to leave the house when you wanted to because of a problem with transportation?")]
        [Range(1, 8)]
        public int? TRANSPROB { get; set; }

        [Display(Name = "In the past 30 days, how often did you worry about whether or not you would be able to get somewhere because of a problem with transportation?")]
        [Range(1, 8)]
        public int? TRANSWORRY { get; set; }

        [Display(Name = "In the past 30 days, how often did it take you longer to get somewhere than it would have taken you if you had different transportation?")]
        [Range(1, 8)]
        public int? TRSPLONGER { get; set; }

        [Display(Name = "In the past 30 days, how often has a lack of transportation kept you from medical appointments or from doing things needed for daily living?")]
        [Range(1, 8)]
        public int? TRSPMED { get; set; }

        [Display(Name = "Which of these income groups represents your household income for the past year? Include income from all sources such as wages, salaries, social security or retirement benefits, help from relatives, rent from property, and so forth.")]
        [Range(1, 9)]
        public int? INCOMEYR { get; set; }

        [Display(Name = "How satisfied are you with your current personal financial condition?")]
        [Range(1, 8)]
        public int? FINSATIS { get; set; }

        [Display(Name = "How difficult is it for you to meet monthly payments on your bills?")]
        [Range(1, 8)]
        public int? BILLPAY { get; set; }

        [Display(Name = "If you have had financial problems that lasted twelve months or longer, how upsetting has it been to you?")]
        [Range(1, 8)]
        public int? FINUPSET { get; set; }

        [Display(Name = "At any time, did you ever eat less than you felt you should because there wasn't enough money to buy food?")]
        [Range(0, 8)]
        public int? EATLESS { get; set; }

        [Display(Name = "In the last 12 months, did you ever eat less than you felt you should because there wasn't enough money to buy food?")]
        [Range(0, 8)]
        public int? EATLESSYR { get; set; }

        [Display(Name = "At any time, have you ended up taking less medication than was prescribed for you because of the cost?")]
        [Range(0, 8)]
        public int? LESSMEDS { get; set; }

        [Display(Name = "In the last 12 months, have you ended up taking less medication than was prescribed for you because of the cost?")]
        [Range(0, 8)]
        public int? LESSMEDSYR { get; set; }

        [Display(Name = "Where would you place yourself on this ladder compared to others in your community (or neighborhood)? Please mark the number where you would place yourself.")]
        [Range(0, 10)]
        public int? COMPCOMM { get; set; }

        [Display(Name = "Where would you place yourself on this ladder compared to others in the U.S.?")]
        [Range(0, 10)]
        public int? COMPUSA { get; set; }

        [Display(Name = "Thinking of your childhood, where would your family have been placed on this ladder compared to others in your community (or neighborhood)?")]
        [Range(0, 10)]
        public int? FAMCOMP { get; set; }

        [Display(Name = "Thinking of the person who raised you, what was their highest level of education completed?")]
        [Range(1, 9)]
        public int? GUARDEDU { get; set; }

        [Display(Name = "What was this person's relationship to you?")]
        [Range(1, 8)]
        public int? GUARDREL { get; set; }

        [Display(Name = "Specify other relationship")]
        [MaxLength(60)]
        public string? GUARDRELX { get; set; }

        [Display(Name = "If there was a second person who raised you (e.g., your mother, father, grandmother, etc.?), what was that person's highest level of education completed?")]
        [Range(1, 9)]
        public int? GUARD2EDU { get; set; }

        [Display(Name = "What was this second person's relationship to you (if applicable)?")]
        [Range(1, 8)]
        public int? GUARD2REL { get; set; }

        [Display(Name = "Specify other relationship")]
        [MaxLength(60)]
        public string? GUARD2RELX { get; set; }

        [Display(Name = "I experience a general sense of emptiness")]
        [Range(1, 8)]
        public int? EMPTINESS { get; set; }

        [Display(Name = "I miss having people around")]
        [Range(1, 8)]
        public int? MISSPEOPLE { get; set; }

        [Display(Name = "I feel like I don't have enough friends")]
        [Range(1, 8)]
        public int? FRIENDS { get; set; }

        [Display(Name = "I often feel abandoned")]
        [Range(1, 8)]
        public int? ABANDONED { get; set; }

        [Display(Name = "I miss having a really good friend")]
        [Range(1, 8)]
        public int? CLOSEFRND { get; set; }

        [Display(Name = "If your parents are still alive, how often do you have contact with them (including mother, father, mother-in-law, and father-in-law) either in person, by phone, mail, or email (e.g., any online interaction)?")]
        [Range(0, 8)]
        public int? PARENTCOMM { get; set; }

        [Display(Name = "If you have children, how often do you have contact with your children (including child[ren]-in-law and stepchild[ren]) either in person, by phone, mail, or email (e.g., any online interaction)?")]
        [Range(0, 8)]
        public int? CHILDCOMM { get; set; }

        [Display(Name = "How often do you have contact with close friends either in person, by phone, mail, or email (e.g., any online interaction)?")]
        [Range(0, 8)]
        public int? FRIENDCOMM { get; set; }

        [Display(Name = "How often do you participate in activities outside the home (e.g., religious activities, educational activities, volunteer work, paid work, or activities with groups or organizations)?")]
        [Range(0, 8)]
        public int? PARTICIPATE { get; set; }

        [Display(Name = "How safe do you feel in your home?")]
        [Range(1, 8)]
        public int? SAFEHOME { get; set; }

        [Display(Name = "How safe do you feel in your community (or neighborhood)?")]
        [Range(1, 8)]
        public int? SAFECOMM { get; set; }

        [Display(Name = "In the past year, how often did you delay seeking medical attention for a problem that was bothering you?")]
        [Range(1, 8)]
        public int? DELAYMED { get; set; }

        [Display(Name = "In the past year, how often did you experience challenges in filling a prescription?")]
        [Range(1, 8)]
        public int? SCRIPTPROB { get; set; }

        [Display(Name = "In the past year, how often did you miss a follow-up medical appointment that was scheduled?")]
        [Range(1, 8)]
        public int? MISSEDFUP { get; set; }

        [Display(Name = "In the past year, how often did you follow a doctor's advice or treatment plan when it was given?")]
        [Range(1, 8)]
        public int? DOCADVICE { get; set; }

        [Display(Name = "Overall, which of these describes your health insurance, access to healthcare services, and access to medications?")]
        [Range(1, 8)]
        public int? HEALTHACC { get; set; }

        [Display(Name = "In your day-to-day life how often are you treated with less courtesy or respect than other people?")]
        [Range(1, 8)]
        public int? LESSCOURT { get; set; }

        [Display(Name = "In your day-to-day life how often do you receive poorer service than other people at restaurants or stores?")]
        [Range(1, 8)]
        public int? POORSERV { get; set; }

        [Display(Name = "In your day-to-day life how often do people act as if they think you are not smart?")]
        [Range(1, 8)]
        public int? NOTSMART { get; set; }

        [Display(Name = "In your day-to-day life how often do people act as if they are afraid of you?")]
        [Range(1, 8)]
        public int? ACTAFRAID { get; set; }

        [Display(Name = "In your day-to-day life how often are you threatened or harassed?")]
        [Range(1, 8)]
        public int? THREATENED { get; set; }

        [Display(Name = "How frequently did you receive poorer service or treatment from doctors or in hospitals compared to other people?")]
        [Range(1, 8)]
        public int? POORMEDTRT { get; set; }

        [Display(Name = "Your Ancestry or National Origins")]
        public bool EXPANCEST { get; set; }

        [Display(Name = "Your gender")]
        public bool EXPGENDER { get; set; }

        [Display(Name = "Your race")]
        public bool EXPRACE { get; set; }

        [Display(Name = "Your age")]
        public bool EXPAGE { get; set; }

        [Display(Name = "Your religion")]
        public bool EXPRELIG { get; set; }

        [Display(Name = "Your height")]
        public bool EXPHEIGHT { get; set; }

        [Display(Name = "Your weight")]
        public bool EXPWEIGHT { get; set; }

        [Display(Name = "Some other aspect of your physical appearance")]
        public bool EXPAPPEAR { get; set; }

        [Display(Name = "Your sexual orientation")]
        public bool EXPSEXORN { get; set; }

        [Display(Name = "Your education or income level")]
        public bool EXPEDUCINC { get; set; }

        [Display(Name = "A physical disability")]
        public bool EXPDISAB { get; set; }

        [Display(Name = "Your shade of skin color")]
        public bool EXPSKIN { get; set; }

        [Display(Name = "Other")]
        public bool EXPOTHER { get; set; }

        [Display(Name = "Not applicable - I do not have these experiences in my day-to-day life (END FORM HERE)")]
        public bool EXPNOTAPP { get; set; }

        [Display(Name = "Prefer not to answer")]
        public bool EXPNOANS { get; set; }

        [Display(Name = "When you have had day-to-day experiences like those in questions 33 to 38, would you say they have been very stressful, moderately stressful, or not stressful?")]
        public int? EXPSTRS { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            foreach (var result in base.Validate(validationContext))
            {
                yield return result;
            }

            yield break;
        }
    }
}

