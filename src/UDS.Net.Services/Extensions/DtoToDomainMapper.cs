﻿using System;
using System.Collections.Generic;
using System.Linq;
using UDS.Net.Dto;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;

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
                IsDeleted = dto.IsDeleted
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
            {
                existingForms = dto.Forms.ToDomain(dto.Id, username);
            }

            return new Visit(dto.Id, dto.Number, dto.ParticipationId, dto.Version, dto.Kind, dto.StartDateTime, dto.CreatedAt, dto.CreatedBy, dto.ModifiedBy, dto.DeletedBy, dto.IsDeleted, existingForms);
        }

        public static IList<Form> ToDomain(this List<FormDto> dto, int visitId, string username)
        {
            if (dto != null)
                return dto.Select(f => f.ToDomain(visitId, username)).ToList();

            return new List<Form>();
        }

        public static Form ToDomain(this FormDto dto, int visitId, string username)
        {
            IFormFields formFields = null; // if the form is NOT of a specific type then there are no fields to include

            if (dto is A1Dto)
            {
                formFields = new A1FormFields(dto);
            }
            else if (dto is A2Dto)
            {
                formFields = new A2FormFields(dto);
            }
            else if (dto is A3Dto)
            {
                formFields = new A3FormFields(dto);
            }
            else if (dto is A4GDto)
            {
                formFields = new A4GFormFields(dto);
            }
            else if (dto is A5Dto)
            {
                formFields = new A5FormFields(dto);
            }
            else if (dto is B1Dto)
            {
                formFields = new B1FormFields(dto);
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
            else if (dto is C1Dto)
            {
                formFields = new C1FormFields(dto);
            }
            else if (dto is C2Dto)
            {
                formFields = new C2FormFields(dto);
            }
            else if (dto is D1Dto)
            {
                formFields = new D1FormFields(dto);
            }
            else if (dto is D2Dto)
            {
                formFields = new D2FormFields(dto);
            }
            else if (dto is T1Dto)
            {
                formFields = new T1FormFields(dto);
            }

            return new Form(visitId, dto.Id, dto.Kind, dto.Kind, dto.Status, dto.Language, dto.IsIncluded, dto.ReasonCode, dto.CreatedAt, dto.CreatedBy, dto.ModifiedBy, dto.DeletedBy, dto.IsDeleted, formFields);
        }

    }
}

