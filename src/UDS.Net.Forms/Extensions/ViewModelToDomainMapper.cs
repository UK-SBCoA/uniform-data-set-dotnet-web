using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;

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
                LastVisitNumber = vm.LastVisitNumber

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
            };
        }

        public static Visit ToEntity(this VisitModel vm)
        {
            return new Visit(vm.Id, vm.Number, vm.ParticipationId, vm.Version, vm.Kind, vm.StartDateTime, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, vm.Forms.ToEntity());
        }

        public static List<Form> ToEntity(this IList<FormModel> vm)
        {
            return vm.Select(v => v.ToEntity()).ToList();
        }

        public static Form ToEntity(this FormModel vm)
        {
            if (vm is A1)
                return ((A1)vm).ToEntity();
            else if (vm is A1a)
                return ((A1a)vm).ToEntity();
            else if (vm is A2)
                return ((A2)vm).ToEntity();
            else if (vm is A3)
                return ((A3)vm).ToEntity();
            else if (vm is A4)
                return ((A4)vm).ToEntity();
            else if (vm is A4a)
                return ((A4a)vm).ToEntity();
            else if (vm is A5)
                return ((A5)vm).ToEntity();
            else if (vm is A5D2)
                return ((A5D2)vm).ToEntity();
            else if (vm is B1)
                return ((B1)vm).ToEntity();
            else if (vm is B3)
                return ((B3)vm).ToEntity();
            else if (vm is B4)
                return ((B4)vm).ToEntity();
            else if (vm is B5)
                return ((B5)vm).ToEntity();
            else if (vm is B6)
                return ((B6)vm).ToEntity();
            else if (vm is B7)
                return ((B7)vm).ToEntity();
            else if (vm is B8)
                return ((B8)vm).ToEntity();
            else if (vm is B9)
                return ((B9)vm).ToEntity();
            else if (vm is C1)
                return ((C1)vm).ToEntity();
            else if (vm is C2)
                return ((C2)vm).ToEntity();
            else if (vm is D1)
                return ((D1)vm).ToEntity();
            else if (vm is D2)
                return ((D2)vm).ToEntity();
            else if (vm is T1)
                return ((T1)vm).ToEntity();
            else
                return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, null);
        }

        public static Form ToEntity(this A1 vm)
        {
            var fields = new A1FormFields
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
                ETHFRENCH = vm.ETHFRENCH ? 1 : 0,
                ETHWHIOTH = vm.ETHWHIOTH ? 1 : 0,
                ETHWHIOTHX = vm.ETHWHIOTHX,
                ETHISPANIC = vm.ETHISPANIC ? 1 : 0,
                ETHMEXICAN = vm.ETHMEXICAN ? 1 : 0,
                ETHPUERTO = vm.ETHPUERTO ? 1 : 0,
                ETHCUBAN = vm.ETHCUBAN ? 1 : 0,
                ETHSALVA = vm.ETHSALVA ? 1 : 0,
                ETHDOMIN = vm.ETHDOMIN ? 1 : 0,
                ETHCOLOM = vm.ETHCOLOM ? 1 : 0,
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
                ETHMOROCCO = vm.ETHMOROCCO ? 1 : 0,
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this A1a vm)
        {
            var fields = new A1aFormFields
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this A2 vm)
        {
            var fields = new A2FormFields
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this A3 vm)
        {
            var fields = new A3FormFields
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
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

        public static Form ToEntity(this A4 vm)
        {
            var fields = new A4GFormFields
            {
                ANYMEDS = vm.ANYMEDS,
                A4Ds = vm.DrugIds.Select(d => d.ToEntity()).ToList()
            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
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

        public static Form ToEntity(this A4a vm)
        {
            var fields = new A4aFormFields
            {
                ADVEVENT = vm.ADVEVENT,
                ARIAE = vm.ARIAE,
                ARIAH = vm.ARIAH,
                ADVERSEOTH = vm.ADVERSEOTH,
                ADVERSEOTX = vm.ADVERSEOTX,
                TRTBIOMARK = vm.TRTBIOMARK,
                TreatmentFormFields = vm.Treatments.Select(s => s.ToEntity()).ToList()
            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
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


        public static Form ToEntity(this A5 vm)
        {
            var fields = new A5FormFields
            {
                TOBAC30 = vm.TOBAC30,
                TOBAC100 = vm.TOBAC100,
                SMOKYRS = vm.SMOKYRS,
                PACKSPER = vm.PACKSPER,
                QUITSMOK = vm.QUITSMOK,
                ALCOCCAS = vm.ALCOCCAS,
                ALCFREQ = vm.ALCFREQ,
                CVHATT = vm.CVHATT,
                HATTMULT = vm.HATTMULT,
                HATTYEAR = vm.HATTYEAR,
                CVAFIB = vm.CVAFIB,
                CVANGIO = vm.CVANGIO,
                CVBYPASS = vm.CVBYPASS,
                CVPACDEF = vm.CVPACDEF,
                CVCHF = vm.CVCHF,
                CVANGINA = vm.CVANGINA,
                CVHVALVE = vm.CVHVALVE,
                CVOTHR = vm.CVOTHR,
                CVOTHRX = vm.CVOTHRX,
                CBSTROKE = vm.CBSTROKE,
                STROKMUL = vm.STROKMUL,
                STROKYR = vm.STROKYR,
                CBTIA = vm.CBTIA,
                TIAMULT = vm.TIAMULT,
                TIAYEAR = vm.TIAYEAR,
                PD = vm.PD,
                PDYR = vm.PDYR,
                PDOTHR = vm.PDOTHR,
                SEIZURES = vm.SEIZURES,
                TBI = vm.TBI,
                TBIBRIEF = vm.TBIBRIEF,
                TBIEXTEN = vm.TBIEXTEN,
                TBIWOLOS = vm.TBIWOLOS,
                TBIYEAR = vm.TBIYEAR,
                DIABETES = vm.DIABETES,
                DIABTYPE = vm.DIABTYPE,
                HYPERTEN = vm.HYPERTEN,
                HYPERCHO = vm.HYPERCHO,
                B12DEF = vm.B12DEF,
                THYROID = vm.THYROID,
                ARTHRIT = vm.ARTHRIT,
                ARTHTYPE = vm.ARTHTYPE,
                ARTHTYPX = vm.ARTHTYPX,
                ARTHUPEX = vm.ARTHUPEX ? 1 : 0,
                ARTHLOEX = vm.ARTHLOEX ? 1 : 0,
                ARTHSPIN = vm.ARTHSPIN ? 1 : 0,
                ARTHUNK = vm.ARTHUNK ? 1 : 0,
                INCONTU = vm.INCONTU,
                INCONTF = vm.INCONTF,
                APNEA = vm.APNEA,
                RBD = vm.RBD,
                INSOMN = vm.INSOMN,
                OTHSLEEP = vm.OTHSLEEP,
                OTHSLEEX = vm.OTHSLEEX,
                ALCOHOL = vm.ALCOHOL,
                ABUSOTHR = vm.ABUSOTHR,
                ABUSX = vm.ABUSX,
                PTSD = vm.PTSD,
                BIPOLAR = vm.BIPOLAR,
                SCHIZ = vm.SCHIZ,
                DEP2YRS = vm.DEP2YRS,
                DEPOTHR = vm.DEPOTHR,
                ANXIETY = vm.ANXIETY,
                OCD = vm.OCD,
                NPSYDEV = vm.NPSYDEV,
                PSYCDIS = vm.PSYCDIS,
                PSYCDISX = vm.PSYCDISX
            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this A5D2 vm)
        {
            var fields = new A5D2FormFields
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this B1 vm)
        {
            var fields = new B1FormFields
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this B3 vm)
        {
            var fields = new B3FormFields
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);

        }
        public static Form ToEntity(this B4 vm)
        {
            var fields = new B4FormFields
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this B5 vm)
        {
            var fields = new B5FormFields
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this B6 vm)
        {
            var fields = new B6FormFields
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this B7 vm)
        {
            var fields = new B7FormFields
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this B8 vm)
        {
            var fields = new B8FormFields
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this B9 vm)
        {
            var fields = new B9FormFields
            {
                DECSUB = vm.DECSUB,
                DECIN = vm.DECIN,
                DECCLCOG = vm.DECCLCOG,
                COGMEM = vm.COGMEM,
                COGORI = vm.COGORI,
                COGJUDG = vm.COGJUDG,
                COGLANG = vm.COGLANG,
                COGVIS = vm.COGVIS,
                COGATTN = vm.COGATTN,
                COGFLUC = vm.COGFLUC,
                COGFLAGO = vm.COGFLAGO,
                COGOTHR = vm.COGOTHR,
                COGOTHRX = vm.COGOTHRX,
                COGFPRED = vm.COGFPRED,
                COGFPREX = vm.COGFPREX,
                COGMODE = vm.COGMODE,
                COGMODEX = vm.COGMODEX,
                DECAGE = vm.DECAGE,
                DECCLBE = vm.DECCLBE,
                BEAPATHY = vm.BEAPATHY,
                BEDEP = vm.BEDEP,
                BEVHALL = vm.BEVHALL,
                BEVWELL = vm.BEVWELL,
                BEVHAGO = vm.BEVHAGO,
                BEAHALL = vm.BEAHALL,
                BEDEL = vm.BEDISIN,
                BEDISIN = vm.BEDISIN,
                BEIRRIT = vm.BEAGIT,
                BEAGIT = vm.BEAGIT,
                BEPERCH = vm.BEPERCH,
                BEREM = vm.BEREM,
                BEREMAGO = vm.BEREMAGO,
                BEANX = vm.BEANX,
                BEOTHR = vm.BEOTHR,
                BEOTHRX = vm.BEOTHRX,
                BEFPRED = vm.BEFPRED,
                BEFPREDX = vm.BEFPREDX,
                BEMODE = vm.BEMODE,
                BEMODEX = vm.BEMODEX,
                BEAGE = vm.BEAGE,
                DECCLMOT = vm.DECCLMOT,
                MOGAIT = vm.MOGAIT,
                MOFALLS = vm.MOFALLS,
                MOTREM = vm.MOTREM,
                MOSLOW = vm.MOSLOW,
                MOFRST = vm.MOFRST,
                MOMODE = vm.MOMODE,
                MOMODEX = vm.MOMODEX,
                MOMOPARK = vm.MOMOPARK,
                PARKAGE = vm.PARKAGE,
                MOMOALS = vm.MOMOALS,
                ALSAGE = vm.ALSAGE,
                MOAGE = vm.MOAGE,
                COURSE = vm.COURSE,
                FRSTCHG = vm.FRSTCHG,
                LBDEVAL = vm.LBDEVAL,
                FTLDEVAL = vm.FTLDEVAL
            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this C1 vm)
        {
            var fields = new C1FormFields
            {
                MMSECOMP = vm.MMSECOMP,
                MMSEREAS = vm.MMSEREAS,
                MMSELOC = vm.MMSELOC,
                MMSELAN = vm.MMSELAN,
                MMSELANX = vm.MMSELANX,
                MMSEVIS = vm.MMSEVIS,
                MMSEHEAR = vm.MMSEHEAR,
                MMSEORDA = vm.MMSEORDA,
                MMSEORLO = vm.MMSEORLO,
                PENTAGON = vm.PENTAGON,
                MMSE = vm.MMSE,
                NPSYCLOC = vm.NPSYCLOC,
                NPSYLAN = vm.NPSYLAN,
                NPSYLANX = vm.NPSYLANX,
                LOGIMO = vm.LOGIMO,
                LOGIDAY = vm.LOGIDAY,
                LOGIYR = vm.LOGIYR,
                LOGIPREV = vm.LOGIPREV,
                LOGIMEM = vm.LOGIMEM,
                UDSBENTC = vm.UDSBENTC,
                DIGIF = vm.DIGIF,
                DIGIFLEN = vm.DIGIFLEN,
                DIGIB = vm.DIGIB,
                DIGIBLEN = vm.DIGIBLEN,
                ANIMALS = vm.ANIMALS,
                VEG = vm.VEG,
                TRAILA = vm.TRAILA,
                TRAILARR = vm.TRAILARR,
                TRAILALI = vm.TRAILALI,
                TRAILB = vm.TRAILB,
                TRAILBRR = vm.TRAILBRR,
                TRAILBLI = vm.TRAILBLI,
                MEMUNITS = vm.MEMUNITS,
                MEMTIME = vm.MEMTIME,
                UDSBENTD = vm.UDSBENTD,
                UDSBENRS = vm.UDSBENRS,
                BOSTON = vm.BOSTON,
                UDSVERFC = vm.UDSVERFC,
                UDSVERFN = vm.UDSVERFN,
                UDSVERNF = vm.UDSVERNF,
                UDSVERLC = vm.UDSVERLC,
                UDSVERLR = vm.UDSVERLR,
                UDSVERLN = vm.UDSVERLN,
                UDSVERTN = vm.UDSVERTN,
                UDSVERTE = vm.UDSVERTE,
                UDSVERTI = vm.UDSVERTI,
                COGSTAT = vm.COGSTAT
            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this C2 vm)
        {
            var fields = new C2FormFields
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
                REY6REC = vm.REY6REC,
                REY6INT = vm.REY6INT,
                OTRAILA = vm.OTRAILA,
                OTRLARR = vm.OTRLARR,
                OTRLALI = vm.OTRLALI,
                OTRAILB = vm.OTRAILB,
                OTRLBRR = vm.OTRLBRR,
                OTRLBLI = vm.OTRLBLI,
                REYDREC = vm.REYDREC,
                REYDINT = vm.REYDINT,
                REYTCOR = vm.REYTCOR,
                REYFPOS = vm.REYFPOS,
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this D2 vm)
        {
            var fields = new D2FormFields
            {
                CANCER = vm.CANCER,
                CANCSITE = vm.CANCSITE,
                DIABET = vm.DIABET,
                MYOINF = vm.MYOINF,
                CONGHRT = vm.CONGHRT,
                AFIBRILL = vm.AFIBRILL,
                HYPERT = vm.HYPERT,
                ANGINA = vm.ANGINA,
                HYPCHOL = vm.HYPCHOL,
                VB12DEF = vm.VB12DEF,
                THYDIS = vm.THYDIS,
                ARTH = vm.ARTH,
                ARTYPE = vm.ARTYPE,
                ARTYPEX = vm.ARTYPEX,
                ARTUPEX = vm.ARTUPEX ? 1 : 0,
                ARTLOEX = vm.ARTLOEX ? 1 : 0,
                ARTSPIN = vm.ARTSPIN ? 1 : 0,
                ARTUNKN = vm.ARTUNKN ? 1 : 0,
                URINEINC = vm.URINEINC,
                BOWLINC = vm.BOWLINC,
                SLEEPAP = vm.SLEEPAP,
                REMDIS = vm.REMDIS,
                HYPOSOM = vm.HYPOSOM,
                SLEEPOTH = vm.SLEEPOTH,
                SLEEPOTX = vm.SLEEPOTX,
                ANGIOCP = vm.ANGIOCP,
                ANGIOPCI = vm.ANGIOPCI,
                PACEMAKE = vm.PACEMAKE,
                HVALVE = vm.HVALVE,
                ANTIENC = vm.ANTIENC,
                ANTIENCX = vm.ANTIENCX,
                OTHCOND = vm.OTHCOND,
                OTHCONDX = vm.OTHCONDX
            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this T1 vm)
        {
            var fields = new T1FormFields
            {
                TELCOG = vm.TELCOG,
                TELILL = vm.TELILL,
                TELHOME = vm.TELHOME,
                TELREFU = vm.TELREFU,
                TELCOV = vm.TELCOV,
                TELOTHR = vm.TELOTHR,
                TELOTHRX = vm.TELOTHRX,
                TELMOD = vm.TELMOD,
                TELINPER = vm.TELINPER,
                TELMILE = vm.TELMILE
            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.ReasonCodeNotIncluded, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }
    }
}

