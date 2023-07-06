using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using UDS.Net.Dto;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.Extensions
{
    public static class DomainToDtoMapper
    {
        private static void SetBaseProperties(FormDto dto, Form form)
        {

            dto.Id = form.Id;
            dto.VisitId = form.VisitId;
            dto.Kind = form.Kind;
            dto.Status = ((int)form.Status).ToString();
            dto.Language = ((int)form.Language).ToString();
            dto.IsIncluded = form.IsIncluded;
            dto.ReasonCode = form.ReasonCode.HasValue ? ((int)form.ReasonCode.Value).ToString() : "";
            dto.CreatedAt = form.CreatedAt;
            dto.CreatedBy = form.CreatedBy;
            dto.ModifiedBy = form.ModifiedBy;
            dto.DeletedBy = form.DeletedBy;
            dto.IsDeleted = form.IsDeleted;
        }

        public static ParticipationDto ToDto(this Participation participation)
        {
            return new ParticipationDto
            {
                Id = participation.Id,
                LegacyId = participation.LegacyId,
                CreatedAt = participation.CreatedAt,
                CreatedBy = participation.CreatedBy,
                ModifiedBy = participation.ModifiedBy,
                DeletedBy = participation.DeletedBy,
                IsDeleted = participation.IsDeleted
            };
        }
        public static VisitDto ToDto(this Visit visit)
        {
            var dto = new VisitDto()
            {
                Id = visit.Id,
                ParticipationId = visit.ParticipationId,
                Number = visit.Number,
                Version = visit.Version,
                Kind = visit.Kind.ToString(),
                StartDateTime = visit.StartDateTime,
                CreatedAt = visit.CreatedAt,
                CreatedBy = visit.CreatedBy,
                ModifiedBy = visit.ModifiedBy,
                DeletedBy = visit.DeletedBy,
                IsDeleted = visit.IsDeleted
            };
            if (visit.Forms != null)
                dto.Forms = visit.Forms.ToDto();

            return dto;
        }

        public static VisitDto ToDto(this Visit visit, string formKind)
        {
            var dto = new VisitDto()
            {
                Id = visit.Id,
                ParticipationId = visit.ParticipationId,
                Number = visit.Number,
                Version = visit.Version,
                Kind = visit.Kind.ToString(),
                StartDateTime = visit.StartDateTime,
                CreatedAt = visit.CreatedAt,
                CreatedBy = visit.CreatedBy,
                ModifiedBy = visit.ModifiedBy,
                DeletedBy = visit.DeletedBy,
                IsDeleted = visit.IsDeleted
            };
            if (visit.Forms != null)
                dto.Forms = visit.Forms.ToDto(formKind);

            return dto;
        }

        public static List<FormDto> ToDto(this IList<Form> forms)
        {
            return forms.Select(f => f.ToDto()).ToList();
        }

        public static List<FormDto> ToDto(this IList<Form> forms, string formKind)
        {
            return forms.Select(f => f.ToDto(formKind)).ToList();
        }

        private static FormDto GetDto(Form form)
        {
            string reasonCode = "";
            if (form.Status == FormStatus.NotIncluded && form.ReasonCode.HasValue)
                reasonCode = ((int)form.ReasonCode).ToString();

            // set default formDto and then override with more details if it is a strongly typed object
            FormDto dto = new FormDto()
            {
                Id = form.Id,
                VisitId = form.VisitId,
                Kind = form.Kind,
                Status = ((int)form.Status).ToString(),
                Language = ((int)form.Language).ToString(),
                IsIncluded = form.IsIncluded,
                ReasonCode = reasonCode,
                CreatedAt = form.CreatedAt,
                CreatedBy = form.CreatedBy,
                ModifiedBy = form.ModifiedBy,
                DeletedBy = form.DeletedBy,
                IsDeleted = form.IsDeleted
            };

            return dto;
        }

        public static FormDto ToDto(this Form form)
        {
            FormDto dto = GetDto(form); // get baseline dto

            // if the form is a special type then get that type of dto
            if (form.Fields is A1FormFields)
            {
                dto = ((A1FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is A2FormFields)
            {
                dto = ((A2FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is A3FormFields)
            {
                dto = ((A3FormFields)form.Fields).ToDto(form.Id);
            }
            else if (form.Fields is A4GFormFields)
            {
                dto = ((A4GFormFields)form.Fields).ToDto(form);
            }
            else if (form.Fields is A5FormFields)
            {
                dto = ((A5FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is B1FormFields)
            {
                dto = ((B1FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is B4FormFields)
            {
                dto = ((B4FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is B5FormFields)
            {
                dto = ((B5FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is B6FormFields)
            {
                dto = ((B6FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is B7FormFields)
            {
                dto = ((B7FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is B8FormFields)
            {
                dto = ((B8FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is B9FormFields)
            {
                dto = ((B9FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is C1FormFields)
            {
                dto = ((C1FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is C2FormFields)
            {
                dto = ((C2FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is D1FormFields)
            {
                dto = ((D1FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is D2FormFields)
            {
                dto = ((D2FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is T1FormFields)
            {
                dto = ((T1FormFields)form.Fields).ToDto();
            }

            SetBaseProperties(dto, form);

            return dto;

        }

        public static FormDto ToDto(this Form form, string formKind)
        {
            FormDto dto = GetDto(form); // get baseline form dto

            // if the type of form we want to retun matches the specialized type
            // then return the special dto, otherwise just return the baseline
            if (form.Fields is A1FormFields && formKind == "A1")
            {
                dto = ((A1FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is A2FormFields && formKind == "A2")
            {
                dto = ((A2FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is A3FormFields && formKind == "A3")
            {
                dto = ((A3FormFields)form.Fields).ToDto(form.Id);
            }
            else if (form.Fields is A4GFormFields && formKind == "A4")
            {
                dto = ((A4GFormFields)form.Fields).ToDto(form);
            }
            else if (form.Fields is A5FormFields && formKind == "A5")
            {
                dto = ((A5FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is B1FormFields && formKind == "B1")
            {
                dto = ((B1FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is B4FormFields && formKind == "B4")
            {
                dto = ((B4FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is B5FormFields && formKind == "B5")
            {
                dto = ((B5FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is B6FormFields && formKind == "B6")
            {
                dto = ((B6FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is B7FormFields && formKind == "B7")
            {
                dto = ((B7FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is B8FormFields && formKind == "B8")
            {
                dto = ((B8FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is B9FormFields && formKind == "B9")
            {
                dto = ((B9FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is C1FormFields && formKind == "C1")
            {
                dto = ((C1FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is C2FormFields && formKind == "C2")
            {
                dto = ((C2FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is D1FormFields && formKind == "D1")
            {
                dto = ((D1FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is D2FormFields && formKind == "D2")
            {
                dto = ((D2FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is T1FormFields && formKind == "T1")
            {
                dto = ((T1FormFields)form.Fields).ToDto();
            }

            SetBaseProperties(dto, form);

            return dto;
        }

        public static A1Dto ToDto(this A1FormFields fields)
        {
            return new A1Dto()
            {
                REASON = fields.REASON,
                REFERSC = fields.REFERSC,
                LEARNED = fields.LEARNED,
                PRESTAT = fields.PRESTAT,
                PRESPART = fields.PRESPART,
                SOURCENW = fields.SOURCENW,
                BIRTHMO = fields.BIRTHMO,
                BIRTHYR = fields.BIRTHYR,
                SEX = fields.SEX,
                MARISTAT = fields.MARISTAT,
                LIVSITUA = fields.LIVSITUA,
                INDEPEND = fields.INDEPEND,
                RESIDENC = fields.RESIDENC,
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

        public static A2Dto ToDto(this A2FormFields fields)
        {
            return new A2Dto()
            {
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

        public static A3Dto ToDto(this A3FormFields fields, int formId)
        {
            var dto = new A3Dto()
            {
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
                //MOMPRDX = fields.MOMPRDX, /// TODO Add property to A3 dto
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
                KIDS = fields.KIDS
            };

            foreach (var sib in fields.SiblingFormFields)
            {
                // TODO map a3 siblings
                var sibDto = sib.ToDto(formId);
            }

            foreach (var kid in fields.KidsFormFields)
            {
                // TODO map a3 children
                var kidSto = kid.ToDto(formId);

            }

            return dto;
        }

        public static A3FamilyMemberDto ToDto(this A3FamilyMemberFormFields fields, int formId)
        {
            return new A3FamilyMemberDto
            {
                FormId = formId,
                MOB = fields.MOB,
                YOB = fields.YOB,
                AGD = fields.AGD,
                NEU = fields.NEU,
                PDX = fields.PDX,
                MOE = fields.MOE,
                AGO = fields.AGO
            };
        }

        public static A4GDto ToDto(this A4GFormFields fields, Form form)
        {
            return new A4GDto
            {
                ANYMEDS = fields.ANYMEDS,
                A4Dtos = fields.A4Ds.Select(a => a.ToDto(form)).ToList()
            };
        }

        public static A4DDto ToDto(this A4DFormFields fields, Form form)
        {
            var dto = new A4DDto
            {
                DRUGID = fields.DRUGID
            };

            SetBaseProperties(dto, form);

            return dto;
        }

        public static A5Dto ToDto(this A5FormFields fields)
        {
            return new A5Dto
            {
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

        public static B1Dto ToDto(this B1FormFields fields)
        {
            return new B1Dto
            {
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

        public static B4Dto ToDto(this B4FormFields fields)
        {
            return new B4Dto
            {
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

        public static B5Dto ToDto(this B5FormFields fields)
        {
            return new B5Dto
            {
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

        public static B6Dto ToDto(this B6FormFields fields)
        {
            return new B6Dto
            {
                NOGDS = fields.NOGDS,
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

        public static B7Dto ToDto(this B7FormFields fields)
        {
            return new B7Dto
            {
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

        public static B8Dto ToDto(this B8FormFields fields)
        {
            return new B8Dto
            {
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

        public static B9Dto ToDto(this B9FormFields fields)
        {
            return new B9Dto
            {
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

        public static C1Dto ToDto(this C1FormFields fields)
        {
            return new C1Dto
            {
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

        public static C2Dto ToDto(this C2FormFields fields)
        {
            return new C2Dto
            {
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

        public static D1Dto ToDto(this D1FormFields fields)
        {
            return new D1Dto
            {
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

        public static D2Dto ToDto(this D2FormFields fields)
        {
            return new D2Dto
            {
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

        public static T1Dto ToDto(this T1FormFields fields)
        {
            return new T1Dto
            {
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

