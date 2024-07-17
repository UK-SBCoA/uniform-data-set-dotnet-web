﻿using System;
using System.Collections.Generic;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;
using UDS.Net.Services.LookupModels;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A4DFormFields : IFormFields
    {
        public int Id { get; set; }

        public string RxNormId { get; set; }

        public DrugCode? DrugCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; }

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
            return "Medication";
        }

        public string GetVersion()
        {
            return "4";
        }

        public A4DFormFields() { }
        public A4DFormFields(FormDto dto) : this()
        {
            // TODO map rxnormids
        }
    }
}

