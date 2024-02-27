using System;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A2FormFields : IFormFields
    {
        public int? NEWINF { get; set; }
        public int? INRELTO { get; set; }
        public int? INKNOWN { get; set; }
        public int? INLIVWTH { get; set; }
        public int? INCNTMOD { get; set; }
        public string INCNTMDX { get; set; }
        public int? INCNTFRQ { get; set; }
        public int? INCNTTIM { get; set; }
        public int? INRELY { get; set; }
        public int? INMEMWORS { get; set; }
        public int? INMEMTROUB { get; set; }
        public int? INMEMTEN { get; set; }

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

                //this.INBIRMO = a2Dto.INBIRMO;
                //this.INBIRYR = a2Dto.INBIRYR;
                //this.INSEX = a2Dto.INSEX;
                this.NEWINF = a2Dto.NEWINF;
                //this.INHISP = a2Dto.INHISP;
                //this.INHISPOR = a2Dto.INHISPOR;
                //this.INHISPOX = a2Dto.INHISPOX;
                //this.INRACE = a2Dto.INRACE;
                //this.INRACEX = a2Dto.INRACEX;
                //this.INRASEC = a2Dto.INRASEC;
                //this.INRASECX = a2Dto.INRASECX;
                //this.INRATER = a2Dto.INRATER;
                //this.INRATERX = a2Dto.INRATERX;
                //this.INEDUC = a2Dto.INEDUC;
                this.INRELTO = a2Dto.INRELTO;
                this.INKNOWN = a2Dto.INKNOWN;
                this.INLIVWTH = a2Dto.INLIVWTH;
                //this.INVISITS = a2Dto.INVISITS;
                //this.INCALLS = a2Dto.INCALLS;
                this.NEWINF = a2Dto.NEWINF;
                this.INRELTO = a2Dto.INRELTO;
                this.INKNOWN = a2Dto.INKNOWN;
                this.INLIVWTH = a2Dto.INLIVWTH;
                this.INCNTMOD = a2Dto.INCNTMOD;
                this.INCNTMDX = a2Dto.INCNTMDX;
                this.INCNTFRQ = a2Dto.INCNTFRQ;
                this.INCNTTIM = a2Dto.INCNTTIM;
                this.INRELY = a2Dto.INRELY;
                this.INMEMWORS = a2Dto.INMEMWORS;
                this.INMEMTROUB = a2Dto.INMEMTROUB;
                this.INMEMTEN = a2Dto.INMEMTEN;
            }
        }
    }
}

