using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using UDS.Net.Dto;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;

namespace UDS.Net.Services.Extensions
{
    public static class DomainToDtoMapper
    {
        private static void SetBaseProperties(FormDto dto, Form form)
        {

            dto.Id = form.Id;
            dto.VisitId = form.VisitId;
            dto.Kind = form.Kind;
            dto.Status = form.Status;
            dto.Language = form.Language;
            dto.IsIncluded = form.IsIncluded;
            dto.ReasonCode = form.ReasonCode;
            dto.CreatedAt = form.CreatedAt;
            dto.CreatedBy = form.CreatedBy;
            dto.ModifiedBy = form.ModifiedBy;
            dto.DeletedBy = form.DeletedBy;
            dto.IsDeleted = form.IsDeleted;
        }

        public static VisitDto ToDto(this Visit visit)
        {
            return new VisitDto()
            {
                Id = visit.Id,
                ParticipationId = visit.ParticipationId,
                Number = visit.Number,
                Version = visit.Version,
                Kind = visit.Kind,
                StartDateTime = visit.StartDateTime,
                CreatedAt = visit.CreatedAt,
                CreatedBy = visit.CreatedBy,
                ModifiedBy = visit.ModifiedBy,
                DeletedBy = visit.DeletedBy,
                IsDeleted = visit.IsDeleted,
                Forms = visit.Forms.ToDto()
            };
        }

        public static List<FormDto> ToDto(this IList<Form> forms)
        {
            return forms.Select(f => f.ToDto()).ToList();
        }

        public static FormDto ToDto(this Form form)
        {
            if (form.Fields is A1FormFields)
            {
                var fields = (A1FormFields)form.Fields;

                var dto = new A1Dto()
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

                SetBaseProperties(dto, form);

                return dto;
            }
            else if (form.Fields is A2FormFields)
            {
                var fields = (A2FormFields)form.Fields;
                var dto = new A2Dto()
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

                SetBaseProperties(dto, form);

                return dto;
            }
            else if (form.Fields is A3FormFields)
            {
                // TODO map a3
            }
            else if (form.Fields is A4GFormFields)
            {
                // TODO map a4
            }
            else if (form.Fields is A5FormFields)
            {
                // TODO map a5
            }

            return new FormDto()
            {
                Id = form.Id,
                VisitId = form.VisitId,
                Kind = form.Kind,
                Status = form.Status,
                Language = form.Language,
                IsIncluded = form.IsIncluded,
                ReasonCode = form.ReasonCode,
                CreatedAt = form.CreatedAt,
                CreatedBy = form.CreatedBy,
                ModifiedBy = form.ModifiedBy,
                DeletedBy = form.DeletedBy,
                IsDeleted = form.IsDeleted
            };
        }
    }
}

