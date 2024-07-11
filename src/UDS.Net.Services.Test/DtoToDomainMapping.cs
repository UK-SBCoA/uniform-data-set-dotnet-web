
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.Enums;

namespace UDS.Net.Services.Test;

[TestClass]
public class DtoToDomainMapping
{
    private static string TESTSTRING = "Test";
    private static int TESTINT = 1;
    private static double TESTDOUBLE = 1.0;
    private static string EMAIL = "test@uky.edu";

    //[TestMethod]
    //public void A1DtoMapsToDomain()
    //{
    //    VisitDto visitDto = new VisitDto
    //    {
    //        Id = 1,
    //        Kind = "IVP",
    //        CreatedAt = DateTime.Now,
    //        CreatedBy = EMAIL,
    //        IsDeleted = false,
    //        Number = 1,
    //        StartDateTime = DateTime.Now,
    //        ParticipationId = 1,
    //        Version = "UDS3",
    //        Forms = new List<FormDto>()
    //        {
    //            new A1Dto
    //            {
    //                Id = 1,
    //                VisitId = 1,
    //                Kind = "A1",
    //                CreatedAt = DateTime.Now,
    //                CreatedBy = EMAIL,
    //                IsDeleted = false,
    //                Status = "Pending",
    //                REASON = TESTINT,
    //                REFERSC = TESTINT,
    //                LEARNED = TESTINT,
    //                PRESTAT = TESTINT,
    //                PRESPART = TESTINT,
    //                SOURCENW = TESTINT,
    //                BIRTHMO = TESTINT,
    //                BIRTHYR = TESTINT,
    //                SEX = TESTINT,
    //                HISPANIC = TESTINT,
    //                HISPOR = TESTINT,
    //                HISPORX = TESTSTRING,
    //                RACE = TESTINT,
    //                RACEX = TESTSTRING,
    //                RACESEC = TESTINT,
    //                RACESECX = TESTSTRING,
    //                RACETER = TESTINT,
    //                RACETERX = TESTSTRING,
    //                PRIMLANG = TESTINT,
    //                PRIMLANX = TESTSTRING,
    //                EDUC = TESTINT,
    //                MARISTAT = TESTINT,
    //                LIVSITUA = TESTINT,
    //                INDEPEND = TESTINT,
    //                RESIDENC = TESTINT,
    //                ZIP = TESTSTRING,
    //                HANDED = TESTINT
    //            }
    //        }
    //    };

    //    var visit = visitDto.ToDomain(EMAIL);

    //    var a1 = visit.Forms.Where(f => f.Kind == "A1").FirstOrDefault();

    //    Assert.IsTrue(a1.GetType() == typeof(Form));
    //    Assert.IsTrue(a1.Fields.GetType() == typeof(A1FormFields));

    //    var fields = (A1FormFields)a1.Fields;
    //    var dtoFields = visitDto.Forms.Where(f => f.Kind == "A1").FirstOrDefault();

    //    Assert.IsNotNull(dtoFields);

    //    var a1DtoFields = (A1Dto)dtoFields;

    //    Assert.AreEqual(a1DtoFields.REASON, fields.REASON);
    //    Assert.AreEqual(a1DtoFields.REFERSC, fields.REFERSC);
    //    Assert.AreEqual(a1DtoFields.LEARNED, fields.LEARNED);
    //    Assert.AreEqual(a1DtoFields.PRESTAT, fields.PRESTAT);
    //    Assert.AreEqual(a1DtoFields.PRESPART, fields.PRESPART);
    //    Assert.AreEqual(a1DtoFields.SOURCENW, fields.SOURCENW);
    //    Assert.AreEqual(a1DtoFields.BIRTHMO, fields.BIRTHMO);
    //    Assert.AreEqual(a1DtoFields.BIRTHYR, fields.BIRTHYR);
    //    Assert.AreEqual(a1DtoFields.SEX, fields.SEX);
    //    Assert.AreEqual(a1DtoFields.HISPANIC, fields.HISPANIC);
    //    Assert.AreEqual(a1DtoFields.HISPOR, fields.HISPOR);
    //    Assert.AreEqual(a1DtoFields.HISPORX, fields.HISPORX);
    //    Assert.AreEqual(a1DtoFields.RACE, fields.RACE);
    //    Assert.AreEqual(a1DtoFields.RACEX, fields.RACEX);
    //    Assert.AreEqual(a1DtoFields.RACESEC, fields.RACESEC);
    //    Assert.AreEqual(a1DtoFields.RACESECX, fields.RACESECX);
    //    Assert.AreEqual(a1DtoFields.RACETER, fields.RACETER);
    //    Assert.AreEqual(a1DtoFields.RACETERX, fields.RACETERX);
    //    Assert.AreEqual(a1DtoFields.PRIMLANG, fields.PRIMLANG);
    //    Assert.AreEqual(a1DtoFields.PRIMLANX, fields.PRIMLANX);
    //    Assert.AreEqual(a1DtoFields.EDUC, fields.EDUC);
    //    Assert.AreEqual(a1DtoFields.MARISTAT, fields.MARISTAT);
    //    Assert.AreEqual(a1DtoFields.LIVSITUA, fields.LIVSITUA);
    //    Assert.AreEqual(a1DtoFields.INDEPEND, fields.INDEPEND);
    //    Assert.AreEqual(a1DtoFields.RESIDENC, fields.RESIDENC);
    //    Assert.AreEqual(a1DtoFields.ZIP, fields.ZIP);
    //    Assert.AreEqual(a1DtoFields.HANDED, fields.HANDED);
    //}

