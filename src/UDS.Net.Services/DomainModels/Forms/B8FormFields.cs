using System;
using System.Collections.Generic;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class B8FormFields : IFormFields
    {
        public int? NEUREXAM { get; set; }
        public bool? NORMNREXAM { get; set; }
        public int? PARKSIGN { get; set; }
        public int? SLOWINGFM { get; set; }
        public int? TREMREST { get; set; }
        public int? TREMPOST { get; set; }
        public int? TREMKINE { get; set; }
        public int? RIGIDARM { get; set; }
        public int? RIGIDLEG { get; set; }
        public int? DYSTARM { get; set; }
        public int? DYSTLEG { get; set; }
        public int? CHOREA { get; set; }
        public int? AMPMOTOR { get; set; }
        public int? AXIALRIG { get; set; }
        public int? POSTINST { get; set; }
        public int? MASKING { get; set; }
        public int? STOOPED { get; set; }
        public int? OTHERSIGN { get; set; }
        public int? LIMBAPRAX { get; set; }
        public int? UMNDIST { get; set; }
        public int? LMNDIST { get; set; }
        public int? VFIELDCUT { get; set; }
        public int? LIMBATAX { get; set; }
        public int? MYOCLON { get; set; }
        public int? UNISOMATO { get; set; }
        public int? APHASIA { get; set; }
        public int? ALIENLIMB { get; set; }
        public int? HSPATNEG { get; set; }
        public int? PSPOAGNO { get; set; }
        public int? SMTAGNO { get; set; }
        public int? OPTICATAX { get; set; }
        public int? APRAXGAZE { get; set; }
        public int? VHGAZEPAL { get; set; }
        public int? DYSARTH { get; set; }
        public int? APRAXSP { get; set; }
        public int? GAITABN { get; set; }
        public int? GAITFIND { get; set; }
        public string GAITOTHRX { get; set; }

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
            return "Evaluation Form: Neurological Examination Findings";
        }

        public string GetVersion()
        {
            return "4";
        }

        public B8FormFields() { }
        public B8FormFields(FormDto dto)
        {
            if (dto is B8Dto)
            {
                var b8Dto = ((B8Dto)dto);
                NEUREXAM = b8Dto.NEUREXAM;
                NORMNREXAM = b8Dto.NORMNREXAM;
                PARKSIGN = b8Dto.PARKSIGN;
                SLOWINGFM = b8Dto.SLOWINGFM;
                TREMREST = b8Dto.TREMREST;
                TREMPOST = b8Dto.TREMPOST;
                TREMKINE = b8Dto.TREMKINE;
                RIGIDARM = b8Dto.RIGIDARM;
                RIGIDLEG = b8Dto.RIGIDLEG;
                DYSTARM = b8Dto.DYSTARM;
                DYSTLEG = b8Dto.DYSTLEG;
                CHOREA = b8Dto.CHOREA;
                AMPMOTOR = b8Dto.AMPMOTOR;
                AXIALRIG = b8Dto.AXIALRIG;
                POSTINST = b8Dto.POSTINST;
                MASKING = b8Dto.MASKING;
                STOOPED = b8Dto.STOOPED;
                OTHERSIGN = b8Dto.OTHERSIGN;
                LIMBAPRAX = b8Dto.LIMBAPRAX;
                UMNDIST = b8Dto.UMNDIST;
                LMNDIST = b8Dto.LMNDIST;
                VFIELDCUT = b8Dto.VFIELDCUT;
                LIMBATAX = b8Dto.LIMBATAX;
                MYOCLON = b8Dto.MYOCLON;
                UNISOMATO = b8Dto.UNISOMATO;
                APHASIA = b8Dto.APHASIA;
                ALIENLIMB = b8Dto.ALIENLIMB;
                HSPATNEG = b8Dto.HSPATNEG;
                PSPOAGNO = b8Dto.PSPOAGNO;
                SMTAGNO = b8Dto.SMTAGNO;
                OPTICATAX = b8Dto.OPTICATAX;
                APRAXGAZE = b8Dto.APRAXGAZE;
                VHGAZEPAL = b8Dto.VHGAZEPAL;
                DYSARTH = b8Dto.DYSARTH;
                APRAXSP = b8Dto.APRAXSP;
                GAITABN = b8Dto.GAITABN;
                GAITFIND = b8Dto.GAITFIND;
                GAITOTHRX = b8Dto.GAITOTHRX;

            }
        }
    }
}

