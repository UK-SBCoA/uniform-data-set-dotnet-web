﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models.UDS4
{
    public class A1a : FormModel
    {
        [Display(Name = "Do you or someone in your household currently own a car?")]
        [RegularExpression("^(0|1|8)$", ErrorMessage = "Valid range is 0-1 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? OWNSCAR { get; set; }

        [Display(Name = "Do you have consistent access to transportation?")]
        [RegularExpression("^(0|1|8)$", ErrorMessage = "Valid range is 0-1 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? TRSPACCESS { get; set; }

        [Display(Name = "In the past 30 days, how often were you not able to leave the house when you wanted to because of a problem with transportation?")]
        [RegularExpression("^([1-3]|8)$", ErrorMessage = "Valid range is 1-3 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? TRANSPROB { get; set; }

        [Display(Name = "In the past 30 days, how often did you worry about whether or not you would be able to get somewhere because of a problem with transportation?")]
        [RegularExpression("^([1-3]|8)$", ErrorMessage = "Valid range is 1-3 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? TRANSWORRY { get; set; }

        [Display(Name = "In the past 30 days, how often has a lack of transportation kept you from medical appointments or from doing things needed for daily living?")]
        [RegularExpression("^([1-3]|8)$", ErrorMessage = "Valid range is 1-3 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? TRSPMED { get; set; }

        [Display(Name = "Which of these income groups represents your household income for the past year? Include income from all sources such as wages, salaries, social security or retirement benefits, help from relatives, rent from property, and so forth.")]
        [RegularExpression("^([1-4]|8|9)$", ErrorMessage = "Valid range is 1-4 or 8 - 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? INCOMEYR { get; set; }

        [Display(Name = "How satisfied are you with your current personal financial condition?")]
        [RegularExpression("^([1-5]|8)$", ErrorMessage = "Valid range is 1-5 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? FINSATIS { get; set; }

        [Display(Name = "How difficult is it for you to meet monthly payments on your bills?")]
        [RegularExpression("^([1-5]|8)$", ErrorMessage = "Valid range is 1-5 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? BILLPAY { get; set; }

        [Display(Name = "If you have had financial problems that lasted twelve months or longer, how upsetting has it been to you?")]
        [RegularExpression("^([1-4]|8)$", ErrorMessage = "Valid range is 1-4 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? FINUPSET { get; set; }

        [Display(Name = "At any time, did you ever eat less than you felt you should because there wasn't enough money to buy food?")]
        [RegularExpression("^(0|1|8)$", ErrorMessage = "Valid range is 0-1 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? EATLESS { get; set; }

        [Display(Name = "In the last 12 months, did you ever eat less than you felt you should because there wasn't enough money to buy food?")]
        [RegularExpression("^(0|1|8)$", ErrorMessage = "Valid range is 0-1 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? EATLESSYR { get; set; }

        [Display(Name = "At any time, have you ended up taking less medication than was prescribed for you because of the cost?")]
        [RegularExpression("^(0|1|8)$", ErrorMessage = "Valid range is 0-1 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? LESSMEDS { get; set; }

        [Display(Name = "In the last 12 months, have you ended up taking less medication than was prescribed for you because of the cost?")]
        [RegularExpression("^(0|1|8)$", ErrorMessage = "Valid range is 0-1 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? LESSMEDSYR { get; set; }

        [Display(Name = "Where would you place yourself on this ladder compared to others in your community (or neighborhood)? Please mark the number where you would place yourself. (88 = prefer not to answer)")]
        [RegularExpression("^([1-9]|10|88)$", ErrorMessage = "Valid range is 1-10 or 88")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? COMPCOMM { get; set; }


        [Display(Name = "Thinking of the person who raised you, what was their highest level of education completed?")]
        [RegularExpression("^([1-6]|9)$", ErrorMessage = "Valid range is 1-6 or 9")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? GUARDEDU { get; set; }

        [Display(Name = "I experience a general sense of emptiness")]
        [RegularExpression("^([1-5]|8)$", ErrorMessage = "Valid range is 1-5 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? EMPTINESS { get; set; }

        [Display(Name = "I miss having people around")]
        [RegularExpression("^([1-5]|8)$", ErrorMessage = "Valid range is 1-5 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? MISSPEOPLE { get; set; }

        [Display(Name = "I feel like I don't have enough friends")]
        [RegularExpression("^([1-5]|8)$", ErrorMessage = "Valid range is 1-5 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? FRIENDS { get; set; }

        [Display(Name = "I often feel abandoned")]
        [RegularExpression("^([1-5]|8)$", ErrorMessage = "Valid range is 1-5 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? ABANDONED { get; set; }

        [Display(Name = "I miss having a really good friend")]
        [RegularExpression("^([1-5]|8)$", ErrorMessage = "Valid range is 1-5 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? CLOSEFRND { get; set; }

        [Display(Name = "If your parents are still alive, how often do you have contact with them (including mother, father, mother-in-law, and father-in-law) either in person, by phone, mail, or email (e.g., any online interaction)?")]
        [RegularExpression("^([0-5]|8)$", ErrorMessage = "Valid range is 0-5 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? PARENTCOMM { get; set; }

        [Display(Name = "If you have children, how often do you have contact with your children (including child[ren]-in-law and stepchild[ren]) either in person, by phone, mail, or email (e.g., any online interaction)?")]
        [RegularExpression("^([0-5]|8)$", ErrorMessage = "Valid range is 0-5 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? CHILDCOMM { get; set; }

        [Display(Name = "How often do you have contact with close friends either in person, by phone, mail, or email (e.g., any online interaction)?")]
        [RegularExpression("^([0-5]|8)$", ErrorMessage = "Valid range is 0-5 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? FRIENDCOMM { get; set; }

        [Display(Name = "How often do you participate in activities outside the home (e.g., religious activities, educational activities, volunteer work, paid work, or activities with groups or organizations)?")]
        [RegularExpression("^([0-5]|8)$", ErrorMessage = "Valid range is 0-5 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? PARTICIPATE { get; set; }

        [Display(Name = "How safe do you feel in your home?")]
        [RegularExpression("^([1-4]|8)$", ErrorMessage = "Valid range is 1-4 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? SAFEHOME { get; set; }

        [Display(Name = "How safe do you feel in your community (or neighborhood)?")]
        [RegularExpression("^([1-4]|8)$", ErrorMessage = "Valid range is 1-4 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? SAFECOMM { get; set; }

        [Display(Name = "In the past year, how often did you delay seeking medical attention for a problem that was bothering you?")]
        [RegularExpression("^([1-5]|8)$", ErrorMessage = "Valid range is 1-5 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? DELAYMED { get; set; }

        [Display(Name = "In the past year, how often did you experience challenges in filling a prescription?")]
        [RegularExpression("^([1-5]|8)$", ErrorMessage = "Valid range is 1-5 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? SCRIPTPROB { get; set; }

        [Display(Name = "In the past year, how often did you miss a follow-up medical appointment that was scheduled?")]
        [RegularExpression("^([1-5]|8)$", ErrorMessage = "Valid range is 1-5 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? MISSEDFUP { get; set; }

        [Display(Name = "In the past year, how often did you follow a doctor's advice or treatment plan when it was given?")]
        [RegularExpression("^([1-5]|8)$", ErrorMessage = "Valid range is 1-5 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? DOCADVICE { get; set; }

        [Display(Name = "Overall, which of these describes your health insurance, access to healthcare services, and access to medications?")]
        [RegularExpression("^([1-4]|8)$", ErrorMessage = "Valid range is 1-4 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? HEALTHACC { get; set; }

        [Display(Name = "In your day-to-day life how often are you treated with less courtesy or respect than other people?")]
        [RegularExpression("^([1-6]|8)$", ErrorMessage = "Valid range is 1-6 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? LESSCOURT { get; set; }

        [Display(Name = "In your day-to-day life how often do you receive poorer service than other people at restaurants or stores?")]
        [RegularExpression("^([1-6]|8)$", ErrorMessage = "Valid range is 1-6 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? POORSERV { get; set; }

        [Display(Name = "In your day-to-day life how often do people act as if they think you are not smart?")]
        [RegularExpression("^([1-6]|8)$", ErrorMessage = "Valid range is 1-6 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? NOTSMART { get; set; }

        [Display(Name = "In your day-to-day life how often do people act as if they are afraid of you?")]
        [RegularExpression("^([1-6]|8)$", ErrorMessage = "Valid range is 1-6 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? ACTAFRAID { get; set; }

        [Display(Name = "In your day-to-day life how often are you threatened or harassed?")]
        [RegularExpression("^([1-6]|8)$", ErrorMessage = "Valid range is 1-6 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public int? THREATENED { get; set; }

        [Display(Name = "How frequently did you receive poorer service or treatment from doctors or in hospitals compared to other people?")]
        [RegularExpression("^([1-5]|8)$", ErrorMessage = "Valid range is 1-5 or 8")]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
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
        [RegularExpression("^([1-3]|[8-9])$", ErrorMessage = "Valid range is 1-3 or 8-9")]
        public int? EXPSTRS { get; set; }

        //39 must have at least one box checked
        [NotMapped]
        [RequiredOnFinalized(ErrorMessage = "Response required")]
        public bool? POORMEDTRTInvalidNoResponse
        {
            get
            {
                if (EXPANCEST || EXPGENDER || EXPRACE || EXPAGE || EXPRELIG || EXPHEIGHT ||
                EXPWEIGHT || EXPAPPEAR || EXPSEXORN || EXPEDUCINC || EXPDISAB ||
                EXPSKIN || EXPOTHER || EXPNOTAPP || EXPNOANS)
                {
                    return true;
                }

                return null;
            }
        }

        //39 cannot have 39a1 - 39a13 marked if not applicable or prefer not to answer is marked
        [NotMapped]
        [RequiredOnFinalized(ErrorMessage = "If \"not applicable\" or \"prefer not to answer\" marked, another Response cannot be marked")]
        public bool? POORMEDTRTInvalidExtra
        {
            get
            {
                if (EXPNOTAPP || EXPNOANS)
                {
                    if (EXPANCEST || EXPGENDER || EXPRACE || EXPAGE || EXPRELIG || EXPHEIGHT ||
                        EXPWEIGHT || EXPAPPEAR || EXPSEXORN || EXPEDUCINC || EXPDISAB ||
                        EXPSKIN || EXPOTHER)
                    {
                        return null;
                    }
                }

                return true;
            }
        }

        //39 both not applicable and prefer not to answer cannot be marked
        [NotMapped]
        [RequiredOnFinalized(ErrorMessage = "Both \"Not applicable\" and \"Prefer not to answer\" cannot be marked")]
        public bool? POORMEDTRTInvalidNAAndPreferNot
        {
            get
            {
                if (EXPNOTAPP && EXPNOANS)
                {
                    return null;
                }

                return true;
            }
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Status == FormStatus.Finalized && MODE != FormMode.NotCompleted)
            {
                if (!EXPNOTAPP && EXPSTRS == null)
                {
                    yield return new ValidationResult("Response required", new[] { nameof(EXPSTRS) });
                }
            }

            foreach (var result in base.Validate(validationContext))
            {
                yield return result;
            }

            yield break;
        }
    }
}

