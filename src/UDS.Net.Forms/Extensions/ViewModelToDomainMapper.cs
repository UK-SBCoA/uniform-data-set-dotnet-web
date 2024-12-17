using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.DomainModels.Submission;

namespace UDS.Net.Forms.Extensions
{
    public static class ViewModelToDomainMapper
    {
        public static Participation ToEntity(this ParticipationModel vm)
        {
            return new Participation
            {
                Id = vm.Id,
                LegacyId = vm.LegacyId,
                CreatedAt = vm.CreatedAt,
                CreatedBy = vm.CreatedBy,
                ModifiedBy = vm.ModifiedBy,
                DeletedBy = vm.DeletedBy,
                IsDeleted = vm.IsDeleted,
                VisitCount = vm.VisitCount,
                LastVisitNumber = vm.LastVisitNumber,
                Status = vm.Status
            };
        }

        public static Milestone ToEntity(this MilestoneModel vm)
        {
            return new Milestone
            {
                Id = vm.Id,
                FormId = vm.FormId,
                ParticipationId = vm.ParticipationId,
                Status = vm.Status,
                CHANGEMO = vm.CHANGEMO,
                CHANGEDY = vm.CHANGEDY,
                CHANGEYR = vm.CHANGEYR,
                PROTOCOL = vm.PROTOCOL,
                ACONSENT = vm.ACONSENT,
                RECOGIM = vm.RECOGIM == true ? 1 : null,
                REPHYILL = vm.REPHYILL == true ? 1 : null,
                REREFUSE = vm.REREFUSE == true ? 1 : null,
                RENAVAIL = vm.RENAVAIL == true ? 1 : null,
                RENURSE = vm.RENURSE == true ? 1 : null,
                NURSEMO = vm.NURSEMO,
                NURSEDY = vm.NURSEDY,
                NURSEYR = vm.NURSEYR,
                REJOIN = vm.REJOIN == true ? 1 : null,
                FTLDDISC = vm.FTLDDISC == true ? 1 : null,
                FTLDREAS = vm.FTLDREAS,
                FTLDREAX = vm.FTLDREAX,
                DECEASED = vm.DECEASED == true ? 1 : null,
                DISCONT = vm.DISCONT == true ? 1 : null,
                DEATHMO = vm.DEATHMO,
                DEATHDY = vm.DEATHDY,
                DEATHYR = vm.DEATHYR,
                AUTOPSY = vm.AUTOPSY,
                DISCMO = vm.DISCMO,
                DISCDAY = vm.DISCDAY,
                DISCYR = vm.DISCYR,
                DROPREAS = vm.DROPREAS,
                CreatedAt = vm.CreatedAt,
                CreatedBy = vm.CreatedBy,
                ModifiedBy = vm.ModifiedBy,
                DeletedBy = vm.DeletedBy,
                IsDeleted = vm.IsDeleted,
                MILESTONETYPE = vm.MILESTONETYPE
            };
        }

        public static Visit ToEntity(this VisitModel vm)
        {
            return new Visit(vm.Id, vm.VISITNUM, vm.ParticipationId, vm.FORMVER, vm.PACKET, vm.VISIT_DATE, vm.INITIALS, vm.Status, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, vm.Forms.ToEntity());
        }

        public static Packet ToEntity(this PacketModel vm)
        {
            return new Packet(vm.Id, vm.VISITNUM, vm.ParticipationId, vm.FORMVER, vm.PACKET, vm.VISIT_DATE, vm.INITIALS, vm.Status, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, vm.Forms.ToEntity(), vm.PacketSubmissions.ToEntity());
        }

        public static List<PacketSubmission> ToEntity(this IList<PacketSubmissionModel> vm)
        {
            List<PacketSubmission> submissions = new List<PacketSubmission>();

            if (vm != null)
            {
                submissions = vm.Select(p => p.ToEntity()).ToList();
            }

            return submissions;
        }

        public static PacketSubmission ToEntity(this PacketSubmissionModel vm)
        {
            return new PacketSubmission(vm.Id, "", vm.SubmissionDate, vm.PacketId, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, "", false, 0);
        }

        public static List<Form> ToEntity(this IList<FormModel> vm)
        {
            return vm.Select(v => v.ToEntity()).ToList();
        }

