using System;
using UDS.Net.Dto;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.UDS3;
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
                LegacyId = vm.LegacyId
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
            {
                return ((A1)vm).ToEntity();
            }
            else
                return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, null);
        }

        public static Form ToEntity(this A1 vm)
        {
            var fields = new A1FormFields
            {
                REASON = vm.REASON,
                REFERSC = vm.REFERSC,
                LEARNED = vm.LEARNED,
                PRESTAT = vm.PRESTAT,
                PRESPART = vm.PRESPART,
                SOURCENW = vm.SOURCENW,
                BIRTHMO = vm.BIRTHMO,
                BIRTHYR = vm.BIRTHYR,
                SEX = vm.SEX,
                MARISTAT = vm.MARISTAT,
                LIVSITUA = vm.LIVSITUA,
                INDEPEND = vm.INDEPEND,
                RESIDENC = vm.RESIDENC,
                HISPANIC = vm.HISPANIC,
                HISPOR = vm.HISPOR,
                HISPORX = vm.HISPORX,
                RACE = vm.RACE,
                RACEX = vm.RACEX,
                RACESEC = vm.RACESEC,
                RACESECX = vm.RACESECX,
                RACETER = vm.RACETER,
                PRIMLANG = vm.PRIMLANG,
                PRIMLANX = vm.PRIMLANX,
                EDUC = vm.EDUC,
                ZIP = vm.ZIP,
                HANDED = vm.HANDED
            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this A2 vm)
        {
            var fields = new A2FormFields
            {
                INBIRMO = vm.INBIRMO,
                INBIRYR = vm.INBIRYR,
                INSEX = vm.INSEX,
                INHISP = vm.INHISP,
                INHISPOR = vm.INHISPOR,
                INHISPOX = vm.INHISPOX,
                INRACE = vm.INRACE,
                INRACEX = vm.INRACEX,
                INRASEC = vm.INRASEC,
                INRASECX = vm.INRASECX,
                INRATER = vm.INRATER,
                INRATERX = vm.INRATERX,
                INEDUC = vm.INEDUC,
                INRELTO = vm.INRELTO,
                INKNOWN = vm.INKNOWN,
                INLIVWTH = vm.INLIVWTH,
                INVISITS = vm.INVISITS,
                INCALLS = vm.INCALLS,
                INRELY = vm.INRELY
            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this A3 vm)
        {
            var fields = new A3FormFields
            {
                AFFFAMM = vm.AFFFAMM,
                NWINFMUT = vm.NWINFMUT,
                FADMUT = vm.FADMUT,
                FADMUTX = vm.FADMUTX,
                FADMUSO = vm.FADMUSO,
                FADMUSOX = vm.FADMUSOX,
                FFTDMUT = vm.FFTDMUT,
                FFTDMUTX = vm.FFTDMUTX,
                FFTDMUSO = vm.FFTDMUSO,
                FFTDMUSX = vm.FFTDMUSX,
                FOTHMUT = vm.FOTHMUT,
                FOTHMUTX = vm.FOTHMUTX,
                FOTHMUSO = vm.FOTHMUSO,
                FOTHMUSX = vm.FOTHMUSX,
                MOMMOB = vm.MOMMOB,
                MOMYOB = vm.MOMYOB,
                MOMDAGE = vm.MOMDAGE,
                MOMNEUR = vm.MOMNEUR,
                MOMPRDX = vm.MOMPRDX,
                MOMMOE = vm.MOMMOE,
                MOMAGEO = vm.MOMAGEO,
                DADMOB = vm.DADMOB,
                DADYOB = vm.DADYOB,
                DADDAGE = vm.DADDAGE,
                DADNEUR = vm.DADNEUR,
                DADPRDX = vm.DADPRDX,
                DADMOE = vm.DADMOE,
                DADAGEO = vm.DADAGEO,
                SIBS = vm.SIBS,
                KIDS = vm.KIDS
            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this A4 vm)
        {
            /// TODO medications and details
            var fields = new A4GFormFields
            {
                ANYMEDS = vm.ANYMEDS
            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this A5 vm)
        {
            var fields = new A5FormFields
            {

            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this B1 vm)
        {
            var fields = new B1FormFields
            {

            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this B4 vm)
        {
            var fields = new B4FormFields
            {

            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this B5 vm)
        {
            var fields = new B5FormFields
            {

            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this B6 vm)
        {
            var fields = new B6FormFields
            {
                NOGDS = vm.NOGDS,
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this B8 vm)
        {
            var fields = new B8FormFields
            {

                NORMEXAM = vm.NORMEXAM,
                PARKSIGN = vm.PARKSIGN,
                RESTTRL = vm.RESTTRL,
                RESTTRR = vm.RESTTRR,
                SLOWINGL = vm.SLOWINGL,
                SLOWINGR = vm.SLOWINGR,
                RIGIDL = vm.RIGIDL,
                RIGIDR = vm.RIGIDR,
                BRADY = vm.BRADY,
                PARKGAIT = vm.PARKGAIT,
                POSTINST = vm.POSTINST,
                CVDSIGNS = vm.CVDSIGNS,
                CORTDEF = vm.CORTDEF,
                SIVDFIND = vm.SIVDFIND,
                CVDMOTL = vm.CVDMOTL,
                CVDMOTR = vm.CVDMOTR,
                CORTVISL = vm.CORTVISL,
                CORTVISR = vm.CORTVISR,
                SOMATL = vm.SOMATL,
                SOMATR = vm.SOMATR,
                POSTCORT = vm.POSTCORT,
                PSPCBS = vm.PSPCBS,
                EYEPSP = vm.EYEPSP,
                DYSPSP = vm.DYSPSP,
                AXIALPSP = vm.AXIALPSP,
                GAITPSP = vm.GAITPSP,
                APRAXSP = vm.APRAXSP,
                APRAXL = vm.APRAXL,
                APRAXR = vm.APRAXR,
                CORTSENL = vm.CORTSENL,
                CORTSENR = vm.CORTSENR,
                ATAXL = vm.ATAXL,
                ATAXR = vm.ATAXR,
                ALIENLML = vm.ALIENLML,
                ALIENLMR = vm.ALIENLMR,
                DYSTONL = vm.DYSTONL,
                DYSTONR = vm.DYSTONR,
                MYOCLLT = vm.MYOCLLT,
                MYOCLRT = vm.MYOCLRT,
                ALSFIND = vm.ALSFIND,
                GAITNPH = vm.GAITNPH,
                OTHNEUR = vm.OTHNEUR,
                OTHNEURX = vm.OTHNEURX
            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this C2 vm)
        {
            var fields = new C2FormFields
            {
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
                COGSTAT = vm.COGSTAT
            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this D1 vm)
        {
            var fields = new D1FormFields
            {
                DXMETHOD = vm.DXMETHOD,
                NORMCOG = vm.NORMCOG,
                DEMENTED = vm.DEMENTED,
                AMNDEM = vm.AMNDEM,
                PCA = vm.PCA,
                PPASYN = vm.PPASYN,
                PPASYNT = vm.PPASYNT,
                FTDSYN = vm.FTDSYN,
                LBDSYN = vm.LBDSYN,
                NAMNDEM = vm.NAMNDEM,
                MCIAMEM = vm.MCIAMEM,
                MCIAPLUS = vm.MCIAPLUS,
                MCIAPLAN = vm.MCIAPLAN,
                MCIAPATT = vm.MCIAPATT,
                MCIAPEX = vm.MCIAPEX,
                MCIAPVIS = vm.MCIAPVIS,
                MCINON1 = vm.MCINON1,
                MCIN1LAN = vm.MCIN1LAN,
                MCIN1ATT = vm.MCIN1ATT,
                MCIN1EX = vm.MCIN1EX,
                MCIN1VIS = vm.MCIN1VIS,
                MCINON2 = vm.MCINON2,
                MCIN2LAN = vm.MCIN2LAN,
                MCIN2ATT = vm.MCIN2ATT,
                MCIN2EX = vm.MCIN2EX,
                MCIN2VIS = vm.MCIN2VIS,
                IMPNOMCI = vm.IMPNOMCI,
                AMYLPET = vm.AMYLPET,
                AMYLCSF = vm.AMYLCSF,
                FDGAD = vm.FDGAD,
                HIPPATR = vm.HIPPATR,
                TAUPETAD = vm.TAUPETAD,
                CSFTAU = vm.CSFTAU,
                FDGFTLD = vm.FDGFTLD,
                TPETFTLD = vm.TPETFTLD,
                MRFTLD = vm.MRFTLD,
                DATSCAN = vm.DATSCAN,
                OTHBIOM = vm.OTHBIOM,
                OTHBIOMX = vm.OTHBIOMX,
                IMAGLINF = vm.IMAGLINF,
                IMAGLAC = vm.IMAGLAC,
                IMAGMACH = vm.IMAGMACH,
                IMAGMICH = vm.IMAGMICH,
                IMAGMWMH = vm.IMAGMWMH,
                IMAGEWMH = vm.IMAGEWMH,
                ADMUT = vm.ADMUT,
                FTLDMUT = vm.FTLDMUT,
                OTHMUT = vm.OTHMUT,
                OTHMUTX = vm.OTHMUTX,
                ALZDIS = vm.ALZDIS,
                ALZDISIF = vm.ALZDISIF,
                LBDIS = vm.LBDIS,
                LBDIF = vm.LBDIF,
                PARK = vm.PARK,
                MSA = vm.MSA,
                MSAIF = vm.MSAIF,
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
                PREVSTK = vm.PREVSTK,
                STROKDEC = vm.STROKDEC,
                STKIMAG = vm.STKIMAG,
                INFNETW = vm.INFNETW,
                INFWMH = vm.INFWMH,
                ESSTREM = vm.ESSTREM,
                ESSTREIF = vm.ESSTREIF,
                DOWNS = vm.DOWNS,
                DOWNSIF = vm.DOWNSIF,
                HUNT = vm.HUNT,
                HUNTIF = vm.HUNTIF,
                PRION = vm.PRION,
                PRIONIF = vm.PRIONIF,
                BRNINJ = vm.BRNINJ,
                BRNINJIF = vm.BRNINJIF,
                BRNINCTE = vm.BRNINCTE,
                HYCEPH = vm.HYCEPH,
                HYCEPHIF = vm.HYCEPHIF,
                EPILEP = vm.EPILEP,
                EPILEPIF = vm.EPILEPIF,
                NEOP = vm.NEOP,
                NEOPIF = vm.NEOPIF,
                NEOPSTAT = vm.NEOPSTAT,
                HIV = vm.HIV,
                HIVIF = vm.HIVIF,
                OTHCOG = vm.OTHCOG,
                OTHCOGIF = vm.OTHCOGIF,
                OTHCOGX = vm.OTHCOGX,
                DEP = vm.DEP,
                DEPIF = vm.DEPIF,
                DEPTREAT = vm.DEPTREAT,
                BIPOLDX = vm.BIPOLDX,
                BIPOLDIF = vm.BIPOLDIF,
                SCHIZOP = vm.SCHIZOP,
                SCHIZOIF = vm.SCHIZOIF,
                ANXIET = vm.ANXIET,
                ANXIETIF = vm.ANXIETIF,
                DELIR = vm.DELIR,
                DELIRIF = vm.DELIRIF,
                PTSDDX = vm.PTSDDX,
                PTSDDXIF = vm.PTSDDXIF,
                OTHPSY = vm.OTHPSY,
                OTHPSYIF = vm.OTHPSYIF,
                OTHPSYX = vm.OTHPSYX,
                ALCDEMIF = vm.ALCDEMIF,
                ALCABUSE = vm.ALCABUSE,
                IMPSUB = vm.IMPSUB,
                IMPSUBIF = vm.IMPSUBIF,
                DYSILL = vm.DYSILL,
                DYSILLIF = vm.DYSILLIF,
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
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
                ARTUPEX = vm.ARTUPEX,
                ARTLOEX = vm.ARTLOEX,
                ARTSPIN = vm.ARTSPIN,
                ARTUNKN = vm.ARTUNKN,
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
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

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }
    }
}

