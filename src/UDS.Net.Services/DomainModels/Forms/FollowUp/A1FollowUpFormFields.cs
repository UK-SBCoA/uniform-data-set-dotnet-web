using System.Collections.Generic;
using UDS.Net.Dto;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms.FollowUp
{
    public class A1FollowUpFormFields : IFormFields
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

        public A1FollowUpFormFields() { }

        public A1FollowUpFormFields(FormDto dto) : this()
        {
            if (dto is A1Dto)
            {
                var a1Dto = ((A1Dto)dto);
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
                this.SEXORNGAY = a1Dto.SEXORNGAY.Value == 1 ? true : (bool?)null;
                this.SEXORNHET = a1Dto.SEXORNHET.Value == 1 ? true : (bool?)null;
                this.SEXORNBI = a1Dto.SEXORNBI.Value == 1 ? true : (bool?)null;
                this.SEXORNTWOS = a1Dto.SEXORNTWOS.Value == 1 ? true : (bool?)null;
                this.SEXORNOTH = a1Dto.SEXORNOTH.Value == 1 ? true : (bool?)null;
                this.SEXORNOTHX = a1Dto.SEXORNOTHX;
                this.SEXORNDNK = a1Dto.SEXORNDNK.Value == 1 ? true : (bool?)null;
                this.SEXORNNOAN = a1Dto.SEXORNNOAN.Value == 1 ? true : (bool?)null;
                this.MARISTAT = a1Dto.MARISTAT;
                this.LIVSITUA = a1Dto.LIVSITUA;
                this.RESIDENC = a1Dto.RESIDENC;
                this.ZIP = a1Dto.ZIP;
                this.MEDVA = a1Dto.MEDVA;
                this.EXRTIME = a1Dto.EXRTIME;
                this.MEMWORS = a1Dto.MEMWORS;
                this.MEMTROUB = a1Dto.MEMTROUB;
                this.MEMTEN = a1Dto.MEMTEN;
                this.ADISTATE = a1Dto.ADISTATE;
                this.ADINAT = a1Dto.ADINAT;
            }
        }
    }
}
