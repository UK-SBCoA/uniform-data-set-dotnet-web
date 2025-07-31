using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> Index(string legacyId)
    {
        var participation = await _participationService.GetByLegacyId("username", legacyId);

        var visit = new Visit(1, 1, participation.Id, "4", Net.Services.Enums.PacketKind.I, DateTime.Now, "TST", Net.Services.Enums.PacketStatus.Pending, DateTime.Now, "email@uky.edu", "", "", false, null);

        var created = await _visitService.Add("username", visit);

        return RedirectToPage("/Visits/Details", new { Id = created.Id });
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