    [TestMethod]
    public void A2DtoMapsToDomain()
    {
        VisitDto visitDto = new VisitDto
        {
            Id = 1,
            PACKET = PacketKind.I.ToString(),
            CreatedAt = DateTime.Now,
            CreatedBy = EMAIL,
            IsDeleted = false,
            VISITNUM = 1,
            VISIT_DATE = DateTime.Now,
            ParticipationId = 1,
            FORMVER = "4",
            INITIALS = "TST",
            Forms = new List<FormDto>()
            {
                new A2Dto
                {
                    Id = 1,
                    VisitId = 1,
                    Kind = "A2",
                    CreatedAt = DateTime.Now,
                    CreatedBy = EMAIL,
                    IsDeleted = false,
                    Status = "Pending",
                    NEWINF = TESTINT,
                    INRELTO = TESTINT,
                    INKNOWN = TESTINT,
                    INLIVWTH = TESTINT,
                    INCNTMOD = TESTINT,
                    INCNTMDX = TESTSTRING,
                    INCNTFRQ = TESTINT,
                    INCNTTIM = TESTINT,
                    INRELY = TESTINT,
                    INMEMWORS = TESTINT,
                    INMEMTROUB = TESTINT,
                    INMEMTEN = TESTINT,
                }
            }
        };

        var visit = visitDto.ToDomain(EMAIL);

        var a2 = visit.Forms.Where(f => f.Kind == "A2").FirstOrDefault();

        Assert.IsTrue(a2.GetType() == typeof(Form));
        Assert.IsTrue(a2.Fields.GetType() == typeof(A2FormFields));

        var fields = (A2FormFields)a2.Fields;
        var dtoFields = visitDto.Forms.Where(f => f.Kind == "A2").FirstOrDefault();

        Assert.IsNotNull(dtoFields);

        var a2DtoFields = (A2Dto)dtoFields;

        Assert.AreEqual(a2DtoFields.NEWINF, fields.NEWINF);
        Assert.AreEqual(a2DtoFields.INRELTO, fields.INRELTO);
        Assert.AreEqual(a2DtoFields.INKNOWN, fields.INKNOWN);
        Assert.AreEqual(a2DtoFields.INLIVWTH, fields.INLIVWTH);
        Assert.AreEqual(a2DtoFields.INCNTMOD, fields.INCNTMOD);
        Assert.AreEqual(a2DtoFields.INCNTMDX, fields.INCNTMDX);
        Assert.AreEqual(a2DtoFields.INCNTFRQ, fields.INCNTFRQ);
        Assert.AreEqual(a2DtoFields.INCNTTIM, fields.INCNTTIM);
        Assert.AreEqual(a2DtoFields.INRELY, fields.INRELY);
        Assert.AreEqual(a2DtoFields.INMEMWORS, fields.INMEMWORS);
        Assert.AreEqual(a2DtoFields.INMEMTROUB, fields.INMEMTROUB);
        Assert.AreEqual(a2DtoFields.INMEMTEN, fields.INMEMTEN);
    }

    //[TestMethod]
    //public void A3DtoMapsToDomain()
    //{
    //    VisitDto visitDto = new VisitDto
    //    {
    //        Id = 1,
    //        Kind = "IVP",
    //        CreatedAt = DateTime.Now,
    //        CreatedBy = EMAIL,
    //        IsDeleted = false,
    //        Number = 1,
    //        StartDateTime = DateTime.Now,
    //        ParticipationId = 1,
    //        Version = "UDS3",
    //        Forms = new List<FormDto>()
    //        {
    //            new A3Dto
    //            {
    //                Id = 1,
    //                VisitId = 1,
    //                Kind = "A3",
    //                CreatedAt = DateTime.Now,
    //                CreatedBy = EMAIL,
    //                IsDeleted = false,
    //                Status = "Pending",
    //                AFFFAMM = TESTINT,
    //                NWINFMUT = TESTINT,
    //                FADMUT = TESTINT,
    //                FADMUTX = TESTSTRING,
    //                FADMUSO = TESTINT,
    //                FADMUSOX = TESTSTRING,
    //                FFTDMUT = TESTINT,
    //                FFTDMUTX = TESTSTRING,
    //                FFTDMUSO = TESTINT,
    //                FFTDMUSX = TESTSTRING,
    //                FOTHMUT = TESTINT,
    //                FOTHMUTX = TESTSTRING,
    //                FOTHMUSO = TESTINT,
    //                FOTHMUSX = TESTSTRING,
    //                MOMMOB = TESTINT,
    //                MOMYOB = TESTINT,
    //                MOMDAGE = TESTINT,
    //                MOMNEUR = TESTINT,
    //                MOMPRDX = TESTINT,
    //                MOMMOE = TESTINT,
    //                MOMAGEO = TESTINT,
    //                DADMOB = TESTINT,
    //                DADDAGE = TESTINT,
    //                DADNEUR = TESTINT,
    //                DADPRDX = TESTINT,
    //                DADMOE = TESTINT,
    //                DADAGEO = TESTINT
    //                // TODO test sibling and children mappings
    //            }
    //        }
    //    };

    //    var visit = visitDto.ToDomain(EMAIL);

    //    var a3 = visit.Forms.Where(f => f.Kind == "A3").FirstOrDefault();

    //    Assert.IsTrue(a3.GetType() == typeof(Form));
    //    Assert.IsTrue(a3.Fields.GetType() == typeof(A3FormFields));

    //    var fields = (A3FormFields)a3.Fields;
    //    var dtoFields = visitDto.Forms.Where(f => f.Kind == "A3").FirstOrDefault();

    //    Assert.IsNotNull(dtoFields);

    //    var a3DtoFields = (A3Dto)dtoFields;

    //    foreach (var property in typeof(A3FormFields).GetProperties())
    //    {
    //        // property names are the same in each object
    //        // so we can iterate through reflection
    //        var domainPropertyValue = fields.GetType().GetProperty(property.Name).GetValue(fields, null);

    //        // Make sure the test was set to a value
    //        Assert.IsNotNull(domainPropertyValue);

    //        var dtoProperty = a3DtoFields.GetType().GetProperty(property.Name);
    //        if (dtoProperty != null)
    //        {
    //            var dtoPropertyValue = dtoProperty.GetValue(a3DtoFields, null);
    //            Assert.AreEqual(dtoPropertyValue, domainPropertyValue);
    //        }


    //    }
    //}

    //[TestMethod]
    //public void A4DtoMapsToDomain()
    //{
    //    VisitDto visitDto = new VisitDto
    //    {
    //        Id = 1,
    //        Kind = "IVP",
    //        CreatedAt = DateTime.Now,
    //        CreatedBy = EMAIL,
    //        IsDeleted = false,
    //        Number = 1,
    //        StartDateTime = DateTime.Now,
    //        ParticipationId = 1,
    //        Version = "UDS3",
    //        Forms = new List<FormDto>()
    //        {
    //            new A4GDto
    //            {
    //                Id = 1,
    //                VisitId = 1,
    //                Kind = "A4",
    //                CreatedAt = DateTime.Now,
    //                CreatedBy = EMAIL,
    //                IsDeleted = false,
    //                Status = "Pending",
    //                ANYMEDS = TESTINT,
    //                A4Dtos = new List<A4DDto>()
    //                {
    //                    new A4DDto
    //                    {
    //                        Id = 1,
    //                        VisitId = 1,
    //                        Kind = "A4",
    //                        CreatedAt = DateTime.Now,
    //                        CreatedBy = EMAIL,
    //                        IsDeleted = false,
    //                        Status = "Pending",
    //                        DRUGID = TESTSTRING
    //                    }
    //                }
    //            }
    //        }
    //    };

