
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using UDS.Net.Forms.DataAnnotations;
using UDS.Net.Forms.TagHelpers;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class A2 : FormModel
    {
        public int? NEWINF { get; set; }
        public int? INRELTO { get; set; }
        public int? INKNOWN { get; set; }
        public int? INLIVWTH { get; set; }
        public int? INCNTMOD { get; set; }
        [MaxLength(60)]
        public string? INCNTMDX { get; set; }
        public int? INCNTFRQ { get; set; }
        public int? INCNTTIM { get; set; }
        public int? INRELY { get; set; }
        public int? INMEMWORS { get; set; }
        public int? INMEMTROUB { get; set; }
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

