using System;
using System.Collections.Generic;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms.FollowUp
{
    public class B4FollowUpFormFields : IFormFields
    {
        public double? MEMORY { get; set; }
        public double? ORIENT { get; set; }
        public double? JUDGMENT { get; set; }
        public double? COMMUN { get; set; }
        public double? HOMEHOBB { get; set; }
        public double? PERSCARE { get; set; }
        public double? CDRSUM { get; set; }
        public double? CDRGLOB { get; set; }
        public double? COMPORT { get; set; }
        public double? CDRLANG { get; set; }

        public IEnumerable<FormMode> FormModes
        {
            get
            {
                return new List<FormMode>() { FormMode.InPerson, FormMode.Remote };
            }
        }

        public IEnumerable<NotIncludedReasonCode> NotIncludedReasonCodes
        {
            get
            {
                return new List<NotIncludedReasonCode>();
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
            return "CDR Plus NACC FTLD";
        }

        public string GetVersion()
        {
            return "4";
        }

        public B4FollowUpFormFields() { }
        public B4FollowUpFormFields(FormDto dto)
        {
            if (dto is B4Dto)
            {
                var b4Dto = ((B4Dto)dto);

                MEMORY = b4Dto.MEMORY;
                ORIENT = b4Dto.ORIENT;
                JUDGMENT = b4Dto.JUDGMENT;
                COMMUN = b4Dto.COMMUN;
                HOMEHOBB = b4Dto.HOMEHOBB;
                PERSCARE = b4Dto.PERSCARE;
                CDRSUM = b4Dto.CDRSUM;
                CDRGLOB = b4Dto.CDRGLOB;
                COMPORT = b4Dto.COMPORT;
                CDRLANG = b4Dto.CDRLANG;
            }
        }
    }
}

