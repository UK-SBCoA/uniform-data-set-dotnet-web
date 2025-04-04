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

        public PacketStatus Status { get; private set; }

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

        /// <summary>
        /// This only checks if it could be finalized, not that it follows the rules for status changes
        /// </summary>
        public bool IsFinalizable
        {
            get
            {
                bool finalizable = false;

                // double check that it does not have unresolved errors
                if (this.UnresolvedErrorCount.HasValue && this.UnresolvedErrorCount.Value > 0)
                    return false;

                // now check that all the forms follow the contract to be finalized
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
                        PacketKind.I4.ToString(),
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

                        Forms.Add(new Form(Id, existing.Id, existing.Title, existing.Kind, formContract.IsRequredForVisitKind, existing.Status, existing.FRMDATE, existing.INITIALS, existing.LANG, existing.MODE, existing.RMREAS, existing.RMMODE, existing.NOT, existing.CreatedAt, existing.CreatedBy, existing.ModifiedBy, existing.DeletedBy, existing.IsDeleted, existing.Fields, existing.UnresolvedErrors));
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

        public bool TryUpdateStatus(PacketStatus status)
        {
            bool updatePossible = false;
            if (this.Status == PacketStatus.Pending)
            {
                if (status == PacketStatus.Pending)
                    updatePossible = true;
                else if (status == PacketStatus.Finalized)
                {
                    if (this.IsFinalizable)
                        updatePossible = true;
                }
            }
            else if (this.Status == PacketStatus.Finalized)
            {
                if (status == PacketStatus.Pending)
                    updatePossible = true; // revert
                else if (status == PacketStatus.Submitted)
                    updatePossible = true;
            }
            else if (this.Status == PacketStatus.FailedErrorChecks)
            {
                // when errors are attempted to be resolved status can be moved back to pending
                if (status == PacketStatus.Pending)
                    updatePossible = true;
            }
            else if (this.Status == PacketStatus.PassedErrorChecks)
            {
                if (status == PacketStatus.Pending)
                    updatePossible = true;
                else if (status == PacketStatus.Frozen)
                    updatePossible = true;
            }
            else if (this.Status == PacketStatus.Frozen)
            {
                if (status == PacketStatus.Pending)
                    updatePossible = true;
            }
            return updatePossible;
        }

        public bool UpdateStatus(PacketStatus status)
        {
            if (TryUpdateStatus(status))
            {
                this.Status = status;
                return true;
            }
            return false;
        }

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

        public Visit(int id, int number, int participationId, Participation participation, string version, PacketKind packet, DateTime visitDate, string initials, PacketStatus status, DateTime createdAt, string createdBy, string modifiedBy, string deletedBy, bool isDeleted, IList<Form> existingForms, int? unresolvedErrorCount, IList<PacketSubmissionError> unresolvedErrors)
            : this(id, number, participationId, version, packet, visitDate, initials, status, createdAt, createdBy, modifiedBy, deletedBy, isDeleted, existingForms)
        {
            if (participation != null)
            {
                Participation = participation;
            }
        }

        // TODO There's form fields and then there's validation rules for the form fields based on visit type
        // look up generics builder
        // https://stackoverflow.com/questions/30895888/setting-common-base-class-properties-when-creating-objects
        // TODO Use notifications pattern to return errors and not throwing exceptions

        public bool TryValidate()
        {
            // TODO validate the visit against any rules that might have changed due to form fields changing
            var errors = GetModelErrors();
            if (errors != null && errors.Count() > 0)
                return false;
            else
                return true;
        }

        // Iterator method in c# retrieves elements one by one
        //public virtual IEnumerable<VisitValidationResult> GetModelErrors()
        //{
        //    /// TODO For example, in UDS3 FVP, either C1 or C2 is required, but not both

        //    // A1 sex and D1a menstruation
        //    var a1 = (A1FormFields)this.Forms.Where(f => f.Kind == "A1").Select(f => f.Fields).FirstOrDefault();
        //    var a5d2 = (A5D2FormFields)this.Forms.Where(f => f.Kind == "A5D2").Select(f => f.Fields).FirstOrDefault();

        //    if (PACKET == PacketKind.I || PACKET == PacketKind.I4)
        //    {
        //        if (a1.BIRTHSEX == 0 && a5d2.MENARCHE != null)
        //        {
        //            yield return new VisitValidationResult(
        //                $"A1 sex cannot be male and A5D2 menstration details be provi.",
        //                new[] { nameof(a1.BIRTHSEX), nameof(a5d2.MENARCHE) });
        //        }
        //    }

        //    yield break;
        //}

        public IEnumerable<VisitValidationResult> GetModelErrors()
        {
            List<VisitValidationResult> results = new List<VisitValidationResult>();

            if (PACKET == PacketKind.I || PACKET == PacketKind.I4)
            {
                // A1 sex and D1a menstruation
                var a1 = (A1FormFields)this.Forms.Where(f => f.Kind == "A1").Select(f => f.Fields).FirstOrDefault();
                var a5d2 = (A5D2FormFields)this.Forms.Where(f => f.Kind == "A5D2").Select(f => f.Fields).FirstOrDefault();
                var b5 = (B5FormFields)this.Forms.Where(f => f.Kind == "B5").Select(f => f.Fields).FirstOrDefault();

                if (a1 != null && a5d2 != null && b5 != null)
                {
                    if (a1.BIRTHSEX == 0 && a5d2.MENARCHE != null)
                    {
                        results.Add(new VisitValidationResult(
                            $"A1 sex cannot be male and A5D2 menstration details be provided.",
                            new[] { nameof(a1.BIRTHSEX), nameof(a5d2.MENARCHE) }));
                    }
                    if (b5.ANX == 0 && a5d2.ANXIETY == 1)
                    {
                        results.Add(new VisitValidationResult(
                            $"B1 anxiety cannot be 0 (no) and A5D2 anxiety be 1 (active).",
                            new[] { nameof(b5.ANX), nameof(a5d2.ANXIETY) }));
                    }
                }
            }

            return results;
        }
    }
}