    //    var visit = visitDto.ToDomain(EMAIL);

    //    var a4 = visit.Forms.Where(f => f.Kind == "A4").FirstOrDefault();

    //    Assert.IsTrue(a4.GetType() == typeof(Form));
    //    Assert.IsTrue(a4.Fields.GetType() == typeof(A4GFormFields));

    //    var fields = (A4GFormFields)a4.Fields;
    //    var dtoFields = visitDto.Forms.Where(f => f.Kind == "A4").FirstOrDefault();

    //    Assert.IsNotNull(dtoFields);

    //    var a4DtoFields = (A4GDto)dtoFields;

    //    Assert.AreEqual(a4DtoFields.ANYMEDS, fields.ANYMEDS);
    //    Assert.AreEqual(a4DtoFields.A4Dtos.FirstOrDefault().DRUGID, fields.A4Ds.FirstOrDefault().DRUGID);
    //}



    //[TestMethod]
    //public void B1DtoMapsToDomain()
    //{
    //    VisitDto visitDto = new VisitDto
    //    {
    //        Id = 1,
    //        Kind = "IVP",
    //        CreatedAt = DateTime.Now,
    //        CreatedBy = EMAIL,
    //        IsDeleted = false,
    //        Number = 1,
    //        StartDateTime = DateTime.Now,
    //        ParticipationId = 1,
    //        Version = "UDS3",
    //        Forms = new List<FormDto>()
    //        {
    //            new B1Dto
    //            {
    //                Id = 1,
    //                VisitId = 1,
    //                Kind = "B1",
    //                CreatedAt = DateTime.Now,
    //                CreatedBy = EMAIL,
    //                IsDeleted = false,
    //                Status = "Pending",
    //                HEIGHT = TESTDOUBLE,
    //                WEIGHT = TESTINT,
    //                BPSYS = TESTINT,
    //                BPDIAS = TESTINT,
    //                HRATE = TESTINT,
    //                VISION = TESTINT,
    //                VISCORR = TESTINT,
    //                VISWCORR = TESTINT,
    //                HEARING = TESTINT,
    //                HEARAID = TESTINT,
    //                HEARWAID = TESTINT
    //            }
    //        }
    //    };

    //    var visit = visitDto.ToDomain(EMAIL);

    //    var b1 = visit.Forms.Where(f => f.Kind == "B1").FirstOrDefault();

    //    Assert.IsTrue(b1.GetType() == typeof(Form));
    //    Assert.IsTrue(b1.Fields.GetType() == typeof(B1FormFields));

    //    var fields = (B1FormFields)b1.Fields;
    //    var dtoFields = visitDto.Forms.Where(f => f.Kind == "B1").FirstOrDefault();

    //    Assert.IsNotNull(dtoFields);

    //    var b1DtoFields = (B1Dto)dtoFields;

    //    Assert.AreEqual(b1DtoFields.HEIGHT, fields.HEIGHT);
    //    Assert.AreEqual(b1DtoFields.WEIGHT, fields.WEIGHT);
    //    Assert.AreEqual(b1DtoFields.BPSYS, fields.BPSYS);
    //    Assert.AreEqual(b1DtoFields.BPDIAS, fields.BPDIAS);
    //    Assert.AreEqual(b1DtoFields.HRATE, fields.HRATE);
    //    Assert.AreEqual(b1DtoFields.VISION, fields.VISION);
    //    Assert.AreEqual(b1DtoFields.VISCORR, fields.VISCORR);
    //    Assert.AreEqual(b1DtoFields.VISWCORR, fields.VISWCORR);
    //    Assert.AreEqual(b1DtoFields.HEARING, fields.HEARING);
    //    Assert.AreEqual(b1DtoFields.HEARAID, fields.HEARAID);
    //    Assert.AreEqual(b1DtoFields.HEARWAID, fields.HEARWAID);
    //}

    [TestMethod]
    public void B4DtoMapsToDomain()
    {
        VisitDto visitDto = new VisitDto
        {
            Id = 1,
            PACKET = PacketKind.I.ToString(),
            CreatedAt = DateTime.Now,
            CreatedBy = EMAIL,
            IsDeleted = false,
            VISITNUM = 1,
            VISIT_DATE = DateTime.Now,
            ParticipationId = 1,
            FORMVER = "4",
            INITIALS = "TST",
            Forms = new List<FormDto>()
            {
                new B4Dto
                {
                    Id = 1,
                    VisitId = 1,
                    Kind = "B4",
                    CreatedAt = DateTime.Now,
                    CreatedBy = EMAIL,
                    IsDeleted = false,
                    Status = "Pending",
                    MEMORY = TESTDOUBLE,
                    ORIENT = TESTDOUBLE,
                    JUDGMENT = TESTDOUBLE,
                    COMMUN = TESTDOUBLE,
                    HOMEHOBB = TESTDOUBLE,
                    PERSCARE = TESTDOUBLE,
                    CDRSUM = TESTDOUBLE,
                    CDRGLOB = TESTDOUBLE,
                    COMPORT = TESTDOUBLE,
                    CDRLANG = TESTDOUBLE
                }
            }
        };

        var visit = visitDto.ToDomain(EMAIL);

        var b4 = visit.Forms.Where(f => f.Kind == "B4").FirstOrDefault();

        Assert.IsTrue(b4.GetType() == typeof(Form));
        Assert.IsTrue(b4.Fields.GetType() == typeof(B4FormFields));

        var fields = (B4FormFields)b4.Fields;
        var dtoFields = visitDto.Forms.Where(f => f.Kind == "B4").FirstOrDefault();

        Assert.IsNotNull(dtoFields);

        var b4DtoFields = (B4Dto)dtoFields;

        Assert.AreEqual(b4DtoFields.MEMORY, fields.MEMORY);
        Assert.AreEqual(b4DtoFields.ORIENT, fields.ORIENT);
        Assert.AreEqual(b4DtoFields.JUDGMENT, fields.JUDGMENT);
        Assert.AreEqual(b4DtoFields.COMMUN, fields.COMMUN);
        Assert.AreEqual(b4DtoFields.HOMEHOBB, fields.HOMEHOBB);
        Assert.AreEqual(b4DtoFields.PERSCARE, fields.PERSCARE);
        Assert.AreEqual(b4DtoFields.CDRSUM, fields.CDRSUM);
        Assert.AreEqual(b4DtoFields.CDRGLOB, fields.CDRGLOB);
        Assert.AreEqual(b4DtoFields.COMPORT, fields.COMPORT);
        Assert.AreEqual(b4DtoFields.CDRLANG, fields.CDRLANG);
    }

