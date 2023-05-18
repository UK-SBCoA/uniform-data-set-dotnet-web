using System;
namespace UDS.Net.Services.DomainModels
{
    public class Form
    {
        public int VisitId { get; set; }

        public int Id { get; set; }

        public string Version { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsRequiredForVisitKind { get; set; }

        public string Kind { get; set; }

        public string Status { get; set; }

        public string Language { get; set; }

        public bool? IsIncluded { get; set; }

        public string ReasonCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; }

        public IFormFields Fields { get; set; }

        // TODO field versions so comparison can be made between existing data version and version that should be used
        public Form(int visitId, string kind, bool isRequired, string createdBy)
        {
            // TODO This is used in VisitService to initialize a new form when one doesn't exist, but should
            VisitId = visitId;

            Kind = kind;

            IsRequiredForVisitKind = isRequired;

            Status = "NotStarted";

            CreatedBy = createdBy;

            CreatedAt = DateTime.Now;
        }

        public Form(int visitId, int id, string title, string kind, string status, string language, bool? isIncluded, string reasonCode, DateTime createdAt, string createdBy, string modifiedBy, string deletedBy, bool isDeleted, IFormFields fields)
        {
            Id = id;
            Title = title;
            VisitId = visitId;

            Kind = kind;
            Status = status;
            Language = language;
            IsIncluded = isIncluded;
            ReasonCode = reasonCode;

            CreatedAt = createdAt;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            DeletedBy = deletedBy;
            IsDeleted = isDeleted;

            if (fields != null)
            {
                Fields = fields;
                Version = fields.GetVersion();
                Description = fields.GetDescription();
            }
        }

        public Form(int visitId, int id, string title, string kind, bool isRequired, string status, string language, bool? isIncluded, string reasonCode, DateTime createdAt, string createdBy, string modifiedBy, string deletedBy, bool isDeleted, IFormFields fields)
        {
            Id = id;
            Title = title;
            VisitId = visitId;

            Kind = kind;
            IsRequiredForVisitKind = isRequired;
            Status = status;
            Language = language;
            IsIncluded = isIncluded;
            ReasonCode = reasonCode;

            CreatedAt = createdAt;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            DeletedBy = deletedBy;
            IsDeleted = isDeleted;

            if (fields != null)
            {
                Fields = fields;
                Version = fields.GetVersion();
                Description = fields.GetDescription();
            }
        }

    }
}

