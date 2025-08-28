﻿using System;
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
                //return GetValidity("", 0);
                return TryValidate();
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
                    return finalizable;

                // now check that all the forms follow the contract to be finalized
                if (this.Forms != null && this.Forms.Count() > 0 && _formsContract != null)
                {
                    var packetKindFormsContract = _formsContract.Where(u => u.Key == this.PACKET.ToString()).FirstOrDefault();
                    if (packetKindFormsContract.Value != null) // do we have a contract matching the packet kind?
                    {
                        foreach (var formContract in packetKindFormsContract.Value)
                        {
                            // if the form exists in the formscontract
                            if (this.Forms.Where(f => formContract.Abbreviation == f.Kind).Any())
                            {
                                var form = this.Forms.Where(f => formContract.Abbreviation == f.Kind).FirstOrDefault();

                                if (form.Status == FormStatus.Finalized)
                                    finalizable = true; // when a form in the contract is finalized then we will have a running finalizable = true, if we successfully make it through the list then it should remain true
                                else
                                {
                                    finalizable = false;
                                    break; // as soon as a form is found that is not finalized we can break out of the loop and immediately return false
                                }
                            }
                            else
                            {
                                // this shouldn't be reached, but just in case there is an error elsewhere we are returning false if the packet doesn't contain a form in the forms contract
                                finalizable = false;
                                break;
                            }
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
                            new FormContract("A1a", false),
                            new FormContract("A2", false),
                            new FormContract("A3", true),
                            new FormContract("A4", true),
                            new FormContract("A4a", true),
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
                            new FormContract("A1a", false),
                            new FormContract("A2", false),
                            new FormContract("A3", true),
                            new FormContract("A4", true),
                            new FormContract("A4a", true),
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
                            new FormContract("A1a", false),
                            new FormContract("A2", false),
                            new FormContract("A3", true),
                            new FormContract("A4", true),
                            new FormContract("A4a", true),
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

                        Forms.Add(new Form(Id, existing.Id, existing.Title, existing.Kind, formContract.IsRequiredForVisitKind, existing.Status, existing.FRMDATE, existing.INITIALS, existing.LANG, existing.MODE, existing.RMREAS, existing.RMMODE, existing.NOT, existing.CreatedAt, existing.CreatedBy, existing.ModifiedBy, existing.DeletedBy, existing.IsDeleted, existing.Fields, existing.UnresolvedErrors));
                    }
                    else
                    {
                        Forms.Add(new Form(Id, formContract.Abbreviation, formContract.IsRequiredForVisitKind, visitDate, CreatedBy));
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
            else if (this.Status == PacketStatus.Submitted)
            {
                // Submitted forms can change to failed error checks when an error count is submitted
                if (status == PacketStatus.FailedErrorChecks)
                    updatePossible = true;

                // Forms checked as success change to Passed error checks with an error count of 0
                if (status == PacketStatus.PassedErrorChecks)
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

        public IEnumerable<VisitValidationResult> GetModelErrors()
        {
            List<VisitValidationResult> results = new List<VisitValidationResult>();

            var a1 = (A1FormFields)this.Forms.Where(f => f.Kind == "A1").Select(f => f.Fields).FirstOrDefault();
            var a2 = (A2FormFields)this.Forms.Where(f => f.Kind == "A2").Select(f => f.Fields).FirstOrDefault();
            var a5d2 = (A5D2FormFields)this.Forms.Where(f => f.Kind == "A5D2").Select(f => f.Fields).FirstOrDefault();
            var b5 = (B5FormFields)this.Forms.Where(f => f.Kind == "B5").Select(f => f.Fields).FirstOrDefault();

            if (a1 != null && a5d2 != null && b5 != null)
            {
                // A1 sex and D1a menstruation
                if (a1.BIRTHSEX == 1 && a5d2.MENARCHE != null)
                {
                    results.Add(new VisitValidationResult(
                        $"A1 sex cannot be male and A5D2 menstruation details be provided.",
                        new[] { nameof(a1.BIRTHSEX), nameof(a5d2.MENARCHE) }));
                }
            }

            // A2 INLIVWTH == 1 (yes) and A1 LIVSITUA == 1 (lives alone) is a conflict
            if (a1 != null && a2 != null)
            {
                if (a2.INLIVWTH == 1 && a1.LIVSITUA == 1)
                {
                    results.Add(new VisitValidationResult(
                        $"IF A2 Q3. INLIVWTH (lives with participant?)=1 (yes) then Form A1, Q12. LIVSITUA (participant's living situation) should not equal 1 (lives alone)",
                        new[] { nameof(a2.INLIVWTH), nameof(a1.LIVSITUA) }));
                }
            }

            if (PACKET == PacketKind.I || PACKET == PacketKind.I4)
            {

            }

            return results;
        }

        public IEnumerable<VisitValidationResult> GetModelAlerts()
        {
            List<VisitValidationResult> results = new List<VisitValidationResult>();

            var a1 = (A1FormFields)this.Forms.Where(f => f.Kind == "A1").Select(f => f.Fields).FirstOrDefault();
            var a5d2 = (A5D2FormFields)this.Forms.Where(f => f.Kind == "A5D2").Select(f => f.Fields).FirstOrDefault();
            var b5 = (B5FormFields)this.Forms.Where(f => f.Kind == "B5").Select(f => f.Fields).FirstOrDefault();
            var b9 = (B9FormFields)this.Forms.Where(f => f.Kind == "B9").Select(f => f.Fields).FirstOrDefault();
            var d1a = (D1aFormFields)this.Forms.Where(f => f.Kind == "D1a").Select(f => f.Fields).FirstOrDefault();

            if (a1 != null && a5d2 != null && b5 != null && b9 != null && d1a != null)
            {
                if (b5.ANX.HasValue)
                {
                    if (b5.ANX == 0)
                    {
                        if (a5d2.ANXIETY.HasValue && a5d2.ANXIETY != 0)
                        {
                            results.Add(new VisitValidationResult(
                                $"if q6a. anx (anxiety) = 0 (no), then form a5d2, q6d. anxiety (anxiety disorder) should not equal 1 (active).",
                                new[] { nameof(b5.ANX), nameof(a5d2.ANXIETY) }));
                        }
                    }
                    else if (b5.ANX == 1)
                    {
                        if (a5d2.ANXIETY.HasValue && a5d2.ANXIETY != 1)
                        {
                            results.Add(new VisitValidationResult(
                                $"B5 if q6a. anx (anxiety) = 1 (yes), then form a5d2, q6d. anxiety (anxiety disorder) should equal 1 (recent/active).",
                                new[] { nameof(b5.ANX), nameof(a5d2.ANXIETY) }));
                        }
                        if (b9.BEANX.HasValue && b9.BEANX != 1)
                        {
                            results.Add(new VisitValidationResult(
                                $"if q6a. anx (anxiety) = 1 (yes), then form b9, q12c. beanx (anxiety) should equal 1 (yes).",
                                new[] { nameof(b5.ANX), nameof(a5d2.ANXIETY) }));
                        }
                        if (d1a.ANXIET.HasValue && d1a.ANXIET != true)
                        {
                            results.Add(new VisitValidationResult(
                                $"if q6a. anx (anxiety) = 1 (yes), then form d1a, q14. anxiet (anxiety disorder (present)) should equal 1 (present).",
                                new[] { nameof(b5.ANX), nameof(a5d2.ANXIETY) }));
                        }
                    }
                }
            }

            return results;
        }
    }
}

