
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models.UDS4
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class A2 : FormModel
    {
        [Display(Name = "Is this a new co-participant - i.e., one who was not a co-participant at any past UDS visit?")]
        public int? NEWINF { get; set; }
        [Display(Name = "What is the co-participant’s relationship to the participant?")]
        public int? INRELTO { get; set; }
        [Display(Name = "How long has the co-participant known the participant?")]
        public int? INKNOWN { get; set; }
        [Display(Name = "Does the co-participant live with the participant?")]
        public int? INLIVWTH { get; set; }
        [Display(Name = "What is the primary mode of contact with the participant?")]
        public int? INCNTMOD { get; set; }
        [Display(Name = "Primary mode of contact with the participant - Other (specify)")]
        [MaxLength(60)]
        public string? INCNTMDX { get; set; }
        [Display(Name = "What is the approximate frequency of contact?")]
        public int? INCNTFRQ { get; set; }
        [Display(Name = "What is the average amount of time spent in contact with the participant during each encounter?")]
        public int? INCNTTIM { get; set; }
        [Display(Name = "Is there a question about the co-participant’s reliability?")]
        public int? INRELY { get; set; }
        [Display(Name = "Do you feel like the participant's memory is becoming worse?")]
        public int? INMEMWORS { get; set; }
        [Display(Name = "About how often does the participant have trouble remembering things?")]
        public int? INMEMTROUB { get; set; }
        [Display(Name = "Compared to 10 years ago, would you say that the participant's memory is much worse, a little worse, the same, a little better, or much better?")]
        public int? INMEMTEN { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (Status == FormStatus.Complete)
            {
                var visitValue = validationContext.Items.FirstOrDefault(v => v.Key.ToString() == "Visit").Value;
                if (visitValue is VisitModel)
                {
                    VisitModel visit = (VisitModel)visitValue;

                    if (visit != null)
                    {
                        if (visit.Kind == VisitKind.FVP || visit.Kind == VisitKind.TFP)
                        {
                            if (!NEWINF.HasValue)
                                yield return new ValidationResult("Response required", new[] { nameof(NEWINF) });
                        }
                    }
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

