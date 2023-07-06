using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace UDS.Net.Forms.Models.UDS3
{
    /// <summary>
    /// ViewModel for form with front-end validation
    /// </summary>
    public class D1 : FormModel
    {
        [Display(Name = "")]
        public int? DXMETHOD { get; set; }

        [Display(Name = "")]
        public int? NORMCOG { get; set; }

        [Display(Name = "")]
        public int? DEMENTED { get; set; }

        [Display(Name = "")]
        public int? AMNDEM { get; set; }

        [Display(Name = "")]
        public int? PCA { get; set; }

        [Display(Name = "")]
        public int? PPASYN { get; set; }

        [Display(Name = "")]
        public int? PPASYNT { get; set; }

        [Display(Name = "")]
        public int? FTDSYN { get; set; }

        [Display(Name = "")]
        public int? LBDSYN { get; set; }

        [Display(Name = "")]
        public int? NAMNDEM { get; set; }

        [Display(Name = "")]
        public int? MCIAMEM { get; set; }

        [Display(Name = "")]
        public int? MCIAPLUS { get; set; }

        [Display(Name = "")]
        public int? MCIAPLAN { get; set; }

        [Display(Name = "")]
        public int? MCIAPATT { get; set; }

        [Display(Name = "")]
        public int? MCIAPEX { get; set; }

        [Display(Name = "")]
        public int? MCIAPVIS { get; set; }

        [Display(Name = "")]
        public int? MCINON1 { get; set; }

        [Display(Name = "")]
        public int? MCIN1LAN { get; set; }

        [Display(Name = "")]
        public int? MCIN1ATT { get; set; }

        [Display(Name = "")]
        public int? MCIN1EX { get; set; }

        [Display(Name = "")]
        public int? MCIN1VIS { get; set; }

        [Display(Name = "")]
        public int? MCINON2 { get; set; }

        [Display(Name = "")]
        public int? MCIN2LAN { get; set; }

        [Display(Name = "")]
        public int? MCIN2ATT { get; set; }

        [Display(Name = "")]
        public int? MCIN2EX { get; set; }

        [Display(Name = "")]
        public int? MCIN2VIS { get; set; }

        [Display(Name = "")]
        public int? IMPNOMCI { get; set; }

        [Display(Name = "")]
        public int? AMYLPET { get; set; }

        [Display(Name = "")]
        public int? AMYLCSF { get; set; }

        [Display(Name = "")]
        public int? FDGAD { get; set; }

        [Display(Name = "")]
        public int? HIPPATR { get; set; }

        [Display(Name = "")]
        public int? TAUPETAD { get; set; }

        [Display(Name = "")]
        public int? CSFTAU { get; set; }

        [Display(Name = "")]
        public int? FDGFTLD { get; set; }

        [Display(Name = "")]
        public int? TPETFTLD { get; set; }

        [Display(Name = "")]
        public int? MRFTLD { get; set; }

        [Display(Name = "")]
        public int? DATSCAN { get; set; }

        [Display(Name = "")]
        public int? OTHBIOM { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? OTHBIOMX { get; set; }

        [Display(Name = "")]
        public int? IMAGLINF { get; set; }

        [Display(Name = "")]
        public int? IMAGLAC { get; set; }

        [Display(Name = "")]
        public int? IMAGMACH { get; set; }

        [Display(Name = "")]
        public int? IMAGMICH { get; set; }

        [Display(Name = "")]
        public int? IMAGMWMH { get; set; }

        [Display(Name = "")]
        public int? IMAGEWMH { get; set; }

        [Display(Name = "")]
        public int? ADMUT { get; set; }

        [Display(Name = "")]
        public int? FTLDMUT { get; set; }

        [Display(Name = "")]
        public int? OTHMUT { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? OTHMUTX { get; set; }

        [Display(Name = "")]
        public int? ALZDIS { get; set; }

        [Display(Name = "")]
        public int? ALZDISIF { get; set; }

        [Display(Name = "")]
        public int? LBDIS { get; set; }

        [Display(Name = "")]
        public int? LBDIF { get; set; }

        [Display(Name = "")]
        public int? PARK { get; set; }

        [Display(Name = "")]
        public int? MSA { get; set; }

        [Display(Name = "")]
        public int? MSAIF { get; set; }

        [Display(Name = "")]
        public int? PSP { get; set; }

        [Display(Name = "")]
        public int? PSPIF { get; set; }

        [Display(Name = "")]
        public int? CORT { get; set; }

        [Display(Name = "")]
        public int? CORTIF { get; set; }

        [Display(Name = "")]
        public int? FTLDMO { get; set; }

        [Display(Name = "")]
        public int? FTLDMOIF { get; set; }

        [Display(Name = "")]
        public int? FTLDNOS { get; set; }

        [Display(Name = "")]
        public int? FTLDNOIF { get; set; }

        [Display(Name = "")]
        public int? FTLDSUBT { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? FTLDSUBX { get; set; }

        [Display(Name = "")]
        public int? CVD { get; set; }

        [Display(Name = "")]
        public int? CVDIF { get; set; }

        [Display(Name = "")]
        public int? PREVSTK { get; set; }

        [Display(Name = "")]
        public int? STROKDEC { get; set; }

        [Display(Name = "")]
        public int? STKIMAG { get; set; }

        [Display(Name = "")]
        public int? INFNETW { get; set; }

        [Display(Name = "")]
        public int? INFWMH { get; set; }

        [Display(Name = "")]
        public int? ESSTREM { get; set; }

        [Display(Name = "")]
        public int? ESSTREIF { get; set; }

        [Display(Name = "")]
        public int? DOWNS { get; set; }

        [Display(Name = "")]
        public int? DOWNSIF { get; set; }

        [Display(Name = "")]
        public int? HUNT { get; set; }

        [Display(Name = "")]
        public int? HUNTIF { get; set; }

        [Display(Name = "")]
        public int? PRION { get; set; }

        [Display(Name = "")]
        public int? PRIONIF { get; set; }

        [Display(Name = "")]
        public int? BRNINJ { get; set; }

        [Display(Name = "")]
        public int? BRNINJIF { get; set; }

        [Display(Name = "")]
        public int? BRNINCTE { get; set; }

        [Display(Name = "")]
        public int? HYCEPH { get; set; }

        [Display(Name = "")]
        public int? HYCEPHIF { get; set; }

        [Display(Name = "")]
        public int? EPILEP { get; set; }

        [Display(Name = "")]
        public int? EPILEPIF { get; set; }

        [Display(Name = "")]
        public int? NEOP { get; set; }

        [Display(Name = "")]
        public int? NEOPIF { get; set; }

        [Display(Name = "")]
        public int? NEOPSTAT { get; set; }

        [Display(Name = "")]
        public int? HIV { get; set; }

        [Display(Name = "")]
        public int? HIVIF { get; set; }

        [Display(Name = "")]
        public int? OTHCOG { get; set; }

        [Display(Name = "")]
        public int? OTHCOGIF { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? OTHCOGX { get; set; }

        [Display(Name = "")]
        public int? DEP { get; set; }

        [Display(Name = "")]
        public int? DEPIF { get; set; }

        [Display(Name = "")]
        public int? DEPTREAT { get; set; }

        [Display(Name = "")]
        public int? BIPOLDX { get; set; }

        [Display(Name = "")]
        public int? BIPOLDIF { get; set; }

        [Display(Name = "")]
        public int? SCHIZOP { get; set; }

        [Display(Name = "")]
        public int? SCHIZOIF { get; set; }

        [Display(Name = "")]
        public int? ANXIET { get; set; }

        [Display(Name = "")]
        public int? ANXIETIF { get; set; }

        [Display(Name = "")]
        public int? DELIR { get; set; }

        [Display(Name = "")]
        public int? DELIRIF { get; set; }

        [Display(Name = "")]
        public int? PTSDDX { get; set; }

        [Display(Name = "")]
        public int? PTSDDXIF { get; set; }

        [Display(Name = "")]
        public int? OTHPSY { get; set; }

        [Display(Name = "")]
        public int? OTHPSYIF { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? OTHPSYX { get; set; }

        [Display(Name = "")]
        public int? ALCDEM { get; set; }

        [Display(Name = "")]
        public int? ALCDEMIF { get; set; }

        [Display(Name = "")]
        public int? ALCABUSE { get; set; }

        [Display(Name = "")]
        public int? IMPSUB { get; set; }

        [Display(Name = "")]
        public int? IMPSUBIF { get; set; }

        [Display(Name = "")]
        public int? DYSILL { get; set; }

        [Display(Name = "")]
        public int? DYSILLIF { get; set; }

        [Display(Name = "")]
        public int? MEDS { get; set; }

        [Display(Name = "")]
        public int? MEDSIF { get; set; }

        [Display(Name = "")]
        public int? COGOTH { get; set; }

        [Display(Name = "")]
        public int? COGOTHIF { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? COGOTHX { get; set; }

        [Display(Name = "")]
        public int? COGOTH2 { get; set; }

        [Display(Name = "")]
        public int? COGOTH2F { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? COGOTH2X { get; set; }

        [Display(Name = "")]
        public int? COGOTH3 { get; set; }

        [Display(Name = "")]
        public int? COGOTH3F { get; set; }

        [Display(Name = "")]
        [MaxLength(60)]
        public string? COGOTH3X { get; set; }

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

