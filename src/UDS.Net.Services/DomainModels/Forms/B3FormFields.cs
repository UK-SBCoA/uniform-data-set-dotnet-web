using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class B3FormFields : IFormFields
    {
        public bool? PDNORMAL { get; set; }
        public int? SPEECH { get; set; }
        public string SPEECHX { get; set; }
        public int? FACEXP { get; set; }
        public string FACEXPX { get; set; }
        public int? TRESTFAC { get; set; }
        public string TRESTFAX { get; set; }
        public int? TRESTRHD { get; set; }
        public string TRESTRHX { get; set; }
        public int? TRESTLHD { get; set; }
        public string TRESTLHX { get; set; }
        public int? TRESTRFT { get; set; }
        public string TRESTRFX { get; set; }
        public int? TRESTLFT { get; set; }
        public string TRESTLFX { get; set; }
        public int? TRACTRHD { get; set; }
        public string TRACTRHX { get; set; }
        public int? TRACTLHD { get; set; }
        public string TRACTLHX { get; set; }
        public int? RIGDNECK { get; set; }
        public string RIGDNEX { get; set; }
        public int? RIGDUPRT { get; set; }
        public string RIGDUPRX { get; set; }
        public int? RIGDUPLF { get; set; }
        public string RIGDUPLX { get; set; }
        public int? RIGDLORT { get; set; }
        public string RIGDLORX { get; set; }
        public int? RIGDLOLF { get; set; }
        public string RIGDLOLX { get; set; }
        public int? TAPSRT { get; set; }
        public string TAPSRTX { get; set; }
        public int? TAPSLF { get; set; }
        public string TAPSLFX { get; set; }
        public int? HANDMOVR { get; set; }
        public string HANDMVRX { get; set; }
        public int? HANDMOVL { get; set; }
        public string HANDMVLX { get; set; }
        public int? HANDALTR { get; set; }
        public string HANDATRX { get; set; }
        public int? HANDALTL { get; set; }
        public string HANDATLX { get; set; }
        public int? LEGRT { get; set; }
        public string LEGRTX { get; set; }
        public int? LEGLF { get; set; }
        public string LEGLFX { get; set; }
        public int? ARISING { get; set; }
        public string ARISINGX { get; set; }
        public int? POSTURE { get; set; }
        public string POSTUREX { get; set; }
        public int? GAIT { get; set; }
        public string GAITX { get; set; }
        public int? POSSTAB { get; set; }
        public string POSSTABX { get; set; }
        public int? BRADYKIN { get; set; }
        public string BRADYKIX { get; set; }
        public int? TOTALUPDRS { get; set; }

        public IEnumerable<FormMode> FormModes
        {
            get
            {
                return new List<FormMode>() { FormMode.InPerson, FormMode.NotCompleted };
            }
        }

        public IEnumerable<NotIncludedReasonCode> NotIncludedReasonCodes
        {
            get
            {
                return new List<NotIncludedReasonCode>() { NotIncludedReasonCode.RemoteVisit, NotIncludedReasonCode.PhysicalProblem, NotIncludedReasonCode.CognitiveBehavioralProblem, NotIncludedReasonCode.Other, NotIncludedReasonCode.VerbalRefusal };
            }
        }

        public IEnumerable<RemoteModality> RemoteModalities
        {
            get
            {
                return new List<RemoteModality>();
            }
        }

        public IEnumerable<AdministrationFormat> AdministrationFormats
        {
            get
            {
                return new List<AdministrationFormat>() { };
            }
        }

        public string GetDescription()
        {
            return "Unified Parkinson's Disease Rating Scale (UPDRS) - Motor Exam";
        }

        public string GetVersion()
        {
            return "4";
        }

        public B3FormFields() { }

        public B3FormFields(FormDto dto)
        {
            if (dto is B3Dto)
            {
                var b3dto = ((B3Dto)dto);

                PDNORMAL = b3dto.PDNORMAL;
                SPEECH = b3dto.SPEECH;
                SPEECHX = b3dto.SPEECHX;
                FACEXP = b3dto.FACEXP;
                FACEXPX = b3dto.FACEXPX;
                TRESTFAC = b3dto.TRESTFAC;
                TRESTFAX = b3dto.TRESTFAX;
                TRESTRHD = b3dto.TRESTRHD;
                TRESTRHX = b3dto.TRESTRHX;
                TRESTLHD = b3dto.TRESTLHD;
                TRESTLHX = b3dto.TRESTLHX;
                TRESTRFT = b3dto.TRESTRFT;
                TRESTRFX = b3dto.TRESTRFX;
                TRESTLFT = b3dto.TRESTLFT;
                TRESTLFX = b3dto.TRESTLFX;
                TRACTRHD = b3dto.TRACTRHD;
                TRACTRHX = b3dto.TRACTRHX;
                TRACTLHD = b3dto.TRACTLHD;
                TRACTLHX = b3dto.TRACTLHX;
                RIGDNECK = b3dto.RIGDNECK;
                RIGDNEX = b3dto.RIGDNEX;
                RIGDUPRT = b3dto.RIGDUPRT;
                RIGDUPRX = b3dto.RIGDUPRX;
                RIGDUPLF = b3dto.RIGDUPLF;
                RIGDUPLX = b3dto.RIGDUPLX;
                RIGDLORT = b3dto.RIGDLORT;
                RIGDLORX = b3dto.RIGDLORX;
                RIGDLOLF = b3dto.RIGDLOLF;
                RIGDLOLX = b3dto.RIGDLOLX;
                TAPSRT = b3dto.TAPSRT;
                TAPSRTX = b3dto.TAPSRTX;
                TAPSLF = b3dto.TAPSLF;
                TAPSLFX = b3dto.TAPSLFX;
                HANDMOVR = b3dto.HANDMOVR;
                HANDMVRX = b3dto.HANDMVRX;
                HANDMOVL = b3dto.HANDMOVL;
                HANDMVLX = b3dto.HANDMVLX;
                HANDALTR = b3dto.HANDALTR;
                HANDATRX = b3dto.HANDATRX;
                HANDALTL = b3dto.HANDALTL;
                HANDATLX = b3dto.HANDATLX;
                LEGRT = b3dto.LEGRT;
                LEGRTX = b3dto.LEGRTX;
                LEGLF = b3dto.LEGLF;
                LEGLFX = b3dto.LEGLFX;
                ARISING = b3dto.ARISING;
                ARISINGX = b3dto.ARISINGX;
                POSTURE = b3dto.POSTURE;
                POSTUREX = b3dto.POSTUREX;
                GAIT = b3dto.GAIT;
                GAITX = b3dto.GAITX;
                POSSTAB = b3dto.POSSTAB;
                POSSTABX = b3dto.POSSTABX;
                BRADYKIN = b3dto.BRADYKIN;
                BRADYKIX = b3dto.BRADYKIX;
                TOTALUPDRS = b3dto.TOTALUPDRS;

            }

        }
    }
}
