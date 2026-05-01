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

        public A3FamilyMemberFormFields GetEncodedFormFields(A3FamilyMemberFormFields previousFamilyMemberFormFields, Action<int?> changePropSetter)
        {
            if (previousFamilyMemberFormFields != null)
            {
                A3FamilyMemberFormFields encodedFamilyMemberFormFields = new A3FamilyMemberFormFields();

                encodedFamilyMemberFormFields.YOB = ExportValueHelper.GetExportValue(previousFamilyMemberFormFields.YOB, this.YOB, 6666, changePropSetter);
                encodedFamilyMemberFormFields.AGD = ExportValueHelper.GetExportValue(previousFamilyMemberFormFields.AGD, this.AGD, 666, changePropSetter);
                encodedFamilyMemberFormFields.ETPR = ExportValueHelper.GetExportValue(previousFamilyMemberFormFields.ETPR, this.ETPR, "66", changePropSetter);
                encodedFamilyMemberFormFields.ETSEC = ExportValueHelper.GetExportValue(previousFamilyMemberFormFields.ETSEC, this.ETSEC, "66", changePropSetter);
                encodedFamilyMemberFormFields.MEVAL = ExportValueHelper.GetExportValue(previousFamilyMemberFormFields.MEVAL, this.MEVAL, 6, changePropSetter);
                encodedFamilyMemberFormFields.AGO = ExportValueHelper.GetExportValue(previousFamilyMemberFormFields.AGO, this.AGO, 666, changePropSetter);

                return encodedFamilyMemberFormFields;
            }

            return null;
        }

        public A3FamilyMemberFormFields GetExportFormFields(int? changePropValue)
        {
            A3FamilyMemberFormFields exportFamilyMemberFormFields = this;

            if (changePropValue == 0)
            {
                exportFamilyMemberFormFields.YOB = null;
                exportFamilyMemberFormFields.AGD = null;
                exportFamilyMemberFormFields.ETPR = null;
                exportFamilyMemberFormFields.ETSEC = null;
                exportFamilyMemberFormFields.MEVAL = null;
                exportFamilyMemberFormFields.AGO = null;
            }

            return exportFamilyMemberFormFields;
        }
    }
}

