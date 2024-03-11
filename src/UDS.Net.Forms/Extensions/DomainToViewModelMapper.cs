using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.LookupModels;

namespace UDS.Net.Forms.Extensions
{
    public static class DomainToViewModelMapper
    {
        private static void SetBaseProperties(Form form, FormModel vm)
        {
            vm.VisitId = form.VisitId;
            vm.Version = form.Version;
            vm.Status = form.Status;
            vm.Kind = form.Kind;
            vm.Title = form.Title;
            vm.Description = form.Description;
            vm.IsRequiredForVisitKind = form.IsRequiredForVisitKind;
            vm.ReasonCodeNotIncluded = form.ReasonCode;
            vm.CreatedAt = form.CreatedAt;
            vm.CreatedBy = form.CreatedBy;
            vm.ModifiedBy = form.ModifiedBy;
            vm.DeletedBy = form.DeletedBy;
            vm.IsDeleted = form.IsDeleted;
        }

        public static ParticipationModel ToVM(this Participation participation)
        {
            return new ParticipationModel()
            {
                Id = participation.Id,
                LegacyId = participation.LegacyId,
                VisitCount = participation.Visits == null ? participation.VisitCount : participation.Visits.Count(), // TODO possibly use visitcount on the object??
                Visits = participation.Visits.ToVM(),
                LastVisitNumber = participation.LastVisitNumber
            };
        }

        public static List<VisitModel> ToVM(this IList<Visit> visits)
        {
            List<VisitModel> vm = new List<VisitModel>();

            foreach (var visit in visits)
            {
                vm.Add(visit.ToVM());
            }

            return vm;
        }

        public static VisitModel ToVM(this Visit visit)
        {
            return new VisitModel()
            {
                Id = visit.Id,
                ParticipationId = visit.ParticipationId,
                Number = visit.Number,
                Kind = visit.Kind,
                Version = visit.Version,
                StartDateTime = visit.StartDateTime,
                CreatedAt = visit.CreatedAt,
                CreatedBy = visit.CreatedBy,
                ModifiedBy = visit.ModifiedBy,
                DeletedBy = visit.DeletedBy,
                IsDeleted = visit.IsDeleted,
                Forms = visit.Forms.ToVM()
            };
        }

        public static MilestoneModel ToVM(this Milestone milestone)
        {
            return new MilestoneModel()
            {
                Id = milestone.Id,
                FormId = milestone.FormId,
                ParticipationId = milestone.ParticipationId,
                Status = milestone.Status,
                CHANGEMO = milestone.CHANGEMO,
                CHANGEDY = milestone.CHANGEDY,
                CHANGEYR = milestone.CHANGEYR,
                PROTOCOL = milestone.PROTOCOL,
                ACONSENT = milestone.ACONSENT,
                RECOGIM = milestone.RECOGIM.HasValue ? true : false,
                REPHYILL = milestone.REPHYILL.HasValue ? true : false,
                REREFUSE = milestone.REREFUSE.HasValue ? true : false,
                RENAVAIL = milestone.RENAVAIL.HasValue ? true : false,
                RENURSE = milestone.RENURSE.HasValue ? true : false,
                NURSEMO = milestone.NURSEMO,
                NURSEDY = milestone.NURSEDY,
                NURSEYR = milestone.NURSEYR,
                REJOIN = milestone.REJOIN.HasValue ? true : false,
                FTLDDISC = milestone.FTLDDISC.HasValue ? true : false,
                FTLDREAS = milestone.FTLDREAS,
                FTLDREAX = milestone.FTLDREAX,
                DECEASED = milestone.DECEASED.HasValue ? true : false,
                DISCONT = milestone.DISCONT.HasValue ? true : false,
                DEATHMO = milestone.DEATHMO,
                DEATHDY = milestone.DEATHDY,
                DEATHYR = milestone.DEATHYR,
                AUTOPSY = milestone.AUTOPSY,
                DISCMO = milestone.DISCMO,
                DISCDAY = milestone.DISCDAY,
                DISCYR = milestone.DISCYR,
                DROPREAS = milestone.DROPREAS,
                CreatedAt = milestone.CreatedAt,
                CreatedBy = milestone.CreatedBy,
                ModifiedBy = milestone.ModifiedBy,
                DeletedBy = milestone.DeletedBy,
                IsDeleted = milestone.IsDeleted,
            };
        }

        public static IEnumerable<MilestoneModel> ToVM(this IEnumerable<Milestone> milestones)
        {
            return milestones.Select(m => m.ToVM()).ToList();
        }

        public static List<FormModel> ToVM(this IList<Form> forms)
        {
            List<FormModel> vm = new List<FormModel>();

            foreach (var form in forms)
            {
                vm.Add(form.ToVM());
            }

            return vm;
        }

