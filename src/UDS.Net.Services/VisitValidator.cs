using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDS.Net.API.Entities;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services
{
    public interface IVisitValidator
    {
        Task<List<VisitValidationResult>> ValidateAsync(Visit visit);
    }

    public class VisitValidator : IVisitValidator
    {
        private readonly ILookupService _lookupService;

        public VisitValidator(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }

        public async Task<List<VisitValidationResult>> ValidateAsync(Visit visit)
        {
            var errors = visit.GetModelErrors().ToList();

            if (visit.PACKET != PacketKind.F)
            {
                var a1 = visit.GetFormFields<A1FormFields>("A1");

                if (a1 != null)
                {
                    int? priocc = a1.PRIOCC;

                    if (priocc.HasValue)
                    {
                        var occupations = await _lookupService.GetAllOccupations();

                        var isValid = occupations.Any(o => o.Code == priocc.ToString());

                        if (!isValid)
                        {
                            errors.Add(new VisitValidationResult(
                                "PRIOCC must match a valid occupation code.",
                                new[] { "PRIOCC" }
                            ));
                        }
                    }
                }
            }

            return errors;
        }
    }
}
