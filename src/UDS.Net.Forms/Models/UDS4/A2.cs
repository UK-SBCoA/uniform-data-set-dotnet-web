using System.ComponentModel.DataAnnotations;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models.UDS4
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class A2 : FormModel
    {
        [Display(Name = "What is the co-participant’s relationship to the participant?")]
        [RequiredOnFinalized(ErrorMessage = "Response to co-participant's relationship to participant required")]
        public int? INRELTO { get; set; }
        [Display(Name = "How long has the co-participant known the participant?")]
        [RequiredOnFinalized(ErrorMessage = "Response to how long co-participant has know the participant required")]
        [RegularExpression("^(0|[1-9]\\d?|1[01]\\d|120|999)$", ErrorMessage = "Valid range is 0-120 or 999")]
        public int? INKNOWN { get; set; }
        [Display(Name = "Does the co-participant live with the participant?")]
        [RequiredOnFinalized(ErrorMessage = "Response to co-participant living with participant required")]
        public int? INLIVWTH { get; set; }
        [Display(Name = "What is the primary mode of contact with the participant?")]
        [RequiredIf(nameof(INLIVWTH), "0", ErrorMessage = "Response to primary mode of contact required")]
        public int? INCNTMOD { get; set; }
        [Display(Name = "Primary mode of contact with the participant - Other (specify)")]
        [MaxLength(60)]
        [RequiredIf(nameof(INCNTMOD), "6", ErrorMessage = "If primary mode of contact is 'Other', response is required")]
        public string? INCNTMDX { get; set; }
        [Display(Name = "What is the approximate frequency of contact?")]
        [RequiredIf(nameof(INLIVWTH), "0", ErrorMessage = "Response to frequency of contact required")]
        public int? INCNTFRQ { get; set; }
        [Display(Name = "What is the average amount of time spent in contact with the participant during each encounter?")]
        [RequiredIf(nameof(INLIVWTH), "0", ErrorMessage = "Response to average amount of time spent in contact requried")]
        public int? INCNTTIM { get; set; }
        [Display(Name = "Is there a question about the co-participant’s reliability?")]
        [RequiredOnFinalized(ErrorMessage = "Response to co-participant's reliability required")]
        public int? INRELY { get; set; }
        [Display(Name = "Do you feel like the participant's memory is becoming worse?")]
        [RequiredOnFinalized(ErrorMessage = "Response to participants memory becoming worse required")]
        public int? INMEMWORS { get; set; }
        [Display(Name = "About how often does the participant have trouble remembering things?")]
        [RequiredOnFinalized(ErrorMessage = "Response to participants memory required")]
        public int? INMEMTROUB { get; set; }
        [Display(Name = "Compared to 10 years ago, would you say that the participant's memory is much worse, a little worse, the same, a little better, or much better?")]
        [RequiredOnFinalized(ErrorMessage = "Response to participants memory since 10 years ago required")]
        public int? INMEMTEN { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Status == FormStatus.Finalized)
            {
                var visitValue = validationContext.Items.FirstOrDefault(v => v.Key.ToString() == "Visit").Value;
                if (visitValue is VisitModel)
                {
                    VisitModel visit = (VisitModel)visitValue;

                    if (visit != null)
                    {
                        if (visit.PACKET == PacketKind.F)
                        {
                            yield return new ValidationResult("Response required");
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

