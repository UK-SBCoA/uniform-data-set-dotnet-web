using System;
using System.Collections.Generic;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class C2FormFields : IFormFields
    {
        public int? MOCACOMP { get; set; }
        public int? MOCAREAS { get; set; }
        public int? MOCALOC { get; set; }
        public int? MOCALAN { get; set; }
        public string MOCALANX { get; set; }
        public int? MOCAVIS { get; set; }
        public int? MOCAHEAR { get; set; }
        public int? MOCATOTS { get; set; }
        public int? MOCATRAI { get; set; }
        public int? MOCACUBE { get; set; }
        public int? MOCACLOC { get; set; }
        public int? MOCBTOTS { get; set; }
        public int? MOCACLON { get; set; }
        public int? MOCACLOH { get; set; }
        public int? MOCANAMI { get; set; }
        public int? MOCAREGI { get; set; }
        public int? MOCADIGI { get; set; }
        public int? MOCALETT { get; set; }
        public int? MOCASER7 { get; set; }
        public int? MOCAREPE { get; set; }
        public int? MOCAFLUE { get; set; }
        public int? MOCAABST { get; set; }
        public int? MOCARECN { get; set; }
        public int? MOCARECC { get; set; }
        public int? MOCARECR { get; set; }
        public int? MOCAORDT { get; set; }
        public int? MOCAORMO { get; set; }
        public int? MOCAORYR { get; set; }
        public int? MOCAORDY { get; set; }
        public int? MOCAORPL { get; set; }
        public int? MOCAORCT { get; set; }
        public int? NPSYCLOC { get; set; }
        public int? NPSYLAN { get; set; }
        public string NPSYLANX { get; set; }
        public int? CRAFTVRS { get; set; }
        public int? CRAFTURS { get; set; }
        public int? REY1REC { get; set; }
        public int? REY1INT { get; set; }
        public int? REY2REC { get; set; }
        public int? REY2INT { get; set; }
        public int? REY3REC { get; set; }
        public int? REY3INT { get; set; }
        public int? REY4REC { get; set; }
        public int? REY4INT { get; set; }
        public int? REY5REC { get; set; }
        public int? REY5INT { get; set; }
        public int? REYBREC { get; set; }
        public int? REYBINT { get; set; }
        public int? REY6REC { get; set; }
        public int? REY6INT { get; set; }
        public int? UDSBENTC { get; set; }
        public int? DIGFORCT { get; set; }
        public int? DIGFORSL { get; set; }
        public int? DIGBACCT { get; set; }
        public int? DIGBACLS { get; set; }
        public int? OTRAILA { get; set; }
        public int? OTRLARR { get; set; }
        public int? OTRLALI { get; set; }
        public int? OTRAILB { get; set; }
        public int? OTRLBRR { get; set; }
        public int? OTRLBLI { get; set; }
        public int? ANIMALS { get; set; }
        public int? VEG { get; set; }
        public int? TRAILA { get; set; }
        public int? TRAILARR { get; set; }
        public int? TRAILALI { get; set; }
        public int? TRAILB { get; set; }
        public int? TRAILBRR { get; set; }
        public int? TRAILBLI { get; set; }
        public int? CRAFTDVR { get; set; }
        public int? CRAFTDRE { get; set; }
        public int? CRAFTDTI { get; set; }
        public int? CRAFTCUE { get; set; }
        public int? UDSBENTD { get; set; }
        public int? UDSBENRS { get; set; }
        public int? MINTTOTS { get; set; }
        public int? MINTTOTW { get; set; }
        public int? MINTSCNG { get; set; }
        public int? MINTSCNC { get; set; }
        public int? MINTPCNG { get; set; }
        public int? MINTPCNC { get; set; }
        public int? UDSVERFC { get; set; }
        public int? UDSVERFN { get; set; }
        public int? UDSVERNF { get; set; }
        public int? UDSVERLC { get; set; }
        public int? UDSVERLR { get; set; }
        public int? UDSVERLN { get; set; }
        public int? UDSVERTN { get; set; }
        public int? UDSVERTE { get; set; }
        public int? UDSVERTI { get; set; }
        public int? VERBALTEST { get; set; }
        public int? REYDREC { get; set; }
        public int? REYDINT { get; set; }
        public int? REYDTI { get; set; }
        public int? REYMETHOD { get; set; }
        public int? REYTCOR { get; set; }
        public int? REYFPOS { get; set; }
        public int? CERAD1REC { get; set; }
        public int? CERAD1READ { get; set; }
        public int? CERAD1INT { get; set; }
        public int? CERAD2REC { get; set; }
        public int? CERAD2READ { get; set; }
        public int? CERAD2INT { get; set; }
        public int? CERAD3REC { get; set; }
        public int? CERAD3READ { get; set; }
        public int? CERAD3INT { get; set; }
        public int? CERADDTI { get; set; }
        public int? CERADJ6REC { get; set; }
        public int? CERADJ6INT { get; set; }
        public int? CERADJ7YES { get; set; }
        public int? CERADJ7NO { get; set; }
        public int? VNTTOTW { get; set; }
        public int? VNTPCNC { get; set; }
        public int? COGSTAT { get; set; }
        public int? RESPVAL { get; set; }
        public int? RESPHEAR { get; set; }
        public int? RESPDIST { get; set; }
        public int? RESPINTR { get; set; }
        public int? RESPDISN { get; set; }
        public int? RESPFATG { get; set; }
        public int? RESPEMOT { get; set; }
        public int? RESPASST { get; set; }
        public int? RESPOTH { get; set; }
        public string RESPOTHX { get; set; }

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
                return new List<RemoteModality>() { RemoteModality.Telephone, RemoteModality.Video }; // C2T for telephone and C2 for video
            }
        }

        public string GetDescription()
        {
            return "Neuropsychological Battery Scores";
        }

        public string GetVersion()
        {
            return "4";
        }

        public C2FormFields() { }
        public C2FormFields(FormDto dto)
        {
            if (dto is C2Dto)
            {
                var c2Dto = ((C2Dto)dto);
                MOCACOMP = c2Dto.MOCACOMP;
                MOCAREAS = c2Dto.MOCAREAS;
                MOCALOC = c2Dto.MOCALOC;
                MOCALAN = c2Dto.MOCALAN;
                MOCALANX = c2Dto.MOCALANX;
                MOCAVIS = c2Dto.MOCAVIS;
                MOCAHEAR = c2Dto.MOCAHEAR;
                MOCATOTS = c2Dto.MOCATOTS;
                MOCBTOTS = c2Dto.MOCBTOTS;
                MOCATRAI = c2Dto.MOCATRAI;
                MOCACUBE = c2Dto.MOCACUBE;
                MOCACLOC = c2Dto.MOCACLOC;
                MOCACLON = c2Dto.MOCACLON;
                MOCACLOH = c2Dto.MOCACLOH;
                MOCANAMI = c2Dto.MOCANAMI;
                MOCAREGI = c2Dto.MOCAREGI;
                MOCADIGI = c2Dto.MOCADIGI;
                MOCALETT = c2Dto.MOCALETT;
                MOCASER7 = c2Dto.MOCASER7;
                MOCAREPE = c2Dto.MOCAREPE;
                MOCAFLUE = c2Dto.MOCAFLUE;
                MOCAABST = c2Dto.MOCAABST;
                MOCARECN = c2Dto.MOCARECN;
                MOCARECC = c2Dto.MOCARECC;
                MOCARECR = c2Dto.MOCARECR;
                MOCAORDT = c2Dto.MOCAORDT;
                MOCAORMO = c2Dto.MOCAORMO;
                MOCAORYR = c2Dto.MOCAORYR;
                MOCAORDY = c2Dto.MOCAORDY;
                MOCAORPL = c2Dto.MOCAORPL;
                MOCAORCT = c2Dto.MOCAORCT;
                NPSYCLOC = c2Dto.NPSYCLOC;
                NPSYLAN = c2Dto.NPSYLAN;
                NPSYLANX = c2Dto.NPSYLANX;
                CRAFTVRS = c2Dto.CRAFTVRS;
                CRAFTURS = c2Dto.CRAFTURS;
                UDSBENTC = c2Dto.UDSBENTC;
                DIGFORCT = c2Dto.DIGFORCT;
                DIGFORSL = c2Dto.DIGFORSL;
                DIGBACCT = c2Dto.DIGBACCT;
                DIGBACLS = c2Dto.DIGBACLS;
                ANIMALS = c2Dto.ANIMALS;
                VEG = c2Dto.VEG;
                TRAILA = c2Dto.TRAILA;
                TRAILARR = c2Dto.TRAILARR;
                TRAILALI = c2Dto.TRAILALI;
                TRAILB = c2Dto.TRAILB;
                TRAILBRR = c2Dto.TRAILBRR;
                TRAILBLI = c2Dto.TRAILBLI;
                CRAFTDVR = c2Dto.CRAFTDVR;
                CRAFTDRE = c2Dto.CRAFTDRE;
                CRAFTDTI = c2Dto.CRAFTDTI;
                CRAFTCUE = c2Dto.CRAFTCUE;
                UDSBENTD = c2Dto.UDSBENTD;
                UDSBENRS = c2Dto.UDSBENRS;
                MINTTOTS = c2Dto.MINTTOTS;
                MINTTOTW = c2Dto.MINTTOTW;
                MINTSCNG = c2Dto.MINTSCNG;
                MINTSCNC = c2Dto.MINTSCNC;
                MINTPCNG = c2Dto.MINTPCNG;
                MINTPCNC = c2Dto.MINTPCNC;
                UDSVERFC = c2Dto.UDSVERFC;
                UDSVERFN = c2Dto.UDSVERFN;
                UDSVERNF = c2Dto.UDSVERNF;
                UDSVERLC = c2Dto.UDSVERLC;
                UDSVERLR = c2Dto.UDSVERLR;
                UDSVERLN = c2Dto.UDSVERLN;
                UDSVERTN = c2Dto.UDSVERTN;
                UDSVERTE = c2Dto.UDSVERTE;
                UDSVERTI = c2Dto.UDSVERTI;
                VERBALTEST = c2Dto.VERBALTEST;
                COGSTAT = c2Dto.COGSTAT;
                REY1REC = c2Dto.REY1REC;
                REY1INT = c2Dto.REY1INT;
                REY2REC = c2Dto.REY2REC;
                REY2INT = c2Dto.REY2INT;
                REY3REC = c2Dto.REY3REC;
                REY3INT = c2Dto.REY3INT;
                REY4REC = c2Dto.REY4REC;
                REY4INT = c2Dto.REY4INT;
                REY5REC = c2Dto.REY5REC;
                REY5INT = c2Dto.REY5INT;
                REYBREC = c2Dto.REYBREC;
                REYBINT = c2Dto.REYBINT;
                REY6REC = c2Dto.REY6REC;
                REY6INT = c2Dto.REY6INT;
                REYDREC = c2Dto.REYDREC;
                REYDINT = c2Dto.REYDINT;
                REYDTI = c2Dto.REYDTI;
                REYMETHOD = c2Dto.REYMETHOD;
                REYTCOR = c2Dto.REYTCOR;
                REYFPOS = c2Dto.REYFPOS;
                VNTTOTW = c2Dto.VNTTOTW;
                VNTPCNC = c2Dto.VNTPCNC;
                CERAD1REC = c2Dto.CERAD1REC;
                CERAD1READ = c2Dto.CERAD1READ;
                CERAD1INT = c2Dto.CERAD1INT;
                CERAD2REC = c2Dto.CERAD2REC;
                CERAD2READ = c2Dto.CERAD2READ;
                CERAD2INT = c2Dto.CERAD2INT;
                CERAD3REC = c2Dto.CERAD3REC;
                CERAD3READ = c2Dto.CERAD3READ;
                CERAD3INT = c2Dto.CERAD3INT;
                CERADDTI = c2Dto.CERADDTI;
                CERADJ6REC = c2Dto.CERADJ6REC;
                CERADJ6INT = c2Dto.CERADJ6INT;
                CERADJ7YES = c2Dto.CERADJ7YES;
                CERADJ7NO = c2Dto.CERADJ7NO;
                OTRAILA = c2Dto.OTRAILA;
                OTRLARR = c2Dto.OTRLARR;
                OTRLALI = c2Dto.OTRLALI;
                OTRAILB = c2Dto.OTRAILB;
                OTRLBRR = c2Dto.OTRLBRR;
                OTRLBLI = c2Dto.OTRLBLI;
                RESPVAL = c2Dto.RESPVAL;
                RESPHEAR = c2Dto.RESPHEAR;
                RESPDIST = c2Dto.RESPDIST;
                RESPINTR = c2Dto.RESPINTR;
                RESPDISN = c2Dto.RESPDISN;
                RESPFATG = c2Dto.RESPFATG;
                RESPEMOT = c2Dto.RESPEMOT;
                RESPASST = c2Dto.RESPASST;
                RESPOTH = c2Dto.RESPOTH;
                RESPOTHX = c2Dto.RESPOTHX;

            }
        }
        //public string GetDescription()
        //{
        //    return "Neuropsychological Battery Scores";
        //}

        //public string GetVersion()
        //{
        //    return "4.0";
        //}
    }
}

