using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A1FormFields : IFormFields
    {
        public int? BIRTHMO { get; set; }
        public int? BIRTHYR { get; set; }
        public string CHLDHDCTRY { get; set; }
        public int? RACEWHITE { get; set; }
        public int? ETHGERMAN { get; set; }
        public int? ETHIRISH { get; set; }
        public int? ETHENGLISH { get; set; }
        public int? ETHITALIAN { get; set; }
        public int? ETHPOLISH { get; set; }
        public int? ETHSCOTT { get; set; }
        public int? ETHWHIOTH { get; set; }
        public string ETHWHIOTHX { get; set; }
        public int? ETHISPANIC { get; set; }
        public int? ETHMEXICAN { get; set; }
        public int? ETHPUERTO { get; set; }
        public int? ETHCUBAN { get; set; }
        public int? ETHSALVA { get; set; }
        public int? ETHDOMIN { get; set; }
        public int? ETHCOLOM { get; set; }
        public int? ETHHISOTH { get; set; }
        public string ETHHISOTHX { get; set; }
        public int? RACEBLACK { get; set; }
        public int? ETHAFAMER { get; set; }
        public int? ETHJAMAICA { get; set; }
        public int? ETHHAITIAN { get; set; }
        public int? ETHNIGERIA { get; set; }
        public int? ETHETHIOP { get; set; }
        public int? ETHSOMALI { get; set; }
        public int? ETHBLKOTH { get; set; }
        public string ETHBLKOTHX { get; set; }
        public int? RACEASIAN { get; set; }
        public int? ETHCHINESE { get; set; }
        public int? ETHFILIP { get; set; }
        public int? ETHINDIA { get; set; }
        public int? ETHVIETNAM { get; set; }
        public int? ETHKOREAN { get; set; }
        public int? ETHJAPAN { get; set; }
        public int? ETHASNOTH { get; set; }
        public string ETHASNOTHX { get; set; }
        public int? RACEAIAN { get; set; }
        public string RACEAIANX { get; set; }
        public int? RACEMENA { get; set; }
        public int? ETHLEBANON { get; set; }
        public int? ETHIRAN { get; set; }
        public int? ETHEGYPT { get; set; }
        public int? ETHSYRIA { get; set; }
        public int? ETHIRAQI{ get; set; }
        public int? ETHISRAEL { get; set; }
        public int? ETHMENAOTH { get; set; }
        public string ETHMENAOTX { get; set; }
        public int? RACENHPI { get; set; }
        public int? ETHHAWAII { get; set; }
        public int? ETHSAMOAN { get; set; }
        public int? ETHCHAMOR { get; set; }
        public int? ETHTONGAN { get; set; }
        public int? ETHFIJIAN { get; set; }
        public int? ETHMARSHAL { get; set; }
        public int? ETHNHPIOTH { get; set; }
        public string ETHNHPIOTX { get; set; }
        public int? RACEUNKN { get; set; }
        public int? GENMAN { get; set; }
        public int? GENWOMAN { get; set; }
        public int? GENTRMAN { get; set; }
        public int? GENTRWOMAN { get; set; }
        public int? GENNONBI { get; set; }
        public int? GENTWOSPIR { get; set; }
        public int? GENOTH { get; set; }
        public string GENOTHX { get; set; }
        public int? GENDKN { get; set; }
        public int? GENNOANS { get; set; }
        public int? BIRTHSEX { get; set; }
        public int? INTERSEX { get; set; }
        public int? SEXORNGAY { get; set; }
        public int? SEXORNHET { get; set; }
        public int? SEXORNBI { get; set; }
        public int? SEXORNTWOS { get; set; }
        public int? SEXORNOTH { get; set; }
        public string SEXORNOTHX { get; set; }
        public int? SEXORNDNK { get; set; }
        public int? SEXORNNOAN { get; set; }
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
                this.RACEWHITE = a1Dto.RACEWHITE;
                this.ETHGERMAN = a1Dto.ETHGERMAN;
                this.ETHIRISH = a1Dto.ETHIRISH;
                this.ETHENGLISH = a1Dto.ETHENGLISH;
                this.ETHITALIAN = a1Dto.ETHITALIAN;
                this.ETHPOLISH = a1Dto.ETHPOLISH;
                this.ETHSCOTT = a1Dto.ETHSCOTT;
                this.ETHWHIOTH = a1Dto.ETHWHIOTH;
                this.ETHWHIOTHX = a1Dto.ETHWHIOTHX;
                this.ETHISPANIC = a1Dto.ETHISPANIC;
                this.ETHMEXICAN = a1Dto.ETHMEXICAN;
                this.ETHPUERTO = a1Dto.ETHPUERTO;
                this.ETHCUBAN = a1Dto.ETHCUBAN;
                this.ETHSALVA = a1Dto.ETHSALVA;
                this.ETHDOMIN = a1Dto.ETHDOMIN;
                this.ETHCOLOM = a1Dto.ETHCOLOM;
                this.ETHHISOTH = a1Dto.ETHHISOTH;
                this.ETHHISOTHX = a1Dto.ETHHISOTHX;
                this.RACEBLACK = a1Dto.RACEBLACK;
                this.ETHAFAMER = a1Dto.ETHAFAMER;
                this.ETHJAMAICA = a1Dto.ETHJAMAICA;
                this.ETHHAITIAN = a1Dto.ETHHAITIAN;
                this.ETHNIGERIA = a1Dto.ETHNIGERIA;
                this.ETHETHIOP = a1Dto.ETHETHIOP;
                this.ETHSOMALI = a1Dto.ETHSOMALI;
                this.ETHBLKOTH = a1Dto.ETHBLKOTH;
                this.ETHBLKOTHX = a1Dto.ETHBLKOTHX;
                this.RACEASIAN = a1Dto.RACEASIAN;
                this.ETHCHINESE = a1Dto.ETHCHINESE;
                this.ETHFILIP = a1Dto.ETHFILIP;
                this.ETHINDIA = a1Dto.ETHINDIA;
                this.ETHVIETNAM = a1Dto.ETHVIETNAM;
                this.ETHKOREAN = a1Dto.ETHKOREAN;
                this.ETHJAPAN = a1Dto.ETHJAPAN;
                this.ETHASNOTH = a1Dto.ETHASNOTH;
                this.ETHASNOTHX = a1Dto.ETHASNOTHX;
                this.RACEAIAN = a1Dto.RACEAIAN;
                this.RACEAIANX = a1Dto.RACEAIANX;
                this.RACEMENA = a1Dto.RACEMENA;
                this.ETHLEBANON = a1Dto.ETHLEBANON;
                this.ETHIRAN = a1Dto.ETHIRAN;
                this.ETHEGYPT = a1Dto.ETHEGYPT;
                this.ETHSYRIA = a1Dto.ETHSYRIA;
                this.ETHIRAQI = a1Dto.ETHIRAQI;
                this.ETHISRAEL = a1Dto.ETHISRAEL;
                this.ETHMENAOTH = a1Dto.ETHMENAOTH;
                this.ETHMENAOTX = a1Dto.ETHMENAOTX;
                this.RACENHPI = a1Dto.RACENHPI;
                this.ETHHAWAII = a1Dto.ETHHAWAII;
                this.ETHSAMOAN = a1Dto.ETHSAMOAN;
                this.ETHCHAMOR = a1Dto.ETHCHAMOR;
                this.ETHTONGAN = a1Dto.ETHTONGAN;
                this.ETHFIJIAN = a1Dto.ETHFIJIAN;
                this.ETHMARSHAL = a1Dto.ETHMARSHAL;
                this.ETHNHPIOTH = a1Dto.ETHNHPIOTH;
                this.ETHNHPIOTX = a1Dto.ETHNHPIOTX;
                this.RACEUNKN = a1Dto.RACEUNKN;
                this.GENMAN = a1Dto.GENMAN;
                this.GENWOMAN = a1Dto.GENWOMAN;
                this.GENTRMAN = a1Dto.GENTRMAN;
                this.GENTRWOMAN = a1Dto.GENTRWOMAN;
                this.GENNONBI = a1Dto.GENNONBI;
                this.GENTWOSPIR = a1Dto.GENTWOSPIR;
                this.GENOTH = a1Dto.GENOTH;
                this.GENOTHX = a1Dto.GENOTHX;
                this.GENDKN = a1Dto.GENDKN;
                this.GENNOANS = a1Dto.GENNOANS;
                this.BIRTHSEX = a1Dto.BIRTHSEX;
                this.INTERSEX = a1Dto.INTERSEX;
                this.SEXORNGAY = a1Dto.SEXORNGAY;
                this.SEXORNHET = a1Dto.SEXORNHET;
                this.SEXORNBI = a1Dto.SEXORNBI;
                this.SEXORNTWOS = a1Dto.SEXORNTWOS;
                this.SEXORNOTH = a1Dto.SEXORNOTH;
                this.SEXORNOTHX = a1Dto.SEXORNOTHX;
                this.SEXORNDNK = a1Dto.SEXORNDNK;
                this.SEXORNNOAN = a1Dto.SEXORNNOAN;
                this.PREDOMLAN = a1Dto.PREDOMLAN;
                this.PREDOMLANX = a1Dto.PREDOMLANX;
                this.HANDED = a1Dto.HANDED;
                this.EDUC = a1Dto.EDUC;
                this.LVLEDUC = a1Dto.LVLEDUC;
                this.MARISTAT = a1Dto.MARISTAT;
                this.LIVSITUA = a1Dto.LIVSITUA;
                this.RESIDENC = a1Dto.RESIDENC;
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

