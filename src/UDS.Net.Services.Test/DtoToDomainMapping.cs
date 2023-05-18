
using UDS.Net.Services.DomainModels.Forms;

namespace UDS.Net.Services.Test;

[TestClass]
public class DtoToDomainMapping
{
    private static string TESTSTRING = "Test";
    private static int TESTINT = 1;
    private static string EMAIL = "test@uky.edu";

    [TestMethod]
    public void A1DtoMapsToDomain()
    {
        VisitDto visitDto = new VisitDto
        {
            Id = 1,
            Kind = "IVP",
            CreatedAt = DateTime.Now,
            CreatedBy = EMAIL,
            IsDeleted = false,
            Number = 1,
            StartDateTime = DateTime.Now,
            ParticipationId = 1,
            Version = "UDS3",
            Forms = new List<FormDto>()
            {
                new A1Dto
                {
                    Id = 1,
                    VisitId = 1,
                    Kind = "A1",
                    CreatedAt = DateTime.Now,
                    CreatedBy = EMAIL,
                    IsDeleted = false,
                    Status = "Pending",
                    REASON = TESTINT,
                    REFERSC = TESTINT,
                    LEARNED = TESTINT,
                    PRESTAT = TESTINT,
                    PRESPART = TESTINT,
                    SOURCENW = TESTINT,
                    BIRTHMO = TESTINT,
                    BIRTHYR = TESTINT,
                    SEX = TESTINT,
                    HISPANIC = TESTINT,
                    HISPOR = TESTINT,
                    HISPORX = TESTSTRING,
                    RACE = TESTINT,
                    RACEX = TESTSTRING,
                    RACESEC = TESTINT,
                    RACESECX = TESTSTRING,
                    RACETER = TESTINT,
                    RACETERX = TESTSTRING,
                    PRIMLANG = TESTINT,
                    PRIMLANX = TESTSTRING,
                    EDUC = TESTINT,
                    MARISTAT = TESTINT,
                    LIVSITUA = TESTINT,
                    INDEPEND = TESTINT,
                    RESIDENC = TESTINT,
                    ZIP = TESTSTRING,
                    HANDED = TESTINT
                }
            }
        };

        var visit = visitDto.ToDomain(EMAIL);

        var a1 = visit.Forms.Where(f => f.Kind == "A1").FirstOrDefault();

        Assert.IsTrue(a1.GetType() == typeof(Form));
        Assert.IsTrue(a1.Fields.GetType() == typeof(A1FormFields));

        var fields = (A1FormFields)a1.Fields;
        var dtoFields = visitDto.Forms.Where(f => f.Kind == "A1").FirstOrDefault();

        Assert.IsNotNull(dtoFields);

        var a1DtoFields = (A1Dto)dtoFields;

        Assert.AreEqual(a1DtoFields.REASON, fields.REASON);
        Assert.AreEqual(a1DtoFields.REFERSC, fields.REFERSC);
        Assert.AreEqual(a1DtoFields.LEARNED, fields.LEARNED);
        Assert.AreEqual(a1DtoFields.PRESTAT, fields.PRESTAT);
        Assert.AreEqual(a1DtoFields.PRESPART, fields.PRESPART);
        Assert.AreEqual(a1DtoFields.SOURCENW, fields.SOURCENW);
        Assert.AreEqual(a1DtoFields.BIRTHMO, fields.BIRTHMO);
        Assert.AreEqual(a1DtoFields.BIRTHYR, fields.BIRTHYR);
        Assert.AreEqual(a1DtoFields.SEX, fields.SEX);
        Assert.AreEqual(a1DtoFields.HISPANIC, fields.HISPANIC);
        // TODO finish assertions
    }
}
