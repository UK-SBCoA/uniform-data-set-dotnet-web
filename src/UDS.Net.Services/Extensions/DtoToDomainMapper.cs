using System;
using System.Collections.Generic;
using System.Linq;
using UDS.Net.Dto;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.Extensions
{
    public static class DtoToDomainMapper
    {
        public static Participation ToDomain(this ParticipationDto dto, string username)
        {
            var participation = new Participation()
            {
                Id = dto.Id,
                LegacyId = dto.LegacyId,
                CreatedAt = dto.CreatedAt,
                CreatedBy = dto.CreatedBy,
                ModifiedBy = dto.ModifiedBy,
                DeletedBy = dto.DeletedBy,
                IsDeleted = dto.IsDeleted,
                VisitCount = dto.VisitCount,
                LastVisitNumber = dto.LastVisitNumber
            };

            if (dto.Visits != null)
            {
                participation.Visits = dto.Visits.Select(v => v.ToDomain(username)).ToList();
            }

            return participation;
        }

        public static Visit ToDomain(this VisitDto dto, string username)
        {
            IList<Form> existingForms = new List<Form>();

            if (dto.Forms != null)
                existingForms = dto.Forms.ToDomain(dto.Id, username);

            PacketKind packetKind = PacketKind.I;

            if (!string.IsNullOrWhiteSpace(dto.PACKET))
            {
                if (Enum.TryParse(dto.PACKET, true, out PacketKind kind))
                    packetKind = kind;
            }

            PacketStatus packetStatus = PacketStatus.Unsubmitted;
            if (!string.IsNullOrWhiteSpace(dto.Status))
            {
                if (!Enum.TryParse(dto.Status, true, out PacketStatus status))
                    packetStatus = status;
            }

            IList<PacketSubmission> packetSubmissions = new List<PacketSubmission>();

            if (dto.PacketSubmissions != null)
                packetSubmissions = dto.PacketSubmissions.ToDomain("", dto.Id, username); // we do not need the adrcid until packet submission/export

            return new Visit(dto.Id, dto.VISITNUM, dto.ParticipationId, dto.FORMVER, packetKind, dto.VISIT_DATE, dto.INITIALS, packetStatus, dto.CreatedAt, dto.CreatedBy, dto.ModifiedBy, dto.DeletedBy, dto.IsDeleted, existingForms, packetSubmissions);
        }

        public static Milestone ToDomain(this M1Dto dto)
        {
            return new Milestone()
            {
                Id = dto.Id,
                FormId = dto.FormId,
                ParticipationId = dto.ParticipationId,
                Status = dto.Status,
                CHANGEMO = dto.CHANGEMO,
                CHANGEDY = dto.CHANGEDY,
                CHANGEYR = dto.CHANGEYR,
                PROTOCOL = dto.PROTOCOL,
                ACONSENT = dto.ACONSENT,
                RECOGIM = dto.RECOGIM,
                REPHYILL = dto.REPHYILL,
                REREFUSE = dto.REREFUSE,
                RENAVAIL = dto.RENAVAIL,
                RENURSE = dto.RENURSE,
                NURSEMO = dto.NURSEMO,
                NURSEDY = dto.NURSEDY,
                NURSEYR = dto.NURSEYR,
                REJOIN = dto.REJOIN,
                FTLDDISC = dto.FTLDDISC,
                FTLDREAS = dto.FTLDREAS,
                FTLDREAX = dto.FTLDREAX,
                DECEASED = dto.DECEASED,
                DISCONT = dto.DISCONT,
                DEATHMO = dto.DEATHMO,
                DEATHDY = dto.DEATHDY,
                DEATHYR = dto.DEATHYR,
                AUTOPSY = dto.AUTOPSY,
                DISCMO = dto.DISCMO,
                DISCDAY = dto.DISCDAY,
                DISCYR = dto.DISCYR,
                DROPREAS = dto.DROPREAS,
                CreatedAt = dto.CreatedAt,
                CreatedBy = dto.CreatedBy,
                ModifiedBy = dto.ModifiedBy,
                DeletedBy = dto.DeletedBy,
                IsDeleted = dto.IsDeleted,
                MILESTONETYPE = dto.MILESTONETYPE
            };
        }

        public static IEnumerable<Milestone> ToDomain(this IEnumerable<M1Dto> m1Dtos)
        {
            return m1Dtos.Select(m => m.ToDomain()).ToList();
        }

        public static IList<Form> ToDomain(this List<FormDto> dto, int visitId, string username)
        {
            if (dto != null)
                return dto.Select(f => f.ToDomain(visitId, f.CreatedBy)).ToList();

            return new List<Form>();
        }

        public static Form ToDomain(this FormDto dto, int visitId, string username)
        {
            IFormFields formFields = null;
            string title = "";

            if (dto is A1Dto)
            {
                formFields = new A1FormFields(dto);
            }
            else if (dto is A1aDto)
            {
                formFields = new A1aFormFields(dto);
            }
            else if (dto is A2Dto)
            {
                formFields = new A2FormFields(dto);
            }
            else if (dto is A3Dto)
            {
                formFields = new A3FormFields(dto);
            }
            else if (dto is A4Dto)
            {
                formFields = new A4GFormFields(dto);
            }
            else if (dto is A4aDto)
            {
                formFields = new A4aFormFields(dto);
            }
            else if (dto is A5D2Dto)
            {
                formFields = new A5D2FormFields(dto);
            }
            else if (dto is B1Dto)
            {
                formFields = new B1FormFields(dto);
            }
            else if (dto is B3Dto)
            {
                formFields = new B3FormFields(dto);
            }
            else if (dto is B4Dto)
            {
                formFields = new B4FormFields(dto);
            }
            else if (dto is B5Dto)
            {
                formFields = new B5FormFields(dto);
            }
            else if (dto is B6Dto)
            {
                formFields = new B6FormFields(dto);
            }
            else if (dto is B7Dto)
            {
                formFields = new B7FormFields(dto);
            }
            else if (dto is B8Dto)
            {
                formFields = new B8FormFields(dto);
            }
            else if (dto is B9Dto)
            {
                formFields = new B9FormFields(dto);
            }
            else if (dto is C2Dto)
            {
                formFields = new C2FormFields(dto);
            }
            else if (dto is D1aDto)
            {
                formFields = new D1aFormFields(dto);
            }
            else if (dto is D1bDto)
            {
                formFields = new D1bFormFields(dto);
            }
            else
            {
                if (dto.Kind == "A1")
                    title = new A1FormFields().GetDescription();
                else if (dto.Kind == "A1a")
                    title = new A1aFormFields().GetDescription();
                else if (dto.Kind == "A2")
                    title = new A2FormFields().GetDescription();
                else if (dto.Kind == "A3")
                    title = new A3FormFields().GetDescription();
                else if (dto.Kind == "A4")
                    title = new A4GFormFields().GetDescription();
                else if (dto.Kind == "A4a")
                    title = new A4aFormFields().GetDescription();
                else if (dto.Kind == "A5D2")
                    title = new A5D2FormFields().GetDescription();
                else if (dto.Kind == "B1")
                    title = new B1FormFields().GetDescription();
                else if (dto.Kind == "B3")
                    title = new B3FormFields().GetDescription();
                else if (dto.Kind == "B4")
                    title = new B4FormFields().GetDescription();
                else if (dto.Kind == "B5")
                    title = new B5FormFields().GetDescription();
                else if (dto.Kind == "B6")
                    title = new B6FormFields().GetDescription();
                else if (dto.Kind == "B7")
                    title = new B7FormFields().GetDescription();
                else if (dto.Kind == "B8")
                    title = new B8FormFields().GetDescription();
                else if (dto.Kind == "B9")
                    title = new B9FormFields().GetDescription();
                else if (dto.Kind == "C2")
                    title = new C2FormFields().GetDescription();
                else if (dto.Kind == "D1a")
                    title = new D1aFormFields().GetDescription();
                else if (dto.Kind == "D1b")
                    title = new D1bFormFields().GetDescription();
            }

            FormStatus formStatus = FormStatus.NotStarted;
            if (!string.IsNullOrWhiteSpace(dto.Status) && Int32.TryParse(dto.Status, out int statusValue))
            {
                formStatus = (FormStatus)statusValue;
            }
            FormLanguage formLanguage = FormLanguage.English;
            if (!string.IsNullOrWhiteSpace(dto.LANG) && Int32.TryParse(dto.LANG, out int languageValue))
            {
                formLanguage = (FormLanguage)languageValue;
            }
            FormMode formMode = FormMode.InPerson;
            if (!string.IsNullOrWhiteSpace(dto.MODE) && Int32.TryParse(dto.MODE, out int formModeValue))
            {
                formMode = (FormMode)formModeValue;
            }
            NotIncludedReasonCode? notIncludedReasonCode = null;
            if (formMode == FormMode.NotCompleted && !string.IsNullOrWhiteSpace(dto.NOT) && Int32.TryParse(dto.NOT, out int notIncludedReasonCodeValue))
            {
                notIncludedReasonCode = (NotIncludedReasonCode)notIncludedReasonCodeValue;
            }
            RemoteModality? remoteModality = null;
            if (!string.IsNullOrWhiteSpace(dto.RMMODE) && Int32.TryParse(dto.RMMODE, out int remoteModalityValue))
            {
                remoteModality = (RemoteModality)remoteModalityValue;
            }

            RemoteReasonCode? remoteReasonCode = null;
            if (!string.IsNullOrWhiteSpace(dto.RMREAS) && Int32.TryParse(dto.RMREAS, out int remoteReasonCodeValue))
            {
                remoteReasonCode = (RemoteReasonCode)remoteReasonCodeValue;
            }

            return new Form(visitId, dto.Id, title, dto.Kind, formStatus, dto.FRMDATE, dto.INITIALS, formLanguage, formMode, remoteReasonCode, remoteModality, notIncludedReasonCode, dto.CreatedAt, dto.CreatedBy, dto.ModifiedBy, dto.DeletedBy, dto.IsDeleted, formFields);
        }

        public static IList<PacketSubmission> ToDomain(this List<PacketSubmissionDto> dto, string adrcId, int visitId, string username)
        {
            if (dto == null)
                return new List<PacketSubmission>();
            else
            {
                return dto.Select(p => p.ToDomain(adrcId)).ToList();
            }
        }

        public static PacketSubmission ToDomain(this PacketSubmissionDto dto, string adrcId)
        {
            if (dto.Forms != null && dto.Forms.Count() > 0)
            {
                IList<Form> forms = new List<Form>();

                foreach (var form in dto.Forms)
                {
                    forms.Add(form.ToDomain(dto.VisitId, form.CreatedBy));
                }

                return new PacketSubmission(dto.Id, adrcId, dto.SubmissionDate, dto.VisitId, dto.CreatedAt, dto.CreatedBy, dto.ModifiedBy, dto.DeletedBy, dto.IsDeleted, dto.ErrorCount, forms);
            }
            else if (dto.PacketSubmissionErrors != null && dto.PacketSubmissionErrors.Count() > 0)
            {
                var errors = dto.PacketSubmissionErrors.Select(e => e.ToDomain()).ToList();

                return new PacketSubmission(dto.Id, adrcId, dto.SubmissionDate, dto.VisitId, dto.CreatedAt, dto.CreatedBy, dto.ModifiedBy, dto.DeletedBy, dto.IsDeleted, dto.ErrorCount, errors);
            }
            else
                return new PacketSubmission(dto.Id, adrcId, dto.SubmissionDate, dto.VisitId, dto.CreatedAt, dto.CreatedBy, dto.ModifiedBy, dto.DeletedBy, dto.IsDeleted, dto.ErrorCount);
        }

        public static PacketSubmissionError ToDomain(this PacketSubmissionErrorDto dto)
        {
            PacketSubmissionErrorLevel packetSubmissionErrorLevel = PacketSubmissionErrorLevel.Information;
            if (!string.IsNullOrWhiteSpace(dto.Level))
            {
                if (Enum.TryParse(dto.Level, true, out PacketSubmissionErrorLevel level))
                    packetSubmissionErrorLevel = level;
            }

            return new PacketSubmissionError(dto.Id, dto.FormKind, dto.Message, dto.AssignedTo, packetSubmissionErrorLevel, dto.ResolvedBy, dto.CreatedAt, dto.CreatedBy, dto.ModifiedBy, dto.DeletedBy, dto.IsDeleted);
        }
    }
}

