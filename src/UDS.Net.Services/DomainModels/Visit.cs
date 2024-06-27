using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels
{
    /// <summary>
    /// Visit domain model and forms contracts
    /// </summary>
    public class Visit
    {
        public int Id { get; set; }

        public int ParticipationId { get; set; }

        public int VISITNUM { get; set; }

        public string FORMVER { get; set; } = "";

        public PacketKind PACKET { get; set; }

        public DateTime VISIT_DATE { get; set; }

        public string INITIALS { get; set; }

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

        public Participation Participation { get; set; } = new Participation();

        public IList<Form> Forms { get; set; } = new List<Form>();

        private void BuildFormsContract(string version, PacketKind kind, IList<Form> existingForms)
        {
            if (version == "4")
            {
                Dictionary<string, FormContract[]> UDS4 = new Dictionary<string, FormContract[]>
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
                            new FormContract("B9", true), // C2C2T
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
                            new FormContract("B9", true), // C2C2T
                            new FormContract("D1a", true),
                            new FormContract("D1b", true)
                        }
                    }
                };

                var formDefinitions = UDS4.Where(u => u.Key == kind.ToString()).FirstOrDefault();

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

                        Forms.Add(new Form(Id, existing.Id, existing.Title, existing.Kind, existing.Status, existing.FRMDATE, existing.INITIALS, existing.LANG, existing.MODE, existing.RMREAS, existing.RMMODE, existing.NOT, existing.CreatedAt, existing.CreatedBy, existing.ModifiedBy, existing.DeletedBy, existing.IsDeleted, existing.Fields));
                    }
                    else
                    {
                        Forms.Add(new Form(Id, formContract.Abbreviation, formContract.IsRequredForVisitKind, CreatedBy));
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

        public int ErrorCount { get; private set; }

        public int Count { get; private set; }

        public Visit(int id, int number, int participationId, string version, PacketKind packet, DateTime visitDate, string initials, DateTime createdAt, string createdBy, string modifiedBy, string deletedBy, bool isDeleted, IList<Form> existingForms)
        {
            Id = id;
            VISITNUM = number;
            ParticipationId = participationId;
            FORMVER = version;
            PACKET = packet;
            VISIT_DATE = visitDate;
            INITIALS = initials;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            DeletedBy = deletedBy;
            IsDeleted = IsDeleted;

            if (existingForms == null)
                existingForms = new List<Form>();

            BuildFormsContract(FORMVER, PACKET, existingForms);

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

