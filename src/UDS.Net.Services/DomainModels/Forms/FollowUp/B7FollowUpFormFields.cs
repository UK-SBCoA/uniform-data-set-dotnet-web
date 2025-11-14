using System;
using System.Collections.Generic;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms.FollowUp
{
    public class B7FollowUpFormFields : IFormFields
    {
        public int? BILLS { get; set; }
        public int? TAXES { get; set; }
        public int? SHOPPING { get; set; }
        public int? GAMES { get; set; }
        public int? STOVE { get; set; }
        public int? MEALPREP { get; set; }
        public int? EVENTS { get; set; }
        public int? PAYATTN { get; set; }
        public int? REMDATES { get; set; }
        public int? TRAVEL { get; set; }

        public IEnumerable<FormMode> FormModes
        {
            get
            {
                return new List<FormMode>() { FormMode.InPerson, FormMode.Remote, FormMode.NotCompleted };
            }
        }

        public IEnumerable<NotIncludedReasonCode> NotIncludedReasonCodes
        {
            get
            {
                return new List<NotIncludedReasonCode>() { NotIncludedReasonCode.PhysicalProblem, NotIncludedReasonCode.CognitiveBehavioralProblem, NotIncludedReasonCode.Other, NotIncludedReasonCode.VerbalRefusal };
            }
        }

        public IEnumerable<RemoteModality> RemoteModalities
        {
            get
            {
                return new List<RemoteModality>() { RemoteModality.Telephone, RemoteModality.Video };
            }
        }

        public string GetDescription()
        {
            return "NACC Functional Assessment Scale";
        }

        public string GetVersion()
        {
            return "4";
        }

        public B7FollowUpFormFields() { }
        public B7FollowUpFormFields(FormDto dto)
        {
            if (dto is B7Dto)
            {
                var b7Dto = ((B7Dto)dto);
                BILLS = b7Dto.BILLS;
                TAXES = b7Dto.TAXES;
                SHOPPING = b7Dto.SHOPPING;
                GAMES = b7Dto.GAMES;
                STOVE = b7Dto.STOVE;
                MEALPREP = b7Dto.MEALPREP;
                EVENTS = b7Dto.EVENTS;
                PAYATTN = b7Dto.PAYATTN;
                REMDATES = b7Dto.REMDATES;
                TRAVEL = b7Dto.TRAVEL;
            }
        }
    }
}