        public static FormModel ToVM(this Form form)
        {
            var vm = new FormModel()
            {
                Id = form.Id,
                VisitId = form.VisitId,
                Version = form.Version,
                Kind = form.Kind,
                Status = form.Status,
                Title = form.Title,
                Description = form.Description,
                IsRequiredForVisitKind = form.IsRequiredForVisitKind,
                CreatedAt = form.CreatedAt,
                CreatedBy = form.CreatedBy,
                ModifiedBy = form.ModifiedBy,
                DeletedBy = form.DeletedBy,
                IsDeleted = form.IsDeleted,
                Language = form.Language,
                ReasonCodeNotIncluded = form.ReasonCode
            };

            if (form.Fields != null)
            {
                if (form.Fields is A1FormFields)
                {
                    vm = ((A1FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is A2FormFields)
                {
                    vm = ((A2FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is A3FormFields)
                {
                    vm = ((A3FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is A4GFormFields)
                {
                    vm = ((A4GFormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is A5FormFields)
                {
                    vm = ((A5FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is A5D2FormFields)
                {
                    vm = ((A5D2FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is B1FormFields)
                {
                    vm = ((B1FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is B4FormFields)
                {
                    vm = ((B4FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is B5FormFields)
                {
                    vm = ((B5FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is B6FormFields)
                {
                    vm = ((B6FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is B7FormFields)
                {
                    vm = ((B7FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is B8FormFields)
                {
                    vm = ((B8FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is B9FormFields)
                {
                    vm = ((B9FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is C1FormFields)
                {
                    vm = ((C1FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is C2FormFields)
                {
                    vm = ((C2FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is D1FormFields)
                {
                    vm = ((D1FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is D2FormFields)
                {
                    vm = ((D2FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is T1FormFields)
                {
                    vm = ((T1FormFields)form.Fields).ToVM(form.Id);
                }

                SetBaseProperties(form, vm); // must know the vm type in order to do this
            }

            return vm;
        }

        public static A1 ToVM(this A1FormFields fields, int formId)
        {
            return new A1()
            {
                Id = formId,
                BIRTHMO = fields.BIRTHMO,
                BIRTHYR = fields.BIRTHYR,
                CHLDHDCTRY = fields.CHLDHDCTRY,
                RACEWHITE = fields.RACEWHITE.HasValue ? fields.RACEWHITE.Value != 0 : false,
                ETHGERMAN = fields.ETHGERMAN.HasValue ? fields.ETHGERMAN.Value != 0 : false,
                ETHIRISH = fields.ETHIRISH.HasValue ? fields.ETHIRISH.Value != 0 : false,
                ETHENGLISH = fields.ETHENGLISH.HasValue ? fields.ETHENGLISH.Value != 0 : false,
                ETHITALIAN = fields.ETHITALIAN.HasValue ? fields.ETHITALIAN.Value != 0 : false,
                ETHPOLISH = fields.ETHPOLISH.HasValue ? fields.ETHPOLISH.Value != 0 : false,
                ETHFRENCH = fields.ETHFRENCH.HasValue ? fields.ETHFRENCH.Value != 0 : false,
                ETHWHIOTH = fields.ETHWHIOTH.HasValue ? fields.ETHWHIOTH.Value != 0 : false,
                ETHWHIOTHX = fields.ETHWHIOTHX,
                ETHISPANIC = fields.ETHISPANIC.HasValue ? fields.ETHISPANIC.Value != 0 : false,
                ETHMEXICAN = fields.ETHMEXICAN.HasValue ? fields.ETHMEXICAN.Value != 0 : false,
                ETHPUERTO = fields.ETHPUERTO.HasValue ? fields.ETHPUERTO.Value != 0 : false,
                ETHCUBAN = fields.ETHCUBAN.HasValue ? fields.ETHCUBAN.Value != 0 : false,
                ETHSALVA = fields.ETHSALVA.HasValue ? fields.ETHSALVA.Value != 0 : false,
                ETHDOMIN = fields.ETHDOMIN.HasValue ? fields.ETHDOMIN.Value != 0 : false,
                ETHCOLOM = fields.ETHCOLOM.HasValue ? fields.ETHCOLOM.Value != 0 : false,
                ETHHISOTH = fields.ETHHISOTH.HasValue ? fields.ETHHISOTH.Value != 0 : false,
                ETHHISOTHX = fields.ETHHISOTHX,
                RACEBLACK = fields.RACEBLACK.HasValue ? fields.RACEBLACK.Value != 0 : false,
                ETHAFAMER = fields.ETHAFAMER.HasValue ? fields.ETHAFAMER.Value != 0 : false,
                ETHJAMAICA = fields.ETHJAMAICA.HasValue ? fields.ETHJAMAICA.Value != 0 : false,
                ETHHAITIAN = fields.ETHHAITIAN.HasValue ? fields.ETHHAITIAN.Value != 0 : false,
                ETHNIGERIA = fields.ETHNIGERIA.HasValue ? fields.ETHNIGERIA.Value != 0 : false,
                ETHETHIOP = fields.ETHETHIOP.HasValue ? fields.ETHETHIOP.Value != 0 : false,
                ETHSOMALI = fields.ETHSOMALI.HasValue ? fields.ETHSOMALI.Value != 0 : false,
                ETHBLKOTH = fields.ETHBLKOTH.HasValue ? fields.ETHBLKOTH.Value != 0 : false,
                ETHBLKOTHX = fields.ETHBLKOTHX,
                RACEASIAN = fields.RACEASIAN.HasValue ? fields.RACEASIAN.Value != 0 : false,
                ETHCHINESE = fields.ETHCHINESE.HasValue ? fields.ETHCHINESE.Value != 0 : false,
                ETHFILIP = fields.ETHFILIP.HasValue ? fields.ETHFILIP.Value != 0 : false,
                ETHINDIA = fields.ETHINDIA.HasValue ? fields.ETHINDIA.Value != 0 : false,
                ETHVIETNAM = fields.ETHVIETNAM.HasValue ? fields.ETHVIETNAM.Value != 0 : false,
                ETHKOREAN = fields.ETHKOREAN.HasValue ? fields.ETHKOREAN.Value != 0 : false,
                ETHJAPAN = fields.ETHJAPAN.HasValue ? fields.ETHJAPAN.Value != 0 : false,
                ETHASNOTH = fields.ETHASNOTH.HasValue ? fields.ETHASNOTH.Value != 0 : false,
                ETHASNOTHX = fields.ETHASNOTHX,
                RACEAIAN = fields.RACEAIAN.HasValue ? fields.RACEAIAN.Value != 0 : false,
                RACEAIANX = fields.RACEAIANX,
                RACEMENA = fields.RACEMENA.HasValue ? fields.RACEMENA.Value != 0 : false,
                ETHLEBANON = fields.ETHLEBANON.HasValue ? fields.ETHLEBANON.Value != 0 : false,
                ETHIRAN = fields.ETHIRAN.HasValue ? fields.ETHIRAN.Value != 0 : false,
                ETHEGYPT = fields.ETHEGYPT.HasValue ? fields.ETHEGYPT.Value != 0 : false,
                ETHSYRIA = fields.ETHSYRIA.HasValue ? fields.ETHSYRIA.Value != 0 : false,
                ETHMOROCCO = fields.ETHMOROCCO.HasValue ? fields.ETHMOROCCO.Value != 0 : false,
                ETHISRAEL = fields.ETHISRAEL.HasValue ? fields.ETHISRAEL.Value != 0 : false,
                ETHMENAOTH = fields.ETHMENAOTH.HasValue ? fields.ETHMENAOTH.Value != 0 : false,
                ETHMENAOTX = fields.ETHMENAOTX,
                RACENHPI = fields.RACENHPI.HasValue ? fields.RACENHPI.Value != 0 : false,
                ETHHAWAII = fields.ETHHAWAII.HasValue ? fields.ETHHAWAII.Value != 0 : false,
                ETHSAMOAN = fields.ETHSAMOAN.HasValue ? fields.ETHSAMOAN.Value != 0 : false,
                ETHCHAMOR = fields.ETHCHAMOR.HasValue ? fields.ETHCHAMOR.Value != 0 : false,
                ETHTONGAN = fields.ETHTONGAN.HasValue ? fields.ETHTONGAN.Value != 0 : false,
                ETHFIJIAN = fields.ETHFIJIAN.HasValue ? fields.ETHFIJIAN.Value != 0 : false,
                ETHMARSHAL = fields.ETHMARSHAL.HasValue ? fields.ETHMARSHAL.Value != 0 : false,
                ETHNHPIOTH = fields.ETHNHPIOTH.HasValue ? fields.ETHNHPIOTH.Value != 0 : false,
                ETHNHPIOTX = fields.ETHNHPIOTX,
                RACEUNKN = fields.RACEUNKN.HasValue ? fields.RACEUNKN.Value != 0 : false,
                GENMAN = fields.GENMAN.HasValue ? fields.GENMAN.Value != 0 : false,
                GENWOMAN = fields.GENWOMAN.HasValue ? fields.GENWOMAN.Value != 0 : false,
                GENTRMAN = fields.GENTRMAN.HasValue ? fields.GENTRMAN.Value != 0 : false,
                GENTRWOMAN = fields.GENTRWOMAN.HasValue ? fields.GENTRWOMAN.Value != 0 : false,
                GENNONBI = fields.GENNONBI.HasValue ? fields.GENNONBI.Value != 0 : false,
                GENTWOSPIR = fields.GENTWOSPIR.HasValue ? fields.GENTWOSPIR.Value != 0 : false,
                GENOTH = fields.GENOTH.HasValue ? fields.GENOTH.Value != 0 : false,
                GENOTHX = fields.GENOTHX,
                GENDKN = fields.GENDKN.HasValue ? fields.GENDKN.Value != 0 : false,
                GENNOANS = fields.GENNOANS.HasValue ? fields.GENNOANS.Value != 0 : false,
                BIRTHSEX = fields.BIRTHSEX,
                INTERSEX = fields.INTERSEX,
                SEXORNGAY = fields.SEXORNGAY.HasValue ? fields.SEXORNGAY.Value != 0 : false,
                SEXORNHET = fields.SEXORNHET.HasValue ? fields.SEXORNHET.Value != 0 : false,
                SEXORNBI = fields.SEXORNBI.HasValue ? fields.SEXORNBI.Value != 0 : false,
                SEXORNTWOS = fields.SEXORNTWOS.HasValue ? fields.SEXORNTWOS.Value != 0 : false,
                SEXORNOTH = fields.SEXORNOTH.HasValue ? fields.SEXORNOTH.Value != 0 : false,
                SEXORNOTHX = fields.SEXORNOTHX,
                SEXORNDNK = fields.SEXORNDNK.HasValue ? fields.SEXORNDNK.Value != 0 : false,
                SEXORNNOAN = fields.SEXORNNOAN.HasValue ? fields.SEXORNNOAN.Value != 0 : false,
                PREDOMLAN = fields.PREDOMLAN,
                PREDOMLANX = fields.PREDOMLANX,
                HANDED = fields.HANDED,
                EDUC = fields.EDUC,
                LVLEDUC = fields.LVLEDUC,
                MARISTAT = fields.MARISTAT,
                LIVSITUA = fields.LIVSITUA,
                RESIDENC = fields.RESIDENC,
                ZIP = fields.ZIP,
                SERVED = fields.SERVED,
                MEDVA = fields.MEDVA,
                EXRTIME = fields.EXRTIME,
                MEMWORS = fields.MEMWORS,
                MEMTROUB = fields.MEMTROUB,
                MEMTEN = fields.MEMTEN,
                ADISTATE = fields.ADISTATE,
                ADINAT = fields.ADINAT,
                PRIOCC = fields.PRIOCC,
                SOURCENW = fields.SOURCENW,
                REFERSC = fields.REFERSC,
                REFERSCX = fields.REFERSCX,
                REFLEARNED = fields.REFLEARNED,
                REFCTRSOCX = fields.REFCTRSOCX,
                REFCTRREGX = fields.REFCTRREGX,
                REFOTHWEBX = fields.REFOTHWEBX,
                REFOTHMEDX = fields.REFOTHMEDX,
                REFOTHREGX = fields.REFOTHREGX,
                REFOTHX = fields.REFOTHX
            };
        }

        public static A2 ToVM(this A2FormFields fields, int formId)
        {
            return new A2()
            {
                Id = formId,
                NEWINF = fields.NEWINF,
                INRELTO = fields.INRELTO,
                INKNOWN = fields.INKNOWN,
                INLIVWTH = fields.INLIVWTH,
                INCNTMOD = fields.INCNTMOD,
                INCNTMDX = fields.INCNTMDX,
                INCNTFRQ = fields.INCNTFRQ,
                INCNTTIM = fields.INCNTTIM,
                INRELY = fields.INRELY,
                INMEMWORS = fields.INMEMWORS,
                INMEMTROUB = fields.INMEMTROUB,
                INMEMTEN = fields.INMEMTEN,
            };
        }

        public static A3 ToVM(this A3FormFields fields, int formId)
        {
            return new A3()
            {
                Id = formId,
                AFFFAMM = fields.AFFFAMM,
                NWINFMUT = fields.NWINFMUT,
                FADMUT = fields.FADMUT,
                FADMUTX = fields.FADMUTX,
                FADMUSO = fields.FADMUSO,
                FADMUSOX = fields.FADMUSOX,
                FFTDMUT = fields.FFTDMUT,
                FFTDMUTX = fields.FFTDMUTX,
                FFTDMUSO = fields.FFTDMUSO,
                FFTDMUSX = fields.FFTDMUSX,
                FOTHMUT = fields.FOTHMUT,
                FOTHMUTX = fields.FOTHMUTX,
                FOTHMUSO = fields.FOTHMUSO,
                FOTHMUSX = fields.FOTHMUSX,
                MOMMOB = fields.MOMMOB,
                MOMYOB = fields.MOMYOB,
                MOMDAGE = fields.MOMDAGE,
                MOMNEUR = fields.MOMNEUR,
                MOMPRDX = fields.MOMPRDX,
                MOMMOE = fields.MOMMOE,
                MOMAGEO = fields.MOMAGEO,
                DADMOB = fields.DADMOB,
                DADYOB = fields.DADYOB,
                DADDAGE = fields.DADDAGE,
                DADNEUR = fields.DADNEUR,
                DADPRDX = fields.DADPRDX,
                DADMOE = fields.DADMOE,
                DADAGEO = fields.DADAGEO,
                SIBS = fields.SIBS,
                KIDS = fields.KIDS,
                Siblings = fields.SiblingFormFields.Select(s => s.ToVM(formId)).ToList(),
                Children = fields.KidsFormFields.Select(k => k.ToVM(formId)).ToList()
            };
        }

        public static A3FamilyMember ToVM(this A3FamilyMemberFormFields fields, int formId)
        {
            return new A3FamilyMember()
            {
                FamilyMemberIndex = fields.FamilyMemberIndex,
                MOB = fields.MOB,
                YOB = fields.YOB,
                AGD = fields.AGD,
                NEU = fields.NEU,
                PDX = fields.PDX,
                MOE = fields.MOE,
                AGO = fields.AGO
            };
        }

        public static A4 ToVM(this A4GFormFields fields, int formId)
        {
            return new A4()
            {
                Id = formId,
                ANYMEDS = fields.ANYMEDS,
                DrugIds = fields.A4Ds.Select(d => new DrugCodeModel
                {
                    Id = d.Id,
                    DrugId = d.DRUGID,
                    CreatedAt = d.CreatedAt,
                    CreatedBy = d.CreatedBy,
                    ModifiedBy = d.ModifiedBy,
                    DeletedBy = d.DeletedBy,
                    IsDeleted = d.IsDeleted,
                    IsSelected = !d.IsDeleted,
                    DrugName = d.DrugCode != null ? d.DrugCode.DrugName : "",
                    BrandName = d.DrugCode != null ? d.DrugCode.BrandName : "",
                    IsOverTheCounter = d.DrugCode != null ? d.DrugCode.IsOverTheCounter : false,
                    IsPopular = d.DrugCode != null ? d.DrugCode.IsPopular : false
                }).ToList()
            };
        }

        public static DrugCodeModel ToVM(this DrugCode drugCode, DrugCodeModel? a4 = null)
        {
            if (a4 == null)
            {
                return new DrugCodeModel
                {
                    DrugId = drugCode.DrugId,
                    DrugName = drugCode.DrugName,
                    BrandName = drugCode.BrandName,
                    IsPopular = drugCode.IsPopular,
                    IsOverTheCounter = drugCode.IsOverTheCounter,
                    IsSelected = false
                };
            }
            // combines drug code reference with data from A4D record
            return new DrugCodeModel
            {
                Id = a4.Id,
                DrugId = drugCode.DrugId,
                DrugName = drugCode.DrugName,
                BrandName = drugCode.BrandName,
                IsPopular = drugCode.IsPopular,
                IsOverTheCounter = drugCode.IsOverTheCounter,
                IsSelected = a4.IsDeleted.HasValue ? !a4.IsDeleted.Value : false, // there is no concept of isSelected persisted in the database (if the row is there and it's not deleted then it is selected)
                CreatedAt = a4.CreatedAt,
                CreatedBy = a4.CreatedBy,
                ModifiedBy = a4.ModifiedBy,
                DeletedBy = a4.DeletedBy,
                IsDeleted = a4.IsDeleted
            };
        }

        public static A5 ToVM(this A5FormFields fields, int formId)
        {
            return new A5()
            {
                Id = formId,
                TOBAC30 = fields.TOBAC30,
                TOBAC100 = fields.TOBAC100,
                SMOKYRS = fields.SMOKYRS,
                PACKSPER = fields.PACKSPER,
                QUITSMOK = fields.QUITSMOK,
                ALCOCCAS = fields.ALCOCCAS,
                ALCFREQ = fields.ALCFREQ,
                CVHATT = fields.CVHATT,
                HATTMULT = fields.HATTMULT,
                HATTYEAR = fields.HATTYEAR,
                CVAFIB = fields.CVAFIB,
                CVANGIO = fields.CVANGIO,
                CVBYPASS = fields.CVBYPASS,
                CVPACDEF = fields.CVPACDEF,
                CVCHF = fields.CVCHF,
                CVANGINA = fields.CVANGINA,
                CVHVALVE = fields.CVHVALVE,
                CVOTHR = fields.CVOTHR,
                CVOTHRX = fields.CVOTHRX,
                CBSTROKE = fields.CBSTROKE,
                STROKMUL = fields.STROKMUL,
                STROKYR = fields.STROKYR,
                CBTIA = fields.CBTIA,
                TIAMULT = fields.TIAMULT,
                TIAYEAR = fields.TIAYEAR,
                PD = fields.PD,
                PDYR = fields.PDYR,
                PDOTHR = fields.PDOTHR,
                PDOTHRYR = fields.PDOTHRYR,
                SEIZURES = fields.SEIZURES,
                TBI = fields.TBI,
                TBIBRIEF = fields.TBIBRIEF,
                TBIEXTEN = fields.TBIEXTEN,
                TBIWOLOS = fields.TBIWOLOS,
                TBIYEAR = fields.TBIYEAR,
                DIABETES = fields.DIABETES,
                DIABTYPE = fields.DIABTYPE,
                HYPERTEN = fields.HYPERTEN,
                HYPERCHO = fields.HYPERCHO,
                B12DEF = fields.B12DEF,
                THYROID = fields.THYROID,
                ARTHRIT = fields.ARTHRIT,
                ARTHTYPE = fields.ARTHTYPE,
                ARTHTYPX = fields.ARTHTYPX,
                ARTHUPEX = fields.ARTHUPEX.HasValue ? fields.ARTHUPEX.Value != 0 : false,
                ARTHLOEX = fields.ARTHLOEX.HasValue ? fields.ARTHLOEX.Value != 0 : false,
                ARTHSPIN = fields.ARTHSPIN.HasValue ? fields.ARTHSPIN.Value != 0 : false,
                ARTHUNK = fields.ARTHUNK.HasValue ? fields.ARTHUNK.Value != 0 : false,
                INCONTU = fields.INCONTU,
                INCONTF = fields.INCONTF,
                APNEA = fields.APNEA,
                RBD = fields.RBD,
                INSOMN = fields.INSOMN,
                OTHSLEEP = fields.OTHSLEEP,
                OTHSLEEX = fields.OTHSLEEX,
                ALCOHOL = fields.ALCOHOL,
                ABUSOTHR = fields.ABUSOTHR,
                ABUSX = fields.ABUSX,
                PTSD = fields.PTSD,
                BIPOLAR = fields.BIPOLAR,
                SCHIZ = fields.SCHIZ,
                DEP2YRS = fields.DEP2YRS,
                DEPOTHR = fields.DEPOTHR,
                ANXIETY = fields.ANXIETY,
                OCD = fields.OCD,
                NPSYDEV = fields.NPSYDEV,
                PSYCDIS = fields.PSYCDIS,
                PSYCDISX = fields.PSYCDISX
            };
        }

        public static A5D2 ToVM(this A5D2FormFields fields, int formId)
        {
            return new A5D2()
            {
                Id = formId,
                TOBAC100 = fields.TOBAC100,
                SMOKYRS = fields.SMOKYRS,
                PACKSPER = fields.PACKSPER,
                TOBAC30 = fields.TOBAC30,
                QUITSMOK = fields.QUITSMOK,
                ALCFREQYR = fields.ALCFREQYR,
                ALCDRINKS = fields.ALCDRINKS,
                ALCBINGE = fields.ALCBINGE,
                SUBSTYEAR = fields.SUBSTYEAR,
                SUBSTPAST = fields.SUBSTPAST,
                CANNABIS = fields.CANNABIS,
                HRTATTACK = fields.HRTATTACK,
                HRTATTMULT = fields.HRTATTMULT,
                HRTATTAGE = fields.HRTATTAGE,
                CARDARREST = fields.CARDARREST,
                CARDARRAGE = fields.CARDARRAGE,
                CVAFIB = fields.CVAFIB,
                CVANGIO = fields.CVANGIO,
                CVBYPASS = fields.CVBYPASS,
                BYPASSAGE = fields.BYPASSAGE,
                CVPACDEF = fields.CVPACDEF,
                PACDEFAGE = fields.PACDEFAGE,
                CVCHF = fields.CVCHF,
                CVHVALVE = fields.CVHVALVE,
                VALVEAGE = fields.VALVEAGE,
                CVOTHR = fields.CVOTHR,
                CVOTHRX = fields.CVOTHRX,
                CBSTROKE = fields.CBSTROKE,
                STROKMUL = fields.STROKMUL,
                STROKAGE = fields.STROKAGE,
                STROKSTAT = fields.STROKSTAT,
                ANGIOCP = fields.ANGIOCP,
                CAROTIDAGE = fields.CAROTIDAGE,
                CBTIA = fields.CBTIA,
                TIAAGE = fields.TIAAGE,
                PD = fields.PD,
                PDAGE = fields.PDAGE,
                PDOTHR = fields.PDOTHR,
                PDOTHRAGE = fields.PDOTHRAGE,
                SEIZURES = fields.SEIZURES,
                SEIZNUM = fields.SEIZNUM,
                SEIZAGE = fields.SEIZAGE,
                HEADACHE = fields.HEADACHE,
                MS = fields.MS,
                HYDROCEPH = fields.HYDROCEPH,
                HEADIMP = fields.HEADIMP,
                IMPAMFOOT = fields.IMPAMFOOT,
                IMPSOCCER = fields.IMPSOCCER,
                IMPHOCKEY = fields.IMPHOCKEY,
                IMPBOXING = fields.IMPBOXING,
                IMPSPORT = fields.IMPSPORT,
                IMPIPV = fields.IMPIPV,
                IMPMILIT = fields.IMPMILIT,
                IMPASSAULT = fields.IMPASSAULT,
                IMPOTHER = fields.IMPOTHER,
                IMPOTHERX = fields.IMPOTHERX,
                IMPYEARS = fields.IMPYEARS,
                HEADINJURY = fields.HEADINJURY,
                HEADINJUNC = fields.HEADINJUNC,
                HEADINJCON = fields.HEADINJCON,
                HEADINJNUM = fields.HEADINJNUM,
                FIRSTTBI = fields.FIRSTTBI,
                LASTTBI = fields.LASTTBI,
                DIABETES = fields.DIABETES,
                DIABTYPE = fields.DIABTYPE,
                DIABINS = fields.DIABINS,
                DIABMEDS = fields.DIABMEDS,
                DIABDIET = fields.DIABDIET,
                DIABUNK = fields.DIABUNK,
                DIABAGE = fields.DIABAGE,
                HYPERTEN = fields.HYPERTEN,
                HYPERTAGE = fields.HYPERTAGE,
                HYPERCHO = fields.HYPERCHO,
                HYPERCHAGE = fields.HYPERCHAGE,
                B12DEF = fields.B12DEF,
                THYROID = fields.THYROID,
                ARTHRIT = fields.ARTHRIT,
                ARTHRRHEUM = fields.ARTHRRHEUM,
                ARTHROSTEO = fields.ARTHROSTEO,
                ARTHROTHR = fields.ARTHROTHR,
                ARTHTYPX = fields.ARTHTYPX,
                ARTHTYPUNK = fields.ARTHTYPUNK,
                ARTHUPEX = fields.ARTHUPEX,
                ARTHLOEX = fields.ARTHLOEX,
                ARTHSPIN = fields.ARTHSPIN,
                ARTHUNK = fields.ARTHUNK,
                INCONTU = fields.INCONTU,
                INCONTF = fields.INCONTF,
                APNEA = fields.APNEA,
                CPAP = fields.CPAP,
                APNEAORAL = fields.APNEAORAL,
                RBD = fields.RBD,
                INSOMN = fields.INSOMN,
                OTHSLEEP = fields.OTHSLEEP,
                OTHSLEEX = fields.OTHSLEEX,
                CANCER = fields.CANCER,
                CANCERPRIM = fields.CANCERPRIM,
                CANCERMETA = fields.CANCERMETA,
                CANCMETBR = fields.CANCMETBR,
                CANCMETOTH = fields.CANCMETOTH,
                CANCERUNK = fields.CANCERUNK,
                CANCBLOOD = fields.CANCBLOOD,
                CANCBREAST = fields.CANCBREAST,
                CANCCOLON = fields.CANCCOLON,
                CANCLUNG = fields.CANCLUNG,
                CANCPROST = fields.CANCPROST,
                CANCOTHER = fields.CANCOTHER,
                CANCOTHERX = fields.CANCOTHERX,
                CANCRAD = fields.CANCRAD,
                CANCRESECT = fields.CANCRESECT,
                CANCIMMUNO = fields.CANCIMMUNO,
                CANCBONE = fields.CANCBONE,
                CANCCHEMO = fields.CANCCHEMO,
                CANCHORM = fields.CANCHORM,
                CANCTROTH = fields.CANCTROTH,
                CANCTROTHX = fields.CANCTROTHX,
                CANCERAGE = fields.CANCERAGE,
                COVID19 = fields.COVID19,
                COVIDHOSP = fields.COVIDHOSP,
                PULMONARY = fields.PULMONARY,
                KIDNEY = fields.KIDNEY,
                KIDNEYAGE = fields.KIDNEYAGE,
                LIVER = fields.LIVER,
                LIVERAGE = fields.LIVERAGE,
                PVD = fields.PVD,
                PVDAGE = fields.PVDAGE,
                HIVDIAG = fields.HIVDIAG,
                HIVAGE = fields.HIVAGE,
                OTHCOND = fields.OTHCOND,
                OTHCONDX = fields.OTHCONDX,
                MAJORDEP = fields.MAJORDEP,
                OTHERDEP = fields.OTHERDEP,
                DEPRTREAT = fields.DEPRTREAT,
                BIPOLAR = fields.BIPOLAR,
                SCHIZ = fields.SCHIZ,
                ANXIETY = fields.ANXIETY,
                GENERALANX = fields.GENERALANX,
                PANICDIS = fields.PANICDIS,
                OCD = fields.OCD,
                OTHANXDIS = fields.OTHANXDIS,
                OTHANXDISX = fields.OTHANXDISX,
                PTSD = fields.PTSD,
                NPSYDEV = fields.NPSYDEV,
                PSYCDIS = fields.PSYCDIS,
                PSYCDISX = fields.PSYCDISX,
                MENARCHE = fields.MENARCHE,
                NOMENSAGE = fields.NOMENSAGE,
                NOMENSNAT = fields.NOMENSNAT,
                NOMENSHYST = fields.NOMENSHYST,
                NOMENSSURG = fields.NOMENSSURG,
                NOMENSCHEM = fields.NOMENSCHEM,
                NOMENSRAD = fields.NOMENSRAD,
                NOMENSHORM = fields.NOMENSHORM,
                NOMENSESTR = fields.NOMENSESTR,
                NOMENSUNK = fields.NOMENSUNK,
                NOMENSOTH = fields.NOMENSOTH,
                NOMENSOTHX = fields.NOMENSOTHX,
                HRT = fields.HRT,
                HRTYEARS = fields.HRTYEARS,
                HRTSTRTAGE = fields.HRTSTRTAGE,
                HRTENDAGE = fields.HRTENDAGE,
                BCPILLS = fields.BCPILLS,
                BCPILLSYR = fields.BCPILLSYR,
                BCSTARTAGE = fields.BCSTARTAGE,
                BCENDAGE = fields.BCENDAGE
            };
        }

        public static B1 ToVM(this B1FormFields fields, int formId)
        {
            return new B1()
            {
                Id = formId,
                HEIGHT = fields.HEIGHT,
                WEIGHT = fields.WEIGHT,
                BPSYS = fields.BPSYS,
                BPDIAS = fields.BPDIAS,
                HRATE = fields.HRATE,
                VISION = fields.VISION,
                VISCORR = fields.VISCORR,
                VISWCORR = fields.VISWCORR,
                HEARING = fields.HEARING,
                HEARAID = fields.HEARAID,
                HEARWAID = fields.HEARWAID
            };
        }

        public static B4 ToVM(this B4FormFields fields, int formId)
        {
            return new B4()
            {
                Id = formId,
                MEMORY = fields.MEMORY,
                ORIENT = fields.ORIENT,
                JUDGMENT = fields.JUDGMENT,
                COMMUN = fields.COMMUN,
                HOMEHOBB = fields.HOMEHOBB,
                PERSCARE = fields.PERSCARE,
                CDRSUM = fields.CDRSUM,
                CDRGLOB = fields.CDRGLOB,
                COMPORT = fields.COMPORT,
                CDRLANG = fields.CDRLANG
            };
        }

        public static B5 ToVM(this B5FormFields fields, int formId)
        {
            return new B5()
            {
                Id = formId,
                NPIQINF = fields.NPIQINF,
                NPIQINFX = fields.NPIQINFX,
                DEL = fields.DEL,
                DELSEV = fields.DELSEV,
                HALL = fields.HALL,
                HALLSEV = fields.HALLSEV,
                AGIT = fields.AGIT,
                AGITSEV = fields.AGITSEV,
                DEPD = fields.DEPD,
                DEPDSEV = fields.DEPDSEV,
                ANX = fields.ANX,
                ANXSEV = fields.ANXSEV,
                ELAT = fields.ELAT,
                ELATSEV = fields.ELATSEV,
                APA = fields.APA,
                APASEV = fields.APASEV,
                DISN = fields.DISN,
                DISNSEV = fields.DISNSEV,
                IRR = fields.IRR,
                IRRSEV = fields.IRRSEV,
                MOT = fields.MOT,
                MOTSEV = fields.MOTSEV,
                NITE = fields.NITE,
                NITESEV = fields.NITESEV,
                APP = fields.APP,
                APPSEV = fields.APPSEV
            };
        }

        public static B6 ToVM(this B6FormFields fields, int formId)
        {
            return new B6()
            {
                Id = formId,
                NOGDS = fields.NOGDS.HasValue ? fields.NOGDS.Value != 0 : false, // (1 != 0) = true, (0 != 0) = false
                SATIS = fields.SATIS,
                DROPACT = fields.DROPACT,
                EMPTY = fields.EMPTY,
                BORED = fields.BORED,
                SPIRITS = fields.SPIRITS,
                AFRAID = fields.AFRAID,
                HAPPY = fields.HAPPY,
                HELPLESS = fields.HELPLESS,
                STAYHOME = fields.STAYHOME,
                MEMPROB = fields.MEMPROB,
                WONDRFUL = fields.WONDRFUL,
                WRTHLESS = fields.WRTHLESS,
                ENERGY = fields.ENERGY,
                HOPELESS = fields.HOPELESS,
                BETTER = fields.BETTER,
                GDS = fields.GDS
            };
        }

        public static B7 ToVM(this B7FormFields fields, int formId)
        {
            return new B7()
            {
                Id = formId,
                BILLS = fields.BILLS,
                TAXES = fields.TAXES,
                SHOPPING = fields.SHOPPING,
                GAMES = fields.GAMES,
                STOVE = fields.STOVE,
                MEALPREP = fields.MEALPREP,
                EVENTS = fields.EVENTS,
                PAYATTN = fields.PAYATTN,
                REMDATES = fields.REMDATES,
                TRAVEL = fields.TRAVEL
            };
        }

        public static B8 ToVM(this B8FormFields fields, int formId)
        {
            return new B8()
            {
                Id = formId,
                NORMEXAM = fields.NORMEXAM,
                PARKSIGN = fields.PARKSIGN,
                RESTTRL = fields.RESTTRL,
                RESTTRR = fields.RESTTRR,
                SLOWINGL = fields.SLOWINGL,
                SLOWINGR = fields.SLOWINGR,
                RIGIDL = fields.RIGIDL,
                RIGIDR = fields.RIGIDR,
                BRADY = fields.BRADY,
                PARKGAIT = fields.PARKGAIT,
                POSTINST = fields.POSTINST,
                CVDSIGNS = fields.CVDSIGNS,
                CORTDEF = fields.CORTDEF,
                SIVDFIND = fields.SIVDFIND,
                CVDMOTL = fields.CVDMOTL,
                CVDMOTR = fields.CVDMOTR,
                CORTVISL = fields.CORTVISL,
                CORTVISR = fields.CORTVISR,
                SOMATL = fields.SOMATL,
                SOMATR = fields.SOMATR,
                POSTCORT = fields.POSTCORT,
                PSPCBS = fields.PSPCBS,
                EYEPSP = fields.EYEPSP,
                DYSPSP = fields.DYSPSP,
                AXIALPSP = fields.AXIALPSP,
                GAITPSP = fields.GAITPSP,
                APRAXSP = fields.APRAXSP,
                APRAXL = fields.APRAXL,
                APRAXR = fields.APRAXR,
                CORTSENL = fields.CORTSENL,
                CORTSENR = fields.CORTSENR,
                ATAXL = fields.ATAXL,
                ATAXR = fields.ATAXR,
                ALIENLML = fields.ALIENLML,
                ALIENLMR = fields.ALIENLMR,
                DYSTONL = fields.DYSTONL,
                DYSTONR = fields.DYSTONR,
                MYOCLLT = fields.MYOCLLT,
                MYOCLRT = fields.MYOCLRT,
                ALSFIND = fields.ALSFIND,
                GAITNPH = fields.GAITNPH,
                OTHNEUR = fields.OTHNEUR,
                OTHNEURX = fields.OTHNEURX
            };
        }

        public static B9 ToVM(this B9FormFields fields, int formId)
        {
            return new B9()
            {
                Id = formId,
                DECSUB = fields.DECSUB,
                DECIN = fields.DECIN,
                DECCLCOG = fields.DECCLCOG,
                COGMEM = fields.COGMEM,
                COGORI = fields.COGORI,
                COGJUDG = fields.COGJUDG,
                COGLANG = fields.COGLANG,
                COGVIS = fields.COGVIS,
                COGATTN = fields.COGATTN,
                COGFLUC = fields.COGFLUC,
                COGFLAGO = fields.COGFLAGO,
                COGOTHR = fields.COGOTHR,
                COGOTHRX = fields.COGOTHRX,
                COGFPRED = fields.COGFPRED,
                COGFPREX = fields.COGFPREX,
                COGMODE = fields.COGMODE,
                COGMODEX = fields.COGMODEX,
                DECAGE = fields.DECAGE,
                DECCLBE = fields.DECCLBE,
                BEAPATHY = fields.BEAPATHY,
                BEDEP = fields.BEDEP,
                BEVHALL = fields.BEVHALL,
                BEVWELL = fields.BEVWELL,
                BEVHAGO = fields.BEVHAGO,
                BEAHALL = fields.BEAHALL,
                BEDEL = fields.BEDISIN,
                BEDISIN = fields.BEDISIN,
                BEIRRIT = fields.BEAGIT,
                BEAGIT = fields.BEAGIT,
                BEPERCH = fields.BEPERCH,
                BEREM = fields.BEREM,
                BEREMAGO = fields.BEREMAGO,
                BEANX = fields.BEANX,
                BEOTHR = fields.BEOTHR,
                BEOTHRX = fields.BEOTHRX,
                BEFPRED = fields.BEFPRED,
                BEFPREDX = fields.BEFPREDX,
                BEMODE = fields.BEMODE,
                BEMODEX = fields.BEMODEX,
                BEAGE = fields.BEAGE,
                DECCLMOT = fields.DECCLMOT,
                MOGAIT = fields.MOGAIT,
                MOFALLS = fields.MOFALLS,
                MOTREM = fields.MOTREM,
                MOSLOW = fields.MOSLOW,
                MOFRST = fields.MOFRST,
                MOMODE = fields.MOMODE,
                MOMODEX = fields.MOMODEX,
                MOMOPARK = fields.MOMOPARK,
                PARKAGE = fields.PARKAGE,
                MOMOALS = fields.MOMOALS,
                ALSAGE = fields.ALSAGE,
                MOAGE = fields.MOAGE,
                COURSE = fields.COURSE,
                FRSTCHG = fields.FRSTCHG,
                LBDEVAL = fields.LBDEVAL,
                FTLDEVAL = fields.FTLDEVAL
            };
        }

        public static C1 ToVM(this C1FormFields fields, int formId)
        {
            return new C1()
            {
                Id = formId,
                MMSECOMP = fields.MMSECOMP,
                MMSEREAS = fields.MMSEREAS,
                MMSELOC = fields.MMSELOC,
                MMSELAN = fields.MMSELAN,
                MMSELANX = fields.MMSELANX,
                MMSEVIS = fields.MMSEVIS,
                MMSEHEAR = fields.MMSEHEAR,
                MMSEORDA = fields.MMSEORDA,
                MMSEORLO = fields.MMSEORLO,
                PENTAGON = fields.PENTAGON,
                MMSE = fields.MMSE,
                NPSYCLOC = fields.NPSYCLOC,
                NPSYLAN = fields.NPSYLAN,
                NPSYLANX = fields.NPSYLANX,
                LOGIMO = fields.LOGIMO,
                LOGIDAY = fields.LOGIDAY,
                LOGIYR = fields.LOGIYR,
                LOGIPREV = fields.LOGIPREV,
                LOGIMEM = fields.LOGIMEM,
                UDSBENTC = fields.UDSBENTC,
                DIGIF = fields.DIGIF,
                DIGIFLEN = fields.DIGIFLEN,
                DIGIB = fields.DIGIB,
                DIGIBLEN = fields.DIGIBLEN,
                ANIMALS = fields.ANIMALS,
                VEG = fields.VEG,
                TRAILA = fields.TRAILA,
                TRAILARR = fields.TRAILARR,
                TRAILALI = fields.TRAILALI,
                TRAILB = fields.TRAILB,
                TRAILBRR = fields.TRAILBRR,
                TRAILBLI = fields.TRAILBLI,
                MEMUNITS = fields.MEMUNITS,
                MEMTIME = fields.MEMTIME,
                UDSBENTD = fields.UDSBENTD,
                UDSBENRS = fields.UDSBENRS,
                BOSTON = fields.BOSTON,
                UDSVERFC = fields.UDSVERFC,
                UDSVERFN = fields.UDSVERFN,
                UDSVERNF = fields.UDSVERNF,
                UDSVERLC = fields.UDSVERLC,
                UDSVERLR = fields.UDSVERLR,
                UDSVERLN = fields.UDSVERLN,
                UDSVERTN = fields.UDSVERTN,
                UDSVERTE = fields.UDSVERTE,
                UDSVERTI = fields.UDSVERTI,
                COGSTAT = fields.COGSTAT
            };
        }

        public static C2 ToVM(this C2FormFields fields, int formId)
        {
            return new C2()
            {
                Id = formId,
                MODCOMM = fields.MODCOMM,
                MOCACOMP = fields.MOCACOMP,
                MOCAREAS = fields.MOCAREAS,
                MOCALOC = fields.MOCALOC,
                MOCALAN = fields.MOCALAN,
                MOCALANX = fields.MOCALANX,
                MOCAVIS = fields.MOCAVIS,
                MOCAHEAR = fields.MOCAHEAR,
                MOCATOTS = fields.MOCATOTS,
                MOCATRAI = fields.MOCATRAI,
                MOCACUBE = fields.MOCACUBE,
                MOCACLOC = fields.MOCACLOC,
                MOCACLON = fields.MOCACLON,
                MOCACLOH = fields.MOCACLOH,
                MOCANAMI = fields.MOCANAMI,
                MOCAREGI = fields.MOCAREGI,
                MOCADIGI = fields.MOCADIGI,
                MOCALETT = fields.MOCALETT,
                MOCASER7 = fields.MOCASER7,
                MOCAREPE = fields.MOCAREPE,
                MOCAFLUE = fields.MOCAFLUE,
                MOCAABST = fields.MOCAABST,
                MOCARECN = fields.MOCARECN,
                MOCARECC = fields.MOCARECC,
                MOCARECR = fields.MOCARECR,
                MOCAORDT = fields.MOCAORDT,
                MOCAORMO = fields.MOCAORMO,
                MOCAORYR = fields.MOCAORYR,
                MOCAORDY = fields.MOCAORDY,
                MOCAORPL = fields.MOCAORPL,
                MOCAORCT = fields.MOCAORCT,
                NPSYCLOC = fields.NPSYCLOC,
                NPSYLAN = fields.NPSYLAN,
                NPSYLANX = fields.NPSYLANX,
                CRAFTVRS = fields.CRAFTVRS,
                CRAFTURS = fields.CRAFTURS,
                UDSBENTC = fields.UDSBENTC,
                DIGFORCT = fields.DIGFORCT,
                DIGFORSL = fields.DIGFORSL,
                DIGBACCT = fields.DIGBACCT,
                DIGBACLS = fields.DIGBACLS,
                ANIMALS = fields.ANIMALS,
                VEG = fields.VEG,
                TRAILA = fields.TRAILA,
                TRAILARR = fields.TRAILARR,
                TRAILALI = fields.TRAILALI,
                TRAILB = fields.TRAILB,
                TRAILBRR = fields.TRAILBRR,
                TRAILBLI = fields.TRAILBLI,
                CRAFTDVR = fields.CRAFTDVR,
                CRAFTDRE = fields.CRAFTDRE,
                CRAFTDTI = fields.CRAFTDTI,
                CRAFTCUE = fields.CRAFTCUE,
                UDSBENTD = fields.UDSBENTD,
                UDSBENRS = fields.UDSBENRS,
                MINTTOTS = fields.MINTTOTS,
                MINTTOTW = fields.MINTTOTW,
                MINTSCNG = fields.MINTSCNG,
                MINTSCNC = fields.MINTSCNC,
                MINTPCNG = fields.MINTPCNG,
                MINTPCNC = fields.MINTPCNC,
                UDSVERFC = fields.UDSVERFC,
                UDSVERFN = fields.UDSVERFN,
                UDSVERNF = fields.UDSVERNF,
                UDSVERLC = fields.UDSVERLC,
                UDSVERLR = fields.UDSVERLR,
                UDSVERLN = fields.UDSVERLN,
                UDSVERTN = fields.UDSVERTN,
                UDSVERTE = fields.UDSVERTE,
                UDSVERTI = fields.UDSVERTI,
                COGSTAT = fields.COGSTAT,
                REY1REC = fields.REY1REC,
                REY1INT = fields.REY1INT,
                REY2REC = fields.REY2REC,
                REY2INT = fields.REY2INT,
                REY3REC = fields.REY3REC,
                REY3INT = fields.REY3INT,
                REY4REC = fields.REY4REC,
                REY4INT = fields.REY4INT,
                REY5REC = fields.REY5REC,
                REY5INT = fields.REY5INT,
                REY6REC = fields.REY6REC,
                REY6INT = fields.REY6INT,
                OTRAILA = fields.OTRAILA,
                OTRLARR = fields.OTRLARR,
                OTRLALI = fields.OTRLALI,
                OTRAILB = fields.OTRAILB,
                OTRLBRR = fields.OTRLBRR,
                OTRLBLI = fields.OTRLBLI,
                REYDREC = fields.REYDREC,
                REYDINT = fields.REYDINT,
                REYTCOR = fields.REYTCOR,
                REYFPOS = fields.REYFPOS,
                VNTTOTW = fields.VNTTOTW,
                VNTPCNC = fields.VNTPCNC,
                RESPVAL = fields.RESPVAL,
                RESPHEAR = fields.RESPHEAR.HasValue ? fields.RESPHEAR.Value != 0 : false,
                RESPDIST = fields.RESPDIST.HasValue ? fields.RESPDIST.Value != 0 : false,
                RESPINTR = fields.RESPINTR.HasValue ? fields.RESPINTR.Value != 0 : false,
                RESPDISN = fields.RESPDISN.HasValue ? fields.RESPDISN.Value != 0 : false,
                RESPFATG = fields.RESPFATG.HasValue ? fields.RESPFATG.Value != 0 : false,
                RESPEMOT = fields.RESPEMOT.HasValue ? fields.RESPEMOT.Value != 0 : false,
                RESPASST = fields.RESPASST.HasValue ? fields.RESPASST.Value != 0 : false,
                RESPOTH = fields.RESPOTH.HasValue ? fields.RESPOTH.Value != 0 : false,
                RESPOTHX = fields.RESPOTHX
            };
        }

        public static D1 ToVM(this D1FormFields fields, int formId)
        {
            return new D1()
            {
                Id = formId,
                DXMETHOD = fields.DXMETHOD,
                NORMCOG = fields.NORMCOG,
                DEMENTED = fields.DEMENTED,
                AMNDEM = fields.AMNDEM.HasValue ? fields.AMNDEM.Value != 0 : false,
                PCA = fields.PCA.HasValue ? fields.PCA.Value != 0 : false,
                PPASYN = fields.PPASYN.HasValue ? fields.PPASYN.Value != 0 : false,
                PPASYNT = fields.PPASYNT,
                FTDSYN = fields.FTDSYN.HasValue ? fields.FTDSYN.Value != 0 : false,
                LBDSYN = fields.LBDSYN.HasValue ? fields.LBDSYN.Value != 0 : false,
                NAMNDEM = fields.NAMNDEM.HasValue ? fields.NAMNDEM.Value != 0 : false,
                MCIAMEM = fields.MCIAMEM.HasValue ? fields.MCIAMEM.Value != 0 : false,
                MCIAPLUS = fields.MCIAPLUS.HasValue ? fields.MCIAPLUS.Value != 0 : false,
                MCIAPLAN = fields.MCIAPLAN,
                MCIAPATT = fields.MCIAPATT,
                MCIAPEX = fields.MCIAPEX,
                MCIAPVIS = fields.MCIAPVIS,
                MCINON1 = fields.MCINON1.HasValue ? fields.MCINON1.Value != 0 : false,
                MCIN1LAN = fields.MCIN1LAN,
                MCIN1ATT = fields.MCIN1ATT,
                MCIN1EX = fields.MCIN1EX,
                MCIN1VIS = fields.MCIN1VIS,
                MCINON2 = fields.MCINON2.HasValue ? fields.MCINON2.Value != 0 : false,
                MCIN2LAN = fields.MCIN2LAN,
                MCIN2ATT = fields.MCIN2ATT,
                MCIN2EX = fields.MCIN2EX,
                MCIN2VIS = fields.MCIN2VIS,
                IMPNOMCI = fields.IMPNOMCI.HasValue ? fields.IMPNOMCI.Value != 0 : false,
                AMYLPET = fields.AMYLPET,
                AMYLCSF = fields.AMYLCSF,
                FDGAD = fields.FDGAD,
                HIPPATR = fields.HIPPATR,
                TAUPETAD = fields.TAUPETAD,
                CSFTAU = fields.CSFTAU,
                FDGFTLD = fields.FDGFTLD,
                TPETFTLD = fields.TPETFTLD,
                MRFTLD = fields.MRFTLD,
                DATSCAN = fields.DATSCAN,
                OTHBIOM = fields.OTHBIOM,
                OTHBIOMX = fields.OTHBIOMX,
                IMAGLINF = fields.IMAGLINF,
                IMAGLAC = fields.IMAGLAC,
                IMAGMACH = fields.IMAGMACH,
                IMAGMICH = fields.IMAGMICH,
                IMAGMWMH = fields.IMAGMWMH,
                IMAGEWMH = fields.IMAGEWMH,
                ADMUT = fields.ADMUT,
                FTLDMUT = fields.FTLDMUT,
                OTHMUT = fields.OTHMUT,
                OTHMUTX = fields.OTHMUTX,
                ALZDIS = fields.ALZDIS.HasValue ? fields.ALZDIS.Value != 0 : false,
                ALZDISIF = fields.ALZDISIF,
                LBDIS = fields.LBDIS.HasValue ? fields.LBDIS.Value != 0 : false,
                LBDIF = fields.LBDIF,
                PARK = fields.PARK.HasValue ? fields.PARK.Value != 0 : false,
                MSA = fields.MSA.HasValue ? fields.MSA.Value != 0 : false,
                MSAIF = fields.MSAIF,
                PSP = fields.PSP.HasValue ? fields.PSP.Value != 0 : false,
                PSPIF = fields.PSPIF,
                CORT = fields.CORT.HasValue ? fields.CORT.Value != 0 : false,
                CORTIF = fields.CORTIF,
                FTLDMO = fields.FTLDMO.HasValue ? fields.FTLDMO.Value != 0 : false,
                FTLDMOIF = fields.FTLDMOIF,
                FTLDNOS = fields.FTLDNOS.HasValue ? fields.FTLDNOS.Value != 0 : false,
                FTLDNOIF = fields.FTLDNOIF,
                FTLDSUBT = fields.FTLDSUBT,
                FTLDSUBX = fields.FTLDSUBX,
                CVD = fields.CVD.HasValue ? fields.CVD.Value != 0 : false,
                CVDIF = fields.CVDIF,
                PREVSTK = fields.PREVSTK,
                STROKDEC = fields.STROKDEC,
                STKIMAG = fields.STKIMAG,
                INFNETW = fields.INFNETW,
                INFWMH = fields.INFWMH,
                ESSTREM = fields.ESSTREM.HasValue ? fields.ESSTREM.Value != 0 : false,
                ESSTREIF = fields.ESSTREIF,
                DOWNS = fields.DOWNS.HasValue ? fields.DOWNS.Value != 0 : false,
                DOWNSIF = fields.DOWNSIF,
                HUNT = fields.HUNT.HasValue ? fields.HUNT.Value != 0 : false,
                HUNTIF = fields.HUNTIF,
                PRION = fields.PRION.HasValue ? fields.PRION.Value != 0 : false,
                PRIONIF = fields.PRIONIF,
                BRNINJ = fields.BRNINJ.HasValue ? fields.BRNINJ.Value != 0 : false,
                BRNINJIF = fields.BRNINJIF,
                BRNINCTE = fields.BRNINCTE,
                HYCEPH = fields.HYCEPH.HasValue ? fields.HYCEPH.Value != 0 : false,
                HYCEPHIF = fields.HYCEPHIF,
                EPILEP = fields.EPILEP.HasValue ? fields.EPILEP.Value != 0 : false,
                EPILEPIF = fields.EPILEPIF,
                NEOP = fields.NEOP.HasValue ? fields.NEOP.Value != 0 : false,
                NEOPIF = fields.NEOPIF,
                NEOPSTAT = fields.NEOPSTAT,
                HIV = fields.HIV.HasValue ? fields.HIV.Value != 0 : false,
                HIVIF = fields.HIVIF,
                OTHCOG = fields.OTHCOG.HasValue ? fields.OTHCOG.Value != 0 : false,
                OTHCOGIF = fields.OTHCOGIF,
                OTHCOGX = fields.OTHCOGX,
                DEP = fields.DEP.HasValue ? fields.DEP.Value != 0 : false,
                DEPIF = fields.DEPIF,
                DEPTREAT = fields.DEPTREAT,
                BIPOLDX = fields.BIPOLDX.HasValue ? fields.BIPOLDX.Value != 0 : false,
                BIPOLDIF = fields.BIPOLDIF,
                SCHIZOP = fields.SCHIZOP.HasValue ? fields.SCHIZOP.Value != 0 : false,
                SCHIZOIF = fields.SCHIZOIF,
                ANXIET = fields.ANXIET.HasValue ? fields.ANXIET.Value != 0 : false,
                ANXIETIF = fields.ANXIETIF,
                DELIR = fields.DELIR.HasValue ? fields.DELIR.Value != 0 : false,
                DELIRIF = fields.DELIRIF,
                PTSDDX = fields.PTSDDX.HasValue ? fields.PTSDDX.Value != 0 : false,
                PTSDDXIF = fields.PTSDDXIF,
                OTHPSY = fields.OTHPSY.HasValue ? fields.OTHPSY.Value != 0 : false,
                OTHPSYIF = fields.OTHPSYIF,
                OTHPSYX = fields.OTHPSYX,
                ALCDEMIF = fields.ALCDEMIF,
                ALCABUSE = fields.ALCABUSE,
                IMPSUB = fields.IMPSUB.HasValue ? fields.IMPSUB.Value != 0 : false,
                IMPSUBIF = fields.IMPSUBIF,
                DYSILL = fields.DYSILL.HasValue ? fields.DYSILL.Value != 0 : false,
                DYSILLIF = fields.DYSILLIF,
                MEDS = fields.MEDS.HasValue ? fields.MEDS.Value != 0 : false,
                MEDSIF = fields.MEDSIF,
                COGOTH = fields.COGOTH.HasValue ? fields.COGOTH.Value != 0 : false,
                COGOTHIF = fields.COGOTHIF,
                COGOTHX = fields.COGOTHX,
                COGOTH2 = fields.COGOTH2.HasValue ? fields.COGOTH2.Value != 0 : false,
                COGOTH2F = fields.COGOTH2F,
                COGOTH2X = fields.COGOTH2X,
                COGOTH3 = fields.COGOTH3.HasValue ? fields.COGOTH3.Value != 0 : false,
                COGOTH3F = fields.COGOTH3F,
                COGOTH3X = fields.COGOTH3X
            };
        }

        public static D2 ToVM(this D2FormFields fields, int formId)
        {
            return new D2()
            {
                Id = formId,
                CANCER = fields.CANCER,
                CANCSITE = fields.CANCSITE,
                DIABET = fields.DIABET,
                MYOINF = fields.MYOINF,
                CONGHRT = fields.CONGHRT,
                AFIBRILL = fields.AFIBRILL,
                HYPERT = fields.HYPERT,
                ANGINA = fields.ANGINA,
                HYPCHOL = fields.HYPCHOL,
                VB12DEF = fields.VB12DEF,
                THYDIS = fields.THYDIS,
                ARTH = fields.ARTH,
                ARTYPE = fields.ARTYPE,
                ARTYPEX = fields.ARTYPEX,
                ARTUPEX = fields.ARTUPEX.HasValue ? fields.ARTUPEX.Value != 0 : false,
                ARTLOEX = fields.ARTLOEX.HasValue ? fields.ARTLOEX.Value != 0 : false,
                ARTSPIN = fields.ARTSPIN.HasValue ? fields.ARTSPIN.Value != 0 : false,
                ARTUNKN = fields.ARTUNKN.HasValue ? fields.ARTUNKN.Value != 0 : false,
                URINEINC = fields.URINEINC,
                BOWLINC = fields.BOWLINC,
                SLEEPAP = fields.SLEEPAP,
                REMDIS = fields.REMDIS,
                HYPOSOM = fields.HYPOSOM,
                SLEEPOTH = fields.SLEEPOTH,
                SLEEPOTX = fields.SLEEPOTX,
                ANGIOCP = fields.ANGIOCP,
                ANGIOPCI = fields.ANGIOPCI,
                PACEMAKE = fields.PACEMAKE,
                HVALVE = fields.HVALVE,
                ANTIENC = fields.ANTIENC,
                ANTIENCX = fields.ANTIENCX,
                OTHCOND = fields.OTHCOND,
                OTHCONDX = fields.OTHCONDX
            };
        }

        public static T1 ToVM(this T1FormFields fields, int formId)
        {
            return new T1()
            {
                Id = formId,
                TELCOG = fields.TELCOG,
                TELILL = fields.TELILL,
                TELHOME = fields.TELHOME,
                TELREFU = fields.TELREFU,
                TELCOV = fields.TELCOV,
                TELOTHR = fields.TELOTHR,
                TELOTHRX = fields.TELOTHRX,
                TELMOD = fields.TELMOD,
                TELINPER = fields.TELINPER,
                TELMILE = fields.TELMILE
            };
        }
    }
}

