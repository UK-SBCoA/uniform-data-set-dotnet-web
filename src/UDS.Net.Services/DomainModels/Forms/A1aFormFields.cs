using System.Collections.Generic;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A1aFormFields : IFormFields
    {
        public int? OWNSCAR { get; set; }
        public int? TRSPACCESS { get; set; }
        public int? TRANSPROB { get; set; }
        public int? TRANSWORRY { get; set; }
        public int? TRSPMED { get; set; }
        public int? INCOMEYR { get; set; }
        public int? FINSATIS { get; set; }
        public int? BILLPAY { get; set; }
        public int? FINUPSET { get; set; }
        public int? EATLESS { get; set; }
        public int? EATLESSYR { get; set; }
        public int? LESSMEDS { get; set; }
        public int? LESSMEDSYR { get; set; }
        public int? COMPCOMM { get; set; }
        public int? GUARDEDU { get; set; }
        public int? EMPTINESS { get; set; }
        public int? MISSPEOPLE { get; set; }
        public int? FRIENDS { get; set; }
        public int? ABANDONED { get; set; }
        public int? CLOSEFRND { get; set; }
        public int? PARENTCOMM { get; set; }
        public int? CHILDCOMM { get; set; }
        public int? FRIENDCOMM { get; set; }
        public int? PARTICIPATE { get; set; }
        public int? SAFEHOME { get; set; }
        public int? SAFECOMM { get; set; }
        public int? DELAYMED { get; set; }
        public int? SCRIPTPROB { get; set; }
        public int? MISSEDFUP { get; set; }
        public int? DOCADVICE { get; set; }
        public int? HEALTHACC { get; set; }
        public int? LESSCOURT { get; set; }
        public int? POORSERV { get; set; }
        public int? NOTSMART { get; set; }
        public int? ACTAFRAID { get; set; }
        public int? THREATENED { get; set; }
        public int? POORMEDTRT { get; set; }
        public bool EXPANCEST { get; set; }
        public bool EXPGENDER { get; set; }
        public bool EXPRACE { get; set; }
        public bool EXPAGE { get; set; }
        public bool EXPRELIG { get; set; }
        public bool EXPHEIGHT { get; set; }
        public bool EXPWEIGHT { get; set; }
        public bool EXPAPPEAR { get; set; }
        public bool EXPSEXORN { get; set; }
        public bool EXPEDUCINC { get; set; }
        public bool EXPDISAB { get; set; }
        public bool EXPSKIN { get; set; }
        public bool EXPOTHER { get; set; }
        public bool EXPNOTAPP { get; set; }
        public bool EXPNOANS { get; set; }
        public int? EXPSTRS { get; set; }

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
                return new List<NotIncludedReasonCode>() { NotIncludedReasonCode.ConcernsAboutReliability };
            }
        }

        public IEnumerable<RemoteModality> RemoteModalities
        {
            get
            {
                return new List<RemoteModality>() { RemoteModality.Telephone, RemoteModality.Video, RemoteModality.Mail, RemoteModality.Electronic }; // form is required for I
            }
        }

        public string GetDescription()
        {
            return "Social Determinants of Health";
        }

        public string GetVersion()
        {
            return "4";
        }

        public A1aFormFields() { }
        public A1aFormFields(FormDto dto)
        {
            if (dto is A1aDto)
            {
                var a1aDto = ((A1aDto)dto);
                OWNSCAR = a1aDto.OWNSCAR;
                TRSPACCESS = a1aDto.TRSPACCESS;
                TRANSPROB = a1aDto.TRANSPROB;
                TRANSWORRY = a1aDto.TRANSWORRY;
                TRSPMED = a1aDto.TRSPMED;
                INCOMEYR = a1aDto.INCOMEYR;
                FINSATIS = a1aDto.FINSATIS;
                BILLPAY = a1aDto.BILLPAY;
                FINUPSET = a1aDto.FINUPSET;
                EATLESS = a1aDto.EATLESS;
                EATLESSYR = a1aDto.EATLESSYR;
                LESSMEDS = a1aDto.LESSMEDS;
                LESSMEDSYR = a1aDto.LESSMEDSYR;
                COMPCOMM = a1aDto.COMPCOMM;
                GUARDEDU = a1aDto.GUARDEDU;
                EMPTINESS = a1aDto.EMPTINESS;
                MISSPEOPLE = a1aDto.MISSPEOPLE;
                FRIENDS = a1aDto.FRIENDS;
                ABANDONED = a1aDto.ABANDONED;
                CLOSEFRND = a1aDto.CLOSEFRND;
                PARENTCOMM = a1aDto.PARENTCOMM;
                CHILDCOMM = a1aDto.CHILDCOMM;
                FRIENDCOMM = a1aDto.FRIENDCOMM;
                PARTICIPATE = a1aDto.PARTICIPATE;
                SAFEHOME = a1aDto.SAFEHOME;
                SAFECOMM = a1aDto.SAFECOMM;
                DELAYMED = a1aDto.DELAYMED;
                SCRIPTPROB = a1aDto.SCRIPTPROB;
                MISSEDFUP = a1aDto.MISSEDFUP;
                DOCADVICE = a1aDto.DOCADVICE;
                HEALTHACC = a1aDto.HEALTHACC;
                LESSCOURT = a1aDto.LESSCOURT;
                POORSERV = a1aDto.POORSERV;
                NOTSMART = a1aDto.NOTSMART;
                ACTAFRAID = a1aDto.ACTAFRAID;
                THREATENED = a1aDto.THREATENED;
                POORMEDTRT = a1aDto.POORMEDTRT;
                EXPANCEST = (bool)a1aDto.EXPANCEST;
                EXPGENDER = (bool)a1aDto.EXPGENDER;
                EXPRACE = (bool)a1aDto.EXPRACE;
                EXPAGE = (bool)a1aDto.EXPAGE;
                EXPRELIG = (bool)a1aDto.EXPRELIG;
                EXPHEIGHT = (bool)a1aDto.EXPHEIGHT;
                EXPWEIGHT = (bool)a1aDto.EXPWEIGHT;
                EXPAPPEAR = (bool)a1aDto.EXPAPPEAR;
                EXPSEXORN = (bool)a1aDto.EXPSEXORN;
                EXPEDUCINC = (bool)a1aDto.EXPEDUCINC;
                EXPDISAB = (bool)a1aDto.EXPDISAB;
                EXPSKIN = (bool)a1aDto.EXPSKIN;
                EXPOTHER = (bool)a1aDto.EXPOTHER;
                EXPNOTAPP = (bool)a1aDto.EXPNOTAPP;
                EXPNOANS = (bool)a1aDto.EXPNOANS;
                EXPSTRS = a1aDto.EXPSTRS;
            }
        }

    }
}

