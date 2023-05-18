using System;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A2FormFields : IFormFields
    {
        public int? INBIRMO { get; set; }
        public int? INBIRYR { get; set; }
        public int? INSEX { get; set; }
        public int? INHISP { get; set; }
        public int? INHISPOR { get; set; }
        public string INHISPOX { get; set; }
        public int? INRACE { get; set; }
        public string INRACEX { get; set; }
        public int? INRASEC { get; set; }
        public string INRASECX { get; set; }
        public int? INRATER { get; set; }
        public string INRATERX { get; set; }
        public int? INEDUC { get; set; }
        public int? INRELTO { get; set; }
        public int? INKNOWN { get; set; }
        public int? INLIVWTH { get; set; }
        public int? INVISITS { get; set; }
        public int? INCALLS { get; set; }
        public int? INRELY { get; set; }

        public string GetDescription()
        {
            return "Co-participant demographics";
        }

        public string GetVersion()
        {
            return "3.0";
        }

        public A2FormFields() { }
        public A2FormFields(FormDto dto) : this()
        {
            if (dto is A2Dto)
            {
                var a2Dto = ((A2Dto)dto);

                this.INBIRMO = a2Dto.INBIRMO;
                this.INBIRYR = a2Dto.INBIRYR;
                this.INSEX = a2Dto.INSEX;
                this.INHISP = a2Dto.INHISP;
                this.INHISPOR = a2Dto.INHISPOR;
                this.INHISPOX = a2Dto.INHISPOX;
                this.INRACE = a2Dto.INRACE;
                this.INRACEX = a2Dto.INRACEX;
                this.INRASEC = a2Dto.INRASEC;
                this.INRATER = a2Dto.INRATER;
                this.INRATERX = a2Dto.INRATERX;
                this.INEDUC = a2Dto.INEDUC;
                this.INRELTO = a2Dto.INRELTO;
                this.INKNOWN = a2Dto.INKNOWN;
                this.INLIVWTH = a2Dto.INLIVWTH;
                this.INVISITS = a2Dto.INVISITS;
                this.INCALLS = a2Dto.INCALLS;
                this.INRELY = a2Dto.INRELY;
            }
        }
    }
}

