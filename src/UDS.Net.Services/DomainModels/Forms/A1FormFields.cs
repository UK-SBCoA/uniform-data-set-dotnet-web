using System.Collections.Generic;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A1FormFields : IFormFields
    {
        public FollowUpFields FollowUp { get; set; } = new FollowUpFields();

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

        public class FollowUpFields
        {
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
            public bool? SEXORNGAY { get; set; }
            public bool? SEXORNHET { get; set; }
            public bool? SEXORNBI { get; set; }
            public bool? SEXORNTWOS { get; set; }
            public bool? SEXORNOTH { get; set; }
            public string SEXORNOTHX { get; set; }
            public bool? SEXORNDNK { get; set; }
            public bool? SEXORNNOAN { get; set; }
            public int? MARISTAT { get; set; }
            public int? LIVSITUA { get; set; }
            public int? RESIDENC { get; set; }
            public string ZIP { get; set; }
            public int? MEDVA { get; set; }
            public int? EXRTIME { get; set; }
            public int? MEMWORS { get; set; }
            public int? MEMTROUB { get; set; }
            public int? MEMTEN { get; set; }
            public int? ADISTATE { get; set; }
            public int? ADINAT { get; set; }
        }

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
        public A1FormFields(FormDto dto, bool isFollowUp) : this()
        {
            if (dto is A1Dto)
            {
                if (isFollowUp)
                {
                    var a1Dto = ((A1Dto)dto);
                    this.FollowUp.GENMAN = a1Dto.GENMAN.Value == 1 ? true : (bool?)null;
                    this.FollowUp.GENWOMAN = a1Dto.GENWOMAN.Value == 1 ? true : (bool?)null;
                    this.FollowUp.GENTRMAN = a1Dto.GENTRMAN.Value == 1 ? true : (bool?)null;
                    this.FollowUp.GENTRWOMAN = a1Dto.GENTRWOMAN.Value == 1 ? true : (bool?)null;
                    this.FollowUp.GENNONBI = a1Dto.GENNONBI.Value == 1 ? true : (bool?)null;
                    this.FollowUp.GENTWOSPIR = a1Dto.GENTWOSPIR.Value == 1 ? true : (bool?)null;
                    this.FollowUp.GENOTH = a1Dto.GENOTH.Value == 1 ? true : (bool?)null;
                    this.FollowUp.GENOTHX = a1Dto.GENOTHX;
                    this.FollowUp.GENDKN = a1Dto.GENDKN.Value == 1 ? true : (bool?)null;
                    this.FollowUp.GENNOANS = a1Dto.GENNOANS.Value == 1 ? true : (bool?)null;
                    this.FollowUp.SEXORNGAY = a1Dto.SEXORNGAY.Value == 1 ? true : (bool?)null;
                    this.FollowUp.SEXORNHET = a1Dto.SEXORNHET.Value == 1 ? true : (bool?)null;
                    this.FollowUp.SEXORNBI = a1Dto.SEXORNBI.Value == 1 ? true : (bool?)null;
                    this.FollowUp.SEXORNTWOS = a1Dto.SEXORNTWOS.Value == 1 ? true : (bool?)null;
                    this.FollowUp.SEXORNOTH = a1Dto.SEXORNOTH.Value == 1 ? true : (bool?)null;
                    this.FollowUp.SEXORNOTHX = a1Dto.SEXORNOTHX;
                    this.FollowUp.SEXORNDNK = a1Dto.SEXORNDNK.Value == 1 ? true : (bool?)null;
                    this.FollowUp.SEXORNNOAN = a1Dto.SEXORNNOAN.Value == 1 ? true : (bool?)null;
                    this.FollowUp.MARISTAT = a1Dto.MARISTAT;
                    this.FollowUp.LIVSITUA = a1Dto.LIVSITUA;
                    this.FollowUp.RESIDENC = a1Dto.RESIDENC;
                    this.FollowUp.ZIP = a1Dto.ZIP;
                    this.FollowUp.MEDVA = a1Dto.MEDVA;
                    this.FollowUp.EXRTIME = a1Dto.EXRTIME;
                    this.FollowUp.MEMWORS = a1Dto.MEMWORS;
                    this.FollowUp.MEMTROUB = a1Dto.MEMTROUB;
                    this.FollowUp.MEMTEN = a1Dto.MEMTEN;
                    this.FollowUp.ADISTATE = a1Dto.ADISTATE;
                    this.FollowUp.ADINAT = a1Dto.ADINAT;
                }
                else
                {
                    var a1Dto = ((A1Dto)dto);
                    this.Initial.BIRTHMO = a1Dto.BIRTHMO;
                    this.Initial.BIRTHYR = a1Dto.BIRTHYR;
                    this.Initial.CHLDHDCTRY = a1Dto.CHLDHDCTRY;
                    this.Initial.RACEWHITE = a1Dto.RACEWHITE.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHGERMAN = a1Dto.ETHGERMAN.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHIRISH = a1Dto.ETHIRISH.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHENGLISH = a1Dto.ETHENGLISH.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHITALIAN = a1Dto.ETHITALIAN.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHPOLISH = a1Dto.ETHPOLISH.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHSCOTT = a1Dto.ETHSCOTT.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHWHIOTH = a1Dto.ETHWHIOTH.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHWHIOTHX = a1Dto.ETHWHIOTHX;
                    this.Initial.ETHISPANIC = a1Dto.ETHISPANIC.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHMEXICAN = a1Dto.ETHMEXICAN.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHPUERTO = a1Dto.ETHPUERTO.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHCUBAN = a1Dto.ETHCUBAN.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHSALVA = a1Dto.ETHSALVA.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHDOMIN = a1Dto.ETHDOMIN.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHGUATEM = a1Dto.ETHGUATEM.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHHISOTH = a1Dto.ETHHISOTH.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHHISOTHX = a1Dto.ETHHISOTHX;
                    this.Initial.RACEBLACK = a1Dto.RACEBLACK.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHAFAMER = a1Dto.ETHAFAMER.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHJAMAICA = a1Dto.ETHJAMAICA.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHHAITIAN = a1Dto.ETHHAITIAN.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHNIGERIA = a1Dto.ETHNIGERIA.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHETHIOP = a1Dto.ETHETHIOP.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHSOMALI = a1Dto.ETHSOMALI.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHBLKOTH = a1Dto.ETHBLKOTH.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHBLKOTHX = a1Dto.ETHBLKOTHX;
                    this.Initial.RACEASIAN = a1Dto.RACEASIAN.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHCHINESE = a1Dto.ETHCHINESE.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHFILIP = a1Dto.ETHFILIP.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHINDIA = a1Dto.ETHINDIA.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHVIETNAM = a1Dto.ETHVIETNAM.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHKOREAN = a1Dto.ETHKOREAN.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHJAPAN = a1Dto.ETHJAPAN.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHASNOTH = a1Dto.ETHASNOTH.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHASNOTHX = a1Dto.ETHASNOTHX;
                    this.Initial.RACEAIAN = a1Dto.RACEAIAN.Value == 1 ? true : (bool?)null;
                    this.Initial.RACEAIANX = a1Dto.RACEAIANX;
                    this.Initial.RACEMENA = a1Dto.RACEMENA.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHLEBANON = a1Dto.ETHLEBANON.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHIRAN = a1Dto.ETHIRAN.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHEGYPT = a1Dto.ETHEGYPT.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHSYRIA = a1Dto.ETHSYRIA.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHIRAQI = a1Dto.ETHIRAQI.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHISRAEL = a1Dto.ETHISRAEL.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHMENAOTH = a1Dto.ETHMENAOTH.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHMENAOTX = a1Dto.ETHMENAOTX;
                    this.Initial.RACENHPI = a1Dto.RACENHPI.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHHAWAII = a1Dto.ETHHAWAII.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHSAMOAN = a1Dto.ETHSAMOAN.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHCHAMOR = a1Dto.ETHCHAMOR.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHTONGAN = a1Dto.ETHTONGAN.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHFIJIAN = a1Dto.ETHFIJIAN.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHMARSHAL = a1Dto.ETHMARSHAL.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHNHPIOTH = a1Dto.ETHNHPIOTH.Value == 1 ? true : (bool?)null;
                    this.Initial.ETHNHPIOTX = a1Dto.ETHNHPIOTX;
                    this.Initial.RACEUNKN = a1Dto.RACEUNKN.Value == 1 ? true : (bool?)null;
                    this.Initial.GENMAN = a1Dto.GENMAN.Value == 1 ? true : (bool?)null;
                    this.Initial.GENWOMAN = a1Dto.GENWOMAN.Value == 1 ? true : (bool?)null;
                    this.Initial.GENTRMAN = a1Dto.GENTRMAN.Value == 1 ? true : (bool?)null;
                    this.Initial.GENTRWOMAN = a1Dto.GENTRWOMAN.Value == 1 ? true : (bool?)null;
                    this.Initial.GENNONBI = a1Dto.GENNONBI.Value == 1 ? true : (bool?)null;
                    this.Initial.GENTWOSPIR = a1Dto.GENTWOSPIR.Value == 1 ? true : (bool?)null;
                    this.Initial.GENOTH = a1Dto.GENOTH.Value == 1 ? true : (bool?)null;
                    this.Initial.GENOTHX = a1Dto.GENOTHX;
                    this.Initial.GENDKN = a1Dto.GENDKN.Value == 1 ? true : (bool?)null;
                    this.Initial.GENNOANS = a1Dto.GENNOANS.Value == 1 ? true : (bool?)null;
                    this.Initial.BIRTHSEX = a1Dto.BIRTHSEX;
                    this.Initial.INTERSEX = a1Dto.INTERSEX;
                    this.Initial.SEXORNGAY = a1Dto.SEXORNGAY.Value == 1 ? true : (bool?)null;
                    this.Initial.SEXORNHET = a1Dto.SEXORNHET.Value == 1 ? true : (bool?)null;
                    this.Initial.SEXORNBI = a1Dto.SEXORNBI.Value == 1 ? true : (bool?)null;
                    this.Initial.SEXORNTWOS = a1Dto.SEXORNTWOS.Value == 1 ? true : (bool?)null;
                    this.Initial.SEXORNOTH = a1Dto.SEXORNOTH.Value == 1 ? true : (bool?)null;
                    this.Initial.SEXORNOTHX = a1Dto.SEXORNOTHX;
                    this.Initial.SEXORNDNK = a1Dto.SEXORNDNK.Value == 1 ? true : (bool?)null;
                    this.Initial.SEXORNNOAN = a1Dto.SEXORNNOAN.Value == 1 ? true : (bool?)null;
                    this.Initial.PREDOMLAN = a1Dto.PREDOMLAN;
                    this.Initial.PREDOMLANX = a1Dto.PREDOMLANX;
                    this.Initial.HANDED = a1Dto.HANDED;
                    this.Initial.EDUC = a1Dto.EDUC;
                    this.Initial.LVLEDUC = a1Dto.LVLEDUC;
                    this.Initial.MARISTAT = a1Dto.MARISTAT;
                    this.Initial.LIVSITUA = a1Dto.LIVSITUA;
                    this.Initial.RESIDENC = a1Dto.RESIDENC;
                    this.Initial.ZIP = a1Dto.ZIP;
                    this.Initial.SERVED = a1Dto.SERVED;
                    this.Initial.MEDVA = a1Dto.MEDVA;
                    this.Initial.EXRTIME = a1Dto.EXRTIME;
                    this.Initial.MEMWORS = a1Dto.MEMWORS;
                    this.Initial.MEMTROUB = a1Dto.MEMTROUB;
                    this.Initial.MEMTEN = a1Dto.MEMTEN;
                    this.Initial.ADISTATE = a1Dto.ADISTATE;
                    this.Initial.ADINAT = a1Dto.ADINAT;
                    this.Initial.PRIOCC = a1Dto.PRIOCC;
                    this.Initial.SOURCENW = a1Dto.SOURCENW;
                    this.Initial.REFERSC = a1Dto.REFERSC;
                    this.Initial.REFERSCX = a1Dto.REFERSCX;
                    this.Initial.REFLEARNED = a1Dto.REFLEARNED;
                    this.Initial.REFCTRSOCX = a1Dto.REFCTRSOCX;
                    this.Initial.REFCTRREGX = a1Dto.REFCTRREGX;
                    this.Initial.REFOTHWEBX = a1Dto.REFOTHWEBX;
                    this.Initial.REFOTHMEDX = a1Dto.REFOTHMEDX;
                    this.Initial.REFOTHREGX = a1Dto.REFOTHREGX;
                    this.Initial.REFOTHX = a1Dto.REFOTHX;
                }
            }
        }
    }
}

