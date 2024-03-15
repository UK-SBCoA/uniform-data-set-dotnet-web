using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                IsDeleted = participation.IsDeleted,
                VisitCount = participation.VisitCount,
                LastVisitNumber = participation.LastVisitNumber
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

        public static M1Dto ToDto(this Milestone milestone)
        {
            return new M1Dto
            {
                FormId = milestone.FormId,
                ParticipationId = milestone.ParticipationId,
                Status = milestone.Status,
                CHANGEMO = milestone.CHANGEMO,
                CHANGEDY = milestone.CHANGEDY,
                CHANGEYR = milestone.CHANGEYR,
                PROTOCOL = milestone.PROTOCOL,
                ACONSENT = milestone.ACONSENT,
                RECOGIM = milestone.RECOGIM,
                REPHYILL = milestone.REPHYILL,
                REREFUSE = milestone.REREFUSE,
                RENAVAIL = milestone.RENAVAIL,
                RENURSE = milestone.RENURSE,
                NURSEMO = milestone.NURSEMO,
                NURSEDY = milestone.NURSEDY,
                NURSEYR = milestone.NURSEYR,
                REJOIN = milestone.REJOIN,
                FTLDDISC = milestone.FTLDDISC,
                FTLDREAS = milestone.FTLDREAS,
                FTLDREAX = milestone.FTLDREAX,
                DECEASED = milestone.DECEASED,
                DISCONT = milestone.DISCONT,
                DEATHMO = milestone.DEATHMO,
                DEATHDY = milestone.DEATHDY,
                DEATHYR = milestone.DEATHYR,
                AUTOPSY = milestone.AUTOPSY,
                DISCMO = milestone.DISCMO,
                DISCDAY = milestone.DISCDAY,
                DISCYR = milestone.DISCYR,
                DROPREAS = milestone.DROPREAS,
                CreatedAt = milestone.CreatedAt,
                CreatedBy = milestone.CreatedBy,
                ModifiedBy = milestone.ModifiedBy,
                DeletedBy = milestone.DeletedBy,
                IsDeleted = milestone.IsDeleted,
            };
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
            if (form.Fields is A1aFormFields)
            {
                dto = ((A1aFormFields)form.Fields).ToDto();
            }
            else if (form.Fields is A1FormFields)
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
            else if (form.Fields is A4aFormFields)
            {
                dto = ((A4aFormFields)form.Fields).ToDto(form.Id);
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
            if (form.Fields is A1aFormFields && formKind == "A1a")
            {
                dto = ((A1aFormFields)form.Fields).ToDto();
            }
            else if (form.Fields is A1FormFields && formKind == "A1")
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
            else if (form.Fields is A4aFormFields && formKind == "A4a")
            {
                dto = ((A4aFormFields)form.Fields).ToDto(form.Id);
            }
            else if (form.Fields is A5FormFields && formKind == "A5D2")
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
            else if (form.Fields is T1FormFields && formKind == "T1")
            {
                dto = ((T1FormFields)form.Fields).ToDto();
            }

            SetBaseProperties(dto, form);

            return dto;
        }

        public static A1aDto ToDto(this A1aFormFields fields)
        {
            return new A1aDto()
            {
                OWNSCAR = fields.OWNSCAR,
                TRSPACCESS = fields.TRSPACCESS,
                TRANSPROB = fields.TRANSPROB,
                TRANSWORRY = fields.TRANSWORRY,
                TRSPLONGER = fields.TRSPLONGER,
                TRSPMED = fields.TRSPMED,
                INCOMEYR = fields.INCOMEYR,
                FINSATIS = fields.FINSATIS,
                BILLPAY = fields.BILLPAY,
                FINUPSET = fields.FINUPSET,
                EATLESS = fields.EATLESS,
                EATLESSYR = fields.EATLESSYR,
                LESSMEDS = fields.LESSMEDS,
                LESSMEDSYR = fields.LESSMEDSYR,
                COMPCOMM = fields.COMPCOMM,
                COMPUSA = fields.COMPUSA,
                FAMCOMP = fields.FAMCOMP,
                GUARDEDU = fields.GUARDEDU,
                GUARDREL = fields.GUARDREL,
                GUARDRELX = fields.GUARDRELX,
                GUARD2EDU = fields.GUARD2EDU,
                GUARD2REL = fields.GUARD2REL,
                GUARD2RELX = fields.GUARD2RELX,
                EMPTINESS = fields.EMPTINESS,
                MISSPEOPLE = fields.MISSPEOPLE,
                FRIENDS = fields.FRIENDS,
                ABANDONED = fields.ABANDONED,
                CLOSEFRND = fields.CLOSEFRND,
                PARENTCOMM = fields.PARENTCOMM,
                CHILDCOMM = fields.CHILDCOMM,
                FRIENDCOMM = fields.FRIENDCOMM,
                PARTICIPATE = fields.PARTICIPATE,
                SAFEHOME = fields.SAFEHOME,
                SAFECOMM = fields.SAFECOMM,
                DELAYMED = fields.DELAYMED,
                SCRIPTPROB = fields.SCRIPTPROB,
                MISSEDFUP = fields.MISSEDFUP,
                DOCADVICE = fields.DOCADVICE,
                HEALTHACC = fields.HEALTHACC,
                LESSCOURT = fields.LESSCOURT,
                POORSERV = fields.POORSERV,
                NOTSMART = fields.NOTSMART,
                ACTAFRAID = fields.ACTAFRAID,
                THREATENED = fields.THREATENED,
                POORMEDTRT = fields.POORMEDTRT,
                EXPANCEST = fields.EXPANCEST,
                EXPGENDER = fields.EXPGENDER,
                EXPRACE = fields.EXPRACE,
                EXPAGE = fields.EXPAGE,
                EXPRELIG = fields.EXPRELIG,
                EXPHEIGHT = fields.EXPHEIGHT,
                EXPWEIGHT = fields.EXPWEIGHT,
                EXPAPPEAR = fields.EXPAPPEAR,
                EXPSEXORN = fields.EXPSEXORN,
                EXPEDUCINC = fields.EXPEDUCINC,
                EXPDISAB = fields.EXPDISAB,
                EXPSKIN = fields.EXPSKIN,
                EXPOTHER = fields.EXPOTHER,
                EXPNOTAPP = fields.EXPNOTAPP,
                EXPNOANS = fields.EXPNOANS,
                EXPSTRS = fields.EXPSTRS,
            };
        }

        public static A1Dto ToDto(this A1FormFields fields)
        {
            return new A1Dto()
            {
                BIRTHMO = fields.BIRTHMO,
                BIRTHYR = fields.BIRTHYR,
                CHLDHDCTRY = fields.CHLDHDCTRY,
                RACEWHITE = fields.RACEWHITE,
                ETHGERMAN = fields.ETHGERMAN,
                ETHIRISH = fields.ETHIRISH,
                ETHENGLISH = fields.ETHENGLISH,
                ETHITALIAN = fields.ETHITALIAN,
                ETHPOLISH = fields.ETHPOLISH,
                ETHFRENCH = fields.ETHFRENCH,
                ETHWHIOTH = fields.ETHWHIOTH,
                ETHWHIOTHX = fields.ETHWHIOTHX,
                ETHISPANIC = fields.ETHISPANIC,
                ETHMEXICAN = fields.ETHMEXICAN,
                ETHPUERTO = fields.ETHPUERTO,
                ETHCUBAN = fields.ETHCUBAN,
                ETHSALVA = fields.ETHSALVA,
                ETHDOMIN = fields.ETHDOMIN,
                ETHCOLOM = fields.ETHCOLOM,
                ETHHISOTH = fields.ETHHISOTH,
                ETHHISOTHX = fields.ETHHISOTHX,
                RACEBLACK = fields.RACEBLACK,
                ETHAFAMER = fields.ETHAFAMER,
                ETHJAMAICA = fields.ETHJAMAICA,
                ETHHAITIAN = fields.ETHHAITIAN,
                ETHNIGERIA = fields.ETHNIGERIA,
                ETHETHIOP = fields.ETHETHIOP,
                ETHSOMALI = fields.ETHSOMALI,
                ETHBLKOTH = fields.ETHBLKOTH,
                ETHBLKOTHX = fields.ETHBLKOTHX,
                RACEASIAN = fields.RACEASIAN,
                ETHCHINESE = fields.ETHCHINESE,
                ETHFILIP = fields.ETHFILIP,
                ETHINDIA = fields.ETHINDIA,
                ETHVIETNAM = fields.ETHVIETNAM,
                ETHKOREAN = fields.ETHKOREAN,
                ETHJAPAN = fields.ETHJAPAN,
                ETHASNOTH = fields.ETHASNOTH,
                ETHASNOTHX = fields.ETHASNOTHX,
                RACEAIAN = fields.RACEAIAN,
                RACEAIANX = fields.RACEAIANX,
                RACEMENA = fields.RACEMENA,
                ETHLEBANON = fields.ETHLEBANON,
                ETHIRAN = fields.ETHIRAN,
                ETHEGYPT = fields.ETHEGYPT,
                ETHSYRIA = fields.ETHSYRIA,
                ETHMOROCCO = fields.ETHMOROCCO,
                ETHISRAEL = fields.ETHISRAEL,
                ETHMENAOTH = fields.ETHMENAOTH,
                ETHMENAOTX = fields.ETHMENAOTX,
                RACENHPI = fields.RACENHPI,
                ETHHAWAII = fields.ETHHAWAII,
                ETHSAMOAN = fields.ETHSAMOAN,
                ETHCHAMOR = fields.ETHCHAMOR,
                ETHTONGAN = fields.ETHTONGAN,
                ETHFIJIAN = fields.ETHFIJIAN,
                ETHMARSHAL = fields.ETHMARSHAL,
                ETHNHPIOTH = fields.ETHNHPIOTH,
                ETHNHPIOTX = fields.ETHNHPIOTX,
                RACEUNKN = fields.RACEUNKN,
                GENMAN = fields.GENMAN,
                GENWOMAN = fields.GENWOMAN,
                GENTRMAN = fields.GENTRMAN,
                GENTRWOMAN = fields.GENTRWOMAN,
                GENNONBI = fields.GENNONBI,
                GENTWOSPIR = fields.GENTWOSPIR,
                GENOTH = fields.GENOTH,
                GENOTHX = fields.GENOTHX,
                GENDKN = fields.GENDKN,
                GENNOANS = fields.GENNOANS,
                BIRTHSEX = fields.BIRTHSEX,
                INTERSEX = fields.INTERSEX,
                SEXORNGAY = fields.SEXORNGAY,
                SEXORNHET = fields.SEXORNHET,
                SEXORNBI = fields.SEXORNBI,
                SEXORNTWOS = fields.SEXORNTWOS,
                SEXORNOTH = fields.SEXORNOTH,
                SEXORNOTHX = fields.SEXORNOTHX,
                SEXORNDNK = fields.SEXORNDNK,
                SEXORNNOAN = fields.SEXORNNOAN,
                PREDOMLAN = fields.PREDOMLAN,
                PREDOMLANX = fields.PREDOMLANX,
                HANDED = fields.HANDED,
                EDUC = fields.EDUC,
                LVLEDUC = fields.LVLEDUC,
                MARISTAT = fields.MARISTAT,
                LIVSITUA = fields.LIVSITUA,
                RESIDENC = fields.RESIDENC,
                ZIP = fields.ZIP,
                SERVED = fields.SERVED,
                MEDVA = fields.MEDVA,
                EXRTIME = fields.EXRTIME,
                MEMWORS = fields.MEMWORS,
                MEMTROUB = fields.MEMTROUB,
                MEMTEN = fields.MEMTEN,
                ADISTATE = fields.ADISTATE,
                ADINAT = fields.ADINAT,
                PRIOCC = fields.PRIOCC,
                SOURCENW = fields.SOURCENW,
                REFERSC = fields.REFERSC,
                REFERSCX = fields.REFERSCX,
                REFLEARNED = fields.REFLEARNED,
                REFCTRSOCX = fields.REFCTRSOCX,
                REFCTRREGX = fields.REFCTRREGX,
                REFOTHWEBX = fields.REFOTHWEBX,
                REFOTHMEDX = fields.REFOTHMEDX,
                REFOTHREGX = fields.REFOTHREGX,
                REFOTHX = fields.REFOTHX
            };
        }

        public static A2Dto ToDto(this A2FormFields fields)
        {
            return new A2Dto()
            {
                NEWINF = fields.NEWINF,
                INRELTO = fields.INRELTO,
                INKNOWN = fields.INKNOWN,
                INLIVWTH = fields.INLIVWTH,
                INCNTMOD = fields.INCNTMOD,
                INCNTMDX = fields.INCNTMDX,
                INCNTFRQ = fields.INCNTFRQ,
                INCNTTIM = fields.INCNTTIM,
                INRELY = fields.INRELY,
                INMEMWORS = fields.INMEMWORS,
                INMEMTROUB = fields.INMEMTROUB,
                INMEMTEN = fields.INMEMTEN,
            };
        }

        public static A3Dto ToDto(this A3FormFields fields, int formId)
        {
            var dto = new A3Dto()
            {
                AFFFAMM = fields.AFFFAMM,
                NWINFMUT = fields.NWINFMUT,
                MOMYOB = fields.MOMYOB,
                MOMDAGE = fields.MOMDAGE,
                MOMAGEO = fields.MOMAGEO,
                DADYOB = fields.DADYOB,
                DADDAGE = fields.DADDAGE,
                DADAGEO = fields.DADAGEO,
                SIBS = fields.SIBS,
                KIDS = fields.KIDS
            };

            foreach (var sib in fields.SiblingFormFields)
            {
                var sibDto = sib.ToDto(formId);
                if (sib.FamilyMemberIndex == 1)
                    dto.SIB1 = sibDto;
                else if (sib.FamilyMemberIndex == 2)
                    dto.SIB2 = sibDto;
                else if (sib.FamilyMemberIndex == 3)
                    dto.SIB3 = sibDto;
                else if (sib.FamilyMemberIndex == 4)
                    dto.SIB4 = sibDto;
                else if (sib.FamilyMemberIndex == 5)
                    dto.SIB5 = sibDto;
                else if (sib.FamilyMemberIndex == 6)
                    dto.SIB6 = sibDto;
                else if (sib.FamilyMemberIndex == 7)
                    dto.SIB7 = sibDto;
                else if (sib.FamilyMemberIndex == 8)
                    dto.SIB8 = sibDto;
                else if (sib.FamilyMemberIndex == 9)
                    dto.SIB9 = sibDto;
                else if (sib.FamilyMemberIndex == 10)
                    dto.SIB10 = sibDto;
                else if (sib.FamilyMemberIndex == 11)
                    dto.SIB11 = sibDto;
                else if (sib.FamilyMemberIndex == 12)
                    dto.SIB12 = sibDto;
                else if (sib.FamilyMemberIndex == 13)
                    dto.SIB13 = sibDto;
                else if (sib.FamilyMemberIndex == 14)
                    dto.SIB14 = sibDto;
                else if (sib.FamilyMemberIndex == 15)
                    dto.SIB15 = sibDto;
                else if (sib.FamilyMemberIndex == 16)
                    dto.SIB16 = sibDto;
                else if (sib.FamilyMemberIndex == 17)
                    dto.SIB17 = sibDto;
                else if (sib.FamilyMemberIndex == 18)
                    dto.SIB18 = sibDto;
                else if (sib.FamilyMemberIndex == 19)
                    dto.SIB19 = sibDto;
                else if (sib.FamilyMemberIndex == 20)
                    dto.SIB20 = sibDto;
            }

            foreach (var kid in fields.KidsFormFields)
            {
                var kidDto = kid.ToDto(formId);
                if (kid.FamilyMemberIndex == 1)
                    dto.KID1 = kidDto;
                else if (kid.FamilyMemberIndex == 2)
                    dto.KID2 = kidDto;
                else if (kid.FamilyMemberIndex == 3)
                    dto.KID3 = kidDto;
                else if (kid.FamilyMemberIndex == 4)
                    dto.KID4 = kidDto;
                else if (kid.FamilyMemberIndex == 5)
                    dto.KID5 = kidDto;
                else if (kid.FamilyMemberIndex == 6)
                    dto.KID6 = kidDto;
                else if (kid.FamilyMemberIndex == 7)
                    dto.KID7 = kidDto;
                else if (kid.FamilyMemberIndex == 8)
                    dto.KID8 = kidDto;
                else if (kid.FamilyMemberIndex == 9)
                    dto.KID9 = kidDto;
                else if (kid.FamilyMemberIndex == 10)
                    dto.KID10 = kidDto;
                else if (kid.FamilyMemberIndex == 11)
                    dto.KID11 = kidDto;
                else if (kid.FamilyMemberIndex == 12)
                    dto.KID12 = kidDto;
                else if (kid.FamilyMemberIndex == 13)
                    dto.KID13 = kidDto;
                else if (kid.FamilyMemberIndex == 14)
                    dto.KID14 = kidDto;
                else if (kid.FamilyMemberIndex == 15)
                    dto.KID15 = kidDto;
            }

            return dto;
        }

        public static A3FamilyMemberDto ToDto(this A3FamilyMemberFormFields fields, int formId)
        {
            return new A3FamilyMemberDto
            {
                FormId = formId,
                YOB = fields.YOB,
                AGD = fields.AGD,
                AGO = fields.AGO
            };
        }

        public static A4Dto ToDto(this A4GFormFields fields, Form form)
        {
            return new A4Dto
            {
                ANYMEDS = fields.ANYMEDS,
                A4DetailsDtos = fields.A4Ds.ToDto()
            };
        }

        public static List<int> ToDto(this List<A4DFormFields> fields)
        {
            List<int> rxNormIds = new List<int>();
            foreach (var field in fields)
            {
                if (Int32.TryParse(field.RxNormId, out int rxNormId))
                {
                    rxNormIds.Add(rxNormId);
                }
            }
            return rxNormIds;
        }



        public static A4aDto ToDto(this A4aFormFields fields, int formId)
        {
            var dto = new A4aDto()
            {
                ADVEVENT = fields.ADVEVENT,
                ARIAE = fields.ARIAE,
                ARIAH = fields.ARIAH,
                ADVERSEOTH = fields.ADVERSEOTH,
                ADVERSEOTX = fields.ADVERSEOTX,
                TRTBIOMARK = fields.TRTBIOMARK
            };

            foreach (var treatment in fields.TreatmentFormFields)
            {
                var treatmentDto = treatment.ToDto(formId);
                if (treatment.TreatmentIndex == 1)
                    dto.Treatment1 = treatmentDto;
                else if (treatment.TreatmentIndex == 2)
                    dto.Treatment2 = treatmentDto;
                else if (treatment.TreatmentIndex == 3)
                    dto.Treatment3 = treatmentDto;
                else if (treatment.TreatmentIndex == 4)
                    dto.Treatment4 = treatmentDto;
                else if (treatment.TreatmentIndex == 5)
                    dto.Treatment5 = treatmentDto;
                else if (treatment.TreatmentIndex == 6)
                    dto.Treatment6 = treatmentDto;
                else if (treatment.TreatmentIndex == 7)
                    dto.Treatment7 = treatmentDto;
                else if (treatment.TreatmentIndex == 8)
                    dto.Treatment8 = treatmentDto;

            }

            return dto;
        }


        public static A4aTreatmentDto ToDto(this A4aTreatmentFormFields fields, int formId)
        {
            return new A4aTreatmentDto
            {
                FormId = formId,
                TARGETAB = fields.TARGETAB,
                TARGETTAU = fields.TARGETTAU,
                TARGETINF = fields.TARGETINF,
                TARGETSYN = fields.TARGETSYN,
                TARGETOTH = fields.TARGETOTH,
                TARGETOTX = fields.TARGETOTX,
                TRTTRIAL = fields.TRTTRIAL,
                NCTNUM = fields.NCTNUM,
                STARTMO = fields.STARTMO,
                STARTYEAR = fields.STARTYEAR,
                ENDMO = fields.ENDMO,
                ENDYEAR = fields.ENDYEAR,
                CARETRIAL = fields.CARETRIAL,
                TRIALGRP = fields.TRIALGRP
            };
        }

        public static A5D2Dto ToDto(this A5FormFields fields)
        {
            return new A5D2Dto
            {
                TOBAC30 = fields.TOBAC30,
                TOBAC100 = fields.TOBAC100,
                SMOKYRS = fields.SMOKYRS,
                PACKSPER = fields.PACKSPER,
                QUITSMOK = fields.QUITSMOK,
                CVAFIB = fields.CVAFIB,
                CVANGIO = fields.CVANGIO,
                CVBYPASS = fields.CVBYPASS,
                CVPACDEF = fields.CVPACDEF,
                CVCHF = fields.CVCHF,
                CVHVALVE = fields.CVHVALVE,
                CVOTHR = fields.CVOTHR,
                CVOTHRX = fields.CVOTHRX,
                CBSTROKE = fields.CBSTROKE,
                STROKMUL = fields.STROKMUL,
                CBTIA = fields.CBTIA,
                PD = fields.PD,
                PDOTHR = fields.PDOTHR,
                SEIZURES = fields.SEIZURES,
                DIABETES = fields.DIABETES,
                DIABTYPE = fields.DIABTYPE,
                HYPERTEN = fields.HYPERTEN,
                HYPERCHO = fields.HYPERCHO,
                B12DEF = fields.B12DEF,
                THYROID = fields.THYROID,
                ARTHRIT = fields.ARTHRIT,
                ARTHTYPX = fields.ARTHTYPX,
                INCONTU = fields.INCONTU,
                INCONTF = fields.INCONTF,
                APNEA = fields.APNEA,
                RBD = fields.RBD,
                INSOMN = fields.INSOMN,
                OTHSLEEP = fields.OTHSLEEP,
                OTHSLEEX = fields.OTHSLEEX,
                PTSD = fields.PTSD,
                BIPOLAR = fields.BIPOLAR,
                SCHIZ = fields.SCHIZ,
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
                HRATE = fields.HRATE,
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
                PARKSIGN = fields.PARKSIGN,
                POSTINST = fields.POSTINST,
                APRAXSP = fields.APRAXSP
            };
        }

        public static B9Dto ToDto(this B9FormFields fields)
        {
            return new B9Dto
            {
                COGMEM = fields.COGMEM,
                COGORI = fields.COGORI,
                COGJUDG = fields.COGJUDG,
                COGLANG = fields.COGLANG,
                COGVIS = fields.COGVIS,
                COGATTN = fields.COGATTN,
                COGFLUC = fields.COGFLUC,
                COGOTHR = fields.COGOTHR,
                COGOTHRX = fields.COGOTHRX,
                COGMODE = fields.COGMODE,
                COGMODEX = fields.COGMODEX,
                DECCLBE = fields.DECCLBE,
                BEAPATHY = fields.BEAPATHY,
                BEDEP = fields.BEDEP,
                BEVHALL = fields.BEVHALL,
                BEVWELL = fields.BEVWELL,
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
                BEMODE = fields.BEMODE,
                BEMODEX = fields.BEMODEX,
                MOGAIT = fields.MOGAIT,
                MOFALLS = fields.MOFALLS,
                MOTREM = fields.MOTREM,
                MOSLOW = fields.MOSLOW,
                MOMODE = fields.MOMODE,
                MOMODEX = fields.MOMODEX,
                MOMOPARK = fields.MOMOPARK,
                MOMOALS = fields.MOMOALS,
                COURSE = fields.COURSE,
                FRSTCHG = fields.FRSTCHG,
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
                COGSTAT = fields.COGSTAT,
                REY1REC = fields.REY1REC,
                REY1INT = fields.REY1INT,
                REY2REC = fields.REY2REC,
                REY2INT = fields.REY2INT,
                REY3REC = fields.REY3REC,
                REY3INT = fields.REY3INT,
                REY4REC = fields.REY4REC,
                REY4INT = fields.REY4INT,
                REY5REC = fields.REY5REC,
                REY5INT = fields.REY5INT,
                REY6REC = fields.REY6REC,
                REY6INT = fields.REY6INT,
                REYDREC = fields.REYDREC,
                REYDINT = fields.REYDINT,
                REYTCOR = fields.REYTCOR,
                REYFPOS = fields.REYFPOS,
                RESPVAL = fields.RESPVAL,
                RESPHEAR = fields.RESPHEAR,
                RESPDIST = fields.RESPDIST,
                RESPINTR = fields.RESPINTR,
                RESPDISN = fields.RESPDISN,
                RESPFATG = fields.RESPFATG,
                RESPEMOT = fields.RESPEMOT,
                RESPASST = fields.RESPASST,
                RESPOTH = fields.RESPOTH,
                RESPOTHX = fields.RESPOTHX
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

