using System;
using System.Collections.Generic;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class T1FormFields : IFormFields
    {
        public int? TELCOG { get; set; }
        public int? TELILL { get; set; }
        public int? TELHOME { get; set; }
        public int? TELREFU { get; set; }
        public int? TELCOV { get; set; }
        public int? TELOTHR { get; set; }
        public string TELOTHRX { get; set; }
        public int? TELMOD { get; set; }
        public int? TELINPER { get; set; }
        public int? TELMILE { get; set; }

        public IEnumerable<FormMode> FormModes
        {
            get
            {
                return new List<FormMode>() { FormMode.Remote };
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
                return new List<RemoteModality>() { RemoteModality.Telephone }; // form is required for I
            }
        }

        public T1FormFields() { }
        public T1FormFields(FormDto dto)
        {
            if (dto is T1Dto)
            {
                var t1Dto = ((T1Dto)dto);
                TELCOG = t1Dto.TELCOG;
                TELILL = t1Dto.TELILL;
                TELHOME = t1Dto.TELHOME;
                TELREFU = t1Dto.TELREFU;
                TELCOV = t1Dto.TELCOV;
                TELOTHR = t1Dto.TELOTHR;
                TELOTHRX = t1Dto.TELOTHRX;
                TELMOD = t1Dto.TELMOD;
                TELINPER = t1Dto.TELINPER;
                TELMILE = t1Dto.TELMILE;
            }
        }

        public string GetDescription()
        {
            return "Inclusion Form";
        }

        public string GetVersion()
        {
            return "4";
        }
    }
}

