using System;
using System.Collections.Generic;
using System.Reflection;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

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
                A3FormFields encodedFormFields = new A3FormFields();

                //Set change props to 0 before potential changes in GetExportValue()
                encodedFormFields.NWINFPAR = 0;
                encodedFormFields.NWINFSIB = 0;
                encodedFormFields.NWINFKID = 0;

                encodedFormFields.MOMYOB = GetExportValue(previousA3Fields.MOMYOB, MOMYOB, 6666, changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.MOMDAGE = GetExportValue(previousA3Fields.MOMDAGE, MOMDAGE, 666, changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.MOMETPR = GetExportValue(previousA3Fields.MOMETPR, MOMETPR, "66", changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.MOMETSEC = GetExportValue(previousA3Fields.MOMETSEC, MOMETSEC, "66", changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.MOMMEVAL = GetExportValue(previousA3Fields.MOMMEVAL, MOMMEVAL, 6, changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.MOMAGEO = GetExportValue(previousA3Fields.MOMAGEO, MOMAGEO, 666, changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.DADYOB = GetExportValue(previousA3Fields.DADYOB, DADYOB, 6666, changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.DADDAGE = GetExportValue(previousA3Fields.DADDAGE, DADDAGE, 666, changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.DADETPR = GetExportValue(previousA3Fields.DADETPR, DADETPR, "66", changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.DADETSEC = GetExportValue(previousA3Fields.DADETSEC, DADETSEC, "66", changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.DADMEVAL = GetExportValue(previousA3Fields.DADMEVAL, DADMEVAL, 6, changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.DADAGEO = GetExportValue(previousA3Fields.DADAGEO, DADAGEO, 666, changeProp => encodedFormFields.NWINFPAR = changeProp);
                encodedFormFields.SIBS = GetExportValue(previousA3Fields.SIBS, SIBS, 66, changeProp => encodedFormFields.NWINFSIB = changeProp);
                encodedFormFields.KIDS = GetExportValue(previousA3Fields.KIDS, KIDS, 66, changeProp => encodedFormFields.NWINFKID = changeProp);

                //Encode siblings and kids
                if (encodedFormFields != null)
                {
                    for (var i = 0; i < SiblingFormFields.Count; i++)
                    {
                        encodedFormFields.SiblingFormFields[i].YOB = GetExportValue(previousA3Fields.SiblingFormFields[i].YOB, SiblingFormFields[i].YOB, 6666, changeProp => encodedFormFields.NWINFSIB = changeProp);
                        encodedFormFields.SiblingFormFields[i].AGD = GetExportValue(previousA3Fields.SiblingFormFields[i].AGD, SiblingFormFields[i].AGD, 666, changeProp => encodedFormFields.NWINFSIB = changeProp);
                        encodedFormFields.SiblingFormFields[i].ETPR = GetExportValue(previousA3Fields.SiblingFormFields[i].ETPR, SiblingFormFields[i].ETPR, "66", changeProp => encodedFormFields.NWINFSIB = changeProp);
                        encodedFormFields.SiblingFormFields[i].ETSEC = GetExportValue(previousA3Fields.SiblingFormFields[i].ETSEC, SiblingFormFields[i].ETSEC, "66", changeProp => encodedFormFields.NWINFSIB = changeProp);
                        encodedFormFields.SiblingFormFields[i].MEVAL = GetExportValue(previousA3Fields.SiblingFormFields[i].MEVAL, SiblingFormFields[i].MEVAL, 6, changeProp => encodedFormFields.NWINFSIB = changeProp);
                        encodedFormFields.SiblingFormFields[i].AGO = GetExportValue(previousA3Fields.SiblingFormFields[i].AGO, SiblingFormFields[i].AGO, 666, changeProp => encodedFormFields.NWINFSIB = changeProp);
                    }

                    for (var i = 0; i < KidsFormFields.Count; i++)
                    {
                        encodedFormFields.KidsFormFields[i].YOB = GetExportValue(previousA3Fields.KidsFormFields[i].YOB, KidsFormFields[i].YOB, 6666, changeProp => encodedFormFields.NWINFKID = changeProp);
                        encodedFormFields.KidsFormFields[i].AGD = GetExportValue(previousA3Fields.KidsFormFields[i].AGD, KidsFormFields[i].AGD, 666, changeProp => encodedFormFields.NWINFKID = changeProp);
                        encodedFormFields.KidsFormFields[i].ETPR = GetExportValue(previousA3Fields.KidsFormFields[i].ETPR, KidsFormFields[i].ETPR, "66", changeProp => encodedFormFields.NWINFKID = changeProp);
                        encodedFormFields.KidsFormFields[i].ETSEC = GetExportValue(previousA3Fields.KidsFormFields[i].ETSEC, KidsFormFields[i].ETSEC, "66", changeProp => encodedFormFields.NWINFKID = changeProp);
                        encodedFormFields.KidsFormFields[i].MEVAL = GetExportValue(previousA3Fields.KidsFormFields[i].MEVAL, KidsFormFields[i].MEVAL, 6, changeProp => encodedFormFields.NWINFKID = changeProp);
                        encodedFormFields.KidsFormFields[i].AGO = GetExportValue(previousA3Fields.KidsFormFields[i].AGO, KidsFormFields[i].AGO, 666, changeProp => encodedFormFields.NWINFKID = changeProp);
                    }
                }

                return encodedFormFields;
            }

            return null;
        }

        //Take the enocded form fields and set values to null when change property is 0
        public A3FormFields GetExportFormFields()
        {
            A3FormFields encodedFormFields = this;

            if(encodedFormFields != null)
            {
                if(NWINFPAR == 0)
                {
                    encodedFormFields.MOMYOB = null;
                    encodedFormFields.MOMDAGE = null;
                    encodedFormFields.MOMETPR = null;
                    encodedFormFields.MOMETSEC = null;
                    encodedFormFields.MOMMEVAL = null;
                    encodedFormFields.MOMAGEO = null;
                    encodedFormFields.DADYOB = null;
                    encodedFormFields.DADDAGE = null;
                    encodedFormFields.DADETPR = null;
                    encodedFormFields.DADETSEC = null;
                    encodedFormFields.DADMEVAL = null;
                    encodedFormFields.DADAGEO = null;
                    encodedFormFields.SIBS = null;
                    encodedFormFields.KIDS = null;
                }

                if(NWINFSIB == 0)
                {
                    encodedFormFields.SIBS = encodedFormFields.NWINFSIB == 0 ? null : SIBS;

                    if (encodedFormFields.SiblingFormFields != null)
                    {
                        for (var i = 0; i < SiblingFormFields.Count; i++)
                        {
                            encodedFormFields.SiblingFormFields[i].YOB = null;
                            encodedFormFields.SiblingFormFields[i].AGD = null;
                            encodedFormFields.SiblingFormFields[i].ETPR = null;
                            encodedFormFields.SiblingFormFields[i].ETSEC = null;
                            encodedFormFields.SiblingFormFields[i].MEVAL = null;
                            encodedFormFields.SiblingFormFields[i].AGO = null;
                        }
                    }
                }

                if(NWINFKID == 0)
                {
                    encodedFormFields.KIDS = encodedFormFields.NWINFKID == 0 ? null : KIDS;

                    if (encodedFormFields.KidsFormFields != null)
                    {
                        for (var i = 0; i < KidsFormFields.Count; i++)
                        {
                            encodedFormFields.KidsFormFields[i].YOB = null;
                            encodedFormFields.KidsFormFields[i].AGD = null;
                            encodedFormFields.KidsFormFields[i].ETPR = null;
                            encodedFormFields.KidsFormFields[i].ETSEC = null;
                            encodedFormFields.KidsFormFields[i].MEVAL = null;
                            encodedFormFields.KidsFormFields[i].AGO = null;
                        }
                    }
                }

                return encodedFormFields;
            }

            return null;
        }

        // Evalutate for export value (currentValue, code, or null) and use the setter method to set change property value
        private int? GetExportValue(int? previousValue, int? currentValue, int code, Action<int?> changePropSetter)
        {
            if (previousValue == null && currentValue == null)
            {
                return null;
            }

            if (previousValue == currentValue)
            {
                return code;
            }

            //Set change property provided if change detected
            changePropSetter(1);
            return currentValue;
        }

        // Evalutate for export value (currentValue, code, or null) and use the setter method to set change property value
        private string GetExportValue(string? previousValue, string? currentValue, string code, Action<int?> changePropSetter)
        {
            if (previousValue == null && currentValue == null)
            {
                return null;
            }

            if (previousValue == currentValue)
            {
                //Set change property provided if change detected
                return code;
            }

            changePropSetter(1);
            return currentValue;
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

