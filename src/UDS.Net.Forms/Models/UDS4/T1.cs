using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace UDS.Net.Forms.Models.UDS4
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class T1 : FormModel
    {
        [Display(Name = "Participant is too cognitively impaired for an in-person UDS visit.")]
        public int? TELCOG { get; set; }

        [Display(Name = "Participant is too physically impaired (medical illness or injury) to attend an in-person UDS visit.")]
        public int? TELILL { get; set; }

        [Display(Name = "Participant is homebound or in a nursing home and cannot travel.")]
        public int? TELHOME { get; set; }

        [Display(Name = "Participant or co-participant refused an in-person UDS visit.")]
        public int? TELREFU { get; set; }

        [Display(Name = "COVID pandemic precludes traditional in-person UDS visit.")]
        public int? TELCOV { get; set; }

        [Display(Name = "Other")]
        public int? TELOTHR { get; set; }

        [Display(Name = "Other (specify)")]
        [MaxLength(60)]
        public string? TELOTHRX { get; set; }

        [Display(Name = "What modality of communication was used to collect this remote UDS packet?")]
        public int? TELMOD { get; set; }

        [Display(Name = "Is the participant likely to resume in-person UDS follow-up evaluation?")]
        public int? TELINPER { get; set; }

        [Display(Name = "Has a Milestones Form documenting the change to telephone follow-up been completed? (If no, complete a Milestones Form now.)")]
        public int? TELMILE { get; set; }

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

