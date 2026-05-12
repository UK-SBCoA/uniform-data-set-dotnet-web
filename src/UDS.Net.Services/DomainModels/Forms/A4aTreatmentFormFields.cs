namespace UDS.Net.Services.DomainModels.Forms
{
    public class A4aTreatmentFormFields
    {
        public int TreatmentIndex { get; set; }
        public bool? TARGETAB { get; set; }
        public bool? TARGETTAU { get; set; }
        public bool? TARGETINF { get; set; }
        public bool? TARGETSYN { get; set; }
        public bool? TARGETOTH { get; set; }
        public string? TARGETOTX { get; set; }
        public string? TRTTRIAL { get; set; }
        public string? NCTNUM { get; set; }
        public int? STARTMO { get; set; }
        public int? STARTYEAR { get; set; }
        public int? ENDMO { get; set; }
        public int? ENDYEAR { get; set; }
        public int? CARETRIAL { get; set; }
        public int? TRIALGRP { get; set; }


        public A4aTreatmentFormFields GetExportedTreatmentFields(A4aTreatmentFormFields currentTreatments, int? newTreatValue)
        {
            if ((newTreatValue == 0 || newTreatValue == 9))
            {
                currentTreatments.TARGETAB = null;
                currentTreatments.TARGETTAU = null;
                currentTreatments.TARGETINF = null;
                currentTreatments.TARGETSYN = null;
                currentTreatments.TARGETOTH = null;
                currentTreatments.TARGETOTX = null;
                currentTreatments.TRTTRIAL = null;
                currentTreatments.NCTNUM = null;
                currentTreatments.STARTMO = null;
                currentTreatments.STARTYEAR = null;
                currentTreatments.ENDMO = null;
                currentTreatments.ENDYEAR = null;
                currentTreatments.CARETRIAL = null;
                currentTreatments.TRIALGRP = null;
            }
            return currentTreatments;
        }
    }
}
