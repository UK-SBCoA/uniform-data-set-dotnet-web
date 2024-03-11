using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDS.Net.Forms.Models.UDS4
{
    public class A5D2 : FormModel
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
        [MaxLength(60)]
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
        [MaxLength(60)]
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
        [MaxLength(60)]
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
        [MaxLength(60)]
        public string? OTHSLEEX { get; set; }
        public int? CANCER { get; set; }
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
        [MaxLength]
        public string? CANCOTHERX { get; set; }
        public bool? CANCRAD { get; set; }
        public bool? CANCRESECT { get; set; }
        public bool? CANCIMMUNO { get; set; }
        public bool? CANCBONE { get; set; }
        public bool? CANCCHEMO { get; set; }
        public bool? CANCHORM { get; set; }
        public bool? CANCTROTH { get; set; }
        [MaxLength(60)]
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
        public int? OTHCOND { get; set; }
        public string? OTHCONDX { get; set; }
        public int? MAJORDEP { get; set; }
        public int? OTHERDEP { get; set; }
        public bool? DEPRTREAT { get; set; }
        public int? BIPOLAR { get; set; }
        public int? SCHIZ { get; set; }
        public int? ANXIETY { get; set; }
        public int? GENERALANX { get; set; }
        public int? PANICDIS { get; set; }
        public int? OCD { get; set; }
        public int? OTHANXDIS { get; set; }
        [MaxLength(60)]
        public string? OTHANXDISX { get; set; }
        public int? PTSD { get; set; }
        public int? NPSYDEV { get; set; }
        public int? PSYCDIS { get; set; }
        [MaxLength(60)]
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
        [MaxLength(60)]
        public string? NOMENSOTHX { get; set; }
        public int? HRT { get; set; }
        public int? HRTYEARS { get; set; }
        public int? HRTSTRTAGE { get; set; }
        public int? HRTENDAGE { get; set; }
        public int? BCPILLS { get; set; }
        public int? BCPILLSYR { get; set; }
        public int? BCSTARTAGE { get; set; }
        public int? BCENDAGE { get; set; }
    }
}
