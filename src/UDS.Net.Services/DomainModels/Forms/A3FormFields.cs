using System;
using System.Collections.Generic;
using System.Reflection;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A3FormFields : IFormFields
    {
        public int? AFFFAMM { get; set; } // initial visits
        public int? NWINFMUT { get; set; } // follow-up visits
        public int? FADMUT { get; set; }
        public string? FADMUTX { get; set; }
        public int? FADMUSO { get; set; }
        public string? FADMUSOX { get; set; }
        public int? FFTDMUT { get; set; }
        public string? FFTDMUTX { get; set; }
        public int? FFTDMUSO { get; set; }
        public string? FFTDMUSX { get; set; }
        public int? FOTHMUT { get; set; }
        public string? FOTHMUTX { get; set; }
        public int? FOTHMUSO { get; set; }
        public string? FOTHMUSX { get; set; }
        public int? MOMMOB { get; set; }
        public int? MOMYOB { get; set; }
        public int? MOMDAGE { get; set; }
        public int? MOMNEUR { get; set; }
        public int? MOMMOE { get; set; }
        public int? MOMAGEO { get; set; }
        public int? DADMOB { get; set; }
        public int? DADYOB { get; set; }
        public int? DADDAGE { get; set; }
        public int? DADNEUR { get; set; }
        public int? DADPRDX { get; set; }
        public int? DADMOE { get; set; }
        public int? DADAGEO { get; set; }

        public int? SIBS { get; set; }

        public List<A3FamilyMemberFormFields> SiblingFormFields { get; set; } = new List<A3FamilyMemberFormFields>();

        public int? KIDS { get; set; }

        public List<A3FamilyMemberFormFields> KidsFormFields { get; set; } = new List<A3FamilyMemberFormFields>();

        public string GetDescription()
        {
            return "Participant family history";
        }

        public string GetVersion()
        {
            return "3.0";
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
                A3FamilyMemberDto value = (A3FamilyMemberDto)prop.GetValue(dto);
                if (value != null)
                {
                    familyMember.MOB = value.MOB;
                    familyMember.YOB = value.YOB;
                    familyMember.AGD = value.AGD;
                    familyMember.NEU = value.NEU;
                    familyMember.PDX = value.PDX;
                    familyMember.MOE = value.MOE;
                    familyMember.AGO = value.AGO;
                }
            }

            return familyMember;
        }

        public A3FormFields(FormDto dto)
        {
            if (dto is A3Dto)
            {
                var a3Dto = ((A3Dto)dto);
                this.AFFFAMM = a3Dto.AFFFAMM;
                this.NWINFMUT = a3Dto.AFFFAMM;
                this.FADMUT = a3Dto.FADMUT;
                this.FADMUTX = a3Dto.FADMUTX;
                this.FADMUSO = a3Dto.FADMUSO;
                this.FADMUSOX = a3Dto.FADMUSOX;
                this.FFTDMUT = a3Dto.FFTDMUT;
                this.FFTDMUTX = a3Dto.FFTDMUTX;
                this.FFTDMUSO = a3Dto.FFTDMUSO;
                this.FFTDMUSX = a3Dto.FFTDMUSX;
                this.FOTHMUT = a3Dto.FOTHMUT;
                this.FOTHMUTX = a3Dto.FOTHMUTX;
                this.FOTHMUSO = a3Dto.FOTHMUSO;
                this.FOTHMUSX = a3Dto.FOTHMUSX;
                this.MOMMOB = a3Dto.MOMMOB;
                this.MOMYOB = a3Dto.MOMYOB;
                this.MOMDAGE = a3Dto.MOMDAGE;
                this.MOMNEUR = a3Dto.MOMNEUR;
                this.MOMMOE = a3Dto.MOMMOE;
                this.MOMAGEO = a3Dto.MOMAGEO;
                this.DADMOB = a3Dto.DADMOB;
                this.DADYOB = a3Dto.DADYOB;
                this.DADDAGE = a3Dto.DADDAGE;
                this.DADNEUR = a3Dto.DADNEUR;
                this.DADPRDX = a3Dto.DADPRDX;
                this.DADMOE = a3Dto.DADMOB;
                this.DADAGEO = a3Dto.DADAGEO;

                this.SIBS = a3Dto.SIBS; // the count of siblings
                // always 20 spots for siblings
                for (int i = 1; i <= 20; i++)
                {
                    var sibling = GetFamilyMemberFormFields(i, "SIB", a3Dto);

                    this.SiblingFormFields.Add(sibling);
                }

                this.KIDS = a3Dto.KIDS; // the count of kids
                // always 15 spots for kids
                for (int i = 1; 1 <= 15; i++)
                {
                    var kid = GetFamilyMemberFormFields(i, "KID", a3Dto);

                    this.KidsFormFields.Add(kid);
                }
            }
        }
    }
}