    [TestMethod]
    public void B5DtoMapsToDomain()
    {
        VisitDto visitDto = new VisitDto
        {
            Id = 1,
            PACKET = PacketKind.I.ToString(),
            CreatedAt = DateTime.Now,
            CreatedBy = EMAIL,
            IsDeleted = false,
            VISITNUM = 1,
            VISIT_DATE = DateTime.Now,
            ParticipationId = 1,
            FORMVER = "4",
            INITIALS = "TST",
            Forms = new List<FormDto>()
            {
                new B5Dto
                {
                    Id = 1,
                    VisitId = 1,
                    Kind = "B5",
                    CreatedAt = DateTime.Now,
                    CreatedBy = EMAIL,
                    IsDeleted = false,
                    Status = "Pending",
                    NPIQINF = TESTINT,
                    NPIQINFX = TESTSTRING,
                    DEL = TESTINT,
                    DELSEV = TESTINT,
                    HALL = TESTINT,
                    HALLSEV = TESTINT,
                    AGIT = TESTINT,
                    AGITSEV = TESTINT,
                    DEPD = TESTINT,
                    DEPDSEV = TESTINT,
                    ANX = TESTINT,
                    ANXSEV = TESTINT,
                    ELAT = TESTINT,
                    ELATSEV = TESTINT,
                    APA = TESTINT,
                    APASEV = TESTINT,
                    DISN = TESTINT,
                    DISNSEV = TESTINT,
                    IRR = TESTINT,
                    IRRSEV = TESTINT,
                    MOT = TESTINT,
                    MOTSEV = TESTINT,
                    NITE = TESTINT,
                    NITESEV = TESTINT,
                    APP = TESTINT,
                    APPSEV = TESTINT
                }
            }
        };

        var visit = visitDto.ToDomain(EMAIL);

        var b5 = visit.Forms.Where(f => f.Kind == "B5").FirstOrDefault();

        Assert.IsTrue(b5.GetType() == typeof(Form));
        Assert.IsTrue(b5.Fields.GetType() == typeof(B5FormFields));

        var fields = (B5FormFields)b5.Fields;
        var dtoFields = visitDto.Forms.Where(f => f.Kind == "B5").FirstOrDefault();

        Assert.IsNotNull(dtoFields);

        var b5DtoFields = (B5Dto)dtoFields;

        Assert.AreEqual(b5DtoFields.NPIQINF, fields.NPIQINF);
        Assert.AreEqual(b5DtoFields.NPIQINFX, fields.NPIQINFX);
        Assert.AreEqual(b5DtoFields.DEL, fields.DEL);
        Assert.AreEqual(b5DtoFields.DELSEV, fields.DELSEV);
        Assert.AreEqual(b5DtoFields.HALL, fields.HALL);
        Assert.AreEqual(b5DtoFields.HALLSEV, fields.HALLSEV);
        Assert.AreEqual(b5DtoFields.AGIT, fields.AGIT);
        Assert.AreEqual(b5DtoFields.AGITSEV, fields.AGITSEV);
        Assert.AreEqual(b5DtoFields.DEPD, fields.DEPD);
        Assert.AreEqual(b5DtoFields.DEPDSEV, fields.DEPDSEV);
        Assert.AreEqual(b5DtoFields.ANX, fields.ANX);
        Assert.AreEqual(b5DtoFields.ANXSEV, fields.ANXSEV);
        Assert.AreEqual(b5DtoFields.ELAT, fields.ELAT);
        Assert.AreEqual(b5DtoFields.ELATSEV, fields.ELATSEV);
        Assert.AreEqual(b5DtoFields.APA, fields.APA);
        Assert.AreEqual(b5DtoFields.APASEV, fields.APASEV);
        Assert.AreEqual(b5DtoFields.DISN, fields.DISN);
        Assert.AreEqual(b5DtoFields.DISNSEV, fields.DISNSEV);
        Assert.AreEqual(b5DtoFields.IRR, fields.IRR);
        Assert.AreEqual(b5DtoFields.IRRSEV, fields.IRRSEV);
        Assert.AreEqual(b5DtoFields.MOT, fields.MOT);
        Assert.AreEqual(b5DtoFields.MOTSEV, fields.MOTSEV);
        Assert.AreEqual(b5DtoFields.NITE, fields.NITE);
        Assert.AreEqual(b5DtoFields.NITESEV, fields.NITESEV);
        Assert.AreEqual(b5DtoFields.APP, fields.APP);
        Assert.AreEqual(b5DtoFields.APPSEV, fields.APPSEV);
    }

