using System;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using Microsoft.Extensions.Logging;
using UDS.Net.Dto;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.UDS3;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;

namespace UDS.Net.Forms.Extensions
{
    public static class DomainToViewModelMapper
    {
        private static void SetBaseProperties(Form form, FormModel vm)
        {
            vm.VisitId = form.VisitId;
            vm.Version = form.Version;
            vm.Status = form.Status; // TODO
            vm.Kind = form.Kind;
            vm.Title = form.Title;
            vm.Description = form.Description;
            vm.IsRequiredForVisitKind = form.IsRequiredForVisitKind;
            vm.IncludeInPacketSubmission = form.IsIncluded.HasValue ? form.IsIncluded.Value : false;
            vm.ReasonNotIncluded = form.ReasonCode;
            vm.CreatedAt = form.CreatedAt;
            vm.CreatedBy = form.CreatedBy;
            vm.ModifiedBy = form.ModifiedBy;
            vm.DeletedBy = form.DeletedBy;
            vm.IsDeleted = form.IsDeleted;
        }

        public static ParticipationModel ToVM(this Participation participation)
        {
            return new ParticipationModel()
            {
                Id = participation.Id,
                LegacyId = participation.LegacyId,
                VisitCount = participation.Visits.Count(),
                Visits = participation.Visits.ToVM()
            };
        }

        public static List<VisitModel> ToVM(this IList<Visit> visits)
        {
            List<VisitModel> vm = new List<VisitModel>();

            foreach (var visit in visits)
            {
                vm.Add(visit.ToVM());
            }

            return vm;
        }

        public static VisitModel ToVM(this Visit visit)
        {
            return new VisitModel()
            {
                Id = visit.Id,
                ParticipationId = visit.ParticipationId,
                Number = visit.Number,
                Kind = visit.Kind,
                Version = visit.Version,
                StartDateTime = visit.StartDateTime,
                CreatedAt = visit.CreatedAt,
                CreatedBy = visit.CreatedBy,
                ModifiedBy = visit.ModifiedBy,
                DeletedBy = visit.DeletedBy,
                IsDeleted = visit.IsDeleted,
                Forms = visit.Forms.ToVM()
            };
        }

        public static List<FormModel> ToVM(this IList<Form> forms)
        {
            List<FormModel> vm = new List<FormModel>();

            foreach (var form in forms)
            {
                vm.Add(form.ToVM());
            }

            return vm;
        }

