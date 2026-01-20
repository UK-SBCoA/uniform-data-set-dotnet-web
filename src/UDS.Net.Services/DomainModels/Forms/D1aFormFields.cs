using System;
using System.Collections.Generic;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class D1aFormFields : IFormFields
    {
        public int? DXMETHOD { get; set; }
        public int? NORMCOG { get; set; }
        public int? SCD { get; set; }
        public int? SCDDXCONF { get; set; }
        public int? DEMENTED { get; set; }
        public bool? MCICRITCLN { get; set; }
        public bool? MCICRITIMP { get; set; }
        public bool? MCICRITFUN { get; set; }
        public int? MCI { get; set; }
        public bool? IMPNOMCIFU { get; set; }
        public bool? IMPNOMCICG { get; set; }
        public bool? IMPNOMCLCD { get; set; }
        public bool? IMPNOMCIO { get; set; }
        public string IMPNOMCIOX { get; set; }
        public int? IMPNOMCI { get; set; }
        public bool? CDOMMEM { get; set; }
        public bool? CDOMLANG { get; set; }
        public bool? CDOMATTN { get; set; }
        public bool? CDOMEXEC { get; set; }
        public bool? CDOMVISU { get; set; }
        public bool? CDOMBEH { get; set; }
        public bool? CDOMAPRAX { get; set; }
        public int? MBI { get; set; }
        public int? BDOMMOT { get; set; }
        public int? BDOMAFREG { get; set; }
        public int? BDOMIMP { get; set; }
        public int? BDOMSOCIAL { get; set; }
        public int? BDOMTHTS { get; set; }
        public int? PREDOMSYN { get; set; }
        public bool? AMNDEM { get; set; }
        public bool? DYEXECSYN { get; set; }
        public bool? PCA { get; set; }
        public bool? PPASYN { get; set; }
        public int? PPASYNT { get; set; }
        public bool? FTDSYN { get; set; }
        public bool? LBDSYN { get; set; }
        public int? LBDSYNT { get; set; }
        public bool? NAMNDEM { get; set; }
        public bool? PSPSYN { get; set; }
        public int? PSPSYNT { get; set; }
        public bool? CTESYN { get; set; }
        public bool? CBSSYN { get; set; }
        public bool? MSASYN { get; set; }
        public int? MSASYNT { get; set; }
        public bool? OTHSYN { get; set; }
        public string OTHSYNX { get; set; }
        public bool? SYNINFCLIN { get; set; }
        public bool? SYNINFCTST { get; set; }
        public bool? SYNINFBIOM { get; set; }
        public bool? MAJDEPDX { get; set; }
        public int? MAJDEPDIF { get; set; }
        public bool? OTHDEPDX { get; set; }
        public int? OTHDEPDIF { get; set; }
        public bool? BIPOLDX { get; set; }
        public int? BIPOLDIF { get; set; }
        public bool? SCHIZOP { get; set; }
        public int? SCHIZOIF { get; set; }
        public bool? ANXIET { get; set; }
        public int? ANXIETIF { get; set; }
        public bool? GENANX { get; set; }
        public bool? PANICDISDX { get; set; }
        public bool? OCDDX { get; set; }
        public bool? OTHANXD { get; set; }
        public string OTHANXDX { get; set; }
        public bool? PTSDDX { get; set; }
        public int? PTSDDXIF { get; set; }
        public bool? NDEVDIS { get; set; }
        public int? NDEVDISIF { get; set; }
        public bool? DELIR { get; set; }
        public int? DELIRIF { get; set; }
        public bool? OTHPSY { get; set; }
        public int? OTHPSYIF { get; set; }
        public string OTHPSYX { get; set; }
        public bool? TBIDX { get; set; }
        public int? TBIDXIF { get; set; }
        public bool? EPILEP { get; set; }
        public int? EPILEPIF { get; set; }
        public bool? HYCEPH { get; set; }
        public int? HYCEPHIF { get; set; }
        public bool? NEOP { get; set; }
        public int? NEOPIF { get; set; }
        public int? NEOPSTAT { get; set; }
        public bool? HIV { get; set; }
        public int? HIVIF { get; set; }
        public bool? POSTC19 { get; set; }
        public int? POSTC19IF { get; set; }
        public bool? APNEADX { get; set; }
        public int? APNEADXIF { get; set; }
        public bool? OTHCOGILL { get; set; }
        public int? OTHCILLIF { get; set; }
        public string OTHCOGILLX { get; set; }
        public bool? ALCDEM { get; set; }
        public int? ALCDEMIF { get; set; }
        public bool? IMPSUB { get; set; }
        public int? IMPSUBIF { get; set; }
        public bool? MEDS { get; set; }
        public int? MEDSIF { get; set; }
        public bool? COGOTH { get; set; }
        public int? COGOTHIF { get; set; }
        public string COGOTHX { get; set; }
        public bool? COGOTH2 { get; set; }
        public int? COGOTH2F { get; set; }
        public string COGOTH2X { get; set; }
        public bool? COGOTH3 { get; set; }
        public int? COGOTH3F { get; set; }
        public string COGOTH3X { get; set; }

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
                return new List<NotIncludedReasonCode>() { };
            }
        }

        public IEnumerable<RemoteModality> RemoteModalities
        {
            get
            {
                return new List<RemoteModality>() { RemoteModality.Telephone, RemoteModality.Video };
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
            return "Clinical Diagnosis";
        }

        public string GetVersion()
        {
            return "4";
        }

        public D1aFormFields() { }
        public D1aFormFields(FormDto dto)
        {
            if (dto is D1aDto)
            {
                var d1aDto = ((D1aDto)dto);
                DXMETHOD = d1aDto.DXMETHOD;
                NORMCOG = d1aDto.NORMCOG;
                SCD = d1aDto.SCD;
                SCDDXCONF = d1aDto.SCDDXCONF;
                DEMENTED = d1aDto.DEMENTED;
                MCICRITCLN = d1aDto.MCICRITCLN;
                MCICRITIMP = d1aDto.MCICRITIMP;
                MCICRITFUN = d1aDto.MCICRITFUN;
                MCI = d1aDto.MCI;
                IMPNOMCIFU = d1aDto.IMPNOMCIFU;
                IMPNOMCICG = d1aDto.IMPNOMCICG;
                IMPNOMCLCD = d1aDto.IMPNOMCLCD;
                IMPNOMCIO = d1aDto.IMPNOMCIO;
                IMPNOMCIOX = d1aDto.IMPNOMCIOX;
                IMPNOMCI = d1aDto.IMPNOMCI.HasValue ? Convert.ToInt32(d1aDto.IMPNOMCI) : (int?)null;
                CDOMMEM = d1aDto.CDOMMEM;
                CDOMLANG = d1aDto.CDOMLANG;
                CDOMATTN = d1aDto.CDOMATTN;
                CDOMEXEC = d1aDto.CDOMEXEC;
                CDOMVISU = d1aDto.CDOMVISU;
                CDOMBEH = d1aDto.CDOMBEH;
                CDOMAPRAX = d1aDto.CDOMAPRAX;
                MBI = d1aDto.MBI;
                BDOMMOT = d1aDto.BDOMMOT;
                BDOMAFREG = d1aDto.BDOMAFREG;
                BDOMIMP = d1aDto.BDOMIMP;
                BDOMSOCIAL = d1aDto.BDOMSOCIAL;
                BDOMTHTS = d1aDto.BDOMTHTS;
                PREDOMSYN = d1aDto.PREDOMSYN;
                AMNDEM = d1aDto.AMNDEM;
                DYEXECSYN = d1aDto.DYEXECSYN;
                PCA = d1aDto.PCA;
                PPASYN = d1aDto.PPASYN;
                PPASYNT = d1aDto.PPASYNT;
                FTDSYN = d1aDto.FTDSYN;
                LBDSYN = d1aDto.LBDSYN;
                LBDSYNT = d1aDto.LBDSYNT;
                NAMNDEM = d1aDto.NAMNDEM;
                PSPSYN = d1aDto.PSPSYN;
                PSPSYNT = d1aDto.PSPSYNT;
                CTESYN = d1aDto.CTESYN;
                CBSSYN = d1aDto.CBSSYN;
                MSASYN = d1aDto.MSASYN;
                MSASYNT = d1aDto.MSASYNT;
                OTHSYN = d1aDto.OTHSYN;
                OTHSYNX = d1aDto.OTHSYNX;
                SYNINFCLIN = d1aDto.SYNINFCLIN;
                SYNINFCTST = d1aDto.SYNINFCTST;
                SYNINFBIOM = d1aDto.SYNINFBIOM;
                MAJDEPDX = d1aDto.MAJDEPDX;
                MAJDEPDIF = d1aDto.MAJDEPDIF;
                OTHDEPDX = d1aDto.OTHDEPDX;
                OTHDEPDIF = d1aDto.OTHDEPDIF;
                BIPOLDX = d1aDto.BIPOLDX;
                BIPOLDIF = d1aDto.BIPOLDIF;
                SCHIZOP = d1aDto.SCHIZOP;
                SCHIZOIF = d1aDto.SCHIZOIF;
                ANXIET = d1aDto.ANXIET;
                ANXIETIF = d1aDto.ANXIETIF;
                GENANX = d1aDto.GENANX;
                PANICDISDX = d1aDto.PANICDISDX;
                OCDDX = d1aDto.OCDDX;
                OTHANXD = d1aDto.OTHANXD;
                OTHANXDX = d1aDto.OTHANXDX;
                PTSDDX = d1aDto.PTSDDX;
                PTSDDXIF = d1aDto.PTSDDXIF;
                NDEVDIS = d1aDto.NDEVDIS;
                NDEVDISIF = d1aDto.NDEVDISIF;
                DELIR = d1aDto.DELIR;
                DELIRIF = d1aDto.DELIRIF;
                OTHPSY = d1aDto.OTHPSY;
                OTHPSYIF = d1aDto.OTHPSYIF;
                OTHPSYX = d1aDto.OTHPSYX;
                TBIDX = d1aDto.TBIDX;
                TBIDXIF = d1aDto.TBIDXIF;
                EPILEP = d1aDto.EPILEP;
                EPILEPIF = d1aDto.EPILEPIF;
                HYCEPH = d1aDto.HYCEPH;
                HYCEPHIF = d1aDto.HYCEPHIF;
                NEOP = d1aDto.NEOP;
                NEOPIF = d1aDto.NEOPIF;
                NEOPSTAT = d1aDto.NEOPSTAT;
                HIV = d1aDto.HIV;
                HIVIF = d1aDto.HIVIF;
                POSTC19 = d1aDto.POSTC19;
                POSTC19IF = d1aDto.POSTC19IF;
                APNEADX = d1aDto.APNEADX;
                APNEADXIF = d1aDto.APNEADXIF;
                OTHCOGILL = d1aDto.OTHCOGILL;
                OTHCILLIF = d1aDto.OTHCILLIF;
                OTHCOGILLX = d1aDto.OTHCOGILLX;
                ALCDEM = d1aDto.ALCDEM;
                ALCDEMIF = d1aDto.ALCDEMIF;
                IMPSUB = d1aDto.IMPSUB;
                IMPSUBIF = d1aDto.IMPSUBIF;
                MEDS = d1aDto.MEDS;
                MEDSIF = d1aDto.MEDSIF;
                COGOTH = d1aDto.COGOTH;
                COGOTHIF = d1aDto.COGOTHIF;
                COGOTHX = d1aDto.COGOTHX;
                COGOTH2 = d1aDto.COGOTH2;
                COGOTH2F = d1aDto.COGOTH2F;
                COGOTH2X = d1aDto.COGOTH2X;
                COGOTH3 = d1aDto.COGOTH3;
                COGOTH3F = d1aDto.COGOTH3F;
                COGOTH3X = d1aDto.COGOTH3X;

            }
        }
    }
}