    [TestMethod]
    public void B6DtoMapsToDomain()
    {
        VisitDto visitDto = new VisitDto
        {
            Id = 1,
            PACKET = PacketKind.I.ToString(),
            CreatedAt = DateTime.Now,
            CreatedBy = EMAIL,
            IsDeleted = false,
            VISITNUM = 1,
            VISIT_DATE = DateTime.Now,
            ParticipationId = 1,
            FORMVER = "4",
            INITIALS = "TST",
            Forms = new List<FormDto>()
            {
                new B6Dto
                {
                    Id = 1,
                    VisitId = 1,
                    Kind = "B6",
                    CreatedAt = DateTime.Now,
                    CreatedBy = EMAIL,
                    IsDeleted = false,
                    Status = "Pending",
                    NOGDS = TESTINT,
                    SATIS = TESTINT,
                    DROPACT = TESTINT,
                    EMPTY = TESTINT,
                    BORED = TESTINT,
                    SPIRITS = TESTINT,
                    AFRAID = TESTINT,
                    HAPPY = TESTINT,
                    HELPLESS = TESTINT,
                    STAYHOME = TESTINT,
                    MEMPROB = TESTINT,
                    WONDRFUL = TESTINT,
                    WRTHLESS = TESTINT,
                    ENERGY = TESTINT,
                    HOPELESS = TESTINT,
                    BETTER = TESTINT,
                    GDS = TESTINT
                }
            }
        };

        var visit = visitDto.ToDomain(EMAIL);

        var b6 = visit.Forms.Where(f => f.Kind == "B6").FirstOrDefault();

        Assert.IsTrue(b6.GetType() == typeof(Form));
        Assert.IsTrue(b6.Fields.GetType() == typeof(B6FormFields));

        var fields = (B6FormFields)b6.Fields;
        var dtoFields = visitDto.Forms.Where(f => f.Kind == "B6").FirstOrDefault();

        Assert.IsNotNull(dtoFields);

        var b6DtoFields = (B6Dto)dtoFields;

        Assert.AreEqual(b6DtoFields.NOGDS, fields.NOGDS);
        Assert.AreEqual(b6DtoFields.SATIS, fields.SATIS);
        Assert.AreEqual(b6DtoFields.DROPACT, fields.DROPACT);
        Assert.AreEqual(b6DtoFields.EMPTY, fields.EMPTY);
        Assert.AreEqual(b6DtoFields.BORED, fields.BORED);
        Assert.AreEqual(b6DtoFields.SPIRITS, fields.SPIRITS);
        Assert.AreEqual(b6DtoFields.AFRAID, fields.AFRAID);
        Assert.AreEqual(b6DtoFields.HAPPY, fields.HAPPY);
        Assert.AreEqual(b6DtoFields.HELPLESS, fields.HELPLESS);
        Assert.AreEqual(b6DtoFields.STAYHOME, fields.STAYHOME);
        Assert.AreEqual(b6DtoFields.MEMPROB, fields.MEMPROB);
        Assert.AreEqual(b6DtoFields.WONDRFUL, fields.WONDRFUL);
        Assert.AreEqual(b6DtoFields.WRTHLESS, fields.WRTHLESS);
        Assert.AreEqual(b6DtoFields.ENERGY, fields.ENERGY);
        Assert.AreEqual(b6DtoFields.HOPELESS, fields.HOPELESS);
        Assert.AreEqual(b6DtoFields.BETTER, fields.BETTER);
        Assert.AreEqual(b6DtoFields.GDS, fields.GDS);
    }

    [TestMethod]
    public void B7DtoMapsToDomain()
    {
        VisitDto visitDto = new VisitDto
        {
            Id = 1,
            PACKET = PacketKind.I.ToString(),
            CreatedAt = DateTime.Now,
            CreatedBy = EMAIL,
            IsDeleted = false,
            VISITNUM = 1,
            VISIT_DATE = DateTime.Now,
            ParticipationId = 1,
            FORMVER = "4",
            INITIALS = "TST",
            Forms = new List<FormDto>()
            {
                new B7Dto
                {
                    Id = 1,
                    VisitId = 1,
                    Kind = "B7",
                    CreatedAt = DateTime.Now,
                    CreatedBy = EMAIL,
                    IsDeleted = false,
                    Status = "Pending",
                    BILLS = TESTINT,
                    TAXES = TESTINT,
                    SHOPPING = TESTINT,
                    GAMES = TESTINT,
                    STOVE = TESTINT,
                    MEALPREP = TESTINT,
                    EVENTS = TESTINT,
                    PAYATTN = TESTINT,
                    REMDATES = TESTINT,
                    TRAVEL = TESTINT
                }
            }
        };

        var visit = visitDto.ToDomain(EMAIL);

        var b7 = visit.Forms.Where(f => f.Kind == "B7").FirstOrDefault();

        Assert.IsTrue(b7.GetType() == typeof(Form));
        Assert.IsTrue(b7.Fields.GetType() == typeof(B7FormFields));

        var fields = (B7FormFields)b7.Fields;
        var dtoFields = visitDto.Forms.Where(f => f.Kind == "B7").FirstOrDefault();

        Assert.IsNotNull(dtoFields);

        var b7DtoFields = (B7Dto)dtoFields;

        Assert.AreEqual(b7DtoFields.BILLS, fields.BILLS);
        Assert.AreEqual(b7DtoFields.TAXES, fields.TAXES);
        Assert.AreEqual(b7DtoFields.SHOPPING, fields.SHOPPING);
        Assert.AreEqual(b7DtoFields.GAMES, fields.GAMES);
        Assert.AreEqual(b7DtoFields.STOVE, fields.STOVE);
        Assert.AreEqual(b7DtoFields.MEALPREP, fields.MEALPREP);
        Assert.AreEqual(b7DtoFields.EVENTS, fields.EVENTS);
        Assert.AreEqual(b7DtoFields.PAYATTN, fields.PAYATTN);
        Assert.AreEqual(b7DtoFields.REMDATES, fields.REMDATES);
        Assert.AreEqual(b7DtoFields.TRAVEL, fields.TRAVEL);
    }

    //[TestMethod]
    //public void B8DtoMapsToDomain()
    //{
    //    VisitDto visitDto = new VisitDto
    //    {
    //        Id = 1,
    //        Kind = "IVP",
    //        CreatedAt = DateTime.Now,
    //        CreatedBy = EMAIL,
    //        IsDeleted = false,
    //        Number = 1,
    //        StartDateTime = DateTime.Now,
    //        ParticipationId = 1,
    //        Version = "UDS3",
    //        Forms = new List<FormDto>()
    //        {
    //            new B8Dto
    //            {
    //                Id = 1,
    //                VisitId = 1,
    //                Kind = "B8",
    //                CreatedAt = DateTime.Now,
    //                CreatedBy = EMAIL,
    //                IsDeleted = false,
    //                Status = "Pending",
    //                NORMEXAM = TESTINT,
    //                PARKSIGN = TESTINT,
    //                RESTTRL = TESTINT,
    //                RESTTRR = TESTINT,
    //                SLOWINGL = TESTINT,
    //                SLOWINGR = TESTINT,
    //                RIGIDL = TESTINT,
    //                RIGIDR = TESTINT,
    //                BRADY = TESTINT,
    //                PARKGAIT = TESTINT,
    //                POSTINST = TESTINT,
    //                CVDSIGNS = TESTINT,
    //                CORTDEF = TESTINT,
    //                SIVDFIND = TESTINT,
    //                CVDMOTL = TESTINT,
    //                CVDMOTR = TESTINT,
    //                CORTVISL = TESTINT,
    //                CORTVISR = TESTINT,
    //                SOMATL = TESTINT,
    //                SOMATR = TESTINT,
    //                POSTCORT = TESTINT,
    //                PSPCBS = TESTINT,
    //                EYEPSP = TESTINT,
    //                DYSPSP = TESTINT,
    //                AXIALPSP = TESTINT,
    //                GAITPSP = TESTINT,
    //                APRAXSP = TESTINT,
    //                APRAXL = TESTINT,
    //                APRAXR = TESTINT,
    //                CORTSENL = TESTINT,
    //                CORTSENR = TESTINT,
    //                ATAXL = TESTINT,
    //                ATAXR = TESTINT,
    //                ALIENLML = TESTINT,
    //                ALIENLMR = TESTINT,
    //                DYSTONL = TESTINT,
    //                DYSTONR = TESTINT,
    //                MYOCLLT = TESTINT,
    //                MYOCLRT = TESTINT,
    //                ALSFIND = TESTINT,
    //                GAITNPH = TESTINT,
    //                OTHNEUR = TESTINT,
    //                OTHNEURX = TESTSTRING
    //            }
    //        }
    //    };

