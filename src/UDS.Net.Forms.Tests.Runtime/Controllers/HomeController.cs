using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UDS.Net.Forms.Tests.Runtime.Data;
using UDS.Net.Forms.Tests.Runtime.Models;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Tests.Runtime.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IVisitService _visitService;
    private readonly IParticipationService _participationService;

    public HomeController(ILogger<HomeController> logger, IVisitService visitService, IParticipationService participationService)
    {
        _logger = logger;
        _visitService = visitService;
        _participationService = participationService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string legacyId, int? existingVisitId = null, string packetKind = null)
    {
        var participation = await _participationService.GetByLegacyId("username", legacyId);

        if (existingVisitId.HasValue)
        {
            var visit = await _visitService.GetById("username", existingVisitId.Value);

            if (visit == null)
            {
                // create a new one if it doesn't exist yet (new db instance)
                var v = new Visit(existingVisitId.Value, 1, participation.Id, "4", Net.Services.Enums.PacketKind.I, DateTime.Now, User.Identity.Name.Substring(0, 3), Net.Services.Enums.PacketStatus.Pending, DateTime.Now, User.Identity.Name, "", "", false, null);

                visit = await _visitService.Add("username", v);
            }

            return RedirectToPage("/Visits/Details", new { Id = visit.Id });
        }
        else
        {
            // create a new visit
            var visitNumber = await _visitService.GetNextVisitNumber(User.Identity.Name, participation.Id);

            Net.Services.Enums.PacketKind visitPacketKind;

            if (!string.IsNullOrEmpty(packetKind))
            {
                visitPacketKind = packetKind == "F" ? Net.Services.Enums.PacketKind.F : Net.Services.Enums.PacketKind.I;
            }
            else
            {
                visitPacketKind = Net.Services.Enums.PacketKind.I;

                if (visitNumber > 1)
                    visitPacketKind = Net.Services.Enums.PacketKind.F;
            }

            var v = new Visit( 0, visitNumber, participation.Id, "4", visitPacketKind, DateTime.Now, User.Identity.Name.Substring(0, 3), Net.Services.Enums.PacketStatus.Pending, DateTime.Now, User.Identity.Name, "", "", false, null);

            var visit = await _visitService.Add("username", v);

            return RedirectToPage("/Visits/Details", new { Id = visit.Id });
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

