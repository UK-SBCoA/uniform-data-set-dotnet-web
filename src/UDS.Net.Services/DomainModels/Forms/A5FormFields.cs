using System;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A5FormFields : IFormFields
    {
        public int? TOBAC30 { get; set; }
        public int? TOBAC100 { get; set; }
        public int? SMOKYRS { get; set; }
        public int? PACKSPER { get; set; }
        public int? QUITSMOK { get; set; }
        public int? ALCOCCAS { get; set; }
        public int? ALCFREQ { get; set; }
        public int? CVHATT { get; set; }
        public int? HATTMULT { get; set; }
        public int? HATTYEAR { get; set; }
        public int? CVAFIB { get; set; }
        public int? CVANGIO { get; set; }
        public int? CVBYPASS { get; set; }
        public int? CVPACDEF { get; set; }
        public int? CVCHF { get; set; }
        public int? CVANGINA { get; set; }
        public int? CVHVALVE { get; set; }
        public int? CVOTHR { get; set; }
        public string CVOTHRX { get; set; }
        public int? CBSTROKE { get; set; }
        public int? STROKMUL { get; set; }
        public int? STROKYR { get; set; }
        public int? CBTIA { get; set; }
        public int? TIAMULT { get; set; }
        public int? TIAYEAR { get; set; }
        public int? PD { get; set; }
        public int? PDYR { get; set; }
        public int? PDOTHR { get; set; }
        public int? PDOTHRYR { get; set; }
        public int? SEIZURES { get; set; }
        public int? TBI { get; set; }
        public int? TBIBRIEF { get; set; }
        public int? TBIEXTEN { get; set; }
        public int? TBIWOLOS { get; set; }
        public int? TBIYEAR { get; set; }
        public int? DIABETES { get; set; }
        public int? DIABTYPE { get; set; }
        public int? HYPERTEN { get; set; }
        public int? HYPERCHO { get; set; }
        public int? B12DEF { get; set; }
        public int? THYROID { get; set; }
        public int? ARTHRIT { get; set; }
        public int? ARTHTYPE { get; set; }
        public string ARTHTYPX { get; set; }
        public int? ARTHUPEX { get; set; }
        public int? ARTHLOEX { get; set; }
        public int? ARTHSPIN { get; set; }
        public int? ARTHUNK { get; set; }
        public int? INCONTU { get; set; }
        public int? INCONTF { get; set; }
        public int? APNEA { get; set; }
        public int? RBD { get; set; }
        public int? INSOMN { get; set; }
        public int? OTHSLEEP { get; set; }
        public string OTHSLEEX { get; set; }
        public int? ALCOHOL { get; set; }
        public int? ABUSOTHR { get; set; }
        public string ABUSX { get; set; }
        public int? PTSD { get; set; }
        public int? BIPOLAR { get; set; }
        public int? SCHIZ { get; set; }
        public int? DEP2YRS { get; set; }
        public int? DEPOTHR { get; set; }
        public int? ANXIETY { get; set; }
        public int? OCD { get; set; }
        public int? NPSYDEV { get; set; }
        public int? PSYCDIS { get; set; }
        public string PSYCDISX { get; set; }

        public string GetDescription()
        {
            return "Participant health history";
        }

        public string GetVersion()
        {
            return "4.0";
        }

        public A5FormFields() { }
        public A5FormFields(FormDto dto)
        {
            if (dto is A5D2Dto)
            {
                var a5Dto = (A5D2Dto)dto;

                this.TOBAC30 = a5Dto.TOBAC30;
                this.TOBAC100 = a5Dto.TOBAC100;
                this.SMOKYRS = a5Dto.SMOKYRS;
                this.PACKSPER = a5Dto.PACKSPER;
                this.QUITSMOK = a5Dto.QUITSMOK;
                this.CVAFIB = a5Dto.CVAFIB;
                this.CVANGIO = a5Dto.CVANGIO;
                this.CVBYPASS = a5Dto.CVBYPASS;
                this.CVPACDEF = a5Dto.CVPACDEF;
                this.CVCHF = a5Dto.CVCHF;
                this.CVHVALVE = a5Dto.CVHVALVE;
                this.CVOTHR = a5Dto.CVOTHR;
                this.CVOTHRX = a5Dto.CVOTHRX;
                this.CBSTROKE = a5Dto.CBSTROKE;
                this.STROKMUL = a5Dto.STROKMUL;
                this.CBTIA = a5Dto.CBTIA;
                this.PD = a5Dto.PD;
                this.PDOTHR = a5Dto.PDOTHR;
                this.SEIZURES = a5Dto.SEIZURES;
                this.DIABETES = a5Dto.DIABETES;
                this.DIABTYPE = a5Dto.DIABTYPE;
                this.HYPERTEN = a5Dto.HYPERTEN;
                this.HYPERCHO = a5Dto.HYPERCHO;
                this.B12DEF = a5Dto.B12DEF;
                this.THYROID = a5Dto.THYROID;
                this.ARTHRIT = a5Dto.ARTHRIT;
                this.ARTHTYPX = a5Dto.ARTHTYPX;
                this.INCONTU = a5Dto.INCONTU;
                this.INCONTF = a5Dto.INCONTF;
                this.APNEA = a5Dto.APNEA;
                this.RBD = a5Dto.RBD;
                this.INSOMN = a5Dto.INSOMN;
                this.OTHSLEEP = a5Dto.OTHSLEEP;
                this.OTHSLEEX = a5Dto.OTHSLEEX;
                this.PTSD = a5Dto.PTSD;
                this.BIPOLAR = a5Dto.BIPOLAR;
                this.SCHIZ = a5Dto.SCHIZ;
                this.ANXIETY = a5Dto.ANXIETY;
                this.OCD = a5Dto.OCD;
                this.NPSYDEV = a5Dto.NPSYDEV;
                this.PSYCDIS = a5Dto.PSYCDIS;
                this.PSYCDISX = a5Dto.PSYCDISX;

                // TODO map new fields
            }
        }
    }
}

