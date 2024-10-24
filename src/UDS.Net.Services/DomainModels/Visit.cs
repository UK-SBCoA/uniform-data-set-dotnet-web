using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels
{
    /// <summary>
    /// Visit domain model and forms contracts
    /// </summary>
    public class Visit
    {
        private Dictionary<string, FormContract[]> _formsContract = new Dictionary<string, FormContract[]>();

        public int Id { get; set; }

        public int ParticipationId { get; set; }

        public int VISITNUM { get; set; }

        public string FORMVER { get; set; } = "";

        public PacketKind PACKET { get; set; }

        public DateTime VISIT_DATE { get; set; }

        public string INITIALS { get; set; }

        public PacketStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; }

        // Read more https://github.com/dotnet/aspnetcore/blob/6d30638626ff0f471f431ae2247ce95480e418ef/src/Mvc/Mvc.Abstractions/src/ModelBinding/ModelStateDictionary.cs#L616
        public bool IsValid
        {
            get
            {
                return GetValidity("", 0);
            }

        }

        public bool IsFinalizable
        {
            get
            {
                // if ti has been submitted and error results are pending
                if (this.Status == PacketStatus.Submitted)
                    return false;

                // if it has already been submitted and it has unresolved errors
                if (this.UnresolvedErrorCount.HasValue && this.UnresolvedErrorCount.Value > 0)
                    return false;

                bool finalizable = false;

                if (this.Forms != null && this.Forms.Count() > 0 && _formsContract != null)
                {
                    var packetKindFormsContract = _formsContract.Where(u => u.Key == this.PACKET.ToString()).FirstOrDefault();
                    if (packetKindFormsContract.Value != null) // do we have a contract matching the packet kind?
                    {
                        foreach (var formContract in packetKindFormsContract.Value)
                        {
                            if (this.Forms.Where(f => formContract.Abbreviation == f.Kind).Any())
                            {
                                // if the form contract exists
                                var form = this.Forms.Where(f => formContract.Abbreviation == f.Kind).FirstOrDefault();

                                if (formContract.IsRequredForVisitKind && form.Status != FormStatus.Finalized)
                                {
                                    finalizable = false;
                                    break; // we can exit out of the loop because one required form is not yet finalized
                                }
                            }
                            finalizable = true; // if we loop through all the forms contract and all the required forms are finalized, then the entire visit is finalizable
                        }
                    }
                }

                return finalizable;
            }
        }

        public Participation Participation { get; set; } = new Participation();

        public IList<Form> Forms { get; set; } = new List<Form>();

        private void BuildFormsContract(string version, PacketKind kind, DateTime visitDate, IList<Form> existingForms)
        {
            if (version == "4")
            {
                _formsContract = new Dictionary<string, FormContract[]>
                {
                    {
                        PacketKind.I.ToString(),
                        new FormContract[]
                        {
                            new FormContract("A1", true),
                            new FormContract("A1a", true),
                            new FormContract("A2", false),
                            new FormContract("A3", true),
                            new FormContract("A4", false),
                            new FormContract("A4a", false),
                            new FormContract("A5D2", true),
                            new FormContract("B1", false),
                            new FormContract("B3", false),
                            new FormContract("B4", true),
                            new FormContract("B5", false),
                            new FormContract("B6", false),
                            new FormContract("B7", false),
                            new FormContract("B8", true),
                            new FormContract("B9", true),
                            new FormContract("C2", true), // C2C2T
                            new FormContract("D1a", true),
                            new FormContract("D1b", true)

                        }
                    },
                    {
                        PacketKind.F.ToString(), // TODO follow-up visit contracts haven't been published
                        new FormContract[]
                        {
                            new FormContract("A1", true),
                            new FormContract("A1a", true),
                            new FormContract("A2", false),
                            new FormContract("A3", true),
                            new FormContract("A4", false),
                            new FormContract("A4a", false),
                            new FormContract("A5D2", true),
                            new FormContract("B1", false),
                            new FormContract("B3", false),
                            new FormContract("B4", true),
                            new FormContract("B5", false),
                            new FormContract("B6", false),
                            new FormContract("B7", false),
                            new FormContract("B8", true),
                            new FormContract("B9", true),
                            new FormContract("C2", true), // C2C2T
                            new FormContract("D1a", true),
                            new FormContract("D1b", true)
                        }
                    }
                };

                var formDefinitions = _formsContract.Where(u => u.Key == kind.ToString()).FirstOrDefault();

                foreach (var formContract in formDefinitions.Value)
                {
                    bool hasExisting = false;

                    if (existingForms != null && existingForms.Count() > 0)
                    {
                        hasExisting = existingForms.Where(f => f.Kind == formContract.Abbreviation).Any();
                    }

                    if (hasExisting)
                    {
                        var existing = existingForms.Where(f => f.Kind == formContract.Abbreviation).FirstOrDefault();

                        Forms.Add(new Form(Id, existing.Id, existing.Title, existing.Kind, formContract.IsRequredForVisitKind, existing.Status, existing.FRMDATE, existing.INITIALS, existing.LANG, existing.MODE, existing.RMREAS, existing.RMMODE, existing.NOT, existing.CreatedAt, existing.CreatedBy, existing.ModifiedBy, existing.DeletedBy, existing.IsDeleted, existing.Fields));
                    }
                    else
                    {
                        Forms.Add(new Form(Id, formContract.Abbreviation, formContract.IsRequredForVisitKind, visitDate, CreatedBy));
                    }
                }


            }
        }

        private bool GetValidity(string node, int currentDepth)
        {
            // TODO check each property if it has been validated or if it's unvalidated
            // then if unvalidated, check if it is invalid
            return true;
        }

        public int? UnresolvedErrorCount { get; private set; }

        public IList<PacketSubmissionError> UnresolvedErrors { get; set; } = new List<PacketSubmissionError>();

        //public int Count { get; private set; }

        public Visit(int id, int number, int participationId, string version, PacketKind packet, DateTime visitDate, string initials, PacketStatus status, DateTime createdAt, string createdBy, string modifiedBy, string deletedBy, bool isDeleted, IList<Form> existingForms)
        {
            Id = id;
            VISITNUM = number;
            ParticipationId = participationId;
            FORMVER = version;
            PACKET = packet;
            VISIT_DATE = visitDate;
            INITIALS = initials;
            Status = status;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            DeletedBy = deletedBy;
            IsDeleted = IsDeleted;

            if (existingForms == null)
                existingForms = new List<Form>();

            BuildFormsContract(FORMVER, PACKET, VISIT_DATE, existingForms);
        }

        public Visit(int id, int number, int participationId, string version, PacketKind packet, DateTime visitDate, string initials, PacketStatus status, DateTime createdAt, string createdBy, string modifiedBy, string deletedBy, bool isDeleted, IList<Form> existingForms, int? unresolvedErrorCount, IList<PacketSubmissionError> unresolvedErrors)
        {
            Id = id;
            VISITNUM = number;
            ParticipationId = participationId;
            FORMVER = version;
            PACKET = packet;
            VISIT_DATE = visitDate;
            INITIALS = initials;
            Status = status;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            DeletedBy = deletedBy;
            IsDeleted = IsDeleted;
            UnresolvedErrorCount = unresolvedErrorCount;

            if (existingForms == null)
                existingForms = new List<Form>();

            BuildFormsContract(FORMVER, PACKET, VISIT_DATE, existingForms);

            if (unresolvedErrors != null)
                UnresolvedErrors = unresolvedErrors;
        }

        // TODO There's form fields and then there's validation rules for the form fields based on visit type
        // look up generics builder
        // https://stackoverflow.com/questions/30895888/setting-common-base-class-properties-when-creating-objects
        // TODO Use notifications pattern to return errors and not throwing exceptions

        public bool TryValidate()
        {
            // TODO validate the visit against any rules that might have changed due to form fields changing
            GetModelErrors();
            return true;
        }

        public IEnumerable<VisitValidationResult> GetModelErrors()
        {
            /// TODO For example, in UDS3 FVP, either C1 or C2 is required, but not both
            yield break;
        }
    }
}

