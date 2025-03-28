using System;
namespace UDS.Net.Services
{
    public class VisitValidationResult
    {
        public string[] MemberNames { get; set; }
        public string ErrorMessage { get; set; }

        public VisitValidationResult(string errorMessage, string[] memberNames)
        {
            this.ErrorMessage = errorMessage;
            this.MemberNames = memberNames;
        }

    }
}

