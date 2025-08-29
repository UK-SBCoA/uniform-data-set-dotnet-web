using System;
using System.Collections.Generic;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.DomainModels.Submission
{
    public class Packet : Visit
    {
        protected readonly List<PacketSubmission> _submissions = new List<PacketSubmission>();

        public List<PacketSubmission> Submissions => _submissions;// new List<PacketSubmission>();

        private int? _totalUnresolvedErrorsCount = null;
        public int? TotalUnresolvedErrorCount
        {
            get
            {
                if (_totalUnresolvedErrorsCount.HasValue)
                    return _totalUnresolvedErrorsCount;
                else if (this._submissions != null)
                {
                    int unresolvedCount = 0;
                    foreach (var submisson in this._submissions)
                    {
                        foreach (var error in submisson.Errors)
                            if (String.IsNullOrWhiteSpace(error.ResolvedBy))
                                unresolvedCount++;
                    }
                    return unresolvedCount;
                }
                return 0;
            }
            set
            {
                _totalUnresolvedErrorsCount = value;
            }
        }

        public IEnumerable<PacketSubmissionError> UnresolvedErrors
        {
            get
            {
                if (_submissions == null)
                    return new List<PacketSubmissionError>();

                var unresolvedErrors = new List<PacketSubmissionError>();

                foreach (var submission in _submissions)
                {
                    if (submission.Errors == null)
                        continue;

                    foreach (var error in submission.Errors)
                    {
                        if (string.IsNullOrWhiteSpace(error.ResolvedBy))
                            unresolvedErrors.Add(error);
                    }
                }

                return unresolvedErrors;
            }
        }

        public void AddSubmission(PacketSubmission submission)
        {
            _submissions.Add(submission);

            // when a submission is added, the overall packet state needs to be changed as well
            if (TryUpdateStatus(PacketStatus.Submitted))
                UpdateStatus(PacketStatus.Submitted);
        }

        public void ResolveError(PacketSubmissionError resolvedError)
        {
            int errorCount = 0;
            int resolvedErrorCount = 0;

            foreach (var submission in _submissions)
            {
                foreach (var error in submission.Errors)
                {
                    errorCount += 1;

                    if (error.Id == resolvedError.Id)
                    {
                        error.Resolve(resolvedError.ResolvedBy, resolvedError.ModifiedBy);
                    }

                    if (!String.IsNullOrWhiteSpace(error.ResolvedBy))
                        resolvedErrorCount += 1;
                }
            }

            // after all errors are resolved, state can be moved back to pending and finalization attempted again
            if (errorCount == resolvedErrorCount)
            {
                if (TryUpdateStatus(PacketStatus.Pending))
                    UpdateStatus(PacketStatus.Pending);
            }
        }

        public Packet(int id, int number, int participationId, string version, PacketKind packet, DateTime visitDate, string initials, PacketStatus status, DateTime createdAt, string createdBy, string modifiedBy, string deletedBy, bool isDeleted, IList<Form> existingForms, IList<PacketSubmission> packetSubmissions) : base(id, number, participationId, version, packet, visitDate, initials, status, createdAt, createdBy, modifiedBy, deletedBy, isDeleted, existingForms)
        {
            if (packetSubmissions != null)
            {
                foreach (var submission in packetSubmissions)
                {
                    _submissions.Add(submission); // when initializing, we just want to load and not affect packet state
                }
            }
        }

    }
}

