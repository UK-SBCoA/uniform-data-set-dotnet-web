using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A5D2FormFields : IFormFields
    {
        public int? TOBAC100 { get; set; }
        public int? SMOKYRS { get; set; }
        public int? PACKSPER { get; set; }
        public int? TOBAC30 { get; set; }
        public int? QUITSMOK { get; set; }
        public int? ALCFREQYR { get; set; }
        public int? ALCDRINKS { get; set; }
        public int? ALCBINGE { get; set; }
        public int? SUBSTYEAR { get; set; }
        public int? SUBSTPAST { get; set; }
        public int? CANNABIS { get; set; }
        public int? HRTATTACK { get; set; }
        public int? HRTATTMULT { get; set; }
        public int? HRTATTAGE { get; set; }
        public int? CARDARREST { get; set; }
        public int? CARDARRAGE { get; set; }
        public int? CVAFIB { get; set; }
        public int? CVANGIO { get; set; }
        public int? CVBYPASS { get; set; }
        public int? BYPASSAGE { get; set; }
        public int? CVPACDEF { get; set; }
        public int? PACDEFAGE { get; set; }
        public int? CVCHF { get; set; }
        public int? CVHVALVE { get; set; }
        public int? VALVEAGE { get; set; }
        public int? CVOTHR { get; set; }
        public string? CVOTHRX { get; set; }
        public int? CBSTROKE { get; set; }
        public int? STROKMUL { get; set; }
        public int? STROKAGE { get; set; }
        public int? STROKSTAT { get; set; }
        public int? ANGIOCP { get; set; }
        public int? CAROTIDAGE { get; set; }
        public int? CBTIA { get; set; }
        public int? TIAAGE { get; set; }
        public int? PD { get; set; }
        public int? PDAGE { get; set; }
        public int? PDOTHR { get; set; }
        public int? PDOTHRAGE { get; set; }
        public int? SEIZURES { get; set; }
        public int? SEIZNUM { get; set; }
        public int? SEIZAGE { get; set; }
        public int? HEADACHE { get; set; }
        public int? MS { get; set; }
        public int? HYDROCEPH { get; set; }
        public int? HEADIMP { get; set; }
        public bool? IMPAMFOOT { get; set; }
        public bool? IMPSOCCER { get; set; }
        public bool? IMPHOCKEY { get; set; }
        public bool? IMPBOXING { get; set; }
        public bool? IMPSPORT { get; set; }
        public bool? IMPIPV { get; set; }
        public bool? IMPMILIT { get; set; }
        public bool? IMPASSAULT { get; set; }
        public bool? IMPOTHER { get; set; }
        public string? IMPOTHERX { get; set; }
        public int? IMPYEARS { get; set; }
        public int? HEADINJURY { get; set; }
        public int? HEADINJUNC { get; set; }
        public int? HEADINJCON { get; set; }
        public int? HEADINJNUM { get; set; }
        public int? FIRSTTBI { get; set; }
        public int? LASTTBI { get; set; }
        public int? DIABETES { get; set; }
        public int? DIABTYPE { get; set; }
        public bool? DIABINS { get; set; }
        public bool? DIABMEDS { get; set; }
        public bool? DIABGLP1 { get; set; }
        public bool? DIABRECACT { get; set; }
        public bool? DIABDIET { get; set; }
        public bool? DIABUNK { get; set; }
        public int? DIABAGE { get; set; }
        public int? HYPERTEN { get; set; }
        public int? HYPERTAGE { get; set; }
        public int? HYPERCHO { get; set; }
        public int? HYPERCHAGE { get; set; }
        public int? B12DEF { get; set; }
        public int? THYROID { get; set; }
        public int? ARTHRIT { get; set; }
        public bool? ARTHRRHEUM { get; set; }
        public bool? ARTHROSTEO { get; set; }
        public bool? ARTHROTHR { get; set; }
        public string? ARTHTYPX { get; set; }
        public bool? ARTHTYPUNK { get; set; }
        public bool? ARTHUPEX { get; set; }
        public bool? ARTHLOEX { get; set; }
        public bool? ARTHSPIN { get; set; }
        public bool? ARTHUNK { get; set; }
        public int? INCONTU { get; set; }
        public int? INCONTF { get; set; }
        public int? APNEA { get; set; }
        public int? CPAP { get; set; }
        public int? APNEAORAL { get; set; }
        public int? RBD { get; set; }
        public int? INSOMN { get; set; }
        public int? OTHSLEEP { get; set; }
        public string? OTHSLEEX { get; set; }
        public int? CANCERACTV { get; set; }
        public bool? CANCERPRIM { get; set; }
        public bool? CANCERMETA { get; set; }
        public bool? CANCMETBR { get; set; }
        public bool? CANCMETOTH { get; set; }
        public bool? CANCERUNK { get; set; }
        public bool? CANCBLOOD { get; set; }
        public bool? CANCBREAST { get; set; }
        public bool? CANCCOLON { get; set; }
        public bool? CANCLUNG { get; set; }
        public bool? CANCPROST { get; set; }
        public bool? CANCOTHER { get; set; }
        public string? CANCOTHERX { get; set; }
        public bool? CANCRAD { get; set; }
        public bool? CANCRESECT { get; set; }
        public bool? CANCIMMUNO { get; set; }
        public bool? CANCBONE { get; set; }
        public bool? CANCCHEMO { get; set; }
        public bool? CANCHORM { get; set; }
        public bool? CANCTROTH { get; set; }
        public string? CANCTROTHX { get; set; }
        public int? CANCERAGE { get; set; }
        public int? COVID19 { get; set; }
        public int? COVIDHOSP { get; set; }
        public int? PULMONARY { get; set; }
        public int? KIDNEY { get; set; }
        public int? KIDNEYAGE { get; set; }
        public int? LIVER { get; set; }
        public int? LIVERAGE { get; set; }
        public int? PVD { get; set; }
        public int? PVDAGE { get; set; }
        public int? HIVDIAG { get; set; }
        public int? HIVAGE { get; set; }
        public int? OTHERCOND { get; set; }
        public string? OTHCONDX { get; set; }
        public int? MAJORDEP { get; set; }
        public int? OTHERDEP { get; set; }
        public int? DEPRTREAT { get; set; }
        public int? BIPOLAR { get; set; }
        public int? SCHIZ { get; set; }
        public int? ANXIETY { get; set; }
        public int? GENERALANX { get; set; }
        public int? PANICDIS { get; set; }
        public int? OCD { get; set; }
        public int? OTHANXDIS { get; set; }
        public string? OTHANXDISX { get; set; }
        public int? PTSD { get; set; }
        public int? NPSYDEV { get; set; }
        public int? PSYCDIS { get; set; }
        public string? PSYCDISX { get; set; }
        public int? MENARCHE { get; set; }
        public int? NOMENSAGE { get; set; }
        public bool? NOMENSNAT { get; set; }
        public bool? NOMENSHYST { get; set; }
        public bool? NOMENSSURG { get; set; }
        public bool? NOMENSCHEM { get; set; }
        public bool? NOMENSRAD { get; set; }
        public bool? NOMENSHORM { get; set; }
        public bool? NOMENSESTR { get; set; }
        public bool? NOMENSUNK { get; set; }
        public bool? NOMENSOTH { get; set; }
        public string? NOMENSOTHX { get; set; }
        public int? HRT { get; set; }
        public int? HRTYEARS { get; set; }
        public int? HRTSTRTAGE { get; set; }
        public int? HRTENDAGE { get; set; }
        public int? BCPILLS { get; set; }
        public int? BCPILLSYR { get; set; }
        public int? BCSTARTAGE { get; set; }
        public int? BCENDAGE { get; set; }

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
                return new List<NotIncludedReasonCode>();
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
            return "Participant Health History";
        }

        public string GetVersion()
        {
            return "4";
        }

        public A5D2FormFields() { }
        public A5D2FormFields(FormDto dto) : this()
        {
            if (dto is A5D2Dto)
            {
                var a5D2Dto = ((A5D2Dto)dto);
                this.TOBAC100 = a5D2Dto.TOBAC100;
                this.SMOKYRS = a5D2Dto.SMOKYRS;
                this.PACKSPER = a5D2Dto.PACKSPER;
                this.TOBAC30 = a5D2Dto.TOBAC30;
                this.QUITSMOK = a5D2Dto.QUITSMOK;
                this.ALCFREQYR = a5D2Dto.ALCFREQYR;
                this.ALCDRINKS = a5D2Dto.ALCDRINKS;
                this.ALCBINGE = a5D2Dto.ALCBINGE;
                this.SUBSTYEAR = a5D2Dto.SUBSTYEAR;
                this.SUBSTPAST = a5D2Dto.SUBSTPAST;
                this.CANNABIS = a5D2Dto.CANNABIS;
                this.HRTATTACK = a5D2Dto.HRTATTACK;
                this.HRTATTMULT = a5D2Dto.HRTATTMULT;
                this.HRTATTAGE = a5D2Dto.HRTATTAGE;
                this.CARDARREST = a5D2Dto.CARDARREST;
                this.CARDARRAGE = a5D2Dto.CARDARRAGE;
                this.CVAFIB = a5D2Dto.CVAFIB;
                this.CVANGIO = a5D2Dto.CVANGIO;
                this.CVBYPASS = a5D2Dto.CVBYPASS;
                this.BYPASSAGE = a5D2Dto.BYPASSAGE;
                this.CVPACDEF = a5D2Dto.CVPACDEF;
                this.PACDEFAGE = a5D2Dto.PACDEFAGE;
                this.CVCHF = a5D2Dto.CVCHF;
                this.CVHVALVE = a5D2Dto.CVHVALVE;
                this.VALVEAGE = a5D2Dto.VALVEAGE;
                this.CVOTHR = a5D2Dto.CVOTHR;
                this.CVOTHRX = a5D2Dto.CVOTHRX;
                this.CBSTROKE = a5D2Dto.CBSTROKE;
                this.STROKMUL = a5D2Dto.STROKMUL;
                this.STROKAGE = a5D2Dto.STROKAGE;
                this.STROKSTAT = a5D2Dto.STROKSTAT;
                this.ANGIOCP = a5D2Dto.ANGIOCP;
                this.CAROTIDAGE = a5D2Dto.CAROTIDAGE;
                this.CBTIA = a5D2Dto.CBTIA;
                this.TIAAGE = a5D2Dto.TIAAGE;
                this.PD = a5D2Dto.PD;
                this.PDAGE = a5D2Dto.PDAGE;
                this.PDOTHR = a5D2Dto.PDOTHR;
                this.PDOTHRAGE = a5D2Dto.PDOTHRAGE;
                this.SEIZURES = a5D2Dto.SEIZURES;
                this.SEIZNUM = a5D2Dto.SEIZNUM;
                this.SEIZAGE = a5D2Dto.SEIZAGE;
                this.HEADACHE = a5D2Dto.HEADACHE;
                this.MS = a5D2Dto.MS;
                this.HYDROCEPH = a5D2Dto.HYDROCEPH;
                this.HEADIMP = a5D2Dto.HEADIMP;
                this.IMPAMFOOT = a5D2Dto.IMPAMFOOT;
                this.IMPSOCCER = a5D2Dto.IMPSOCCER;
                this.IMPHOCKEY = a5D2Dto.IMPHOCKEY;
                this.IMPBOXING = a5D2Dto.IMPBOXING;
                this.IMPSPORT = a5D2Dto.IMPSPORT;
                this.IMPIPV = a5D2Dto.IMPIPV;
                this.IMPMILIT = a5D2Dto.IMPMILIT;
                this.IMPASSAULT = a5D2Dto.IMPASSAULT;
                this.IMPOTHER = a5D2Dto.IMPOTHER;
                this.IMPOTHERX = a5D2Dto.IMPOTHERX;
                this.IMPYEARS = a5D2Dto.IMPYEARS;
                this.HEADINJURY = a5D2Dto.HEADINJURY;
                this.HEADINJUNC = a5D2Dto.HEADINJUNC;
                this.HEADINJCON = a5D2Dto.HEADINJCON;
                this.HEADINJNUM = a5D2Dto.HEADINJNUM;
                this.FIRSTTBI = a5D2Dto.FIRSTTBI;
                this.LASTTBI = a5D2Dto.LASTTBI;
                this.DIABETES = a5D2Dto.DIABETES;
                this.DIABTYPE = a5D2Dto.DIABTYPE;
                this.DIABINS = a5D2Dto.DIABINS;
                this.DIABMEDS = a5D2Dto.DIABMEDS;
                this.DIABGLP1 = a5D2Dto.DIABGLP1;
                this.DIABRECACT = a5D2Dto.DIABRECACT;
                this.DIABDIET = a5D2Dto.DIABDIET;
                this.DIABUNK = a5D2Dto.DIABUNK;
                this.DIABAGE = a5D2Dto.DIABAGE;
                this.HYPERTEN = a5D2Dto.HYPERTEN;
                this.HYPERTAGE = a5D2Dto.HYPERTAGE;
                this.HYPERCHO = a5D2Dto.HYPERCHO;
                this.HYPERCHAGE = a5D2Dto.HYPERCHAGE;
                this.B12DEF = a5D2Dto.B12DEF;
                this.THYROID = a5D2Dto.THYROID;
                this.ARTHRIT = a5D2Dto.ARTHRIT;
                this.ARTHRRHEUM = a5D2Dto.ARTHRRHEUM;
                this.ARTHROSTEO = a5D2Dto.ARTHROSTEO;
                this.ARTHROTHR = a5D2Dto.ARTHROTHR;
                this.ARTHTYPX = a5D2Dto.ARTHTYPX;
                this.ARTHTYPUNK = a5D2Dto.ARTHTYPUNK;
                this.ARTHUPEX = a5D2Dto.ARTHUPEX;
                this.ARTHLOEX = a5D2Dto.ARTHLOEX;
                this.ARTHSPIN = a5D2Dto.ARTHSPIN;
                this.ARTHUNK = a5D2Dto.ARTHUNK;
                this.INCONTU = a5D2Dto.INCONTU;
                this.INCONTF = a5D2Dto.INCONTF;
                this.APNEA = a5D2Dto.APNEA;
                this.CPAP = a5D2Dto.CPAP;
                this.APNEAORAL = a5D2Dto.APNEAORAL;
                this.RBD = a5D2Dto.RBD;
                this.INSOMN = a5D2Dto.INSOMN;
                this.OTHSLEEP = a5D2Dto.OTHSLEEP;
                this.OTHSLEEX = a5D2Dto.OTHSLEEX;
                this.CANCERACTV = a5D2Dto.CANCERACTV;
                this.CANCERPRIM = a5D2Dto.CANCERPRIM;
                this.CANCERMETA = a5D2Dto.CANCERMETA;
                this.CANCMETBR = a5D2Dto.CANCMETBR;
                this.CANCMETOTH = a5D2Dto.CANCMETOTH;
                this.CANCERUNK = a5D2Dto.CANCERUNK;
                this.CANCBLOOD = a5D2Dto.CANCBLOOD;
                this.CANCBREAST = a5D2Dto.CANCBREAST;
                this.CANCCOLON = a5D2Dto.CANCCOLON;
                this.CANCLUNG = a5D2Dto.CANCLUNG;
                this.CANCPROST = a5D2Dto.CANCPROST;
                this.CANCOTHER = a5D2Dto.CANCOTHER;
                this.CANCOTHERX = a5D2Dto.CANCOTHERX;
                this.CANCRAD = a5D2Dto.CANCRAD;
                this.CANCRESECT = a5D2Dto.CANCRESECT;
                this.CANCIMMUNO = a5D2Dto.CANCIMMUNO;
                this.CANCBONE = a5D2Dto.CANCBONE;
                this.CANCCHEMO = a5D2Dto.CANCCHEMO;
                this.CANCHORM = a5D2Dto.CANCHORM;
                this.CANCTROTH = a5D2Dto.CANCTROTH;
                this.CANCTROTHX = a5D2Dto.CANCTROTHX;
                this.CANCERAGE = a5D2Dto.CANCERAGE;
                this.COVID19 = a5D2Dto.COVID19;
                this.COVIDHOSP = a5D2Dto.COVIDHOSP;
                this.PULMONARY = a5D2Dto.PULMONARY;
                this.KIDNEY = a5D2Dto.KIDNEY;
                this.KIDNEYAGE = a5D2Dto.KIDNEYAGE;
                this.LIVER = a5D2Dto.LIVER;
                this.LIVERAGE = a5D2Dto.LIVERAGE;
                this.PVD = a5D2Dto.PVD;
                this.PVDAGE = a5D2Dto.PVDAGE;
                this.HIVDIAG = a5D2Dto.HIVDIAG;
                this.HIVAGE = a5D2Dto.HIVAGE;
                this.OTHERCOND = a5D2Dto.OTHERCOND;
                this.OTHCONDX = a5D2Dto.OTHCONDX;
                this.MAJORDEP = a5D2Dto.MAJORDEP;
                this.OTHERDEP = a5D2Dto.OTHERDEP;
                this.DEPRTREAT = a5D2Dto.DEPRTREAT.HasValue ? (int?)a5D2Dto.DEPRTREAT.Value : null;
                this.BIPOLAR = a5D2Dto.BIPOLAR;
                this.SCHIZ = a5D2Dto.SCHIZ;
                this.ANXIETY = a5D2Dto.ANXIETY;
                this.GENERALANX = a5D2Dto.GENERALANX;
                this.PANICDIS = a5D2Dto.PANICDIS;
                this.OCD = a5D2Dto.OCD;
                this.OTHANXDIS = a5D2Dto.OTHANXDIS;
                this.OTHANXDISX = a5D2Dto.OTHANXDISX;
                this.PTSD = a5D2Dto.PTSD;
                this.NPSYDEV = a5D2Dto.NPSYDEV;
                this.PSYCDIS = a5D2Dto.PSYCDIS;
                this.PSYCDISX = a5D2Dto.PSYCDISX;
                this.MENARCHE = a5D2Dto.MENARCHE;
                this.NOMENSAGE = a5D2Dto.NOMENSAGE;
                this.NOMENSNAT = a5D2Dto.NOMENSNAT;
                this.NOMENSHYST = a5D2Dto.NOMENSHYST;
                this.NOMENSSURG = a5D2Dto.NOMENSSURG;
                this.NOMENSCHEM = a5D2Dto.NOMENSCHEM;
                this.NOMENSRAD = a5D2Dto.NOMENSRAD;
                this.NOMENSHORM = a5D2Dto.NOMENSHORM;
                this.NOMENSESTR = a5D2Dto.NOMENSESTR;
                this.NOMENSUNK = a5D2Dto.NOMENSUNK;
                this.NOMENSOTH = a5D2Dto.NOMENSOTH;
                this.NOMENSOTHX = a5D2Dto.NOMENSOTHX;
                this.HRT = a5D2Dto.HRT;
                this.HRTYEARS = a5D2Dto.HRTYEARS;
                this.HRTSTRTAGE = a5D2Dto.HRTSTRTAGE;
                this.HRTENDAGE = a5D2Dto.HRTENDAGE;
                this.BCPILLS = a5D2Dto.BCPILLS;
                this.BCPILLSYR = a5D2Dto.BCPILLSYR;
                this.BCSTARTAGE = a5D2Dto.BCSTARTAGE;
                this.BCENDAGE = a5D2Dto.BCENDAGE;
            }
        }
    }
}

