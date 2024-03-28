using System;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class C1FormFields : IFormFields
    {
        public int? MMSECOMP { get; set; }
        public int? MMSEREAS { get; set; }
        public int? MMSELOC { get; set; }
        public int? MMSELAN { get; set; }
        public string MMSELANX { get; set; }
        public int? MMSEVIS { get; set; }
        public int? MMSEHEAR { get; set; }
        public int? MMSEORDA { get; set; }
        public int? MMSEORLO { get; set; }
        public int? PENTAGON { get; set; }
        public int? MMSE { get; set; }
        public int? NPSYCLOC { get; set; }
        public int? NPSYLAN { get; set; }
        public string NPSYLANX { get; set; }
        public int? LOGIMO { get; set; }
        public int? LOGIDAY { get; set; }
        public int? LOGIYR { get; set; }
        public int? LOGIPREV { get; set; }
        public int? LOGIMEM { get; set; }
        public int? UDSBENTC { get; set; }
        public int? DIGIF { get; set; }
        public int? DIGIFLEN { get; set; }
        public int? DIGIB { get; set; }
        public int? DIGIBLEN { get; set; }
        public int? ANIMALS { get; set; }
        public int? VEG { get; set; }
        public int? TRAILA { get; set; }
        public int? TRAILARR { get; set; }
        public int? TRAILALI { get; set; }
        public int? TRAILB { get; set; }
        public int? TRAILBRR { get; set; }
        public int? TRAILBLI { get; set; }
        public int? MEMUNITS { get; set; }
        public int? MEMTIME { get; set; }
        public int? UDSBENTD { get; set; }
        public int? UDSBENRS { get; set; }
        public int? BOSTON { get; set; }
        public int? UDSVERFC { get; set; }
        public int? UDSVERFN { get; set; }
        public int? UDSVERNF { get; set; }
        public int? UDSVERLC { get; set; }
        public int? UDSVERLR { get; set; }
        public int? UDSVERLN { get; set; }
        public int? UDSVERTN { get; set; }
        public int? UDSVERTE { get; set; }
        public int? UDSVERTI { get; set; }
        public int? COGSTAT { get; set; }

        public C1FormFields() { }
        public C1FormFields(FormDto dto)
        {
            if (dto is C1Dto)
            {
                var c1Dto = ((C1Dto)dto);
                MMSECOMP = c1Dto.MMSECOMP;
                MMSEREAS = c1Dto.MMSEREAS;
                MMSELOC = c1Dto.MMSELOC;
                MMSELAN = c1Dto.MMSELAN;
                MMSELANX = c1Dto.MMSELANX;
                MMSEVIS = c1Dto.MMSEVIS;
                MMSEHEAR = c1Dto.MMSEHEAR;
                MMSEORDA = c1Dto.MMSEORDA;
                MMSEORLO = c1Dto.MMSEORLO;
                PENTAGON = c1Dto.PENTAGON;
                MMSE = c1Dto.MMSE;
                NPSYCLOC = c1Dto.NPSYCLOC;
                NPSYLAN = c1Dto.NPSYLAN;
                NPSYLANX = c1Dto.NPSYLANX;
                LOGIMO = c1Dto.LOGIMO;
                LOGIDAY = c1Dto.LOGIDAY;
                LOGIYR = c1Dto.LOGIYR;
                LOGIPREV = c1Dto.LOGIPREV;
                LOGIMEM = c1Dto.LOGIMEM;
                UDSBENTC = c1Dto.UDSBENTC;
                DIGIF = c1Dto.DIGIF;
                DIGIFLEN = c1Dto.DIGIFLEN;
                DIGIB = c1Dto.DIGIB;
                DIGIBLEN = c1Dto.DIGIBLEN;
                ANIMALS = c1Dto.ANIMALS;
                VEG = c1Dto.VEG;
                TRAILA = c1Dto.TRAILA;
                TRAILARR = c1Dto.TRAILARR;
                TRAILALI = c1Dto.TRAILALI;
                TRAILB = c1Dto.TRAILB;
                TRAILBRR = c1Dto.TRAILBRR;
                TRAILBLI = c1Dto.TRAILBLI;
                MEMUNITS = c1Dto.MEMUNITS;
                MEMTIME = c1Dto.MEMTIME;
                UDSBENTD = c1Dto.UDSBENTD;
                UDSBENRS = c1Dto.UDSBENRS;
                BOSTON = c1Dto.BOSTON;
                UDSVERFC = c1Dto.UDSVERFC;
                UDSVERFN = c1Dto.UDSVERFN;
                UDSVERNF = c1Dto.UDSVERNF;
                UDSVERLC = c1Dto.UDSVERLC;
                UDSVERLR = c1Dto.UDSVERLR;
                UDSVERLN = c1Dto.UDSVERLN;
                UDSVERTN = c1Dto.UDSVERTN;
                UDSVERTE = c1Dto.UDSVERTE;
                UDSVERTI = c1Dto.UDSVERTI;
                COGSTAT = c1Dto.COGSTAT;
            }
        }
        public string GetDescription()
        {
            return "Neuropsychological Battery Scores";
        }

        public string GetVersion()
        {
            return "3.0";
        }
    }
}

