﻿using System;
using System.Collections.Generic;
using System.Reflection;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A3FormFields : IFormFields
    {
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

        public string GetDescription()
        {
            return "Participant Family History";
        }

        public string GetVersion()
        {
            return "4";
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

