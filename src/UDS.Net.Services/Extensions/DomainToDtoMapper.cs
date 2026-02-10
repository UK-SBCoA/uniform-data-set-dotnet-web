using System;
using System.Collections.Generic;
using System.Linq;
using UDS.Net.Dto;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;
using UDS.Net.Services.LookupModels;

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
            dto.FRMDATE = form.FRMDATE;
            dto.INITIALS = form.INITIALS;
            dto.LANG = ((int)form.LANG).ToString();
            dto.MODE = ((int)form.MODE).ToString();
            dto.RMREAS = form.RMREAS.HasValue ? ((int)form.RMREAS).ToString() : "";
            dto.RMMODE = form.RMMODE.HasValue ? ((int)form.RMMODE).ToString() : "";
            dto.NOT = form.NOT.HasValue ? ((int)form.NOT).ToString() : "";
            dto.ADMIN = form.ADMIN.HasValue ? ((int)form.ADMIN).ToString() : "";
            dto.CreatedAt = form.CreatedAt;
            dto.CreatedBy = form.CreatedBy;
            dto.ModifiedBy = form.ModifiedBy;
            dto.DeletedBy = form.DeletedBy;
            dto.IsDeleted = form.IsDeleted;
        }

        private static void SetBaseVisitProperties(VisitDto dto, Visit visit)
        {
            dto.Id = visit.Id;
            dto.ParticipationId = visit.ParticipationId;
            dto.VISITNUM = visit.VISITNUM;
            dto.FORMVER = visit.FORMVER;
            dto.PACKET = visit.PACKET.ToString();
            dto.VISIT_DATE = visit.VISIT_DATE;
            dto.INITIALS = visit.INITIALS;
            dto.Status = ((int)visit.Status).ToString();
            dto.CreatedAt = visit.CreatedAt;
            dto.CreatedBy = visit.CreatedBy;
            dto.ModifiedBy = visit.ModifiedBy;
            dto.DeletedBy = visit.DeletedBy;
            dto.IsDeleted = visit.IsDeleted;
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

        public static M1Dto ToDto(this Milestone milestone)
        {
            return new M1Dto
            {
                Id = milestone.Id,
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
                MILESTONETYPE = milestone.MILESTONETYPE
            };
        }

        public static VisitDto ToDto(this Visit visit)
        {
            var dto = new VisitDto();
            SetBaseVisitProperties(dto, visit);

            if (visit.Forms != null)
                dto.Forms = visit.Forms.ToDto();

            return dto;
        }

        public static VisitDto ToDto(this Visit visit, string formKind)
        {
            var dto = visit.ToDto();

            if (visit.Forms != null)
                dto.Forms = visit.Forms.ToDto(formKind);

            return dto;
        }

        public static PacketDto ToDto(this Packet packet)
        {
            var dto = new PacketDto();

            dto.Id = packet.Id;
            dto.Status = packet.Status.ToString();

            if (packet.Submissions != null)
                dto.PacketSubmissions = packet.Submissions.Select(s => s.ToDto()).ToList();

            return dto;
        }

        public static PacketSubmissionDto ToDto(this PacketSubmission packetSubmission)
        {
            var dto = new PacketSubmissionDto
            {
                Id = packetSubmission.Id,
                PacketId = packetSubmission.PacketId,
                SubmissionDate = packetSubmission.SubmissionDate,
                CreatedBy = packetSubmission.CreatedBy,
                CreatedAt = packetSubmission.CreatedAt,
                ModifiedBy = packetSubmission.ModifiedBy,
                DeletedBy = packetSubmission.DeletedBy,
                IsDeleted = packetSubmission.IsDeleted,
                ErrorCount = packetSubmission.ErrorCount
            };

            if (packetSubmission.Errors != null)
                dto.PacketSubmissionErrors = packetSubmission.Errors.Select(e => e.ToDto(packetSubmission.Id)).ToList();

            return dto;
        }

        public static PacketSubmissionErrorDto ToDto(this PacketSubmissionError error, int packetSubmissionId)
        {
            var dto = new PacketSubmissionErrorDto
            {
                Id = error.Id,
                PacketSubmissionId = packetSubmissionId,
                FormKind = error.FormKind,
                Level = ((int)error.Level).ToString(),
                Message = error.Message,
                AssignedTo = error.AssignedTo,
                StatusChangedBy = error.StatusChangedBy,
                Status = ((int)error.Status).ToString(),
                Location = error.Location?.ToUpper(),
                Value = error.Value,
                CreatedAt = error.CreatedAt,
                CreatedBy = error.CreatedBy,
                ModifiedBy = error.ModifiedBy,
                DeletedBy = error.DeletedBy,
                IsDeleted = error.IsDeleted
            };

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
            if (form.MODE == FormMode.NotCompleted && form.NOT.HasValue)
                reasonCode = ((int)form.NOT).ToString();

            string remoteReasonCode = "";
            if (form.MODE == FormMode.Remote && form.RMREAS.HasValue)
                remoteReasonCode = ((int)form.RMREAS).ToString();

            string remoteModality = "";
            if (form.MODE == FormMode.Remote && form.RMMODE.HasValue)
                remoteModality = ((int)form.RMMODE).ToString();

            // set default formDto and then override with more details if it is a strongly typed object
            FormDto dto = new FormDto()
            {
                Id = form.Id,
                VisitId = form.VisitId,
                Kind = form.Kind,
                Status = ((int)form.Status).ToString(),
                LANG = ((int)form.LANG).ToString(),
                MODE = ((int)form.MODE).ToString(),
                RMREAS = remoteReasonCode,
                RMMODE = remoteModality,
                NOT = reasonCode,
                INITIALS = form.INITIALS,
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
            else if (form.Fields is A5D2FormFields)
            {
                dto = ((A5D2FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is A4aFormFields)
            {
                dto = ((A4aFormFields)form.Fields).ToDto(form.Id);
            }
            else if (form.Fields is B1FormFields)
            {
                dto = ((B1FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is B3FormFields)
            {
                dto = ((B3FormFields)form.Fields).ToDto();
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
            else if (form.Fields is C2FormFields)
            {
                dto = ((C2FormFields)form.Fields).ToDto();
            }
            else if (form.Fields is D1aFormFields)
            {
                dto = ((D1aFormFields)form.Fields).ToDto();
            }
            else if (form.Fields is D1bFormFields)
            {
                dto = ((D1bFormFields)form.Fields).ToDto();
            }

            SetBaseProperties(dto, form);

            return dto;

        }

        public static FormDto ToDto(this Form form, string formKind)
        {
            FormDto dto = GetDto(form); // get baseline form dto

            // if the type of form we want to retun matches the specialized type
            // then return the special dto, otherwise just return the baseline
            if (formKind == "A1a")
            {
                if (form.Fields is A1aFormFields initial)
                    dto = initial.ToDto();
            }
            else if (formKind == "A1")
            {
                if (form.Fields is A1FormFields initial)
                    dto = initial.ToDto();
            }
            else if (formKind == "A2")
            {
                if (form.Fields is A2FormFields initial)
                    dto = initial.ToDto();
            }
            else if (formKind == "A3")
            {
                if (form.Fields is A3FormFields initial)
                    dto = initial.ToDto(form.Id);
            }
            else if (formKind == "A4")
            {
                if (form.Fields is A4GFormFields initial)
                    dto = initial.ToDto(form);
            }
            else if (formKind == "A5D2")
            {
                if (form.Fields is A5D2FormFields initial)
                    dto = initial.ToDto();
            }
            else if (formKind == "A4a")
            {
                if (form.Fields is A4aFormFields initial)
                    dto = initial.ToDto(form.Id);
            }
            else if (formKind == "B1")
            {
                if (form.Fields is B1FormFields initial)
                    dto = initial.ToDto();
            }
            else if (formKind == "B3")
            {
                if (form.Fields is B3FormFields initial)
                    dto = initial.ToDto();
            }
            else if (formKind == "B4")
            {
                if (form.Fields is B4FormFields initial)
                    dto = initial.ToDto();
            }
            else if (formKind == "B5")
            {
                if (form.Fields is B5FormFields initial)
                    dto = initial.ToDto();
            }
            else if (formKind == "B6")
            {
                if (form.Fields is B6FormFields initial)
                    dto = initial.ToDto();
            }
            else if (formKind == "B7")
            {
                if (form.Fields is B7FormFields initial)
                    dto = initial.ToDto();
            }
            else if (formKind == "B8")
            {
                if (form.Fields is B8FormFields initial)
                    dto = initial.ToDto();
            }
            else if (formKind == "B9")
            {
                if (form.Fields is B9FormFields initial)
                    dto = initial.ToDto();
            }
            else if (formKind == "C2")
            {
                if (form.Fields is C2FormFields initial)
                    dto = initial.ToDto();
            }
            else if (formKind == "D1a")
            {
                if (form.Fields is D1aFormFields initial)
                    dto = initial.ToDto();
            }
            else if (formKind == "D1b")
            {
                if (form.Fields is D1bFormFields initial)
                    dto = initial.ToDto();
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
                GUARDEDU = fields.GUARDEDU,
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
                RACEWHITE = fields.RACEWHITE.HasValue ? 1 : 0,
                ETHGERMAN = fields.ETHGERMAN.HasValue ? 1 : 0,
                ETHIRISH = fields.ETHIRISH.HasValue ? 1 : 0,
                ETHENGLISH = fields.ETHENGLISH.HasValue ? 1 : 0,
                ETHITALIAN = fields.ETHITALIAN.HasValue ? 1 : 0,
                ETHPOLISH = fields.ETHPOLISH.HasValue ? 1 : 0,
                ETHSCOTT = fields.ETHSCOTT.HasValue ? 1 : 0,
                ETHWHIOTH = fields.ETHWHIOTH.HasValue ? 1 : 0,
                ETHWHIOTHX = fields.ETHWHIOTHX,
                ETHISPANIC = fields.ETHISPANIC.HasValue ? 1 : 0,
                ETHMEXICAN = fields.ETHMEXICAN.HasValue ? 1 : 0,
                ETHPUERTO = fields.ETHPUERTO.HasValue ? 1 : 0,
                ETHCUBAN = fields.ETHCUBAN.HasValue ? 1 : 0,
                ETHSALVA = fields.ETHSALVA.HasValue ? 1 : 0,
                ETHDOMIN = fields.ETHDOMIN.HasValue ? 1 : 0,
                ETHGUATEM = fields.ETHGUATEM.HasValue ? 1 : 0,
                ETHHISOTH = fields.ETHHISOTH.HasValue ? 1 : 0,
                ETHHISOTHX = fields.ETHHISOTHX,
                RACEBLACK = fields.RACEBLACK.HasValue ? 1 : 0,
                ETHAFAMER = fields.ETHAFAMER.HasValue ? 1 : 0,
                ETHJAMAICA = fields.ETHJAMAICA.HasValue ? 1 : 0,
                ETHHAITIAN = fields.ETHHAITIAN.HasValue ? 1 : 0,
                ETHNIGERIA = fields.ETHNIGERIA.HasValue ? 1 : 0,
                ETHETHIOP = fields.ETHETHIOP.HasValue ? 1 : 0,
                ETHSOMALI = fields.ETHSOMALI.HasValue ? 1 : 0,
                ETHBLKOTH = fields.ETHBLKOTH.HasValue ? 1 : 0,
                ETHBLKOTHX = fields.ETHBLKOTHX,
                RACEASIAN = fields.RACEASIAN.HasValue ? 1 : 0,
                ETHCHINESE = fields.ETHCHINESE.HasValue ? 1 : 0,
                ETHFILIP = fields.ETHFILIP.HasValue ? 1 : 0,
                ETHINDIA = fields.ETHINDIA.HasValue ? 1 : 0,
                ETHVIETNAM = fields.ETHVIETNAM.HasValue ? 1 : 0,
                ETHKOREAN = fields.ETHKOREAN.HasValue ? 1 : 0,
                ETHJAPAN = fields.ETHJAPAN.HasValue ? 1 : 0,
                ETHASNOTH = fields.ETHASNOTH.HasValue ? 1 : 0,
                ETHASNOTHX = fields.ETHASNOTHX,
                RACEAIAN = fields.RACEAIAN.HasValue ? 1 : 0,
                RACEAIANX = fields.RACEAIANX,
                RACEMENA = fields.RACEMENA.HasValue ? 1 : 0,
                ETHLEBANON = fields.ETHLEBANON.HasValue ? 1 : 0,
                ETHIRAN = fields.ETHIRAN.HasValue ? 1 : 0,
                ETHEGYPT = fields.ETHEGYPT.HasValue ? 1 : 0,
                ETHSYRIA = fields.ETHSYRIA.HasValue ? 1 : 0,
                ETHIRAQI = fields.ETHIRAQI.HasValue ? 1 : 0,
                ETHISRAEL = fields.ETHISRAEL.HasValue ? 1 : 0,
                ETHMENAOTH = fields.ETHMENAOTH.HasValue ? 1 : 0,
                ETHMENAOTX = fields.ETHMENAOTX,
                RACENHPI = fields.RACENHPI.HasValue ? 1 : 0,
                ETHHAWAII = fields.ETHHAWAII.HasValue ? 1 : 0,
                ETHSAMOAN = fields.ETHSAMOAN.HasValue ? 1 : 0,
                ETHCHAMOR = fields.ETHCHAMOR.HasValue ? 1 : 0,
                ETHTONGAN = fields.ETHTONGAN.HasValue ? 1 : 0,
                ETHFIJIAN = fields.ETHFIJIAN.HasValue ? 1 : 0,
                ETHMARSHAL = fields.ETHMARSHAL.HasValue ? 1 : 0,
                ETHNHPIOTH = fields.ETHNHPIOTH.HasValue ? 1 : 0,
                ETHNHPIOTX = fields.ETHNHPIOTX,
                RACEUNKN = fields.RACEUNKN.HasValue ? 1 : 0,
                GENMAN = fields.GENMAN.HasValue ? 1 : 0,
                GENWOMAN = fields.GENWOMAN.HasValue ? 1 : 0,
                GENTRMAN = fields.GENTRMAN.HasValue ? 1 : 0,
                GENTRWOMAN = fields.GENTRWOMAN.HasValue ? 1 : 0,
                GENNONBI = fields.GENNONBI.HasValue ? 1 : 0,
                GENTWOSPIR = fields.GENTWOSPIR.HasValue ? 1 : 0,
                GENOTH = fields.GENOTH.HasValue ? 1 : 0,
                GENOTHX = fields.GENOTHX,
                GENDKN = fields.GENDKN.HasValue ? 1 : 0,
                GENNOANS = fields.GENNOANS.HasValue ? 1 : 0,
                BIRTHSEX = fields.BIRTHSEX,
                INTERSEX = fields.INTERSEX,
                SEXORNGAY = fields.SEXORNGAY.HasValue ? 1 : 0,
                SEXORNHET = fields.SEXORNHET.HasValue ? 1 : 0,
                SEXORNBI = fields.SEXORNBI.HasValue ? 1 : 0,
                SEXORNTWOS = fields.SEXORNTWOS.HasValue ? 1 : 0,
                SEXORNOTH = fields.SEXORNOTH.HasValue ? 1 : 0,
                SEXORNOTHX = fields.SEXORNOTHX,
                SEXORNDNK = fields.SEXORNDNK.HasValue ? 1 : 0,
                SEXORNNOAN = fields.SEXORNNOAN.HasValue ? 1 : 0,
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
                MOMYOB = fields.MOMYOB,
                MOMDAGE = fields.MOMDAGE,
                MOMETPR = fields.MOMETPR,
                MOMETSEC = fields.MOMETSEC,
                MOMMEVAL = fields.MOMMEVAL,
                MOMAGEO = fields.MOMAGEO,
                DADYOB = fields.DADYOB,
                DADDAGE = fields.DADDAGE,
                DADETPR = fields.DADETPR,
                DADETSEC = fields.DADETSEC,
                DADMEVAL = fields.DADMEVAL,
                DADAGEO = fields.DADAGEO,
                SIBS = fields.SIBS,
                KIDS = fields.KIDS,
                NWINFPAR = fields.NWINFPAR,
                NWINFSIB = fields.NWINFSIB,
                NWINFKID = fields.NWINFKID
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
                ETPR = fields.ETPR,
                ETSEC = fields.ETSEC,
                MEVAL = fields.MEVAL,
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

        public static A5D2Dto ToDto(this A5D2FormFields fields)
        {
            return new A5D2Dto
            {
                TOBAC100 = fields.TOBAC100,
                SMOKYRS = fields.SMOKYRS,
                PACKSPER = fields.PACKSPER,
                TOBAC30 = fields.TOBAC30,
                QUITSMOK = fields.QUITSMOK,
                ALCFREQYR = fields.ALCFREQYR,
                ALCDRINKS = fields.ALCDRINKS,
                ALCBINGE = fields.ALCBINGE,
                SUBSTYEAR = fields.SUBSTYEAR,
                SUBSTPAST = fields.SUBSTPAST,
                CANNABIS = fields.CANNABIS,
                HRTATTACK = fields.HRTATTACK,
                HRTATTMULT = fields.HRTATTMULT,
                HRTATTAGE = fields.HRTATTAGE,
                CARDARREST = fields.CARDARREST,
                CARDARRAGE = fields.CARDARRAGE,
                CVAFIB = fields.CVAFIB,
                CVANGIO = fields.CVANGIO,
                CVBYPASS = fields.CVBYPASS,
                BYPASSAGE = fields.BYPASSAGE,
                CVPACDEF = fields.CVPACDEF,
                PACDEFAGE = fields.PACDEFAGE,
                CVCHF = fields.CVCHF,
                CVHVALVE = fields.CVHVALVE,
                VALVEAGE = fields.VALVEAGE,
                CVOTHR = fields.CVOTHR,
                CVOTHRX = fields.CVOTHRX,
                CBSTROKE = fields.CBSTROKE,
                STROKMUL = fields.STROKMUL,
                STROKAGE = fields.STROKAGE,
                STROKSTAT = fields.STROKSTAT,
                ANGIOCP = fields.ANGIOCP,
                CAROTIDAGE = fields.CAROTIDAGE,
                CBTIA = fields.CBTIA,
                TIAAGE = fields.TIAAGE,
                PD = fields.PD,
                PDAGE = fields.PDAGE,
                PDOTHR = fields.PDOTHR,
                PDOTHRAGE = fields.PDOTHRAGE,
                SEIZURES = fields.SEIZURES,
                SEIZNUM = fields.SEIZNUM,
                SEIZAGE = fields.SEIZAGE,
                HEADACHE = fields.HEADACHE,
                MS = fields.MS,
                HYDROCEPH = fields.HYDROCEPH,
                HEADIMP = fields.HEADIMP,
                IMPAMFOOT = fields.IMPAMFOOT,
                IMPSOCCER = fields.IMPSOCCER,
                IMPHOCKEY = fields.IMPHOCKEY,
                IMPBOXING = fields.IMPBOXING,
                IMPSPORT = fields.IMPSPORT,
                IMPIPV = fields.IMPIPV,
                IMPMILIT = fields.IMPMILIT,
                IMPASSAULT = fields.IMPASSAULT,
                IMPOTHER = fields.IMPOTHER,
                IMPOTHERX = fields.IMPOTHERX,
                IMPYEARS = fields.IMPYEARS,
                HEADINJURY = fields.HEADINJURY,
                HEADINJUNC = fields.HEADINJUNC,
                HEADINJCON = fields.HEADINJCON,
                HEADINJNUM = fields.HEADINJNUM,
                FIRSTTBI = fields.FIRSTTBI,
                LASTTBI = fields.LASTTBI,
                DIABETES = fields.DIABETES,
                DIABTYPE = fields.DIABTYPE,
                DIABINS = fields.DIABINS,
                DIABMEDS = fields.DIABMEDS,
                DIABGLP1 = fields.DIABGLP1,
                DIABRECACT = fields.DIABRECACT,
                DIABDIET = fields.DIABDIET,
                DIABUNK = fields.DIABUNK,
                DIABAGE = fields.DIABAGE,
                HYPERTEN = fields.HYPERTEN,
                HYPERTAGE = fields.HYPERTAGE,
                HYPERCHO = fields.HYPERCHO,
                HYPERCHAGE = fields.HYPERCHAGE,
                B12DEF = fields.B12DEF,
                THYROID = fields.THYROID,
                ARTHRIT = fields.ARTHRIT,
                ARTHRRHEUM = fields.ARTHRRHEUM,
                ARTHROSTEO = fields.ARTHROSTEO,
                ARTHROTHR = fields.ARTHROTHR,
                ARTHTYPX = fields.ARTHTYPX,
                ARTHTYPUNK = fields.ARTHTYPUNK,
                ARTHUPEX = fields.ARTHUPEX,
                ARTHLOEX = fields.ARTHLOEX,
                ARTHSPIN = fields.ARTHSPIN,
                ARTHUNK = fields.ARTHUNK,
                INCONTU = fields.INCONTU,
                INCONTF = fields.INCONTF,
                APNEA = fields.APNEA,
                CPAP = fields.CPAP,
                APNEAORAL = fields.APNEAORAL,
                RBD = fields.RBD,
                INSOMN = fields.INSOMN,
                OTHSLEEP = fields.OTHSLEEP,
                OTHSLEEX = fields.OTHSLEEX,
                CANCERACTV = fields.CANCERACTV,
                CANCERPRIM = fields.CANCERPRIM,
                CANCERMETA = fields.CANCERMETA,
                CANCMETBR = fields.CANCMETBR,
                CANCMETOTH = fields.CANCMETOTH,
                CANCERUNK = fields.CANCERUNK,
                CANCBLOOD = fields.CANCBLOOD,
                CANCBREAST = fields.CANCBREAST,
                CANCCOLON = fields.CANCCOLON,
                CANCLUNG = fields.CANCLUNG,
                CANCPROST = fields.CANCPROST,
                CANCOTHER = fields.CANCOTHER,
                CANCOTHERX = fields.CANCOTHERX,
                CANCRAD = fields.CANCRAD,
                CANCRESECT = fields.CANCRESECT,
                CANCIMMUNO = fields.CANCIMMUNO,
                CANCBONE = fields.CANCBONE,
                CANCCHEMO = fields.CANCCHEMO,
                CANCHORM = fields.CANCHORM,
                CANCTROTH = fields.CANCTROTH,
                CANCTROTHX = fields.CANCTROTHX,
                CANCERAGE = fields.CANCERAGE,
                COVID19 = fields.COVID19,
                COVIDHOSP = fields.COVIDHOSP,
                PULMONARY = fields.PULMONARY,
                KIDNEY = fields.KIDNEY,
                KIDNEYAGE = fields.KIDNEYAGE,
                LIVER = fields.LIVER,
                LIVERAGE = fields.LIVERAGE,
                PVD = fields.PVD,
                PVDAGE = fields.PVDAGE,
                HIVDIAG = fields.HIVDIAG,
                HIVAGE = fields.HIVAGE,
                OTHERCOND = fields.OTHERCOND,
                OTHCONDX = fields.OTHCONDX,
                MAJORDEP = fields.MAJORDEP,
                OTHERDEP = fields.OTHERDEP,
                DEPRTREAT = ConvertIntToBool(fields.DEPRTREAT),
                BIPOLAR = fields.BIPOLAR,
                SCHIZ = fields.SCHIZ,
                ANXIETY = fields.ANXIETY,
                GENERALANX = fields.GENERALANX,
                PANICDIS = fields.PANICDIS,
                OCD = fields.OCD,
                OTHANXDIS = fields.OTHANXDIS,
                OTHANXDISX = fields.OTHANXDISX,
                PTSD = fields.PTSD,
                NPSYDEV = fields.NPSYDEV,
                PSYCDIS = fields.PSYCDIS,
                PSYCDISX = fields.PSYCDISX,
                MENARCHE = fields.MENARCHE,
                NOMENSAGE = fields.NOMENSAGE,
                NOMENSNAT = fields.NOMENSNAT,
                NOMENSHYST = fields.NOMENSHYST,
                NOMENSSURG = fields.NOMENSSURG,
                NOMENSCHEM = fields.NOMENSCHEM,
                NOMENSRAD = fields.NOMENSRAD,
                NOMENSHORM = fields.NOMENSHORM,
                NOMENSESTR = fields.NOMENSESTR,
                NOMENSUNK = fields.NOMENSUNK,
                NOMENSOTH = fields.NOMENSOTH,
                NOMENSOTHX = fields.NOMENSOTHX,
                HRT = fields.HRT,
                HRTYEARS = fields.HRTYEARS,
                HRTSTRTAGE = fields.HRTSTRTAGE,
                HRTENDAGE = fields.HRTENDAGE,
                BCPILLS = fields.BCPILLS,
                BCPILLSYR = fields.BCPILLSYR,
                BCSTARTAGE = fields.BCSTARTAGE,
                BCENDAGE = fields.BCENDAGE
            };
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

        public static B1Dto ToDto(this B1FormFields fields)
        {
            return new B1Dto
            {
                HEIGHT = fields.HEIGHT,
                WEIGHT = fields.WEIGHT,
                WAIST1 = fields.WAIST1,
                WAIST2 = fields.WAIST2,
                HIP1 = fields.HIP1,
                HIP2 = fields.HIP2,
                BPSYSL1 = fields.BPSYSL1,
                BPDIASL1 = fields.BPDIASL1,
                BPSYSL2 = fields.BPSYSL2,
                BPDIASL2 = fields.BPDIASL2,
                BPSYSR1 = fields.BPSYSR1,
                BPDIASR1 = fields.BPDIASR1,
                BPSYSR2 = fields.BPSYSR2,
                BPDIASR2 = fields.BPDIASR2,
                HRATE = fields.HRATE,
            };
        }

        public static B3Dto ToDto(this B3FormFields fields)
        {
            return new B3Dto
            {
                PDNORMAL = fields.PDNORMAL,
                SPEECH = fields.SPEECH,
                SPEECHX = fields.SPEECHX,
                FACEXP = fields.FACEXP,
                FACEXPX = fields.FACEXPX,
                TRESTFAC = fields.TRESTFAC,
                TRESTFAX = fields.TRESTFAX,
                TRESTRHD = fields.TRESTRHD,
                TRESTRHX = fields.TRESTRHX,
                TRESTLHD = fields.TRESTLHD,
                TRESTLHX = fields.TRESTLHX,
                TRESTRFT = fields.TRESTRFT,
                TRESTRFX = fields.TRESTRFX,
                TRESTLFT = fields.TRESTLFT,
                TRESTLFX = fields.TRESTLFX,
                TRACTRHD = fields.TRACTRHD,
                TRACTRHX = fields.TRACTRHX,
                TRACTLHD = fields.TRACTLHD,
                TRACTLHX = fields.TRACTLHX,
                RIGDNECK = fields.RIGDNECK,
                RIGDNEX = fields.RIGDNEX,
                RIGDUPRT = fields.RIGDUPRT,
                RIGDUPRX = fields.RIGDUPRX,
                RIGDUPLF = fields.RIGDUPLF,
                RIGDUPLX = fields.RIGDUPLX,
                RIGDLORT = fields.RIGDLORT,
                RIGDLORX = fields.RIGDLORX,
                RIGDLOLF = fields.RIGDLOLF,
                RIGDLOLX = fields.RIGDLOLX,
                TAPSRT = fields.TAPSRT,
                TAPSRTX = fields.TAPSRTX,
                TAPSLF = fields.TAPSLF,
                TAPSLFX = fields.TAPSLFX,
                HANDMOVR = fields.HANDMOVR,
                HANDMVRX = fields.HANDMVRX,
                HANDMOVL = fields.HANDMOVL,
                HANDMVLX = fields.HANDMVLX,
                HANDALTR = fields.HANDALTR,
                HANDATRX = fields.HANDATRX,
                HANDALTL = fields.HANDALTL,
                HANDATLX = fields.HANDATLX,
                LEGRT = fields.LEGRT,
                LEGRTX = fields.LEGRTX,
                LEGLF = fields.LEGLF,
                LEGLFX = fields.LEGLFX,
                ARISING = fields.ARISING,
                ARISINGX = fields.ARISINGX,
                POSTURE = fields.POSTURE,
                POSTUREX = fields.POSTUREX,
                GAIT = fields.GAIT,
                GAITX = fields.GAITX,
                POSSTAB = fields.POSSTAB,
                POSSTABX = fields.POSSTABX,
                BRADYKIN = fields.BRADYKIN,
                BRADYKIX = fields.BRADYKIX,
                TOTALUPDRS = fields.TOTALUPDRS,
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
                NOGDS = fields.NOGDS.HasValue ? 1 : 0,
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
                NEUREXAM = fields.NEUREXAM,
                NORMNREXAM = fields.NORMNREXAM.HasValue ? Convert.ToBoolean(fields.NORMNREXAM) : (bool?)null,
                PARKSIGN = fields.PARKSIGN,
                SLOWINGFM = fields.SLOWINGFM,
                TREMREST = fields.TREMREST,
                TREMPOST = fields.TREMPOST,
                TREMKINE = fields.TREMKINE,
                RIGIDARM = fields.RIGIDARM,
                RIGIDLEG = fields.RIGIDLEG,
                DYSTARM = fields.DYSTARM,
                DYSTLEG = fields.DYSTLEG,
                CHOREA = fields.CHOREA,
                AMPMOTOR = fields.AMPMOTOR,
                AXIALRIG = fields.AXIALRIG,
                POSTINST = fields.POSTINST,
                MASKING = fields.MASKING,
                STOOPED = fields.STOOPED,
                OTHERSIGN = fields.OTHERSIGN,
                LIMBAPRAX = fields.LIMBAPRAX,
                UMNDIST = fields.UMNDIST,
                LMNDIST = fields.LMNDIST,
                VFIELDCUT = fields.VFIELDCUT,
                LIMBATAX = fields.LIMBATAX,
                MYOCLON = fields.MYOCLON,
                UNISOMATO = fields.UNISOMATO,
                APHASIA = fields.APHASIA,
                ALIENLIMB = fields.ALIENLIMB,
                HSPATNEG = fields.HSPATNEG,
                PSPOAGNO = fields.PSPOAGNO,
                SMTAGNO = fields.SMTAGNO,
                OPTICATAX = fields.OPTICATAX,
                APRAXGAZE = fields.APRAXGAZE,
                VHGAZEPAL = fields.VHGAZEPAL,
                DYSARTH = fields.DYSARTH,
                APRAXSP = fields.APRAXSP,
                GAITABN = fields.GAITABN,
                GAITFIND = fields.GAITFIND,
                GAITOTHRX = fields.GAITOTHRX
            };
        }

        public static B9Dto ToDto(this B9FormFields fields)
        {
            return new B9Dto
            {
                DECCOG = fields.DECCOG,
                DECMOT = fields.DECMOT,
                PSYCHSYM = fields.PSYCHSYM,
                DECCOGIN = fields.DECCOGIN,
                DECMOTIN = fields.DECMOTIN,
                PSYCHSYMIN = fields.PSYCHSYMIN,
                DECCLIN = ConvertIntToBool(fields.DECCLIN),
                DECCLCOG = ConvertIntToBool(fields.DECCLCOG),
                COGMEM = fields.COGMEM,
                COGORI = fields.COGORI,
                COGJUDG = fields.COGJUDG,
                COGLANG = fields.COGLANG,
                COGVIS = fields.COGVIS,
                COGATTN = fields.COGATTN,
                COGFLUC = fields.COGFLUC,
                COGOTHR = fields.COGOTHR,
                COGOTHRX = fields.COGOTHRX,
                COGAGE = fields.COGAGE,
                COGMODE = fields.COGMODE,
                COGMODEX = fields.COGMODEX,
                DECCLBE = fields.DECCLBE,
                BEAPATHY = fields.BEAPATHY,
                BEDEP = fields.BEDEP,
                BEANX = fields.BEANX,
                BEEUPH = fields.BEEUPH,
                BEIRRIT = fields.BEIRRIT,
                BEAGIT = fields.BEAGIT,
                BEHAGE = fields.BEHAGE,
                BEVHALL = fields.BEVHALL,
                BEVPATT = fields.BEVPATT,
                BEVWELL = fields.BEVWELL,
                BEAHALL = fields.BEAHALL,
                BEAHSIMP = fields.BEAHSIMP,
                BEAHCOMP = fields.BEAHCOMP,
                BEDEL = fields.BEDEL,
                BEAGGRS = fields.BEAGGRS,
                PSYCHAGE = fields.PSYCHAGE,
                BEDISIN = fields.BEDISIN,
                BEPERCH = fields.BEPERCH,
                BEEMPATH = fields.BEEMPATH,
                BEOBCOM = fields.BEOBCOM,
                BEANGER = fields.BEANGER,
                BESUBAB = fields.BESUBAB,
                ALCUSE = fields.ALCUSE,
                SEDUSE = fields.SEDUSE,
                OPIATEUSE = fields.OPIATEUSE,
                COCAINEUSE = fields.COCAINEUSE,
                CANNABUSE = fields.CANNABUSE,
                OTHSUBUSE = fields.OTHSUBUSE,
                OTHSUBUSEX = fields.OTHSUBUSEX,
                PERCHAGE = fields.PERCHAGE,
                BEREM = fields.BEREM,
                BEREMAGO = fields.BEREMAGO,
                BEREMCONF = fields.BEREMCONF,
                BEOTHR = fields.BEOTHR,
                BEOTHRX = fields.BEOTHRX,
                BEMODE = fields.BEMODE,
                BEMODEX = fields.BEMODEX,
                DECCLMOT = ConvertIntToBool(fields.DECCLMOT),
                MOGAIT = fields.MOGAIT,
                MOFALLS = fields.MOFALLS,
                MOSLOW = fields.MOSLOW,
                MOTREM = fields.MOTREM,
                MOLIMB = fields.MOLIMB,
                MOFACE = fields.MOFACE,
                MOSPEECH = fields.MOSPEECH,
                MOTORAGE = fields.MOTORAGE,
                MOMODE = fields.MOMODE,
                MOMODEX = fields.MOMODEX,
                MOMOPARK = fields.MOMOPARK,
                MOMOALS = fields.MOMOALS,
                COURSE = fields.COURSE,
                FRSTCHG = fields.FRSTCHG,
            };
        }

        private static bool? ConvertIntToBool(int? property)
        {
            if (property == 1) return true;
            if (property == 0) return false;
            return null;
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
                MOCBTOTS = fields.MOCBTOTS,
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
                VERBALTEST = fields.VERBALTEST,
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
                REYBREC = fields.REYBREC,
                REYBINT = fields.REYBINT,
                REY6REC = fields.REY6REC,
                REY6INT = fields.REY6INT,
                REYDREC = fields.REYDREC,
                REYDINT = fields.REYDINT,
                REYDTI = fields.REYDTI,
                REYMETHOD = fields.REYMETHOD,
                REYTCOR = fields.REYTCOR,
                REYFPOS = fields.REYFPOS,
                VNTTOTW = fields.VNTTOTW,
                VNTPCNC = fields.VNTPCNC,
                CERAD1REC = fields.CERAD1REC,
                CERAD1READ = fields.CERAD1READ,
                CERAD1INT = fields.CERAD1INT,
                CERAD2REC = fields.CERAD2REC,
                CERAD2READ = fields.CERAD2READ,
                CERAD2INT = fields.CERAD2INT,
                CERAD3REC = fields.CERAD3REC,
                CERAD3READ = fields.CERAD3READ,
                CERAD3INT = fields.CERAD3INT,
                CERADDTI = fields.CERADDTI,
                CERADJ6REC = fields.CERADJ6REC,
                CERADJ6INT = fields.CERADJ6INT,
                CERADJ7YES = fields.CERADJ7YES,
                CERADJ7NO = fields.CERADJ7NO,
                OTRAILA = fields.OTRAILA,
                OTRLARR = fields.OTRLARR,
                OTRLALI = fields.OTRLALI,
                OTRAILB = fields.OTRAILB,
                OTRLBRR = fields.OTRLBRR,
                OTRLBLI = fields.OTRLBLI,
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

        public static D1aDto ToDto(this D1aFormFields fields)
        {

            return new D1aDto
            {
                DXMETHOD = fields.DXMETHOD,
                NORMCOG = fields.NORMCOG,
                SCD = fields.SCD,
                SCDDXCONF = fields.SCDDXCONF,
                DEMENTED = fields.DEMENTED,
                MCICRITCLN = fields.MCICRITCLN,
                MCICRITIMP = fields.MCICRITIMP,
                MCICRITFUN = fields.MCICRITFUN,
                MCI = fields.MCI,
                IMPNOMCIFU = fields.IMPNOMCIFU,
                IMPNOMCICG = fields.IMPNOMCICG,
                IMPNOMCLCD = fields.IMPNOMCLCD,
                IMPNOMCIO = fields.IMPNOMCIO,
                IMPNOMCIOX = fields.IMPNOMCIOX,
                IMPNOMCI = fields.IMPNOMCI.HasValue ? Convert.ToBoolean(fields.IMPNOMCI) : (bool?)null,
                CDOMMEM = fields.CDOMMEM,
                CDOMLANG = fields.CDOMLANG,
                CDOMATTN = fields.CDOMATTN,
                CDOMEXEC = fields.CDOMEXEC,
                CDOMVISU = fields.CDOMVISU,
                CDOMBEH = fields.CDOMBEH,
                CDOMAPRAX = fields.CDOMAPRAX,
                MBI = fields.MBI,
                BDOMMOT = fields.BDOMMOT,
                BDOMAFREG = fields.BDOMAFREG,
                BDOMIMP = fields.BDOMIMP,
                BDOMSOCIAL = fields.BDOMSOCIAL,
                BDOMTHTS = fields.BDOMTHTS,
                PREDOMSYN = fields.PREDOMSYN,
                AMNDEM = fields.AMNDEM,
                DYEXECSYN = fields.DYEXECSYN,
                PCA = fields.PCA,
                PPASYN = fields.PPASYN,
                PPASYNT = fields.PPASYNT,
                FTDSYN = fields.FTDSYN,
                LBDSYN = fields.LBDSYN,
                LBDSYNT = fields.LBDSYNT,
                NAMNDEM = fields.NAMNDEM,
                PSPSYN = fields.PSPSYN,
                PSPSYNT = fields.PSPSYNT,
                CTESYN = fields.CTESYN,
                CBSSYN = fields.CBSSYN,
                MSASYN = fields.MSASYN,
                MSASYNT = fields.MSASYNT,
                OTHSYN = fields.OTHSYN,
                OTHSYNX = fields.OTHSYNX,
                SYNINFCLIN = fields.SYNINFCLIN,
                SYNINFCTST = fields.SYNINFCTST,
                SYNINFBIOM = fields.SYNINFBIOM,
                MAJDEPDX = fields.MAJDEPDX,
                MAJDEPDIF = fields.MAJDEPDIF,
                OTHDEPDX = fields.OTHDEPDX,
                OTHDEPDIF = fields.OTHDEPDIF,
                BIPOLDX = fields.BIPOLDX,
                BIPOLDIF = fields.BIPOLDIF,
                SCHIZOP = fields.SCHIZOP,
                SCHIZOIF = fields.SCHIZOIF,
                ANXIET = fields.ANXIET,
                ANXIETIF = fields.ANXIETIF,
                GENANX = fields.GENANX,
                PANICDISDX = fields.PANICDISDX,
                OCDDX = fields.OCDDX,
                OTHANXD = fields.OTHANXD,
                OTHANXDX = fields.OTHANXDX,
                PTSDDX = fields.PTSDDX,
                PTSDDXIF = fields.PTSDDXIF,
                NDEVDIS = fields.NDEVDIS,
                NDEVDISIF = fields.NDEVDISIF,
                DELIR = fields.DELIR,
                DELIRIF = fields.DELIRIF,
                OTHPSY = fields.OTHPSY,
                OTHPSYIF = fields.OTHPSYIF,
                OTHPSYX = fields.OTHPSYX,
                TBIDX = fields.TBIDX,
                TBIDXIF = fields.TBIDXIF,
                EPILEP = fields.EPILEP,
                EPILEPIF = fields.EPILEPIF,
                HYCEPH = fields.HYCEPH,
                HYCEPHIF = fields.HYCEPHIF,
                NEOP = fields.NEOP,
                NEOPIF = fields.NEOPIF,
                NEOPSTAT = fields.NEOPSTAT,
                HIV = fields.HIV,
                HIVIF = fields.HIVIF,
                POSTC19 = fields.POSTC19,
                POSTC19IF = fields.POSTC19IF,
                APNEADX = fields.APNEADX,
                APNEADXIF = fields.APNEADXIF,
                OTHCOGILL = fields.OTHCOGILL,
                OTHCILLIF = fields.OTHCILLIF,
                OTHCOGILLX = fields.OTHCOGILLX,
                ALCDEM = fields.ALCDEM,
                ALCDEMIF = fields.ALCDEMIF,
                IMPSUB = fields.IMPSUB,
                IMPSUBIF = fields.IMPSUBIF,
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

        public static D1bDto ToDto(this D1bFormFields fields)
        {

            return new D1bDto
            {
                BIOMARKDX = fields.BIOMARKDX,
                FLUIDBIOM = fields.FLUIDBIOM,
                BLOODAD = fields.BLOODAD,
                BLOODFTLD = fields.BLOODFTLD,
                BLOODLBD = fields.BLOODLBD,
                BLOODOTH = fields.BLOODOTH,
                BLOODOTHX = fields.BLOODOTHX,
                CSFAD = fields.CSFAD,
                CSFFTLD = fields.CSFFTLD,
                CSFLBD = fields.CSFLBD,
                CSFOTH = fields.CSFOTH,
                CSFOTHX = fields.CSFOTHX,
                IMAGINGDX = fields.IMAGINGDX,
                PETDX = fields.PETDX,
                AMYLPET = fields.AMYLPET,
                TAUPET = fields.TAUPET,
                FDGPETDX = fields.FDGPETDX,
                FDGAD = fields.FDGAD,
                FDGFTLD = fields.FDGFTLD,
                FDGLBD = fields.FDGLBD,
                FDGOTH = fields.FDGOTH,
                FDGOTHX = fields.FDGOTHX,
                DATSCANDX = fields.DATSCANDX,
                TRACOTHDX = fields.TRACOTHDX,
                TRACOTHDXX = fields.TRACOTHDXX,
                TRACERAD = fields.TRACERAD,
                TRACERFTLD = fields.TRACERFTLD,
                TRACERLBD = fields.TRACERLBD,
                TRACEROTH = fields.TRACEROTH,
                TRACEROTHX = fields.TRACEROTHX,
                STRUCTDX = fields.STRUCTDX,
                STRUCTAD = fields.STRUCTAD,
                STRUCTFTLD = fields.STRUCTFTLD,
                STRUCTCVD = fields.STRUCTCVD,
                IMAGLINF = fields.IMAGLINF,
                IMAGLAC = fields.IMAGLAC,
                IMAGMACH = fields.IMAGMACH,
                IMAGMICH = fields.IMAGMICH,
                IMAGWMH = fields.IMAGWMH,
                IMAGWMHSEV = fields.IMAGWMHSEV,
                OTHBIOM1 = fields.OTHBIOM1,
                OTHBIOMX1 = fields.OTHBIOMX1,
                BIOMAD1 = fields.BIOMAD1,
                BIOMFTLD1 = fields.BIOMFTLD1,
                BIOMLBD1 = fields.BIOMLBD1,
                BIOMOTH1 = fields.BIOMOTH1,
                BIOMOTHX1 = fields.BIOMOTHX1,
                OTHBIOM2 = fields.OTHBIOM2,
                OTHBIOMX2 = fields.OTHBIOMX2,
                BIOMAD2 = fields.BIOMAD2,
                BIOMFTLD2 = fields.BIOMFTLD2,
                BIOMLBD2 = fields.BIOMLBD2,
                BIOMOTH2 = fields.BIOMOTH2,
                BIOMOTHX2 = fields.BIOMOTHX2,
                OTHBIOM3 = fields.OTHBIOM3,
                OTHBIOMX3 = fields.OTHBIOMX3,
                BIOMAD3 = fields.BIOMAD3,
                BIOMFTLD3 = fields.BIOMFTLD3,
                BIOMLBD3 = fields.BIOMLBD3,
                BIOMOTH3 = fields.BIOMOTH3,
                BIOMOTHX3 = fields.BIOMOTHX3,
                AUTDOMMUT = fields.AUTDOMMUT,
                ALZDIS = fields.ALZDIS,
                ALZDISIF = fields.ALZDISIF,
                LBDIS = fields.LBDIS,
                LBDIF = fields.LBDIF,
                FTLD = fields.FTLD,
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
                MSA = fields.MSA,
                MSAIF = fields.MSAIF,
                CTE = fields.CTE,
                CTEIF = fields.CTEIF,
                CTECERT = fields.CTECERT,
                DOWNS = fields.DOWNS,
                DOWNSIF = fields.DOWNSIF,
                HUNT = fields.HUNT,
                HUNTIF = fields.HUNTIF,
                PRION = fields.PRION,
                PRIONIF = fields.PRIONIF,
                CAA = fields.CAA,
                CAAIF = fields.CAAIF,
                LATE = fields.LATE,
                LATEIF = fields.LATEIF,
                OTHCOG = fields.OTHCOG,
                OTHCOGIF = fields.OTHCOGIF,
                OTHCOGX = fields.OTHCOGX
            };
        }

        public static DrugCodeDto ToDto(this DrugCode drugCode)
        {
            return new DrugCodeDto
            {
                RxNormId = Int32.Parse(drugCode.RxNormId),
                DrugName = drugCode.DrugName,
                BrandName = drugCode.BrandName,
                IsOverTheCounter = drugCode.IsOverTheCounter,
                IsPopular = drugCode.IsPopular
            };
        }
    }
}

