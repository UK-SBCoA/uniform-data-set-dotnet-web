using System;
using System.ComponentModel.Design;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels
{
    public class Form
    {
        private string _title = "";
        public int VisitId { get; set; }

        public int Id { get; set; }

        public string Version
        {
            get
            {
                if (Fields != null)
                    return Fields.GetVersion();
                else
                    return "";
            }
        }

        public string Title
        {
            get
            {

                if (Fields != null)
                    return Fields.GetDescription();
                else
                    return _title;
            }
        }

        public string Description
        {
            get
            {
                if (Fields != null)
                    return Fields.GetDescription();
                else
                    return "";
            }
        }

        public bool IsRequiredForVisitKind { get; set; }

        public string Kind { get; set; }

        public FormStatus Status { get; set; }

        public FormLanguage Language { get; set; }

        public bool? IsIncluded { get; private set; } // Is Included is persisted as Status (Not Included)

        public ReasonCode? ReasonCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; }

        public IFormFields Fields { get; set; }

        private void SetFieldsBasedOnKind()
        {
            if (Kind == "A1")
                Fields = new A1FormFields();
            else if (Kind == "A1a")
                Fields = new A1aFormFields();
            else if (Kind == "A2")
                Fields = new A2FormFields();
            else if (Kind == "A3")
                Fields = new A3FormFields();
            else if (Kind == "A4")
                Fields = new A4GFormFields();
            else if (Kind == "A4a")
                Fields = new A4aFormFields();
            else if (Kind == "A5")
                Fields = new A5FormFields();
            else if (Kind == "A5D2")
                Fields = new A5D2FormFields();
            else if (Kind == "B1")
                Fields = new B1FormFields();
            else if (Kind == "B3")
                Fields = new B3FormFields();
            else if (Kind == "B4")
                Fields = new B4FormFields();
            else if (Kind == "B5")
                Fields = new B5FormFields();
            else if (Kind == "B6")
                Fields = new B6FormFields();
            else if (Kind == "B7")
                Fields = new B7FormFields();
            else if (Kind == "B8")
                Fields = new B8FormFields();
            else if (Kind == "B9")
                Fields = new B9FormFields();
            else if (Kind == "C1")
                Fields = new C1FormFields();
            else if (Kind == "C2")
                Fields = new C2FormFields();
            else if (Kind == "D1a")
                Fields = new D1aFormFields();
            else if (Kind == "D1b")
                Fields = new D1bFormFields();
            else if (Kind == "D2")
                Fields = new D2FormFields();
            else if (Kind == "T1")
                Fields = new T1FormFields();
        }

        // TODO field versions so comparison can be made between existing data version and version that should be used
        public Form(int visitId, string kind, bool isRequired, string createdBy)
        {
            VisitId = visitId;

            Kind = kind;

            IsRequiredForVisitKind = isRequired;

            Status = FormStatus.NotStarted;

            CreatedBy = createdBy;

            CreatedAt = DateTime.Now;

            // there is no existing form, but we need to fields initialized for brand new forms
            SetFieldsBasedOnKind();
        }

        public Form(int visitId, int id, string title, string kind, FormStatus status, FormLanguage language, ReasonCode? reasonCode, DateTime createdAt, string createdBy, string modifiedBy, string deletedBy, bool isDeleted, IFormFields fields)
        {
            Id = id;
            VisitId = visitId;

            _title = title;
            Kind = kind;
            Status = status;
            Language = language;
            IsIncluded = !(Status == FormStatus.NotIncluded);
            ReasonCode = reasonCode;

            CreatedAt = createdAt;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            DeletedBy = deletedBy;
            IsDeleted = isDeleted;

            if (fields != null)
            {
                Fields = fields;
            }
        }

        public Form(int visitId, int id, string title, string kind, bool isRequired, FormStatus status, FormLanguage language, ReasonCode? reasonCode, DateTime createdAt, string createdBy, string modifiedBy, string deletedBy, bool isDeleted, IFormFields fields)
        {
            Id = id;
            VisitId = visitId;

            _title = title;
            Kind = kind;
            IsRequiredForVisitKind = isRequired;
            Status = status;
            Language = language;
            IsIncluded = !(Status == FormStatus.NotIncluded);
            ReasonCode = reasonCode;

            CreatedAt = createdAt;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            DeletedBy = deletedBy;
            IsDeleted = isDeleted;

            if (fields != null)
            {
                Fields = fields;
            }
        }

    }
}