        public static Form ToEntity(this FormModel vm)
        {
            IFormFields fields = null;

            if (vm is A1)
                fields = ((A1)vm).GetFormFields();
            else if (vm is A1a)
                fields = ((A1a)vm).GetFormFields();
            else if (vm is A2)
                fields = ((A2)vm).GetFormFields();
            else if (vm is A3)
                fields = ((A3)vm).GetFormFields();
            else if (vm is A4)
                fields = ((A4)vm).GetFormFields();
            else if (vm is A4a)
                fields = ((A4a)vm).GetFormFields();
            else if (vm is A5D2)
                fields = ((A5D2)vm).GetFormFields();
            else if (vm is B1)
                fields = ((B1)vm).GetFormFields();
            else if (vm is B3)
                fields = ((B3)vm).GetFormFields();
            else if (vm is B4)
                fields = ((B4)vm).GetFormFields();
            else if (vm is B5)
                fields = ((B5)vm).GetFormFields();
            else if (vm is B6)
                fields = ((B6)vm).GetFormFields();
            else if (vm is B7)
                fields = ((B7)vm).GetFormFields();
            else if (vm is B8)
                fields = ((B8)vm).GetFormFields();
            else if (vm is B9)
                fields = ((B9)vm).GetFormFields();
            else if (vm is C2)
                fields = ((C2)vm).GetFormFields();
            else if (vm is D1a)
                fields = ((D1a)vm).GetFormFields();
            else if (vm is D1b)
                fields = ((D1b)vm).GetFormFields();

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.FRMDATE, vm.INITIALS, vm.LANG, vm.MODE, vm.RMREAS, vm.RMMODE, vm.NOT, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static IFormFields GetFormFields(this A1 vm)
        {
            return new A1FormFields
            {
                BIRTHMO = vm.BIRTHMO,
                BIRTHYR = vm.BIRTHYR,
                MARISTAT = vm.MARISTAT,
                LIVSITUA = vm.LIVSITUA,
                RESIDENC = vm.RESIDENC,
                EDUC = vm.EDUC,
                ZIP = vm.ZIP,
                HANDED = vm.HANDED,
                CHLDHDCTRY = vm.CHLDHDCTRY,
                RACEWHITE = vm.RACEWHITE ? 1 : 0,
                ETHGERMAN = vm.ETHGERMAN ? 1 : 0,
                ETHIRISH = vm.ETHIRISH ? 1 : 0,
                ETHENGLISH = vm.ETHENGLISH ? 1 : 0,
                ETHITALIAN = vm.ETHITALIAN ? 1 : 0,
                ETHPOLISH = vm.ETHPOLISH ? 1 : 0,
                ETHSCOTT = vm.ETHSCOTT ? 1 : 0,
                ETHWHIOTH = vm.ETHWHIOTH ? 1 : 0,
                ETHWHIOTHX = vm.ETHWHIOTHX,
                ETHISPANIC = vm.ETHISPANIC ? 1 : 0,
                ETHMEXICAN = vm.ETHMEXICAN ? 1 : 0,
                ETHPUERTO = vm.ETHPUERTO ? 1 : 0,
                ETHCUBAN = vm.ETHCUBAN ? 1 : 0,
                ETHSALVA = vm.ETHSALVA ? 1 : 0,
                ETHDOMIN = vm.ETHDOMIN ? 1 : 0,
                ETHGUATEM = vm.ETHGUATEM ? 1 : 0,
                ETHHISOTH = vm.ETHHISOTH ? 1 : 0,
                ETHHISOTHX = vm.ETHHISOTHX,
                RACEBLACK = vm.RACEBLACK ? 1 : 0,
                ETHAFAMER = vm.ETHAFAMER ? 1 : 0,
                ETHJAMAICA = vm.ETHJAMAICA ? 1 : 0,
                ETHHAITIAN = vm.ETHHAITIAN ? 1 : 0,
                ETHNIGERIA = vm.ETHNIGERIA ? 1 : 0,
                ETHETHIOP = vm.ETHETHIOP ? 1 : 0,
                ETHSOMALI = vm.ETHSOMALI ? 1 : 0,
                ETHBLKOTH = vm.ETHBLKOTH ? 1 : 0,
                ETHBLKOTHX = vm.ETHBLKOTHX,
                RACEASIAN = vm.RACEASIAN ? 1 : 0,
                ETHCHINESE = vm.ETHCHINESE ? 1 : 0,
                ETHFILIP = vm.ETHFILIP ? 1 : 0,
                ETHINDIA = vm.ETHINDIA ? 1 : 0,
                ETHVIETNAM = vm.ETHVIETNAM ? 1 : 0,
                ETHKOREAN = vm.ETHKOREAN ? 1 : 0,
                ETHJAPAN = vm.ETHJAPAN ? 1 : 0,
                ETHASNOTH = vm.ETHASNOTH ? 1 : 0,
                ETHASNOTHX = vm.ETHASNOTHX,
                RACEAIAN = vm.RACEAIAN ? 1 : 0,
                RACEAIANX = vm.RACEAIANX,
                RACEMENA = vm.RACEMENA ? 1 : 0,
                ETHLEBANON = vm.ETHLEBANON ? 1 : 0,
                ETHIRAN = vm.ETHIRAN ? 1 : 0,
                ETHEGYPT = vm.ETHEGYPT ? 1 : 0,
                ETHSYRIA = vm.ETHSYRIA ? 1 : 0,
                ETHIRAQI = vm.ETHIRAQI ? 1 : 0,
                ETHISRAEL = vm.ETHISRAEL ? 1 : 0,
                ETHMENAOTH = vm.ETHMENAOTH ? 1 : 0,
                ETHMENAOTX = vm.ETHMENAOTX,
                RACENHPI = vm.RACENHPI ? 1 : 0,
                ETHHAWAII = vm.ETHHAWAII ? 1 : 0,
                ETHSAMOAN = vm.ETHSAMOAN ? 1 : 0,
                ETHCHAMOR = vm.ETHCHAMOR ? 1 : 0,
                ETHTONGAN = vm.ETHTONGAN ? 1 : 0,
                ETHFIJIAN = vm.ETHFIJIAN ? 1 : 0,
                ETHMARSHAL = vm.ETHMARSHAL ? 1 : 0,
                ETHNHPIOTH = vm.ETHNHPIOTH ? 1 : 0,
                ETHNHPIOTX = vm.ETHNHPIOTX,
                RACEUNKN = vm.RACEUNKN ? 1 : 0,
                GENMAN = vm.GENMAN ? 1 : 0,
                GENWOMAN = vm.GENWOMAN ? 1 : 0,
                GENTRMAN = vm.GENTRMAN ? 1 : 0,
                GENTRWOMAN = vm.GENTRWOMAN ? 1 : 0,
                GENNONBI = vm.GENNONBI ? 1 : 0,
                GENTWOSPIR = vm.GENTWOSPIR ? 1 : 0,
                GENOTH = vm.GENOTH ? 1 : 0,
                GENOTHX = vm.GENOTHX,
                GENDKN = vm.GENDKN ? 1 : 0,
                GENNOANS = vm.GENNOANS ? 1 : 0,
                BIRTHSEX = vm.BIRTHSEX,
                INTERSEX = vm.INTERSEX,
                SEXORNGAY = vm.SEXORNGAY ? 1 : 0,
                SEXORNHET = vm.SEXORNHET ? 1 : 0,
                SEXORNBI = vm.SEXORNBI ? 1 : 0,
                SEXORNTWOS = vm.SEXORNTWOS ? 1 : 0,
                SEXORNOTH = vm.SEXORNOTH ? 1 : 0,
                SEXORNOTHX = vm.SEXORNOTHX,
                SEXORNDNK = vm.SEXORNDNK ? 1 : 0,
                SEXORNNOAN = vm.SEXORNNOAN ? 1 : 0,
                PREDOMLAN = vm.PREDOMLAN,
                PREDOMLANX = vm.PREDOMLANX,
                LVLEDUC = vm.LVLEDUC,
                SERVED = vm.SERVED,
                MEDVA = vm.MEDVA,
                EXRTIME = vm.EXRTIME,
                MEMWORS = vm.MEMWORS,
                MEMTROUB = vm.MEMTROUB,
                MEMTEN = vm.MEMTEN,
                ADISTATE = vm.ADISTATE,
                ADINAT = vm.ADINAT,
                PRIOCC = vm.PRIOCC,
                SOURCENW = vm.SOURCENW,
                REFERSC = vm.REFERSC,
                REFERSCX = vm.REFERSCX,
                REFLEARNED = vm.REFLEARNED,
                REFCTRSOCX = vm.REFCTRSOCX,
                REFCTRREGX = vm.REFCTRREGX,
                REFOTHWEBX = vm.REFOTHWEBX,
                REFOTHMEDX = vm.REFOTHMEDX,
                REFOTHREGX = vm.REFOTHREGX,
                REFOTHX = vm.REFOTHX

            };
        }

        public static IFormFields GetFormFields(this A1a vm)
        {
            return new A1aFormFields
            {
                OWNSCAR = vm.OWNSCAR,
                TRSPACCESS = vm.TRSPACCESS,
                TRANSPROB = vm.TRANSPROB,
                TRANSWORRY = vm.TRANSWORRY,
                TRSPLONGER = vm.TRSPLONGER,
                TRSPMED = vm.TRSPMED,
                INCOMEYR = vm.INCOMEYR,
                FINSATIS = vm.FINSATIS,
                BILLPAY = vm.BILLPAY,
                FINUPSET = vm.FINUPSET,
                EATLESS = vm.EATLESS,
                EATLESSYR = vm.EATLESSYR,
                LESSMEDS = vm.LESSMEDS,
                LESSMEDSYR = vm.LESSMEDSYR,
                COMPCOMM = vm.COMPCOMM,
                COMPUSA = vm.COMPUSA,
                FAMCOMP = vm.FAMCOMP,
                GUARDEDU = vm.GUARDEDU,
                GUARDREL = vm.GUARDREL,
                GUARDRELX = vm.GUARDRELX,
                GUARD2EDU = vm.GUARD2EDU,
                GUARD2REL = vm.GUARD2REL,
                GUARD2RELX = vm.GUARD2RELX,
                EMPTINESS = vm.EMPTINESS,
                MISSPEOPLE = vm.MISSPEOPLE,
                FRIENDS = vm.FRIENDS,
                ABANDONED = vm.ABANDONED,
                CLOSEFRND = vm.CLOSEFRND,
                PARENTCOMM = vm.PARENTCOMM,
                CHILDCOMM = vm.CHILDCOMM,
                FRIENDCOMM = vm.FRIENDCOMM,
                PARTICIPATE = vm.PARTICIPATE,
                SAFEHOME = vm.SAFEHOME,
                SAFECOMM = vm.SAFECOMM,
                DELAYMED = vm.DELAYMED,
                SCRIPTPROB = vm.SCRIPTPROB,
                MISSEDFUP = vm.MISSEDFUP,
                DOCADVICE = vm.DOCADVICE,
                HEALTHACC = vm.HEALTHACC,
                LESSCOURT = vm.LESSCOURT,
                POORSERV = vm.POORSERV,
                NOTSMART = vm.NOTSMART,
                ACTAFRAID = vm.ACTAFRAID,
                THREATENED = vm.THREATENED,
                POORMEDTRT = vm.POORMEDTRT,
                EXPANCEST = vm.EXPANCEST,
                EXPGENDER = vm.EXPGENDER,
                EXPRACE = vm.EXPRACE,
                EXPAGE = vm.EXPAGE,
                EXPRELIG = vm.EXPRELIG,
                EXPHEIGHT = vm.EXPHEIGHT,
                EXPWEIGHT = vm.EXPWEIGHT,
                EXPAPPEAR = vm.EXPAPPEAR,
                EXPSEXORN = vm.EXPSEXORN,
                EXPEDUCINC = vm.EXPEDUCINC,
                EXPDISAB = vm.EXPDISAB,
                EXPSKIN = vm.EXPSKIN,
                EXPOTHER = vm.EXPOTHER,
                EXPNOTAPP = vm.EXPNOTAPP,
                EXPNOANS = vm.EXPNOANS,
                EXPSTRS = vm.EXPSTRS
            };
        }

        public static IFormFields GetFormFields(this A2 vm)
        {
            return new A2FormFields
            {
                NEWINF = vm.NEWINF,
                INRELTO = vm.INRELTO,
                INKNOWN = vm.INKNOWN,
                INLIVWTH = vm.INLIVWTH,
                INCNTMOD = vm.INCNTMOD,
                INCNTMDX = vm.INCNTMDX,
                INCNTFRQ = vm.INCNTFRQ,
                INCNTTIM = vm.INCNTTIM,
                INRELY = vm.INRELY,
                INMEMWORS = vm.INMEMWORS,
                INMEMTROUB = vm.INMEMTROUB,
                INMEMTEN = vm.INMEMTEN,

            };
        }

        public static IFormFields GetFormFields(this A3 vm)
        {
            return new A3FormFields
            {
                AFFFAMM = vm.AFFFAMM,
                NWINFMUT = vm.NWINFMUT,
                MOMYOB = vm.MOMYOB,
                MOMDAGE = vm.MOMDAGE,
                MOMETPR = vm.MOMETPR,
                MOMETSEC = vm.MOMETSEC,
                MOMMEVAL = vm.MOMMEVAL,
                MOMAGEO = vm.MOMAGEO,
                DADYOB = vm.DADYOB,
                DADDAGE = vm.DADDAGE,
                DADETPR = vm.DADETPR,
                DADETSEC = vm.DADETSEC,
                DADMEVAL = vm.DADMEVAL,
                DADAGEO = vm.DADAGEO,
                SIBS = vm.SIBS,
                NWINFSIB = vm.NWINFSIB,
                KIDS = vm.KIDS,
                NWINFKID = vm.NWINFKID,
                SiblingFormFields = vm.Siblings.Select(s => s.ToEntity()).ToList(),
                KidsFormFields = vm.Children.Select(c => c.ToEntity()).ToList()
            };
        }

        public static A3FamilyMemberFormFields ToEntity(this A3FamilyMember vm)
        {
            return new A3FamilyMemberFormFields()
            {
                FamilyMemberIndex = vm.FamilyMemberIndex,
                YOB = vm.YOB,
                AGD = vm.AGD,
                ETPR = vm.ETPR,
                ETSEC = vm.ETSEC,
                MEVAL = vm.MEVAL,
                AGO = vm.AGO
            };
        }

        public static IFormFields GetFormFields(this A4 vm)
        {
            return new A4GFormFields
            {
                ANYMEDS = vm.ANYMEDS,
                A4Ds = vm.DrugIds.Select(d => d.ToEntity()).ToList()
            };
        }

        public static A4DFormFields ToEntity(this DrugCodeModel vm)
        {

            return new A4DFormFields
            {
                Id = vm.Id.HasValue ? vm.Id.Value : 0,
                RxNormId = vm.RxNormId,
                CreatedAt = vm.CreatedAt,
                CreatedBy = vm.CreatedBy,
                ModifiedBy = vm.ModifiedBy,
                DeletedBy = vm.DeletedBy,
                IsDeleted = vm.IsDeleted.HasValue ? vm.IsDeleted.Value : false
            };

        }

        public static IFormFields GetFormFields(this A4a vm)
        {
            return new A4aFormFields
            {
                ADVEVENT = vm.ADVEVENT,
                ARIAE = vm.ARIAE,
                ARIAH = vm.ARIAH,
                ADVERSEOTH = vm.ADVERSEOTH,
                ADVERSEOTX = vm.ADVERSEOTX,
                TRTBIOMARK = vm.TRTBIOMARK,
                TreatmentFormFields = vm.Treatments.Select(s => s.ToEntity()).ToList()
            };
        }

        public static A4aTreatmentFormFields ToEntity(this A4aTreatment vm)
        {
            return new A4aTreatmentFormFields()
            {
                TreatmentIndex = vm.TreatmentIndex,
                TARGETAB = vm.TARGETAB,
                TARGETTAU = vm.TARGETTAU,
                TARGETINF = vm.TARGETINF,
                TARGETSYN = vm.TARGETSYN,
                TARGETOTH = vm.TARGETOTH,
                TARGETOTX = vm.TARGETOTX,
                TRTTRIAL = vm.TRTTRIAL,
                NCTNUM = vm.NCTNUM,
                STARTMO = vm.STARTMO,
                STARTYEAR = vm.STARTYEAR,
                ENDMO = vm.ENDMO,
                ENDYEAR = vm.ENDYEAR,
                CARETRIAL = vm.CARETRIAL,
                TRIALGRP = vm.TRIALGRP
            };
        }


        public static IFormFields GetFormFields(this A5D2 vm)
        {
            return new A5D2FormFields
            {
                TOBAC100 = vm.TOBAC100,
                SMOKYRS = vm.SMOKYRS,
                PACKSPER = vm.PACKSPER,
                TOBAC30 = vm.TOBAC30,
                QUITSMOK = vm.QUITSMOK,
                ALCFREQYR = vm.ALCFREQYR,
                ALCDRINKS = vm.ALCDRINKS,
                ALCBINGE = vm.ALCBINGE,
                SUBSTYEAR = vm.SUBSTYEAR,
                SUBSTPAST = vm.SUBSTPAST,
                CANNABIS = vm.CANNABIS,
                HRTATTACK = vm.HRTATTACK,
                HRTATTMULT = vm.HRTATTMULT,
                HRTATTAGE = vm.HRTATTAGE,
                CARDARREST = vm.CARDARREST,
                CARDARRAGE = vm.CARDARRAGE,
                CVAFIB = vm.CVAFIB,
                CVANGIO = vm.CVANGIO,
                CVBYPASS = vm.CVBYPASS,
                BYPASSAGE = vm.BYPASSAGE,
                CVPACDEF = vm.CVPACDEF,
                PACDEFAGE = vm.PACDEFAGE,
                CVCHF = vm.CVCHF,
                CVHVALVE = vm.CVHVALVE,
                VALVEAGE = vm.VALVEAGE,
                CVOTHR = vm.CVOTHR,
                CVOTHRX = vm.CVOTHRX,
                CBSTROKE = vm.CBSTROKE,
                STROKMUL = vm.STROKMUL,
                STROKAGE = vm.STROKAGE,
                STROKSTAT = vm.STROKSTAT,
                ANGIOCP = vm.ANGIOCP,
                CAROTIDAGE = vm.CAROTIDAGE,
                CBTIA = vm.CBTIA,
                TIAAGE = vm.TIAAGE,
                PD = vm.PD,
                PDAGE = vm.PDAGE,
                PDOTHR = vm.PDOTHR,
                PDOTHRAGE = vm.PDOTHRAGE,
                SEIZURES = vm.SEIZURES,
                SEIZNUM = vm.SEIZNUM,
                SEIZAGE = vm.SEIZAGE,
                HEADACHE = vm.HEADACHE,
                MS = vm.MS,
                HYDROCEPH = vm.HYDROCEPH,
                HEADIMP = vm.HEADIMP,
                IMPAMFOOT = vm.IMPAMFOOT,
                IMPSOCCER = vm.IMPSOCCER,
                IMPHOCKEY = vm.IMPHOCKEY,
                IMPBOXING = vm.IMPBOXING,
                IMPSPORT = vm.IMPSPORT,
                IMPIPV = vm.IMPIPV,
                IMPMILIT = vm.IMPMILIT,
                IMPASSAULT = vm.IMPASSAULT,
                IMPOTHER = vm.IMPOTHER,
                IMPOTHERX = vm.IMPOTHERX,
                IMPYEARS = vm.IMPYEARS,
                HEADINJURY = vm.HEADINJURY,
                HEADINJUNC = vm.HEADINJUNC,
                HEADINJCON = vm.HEADINJCON,
                HEADINJNUM = vm.HEADINJNUM,
                FIRSTTBI = vm.FIRSTTBI,
                LASTTBI = vm.LASTTBI,
                DIABETES = vm.DIABETES,
                DIABTYPE = vm.DIABTYPE,
                DIABINS = vm.DIABINS,
                DIABMEDS = vm.DIABMEDS,
                DIABGLP1 = vm.DIABGLP1,
                DIABRECACT = vm.DIABRECACT,
                DIABDIET = vm.DIABDIET,
                DIABUNK = vm.DIABUNK,
                DIABAGE = vm.DIABAGE,
                HYPERTEN = vm.HYPERTEN,
                HYPERTAGE = vm.HYPERTAGE,
                HYPERCHO = vm.HYPERCHO,
                HYPERCHAGE = vm.HYPERCHAGE,
                B12DEF = vm.B12DEF,
                THYROID = vm.THYROID,
                ARTHRIT = vm.ARTHRIT,
                ARTHRRHEUM = vm.ARTHRRHEUM,
                ARTHROSTEO = vm.ARTHROSTEO,
                ARTHROTHR = vm.ARTHROTHR,
                ARTHTYPX = vm.ARTHTYPX,
                ARTHTYPUNK = vm.ARTHTYPUNK,
                ARTHUPEX = vm.ARTHUPEX,
                ARTHLOEX = vm.ARTHLOEX,
                ARTHSPIN = vm.ARTHSPIN,
                ARTHUNK = vm.ARTHUNK,
                INCONTU = vm.INCONTU,
                INCONTF = vm.INCONTF,
                APNEA = vm.APNEA,
                CPAP = vm.CPAP,
                APNEAORAL = vm.APNEAORAL,
                RBD = vm.RBD,
                INSOMN = vm.INSOMN,
                OTHSLEEP = vm.OTHSLEEP,
                OTHSLEEX = vm.OTHSLEEX,
                CANCERACTV = vm.CANCERACTV,
                CANCERPRIM = vm.CANCERPRIM,
                CANCERMETA = vm.CANCERMETA,
                CANCMETBR = vm.CANCMETBR,
                CANCMETOTH = vm.CANCMETOTH,
                CANCERUNK = vm.CANCERUNK,
                CANCBLOOD = vm.CANCBLOOD,
                CANCBREAST = vm.CANCBREAST,
                CANCCOLON = vm.CANCCOLON,
                CANCLUNG = vm.CANCLUNG,
                CANCPROST = vm.CANCPROST,
                CANCOTHER = vm.CANCOTHER,
                CANCOTHERX = vm.CANCOTHERX,
                CANCRAD = vm.CANCRAD,
                CANCRESECT = vm.CANCRESECT,
                CANCIMMUNO = vm.CANCIMMUNO,
                CANCBONE = vm.CANCBONE,
                CANCCHEMO = vm.CANCCHEMO,
                CANCHORM = vm.CANCHORM,
                CANCTROTH = vm.CANCTROTH,
                CANCTROTHX = vm.CANCTROTHX,
                CANCERAGE = vm.CANCERAGE,
                COVID19 = vm.COVID19,
                COVIDHOSP = vm.COVIDHOSP,
                PULMONARY = vm.PULMONARY,
                KIDNEY = vm.KIDNEY,
                KIDNEYAGE = vm.KIDNEYAGE,
                LIVER = vm.LIVER,
                LIVERAGE = vm.LIVERAGE,
                PVD = vm.PVD,
                PVDAGE = vm.PVDAGE,
                HIVDIAG = vm.HIVDIAG,
                HIVAGE = vm.HIVAGE,
                OTHERCOND = vm.OTHERCOND,
                OTHCONDX = vm.OTHCONDX,
                MAJORDEP = vm.MAJORDEP,
                OTHERDEP = vm.OTHERDEP,
                DEPRTREAT = vm.DEPRTREAT,
                BIPOLAR = vm.BIPOLAR,
                SCHIZ = vm.SCHIZ,
                ANXIETY = vm.ANXIETY,
                GENERALANX = vm.GENERALANX,
                PANICDIS = vm.PANICDIS,
                OCD = vm.OCD,
                OTHANXDIS = vm.OTHANXDIS,
                OTHANXDISX = vm.OTHANXDISX,
                PTSD = vm.PTSD,
                NPSYDEV = vm.NPSYDEV,
                PSYCDIS = vm.PSYCDIS,
                PSYCDISX = vm.PSYCDISX,
                MENARCHE = vm.MENARCHE,
                NOMENSAGE = vm.NOMENSAGE,
                NOMENSNAT = vm.NOMENSNAT,
                NOMENSHYST = vm.NOMENSHYST,
                NOMENSSURG = vm.NOMENSSURG,
                NOMENSCHEM = vm.NOMENSCHEM,
                NOMENSRAD = vm.NOMENSRAD,
                NOMENSHORM = vm.NOMENSHORM,
                NOMENSESTR = vm.NOMENSESTR,
                NOMENSUNK = vm.NOMENSUNK,
                NOMENSOTH = vm.NOMENSOTH,
                NOMENSOTHX = vm.NOMENSOTHX,
                HRT = vm.HRT,
                HRTYEARS = vm.HRTYEARS,
                HRTSTRTAGE = vm.HRTSTRTAGE,
                HRTENDAGE = vm.HRTENDAGE,
                BCPILLS = vm.BCPILLS,
                BCPILLSYR = vm.BCPILLSYR,
                BCSTARTAGE = vm.BCSTARTAGE,
                BCENDAGE = vm.BCENDAGE
            };
        }

        public static IFormFields GetFormFields(this B1 vm)
        {
            return new B1FormFields
            {
                HEIGHT = vm.HEIGHT,
                WEIGHT = vm.WEIGHT,
                WAIST1 = vm.WAIST1,
                WAIST2 = vm.WAIST2,
                HIP1 = vm.HIP1,
                HIP2 = vm.HIP2,
                BPSYSL1 = vm.BPSYSL1,
                BPDIASL1 = vm.BPDIASL1,
                BPSYSL2 = vm.BPSYSL2,
                BPDIASL2 = vm.BPDIASL2,
                BPSYSR1 = vm.BPSYSR1,
                BPDIASR1 = vm.BPDIASR1,
                BPSYSR2 = vm.BPSYSR2,
                BPDIASR2 = vm.BPDIASR2,
                HRATE = vm.HRATE
            };
        }

        public static IFormFields GetFormFields(this B3 vm)
        {
            return new B3FormFields
            {
                PDNORMAL = vm.PDNORMAL,
                SPEECH = vm.SPEECH,
                SPEECHX = vm.SPEECHX,
                FACEXP = vm.FACEXP,
                FACEXPX = vm.FACEXPX,
                TRESTFAC = vm.TRESTFAC,
                TRESTFAX = vm.TRESTFAX,
                TRESTRHD = vm.TRESTRHD,
                TRESTRHX = vm.TRESTRHX,
                TRESTLHD = vm.TRESTLHD,
                TRESTLHX = vm.TRESTLHX,
                TRESTRFT = vm.TRESTRFT,
                TRESTRFX = vm.TRESTRFX,
                TRESTLFT = vm.TRESTLFT,
                TRESTLFX = vm.TRESTLFX,
                TRACTRHD = vm.TRACTRHD,
                TRACTRHX = vm.TRACTRHX,
                TRACTLHD = vm.TRACTLHD,
                TRACTLHX = vm.TRACTLHX,
                RIGDNECK = vm.RIGDNECK,
                RIGDNEX = vm.RIGDNEX,
                RIGDUPRT = vm.RIGDUPRT,
                RIGDUPRX = vm.RIGDUPRX,
                RIGDUPLF = vm.RIGDUPLF,
                RIGDUPLX = vm.RIGDUPLX,
                RIGDLORT = vm.RIGDLORT,
                RIGDLORX = vm.RIGDLORX,
                RIGDLOLF = vm.RIGDLOLF,
                RIGDLOLX = vm.RIGDLOLX,
                TAPSRT = vm.TAPSRT,
                TAPSRTX = vm.TAPSRTX,
                TAPSLF = vm.TAPSLF,
                TAPSLFX = vm.TAPSLFX,
                HANDMOVR = vm.HANDMOVR,
                HANDMVRX = vm.HANDMVRX,
                HANDMOVL = vm.HANDMOVL,
                HANDMVLX = vm.HANDMVLX,
                HANDALTR = vm.HANDALTR,
                HANDATRX = vm.HANDATRX,
                HANDALTL = vm.HANDALTL,
                HANDATLX = vm.HANDATLX,
                LEGRT = vm.LEGRT,
                LEGRTX = vm.LEGRTX,
                LEGLF = vm.LEGLF,
                LEGLFX = vm.LEGLFX,
                ARISING = vm.ARISING,
                ARISINGX = vm.ARISINGX,
                POSTURE = vm.POSTURE,
                POSTUREX = vm.POSTUREX,
                GAIT = vm.GAIT,
                GAITX = vm.GAITX,
                POSSTAB = vm.POSSTAB,
                POSSTABX = vm.POSSTABX,
                BRADYKIN = vm.BRADYKIN,
                BRADYKIX = vm.BRADYKIX,
                TOTALUPDRS = vm.TOTALUPDRS
            };

        }
        public static IFormFields GetFormFields(this B4 vm)
        {
            return new B4FormFields
            {
                MEMORY = vm.MEMORY,
                ORIENT = vm.ORIENT,
                JUDGMENT = vm.JUDGMENT,
                COMMUN = vm.COMMUN,
                HOMEHOBB = vm.HOMEHOBB,
                PERSCARE = vm.PERSCARE,
                CDRSUM = vm.CDRSUM,
                CDRGLOB = vm.CDRGLOB,
                COMPORT = vm.COMPORT,
                CDRLANG = vm.CDRLANG,
            };
        }

        public static IFormFields GetFormFields(this B5 vm)
        {
            return new B5FormFields
            {
                NPIQINF = vm.NPIQINF,
                NPIQINFX = vm.NPIQINFX,
                DEL = vm.DEL,
                DELSEV = vm.DELSEV,
                HALL = vm.HALL,
                HALLSEV = vm.HALLSEV,
                AGIT = vm.AGIT,
                AGITSEV = vm.AGITSEV,
                DEPD = vm.DEPD,
                DEPDSEV = vm.DEPDSEV,
                ANX = vm.ANX,
                ANXSEV = vm.ANXSEV,
                ELAT = vm.ELAT,
                ELATSEV = vm.ELATSEV,
                APA = vm.APA,
                APASEV = vm.APASEV,
                DISN = vm.DISN,
                DISNSEV = vm.DISNSEV,
                IRR = vm.IRR,
                IRRSEV = vm.IRRSEV,
                MOT = vm.MOT,
                MOTSEV = vm.MOTSEV,
                NITE = vm.NITE,
                NITESEV = vm.NITESEV,
                APP = vm.APP,
                APPSEV = vm.APPSEV
            };
        }

        public static IFormFields GetFormFields(this B6 vm)
        {
            return new B6FormFields
            {
                NOGDS = vm.NOGDS ? 1 : 0,
                SATIS = vm.SATIS,
                DROPACT = vm.DROPACT,
                EMPTY = vm.EMPTY,
                BORED = vm.BORED,
                SPIRITS = vm.SPIRITS,
                AFRAID = vm.AFRAID,
                HAPPY = vm.HAPPY,
                HELPLESS = vm.HELPLESS,
                STAYHOME = vm.STAYHOME,
                MEMPROB = vm.MEMPROB,
                WONDRFUL = vm.WONDRFUL,
                WRTHLESS = vm.WRTHLESS,
                ENERGY = vm.ENERGY,
                HOPELESS = vm.HOPELESS,
                BETTER = vm.BETTER,
                GDS = vm.GDS
            };
        }

        public static IFormFields GetFormFields(this B7 vm)
        {
            return new B7FormFields
            {
                BILLS = vm.BILLS,
                TAXES = vm.TAXES,
                SHOPPING = vm.SHOPPING,
                GAMES = vm.GAMES,
                STOVE = vm.STOVE,
                MEALPREP = vm.MEALPREP,
                EVENTS = vm.EVENTS,
                PAYATTN = vm.PAYATTN,
                REMDATES = vm.REMDATES,
                TRAVEL = vm.TRAVEL
            };
        }

        public static IFormFields GetFormFields(this B8 vm)
        {
            return new B8FormFields
            {

                NEUREXAM = vm.NEUREXAM,
                NORMNREXAM = vm.NORMNREXAM.HasValue ? vm.NORMNREXAM.Value != 0 : false,
                PARKSIGN = vm.PARKSIGN,
                SLOWINGFM = vm.SLOWINGFM,
                TREMREST = vm.TREMREST,
                TREMPOST = vm.TREMPOST,
                TREMKINE = vm.TREMKINE,
                RIGIDARM = vm.RIGIDARM,
                RIGIDLEG = vm.RIGIDLEG,
                DYSTARM = vm.DYSTARM,
                DYSTLEG = vm.DYSTLEG,
                CHOREA = vm.CHOREA,
                AMPMOTOR = vm.AMPMOTOR,
                AXIALRIG = vm.AXIALRIG,
                POSTINST = vm.POSTINST,
                MASKING = vm.MASKING,
                STOOPED = vm.STOOPED,
                OTHERSIGN = vm.OTHERSIGN,
                LIMBAPRAX = vm.LIMBAPRAX,
                UMNDIST = vm.UMNDIST,
                LMNDIST = vm.LMNDIST,
                VFIELDCUT = vm.VFIELDCUT,
                LIMBATAX = vm.LIMBATAX,
                MYOCLON = vm.MYOCLON,
                UNISOMATO = vm.UNISOMATO,
                APHASIA = vm.APHASIA,
                ALIENLIMB = vm.ALIENLIMB,
                HSPATNEG = vm.HSPATNEG,
                PSPOAGNO = vm.PSPOAGNO,
                SMTAGNO = vm.SMTAGNO,
                OPTICATAX = vm.OPTICATAX,
                APRAXGAZE = vm.APRAXGAZE,
                VHGAZEPAL = vm.VHGAZEPAL,
                DYSARTH = vm.DYSARTH,
                APRAXSP = vm.APRAXSP,
                GAITABN = vm.GAITABN,
                GAITFIND = vm.GAITFIND,
                GAITOTHRX = vm.GAITOTHRX
            };
        }

        public static IFormFields GetFormFields(this B9 vm)
        {
            return new B9FormFields
            {
                DECCOG = vm.DECCOG,
                DECMOT = vm.DECMOT,
                PSYCHSYM = vm.PSYCHSYM,
                DECCOGIN = vm.DECCOGIN,
                DECMOTIN = vm.DECMOTIN,
                PSYCHSYMIN = vm.PSYCHSYMIN,
                DECCLIN = vm.DECCLIN,
                DECCLCOG = vm.DECCLCOG,
                COGMEM = vm.COGMEM,
                COGORI = vm.COGORI,
                COGJUDG = vm.COGJUDG,
                COGLANG = vm.COGLANG,
                COGVIS = vm.COGVIS,
                COGATTN = vm.COGATTN,
                COGFLUC = vm.COGFLUC,
                COGOTHR = vm.COGOTHR,
                COGOTHRX = vm.COGOTHRX,
                COGAGE = vm.COGAGE,
                COGMODE = vm.COGMODE,
                COGMODEX = vm.COGMODEX,
                DECCLBE = vm.DECCLBE,
                BEAPATHY = vm.BEAPATHY,
                BEDEP = vm.BEDEP,
                BEANX = vm.BEANX,
                BEEUPH = vm.BEEUPH,
                BEIRRIT = vm.BEIRRIT,
                BEAGIT = vm.BEAGIT,
                BEHAGE = vm.BEHAGE,
                BEVHALL = vm.BEVHALL,
                BEVPATT = vm.BEVPATT,
                BEVWELL = vm.BEVWELL,
                BEAHALL = vm.BEAHALL,
                BEAHSIMP = vm.BEAHSIMP,
                BEAHCOMP = vm.BEAHCOMP,
                BEDEL = vm.BEDEL,
                BEAGGRS = vm.BEAGGRS,
                PSYCHAGE = vm.PSYCHAGE,
                BEDISIN = vm.BEDISIN,
                BEPERCH = vm.BEPERCH,
                BEEMPATH = vm.BEEMPATH,
                BEOBCOM = vm.BEOBCOM,
                BEANGER = vm.BEANGER,
                BESUBAB = vm.BESUBAB,
                ALCUSE = vm.ALCUSE,
                SEDUSE = vm.SEDUSE,
                OPIATEUSE = vm.OPIATEUSE,
                COCAINEUSE = vm.COCAINEUSE,
                CANNABUSE = vm.CANNABUSE,
                OTHSUBUSE = vm.OTHSUBUSE,
                OTHSUBUSEX = vm.OTHSUBUSEX,
                PERCHAGE = vm.PERCHAGE,
                BEREM = vm.BEREM,
                BEREMAGO = vm.BEREMAGO,
                BEREMCONF = vm.BEREMCONF,
                BEOTHR = vm.BEOTHR,
                BEOTHRX = vm.BEOTHRX,
                BEMODE = vm.BEMODE,
                BEMODEX = vm.BEMODEX,
                DECCLMOT = vm.DECCLMOT,
                MOGAIT = vm.MOGAIT,
                MOFALLS = vm.MOFALLS,
                MOSLOW = vm.MOSLOW,
                MOTREM = vm.MOTREM,
                MOLIMB = vm.MOLIMB,
                MOFACE = vm.MOFACE,
                MOSPEECH = vm.MOSPEECH,
                MOTORAGE = vm.MOTORAGE,
                MOMODE = vm.MOMODE,
                MOMODEX = vm.MOMODEX,
                MOMOPARK = vm.MOMOPARK,
                MOMOALS = vm.MOMOALS,
                COURSE = vm.COURSE,
                FRSTCHG = vm.FRSTCHG,
            };
        }
        public static IFormFields GetFormFields(this C2 vm)
        {
            return new C2FormFields
            {
                MODCOMM = vm.MODCOMM,
                MOCACOMP = vm.MOCACOMP,
                MOCAREAS = vm.MOCAREAS,
                MOCALOC = vm.MOCALOC,
                MOCALAN = vm.MOCALAN,
                MOCALANX = vm.MOCALANX,
                MOCAVIS = vm.MOCAVIS,
                MOCAHEAR = vm.MOCAHEAR,
                MOCATOTS = vm.MOCATOTS,
                MOCBTOTS = vm.MOCBTOTS,
                MOCATRAI = vm.MOCATRAI,
                MOCACUBE = vm.MOCACUBE,
                MOCACLOC = vm.MOCACLOC,
                MOCACLON = vm.MOCACLON,
                MOCACLOH = vm.MOCACLOH,
                MOCANAMI = vm.MOCANAMI,
                MOCAREGI = vm.MOCAREGI,
                MOCADIGI = vm.MOCADIGI,
                MOCALETT = vm.MOCALETT,
                MOCASER7 = vm.MOCASER7,
                MOCAREPE = vm.MOCAREPE,
                MOCAFLUE = vm.MOCAFLUE,
                MOCAABST = vm.MOCAABST,
                MOCARECN = vm.MOCARECN,
                MOCARECC = vm.MOCARECC,
                MOCARECR = vm.MOCARECR,
                MOCAORDT = vm.MOCAORDT,
                MOCAORMO = vm.MOCAORMO,
                MOCAORYR = vm.MOCAORYR,
                MOCAORDY = vm.MOCAORDY,
                MOCAORPL = vm.MOCAORPL,
                MOCAORCT = vm.MOCAORCT,
                NPSYCLOC = vm.NPSYCLOC,
                NPSYLAN = vm.NPSYLAN,
                NPSYLANX = vm.NPSYLANX,
                CRAFTVRS = vm.CRAFTVRS,
                CRAFTURS = vm.CRAFTURS,
                UDSBENTC = vm.UDSBENTC,
                DIGFORCT = vm.DIGFORCT,
                DIGFORSL = vm.DIGFORSL,
                DIGBACCT = vm.DIGBACCT,
                DIGBACLS = vm.DIGBACLS,
                ANIMALS = vm.ANIMALS,
                VEG = vm.VEG,
                TRAILA = vm.TRAILA,
                TRAILARR = vm.TRAILARR,
                TRAILALI = vm.TRAILALI,
                TRAILB = vm.TRAILB,
                TRAILBRR = vm.TRAILBRR,
                TRAILBLI = vm.TRAILBLI,
                CRAFTDVR = vm.CRAFTDVR,
                CRAFTDRE = vm.CRAFTDRE,
                CRAFTDTI = vm.CRAFTDTI,
                CRAFTCUE = vm.CRAFTCUE,
                UDSBENTD = vm.UDSBENTD,
                UDSBENRS = vm.UDSBENRS,
                MINTTOTS = vm.MINTTOTS,
                MINTTOTW = vm.MINTTOTW,
                MINTSCNG = vm.MINTSCNG,
                MINTSCNC = vm.MINTSCNC,
                MINTPCNG = vm.MINTPCNG,
                MINTPCNC = vm.MINTPCNC,
                UDSVERFC = vm.UDSVERFC,
                UDSVERFN = vm.UDSVERFN,
                UDSVERNF = vm.UDSVERNF,
                UDSVERLC = vm.UDSVERLC,
                UDSVERLR = vm.UDSVERLR,
                UDSVERLN = vm.UDSVERLN,
                UDSVERTN = vm.UDSVERTN,
                UDSVERTE = vm.UDSVERTE,
                UDSVERTI = vm.UDSVERTI,
                VERBALTEST = vm.VERBALTEST,
                COGSTAT = vm.COGSTAT,
                REY1REC = vm.REY1REC,
                REY1INT = vm.REY1INT,
                REY2REC = vm.REY2REC,
                REY2INT = vm.REY2INT,
                REY3REC = vm.REY3REC,
                REY3INT = vm.REY3INT,
                REY4REC = vm.REY4REC,
                REY4INT = vm.REY4INT,
                REY5REC = vm.REY5REC,
                REY5INT = vm.REY5INT,
                REYBREC = vm.REYBREC,
                REYBINT = vm.REYBINT,
                REY6REC = vm.REY6REC,
                REY6INT = vm.REY6INT,
                REYDREC = vm.REYDREC,
                REYDINT = vm.REYDINT,
                REYDTI = vm.REYDTI,
                REYMETHOD = vm.REYMETHOD,
                REYTCOR = vm.REYTCOR,
                REYFPOS = vm.REYFPOS,
                CERAD1REC = vm.CERAD1REC,
                CERAD1READ = vm.CERAD1READ,
                CERAD1INT = vm.CERAD1INT,
                CERAD2REC = vm.CERAD2REC,
                CERAD2READ = vm.CERAD2READ,
                CERAD2INT = vm.CERAD2INT,
                CERAD3REC = vm.CERAD3REC,
                CERAD3READ = vm.CERAD3READ,
                CERAD3INT = vm.CERAD3INT,
                CERADDTI = vm.CERADDTI,
                CERADJ6REC = vm.CERADJ6REC,
                CERADJ6INT = vm.CERADJ6INT,
                CERADJ7YES = vm.CERADJ7YES,
                CERADJ7NO = vm.CERADJ7NO,
                OTRAILA = vm.OTRAILA,
                OTRLARR = vm.OTRLARR,
                OTRLALI = vm.OTRLALI,
                OTRAILB = vm.OTRAILB,
                OTRLBRR = vm.OTRLBRR,
                OTRLBLI = vm.OTRLBLI,
                VNTTOTW = vm.VNTTOTW,
                VNTPCNC = vm.VNTPCNC,
                RESPVAL = vm.RESPVAL,
                RESPHEAR = vm.RESPHEAR ? 1 : 0,
                RESPDIST = vm.RESPDIST ? 1 : 0,
                RESPINTR = vm.RESPINTR ? 1 : 0,
                RESPDISN = vm.RESPDISN ? 1 : 0,
                RESPFATG = vm.RESPFATG ? 1 : 0,
                RESPEMOT = vm.RESPEMOT ? 1 : 0,
                RESPASST = vm.RESPASST ? 1 : 0,
                RESPOTH = vm.RESPOTH ? 1 : 0,
                RESPOTHX = vm.RESPOTHX
            };
        }

        public static IFormFields GetFormFields(this D1a vm)
        {
            return new D1aFormFields
            {
                DXMETHOD = vm.DXMETHOD,
                NORMCOG = vm.NORMCOG,
                SCD = vm.SCD,
                SCDDXCONF = vm.SCDDXCONF,
                DEMENTED = vm.DEMENTED,
                MCICRITCLN = vm.MCICRITCLN,
                MCICRITIMP = vm.MCICRITIMP,
                MCICRITFUN = vm.MCICRITFUN,
                MCI = vm.MCI,
                IMPNOMCIFU = vm.IMPNOMCIFU,
                IMPNOMCICG = vm.IMPNOMCICG,
                IMPNOMCLCD = vm.IMPNOMCLCD,
                IMPNOMCIO = vm.IMPNOMCIO,
                IMPNOMCIOX = vm.IMPNOMCIOX,
                IMPNOMCI = vm.IMPNOMCI.HasValue ? vm.IMPNOMCI.Value != 0 : false,
                CDOMMEM = vm.CDOMMEM,
                CDOMLANG = vm.CDOMLANG,
                CDOMATTN = vm.CDOMATTN,
                CDOMEXEC = vm.CDOMEXEC,
                CDOMVISU = vm.CDOMVISU,
                CDOMBEH = vm.CDOMBEH,
                CDOMAPRAX = vm.CDOMAPRAX,
                MBI = vm.MBI,
                BDOMMOT = vm.BDOMMOT,
                BDOMAFREG = vm.BDOMAFREG,
                BDOMIMP = vm.BDOMIMP,
                BDOMSOCIAL = vm.BDOMSOCIAL,
                BDOMTHTS = vm.BDOMTHTS,
                PREDOMSYN = vm.PREDOMSYN,
                AMNDEM = vm.AMNDEM,
                DYEXECSYN = vm.DYEXECSYN,
                PCA = vm.PCA,
                PPASYN = vm.PPASYN,
                PPASYNT = vm.PPASYNT,
                FTDSYN = vm.FTDSYN,
                LBDSYN = vm.LBDSYN,
                LBDSYNT = vm.LBDSYNT,
                NAMNDEM = vm.NAMNDEM,
                PSPSYN = vm.PSPSYN,
                PSPSYNT = vm.PSPSYNT,
                CTESYN = vm.CTESYN,
                CBSSYN = vm.CBSSYN,
                MSASYN = vm.MSASYN,
                MSASYNT = vm.MSASYNT,
                OTHSYN = vm.OTHSYN,
                OTHSYNX = vm.OTHSYNX,
                SYNINFCLIN = vm.SYNINFCLIN,
                SYNINFCTST = vm.SYNINFCTST,
                SYNINFBIOM = vm.SYNINFBIOM,
                MAJDEPDX = vm.MAJDEPDX,
                MAJDEPDIF = vm.MAJDEPDIF,
                OTHDEPDX = vm.OTHDEPDX,
                OTHDEPDIF = vm.OTHDEPDIF,
                BIPOLDX = vm.BIPOLDX,
                BIPOLDIF = vm.BIPOLDIF,
                SCHIZOP = vm.SCHIZOP,
                SCHIZOIF = vm.SCHIZOIF,
                ANXIET = vm.ANXIET,
                ANXIETIF = vm.ANXIETIF,
                GENANX = vm.GENANX,
                PANICDISDX = vm.PANICDISDX,
                OCDDX = vm.OCDDX,
                OTHANXD = vm.OTHANXD,
                OTHANXDX = vm.OTHANXDX,
                PTSDDX = vm.PTSDDX,
                PTSDDXIF = vm.PTSDDXIF,
                NDEVDIS = vm.NDEVDIS,
                NDEVDISIF = vm.NDEVDISIF,
                DELIR = vm.DELIR,
                DELIRIF = vm.DELIRIF,
                OTHPSY = vm.OTHPSY,
                OTHPSYIF = vm.OTHPSYIF,
                OTHPSYX = vm.OTHPSYX,
                TBIDX = vm.TBIDX,
                TBIDXIF = vm.TBIDXIF,
                EPILEP = vm.EPILEP,
                EPILEPIF = vm.EPILEPIF,
                HYCEPH = vm.HYCEPH,
                HYCEPHIF = vm.HYCEPHIF,
                NEOP = vm.NEOP,
                NEOPIF = vm.NEOPIF,
                NEOPSTAT = vm.NEOPSTAT,
                HIV = vm.HIV,
                HIVIF = vm.HIVIF,
                POSTC19 = vm.POSTC19,
                POSTC19IF = vm.POSTC19IF,
                APNEADX = vm.APNEADX,
                APNEADXIF = vm.APNEADXIF,
                OTHCOGILL = vm.OTHCOGILL,
                OTHCILLIF = vm.OTHCILLIF,
                OTHCOGILLX = vm.OTHCOGILLX,
                ALCDEM = vm.ALCDEM,
                ALCDEMIF = vm.ALCDEMIF,
                IMPSUB = vm.IMPSUB,
                IMPSUBIF = vm.IMPSUBIF,
                MEDS = vm.MEDS,
                MEDSIF = vm.MEDSIF,
                COGOTH = vm.COGOTH,
                COGOTHIF = vm.COGOTHIF,
                COGOTHX = vm.COGOTHX,
                COGOTH2 = vm.COGOTH2,
                COGOTH2F = vm.COGOTH2F,
                COGOTH2X = vm.COGOTH2X,
                COGOTH3 = vm.COGOTH3,
                COGOTH3F = vm.COGOTH3F,
                COGOTH3X = vm.COGOTH3X
            };
        }

        public static IFormFields GetFormFields(this D1b vm)
        {
            return new D1bFormFields
            {
                BIOMARKDX = vm.BIOMARKDX,
                FLUIDBIOM = vm.FLUIDBIOM,
                BLOODAD = vm.BLOODAD,
                BLOODFTLD = vm.BLOODFTLD,
                BLOODLBD = vm.BLOODLBD,
                BLOODOTH = vm.BLOODOTH,
                BLOODOTHX = vm.BLOODOTHX,
                CSFAD = vm.CSFAD,
                CSFFTLD = vm.CSFFTLD,
                CSFLBD = vm.CSFLBD,
                CSFOTH = vm.CSFOTH,
                CSFOTHX = vm.CSFOTHX,
                IMAGINGDX = vm.IMAGINGDX,
                PETDX = vm.PETDX,
                AMYLPET = vm.AMYLPET,
                TAUPET = vm.TAUPET,
                FDGPETDX = vm.FDGPETDX,
                FDGAD = vm.FDGAD,
                FDGFTLD = vm.FDGFTLD,
                FDGLBD = vm.FDGLBD,
                FDGOTH = vm.FDGOTH,
                FDGOTHX = vm.FDGOTHX,
                DATSCANDX = vm.DATSCANDX,
                TRACOTHDX = vm.TRACOTHDX,
                TRACOTHDXX = vm.TRACOTHDXX,
                TRACERAD = vm.TRACERAD,
                TRACERFTLD = vm.TRACERFTLD,
                TRACERLBD = vm.TRACERLBD,
                TRACEROTH = vm.TRACEROTH,
                TRACEROTHX = vm.TRACEROTHX,
                STRUCTDX = vm.STRUCTDX,
                STRUCTAD = vm.STRUCTAD,
                STRUCTFTLD = vm.STRUCTFTLD,
                STRUCTCVD = vm.STRUCTCVD,
                IMAGLINF = vm.IMAGLINF,
                IMAGLAC = vm.IMAGLAC,
                IMAGMACH = vm.IMAGMACH,
                IMAGMICH = vm.IMAGMICH,
                IMAGMWMH = vm.IMAGMWMH,
                IMAGEWMH = vm.IMAGEWMH,
                OTHBIOM1 = vm.OTHBIOM1,
                OTHBIOMX1 = vm.OTHBIOMX1,
                BIOMAD1 = vm.BIOMAD1,
                BIOMFTLD1 = vm.BIOMFTLD1,
                BIOMLBD1 = vm.BIOMLBD1,
                BIOMOTH1 = vm.BIOMOTH1,
                BIOMOTHX1 = vm.BIOMOTHX1,
                OTHBIOM2 = vm.OTHBIOM2,
                OTHBIOMX2 = vm.OTHBIOMX2,
                BIOMAD2 = vm.BIOMAD2,
                BIOMFTLD2 = vm.BIOMFTLD2,
                BIOMLBD2 = vm.BIOMLBD2,
                BIOMOTH2 = vm.BIOMOTH2,
                BIOMOTHX2 = vm.BIOMOTHX2,
                OTHBIOM3 = vm.OTHBIOM3,
                OTHBIOMX3 = vm.OTHBIOMX3,
                BIOMAD3 = vm.BIOMAD3,
                BIOMFTLD3 = vm.BIOMFTLD3,
                BIOMLBD3 = vm.BIOMLBD3,
                BIOMOTH3 = vm.BIOMOTH3,
                BIOMOTHX3 = vm.BIOMOTHX3,
                AUTDOMMUT = vm.AUTDOMMUT,
                ALZDIS = vm.ALZDIS,
                ALZDISIF = vm.ALZDISIF,
                LBDIS = vm.LBDIS,
                LBDIF = vm.LBDIF,
                FTLD = vm.FTLD,
                FTLDIF = vm.FTLDIF,
                PSP = vm.PSP,
                PSPIF = vm.PSPIF,
                CORT = vm.CORT,
                CORTIF = vm.CORTIF,
                FTLDMO = vm.FTLDMO,
                FTLDMOIF = vm.FTLDMOIF,
                FTLDNOS = vm.FTLDNOS,
                FTLDNOIF = vm.FTLDNOIF,
                FTLDSUBT = vm.FTLDSUBT,
                FTLDSUBX = vm.FTLDSUBX,
                CVD = vm.CVD,
                CVDIF = vm.CVDIF,
                MSA = vm.MSA,
                MSAIF = vm.MSAIF,
                CTE = vm.CTE,
                CTEIF = vm.CTEIF,
                DOWNS = vm.DOWNS,
                DOWNSIF = vm.DOWNSIF,
                HUNT = vm.HUNT,
                HUNTIF = vm.HUNTIF,
                PRION = vm.PRION,
                PRIONIF = vm.PRIONIF,
                CAA = vm.CAA,
                CAAIF = vm.CAAIF,
                LATE = vm.LATE,
                LATEIF = vm.LATEIF,
                OTHCOG = vm.OTHCOG,
                OTHCOGIF = vm.OTHCOGIF,
                OTHCOGX = vm.OTHCOGX
            };
        }
    }
}

