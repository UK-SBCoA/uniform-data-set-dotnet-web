using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A1FormFields : IFormFields
    {
        public int? REASON { get; set; }
        public int? REFERSC { get; set; }
        public int? LEARNED { get; set; }
        public int? PRESTAT { get; set; }
        public int? PRESPART { get; set; }
        public int? SOURCENW { get; set; }
        public int? BIRTHMO { get; set; } // FVP
        public int? BIRTHYR { get; set; } // FVP
        public int? SEX { get; set; } // FVP
        public int? HISPANIC { get; set; }
        public int? HISPOR { get; set; }
        public string HISPORX { get; set; }
        public int? RACE { get; set; }
        public string RACEX { get; set; }
        public int? RACESEC { get; set; }
        public string RACESECX { get; set; }
        public int? RACETER { get; set; }
        public string RACETERX { get; set; }
        public int? PRIMLANG { get; set; }
        public string PRIMLANX { get; set; }
        public int? EDUC { get; set; }
        public int? MARISTAT { get; set; } // FVP
        public int? LIVSITUA { get; set; }
        public int? INDEPEND { get; set; } // FVP
        public int? RESIDENC { get; set; } // FVP
        public string ZIP { get; set; } // FVP
        public int? HANDED { get; set; }

        public string GetDescription()
        {
            return "Participant demographics";
        }

        public string GetVersion()
        {
            return "3.0";
        }

        public A1FormFields() { }
        public A1FormFields(FormDto dto) : this()
        {
            if (dto is A1Dto)
            {
                var a1Dto = ((A1Dto)dto);

                REASON = a1Dto.REASON;
                REFERSC = a1Dto.REFERSC;
                LEARNED = a1Dto.LEARNED;
                PRESTAT = a1Dto.PRESTAT;
                PRESPART = a1Dto.PRESPART;
                SOURCENW = a1Dto.SOURCENW;
                BIRTHMO = a1Dto.BIRTHMO;
                BIRTHYR = a1Dto.BIRTHYR;
                SEX = a1Dto.SEX;
                HISPANIC = a1Dto.HISPANIC;
                HISPOR = a1Dto.HISPOR;
                RACE = a1Dto.RACE;
                RACEX = a1Dto.RACEX;
                RACESEC = a1Dto.RACESEC;
                RACESECX = a1Dto.RACESECX;
                RACETER = a1Dto.RACETER;
                RACETERX = a1Dto.RACETERX;
                PRIMLANG = a1Dto.PRIMLANG;
                PRIMLANX = a1Dto.PRIMLANX;
                EDUC = a1Dto.EDUC;
                MARISTAT = a1Dto.MARISTAT;
                LIVSITUA = a1Dto.LIVSITUA;
                INDEPEND = a1Dto.INDEPEND;
                RESIDENC = a1Dto.RESIDENC;
                ZIP = a1Dto.ZIP;
                HANDED = a1Dto.HANDED;
            }
        }
    }
}