    //    var visit = visitDto.ToDomain(EMAIL);

    //    var b8 = visit.Forms.Where(f => f.Kind == "B8").FirstOrDefault();

    //    Assert.IsTrue(b8.GetType() == typeof(Form));
    //    Assert.IsTrue(b8.Fields.GetType() == typeof(B8FormFields));

    //    var fields = (B8FormFields)b8.Fields;
    //    var dtoFields = visitDto.Forms.Where(f => f.Kind == "B8").FirstOrDefault();

    //    Assert.IsNotNull(dtoFields);

    //    var b8DtoFields = (B8Dto)dtoFields;

    //    Assert.AreEqual(b8DtoFields.NORMEXAM, fields.NORMEXAM);
    //    Assert.AreEqual(b8DtoFields.PARKSIGN, fields.PARKSIGN);
    //    Assert.AreEqual(b8DtoFields.RESTTRL, fields.RESTTRL);
    //    Assert.AreEqual(b8DtoFields.RESTTRR, fields.RESTTRR);
    //    Assert.AreEqual(b8DtoFields.SLOWINGL, fields.SLOWINGL);
    //    Assert.AreEqual(b8DtoFields.SLOWINGR, fields.SLOWINGR);
    //    Assert.AreEqual(b8DtoFields.RIGIDL, fields.RIGIDL);
    //    Assert.AreEqual(b8DtoFields.RIGIDR, fields.RIGIDR);
    //    Assert.AreEqual(b8DtoFields.BRADY, fields.BRADY);
    //    Assert.AreEqual(b8DtoFields.PARKGAIT, fields.PARKGAIT);
    //    Assert.AreEqual(b8DtoFields.POSTINST, fields.POSTINST);
    //    Assert.AreEqual(b8DtoFields.CVDSIGNS, fields.CVDSIGNS);
    //    Assert.AreEqual(b8DtoFields.CORTDEF, fields.CORTDEF);
    //    Assert.AreEqual(b8DtoFields.SIVDFIND, fields.SIVDFIND);
    //    Assert.AreEqual(b8DtoFields.CVDMOTL, fields.CVDMOTL);
    //    Assert.AreEqual(b8DtoFields.CVDMOTR, fields.CVDMOTR);
    //    Assert.AreEqual(b8DtoFields.CORTVISL, fields.CORTVISL);
    //    Assert.AreEqual(b8DtoFields.CORTVISR, fields.CORTVISR);
    //    Assert.AreEqual(b8DtoFields.SOMATL, fields.SOMATL);
    //    Assert.AreEqual(b8DtoFields.SOMATR, fields.SOMATR);
    //    Assert.AreEqual(b8DtoFields.POSTCORT, fields.POSTCORT);
    //    Assert.AreEqual(b8DtoFields.PSPCBS, fields.PSPCBS);
    //    Assert.AreEqual(b8DtoFields.EYEPSP, fields.EYEPSP);
    //    Assert.AreEqual(b8DtoFields.DYSPSP, fields.DYSPSP);
    //    Assert.AreEqual(b8DtoFields.AXIALPSP, fields.AXIALPSP);
    //    Assert.AreEqual(b8DtoFields.GAITPSP, fields.GAITPSP);
    //    Assert.AreEqual(b8DtoFields.APRAXSP, fields.APRAXSP);
    //    Assert.AreEqual(b8DtoFields.APRAXL, fields.APRAXL);
    //    Assert.AreEqual(b8DtoFields.APRAXR, fields.APRAXR);
    //    Assert.AreEqual(b8DtoFields.CORTSENL, fields.CORTSENL);
    //    Assert.AreEqual(b8DtoFields.CORTSENR, fields.CORTSENR);
    //    Assert.AreEqual(b8DtoFields.ATAXL, fields.ATAXL);
    //    Assert.AreEqual(b8DtoFields.ATAXR, fields.ATAXR);
    //    Assert.AreEqual(b8DtoFields.ALIENLML, fields.ALIENLML);
    //    Assert.AreEqual(b8DtoFields.ALIENLMR, fields.ALIENLMR);
    //    Assert.AreEqual(b8DtoFields.DYSTONL, fields.DYSTONL);
    //    Assert.AreEqual(b8DtoFields.DYSTONR, fields.DYSTONR);
    //    Assert.AreEqual(b8DtoFields.MYOCLLT, fields.MYOCLLT);
    //    Assert.AreEqual(b8DtoFields.MYOCLRT, fields.MYOCLRT);
    //    Assert.AreEqual(b8DtoFields.ALSFIND, fields.ALSFIND);
    //    Assert.AreEqual(b8DtoFields.GAITNPH, fields.GAITNPH);
    //    Assert.AreEqual(b8DtoFields.OTHNEUR, fields.OTHNEUR);
    //    Assert.AreEqual(b8DtoFields.OTHNEURX, fields.OTHNEURX);

    //}

