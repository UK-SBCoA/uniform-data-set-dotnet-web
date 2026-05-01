using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;
using UDS.Net.Services.Utilities;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A3FormFields : IFormFields
    {
        public int? NWINFPAR { get; set; }
        public int? NWINFSIB { get; set; }
        public int? NWINFKID { get; set; }
        public int? MOMYOB { get; set; }
        public int? MOMDAGE { get; set; }
        public string? MOMETPR { get; set; }
        public string? MOMETSEC { get; set; }
        public int? MOMMEVAL { get; set; }
        public int? MOMAGEO { get; set; }
        public int? DADYOB { get; set; }
        public int? DADDAGE { get; set; }
        public string? DADETPR { get; set; }
        public string? DADETSEC { get; set; }
        public int? DADMEVAL { get; set; }
        public int? DADAGEO { get; set; }
        public int? SIBS { get; set; }

        public List<A3FamilyMemberFormFields> SiblingFormFields { get; set; } = new List<A3FamilyMemberFormFields>();

        public int? KIDS { get; set; }

        public List<A3FamilyMemberFormFields> KidsFormFields { get; set; } = new List<A3FamilyMemberFormFields>();

        public IEnumerable<FormMode> FormModes
        {
            get
            {
                return new List<FormMode>() { FormMode.InPerson, FormMode.Remote };
            }
        }

        public IEnumerable<NotIncludedReasonCode> NotIncludedReasonCodes
        {
            get
            {
                return new List<NotIncludedReasonCode>(); // form is required for I
            }
        }

        public IEnumerable<RemoteModality> RemoteModalities
        {
            get
            {
                return new List<RemoteModality>() { RemoteModality.Telephone, RemoteModality.Video };
            }
        }

        public IEnumerable<AdministrationFormat> AdministrationFormats
        {
            get
            {
                return new List<AdministrationFormat>() { };
            }
        }

        public string GetDescription()
        {
            return "Participant Family History";
        }

        public string GetVersion()
        {
            return "4";
        }

        public A3FormFields GetEncodedFormFields(A3FormFields previousA3Fields)
        {
            if (previousA3Fields != null)
            {
                //Encode parent form fields
                A3FormFields encodedFormFields = this;

                //Set change props to 0 before potential changes in GetExportValue()
                encodedFormFields.NWINFPAR = 0;
                encodedFormFields.NWINFSIB = 0;
                encodedFormFields.NWINFKID = 0;

                //DEVNOTE: It is using the current value without "this", maybe I don't need it for parents
                encodedFormFields.MOMYOB = ExportHelper.GetEncodedValue(previousA3Fields.MOMYOB, this.MOMYOB, 6666, changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.MOMDAGE = ExportHelper.GetEncodedValue(previousA3Fields.MOMDAGE, this.MOMDAGE, 666, changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.MOMETPR = ExportHelper.GetEncodedValue(previousA3Fields.MOMETPR, this.MOMETPR, "66", changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.MOMETSEC = ExportHelper.GetEncodedValue(previousA3Fields.MOMETSEC, this.MOMETSEC, "66", changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.MOMMEVAL = ExportHelper.GetEncodedValue(previousA3Fields.MOMMEVAL, this.MOMMEVAL, 6, changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.MOMAGEO = ExportHelper.GetEncodedValue(previousA3Fields.MOMAGEO, this.MOMAGEO, 666, changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.DADYOB = ExportHelper.GetEncodedValue(previousA3Fields.DADYOB, this.DADYOB, 6666, changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.DADDAGE = ExportHelper.GetEncodedValue(previousA3Fields.DADDAGE, this.DADDAGE, 666, changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.DADETPR = ExportHelper.GetEncodedValue(previousA3Fields.DADETPR, this.DADETPR, "66", changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.DADETSEC = ExportHelper.GetEncodedValue(previousA3Fields.DADETSEC, this.DADETSEC, "66", changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.DADMEVAL = ExportHelper.GetEncodedValue(previousA3Fields.DADMEVAL, this.DADMEVAL, 6, changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.DADAGEO = ExportHelper.GetEncodedValue(previousA3Fields.DADAGEO, this.DADAGEO, 666, changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.SIBS = ExportHelper.GetEncodedValue(previousA3Fields.SIBS, this.SIBS, 66, changeProp => encodedFormFields.NWINFSIB = changeProp);
                encodedFormFields.KIDS = ExportHelper.GetEncodedValue(previousA3Fields.KIDS, this.KIDS, 66, changeProp => encodedFormFields.NWINFKID = changeProp);

                //Encode siblings and kids
                if (encodedFormFields.SiblingFormFields != null & encodedFormFields.KidsFormFields != null)
                {
                    encodedFormFields.SiblingFormFields = encodedFormFields.SiblingFormFields.Select((siblingFields, index) => siblingFields.GetEncodedFormFields(previousA3Fields.SiblingFormFields[index], changeProp => encodedFormFields.NWINFSIB = changeProp)).ToList();

                    encodedFormFields.KidsFormFields = encodedFormFields.KidsFormFields.Select((siblingFields, index) => siblingFields.GetEncodedFormFields(previousA3Fields.KidsFormFields[index], changeProp => encodedFormFields.NWINFKID = changeProp)).ToList();
                }

                return encodedFormFields;
            }

            return null;
        }

        //Take the enocded form fields and set values to null when change property is 0
        public A3FormFields GetExportFormFields()
        {
            A3FormFields exportFormFields = this;

            if (exportFormFields.NWINFPAR == 0)
            {
                exportFormFields.MOMYOB = null;
                exportFormFields.MOMDAGE = null;
                exportFormFields.MOMETPR = null;
                exportFormFields.MOMETSEC = null;
                exportFormFields.MOMMEVAL = null;
                exportFormFields.MOMAGEO = null;
                exportFormFields.DADYOB = null;
                exportFormFields.DADDAGE = null;
                exportFormFields.DADETPR = null;
                exportFormFields.DADETSEC = null;
                exportFormFields.DADMEVAL = null;
                exportFormFields.DADAGEO = null;
            }

            if (exportFormFields.NWINFSIB == 0)
            {
                exportFormFields.SIBS = null;
                exportFormFields.SiblingFormFields = exportFormFields.SiblingFormFields.Select(siblingFields => siblingFields.GetExportFormFields(exportFormFields.NWINFSIB)).ToList();
            }

            if (exportFormFields.NWINFKID == 0)
            {
                exportFormFields.KIDS = null;
                exportFormFields.KidsFormFields = exportFormFields.KidsFormFields.Select(siblingFields => siblingFields.GetExportFormFields(exportFormFields.NWINFKID)).ToList();
            }

            return exportFormFields;
        }

        private A3FamilyMemberFormFields GetFamilyMemberFormFields(int index, string propertyPrefix, A3Dto dto)
        {
            var familyMember = new A3FamilyMemberFormFields
            {
                FamilyMemberIndex = index
            };

            PropertyInfo prop = typeof(A3Dto).GetProperty($"{propertyPrefix}{index}");
            if (prop != null)
            {
                if (dto != null)
                {
                    A3FamilyMemberDto value = (A3FamilyMemberDto)prop.GetValue(dto);
                    if (value != null)
                    {
                        familyMember.YOB = value.YOB;
                        familyMember.AGD = value.AGD;
                        familyMember.ETPR = value.ETPR;
                        familyMember.ETSEC = value.ETSEC;
                        familyMember.MEVAL = value.MEVAL;
                        familyMember.AGO = value.AGO;

                        // TODO map new fields
                    }
                }
            }

            return familyMember;
        }

        public A3FormFields()
        {
            // always 20 spots for siblings
            for (int i = 1; i <= 20; i++)
            {
                var sibling = GetFamilyMemberFormFields(i, "SIB", null);

                this.SiblingFormFields.Add(sibling);
            }
            // always 15 spots for kids
            for (int i = 1; i <= 15; i++)
            {
                var kid = GetFamilyMemberFormFields(i, "KID", null);

                this.KidsFormFields.Add(kid);
            }
        }
        public A3FormFields(FormDto dto)
        {
            if (dto is A3Dto)
            {
                var a3Dto = ((A3Dto)dto);
                this.NWINFPAR = a3Dto.NWINFPAR;
                this.NWINFSIB = a3Dto.NWINFSIB;
                this.NWINFKID = a3Dto.NWINFKID;
                this.MOMYOB = a3Dto.MOMYOB;
                this.MOMDAGE = a3Dto.MOMDAGE;
                this.MOMETPR = a3Dto.MOMETPR;
                this.MOMETSEC = a3Dto.MOMETSEC;
                this.MOMMEVAL = a3Dto.MOMMEVAL;
                this.MOMAGEO = a3Dto.MOMAGEO;
                this.DADYOB = a3Dto.DADYOB;
                this.DADETPR = a3Dto.DADETPR;
                this.DADETSEC = a3Dto.DADETSEC;
                this.DADMEVAL = a3Dto.DADMEVAL;
                this.DADDAGE = a3Dto.DADDAGE;
                this.DADAGEO = a3Dto.DADAGEO;
                this.NWINFPAR = a3Dto.NWINFPAR;
                this.NWINFSIB = a3Dto.NWINFSIB;
                this.NWINFKID = a3Dto.NWINFKID;

                // TODO map new fields

                this.SIBS = a3Dto.SIBS; // the count of siblings
                // always 20 spots for siblings
                for (int i = 1; i <= 20; i++)
                {
                    var sibling = GetFamilyMemberFormFields(i, "SIB", a3Dto);

                    this.SiblingFormFields.Add(sibling);
                }

                this.KIDS = a3Dto.KIDS; // the count of kids
                // always 15 spots for kids
                for (int i = 1; i <= 15; i++)
                {
                    var kid = GetFamilyMemberFormFields(i, "KID", a3Dto);

                    this.KidsFormFields.Add(kid);
                }
            }
        }
    }
}

