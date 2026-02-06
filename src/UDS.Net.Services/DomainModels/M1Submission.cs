using System;
using System.Collections.Generic;
using System.Linq;

namespace UDS.Net.Services.DomainModels.Submission
{
    public class M1Submission
    {
        public int Id { get; set; }

        public string ADRCId { get; set; }

        public DateTime SubmissionDate { get; set; }

        public int M1Id { get; set; }

        public IList<Form> Forms { get; set; } = new List<Form>();

        public int? ErrorCount { get; set; } // If null, no response was received from submission

        public List<M1SubmissionError> Errors { get; set; } = new List<M1SubmissionError>();

        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public string DeletedBy { get; set; }

        public bool IsDeleted { get; set; }

        public M1Submission(
            int id,
            string adrcId,
            DateTime submissionDate,
            int m1Id,
            DateTime createdAt,
            string createdBy,
            string modifiedBy,
            string deletedBy,
            bool isDeleted,
            int? errorCount)
        {
            Id = id;
            ADRCId = adrcId;
            SubmissionDate = submissionDate;
            M1Id = m1Id;
            CreatedAt = createdAt;
            CreatedBy = createdBy;
            ModifiedBy = modifiedBy;
            DeletedBy = deletedBy;
            IsDeleted = isDeleted;
            ErrorCount = errorCount;
        }

        public M1Submission(
            int id,
            string adrcId,
            DateTime submissionDate,
            int m1Id,
            DateTime createdAt,
            string createdBy,
            string modifiedBy,
            string deletedBy,
            bool isDeleted,
            int? errorCount,
            IList<Form> forms,
            IList<M1SubmissionError> errors)
            : this(id, adrcId, submissionDate, m1Id, createdAt, createdBy, modifiedBy, deletedBy, isDeleted, errorCount)
        {
            Forms = forms ?? new List<Form>();
            //Errors = errors?.ToList() ?? new List<M1SubmissionError>();
        }


        //public M1Submission(
        //    int id,
        //    string adrcId,
        //    DateTime submissionDate,
        //    int packetId,
        //    DateTime createdAt,
        //    string createdBy,
        //    string modifiedBy,
        //    string deletedBy,
        //    bool isDeleted,
        //    int? errorCount,
        //    IList<M1SubmissionError> errors)
        //    : this(id, adrcId, submissionDate, packetId, createdAt, createdBy, modifiedBy, deletedBy, isDeleted, errorCount)
        //{
        //    Errors = errors?.ToList() ?? new List<M1SubmissionError>();
        //}

        //public M1Submission(
        //    int id,
        //    string adrcId,
        //    DateTime submissionDate,
        //    int packetId,
        //    DateTime createdAt,
        //    string createdBy,
        //    string modifiedBy,
        //    string deletedBy,
        //    bool isDeleted,
        //    int? errorCount,
        //    IList<Form> forms,
        //    IList<M1SubmissionError> errors)
        //    : this(id, adrcId, submissionDate, packetId, createdAt, createdBy, modifiedBy, deletedBy, isDeleted, errorCount)
        //{
        //    Forms = forms ?? new List<Form>();
        //    Errors = errors?.ToList() ?? new List<M1SubmissionError>();
        //}
    }
}
