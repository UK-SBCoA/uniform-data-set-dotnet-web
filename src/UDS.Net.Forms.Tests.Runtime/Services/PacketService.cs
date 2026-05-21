using UDS.Net.Forms.Tests.Runtime.Data;
using UDS.Net.Services;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.Enums;

namespace UDS.Net.Forms.Tests.Runtime.Services
{
    public class PacketService : IPacketService
    {
        private readonly TestDbContext _context;

        public PacketService(TestDbContext context)
        {
            _context = context;
        }

        public Task<Packet> Add(string username, Packet entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Count(string username, List<PacketStatus> statuses)
        {
            //DEVNOTE: Manually set 1 for packet count
            return 1;
        }

        public Task<int> Count(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<Packet> GetById(string username, int id)
        {
            var packet = new Packet(1, 1, 1, "4", PacketKind.I, DateTime.Now, "TT", PacketStatus.Submitted, DateTime.Now, "test@test.com", null, null, false, new List<Form>(), new List<PacketSubmission>
            {
                new PacketSubmission(1, "19", DateTime.Now, 1, DateTime.Now, "test@test.com", null, null, false, null)
            });

            return packet;
        }

        public Task<Packet> GetPacketWithForms(string username, int id)
        {
            var packet = new Packet(1, 1, 1, "4", PacketKind.I, DateTime.Now, "TT", PacketStatus.Submitted, DateTime.Now, "test@test.com", null, null, false,
                new List<Form>
                {
                    new Form(1, "A3", true, DateTime.Now, "test@test.com", PacketKind.I)
                },
                new List<PacketSubmission>
                {
                    //DEVNOTE: Could this method be moved elwhere to call completed packets elsewhere? 
                    new PacketSubmission(1, "19", DateTime.Now, 1, DateTime.Now, "test@test.com", null, null, false, null, new List<Form>
                    {
                        //DEVNOTE: Will need to include all forms for the export to write data
                        new Form(1, 1, "A1", "A1", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, AdministrationFormat.Self, DateTime.Now, "test@test.com", null, null, false, new A1FormFields()
                        {
                            BIRTHMO = 3,
                            BIRTHYR = 1950,
                            CHLDHDCTRY = "USA",
                            RACEASIAN = true,
                            ETHCHINESE = true,
                            GENNOANS = true,
                            BIRTHSEX = 8,
                            INTERSEX = 8,
                            SEXORNNOAN = true,
                            PREDOMLAN = 1,
                            HANDED = 1,
                            EDUC = 99,
                            LVLEDUC = 1,
                            MARISTAT = 1,
                            LIVSITUA = 1,
                            RESIDENC = 1,
                            SERVED = 0,
                            EXRTIME = 1,
                            MEMWORS = 0,
                            MEMTROUB = 1,
                            MEMTEN = 1,
                            SOURCENW = 1,
                            REFERSC = 2,
                            REFLEARNED = 2
                        }),
                        new Form(1, 1, "A1a", "A1a", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, AdministrationFormat.Self, DateTime.Now, "test@test.com", null, null, false, new A1aFormFields()
                        {
                            OWNSCAR = 0,
                            TRSPACCESS = 0,
                            TRANSPROB = 1,
                            TRANSWORRY = 1,
                            TRSPMED = 1,
                            INCOMEYR = 1,
                            FINSATIS = 1,
                            BILLPAY = 1,
                            FINUPSET = 1,
                            EATLESS = 0,
                            EATLESSYR = 0,
                            LESSMEDS = 0,
                            LESSMEDSYR = 0,
                            COMPCOMM = 10,
                            GUARDEDU = 9,
                            EMPTINESS = 1,
                            MISSPEOPLE = 1,
                            FRIENDS = 1,
                            ABANDONED = 1,
                            CLOSEFRND = 1,
                            PARENTCOMM = 0,
                            CHILDCOMM = 0,
                            FRIENDCOMM = 0,
                            PARTICIPATE = 0,
                            SAFEHOME = 1,
                            SAFECOMM = 1,
                            DELAYMED = 1,
                            SCRIPTPROB = 2,
                            MISSEDFUP = 3,
                            DOCADVICE = 4,
                            HEALTHACC = 3,
                            LESSCOURT = 2,
                            POORSERV = 3,
                            NOTSMART = 3,
                            ACTAFRAID = 2,
                            THREATENED = 4,
                            POORMEDTRT = 3,
                            EXPSKIN = true,
                            EXPSTRS = 1
                        }),
                        new Form(1, 1, "A2", "A2", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new A2FormFields()
                        {
                            INRELTO = 1,
                            INKNOWN = 999,
                            INLIVWTH = 0,
                            INCNTMOD = 5,
                            INCNTFRQ = 1,
                            INCNTTIM = 2,
                            INRELY = 0,
                            INMEMWORS = 0,
                            INMEMTROUB = 2,
                            INMEMTEN = 1
                        }),
                        new Form(1, 1, "A3", "A3", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new A3FormFields()),

                        //DEVNOTE: Issues in sibling writing, logging empty A3 for now. Only sib0 and kid0 props were logged in the test export.

                        //new Form(1, 1, "A3", "A3", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new A3FormFields()
                        //{
                        //    MOMYOB = 1850,
                        //    MOMDAGE = 888,
                        //    MOMETPR = "01",
                        //    MOMETSEC = "01",
                        //    MOMMEVAL = 1,
                        //    MOMAGEO = 999,
                        //    DADYOB = 1851,
                        //    DADDAGE = 999,
                        //    DADETPR = "00",
                        //    SIBS = 1,
                        //    KIDS = 2,
                        //    SiblingFormFields = new List<A3FamilyMemberFormFields>
                        //    {
                        //        new A3FamilyMemberFormFields
                        //        {
                        //            YOB = 2000,
                        //            AGD = 20,
                        //            ETPR = "01",
                        //            ETSEC = "02",
                        //            MEVAL = 2,
                        //            AGO = 10
                        //        }
                        //    },
                        //    KidsFormFields = new List<A3FamilyMemberFormFields>
                        //    {
                        //        new A3FamilyMemberFormFields
                        //        {
                        //            YOB = 1990,
                        //            AGD = 30,
                        //            ETPR = "01",
                        //            ETSEC = "01",
                        //            MEVAL = 3,
                        //            AGO = 20
                        //        },
                        //        new A3FamilyMemberFormFields
                        //        {
                        //            YOB = 1850,
                        //            AGD = 40,
                        //            ETPR = "00"
                        //        }
                        //    }
                        //}),
                        new Form(1, 1, "A4", "A4", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new A4GFormFields()
                        {
                            //DEVNOTE: come back to confirm data for the export
                            ANYMEDS = 1,
                            A4Ds = new List<A4DFormFields>()
                            {
                                new A4DFormFields()
                                {
                                    RxNormId = "12345"
                                }
                            }
                        }),
                        new Form(1, 1, "A4a", "A4a", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new A4aFormFields()
                        {
                            //Currently has a PR open for follow - up exports, may change functionality
                            //Setting TRTBIOMARK = 0 (end form here) for now
                            TRTBIOMARK = 0
                        }),
                        new Form(1, 1, "A5D2", "A5D2", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new A5D2FormFields()
                        {
                            //DEVNOTE: Left out menstral questions, will need to make sure that follow-up packet matches initial packet for sex question
                            TOBAC100 = 1,
                            SMOKYRS = 99,
                            PACKSPER = 4,
                            TOBAC30 = 0,
                            QUITSMOK = 888,
                            ALCFREQYR = 1,
                            ALCDRINKS = 3,
                            ALCBINGE = 2,
                            SUBSTYEAR = 0,
                            SUBSTPAST = 1,
                            CANNABIS = 3,
                            HRTATTACK = 1,
                            HRTATTMULT = 1,
                            HRTATTAGE = 21,
                            CARDARREST = 1,
                            CARDARRAGE = 21,
                            CVAFIB = 0,
                            CVANGIO = 2,
                            CVBYPASS = 1,
                            BYPASSAGE = 21,
                            CVPACDEF = 1,
                            PACDEFAGE = 21,
                            CVCHF = 9,
                            CVHVALVE = 1,
                            VALVEAGE = 21,
                            CVOTHR = 0,
                            CBSTROKE = 1,
                            STROKMUL = 1,
                            STROKAGE = 25,
                            STROKSTAT = 0,
                            ANGIOCP = 1,
                            CAROTIDAGE = 25,
                            CBTIA = 1,
                            TIAAGE = 999,
                            PD = 1,
                            PDAGE = 999,
                            PDOTHR = 1,
                            PDOTHRAGE = 25,
                            SEIZURES = 1,
                            SEIZNUM = 1,
                            SEIZAGE = 21,
                            HEADACHE = 1,
                            MS = 2,
                            HYDROCEPH = 1,
                            HEADIMP = 1,
                            IMPHOCKEY = true,
                            IMPYEARS = 999,
                            HEADINJURY = 1,
                            HEADINJUNC = 1,
                            HEADINJCON = 3,
                            HEADINJNUM = 1,
                            FIRSTTBI = 21,
                            LASTTBI = 24,
                            DIABETES = 1,
                            DIABTYPE = 2,
                            DIABGLP1 = true,
                            DIABAGE = 999,
                            HYPERTEN = 1,
                            HYPERTAGE = 28,
                            HYPERCHO = 2,
                            HYPERCHAGE = 28,
                            B12DEF = 0,
                            THYROID = 1,
                            ARTHRIT = 2,
                            ARTHROSTEO = true,
                            ARTHLOEX = true,
                            INCONTU = 9,
                            INCONTF = 2,
                            APNEA = 1,
                            CPAP = 1,
                            APNEAORAL = 2,
                            RBD = 2,
                            INSOMN = 2,
                            OTHSLEEP = 1,
                            OTHSLEEX = "999",
                            CANCERACTV = 1,
                            CANCERPRIM = true,
                            CANCBREAST = true,
                            CANCBONE = true,
                            CANCERAGE = 999,
                            COVID19 = 1,
                            COVIDHOSP = 1,
                            PULMONARY = 2,
                            KIDNEY = 1,
                            KIDNEYAGE = 23,
                            LIVER = 1,
                            LIVERAGE = 21,
                            PVD = 2,
                            PVDAGE = 999,
                            HIVDIAG = 1,
                            HIVAGE = 22,
                            OTHERCOND = 2,
                            OTHCONDX = "999",
                            MAJORDEP = 1,
                            OTHERDEP = 0,
                            DEPRTREAT = 0,
                            BIPOLAR = 2,
                            SCHIZ = 1,
                            ANXIETY = 2,
                            GENERALANX = 1,
                            PANICDIS = 0,
                            OCD = 0,
                            OTHANXDIS = 0,
                            PTSD = 1,
                            NPSYDEV = 2,
                            PSYCDIS = 9
                        }),
                        new Form(1, 1, "B1", "B1", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new B1FormFields()
                        {
                            //DEVNOTE: putting temp not assessed values from the form I used to check data, might want to have actual values for export tets
                            HEIGHT = 68.0,
                            WEIGHT = 198,
                            WAIST1 = 32,
                            WAIST2 = 32,
                            HIP1 = 38,
                            HIP2 = 38,
                            BPSYSL1 = 128,
                            BPDIASL1 = 88,
                            BPSYSL2 = 128,
                            BPDIASL2 = 88,
                            BPSYSR1 = 129,
                            BPDIASR1 = 88,
                            BPSYSR2 = 129,
                            BPDIASR2 = 88,
                            HRATE = 59
                        }),
                        new Form(1, 1, "B3", "B3", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new B3FormFields()
                        {
                            PDNORMAL = true,
                            SPEECH = 1,
                            FACEXP = 0,
                            TRESTFAC = 0,
                            TRESTRHD = 0,
                            TRESTLHD = 0,
                            TRESTRFT = 0,
                            TRESTLFT = 0,
                            TRACTRHD = 0,
                            TRACTLHD = 0,
                            RIGDNECK = 0,
                            RIGDUPRT = 0,
                            RIGDUPLF = 0,
                            RIGDLORT = 0,
                            RIGDLOLF = 0,
                            TAPSRT = 0,
                            TAPSLF = 0,
                            HANDMOVR = 0,
                            HANDMOVL = 0,
                            HANDALTR = 0,
                            HANDALTL = 0,
                            LEGRT = 0,
                            LEGLF = 0,
                            ARISING = 0,
                            POSTURE = 0,
                            GAIT = 0,
                            POSSTAB = 0,
                            BRADYKIN = 0,
                            TOTALUPDRS = 0
                        }),
                        new Form(1, 1, "B4", "B4", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new B4FormFields()
                        {
                            MEMORY = 0,
                            ORIENT = 0.5,
                            JUDGMENT = 1,
                            COMMUN = 2,
                            HOMEHOBB = 3,
                            PERSCARE = 0,
                            CDRSUM = 6.5,
                            CDRGLOB = 0.5,
                            COMPORT = 0.5,
                            CDRLANG = 1
                        }),
                        new Form(1, 1, "B5", "B5", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new B5FormFields()
                        {
                            NPIQINF = 2,
                            DEL = 1,
                            DELSEV = 1,
                            HALL = 0,
                            AGIT = 9,
                            DEPD = 1,
                            DEPDSEV = 1,
                            ANX = 0,
                            ELAT = 9,
                            APA = 1,
                            APASEV = 1,
                            DISN = 0,
                            IRR = 9,
                            MOT = 1,
                            MOTSEV = 1,
                            NITE = 0,
                            APP = 9
                        }),
                        new Form(1, 1, "B6", "B6", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new B6FormFields()
                        {
                            NOGDS = true,
                            SATIS = 0,
                            DROPACT = 0,
                            EMPTY = 9,
                            BORED = 1,
                            SPIRITS = 1,
                            AFRAID = 9,
                            HAPPY = 0,
                            HELPLESS = 0,
                            STAYHOME = 9,
                            MEMPROB = 1,
                            WONDRFUL = 1,
                            WRTHLESS = 9,
                            ENERGY = 0,
                            HOPELESS = 0,
                            BETTER = 9,
                            GDS = 88
                        }),
                        new Form(1, 1, "B7", "B7", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new B7FormFields()
                        {
                            BILLS = 8,
                            TAXES = 0,
                            SHOPPING = 1,
                            GAMES = 2,
                            STOVE = 3,
                            MEALPREP = 9,
                            EVENTS = 8,
                            PAYATTN = 0,
                            REMDATES = 1,
                            TRAVEL = 2
                        }),
                        new Form(1, 1, "B8", "B8", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new B8FormFields()
                        {
                            NEUREXAM = 1,
                            NORMNREXAM = 1,
                            PARKSIGN = 1,
                            SLOWINGFM = 0,
                            TREMREST = 1,
                            TREMPOST = 2,
                            TREMKINE = 3,
                            RIGIDARM = 8,
                            RIGIDLEG = 0,
                            DYSTARM = 2,
                            DYSTLEG = 3,
                            CHOREA = 8,
                            AMPMOTOR = 0,
                            AXIALRIG = 1,
                            POSTINST = 8,
                            MASKING = 0,
                            STOOPED = 1,
                            OTHERSIGN = 1,
                            LIMBAPRAX = 0,
                            UMNDIST = 1,
                            LMNDIST = 2,
                            VFIELDCUT = 3,
                            LIMBATAX = 8,
                            MYOCLON = 0,
                            UNISOMATO = 1,
                            APHASIA = 0,
                            ALIENLIMB = 0,
                            HSPATNEG = 0,
                            PSPOAGNO = 0,
                            SMTAGNO = 0,
                            OPTICATAX = 0,
                            APRAXGAZE = 0,
                            VHGAZEPAL = 0,
                            DYSARTH = 0,
                            APRAXSP = 0,
                            GAITABN = 1,
                            GAITFIND = 3
                        }),
                        new Form(1, 1, "B9", "B9", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new B9FormFields()
                        {
                            DECCOG = 0,
                            DECMOT = 1,
                            PSYCHSYM = 8,
                            DECCOGIN = 0,
                            DECMOTIN = 1,
                            PSYCHSYMIN = 8,
                            DECCLIN = 1,
                            DECCLCOG = 1,
                            COGMEM = 0,
                            COGORI = 1,
                            COGJUDG = 9,
                            COGLANG = 0,
                            COGVIS = 1,
                            COGATTN = 9,
                            COGFLUC = 0,
                            COGOTHR = 0,
                            COGAGE = 55,
                            COGMODE = 1,
                            DECCLBE = 1,
                            BEAPATHY = 0,
                            BEDEP = 1,
                            BEANX = 9,
                            BEEUPH = 0,
                            BEIRRIT = 1,
                            BEAGIT = 9,
                            BEHAGE = 55,
                            BEVHALL = 1,
                            BEVPATT = 0,
                            BEVWELL = 1,
                            BEAHALL = 1,
                            BEAHSIMP = 0,
                            BEAHCOMP = 1,
                            BEDEL = 0,
                            BEAGGRS = 1,
                            PSYCHAGE = 55,
                            BEDISIN = 0,
                            BEPERCH = 1,
                            BEEMPATH = 9,
                            BEOBCOM = 0,
                            BEANGER = 1,
                            BESUBAB = 1,
                            OPIATEUSE = true,
                            PERCHAGE = 55,
                            BEREM = 1,
                            BEREMAGO = 50,
                            BEREMCONF = 1,
                            BEOTHR = 0,
                            BEMODE = 1,
                            DECCLMOT = 1,
                            MOGAIT = 0,
                            MOFALLS = 1,
                            MOSLOW = 9,
                            MOTREM = 0,
                            MOLIMB = 1,
                            MOFACE = 9,
                            MOSPEECH = 0,
                            MOTORAGE = 50,
                            MOMODE = 1,
                            MOMOPARK = 0,
                            MOMOALS = 1,
                            COURSE = 1,
                            FRSTCHG = 2
                        }),
                        new Form(1, 1, "C2", "C2", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new C2FormFields()
                        {
                            MOCACOMP = 1,
                            MOCALOC = 2,
                            MOCALAN = 1,
                            MOCAVIS = 0,
                            MOCAHEAR = 0,
                            MOCATOTS = 19,
                            MOCATRAI = 1,
                            MOCACUBE = 1,
                            MOCACLOC = 1,
                            MOCACLON = 1,
                            MOCACLOH = 1,
                            MOCANAMI = 1,
                            MOCAREGI = 1,
                            MOCADIGI = 1,
                            MOCALETT = 1,
                            MOCASER7 = 1,
                            MOCAREPE = 1,
                            MOCAFLUE = 1,
                            MOCAABST = 1,
                            MOCARECN = 1,
                            MOCARECC = 1,
                            MOCARECR = 1,
                            MOCAORDT = 1,
                            MOCAORMO = 1,
                            MOCAORYR = 1,
                            MOCAORDY = 1,
                            MOCAORPL = 1,
                            MOCAORCT = 1,
                            NPSYCLOC = 1,
                            NPSYLAN = 1,
                            CRAFTVRS = 44,
                            CRAFTURS = 20,
                            UDSBENTC = 17,
                            DIGFORCT = 14,
                            DIGFORSL = 3,
                            DIGBACCT = 14,
                            DIGBACLS = 2,
                            ANIMALS = 77,
                            VEG = 77,
                            TRAILA = 150,
                            TRAILARR = 40,
                            TRAILALI = 24,
                            TRAILB = 300,
                            TRAILBRR = 40,
                            TRAILBLI = 24,
                            UDSBENTD = 17,
                            UDSBENRS = 0,
                            CRAFTDVR = 44,
                            CRAFTDRE = 25,
                            CRAFTDTI = 85,
                            CRAFTCUE = 0,
                            UDSVERFC = 40,
                            UDSVERFN = 15,
                            UDSVERNF = 15,
                            UDSVERLC = 40,
                            UDSVERLR = 15,
                            UDSVERLN = 15,
                            UDSVERTN = 80,
                            UDSVERTE = 30,
                            UDSVERTI = 30,
                            VERBALTEST = 1,
                            REY1REC = 15,
                            REY1INT = 1,
                            REY2REC = 15,
                            REY2INT = 1,
                            REY3REC = 15,
                            REY3INT = 1,
                            REY4REC = 15,
                            REY4INT = 1,
                            REY5REC = 15,
                            REY5INT = 1,
                            REYBREC = 15,
                            REYBINT = 1,
                            REY6REC = 15,
                            REY6INT = 1,
                            REYDREC = 15,
                            REYDINT = 3,
                            REYDTI = 85,
                            REYMETHOD = 1,
                            REYTCOR = 15,
                            REYFPOS = 14,
                            MINTTOTS = 32,
                            MINTTOTW = 15,
                            MINTSCNG = 32,
                            MINTSCNC = 17,
                            MINTPCNG = 32,
                            MINTPCNC = 32,
                            COGSTAT = 1,
                            RESPVAL = 3,
                            RESPEMOT = true
                        }),
                        new Form(1, 1, "D1a", "D1a", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new D1aFormFields()
                        {
                            DXMETHOD = 1,
                            NORMCOG = 0,
                            DEMENTED = 0,
                            MCICRITCLN = true,
                            MCICRITIMP = true,
                            MCICRITFUN = true,
                            MCI = 1,
                            CDOMMEM = true,
                            MBI = 1,
                            BDOMMOT = 0,
                            BDOMAFREG = 1,
                            BDOMIMP = 0,
                            BDOMSOCIAL = 1,
                            BDOMTHTS = 0,
                            PREDOMSYN = 1,
                            PPASYN = true,
                            PPASYNT = 1,
                            SYNINFCLIN = true,
                            MAJDEPDX = true,
                            MAJDEPDIF = 1,
                            OTHDEPDX = true,
                            OTHDEPDIF = 2,
                            BIPOLDX = true,
                            BIPOLDIF = 3,
                        }),
                        new Form(1, 1, "D1b", "D1b", FormStatus.Finalized, DateTime.Now, "TT", FormLanguage.English, FormMode.InPerson, null, null, null, null, DateTime.Now, "test@test.com", null, null, false, new D1bFormFields()
                        {
                            BIOMARKDX = 1,
                            FLUIDBIOM = 3,
                            BLOODAD = 0,
                            BLOODFTLD = 1,
                            BLOODLBD = 9,
                            BLOODOTH = 8,
                            CSFAD = 0,
                            CSFFTLD = 1,
                            CSFLBD = 9,
                            CSFOTH = 8,
                            IMAGINGDX = 3,
                            PETDX = 2,
                            AMYLPET = 0,
                            TAUPET = 1,
                            FDGPETDX = 1,
                            FDGAD = 0,
                            FDGFTLD = 1,
                            FDGLBD = 9,
                            FDGOTH = 8,
                            DATSCANDX = 0,
                            TRACOTHDX = 0,
                            STRUCTDX = 1,
                            STRUCTAD = 0,
                            STRUCTFTLD = 9,
                            STRUCTCVD = 1,
                            IMAGLINF = 0,
                            IMAGLAC = 1,
                            IMAGMACH = 9,
                            IMAGMICH = 8,
                            IMAGWMH = 1,
                            IMAGWMHSEV = 1,
                            OTHBIOM1 = 2,
                            OTHBIOMX1 = "CSF/Plasma",
                            BIOMAD1 = 0,
                            BIOMFTLD1 = 1,
                            BIOMLBD1 = 9,
                            BIOMOTH1 = 8,
                            OTHBIOM2 = 1,
                            OTHBIOMX2 = "CSF/Plasma",
                            BIOMAD2 = 0,
                            BIOMFTLD2 = 1,
                            BIOMLBD2 = 9,
                            BIOMOTH2 = 8,
                            OTHBIOM3 = 1,
                            OTHBIOMX3 = "CSF/Plasma",
                            BIOMAD3 = 0,
                            BIOMFTLD3 = 1,
                            BIOMLBD3 = 9,
                            BIOMOTH3 = 8,
                            AUTDOMMUT = 0,
                            ALZDIS = true,
                            ALZDISIF = 1,
                            LBDIS = true,
                            LBDIF = 2,
                            FTLD = true,
                            CORT = true,
                            CORTIF = 3,
                            FTLDSUBT = 2,
                        })
                    })
                });

            return Task.FromResult(packet);
        }

        public async Task<List<Packet>> List(string username, List<PacketStatus> statuses, int pageSize = 10, int pageIndex = 1)
        {
            //DEVNOTE: Manually create packet to use with packets index
            List<Packet> packetDomains = new List<Packet>
            {
                new Packet(1, 1, 1, "4", PacketKind.I, DateTime.Now, "TT", PacketStatus.Submitted, DateTime.Now, "test@test.com", null, null, false, new List<Form>(), new List<PacketSubmission>())
            };

            return packetDomains;
        }

        public Task<IEnumerable<Packet>> List(string username, int pageSize = 10, int pageIndex = 1)
        {
            throw new NotImplementedException();
        }

        public Task<Packet> Patch(string username, Packet entity)
        {
            throw new NotImplementedException();
        }

        public Task Remove(string username, Packet entity)
        {
            throw new NotImplementedException();
        }

        public Task<Packet> Update(string username, Packet entity)
        {
            throw new NotImplementedException();
        }

        public Task<Packet> UpdatePacketSubmissionErrors(string username, Packet packetToEdit, int packetSubmissionId, List<PacketSubmissionError> errors)
        {
            throw new NotImplementedException();
        }
    }
}