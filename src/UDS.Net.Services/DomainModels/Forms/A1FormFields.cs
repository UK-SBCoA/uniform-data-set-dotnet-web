using System;
using System.Collections.Generic;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A1FormFields : IFormFields
    {
        public int? BIRTHMO { get; set; }
        public int? BIRTHYR { get; set; }
        public string CHLDHDCTRY { get; set; }
        public bool? RACEWHITE { get; set; }
        public bool? ETHGERMAN { get; set; }
        public bool? ETHIRISH { get; set; }
        public bool? ETHENGLISH { get; set; }
        public bool? ETHITALIAN { get; set; }
        public bool? ETHPOLISH { get; set; }
        public bool? ETHSCOTT { get; set; }
        public bool? ETHWHIOTH { get; set; }
        public string ETHWHIOTHX { get; set; }
        public bool? ETHISPANIC { get; set; }
        public bool? ETHMEXICAN { get; set; }
        public bool? ETHPUERTO { get; set; }
        public bool? ETHCUBAN { get; set; }
        public bool? ETHSALVA { get; set; }
        public bool? ETHDOMIN { get; set; }
        public bool? ETHGUATEM { get; set; }
        public bool? ETHHISOTH { get; set; }
        public string ETHHISOTHX { get; set; }
        public bool? RACEBLACK { get; set; }
        public bool? ETHAFAMER { get; set; }
        public bool? ETHJAMAICA { get; set; }
        public bool? ETHHAITIAN { get; set; }
        public bool? ETHNIGERIA { get; set; }
        public bool? ETHETHIOP { get; set; }
        public bool? ETHSOMALI { get; set; }
        public bool? ETHBLKOTH { get; set; }
        public string ETHBLKOTHX { get; set; }
        public bool? RACEASIAN { get; set; }
        public bool? ETHCHINESE { get; set; }
        public bool? ETHFILIP { get; set; }
        public bool? ETHINDIA { get; set; }
        public bool? ETHVIETNAM { get; set; }
        public bool? ETHKOREAN { get; set; }
        public bool? ETHJAPAN { get; set; }
        public bool? ETHASNOTH { get; set; }
        public string ETHASNOTHX { get; set; }
        public bool? RACEAIAN { get; set; }
        public string RACEAIANX { get; set; }
        public bool? RACEMENA { get; set; }
        public bool? ETHLEBANON { get; set; }
        public bool? ETHIRAN { get; set; }
        public bool? ETHEGYPT { get; set; }
        public bool? ETHSYRIA { get; set; }
        public bool? ETHIRAQI { get; set; }
        public bool? ETHISRAEL { get; set; }
        public bool? ETHMENAOTH { get; set; }
        public string ETHMENAOTX { get; set; }
        public bool? RACENHPI { get; set; }
        public bool? ETHHAWAII { get; set; }
        public bool? ETHSAMOAN { get; set; }
        public bool? ETHCHAMOR { get; set; }
        public bool? ETHTONGAN { get; set; }
        public bool? ETHFIJIAN { get; set; }
        public bool? ETHMARSHAL { get; set; }
        public bool? ETHNHPIOTH { get; set; }
        public string ETHNHPIOTX { get; set; }
        public bool? RACEUNKN { get; set; }
        public bool? GENMAN { get; set; }
        public bool? GENWOMAN { get; set; }
        public bool? GENTRMAN { get; set; }
        public bool? GENTRWOMAN { get; set; }
        public bool? GENNONBI { get; set; }
        public bool? GENTWOSPIR { get; set; }
        public bool? GENOTH { get; set; }
        public string GENOTHX { get; set; }
        public bool? GENDKN { get; set; }
        public bool? GENNOANS { get; set; }
        public int? BIRTHSEX { get; set; }
        public int? INTERSEX { get; set; }
        public bool? SEXORNGAY { get; set; }
        public bool? SEXORNHET { get; set; }
        public bool? SEXORNBI { get; set; }
        public bool? SEXORNTWOS { get; set; }
        public bool? SEXORNOTH { get; set; }
        public string SEXORNOTHX { get; set; }
        public bool? SEXORNDNK { get; set; }
        public bool? SEXORNNOAN { get; set; }
        public int? PREDOMLAN { get; set; }
        public string PREDOMLANX { get; set; }
        public int? HANDED { get; set; }
        public int? EDUC { get; set; }
        public int? LVLEDUC { get; set; }
        public int? MARISTAT { get; set; }
        public int? LIVSITUA { get; set; }
        public int? RESIDENC { get; set; }
        public string ZIP { get; set; }
        public int? SERVED { get; set; }
        public int? MEDVA { get; set; }
        public int? EXRTIME { get; set; }
        public int? MEMWORS { get; set; }
        public int? MEMTROUB { get; set; }
        public int? MEMTEN { get; set; }
        public int? ADISTATE { get; set; }
        public int? ADINAT { get; set; }
        public int? PRIOCC { get; set; }
        public int? SOURCENW { get; set; }
        public int? REFERSC { get; set; }
        public string REFERSCX { get; set; }
        public int? REFLEARNED { get; set; }
        public string REFCTRSOCX { get; set; }
        public string REFCTRREGX { get; set; }
        public string REFOTHWEBX { get; set; }
        public string REFOTHMEDX { get; set; }
        public string REFOTHREGX { get; set; }
        public string REFOTHX { get; set; }

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
                return new List<NotIncludedReasonCode>(); // form is required for I
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
                return new List<AdministrationFormat>() { AdministrationFormat.Self, AdministrationFormat.Staff };
            }
        }

        public string GetDescription()
        {
            return "Participant Demographics";
        }

        public string GetVersion()
        {
            return "4";
        }

        public A1FormFields() { }
        public A1FormFields(FormDto dto) : this()
        {
            if (dto is A1Dto)
            {
                var a1Dto = ((A1Dto)dto);
                this.BIRTHMO = a1Dto.BIRTHMO;
                this.BIRTHYR = a1Dto.BIRTHYR;
                this.CHLDHDCTRY = a1Dto.CHLDHDCTRY;
                this.RACEWHITE = a1Dto.RACEWHITE.Value == 1 ? true : (bool?)null;
                this.ETHGERMAN = a1Dto.ETHGERMAN.Value == 1 ? true : (bool?)null;
                this.ETHIRISH = a1Dto.ETHIRISH.Value == 1 ? true : (bool?)null;
                this.ETHENGLISH = a1Dto.ETHENGLISH.Value == 1 ? true : (bool?)null;
                this.ETHITALIAN = a1Dto.ETHITALIAN.Value == 1 ? true : (bool?)null;
                this.ETHPOLISH = a1Dto.ETHPOLISH.Value == 1 ? true : (bool?)null;
                this.ETHSCOTT = a1Dto.ETHSCOTT.Value == 1 ? true : (bool?)null;
                this.ETHWHIOTH = a1Dto.ETHWHIOTH.Value == 1 ? true : (bool?)null;
                this.ETHWHIOTHX = a1Dto.ETHWHIOTHX;
                this.ETHISPANIC = a1Dto.ETHISPANIC.Value == 1 ? true : (bool?)null;
                this.ETHMEXICAN = a1Dto.ETHMEXICAN.Value == 1 ? true : (bool?)null;
                this.ETHPUERTO = a1Dto.ETHPUERTO.Value == 1 ? true : (bool?)null;
                this.ETHCUBAN = a1Dto.ETHCUBAN.Value == 1 ? true : (bool?)null;
                this.ETHSALVA = a1Dto.ETHSALVA.Value == 1 ? true : (bool?)null;
                this.ETHDOMIN = a1Dto.ETHDOMIN.Value == 1 ? true : (bool?)null;
                this.ETHGUATEM = a1Dto.ETHGUATEM.Value == 1 ? true : (bool?)null;
                this.ETHHISOTH = a1Dto.ETHHISOTH.Value == 1 ? true : (bool?)null;
                this.ETHHISOTHX = a1Dto.ETHHISOTHX;
                this.RACEBLACK = a1Dto.RACEBLACK.Value == 1 ? true : (bool?)null;
                this.ETHAFAMER = a1Dto.ETHAFAMER.Value == 1 ? true : (bool?)null;
                this.ETHJAMAICA = a1Dto.ETHJAMAICA.Value == 1 ? true : (bool?)null;
                this.ETHHAITIAN = a1Dto.ETHHAITIAN.Value == 1 ? true : (bool?)null;
                this.ETHNIGERIA = a1Dto.ETHNIGERIA.Value == 1 ? true : (bool?)null;
                this.ETHETHIOP = a1Dto.ETHETHIOP.Value == 1 ? true : (bool?)null;
                this.ETHSOMALI = a1Dto.ETHSOMALI.Value == 1 ? true : (bool?)null;
                this.ETHBLKOTH = a1Dto.ETHBLKOTH.Value == 1 ? true : (bool?)null;
                this.ETHBLKOTHX = a1Dto.ETHBLKOTHX;
                this.RACEASIAN = a1Dto.RACEASIAN.Value == 1 ? true : (bool?)null;
                this.ETHCHINESE = a1Dto.ETHCHINESE.Value == 1 ? true : (bool?)null;
                this.ETHFILIP = a1Dto.ETHFILIP.Value == 1 ? true : (bool?)null;
                this.ETHINDIA = a1Dto.ETHINDIA.Value == 1 ? true : (bool?)null;
                this.ETHVIETNAM = a1Dto.ETHVIETNAM.Value == 1 ? true : (bool?)null;
                this.ETHKOREAN = a1Dto.ETHKOREAN.Value == 1 ? true : (bool?)null;
                this.ETHJAPAN = a1Dto.ETHJAPAN.Value == 1 ? true : (bool?)null;
                this.ETHASNOTH = a1Dto.ETHASNOTH.Value == 1 ? true : (bool?)null;
                this.ETHASNOTHX = a1Dto.ETHASNOTHX;
                this.RACEAIAN = a1Dto.RACEAIAN.Value == 1 ? true : (bool?)null;
                this.RACEAIANX = a1Dto.RACEAIANX;
                this.RACEMENA = a1Dto.RACEMENA.Value == 1 ? true : (bool?)null;
                this.ETHLEBANON = a1Dto.ETHLEBANON.Value == 1 ? true : (bool?)null;
                this.ETHIRAN = a1Dto.ETHIRAN.Value == 1 ? true : (bool?)null;
                this.ETHEGYPT = a1Dto.ETHEGYPT.Value == 1 ? true : (bool?)null;
                this.ETHSYRIA = a1Dto.ETHSYRIA.Value == 1 ? true : (bool?)null;
                this.ETHIRAQI = a1Dto.ETHIRAQI.Value == 1 ? true : (bool?)null;
                this.ETHISRAEL = a1Dto.ETHISRAEL.Value == 1 ? true : (bool?)null;
                this.ETHMENAOTH = a1Dto.ETHMENAOTH.Value == 1 ? true : (bool?)null;
                this.ETHMENAOTX = a1Dto.ETHMENAOTX;
                this.RACENHPI = a1Dto.RACENHPI.Value == 1 ? true : (bool?)null;
                this.ETHHAWAII = a1Dto.ETHHAWAII.Value == 1 ? true : (bool?)null;
                this.ETHSAMOAN = a1Dto.ETHSAMOAN.Value == 1 ? true : (bool?)null;
                this.ETHCHAMOR = a1Dto.ETHCHAMOR.Value == 1 ? true : (bool?)null;
                this.ETHTONGAN = a1Dto.ETHTONGAN.Value == 1 ? true : (bool?)null;
                this.ETHFIJIAN = a1Dto.ETHFIJIAN.Value == 1 ? true : (bool?)null;
                this.ETHMARSHAL = a1Dto.ETHMARSHAL.Value == 1 ? true : (bool?)null;
                this.ETHNHPIOTH = a1Dto.ETHNHPIOTH.Value == 1 ? true : (bool?)null;
                this.ETHNHPIOTX = a1Dto.ETHNHPIOTX;
                this.RACEUNKN = a1Dto.RACEUNKN.Value == 1 ? true : (bool?)null;
                this.GENMAN = a1Dto.GENMAN.Value == 1 ? true : (bool?)null;
                this.GENWOMAN = a1Dto.GENWOMAN.Value == 1 ? true : (bool?)null;
                this.GENTRMAN = a1Dto.GENTRMAN.Value == 1 ? true : (bool?)null;
                this.GENTRWOMAN = a1Dto.GENTRWOMAN.Value == 1 ? true : (bool?)null;
                this.GENNONBI = a1Dto.GENNONBI.Value == 1 ? true : (bool?)null;
                this.GENTWOSPIR = a1Dto.GENTWOSPIR.Value == 1 ? true : (bool?)null;
                this.GENOTH = a1Dto.GENOTH.Value == 1 ? true : (bool?)null;
                this.GENOTHX = a1Dto.GENOTHX;
                this.GENDKN = a1Dto.GENDKN.Value == 1 ? true : (bool?)null;
                this.GENNOANS = a1Dto.GENNOANS.Value == 1 ? true : (bool?)null;
                this.BIRTHSEX = a1Dto.BIRTHSEX;
                this.INTERSEX = a1Dto.INTERSEX;
                this.SEXORNGAY = a1Dto.SEXORNGAY.Value == 1 ? true : (bool?)null;
                this.SEXORNHET = a1Dto.SEXORNHET.Value == 1 ? true : (bool?)null;
                this.SEXORNBI = a1Dto.SEXORNBI.Value == 1 ? true : (bool?)null;
                this.SEXORNTWOS = a1Dto.SEXORNTWOS.Value == 1 ? true : (bool?)null;
                this.SEXORNOTH = a1Dto.SEXORNOTH.Value == 1 ? true : (bool?)null;
                this.SEXORNOTHX = a1Dto.SEXORNOTHX;
                this.SEXORNDNK = a1Dto.SEXORNDNK.Value == 1 ? true : (bool?)null;
                this.SEXORNNOAN = a1Dto.SEXORNNOAN.Value == 1 ? true : (bool?)null;
                this.PREDOMLAN = a1Dto.PREDOMLAN;
                this.PREDOMLANX = a1Dto.PREDOMLANX;
                this.HANDED = a1Dto.HANDED;
                this.EDUC = a1Dto.EDUC;
                this.LVLEDUC = a1Dto.LVLEDUC;
                this.MARISTAT = a1Dto.MARISTAT;
                this.LIVSITUA = a1Dto.LIVSITUA;
                this.RESIDENC = a1Dto.RESIDENC;
                this.ZIP = a1Dto.ZIP;
                this.SERVED = a1Dto.SERVED;
                this.MEDVA = a1Dto.MEDVA;
                this.EXRTIME = a1Dto.EXRTIME;
                this.MEMWORS = a1Dto.MEMWORS;
                this.MEMTROUB = a1Dto.MEMTROUB;
                this.MEMTEN = a1Dto.MEMTEN;
                this.ADISTATE = a1Dto.ADISTATE;
                this.ADINAT = a1Dto.ADINAT;
                this.PRIOCC = a1Dto.PRIOCC;
                this.SOURCENW = a1Dto.SOURCENW;
                this.REFERSC = a1Dto.REFERSC;
                this.REFERSCX = a1Dto.REFERSCX;
                this.REFLEARNED = a1Dto.REFLEARNED;
                this.REFCTRSOCX = a1Dto.REFCTRSOCX;
                this.REFCTRREGX = a1Dto.REFCTRREGX;
                this.REFOTHWEBX = a1Dto.REFOTHWEBX;
                this.REFOTHMEDX = a1Dto.REFOTHMEDX;
                this.REFOTHREGX = a1Dto.REFOTHREGX;
                this.REFOTHX = a1Dto.REFOTHX;
            }
        }
    }
}