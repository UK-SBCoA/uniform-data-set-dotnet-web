using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class C2 : FormModel
    {
        [Display(Name = "")]
        public int? MOCACOMP { get; set; }

        [Display(Name = "")]
        public int? MOCAREAS { get; set; }

        [Display(Name = "")]
        public int? MOCALOC { get; set; }

        [Display(Name = "")]
        public int? MOCALAN { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? MOCALANX { get; set; }

        [Display(Name = "")]
        public int? MOCAVIS { get; set; }

        [Display(Name = "")]
        public int? MOCAHEAR { get; set; }

        [Display(Name = "")]
        public int? MOCATOTS { get; set; }

        [Display(Name = "")]
        public int? MOCATRAI { get; set; }

        [Display(Name = "")]
        public int? MOCACUBE { get; set; }

        [Display(Name = "")]
        public int? MOCACLOC { get; set; }

        [Display(Name = "")]
        public int? MOCACLON { get; set; }

        [Display(Name = "")]
        public int? MOCACLOH { get; set; }

        [Display(Name = "")]
        public int? MOCANAMI { get; set; }

        [Display(Name = "")]
        public int? MOCAREGI { get; set; }

        [Display(Name = "")]
        public int? MOCADIGI { get; set; }

        [Display(Name = "")]
        public int? MOCALETT { get; set; }

        [Display(Name = "")]
        public int? MOCASER7 { get; set; }

        [Display(Name = "")]
        public int? MOCAREPE { get; set; }

        [Display(Name = "")]
        public int? MOCAFLUE { get; set; }

        [Display(Name = "")]
        public int? MOCAABST { get; set; }

        [Display(Name = "")]
        public int? MOCARECN { get; set; }

        [Display(Name = "")]
        public int? MOCARECC { get; set; }

        [Display(Name = "")]
        public int? MOCARECR { get; set; }

        [Display(Name = "")]
        public int? MOCAORDT { get; set; }

        [Display(Name = "")]
        public int? MOCAORMO { get; set; }

        [Display(Name = "")]
        public int? MOCAORYR { get; set; }

        [Display(Name = "")]
        public int? MOCAORDY { get; set; }

        [Display(Name = "")]
        public int? MOCAORPL { get; set; }

        [Display(Name = "")]
        public int? MOCAORCT { get; set; }

        [Display(Name = "")]
        public int? NPSYCLOC { get; set; }

        [Display(Name = "")]
        public int? NPSYLAN { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? NPSYLANX { get; set; }

        [Display(Name = "")]
        public int? CRAFTVRS { get; set; }

        [Display(Name = "")]
        public int? CRAFTURS { get; set; }

        [Display(Name = "")]
        public int? UDSBENTC { get; set; }

        [Display(Name = "")]
        public int? DIGFORCT { get; set; }

        [Display(Name = "")]
        public int? DIGFORSL { get; set; }

        [Display(Name = "")]
        public int? DIGBACCT { get; set; }

        [Display(Name = "")]
        public int? DIGBACLS { get; set; }

        [Display(Name = "")]
        public int? ANIMALS { get; set; }

        [Display(Name = "")]
        public int? VEG { get; set; }

        [Display(Name = "")]
        public int? TRAILA { get; set; }

        [Display(Name = "")]
        public int? TRAILARR { get; set; }

        [Display(Name = "")]
        public int? TRAILALI { get; set; }

        [Display(Name = "")]
        public int? TRAILB { get; set; }

        [Display(Name = "")]
        public int? TRAILBRR { get; set; }

        [Display(Name = "")]
        public int? TRAILBLI { get; set; }

        [Display(Name = "")]
        public int? CRAFTDVR { get; set; }

        [Display(Name = "")]
        public int? CRAFTDRE { get; set; }

        [Display(Name = "")]
        public int? CRAFTDTI { get; set; }

        [Display(Name = "")]
        public int? CRAFTCUE { get; set; }

        [Display(Name = "")]
        public int? UDSBENTD { get; set; }

        [Display(Name = "")]
        public int? UDSBENRS { get; set; }

        [Display(Name = "")]
        public int? MINTTOTS { get; set; }

        [Display(Name = "")]
        public int? MINTTOTW { get; set; }

        [Display(Name = "")]
        public int? MINTSCNG { get; set; }

        [Display(Name = "")]
        public int? MINTSCNC { get; set; }

        [Display(Name = "")]
        public int? MINTPCNG { get; set; }

        [Display(Name = "")]
        public int? MINTPCNC { get; set; }

        [Display(Name = "")]
        public int? UDSVERFC { get; set; }

        [Display(Name = "")]
        public int? UDSVERFN { get; set; }

        [Display(Name = "")]
        public int? UDSVERNF { get; set; }

        [Display(Name = "")]
        public int? UDSVERLC { get; set; }

        [Display(Name = "")]
        public int? UDSVERLR { get; set; }

        [Display(Name = "")]
        public int? UDSVERLN { get; set; }

        [Display(Name = "")]
        public int? UDSVERTN { get; set; }

        [Display(Name = "")]
        public int? UDSVERTE { get; set; }

        [Display(Name = "")]
        public int? UDSVERTI { get; set; }

        [Display(Name = "")]
        public int? COGSTAT { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}

