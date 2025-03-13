using System.Collections.Generic;
using UDS.Net.Dto;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class A2FormFields : IFormFields
    {
        public int? INRELTO { get; set; }
        public int? INKNOWN { get; set; }
        public int? INLIVWTH { get; set; }
        public int? INCNTMOD { get; set; }
        public string INCNTMDX { get; set; }
        public int? INCNTFRQ { get; set; }
        public int? INCNTTIM { get; set; }
        public int? INRELY { get; set; }
        public int? INMEMWORS { get; set; }
        public int? INMEMTROUB { get; set; }
        public int? INMEMTEN { get; set; }

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
                return new List<NotIncludedReasonCode>() { NotIncludedReasonCode.NoCoParticipantOrRemoteVisit, NotIncludedReasonCode.PhysicalProblem, NotIncludedReasonCode.CognitiveBehavioralProblem, NotIncludedReasonCode.Other, NotIncludedReasonCode.VerbalRefusal };
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
            return "Co-Participant Demographics";
        }

        public string GetVersion()
        {
            return "4";
        }

        public A2FormFields() { }
        public A2FormFields(FormDto dto) : this()
        {
            if (dto is A2Dto)
            {
                var a2Dto = ((A2Dto)dto);
                this.INRELTO = a2Dto.INRELTO;
                this.INKNOWN = a2Dto.INKNOWN;
                this.INLIVWTH = a2Dto.INLIVWTH;
                this.INCNTMOD = a2Dto.INCNTMOD;
                this.INCNTMDX = a2Dto.INCNTMDX;
                this.INCNTFRQ = a2Dto.INCNTFRQ;
                this.INCNTTIM = a2Dto.INCNTTIM;
                this.INRELY = a2Dto.INRELY;
                this.INMEMWORS = a2Dto.INMEMWORS;
                this.INMEMTROUB = a2Dto.INMEMTROUB;
                this.INMEMTEN = a2Dto.INMEMTEN;
            }
        }
    }
}