        public static FormModel ToVM(this Form form)
        {
            var vm = new FormModel()
            {
                Id = form.Id,
                VisitId = form.VisitId,
                Version = form.Version,
                Kind = form.Kind,
                Status = form.Status,
                Title = form.Title,
                Description = form.Description,
                IsRequiredForVisitKind = form.IsRequiredForVisitKind,
                IncludeInPacketSubmission = form.IsIncluded.HasValue ? form.IsIncluded.Value : false,
                CreatedAt = form.CreatedAt,
                CreatedBy = form.CreatedBy,
                ModifiedBy = form.ModifiedBy,
                DeletedBy = form.DeletedBy,
                IsDeleted = form.IsDeleted
            };

            if (form.Fields != null)
            {
                if (form.Fields is A1FormFields)
                {
                    vm = ((A1FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is A2FormFields)
                {
                    vm = ((A2FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is A3FormFields)
                {
                    vm = ((A3FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is A4GFormFields)
                {
                    vm = ((A4GFormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is A5FormFields)
                {
                    vm = ((A5FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is B1FormFields)
                {
                    vm = ((B1FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is B4FormFields)
                {
                    vm = ((B4FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is B5FormFields)
                {
                    vm = ((B5FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is B6FormFields)
                {
                    vm = ((B6FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is B7FormFields)
                {
                    vm = ((B7FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is B8FormFields)
                {
                    vm = ((B8FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is B9FormFields)
                {
                    vm = ((B9FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is C1FormFields)
                {
                    vm = ((C1FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is C2FormFields)
                {
                    vm = ((C2FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is D1FormFields)
                {
                    vm = ((D1FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is D2FormFields)
                {
                    vm = ((D2FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is T1FormFields)
                {
                    vm = ((T1FormFields)form.Fields).ToVM(form.Id);
                }

                SetBaseProperties(form, vm); // must know the vm type in order to do this
            }

            return vm;
        }

        public static A1 ToVM(this A1FormFields fields, int formId)
        {
            return new A1()
            {
                Id = formId,
                BIRTHMO = fields.BIRTHMO,
                BIRTHYR = fields.BIRTHYR,
                SEX = fields.SEX,
                MARISTAT = fields.MARISTAT,
                LIVSITUA = fields.LIVSITUA,
                INDEPEND = fields.INDEPEND,
                RESIDENC = fields.RESIDENC,
                REASON = fields.REASON,
                REFERSC = fields.REFERSC,
                LEARNED = fields.LEARNED,
                PRESTAT = fields.PRESTAT,
                PRESPART = fields.PRESPART,
                SOURCENW = fields.SOURCENW,
                HISPANIC = fields.HISPANIC,
                HISPOR = fields.HISPOR,
                HISPORX = fields.HISPORX,
                RACE = fields.RACE,
                RACEX = fields.RACEX,
                RACESEC = fields.RACESEC,
                RACESECX = fields.RACESECX,
                RACETER = fields.RACETER,
                RACETERX = fields.RACETERX,
                PRIMLANG = fields.PRIMLANG,
                PRIMLANX = fields.PRIMLANX,
                EDUC = fields.EDUC,
                ZIP = fields.ZIP,
                HANDED = fields.HANDED
            };
        }

        public static A2 ToVM(this A2FormFields fields, int formId)
        {
            return new A2()
            {
                Id = formId,
                INBIRMO = fields.INBIRMO,
                INBIRYR = fields.INBIRYR,
                INSEX = fields.INSEX,
                INHISP = fields.INHISP,
                INHISPOR = fields.INHISPOR,
                INHISPOX = fields.INHISPOX,
                INRACE = fields.INRACE,
                INRACEX = fields.INRACEX,
                INRASEC = fields.INRASEC,
                INRASECX = fields.INRASECX,
                INRATER = fields.INRATER,
                INRATERX = fields.INRATERX,
                INEDUC = fields.INEDUC,
                INRELTO = fields.INRELTO,
                INKNOWN = fields.INKNOWN,
                INLIVWTH = fields.INLIVWTH,
                INVISITS = fields.INVISITS,
                INCALLS = fields.INCALLS,
                INRELY = fields.INRELY
            };
        }

        public static A3 ToVM(this A3FormFields fields, int formId)
        {
            return new A3()
            {
                Id = formId,
                AFFFAMM = fields.AFFFAMM,
                NWINFMUT = fields.NWINFMUT,
                FADMUT = fields.FADMUT,
                FADMUTX = fields.FADMUTX,
                FADMUSO = fields.FADMUSO,
                FADMUSOX = fields.FADMUSOX,
                FFTDMUT = fields.FFTDMUT,
                FFTDMUTX = fields.FFTDMUTX,
                FFTDMUSO = fields.FFTDMUSO,
                FFTDMUSX = fields.FFTDMUSX,
                FOTHMUT = fields.FOTHMUT,
                FOTHMUTX = fields.FOTHMUTX,
                FOTHMUSO = fields.FOTHMUSO,
                FOTHMUSX = fields.FOTHMUSX,
                MOMMOB = fields.MOMMOB,
                MOMYOB = fields.MOMYOB,
                MOMDAGE = fields.MOMDAGE,
                MOMNEUR = fields.MOMNEUR,
                MOMPRDX = fields.MOMPRDX,
                MOMMOE = fields.MOMMOE,
                MOMAGEO = fields.MOMAGEO,
                DADMOB = fields.DADMOB,
                DADYOB = fields.DADYOB,
                DADDAGE = fields.DADDAGE,
                DADNEUR = fields.DADNEUR,
                DADPRDX = fields.DADPRDX,
                DADMOE = fields.DADMOE,
                DADAGEO = fields.DADAGEO,
                SIBS = fields.SIBS,
                KIDS = fields.KIDS,
                Siblings = fields.SiblingFormFields.Select(s => s.ToVM(formId)).ToList(),
                Children = fields.KidsFormFields.Select(k => k.ToVM(formId)).ToList()
            };
        }

        public static A3FamilyMember ToVM(this A3FamilyMemberFormFields fields, int formId)
        {
            return new A3FamilyMember()
            {
                FamilyMemberIndex = fields.FamilyMemberIndex,
                MOB = fields.MOB,
                YOB = fields.YOB,
                AGD = fields.AGD,
                NEU = fields.NEU,
                PDX = fields.PDX,
                MOE = fields.MOE,
                AGO = fields.AGO
            };
        }

        public static A4 ToVM(this A4GFormFields fields, int formId)
        {
            return new A4()
            {
                Id = formId,
                ANYMEDS = fields.ANYMEDS,
                DrugIds = fields.A4Ds.Select(d => d.DRUGID).ToList()
            };
        }

        public static A5 ToVM(this A5FormFields fields, int formId)
        {
            return new A5()
            {
                Id = formId,
                TOBAC30 = fields.TOBAC30,
                TOBAC100 = fields.TOBAC100,
                SMOKYRS = fields.SMOKYRS,
                PACKSPER = fields.PACKSPER,
                QUITSMOK = fields.QUITSMOK,
                ALCOCCAS = fields.ALCOCCAS,
                ALCFREQ = fields.ALCFREQ,
                CVHATT = fields.CVHATT,
                HATTMULT = fields.HATTMULT,
                CVAFIB = fields.CVAFIB,
                CVANGIO = fields.CVANGIO,
                CVBYPASS = fields.CVBYPASS,
                CVPACDEF = fields.CVPACDEF,
                CVCHF = fields.CVCHF,
                CVANGINA = fields.CVANGINA,
                CVHVALVE = fields.CVHVALVE,
                CVOTHR = fields.CVOTHR,
                CVOTHRX = fields.CVOTHRX,
                CBSTROKE = fields.CBSTROKE,
                STROKMUL = fields.STROKMUL,
                STROKYR = fields.STROKYR,
                CBTIA = fields.CBTIA,
                TIAMULT = fields.TIAMULT,
                TIAYEAR = fields.TIAYEAR,
                PD = fields.PD,
                PDYR = fields.PDYR,
                PDOTHR = fields.PDOTHR,
                SEIZURES = fields.SEIZURES,
                TBI = fields.TBI,
                TBIBRIEF = fields.TBIBRIEF,
                TBIEXTEN = fields.TBIEXTEN,
                TBIWOLOS = fields.TBIWOLOS,
                TBIYEAR = fields.TBIYEAR,
                DIABETES = fields.DIABETES,
                DIABTYPE = fields.DIABTYPE,
                HYPERTEN = fields.HYPERTEN,
                HYPERCHO = fields.HYPERCHO,
                B12DEF = fields.B12DEF,
                THYROID = fields.THYROID,
                ARTHRIT = fields.ARTHRIT,
                ARTHTYPE = fields.ARTHTYPE,
                ARTHTYPX = fields.ARTHTYPX,
                ARTHUPEX = fields.ARTHUPEX,
                ARTHLOEX = fields.ARTHLOEX,
                ARTHSPIN = fields.ARTHSPIN,
                ARTHUNK = fields.ARTHUNK,
                INCONTU = fields.INCONTU,
                INCONTF = fields.INCONTF,
                APNEA = fields.APNEA,
                RBD = fields.RBD,
                INSOMN = fields.INSOMN,
                OTHSLEEP = fields.OTHSLEEP,
                OTHSLEEX = fields.OTHSLEEX,
                ALCOHOL = fields.ALCOHOL,
                ABUSOTHR = fields.ABUSOTHR,
                ABUSX = fields.ABUSX,
                PTSD = fields.PTSD,
                BIPOLAR = fields.BIPOLAR,
                SCHIZ = fields.SCHIZ,
                DEP2YRS = fields.DEP2YRS,
                DEPOTHR = fields.DEPOTHR,
                ANXIETY = fields.ANXIETY,
                OCD = fields.OCD,
                NPSYDEV = fields.NPSYDEV,
                PSYCDIS = fields.PSYCDIS,
                PSYCDISX = fields.PSYCDISX
            };
        }

        public static B1 ToVM(this B1FormFields fields, int formId)
        {
            return new B1()
            {
                Id = formId,
                HEIGHT = fields.HEIGHT,
                WEIGHT = fields.WEIGHT,
                BPSYS = fields.BPSYS,
                BPDIAS = fields.BPDIAS,
                HRATE = fields.HRATE,
                VISION = fields.VISION,
                VISCORR = fields.VISCORR,
                VISWCORR = fields.VISWCORR,
                HEARING = fields.HEARING,
                HEARAID = fields.HEARAID,
                HEARWAID = fields.HEARWAID
            };
        }

        public static B4 ToVM(this B4FormFields fields, int formId)
        {
            return new B4()
            {
                Id = formId,
                MEMORY = fields.MEMORY,
                ORIENT = fields.ORIENT,
                JUDGMENT = fields.JUDGMENT,
                COMMUN = fields.COMMUN,
                HOMEHOBB = fields.HOMEHOBB,
                PERSCARE = fields.PERSCARE,
                CDRSUM = fields.CDRSUM,
                CDRGLOB = fields.CDRGLOB,
                COMPORT = fields.COMPORT,
                CDRLANG = fields.CDRLANG
            };
        }

        public static B5 ToVM(this B5FormFields fields, int formId)
        {
            return new B5()
            {
                Id = formId,
                NPIQINF = fields.NPIQINF,
                NPIQINFX = fields.NPIQINFX,
                DEL = fields.DEL,
                DELSEV = fields.DELSEV,
                HALL = fields.HALL,
                HALLSEV = fields.HALLSEV,
                AGIT = fields.AGIT,
                AGITSEV = fields.AGITSEV,
                DEPD = fields.DEPD,
                DEPDSEV = fields.DEPDSEV,
                ANX = fields.ANX,
                ANXSEV = fields.ANXSEV,
                ELAT = fields.ELAT,
                ELATSEV = fields.ELATSEV,
                APA = fields.APA,
                APASEV = fields.APASEV,
                DISN = fields.DISN,
                DISNSEV = fields.DISNSEV,
                IRR = fields.IRR,
                IRRSEV = fields.IRRSEV,
                MOT = fields.MOT,
                MOTSEV = fields.MOTSEV,
                NITE = fields.NITE,
                NITESEV = fields.NITESEV,
                APP = fields.APP,
                APPSEV = fields.APPSEV
            };
        }

        public static B6 ToVM(this B6FormFields fields, int formId)
        {
            return new B6()
            {
                Id = formId,
                NOGDS = fields.NOGDS.HasValue ? fields.NOGDS.Value != 0 : false, // (1 != 0) = true, (0 != 0) = false
                SATIS = fields.SATIS,
                DROPACT = fields.DROPACT,
                EMPTY = fields.EMPTY,
                BORED = fields.BORED,
                SPIRITS = fields.SPIRITS,
                AFRAID = fields.AFRAID,
                HAPPY = fields.HAPPY,
                HELPLESS = fields.HELPLESS,
                STAYHOME = fields.STAYHOME,
                MEMPROB = fields.MEMPROB,
                WONDRFUL = fields.WONDRFUL,
                WRTHLESS = fields.WRTHLESS,
                ENERGY = fields.ENERGY,
                HOPELESS = fields.HOPELESS,
                BETTER = fields.BETTER,
                GDS = fields.GDS
            };
        }

        public static B7 ToVM(this B7FormFields fields, int formId)
        {
            return new B7()
            {
                Id = formId,
                BILLS = fields.BILLS,
                TAXES = fields.TAXES,
                SHOPPING = fields.SHOPPING,
                GAMES = fields.GAMES,
                STOVE = fields.STOVE,
                MEALPREP = fields.MEALPREP,
                EVENTS = fields.EVENTS,
                PAYATTN = fields.PAYATTN,
                REMDATES = fields.REMDATES,
                TRAVEL = fields.TRAVEL
            };
        }

        public static B8 ToVM(this B8FormFields fields, int formId)
        {
            return new B8()
            {
                Id = formId,
                NORMEXAM = fields.NORMEXAM,
                PARKSIGN = fields.PARKSIGN,
                RESTTRL = fields.RESTTRL,
                RESTTRR = fields.RESTTRR,
                SLOWINGL = fields.SLOWINGL,
                SLOWINGR = fields.SLOWINGR,
                RIGIDL = fields.RIGIDL,
                RIGIDR = fields.RIGIDR,
                BRADY = fields.BRADY,
                PARKGAIT = fields.PARKGAIT,
                POSTINST = fields.POSTINST,
                CVDSIGNS = fields.CVDSIGNS,
                CORTDEF = fields.CORTDEF,
                SIVDFIND = fields.SIVDFIND,
                CVDMOTL = fields.CVDMOTL,
                CVDMOTR = fields.CVDMOTR,
                CORTVISL = fields.CORTVISL,
                CORTVISR = fields.CORTVISR,
                SOMATL = fields.SOMATL,
                SOMATR = fields.SOMATR,
                POSTCORT = fields.POSTCORT,
                PSPCBS = fields.PSPCBS,
                EYEPSP = fields.EYEPSP,
                DYSPSP = fields.DYSPSP,
                AXIALPSP = fields.AXIALPSP,
                GAITPSP = fields.GAITPSP,
                APRAXSP = fields.APRAXSP,
                APRAXL = fields.APRAXL,
                APRAXR = fields.APRAXR,
                CORTSENL = fields.CORTSENL,
                CORTSENR = fields.CORTSENR,
                ATAXL = fields.ATAXL,
                ATAXR = fields.ATAXR,
                ALIENLML = fields.ALIENLML,
                ALIENLMR = fields.ALIENLMR,
                DYSTONL = fields.DYSTONL,
                DYSTONR = fields.DYSTONR,
                MYOCLLT = fields.MYOCLLT,
                MYOCLRT = fields.MYOCLRT,
                ALSFIND = fields.ALSFIND,
                GAITNPH = fields.GAITNPH,
                OTHNEUR = fields.OTHNEUR,
                OTHNEURX = fields.OTHNEURX
            };
        }

        public static B9 ToVM(this B9FormFields fields, int formId)
        {
            return new B9()
            {
                Id = formId,
                DECSUB = fields.DECSUB,
                DECIN = fields.DECIN,
                DECCLCOG = fields.DECCLCOG,
                COGMEM = fields.COGMEM,
                COGORI = fields.COGORI,
                COGJUDG = fields.COGJUDG,
                COGLANG = fields.COGLANG,
                COGVIS = fields.COGVIS,
                COGATTN = fields.COGATTN,
                COGFLUC = fields.COGFLUC,
                COGFLAGO = fields.COGFLAGO,
                COGOTHR = fields.COGOTHR,
                COGOTHRX = fields.COGOTHRX,
                COGFPRED = fields.COGFPRED,
                COGFPREX = fields.COGFPREX,
                COGMODE = fields.COGMODE,
                COGMODEX = fields.COGMODEX,
                DECAGE = fields.DECAGE,
                DECCLBE = fields.DECCLBE,
                BEAPATHY = fields.BEAPATHY,
                BEDEP = fields.BEDEP,
                BEVHALL = fields.BEVHALL,
                BEVWELL = fields.BEVWELL,
                BEVHAGO = fields.BEVHAGO,
                BEAHALL = fields.BEAHALL,
                BEDEL = fields.BEDISIN,
                BEDISIN = fields.BEDISIN,
                BEIRRIT = fields.BEAGIT,
                BEAGIT = fields.BEAGIT,
                BEPERCH = fields.BEPERCH,
                BEREM = fields.BEREM,
                BEREMAGO = fields.BEREMAGO,
                BEANX = fields.BEANX,
                BEOTHR = fields.BEOTHR,
                BEOTHRX = fields.BEOTHRX,
                BEFPRED = fields.BEFPRED,
                BEFPREDX = fields.BEFPREDX,
                BEMODE = fields.BEMODE,
                BEMODEX = fields.BEMODEX,
                BEAGE = fields.BEAGE,
                DECCLMOT = fields.DECCLMOT,
                MOGAIT = fields.MOGAIT,
                MOFALLS = fields.MOFALLS,
                MOTREM = fields.MOTREM,
                MOSLOW = fields.MOSLOW,
                MOFRST = fields.MOFRST,
                MOMODE = fields.MOMODE,
                MOMODEX = fields.MOMODEX,
                MOMOPARK = fields.MOMOPARK,
                PARKAGE = fields.PARKAGE,
                MOMOALS = fields.MOMOALS,
                ALSAGE = fields.ALSAGE,
                MOAGE = fields.MOAGE,
                COURSE = fields.COURSE,
                FRSTCHG = fields.FRSTCHG,
                LBDEVAL = fields.LBDEVAL,
                FTLDEVAL = fields.FTLDEVAL
            };
        }

        public static C1 ToVM(this C1FormFields fields, int formId)
        {
            return new C1()
            {
                Id = formId,
                MMSECOMP = fields.MMSECOMP,
                MMSEREAS = fields.MMSEREAS,
                MMSELOC = fields.MMSELOC,
                MMSELAN = fields.MMSELAN,
                MMSELANX = fields.MMSELANX,
                MMSEVIS = fields.MMSEVIS,
                MMSEHEAR = fields.MMSEHEAR,
                MMSEORDA = fields.MMSEORDA,
                MMSEORLO = fields.MMSEORLO,
                PENTAGON = fields.PENTAGON,
                MMSE = fields.MMSE,
                NPSYCLOC = fields.NPSYCLOC,
                NPSYLAN = fields.NPSYLAN,
                NPSYLANX = fields.NPSYLANX,
                LOGIMO = fields.LOGIMO,
                LOGIDAY = fields.LOGIDAY,
                LOGIYR = fields.LOGIYR,
                LOGIPREV = fields.LOGIPREV,
                LOGIMEM = fields.LOGIMEM,
                UDSBENTC = fields.UDSBENTC,
                DIGIF = fields.DIGIF,
                DIGIFLEN = fields.DIGIFLEN,
                DIGIB = fields.DIGIB,
                DIGIBLEN = fields.DIGIBLEN,
                ANIMALS = fields.ANIMALS,
                VEG = fields.VEG,
                TRAILA = fields.TRAILA,
                TRAILARR = fields.TRAILARR,
                TRAILALI = fields.TRAILALI,
                TRAILB = fields.TRAILB,
                TRAILBRR = fields.TRAILBRR,
                TRAILBLI = fields.TRAILBLI,
                MEMUNITS = fields.MEMUNITS,
                MEMTIME = fields.MEMTIME,
                UDSBENTD = fields.UDSBENTD,
                UDSBENRS = fields.UDSBENRS,
                BOSTON = fields.BOSTON,
                UDSVERFC = fields.UDSVERFC,
                UDSVERFN = fields.UDSVERFN,
                UDSVERNF = fields.UDSVERNF,
                UDSVERLC = fields.UDSVERLC,
                UDSVERLR = fields.UDSVERLR,
                UDSVERLN = fields.UDSVERLN,
                UDSVERTN = fields.UDSVERTN,
                UDSVERTE = fields.UDSVERTE,
                UDSVERTI = fields.UDSVERTI,
                COGSTAT = fields.COGSTAT
            };
        }

        public static C2 ToVM(this C2FormFields fields, int formId)
        {
            return new C2()
            {
                Id = formId,
                MOCACOMP = fields.MOCACOMP,
                MOCAREAS = fields.MOCAREAS,
                MOCALOC = fields.MOCALOC,
                MOCALAN = fields.MOCALAN,
                MOCALANX = fields.MOCALANX,
                MOCAVIS = fields.MOCAVIS,
                MOCAHEAR = fields.MOCAHEAR,
                MOCATOTS = fields.MOCATOTS,
                MOCATRAI = fields.MOCATRAI,
                MOCACUBE = fields.MOCACUBE,
                MOCACLOC = fields.MOCACLOC,
                MOCACLON = fields.MOCACLON,
                MOCACLOH = fields.MOCACLOH,
                MOCANAMI = fields.MOCANAMI,
                MOCAREGI = fields.MOCAREGI,
                MOCADIGI = fields.MOCADIGI,
                MOCALETT = fields.MOCALETT,
                MOCASER7 = fields.MOCASER7,
                MOCAREPE = fields.MOCAREPE,
                MOCAFLUE = fields.MOCAFLUE,
                MOCAABST = fields.MOCAABST,
                MOCARECN = fields.MOCARECN,
                MOCARECC = fields.MOCARECC,
                MOCARECR = fields.MOCARECR,
                MOCAORDT = fields.MOCAORDT,
                MOCAORMO = fields.MOCAORMO,
                MOCAORYR = fields.MOCAORYR,
                MOCAORDY = fields.MOCAORDY,
                MOCAORPL = fields.MOCAORPL,
                MOCAORCT = fields.MOCAORCT,
                NPSYCLOC = fields.NPSYCLOC,
                NPSYLAN = fields.NPSYLAN,
                NPSYLANX = fields.NPSYLANX,
                CRAFTVRS = fields.CRAFTVRS,
                CRAFTURS = fields.CRAFTURS,
                UDSBENTC = fields.UDSBENTC,
                DIGFORCT = fields.DIGFORCT,
                DIGFORSL = fields.DIGFORSL,
                DIGBACCT = fields.DIGBACCT,
                DIGBACLS = fields.DIGBACLS,
                ANIMALS = fields.ANIMALS,
                VEG = fields.VEG,
                TRAILA = fields.TRAILA,
                TRAILARR = fields.TRAILARR,
                TRAILALI = fields.TRAILALI,
                TRAILB = fields.TRAILB,
                TRAILBRR = fields.TRAILBRR,
                TRAILBLI = fields.TRAILBLI,
                CRAFTDVR = fields.CRAFTDVR,
                CRAFTDRE = fields.CRAFTDRE,
                CRAFTDTI = fields.CRAFTDTI,
                CRAFTCUE = fields.CRAFTCUE,
                UDSBENTD = fields.UDSBENTD,
                UDSBENRS = fields.UDSBENRS,
                MINTTOTS = fields.MINTTOTS,
                MINTTOTW = fields.MINTTOTW,
                MINTSCNG = fields.MINTSCNG,
                MINTSCNC = fields.MINTSCNC,
                MINTPCNG = fields.MINTPCNG,
                MINTPCNC = fields.MINTPCNC,
                UDSVERFC = fields.UDSVERFC,
                UDSVERFN = fields.UDSVERFN,
                UDSVERNF = fields.UDSVERNF,
                UDSVERLC = fields.UDSVERLC,
                UDSVERLR = fields.UDSVERLR,
                UDSVERLN = fields.UDSVERLN,
                UDSVERTN = fields.UDSVERTN,
                UDSVERTE = fields.UDSVERTE,
                UDSVERTI = fields.UDSVERTI,
                COGSTAT = fields.COGSTAT
            };
        }

        public static D1 ToVM(this D1FormFields fields, int formId)
        {
            return new D1()
            {
                Id = formId,
                DXMETHOD = fields.DXMETHOD,
                NORMCOG = fields.NORMCOG,
                DEMENTED = fields.DEMENTED,
                AMNDEM = fields.AMNDEM,
                PCA = fields.PCA,
                PPASYN = fields.PPASYN,
                PPASYNT = fields.PPASYNT,
                FTDSYN = fields.FTDSYN,
                LBDSYN = fields.LBDSYN,
                NAMNDEM = fields.NAMNDEM,
                MCIAMEM = fields.MCIAMEM,
                MCIAPLUS = fields.MCIAPLUS,
                MCIAPLAN = fields.MCIAPLAN,
                MCIAPATT = fields.MCIAPATT,
                MCIAPEX = fields.MCIAPEX,
                MCIAPVIS = fields.MCIAPVIS,
                MCINON1 = fields.MCINON1,
                MCIN1LAN = fields.MCIN1LAN,
                MCIN1ATT = fields.MCIN1ATT,
                MCIN1EX = fields.MCIN1EX,
                MCIN1VIS = fields.MCIN1VIS,
                MCINON2 = fields.MCINON2,
                MCIN2LAN = fields.MCIN2LAN,
                MCIN2ATT = fields.MCIN2ATT,
                MCIN2EX = fields.MCIN2EX,
                MCIN2VIS = fields.MCIN2VIS,
                IMPNOMCI = fields.IMPNOMCI,
                AMYLPET = fields.AMYLPET,
                AMYLCSF = fields.AMYLCSF,
                FDGAD = fields.FDGAD,
                HIPPATR = fields.HIPPATR,
                TAUPETAD = fields.TAUPETAD,
                CSFTAU = fields.CSFTAU,
                FDGFTLD = fields.FDGFTLD,
                TPETFTLD = fields.TPETFTLD,
                MRFTLD = fields.MRFTLD,
                DATSCAN = fields.DATSCAN,
                OTHBIOM = fields.OTHBIOM,
                OTHBIOMX = fields.OTHBIOMX,
                IMAGLINF = fields.IMAGLINF,
                IMAGLAC = fields.IMAGLAC,
                IMAGMACH = fields.IMAGMACH,
                IMAGMICH = fields.IMAGMICH,
                IMAGMWMH = fields.IMAGMWMH,
                IMAGEWMH = fields.IMAGEWMH,
                ADMUT = fields.ADMUT,
                FTLDMUT = fields.FTLDMUT,
                OTHMUT = fields.OTHMUT,
                OTHMUTX = fields.OTHMUTX,
                ALZDIS = fields.ALZDIS,
                ALZDISIF = fields.ALZDISIF,
                LBDIS = fields.LBDIS,
                LBDIF = fields.LBDIF,
                PARK = fields.PARK,
                MSA = fields.MSA,
                MSAIF = fields.MSAIF,
                PSP = fields.PSP,
                PSPIF = fields.PSPIF,
                CORT = fields.CORT,
                CORTIF = fields.CORTIF,
                FTLDMO = fields.FTLDMO,
                FTLDMOIF = fields.FTLDMOIF,
                FTLDNOS = fields.FTLDNOS,
                FTLDNOIF = fields.FTLDNOIF,
                FTLDSUBT = fields.FTLDSUBT,
                FTLDSUBX = fields.FTLDSUBX,
                CVD = fields.CVD,
                CVDIF = fields.CVDIF,
                PREVSTK = fields.PREVSTK,
                STROKDEC = fields.STROKDEC,
                STKIMAG = fields.STKIMAG,
                INFNETW = fields.INFNETW,
                INFWMH = fields.INFWMH,
                ESSTREM = fields.ESSTREM,
                ESSTREIF = fields.ESSTREIF,
                DOWNS = fields.DOWNS,
                DOWNSIF = fields.DOWNSIF,
                HUNT = fields.HUNT,
                HUNTIF = fields.HUNTIF,
                PRION = fields.PRION,
                PRIONIF = fields.PRIONIF,
                BRNINJ = fields.BRNINJ,
                BRNINJIF = fields.BRNINJIF,
                BRNINCTE = fields.BRNINCTE,
                HYCEPH = fields.HYCEPH,
                HYCEPHIF = fields.HYCEPHIF,
                EPILEP = fields.EPILEP,
                EPILEPIF = fields.EPILEPIF,
                NEOP = fields.NEOP,
                NEOPIF = fields.NEOPIF,
                NEOPSTAT = fields.NEOPSTAT,
                HIV = fields.HIV,
                HIVIF = fields.HIVIF,
                OTHCOG = fields.OTHCOG,
                OTHCOGIF = fields.OTHCOGIF,
                OTHCOGX = fields.OTHCOGX,
                DEP = fields.DEP,
                DEPIF = fields.DEPIF,
                DEPTREAT = fields.DEPTREAT,
                BIPOLDX = fields.BIPOLDX,
                BIPOLDIF = fields.BIPOLDIF,
                SCHIZOP = fields.SCHIZOP,
                SCHIZOIF = fields.SCHIZOIF,
                ANXIET = fields.ANXIET,
                ANXIETIF = fields.ANXIETIF,
                DELIR = fields.DELIR,
                DELIRIF = fields.DELIRIF,
                PTSDDX = fields.PTSDDX,
                PTSDDXIF = fields.PTSDDXIF,
                OTHPSY = fields.OTHPSY,
                OTHPSYIF = fields.OTHPSYIF,
                OTHPSYX = fields.OTHPSYX,
                ALCDEMIF = fields.ALCDEMIF,
                ALCABUSE = fields.ALCABUSE,
                IMPSUB = fields.IMPSUB,
                IMPSUBIF = fields.IMPSUBIF,
                DYSILL = fields.DYSILL,
                DYSILLIF = fields.DYSILLIF,
                MEDS = fields.MEDS,
                MEDSIF = fields.MEDSIF,
                COGOTH = fields.COGOTH,
                COGOTHIF = fields.COGOTHIF,
                COGOTHX = fields.COGOTHX,
                COGOTH2 = fields.COGOTH2,
                COGOTH2F = fields.COGOTH2F,
                COGOTH2X = fields.COGOTH2X,
                COGOTH3 = fields.COGOTH3,
                COGOTH3F = fields.COGOTH3F,
                COGOTH3X = fields.COGOTH3X
            };
        }

        public static D2 ToVM(this D2FormFields fields, int formId)
        {
            return new D2()
            {
                Id = formId,
                CANCER = fields.CANCER,
                CANCSITE = fields.CANCSITE,
                DIABET = fields.DIABET,
                MYOINF = fields.MYOINF,
                CONGHRT = fields.CONGHRT,
                AFIBRILL = fields.AFIBRILL,
                HYPERT = fields.HYPERT,
                ANGINA = fields.ANGINA,
                HYPCHOL = fields.HYPCHOL,
                VB12DEF = fields.VB12DEF,
                THYDIS = fields.THYDIS,
                ARTH = fields.ARTH,
                ARTYPE = fields.ARTYPE,
                ARTYPEX = fields.ARTYPEX,
                ARTUPEX = fields.ARTUPEX,
                ARTLOEX = fields.ARTLOEX,
                ARTSPIN = fields.ARTSPIN,
                ARTUNKN = fields.ARTUNKN,
                URINEINC = fields.URINEINC,
                BOWLINC = fields.BOWLINC,
                SLEEPAP = fields.SLEEPAP,
                REMDIS = fields.REMDIS,
                HYPOSOM = fields.HYPOSOM,
                SLEEPOTH = fields.SLEEPOTH,
                SLEEPOTX = fields.SLEEPOTX,
                ANGIOCP = fields.ANGIOCP,
                ANGIOPCI = fields.ANGIOPCI,
                PACEMAKE = fields.PACEMAKE,
                HVALVE = fields.HVALVE,
                ANTIENC = fields.ANTIENC,
                ANTIENCX = fields.ANTIENCX,
                OTHCOND = fields.OTHCOND,
                OTHCONDX = fields.OTHCONDX
            };
        }

        public static T1 ToVM(this T1FormFields fields, int formId)
        {
            return new T1()
            {
                Id = formId,
                TELCOG = fields.TELCOG,
                TELILL = fields.TELILL,
                TELHOME = fields.TELHOME,
                TELREFU = fields.TELREFU,
                TELCOV = fields.TELCOV,
                TELOTHR = fields.TELOTHR,
                TELOTHRX = fields.TELOTHRX,
                TELMOD = fields.TELMOD,
                TELINPER = fields.TELINPER,
                TELMILE = fields.TELMILE
            };
        }
    }
}

