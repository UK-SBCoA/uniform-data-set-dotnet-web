using System;
using UDS.Net.Services.Utilities;
namespace UDS.Net.Services.DomainModels.Forms
{
    public class A3FamilyMemberFormFields
    {
        public int FamilyMemberIndex { get; set; }
        public int? YOB { get; set; }
        public int? AGD { get; set; }
        public string? ETPR { get; set; }
        public string? ETSEC { get; set; }
        public int? MEVAL { get; set; }
        public int? AGO { get; set; }

        public A3FamilyMemberFormFields GetEncodedFormFields(A3FamilyMemberFormFields previousFamilyMemberFormFields, Action<int?> hasNewInformation)
        {
            if (previousFamilyMemberFormFields != null)
            {
                A3FamilyMemberFormFields encodedFamilyMemberFormFields = new A3FamilyMemberFormFields();

                encodedFamilyMemberFormFields.YOB = ExportHelper.GetEncodedValue(previousFamilyMemberFormFields.YOB, this.YOB, 6666, hasNewInformation);
                encodedFamilyMemberFormFields.AGD = ExportHelper.GetEncodedValue(previousFamilyMemberFormFields.AGD, this.AGD, 666, hasNewInformation);
                encodedFamilyMemberFormFields.ETPR = ExportHelper.GetEncodedValue(previousFamilyMemberFormFields.ETPR, this.ETPR, "66", hasNewInformation);
                encodedFamilyMemberFormFields.ETSEC = ExportHelper.GetEncodedValue(previousFamilyMemberFormFields.ETSEC, this.ETSEC, "66", hasNewInformation);
                encodedFamilyMemberFormFields.MEVAL = ExportHelper.GetEncodedValue(previousFamilyMemberFormFields.MEVAL, this.MEVAL, 6, hasNewInformation);
                encodedFamilyMemberFormFields.AGO = ExportHelper.GetEncodedValue(previousFamilyMemberFormFields.AGO, this.AGO, 666, hasNewInformation);

                return encodedFamilyMemberFormFields;
            }

            return null;
        }

        public A3FamilyMemberFormFields GetExportFormFields(int hasNewInformation)
        {
            A3FamilyMemberFormFields formFields = this;

            // if there is no new information then it is exported as null for follow-up visits
            if (hasNewInformation == 0)
            {
                formFields.YOB = null;
                formFields.AGD = null;
                formFields.ETPR = null;
                formFields.ETSEC = null;
                formFields.MEVAL = null;
                formFields.AGO = null;
            }

            return formFields;
        }
    }
}