    //[TestMethod]
    //public void B9DtoMapsToDomain()
    //{
    //    VisitDto visitDto = new VisitDto
    //    {
    //        Id = 1,
    //        Kind = "IVP",
    //        CreatedAt = DateTime.Now,
    //        CreatedBy = EMAIL,
    //        IsDeleted = false,
    //        Number = 1,
    //        StartDateTime = DateTime.Now,
    //        ParticipationId = 1,
    //        Version = "UDS3",
    //        Forms = new List<FormDto>()
    //        {
    //            new B9Dto
    //            {
    //                Id = 1,
    //                VisitId = 1,
    //                Kind = "B9",
    //                CreatedAt = DateTime.Now,
    //                CreatedBy = EMAIL,
    //                IsDeleted = false,
    //                Status = "Pending",
    //                DECSUB = TESTINT,
    //                DECIN = TESTINT,
    //                DECCLCOG = TESTINT,
    //                COGMEM = TESTINT,
    //                COGORI = TESTINT,
    //                COGJUDG = TESTINT,
    //                COGLANG = TESTINT,
    //                COGVIS = TESTINT,
    //                COGATTN = TESTINT,
    //                COGFLUC = TESTINT,
    //                COGFLAGO = TESTINT,
    //                COGOTHR = TESTINT,
    //                COGOTHRX = TESTSTRING,
    //                COGFPRED = TESTINT,
    //                COGFPREX = TESTSTRING,
    //                COGMODE = TESTINT,
    //                COGMODEX = TESTSTRING,
    //                DECAGE = TESTINT,
    //                DECCLBE = TESTINT,
    //                BEAPATHY = TESTINT,
    //                BEDEP = TESTINT,
    //                BEVHALL = TESTINT,
    //                BEVWELL = TESTINT,
    //                BEVHAGO = TESTINT,
    //                BEAHALL = TESTINT,
    //                BEDEL = TESTINT,
    //                BEDISIN = TESTINT,
    //                BEIRRIT = TESTINT,
    //                BEAGIT = TESTINT,
    //                BEPERCH = TESTINT,
    //                BEREM = TESTINT,
    //                BEREMAGO = TESTINT,
    //                BEANX = TESTINT,
    //                BEOTHR = TESTINT,
    //                BEOTHRX = TESTSTRING,
    //                BEFPRED = TESTINT,
    //                BEFPREDX = TESTSTRING,
    //                BEMODE = TESTINT,
    //                BEMODEX = TESTSTRING,
    //                BEAGE = TESTINT,
    //                DECCLMOT = TESTINT,
    //                MOGAIT = TESTINT,
    //                MOFALLS = TESTINT,
    //                MOTREM = TESTINT,
    //                MOSLOW = TESTINT,
    //                MOFRST = TESTINT,
    //                MOMODE = TESTINT,
    //                MOMODEX = TESTSTRING,
    //                MOMOPARK = TESTINT,
    //                PARKAGE = TESTINT,
    //                MOMOALS = TESTINT,
    //                ALSAGE = TESTINT,
    //                MOAGE = TESTINT,
    //                COURSE = TESTINT,
    //                FRSTCHG = TESTINT,
    //                LBDEVAL = TESTINT,
    //                FTLDEVAL = TESTINT
    //            }
    //        }
    //    };

    //    var visit = visitDto.ToDomain(EMAIL);

    //    var b9 = visit.Forms.Where(f => f.Kind == "B9").FirstOrDefault();

    //    Assert.IsTrue(b9.GetType() == typeof(Form));
    //    Assert.IsTrue(b9.Fields.GetType() == typeof(B9FormFields));

    //    var fields = (B9FormFields)b9.Fields;
    //    var dtoFields = visitDto.Forms.Where(f => f.Kind == "B9").FirstOrDefault();

    //    Assert.IsNotNull(dtoFields);

    //    var b9DtoFields = (B9Dto)dtoFields;

    //    foreach (var property in typeof(B9FormFields).GetProperties())
    //    {
    //        // property names are the same in each object
    //        // so we can iterate through reflection
    //        var domainPropertyValue = fields.GetType().GetProperty(property.Name).GetValue(fields, null);

    //        // Make sure the test was set to a value
    //        Assert.IsNotNull(domainPropertyValue);

    //        var dtoProperty = b9DtoFields.GetType().GetProperty(property.Name);
    //        if (dtoProperty != null)
    //        {
    //            var dtoPropertyValue = dtoProperty.GetValue(b9DtoFields, null);
    //            Assert.AreEqual(dtoPropertyValue, domainPropertyValue);
    //        }
    //    }
    //}


    //[TestMethod]
    //public void C2DtoMapsToDomain()
    //{
    //    VisitDto visitDto = new VisitDto
    //    {
    //        Id = 1,
    //        Kind = "IVP",
    //        CreatedAt = DateTime.Now,
    //        CreatedBy = EMAIL,
    //        IsDeleted = false,
    //        Number = 1,
    //        StartDateTime = DateTime.Now,
    //        ParticipationId = 1,
    //        Version = "UDS3",
    //        Forms = new List<FormDto>()
    //        {
    //            new C2Dto
    //            {
    //                Id = 1,
    //                VisitId = 1,
    //                Kind = "C2",
    //                CreatedAt = DateTime.Now,
    //                CreatedBy = EMAIL,
    //                IsDeleted = false,
    //                Status = "Pending",
    //                MOCACOMP = TESTINT,
    //                MOCAREAS = TESTINT,
    //                MOCALOC = TESTINT,
    //                MOCALAN = TESTINT,
    //                MOCALANX = TESTSTRING,
    //                MOCAVIS = TESTINT,
    //                MOCAHEAR = TESTINT,
    //                MOCATOTS = TESTINT,
    //                MOCATRAI = TESTINT,
    //                MOCACUBE = TESTINT,
    //                MOCACLOC = TESTINT,
    //                MOCACLON = TESTINT,
    //                MOCACLOH = TESTINT,
    //                MOCANAMI = TESTINT,
    //                MOCAREGI = TESTINT,
    //                MOCADIGI = TESTINT,
    //                MOCALETT = TESTINT,
    //                MOCASER7 = TESTINT,
    //                MOCAREPE = TESTINT,
    //                MOCAFLUE = TESTINT,
    //                MOCAABST = TESTINT,
    //                MOCARECN = TESTINT,
    //                MOCARECC = TESTINT,
    //                MOCARECR = TESTINT,
    //                MOCAORDT = TESTINT,
    //                MOCAORMO = TESTINT,
    //                MOCAORYR = TESTINT,
    //                MOCAORDY = TESTINT,
    //                MOCAORPL = TESTINT,
    //                MOCAORCT = TESTINT,
    //                NPSYCLOC = TESTINT,
    //                NPSYLAN = TESTINT,
    //                NPSYLANX = TESTSTRING,
    //                CRAFTVRS = TESTINT,
    //                CRAFTURS = TESTINT,
    //                UDSBENTC = TESTINT,
    //                DIGFORCT = TESTINT,
    //                DIGFORSL = TESTINT,
    //                DIGBACCT = TESTINT,
    //                DIGBACLS = TESTINT,
    //                ANIMALS = TESTINT,
    //                VEG = TESTINT,
    //                TRAILA = TESTINT,
    //                TRAILARR = TESTINT,
    //                TRAILALI = TESTINT,
    //                TRAILB = TESTINT,
    //                TRAILBRR = TESTINT,
    //                TRAILBLI = TESTINT,
    //                CRAFTDVR = TESTINT,
    //                CRAFTDRE = TESTINT,
    //                CRAFTDTI = TESTINT,
    //                CRAFTCUE = TESTINT,
    //                UDSBENTD = TESTINT,
    //                UDSBENRS = TESTINT,
    //                MINTTOTS = TESTINT,
    //                MINTTOTW = TESTINT,
    //                MINTSCNG = TESTINT,
    //                MINTSCNC = TESTINT,
    //                MINTPCNC = TESTINT,
    //                MINTPCNG = TESTINT,
    //                UDSVERFC = TESTINT,
    //                UDSVERFN = TESTINT,
    //                UDSVERNF = TESTINT,
    //                UDSVERLC = TESTINT,
    //                UDSVERLR = TESTINT,
    //                UDSVERLN = TESTINT,
    //                UDSVERTN = TESTINT,
    //                UDSVERTE = TESTINT,
    //                UDSVERTI = TESTINT,
    //                COGSTAT = TESTINT
    //            }
    //        }
    //    };

