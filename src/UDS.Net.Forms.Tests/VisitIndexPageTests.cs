using UDS.Net.Forms.Pages.Visits;
using UDS.Net.Forms.Tests.Services;
using UDS.Net.Services;

namespace UDS.Net.Forms.Tests;

public class VisitIndexPageTests
{
    [Fact]
    public async void OnGetAsync_PopulatesThePageModel_WithAListOfVisits()
    { 
        IVisitService visitService = new VisitService();

        var expectedVisits = VisitService.GetSeedingVisits();

        var pageModel = new IndexModel(visitService);

        await pageModel.OnGetAsync();

        var actualVisits = pageModel.Visits;

        Assert.Equal(
            expectedVisits.OrderBy(v => v.Id).Select(v => v.Id),
            actualVisits.OrderBy(v => v.Id).Select(v => v.Id));
    }
}
