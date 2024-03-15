using System;
using System.Collections.Generic;
using System.Reflection;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A4aFormFields : IFormFields
    {
        public int? ADVEVENT { get; set; }
        public bool? ARIAE { get; set; }
        public bool? ARIAH { get; set; }
        public bool? ADVERSEOTH { get; set; }
        public string? ADVERSEOTX { get; set; }
        public int? TRTBIOMARK { get; set; }
        public List<A4aTreatmentFormFields> TreatmentFormFields { get; set; } = new List<A4aTreatmentFormFields>();

        private A4aTreatmentFormFields GetTreatmentFormFields(int index, string propertyPrefix, A4aDto dto)
        {
            var treatment = new A4aTreatmentFormFields
            {
                TreatmentIndex = index
            };

            PropertyInfo prop = typeof(A4aDto).GetProperty($"{propertyPrefix}{index}");
            if (prop != null)
            {
                if (dto != null)
                {
                    A4aTreatmentDto value = (A4aTreatmentDto)prop.GetValue(dto);
                    if (value != null)
                    {
                        treatment.TARGETAB = value.TARGETAB;
                        treatment.TARGETTAU = value.TARGETTAU;
                        treatment.TARGETINF = value.TARGETINF;
                        treatment.TARGETSYN = value.TARGETSYN;
                        treatment.TARGETOTH = value.TARGETOTH;
                        treatment.TARGETOTX = value.TARGETOTX;
                        treatment.TRTTRIAL = value.TRTTRIAL;
                        treatment.NCTNUM = value.NCTNUM;
                        treatment.STARTMO = value.STARTMO;
                        treatment.STARTYEAR = value.STARTYEAR;
                        treatment.ENDMO = value.ENDMO;
                        treatment.ENDYEAR = value.ENDYEAR;
                        treatment.CARETRIAL = value.CARETRIAL;
                        treatment.TRIALGRP = value.TRIALGRP;
                    }
                }
            }

            return treatment;
        }

        public A4aFormFields()
        {
            for (int i = 1; i <= 8; i++)
            {
                var treatment = GetTreatmentFormFields(i, "Treatment", null);
                TreatmentFormFields.Add(treatment);
            }
        }

        public A4aFormFields(FormDto dto)
        {
            if (dto is A4aDto)
            {
                var a4aDto = ((A4aDto)dto);
                ADVEVENT = a4aDto.ADVEVENT;
                ARIAE = a4aDto.ARIAE;
                ARIAH = a4aDto.ARIAH;
                ADVERSEOTH = a4aDto.ADVERSEOTH;
                ADVERSEOTX = a4aDto.ADVERSEOTX;
                TRTBIOMARK = a4aDto.TRTBIOMARK;

                for (int i = 1; i <= 8; i++)
                {
                    var treatment = GetTreatmentFormFields(i, "Treatmentt", a4aDto);
                    TreatmentFormFields[i - 1] = treatment;
                }
            }
        }

        public string GetDescription()
        {
            return "ADRD–Specific Treatments";
        }

        public string GetVersion()
        {
            return "4.0";
        }
    }
}
