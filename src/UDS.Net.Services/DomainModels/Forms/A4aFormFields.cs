using System;
using System.Collections.Generic;

namespace UDS.Net.Services.DomainModels.Forms
{
	public class A4aFormFields
	{
        public int? ADVEVENT { get; set; }
        public bool? ARIAE { get; set; }
        public bool? ARIAH { get; set; }
        public bool? ADVERSEOTH { get; set; }
        public string? ADVERSEOTX { get; set; }
        public int? TRTBIOMARK { get; set; }
        public List<A4aTreatmentFormFields> Treatment1FormFields { get; set; } = new List<A4aTreatmentFormFields>();

        public List<A4aTreatmentFormFields> Treatment2FormFields { get; set; } = new List<A4aTreatmentFormFields>();

        public List<A4aTreatmentFormFields> Treatment3FormFields { get; set; } = new List<A4aTreatmentFormFields>();

        public List<A4aTreatmentFormFields> Treatment4FormFields { get; set; } = new List<A4aTreatmentFormFields>();

        public List<A4aTreatmentFormFields> Treatment5FormFields { get; set; } = new List<A4aTreatmentFormFields>();

        public List<A4aTreatmentFormFields> Treatment6FormFields { get; set; } = new List<A4aTreatmentFormFields>();

        public List<A4aTreatmentFormFields> Treatment7FormFields { get; set; } = new List<A4aTreatmentFormFields>();

        public List<A4aTreatmentFormFields> Treatment8FormFields { get; set; } = new List<A4aTreatmentFormFields>();

        public string GetDescription()
        {
            return "ADRD–Specific Treatments";
        }

        public string GetVersion()
        {
            return "3.0";
        }
    }
}
