using System;
using System.Collections.Generic;
using System.Xml.Linq;
using UDS.Net.Dto;

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
        public int? ETHFRENCH { get; set; }
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
        public int? ETHMOROCCO { get; set; }
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

        public string GetDescription()
        {
            return "Participant demographics";
        }

        public string GetVersion()
        {
            return "3.0";
        }

        public A1FormFields() { }
        public A1FormFields(FormDto dto) : this()
        {
            if (dto is A1Dto)
            {
                var a1Dto = ((A1Dto)dto);

                entity.BIRTHMO = a1Dto.BIRTHMO;
                entity.BIRTHYR = a1Dto.BIRTHYR;
                entity.CHLDHDCTRY = a1Dto.CHLDHDCTRY;
                entity.RACEWHITE = a1Dto.RACEWHITE;
                entity.ETHGERMAN = a1Dto.ETHGERMAN;
                entity.ETHIRISH = a1Dto.ETHIRISH;
                entity.ETHENGLISH = a1Dto.ETHENGLISH;
                entity.ETHITALIAN = a1Dto.ETHITALIAN;
                entity.ETHPOLISH = a1Dto.ETHPOLISH;
                entity.ETHFRENCH = a1Dto.ETHFRENCH;
                entity.ETHWHIOTH = a1Dto.ETHWHIOTH;
                entity.ETHWHIOTHX = a1Dto.ETHWHIOTHX;
                entity.ETHISPANIC = a1Dto.ETHISPANIC;
                entity.ETHMEXICAN = a1Dto.ETHMEXICAN;
                entity.ETHPUERTO = a1Dto.ETHPUERTO;
                entity.ETHCUBAN = a1Dto.ETHCUBAN;
                entity.ETHSALVA = a1Dto.ETHSALVA;
                entity.ETHDOMIN = a1Dto.ETHDOMIN;
                entity.ETHCOLOM = a1Dto.ETHCOLOM;
                entity.ETHHISOTH = a1Dto.ETHHISOTH;
                entity.ETHHISOTHX = a1Dto.ETHHISOTHX;
                entity.RACEBLACK = a1Dto.RACEBLACK;
                entity.ETHAFAMER = a1Dto.ETHAFAMER;
                entity.ETHJAMAICA = a1Dto.ETHJAMAICA;
                entity.ETHHAITIAN = a1Dto.ETHHAITIAN;
                entity.ETHNIGERIA = a1Dto.ETHNIGERIA;
                entity.ETHETHIOP = a1Dto.ETHETHIOP;
                entity.ETHSOMALI = a1Dto.ETHSOMALI;
                entity.ETHBLKOTH = a1Dto.ETHBLKOTH;
                entity.ETHBLKOTHX = a1Dto.ETHBLKOTHX;
                entity.RACEASIAN = a1Dto.RACEASIAN;
                entity.ETHCHINESE = a1Dto.ETHCHINESE;
                entity.ETHFILIP = a1Dto.ETHFILIP;
                entity.ETHINDIA = a1Dto.ETHINDIA;
                entity.ETHVIETNAM = a1Dto.ETHVIETNAM;
                entity.ETHKOREAN = a1Dto.ETHKOREAN;
                entity.ETHJAPAN = a1Dto.ETHJAPAN;
                entity.ETHASNOTH = a1Dto.ETHASNOTH;
                entity.ETHASNOTHX = a1Dto.ETHASNOTHX;
                entity.RACEAIAN = a1Dto.RACEAIAN;
                entity.RACEAIANX = a1Dto.RACEAIANX;
                entity.RACEMENA = a1Dto.RACEMENA;
                entity.ETHLEBANON = a1Dto.ETHLEBANON;
                entity.ETHIRAN = a1Dto.ETHIRAN;
                entity.ETHEGYPT = a1Dto.ETHEGYPT;
                entity.ETHSYRIA = a1Dto.ETHSYRIA;
                entity.ETHMOROCCO = a1Dto.ETHMOROCCO;
                entity.ETHISRAEL = a1Dto.ETHISRAEL;
                entity.ETHMENAOTH = a1Dto.ETHMENAOTH;
                entity.ETHMENAOTX = a1Dto.ETHMENAOTX;
                entity.RACENHPI = a1Dto.RACENHPI;
                entity.ETHHAWAII = a1Dto.ETHHAWAII;
                entity.ETHSAMOAN = a1Dto.ETHSAMOAN;
                entity.ETHCHAMOR = a1Dto.ETHCHAMOR;
                entity.ETHTONGAN = a1Dto.ETHTONGAN;
                entity.ETHFIJIAN = a1Dto.ETHFIJIAN;
                entity.ETHMARSHAL = a1Dto.ETHMARSHAL;
                entity.ETHNHPIOTH = a1Dto.ETHNHPIOTH;
                entity.ETHNHPIOTX = a1Dto.ETHNHPIOTX;
                entity.RACEUNKN = a1Dto.RACEUNKN;
                entity.GENMAN = a1Dto.GENMAN;
                entity.GENWOMAN = a1Dto.GENWOMAN;
                entity.GENTRMAN = a1Dto.GENTRMAN;
                entity.GENTRWOMAN = a1Dto.GENTRWOMAN;
                entity.GENNONBI = a1Dto.GENNONBI;
                entity.GENTWOSPIR = a1Dto.GENTWOSPIR;
                entity.GENOTH = a1Dto.GENOTH;
                entity.GENOTHX = a1Dto.GENOTHX;
                entity.GENDKN = a1Dto.GENDKN;
                entity.GENNOANS = a1Dto.GENNOANS;
                entity.BIRTHSEX = a1Dto.BIRTHSEX;
                entity.INTERSEX = a1Dto.INTERSEX;
                entity.SEXORNGAY = a1Dto.SEXORNGAY;
                entity.SEXORNHET = a1Dto.SEXORNHET;
                entity.SEXORNBI = a1Dto.SEXORNBI;
                entity.SEXORNTWOS = a1Dto.SEXORNTWOS;
                entity.SEXORNOTH = a1Dto.SEXORNOTH;
                entity.SEXORNOTHX = a1Dto.SEXORNOTHX;
                entity.SEXORNDNK = a1Dto.SEXORNDNK;
                entity.SEXORNNOAN = a1Dto.SEXORNNOAN;
                entity.PREDOMLAN = a1Dto.PREDOMLAN;
                entity.PREDOMLANX = a1Dto.PREDOMLANX;
                entity.LVLEDUC = a1Dto.LVLEDUC;
                entity.SERVED = a1Dto.SERVED;
                entity.MEDVA = a1Dto.MEDVA;
                entity.EXRTIME = a1Dto.EXRTIME;
                entity.MEMWORS = a1Dto.MEMWORS;
                entity.MEMTROUB = a1Dto.MEMTROUB;
                entity.MEMTEN = a1Dto.MEMTEN;
                entity.ADISTATE = a1Dto.ADISTATE;
                entity.ADINAT = a1Dto.ADINAT;
                entity.PRIOCC = a1Dto.PRIOCC;
                entity.SOURCENW = a1Dto.SOURCENW;
                entity.REFERSC = a1Dto.REFERSC;
                entity.REFERSCX = a1Dto.REFERSCX;
                entity.REFLEARNED = a1Dto.REFLEARNED;
                entity.REFCTRSOCX = a1Dto.REFCTRSOCX;
                entity.REFCTRREGX = a1Dto.REFCTRREGX;
                entity.REFOTHWEBX = a1Dto.REFOTHWEBX;
                entity.REFOTHMEDX = a1Dto.REFOTHMEDX;
                entity.REFOTHREGX = a1Dto.REFOTHREGX;
                entity.REFOTHX = a1Dto.REFOTHX;

            }
        }
    }
}

