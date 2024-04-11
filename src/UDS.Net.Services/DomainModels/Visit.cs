using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels
{
    /// <summary>
    /// Visit domain model
    /// </summary>
    public class Visit
    {
        public int Id { get; set; }

        public int ParticipationId { get; set; }

        public int Number { get; set; }

        public string Version { get; set; } = "";

        public VisitKind Kind { get; set; }

        public DateTime StartDateTime { get; set; }

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

        private void BuildFormsContract(string version, VisitKind kind, IList<Form> existingForms)
        {
            if (version == "UDS4")
            {
                Dictionary<string, FormContract[]> UDS4 = new Dictionary<string, FormContract[]>
                {
                    {
                        VisitKind.IVP.ToString(),
                        new FormContract[]
                        {
                            new FormContract("A1", true),
                            new FormContract("A1a", false),
                            new FormContract("A2", true),
                            new FormContract("A3", false),
                            new FormContract("A4", true),
                            new FormContract("B1",true),
                            new FormContract("B3", true),
                            new FormContract("B4", true),
                            new FormContract("B5", false),
                            new FormContract("B6", false),
                            new FormContract("B7", false),
                            new FormContract("D1a", true)
                        }
                    },
                    {
                        VisitKind.FVP.ToString(),
                        new FormContract[]
                        {
                            new FormContract("A1", true),
                            new FormContract("A2", true),
                            new FormContract("A3", false),
                            new FormContract("A4", true),
                            new FormContract("B4", true),
                            new FormContract("B5", false),
                            new FormContract("B6", false),
                            new FormContract("B7", false),
                            new FormContract("D1a", true)
                        }
                    },
                    {
                        VisitKind.TIP.ToString(),
                        new FormContract[]
                        {
                            new FormContract("A1", true),
                            new FormContract("A1a", false),
                            new FormContract("A2", true),
                            new FormContract("A3", false),
                            new FormContract("A4", true),
                            new FormContract("B4", true),
                            new FormContract("B5", false),
                            new FormContract("B6", false),
                            new FormContract("B7", false),
                            new FormContract("D1a", true)
                        }
                    },
                    {
                        VisitKind.TFP.ToString(),
                        new FormContract[]
                        {
                            new FormContract("A1", true),
                            new FormContract("A2", true),
                            new FormContract("A3", false),
                            new FormContract("A4", true),
                            new FormContract("B4", true),
                            new FormContract("B5", false),
                            new FormContract("B6", false),
                            new FormContract("B7", false),
                            new FormContract("D1a", true)
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

                        Forms.Add(new Form(Id, existing.Id, existing.Title, existing.Kind, formContract.IsRequredForVisitKind, existing.Status, existing.Language, existing.ReasonCode, existing.CreatedAt, existing.CreatedBy, existing.ModifiedBy, existing.DeletedBy, existing.IsDeleted, existing.Fields));
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

        public Visit(int id, int number, int participationId, string version, VisitKind kind, DateTime startDateTime, DateTime createdAt, string createdBy, string modifiedBy, string deletedBy, bool isDeleted, IList<Form> existingForms)
        {
            Id = id;
            Number = number;
            ParticipationId = participationId;
            Version = version;
            Kind = kind;
            StartDateTime = startDateTime;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            DeletedBy = deletedBy;
            IsDeleted = IsDeleted;

            if (existingForms == null)
                existingForms = new List<Form>();

            BuildFormsContract(Version, Kind, existingForms);

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
            /// TODO For UDS3 FVP, either C1 or C2 is required, but not both
            yield break;
        }
    }
}