    //    var visit = visitDto.ToDomain(EMAIL);

    //    var c2 = visit.Forms.Where(f => f.Kind == "C2").FirstOrDefault();

    //    Assert.IsTrue(c2.GetType() == typeof(Form));
    //    Assert.IsTrue(c2.Fields.GetType() == typeof(C2FormFields));

    //    var fields = (C2FormFields)c2.Fields;
    //    var dtoFields = visitDto.Forms.Where(f => f.Kind == "C2").FirstOrDefault();

    //    Assert.IsNotNull(dtoFields);

    //    var c2DtoFields = (C2Dto)dtoFields;

    //    foreach (var property in typeof(C2FormFields).GetProperties())
    //    {
    //        // property names are the same in each object
    //        // so we can iterate through reflection
    //        var domainPropertyValue = fields.GetType().GetProperty(property.Name).GetValue(fields, null);

    //        // Make sure the test was set to a value
    //        Assert.IsNotNull(domainPropertyValue);

    //        var dtoProperty = c2DtoFields.GetType().GetProperty(property.Name);
    //        if (dtoProperty != null)
    //        {
    //            var dtoPropertyValue = dtoProperty.GetValue(c2DtoFields, null);
    //            Assert.AreEqual(dtoPropertyValue, domainPropertyValue);
    //        }
    //    }
    //}



    //[TestMethod]
    //public void D2DtoMapsToDomain()
    //{
    //    VisitDto visitDto = new VisitDto
    //    {
    //        Id = 1,
    //        Kind = "IVP",
    //        CreatedAt = DateTime.Now,
    //        CreatedBy = EMAIL,
    //        IsDeleted = false,
    //        Number = 1,
    //        StartDateTime = DateTime.Now,
    //        ParticipationId = 1,
    //        Version = "UDS3",
    //        Forms = new List<FormDto>()
    //        {
    //            new D2Dto
    //            {
    //                Id = 1,
    //                VisitId = 1,
    //                Kind = "D2",
    //                CreatedAt = DateTime.Now,
    //                CreatedBy = EMAIL,
    //                IsDeleted = false,
    //                Status = "Pending",
    //                CANCER = TESTINT,
    //                CANCSITE = TESTSTRING,
    //                DIABET = TESTINT,
    //                MYOINF = TESTINT,
    //                CONGHRT = TESTINT,
    //                AFIBRILL = TESTINT,
    //                HYPERT = TESTINT,
    //                ANGINA = TESTINT,
    //                HYPCHOL = TESTINT,
    //                VB12DEF = TESTINT,
    //                THYDIS = TESTINT,
    //                ARTH = TESTINT,
    //                ARTYPE = TESTINT,
    //                ARTYPEX = TESTSTRING,
    //                ARTUPEX = TESTINT,
    //                ARTLOEX = TESTINT,
    //                ARTSPIN = TESTINT,
    //                ARTUNKN = TESTINT,
    //                URINEINC = TESTINT,
    //                BOWLINC = TESTINT,
    //                SLEEPAP = TESTINT,
    //                REMDIS = TESTINT,
    //                HYPOSOM = TESTINT,
    //                SLEEPOTH = TESTINT,
    //                SLEEPOTX = TESTSTRING,
    //                ANGIOCP = TESTINT,
    //                ANGIOPCI = TESTINT,
    //                PACEMAKE = TESTINT,
    //                HVALVE = TESTINT,
    //                ANTIENC = TESTINT,
    //                ANTIENCX = TESTSTRING,
    //                OTHCOND = TESTINT,
    //                OTHCONDX = TESTSTRING
    //            }
    //        }
    //    };

    //    var visit = visitDto.ToDomain(EMAIL);

    //    var d2 = visit.Forms.Where(f => f.Kind == "D2").FirstOrDefault();

    //    Assert.IsTrue(d2.GetType() == typeof(Form));
    //    Assert.IsTrue(d2.Fields.GetType() == typeof(D2FormFields));

    //    var fields = (D2FormFields)d2.Fields;
    //    var dtoFields = visitDto.Forms.Where(f => f.Kind == "D2").FirstOrDefault();

    //    Assert.IsNotNull(dtoFields);

    //    var d2DtoFields = (D2Dto)dtoFields;

    //    foreach (var property in typeof(D2FormFields).GetProperties())
    //    {
    //        // property names are the same in each object
    //        // so we can iterate through reflection
    //        var domainPropertyValue = fields.GetType().GetProperty(property.Name).GetValue(fields, null);

    //        // Make sure the test was set to a value
    //        Assert.IsNotNull(domainPropertyValue);

    //        var dtoProperty = d2DtoFields.GetType().GetProperty(property.Name);
    //        if (dtoProperty != null)
    //        {
    //            var dtoPropertyValue = dtoProperty.GetValue(d2DtoFields, null);
    //            Assert.AreEqual(dtoPropertyValue, domainPropertyValue);
    //        }
    //    }
    //}


}
