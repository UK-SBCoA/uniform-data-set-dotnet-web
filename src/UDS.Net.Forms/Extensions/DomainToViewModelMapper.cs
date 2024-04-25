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

        public static ParticipationsPaginatedModel ToVM(this IEnumerable<Participation> participations, int pageSize, int pageIndex, int total, string search)
        {
            return new ParticipationsPaginatedModel
            {
                List = participations.Select(p => p.ToVM()).ToList(),
                PageSize = pageSize,
                PageIndex = pageIndex,
                Total = total,
                Search = search
            };
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
                else if (form.Fields is A1aFormFields)
                {
                    vm = ((A1aFormFields)form.Fields).ToVM(form.Id);
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
                else if (form.Fields is A4aFormFields)
                {
                    vm = ((A4aFormFields)form.Fields).ToVM(form.Id);
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
                else if (form.Fields is B3FormFields)
                {
                    vm = ((B3FormFields)form.Fields).ToVM(form.Id);
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

        public static A1a ToVM(this A1aFormFields fields, int formId)
        {
            return new A1a()
            {
                Id = formId,
                OWNSCAR = fields.OWNSCAR,
                TRSPACCESS = fields.TRSPACCESS,
                TRANSPROB = fields.TRANSPROB,
                TRANSWORRY = fields.TRANSWORRY,
                TRSPLONGER = fields.TRSPLONGER,
                TRSPMED = fields.TRSPMED,
                INCOMEYR = fields.INCOMEYR,
                FINSATIS = fields.FINSATIS,
                BILLPAY = fields.BILLPAY,
                FINUPSET = fields.FINUPSET,
                EATLESS = fields.EATLESS,
                EATLESSYR = fields.EATLESSYR,
                LESSMEDS = fields.LESSMEDS,
                LESSMEDSYR = fields.LESSMEDSYR,
                COMPCOMM = fields.COMPCOMM,
                COMPUSA = fields.COMPUSA,
                FAMCOMP = fields.FAMCOMP,
                GUARDEDU = fields.GUARDEDU,
                GUARDREL = fields.GUARDREL,
                GUARDRELX = fields.GUARDRELX,
                GUARD2EDU = fields.GUARD2EDU,
                GUARD2REL = fields.GUARD2REL,
                GUARD2RELX = fields.GUARD2RELX,
                EMPTINESS = fields.EMPTINESS,
                MISSPEOPLE = fields.MISSPEOPLE,
                FRIENDS = fields.FRIENDS,
                ABANDONED = fields.ABANDONED,
                CLOSEFRND = fields.CLOSEFRND,
                PARENTCOMM = fields.PARENTCOMM,
                CHILDCOMM = fields.CHILDCOMM,
                FRIENDCOMM = fields.FRIENDCOMM,
                PARTICIPATE = fields.PARTICIPATE,
                SAFEHOME = fields.SAFEHOME,
                SAFECOMM = fields.SAFECOMM,
                DELAYMED = fields.DELAYMED,
                SCRIPTPROB = fields.SCRIPTPROB,
                MISSEDFUP = fields.MISSEDFUP,
                DOCADVICE = fields.DOCADVICE,
                HEALTHACC = fields.HEALTHACC,
                LESSCOURT = fields.LESSCOURT,
                POORSERV = fields.POORSERV,
                NOTSMART = fields.NOTSMART,
                ACTAFRAID = fields.ACTAFRAID,
                THREATENED = fields.THREATENED,
                POORMEDTRT = fields.POORMEDTRT,
                EXPANCEST = fields.EXPANCEST,
                EXPGENDER = fields.EXPGENDER,
                EXPRACE = fields.EXPRACE,
                EXPAGE = fields.EXPAGE,
                EXPRELIG = fields.EXPRELIG,
                EXPHEIGHT = fields.EXPHEIGHT,
                EXPWEIGHT = fields.EXPWEIGHT,
                EXPAPPEAR = fields.EXPAPPEAR,
                EXPSEXORN = fields.EXPSEXORN,
                EXPEDUCINC = fields.EXPEDUCINC,
                EXPDISAB = fields.EXPDISAB,
                EXPSKIN = fields.EXPSKIN,
                EXPOTHER = fields.EXPOTHER,
                EXPNOTAPP = fields.EXPNOTAPP,
                EXPNOANS = fields.EXPNOANS,
                EXPSTRS = fields.EXPSTRS
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
                MOMYOB = fields.MOMYOB,
                MOMDAGE = fields.MOMDAGE,
                MOMETPR = fields.MOMETPR,
                MOMETSEC = fields.MOMETSEC,
                MOMMEVAL = fields.MOMMEVAL,
                MOMAGEO = fields.MOMAGEO,
                DADYOB = fields.DADYOB,
                DADDAGE = fields.DADDAGE,
                DADETPR = fields.DADETPR,
                DADETSEC = fields.DADETSEC,
                DADMEVAL = fields.DADMEVAL,
                DADAGEO = fields.DADAGEO,
                SIBS = fields.SIBS,
                NWINFSIB = fields.NWINFSIB,
                KIDS = fields.KIDS,
                NWINFKID = fields.NWINFKID,
                Siblings = fields.SiblingFormFields.Select(s => s.ToVM(formId)).ToList(),
                Children = fields.KidsFormFields.Select(k => k.ToVM(formId)).ToList()
            };
        }

        public static A3FamilyMember ToVM(this A3FamilyMemberFormFields fields, int formId)
        {
            return new A3FamilyMember()
            {
                FamilyMemberIndex = fields.FamilyMemberIndex,
                YOB = fields.YOB,
                AGD = fields.AGD,
                ETPR = fields.ETPR,
                ETSEC = fields.ETSEC,
                MEVAL = fields.MEVAL,
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
                    RxNormId = d.RxNormId,
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
                    RxNormId = drugCode.RxNormId,
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
                RxNormId = drugCode.RxNormId,
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



        public static A4a ToVM(this A4aFormFields fields, int formId)
        {
            return new A4a()
            {
                Id = formId,
                ADVEVENT = fields.ADVEVENT,
                ARIAE = fields.ARIAE,
                ARIAH = fields.ARIAH,
                ADVERSEOTH = fields.ADVERSEOTH,
                ADVERSEOTX = fields.ADVERSEOTX,
                TRTBIOMARK = fields.TRTBIOMARK,
                Treatments = fields.TreatmentFormFields.Select(s => s.ToVM(formId)).ToList(),

            };
        }

        public static A4aTreatment ToVM(this A4aTreatmentFormFields fields, int formId)
        {
            return new A4aTreatment()
            {
                TreatmentIndex = fields.TreatmentIndex,
                TARGETAB = fields.TARGETAB,
                TARGETTAU = fields.TARGETTAU,
                TARGETINF = fields.TARGETINF,
                TARGETSYN = fields.TARGETSYN,
                TARGETOTH = fields.TARGETOTH,
                TARGETOTX = fields.TARGETOTX,
                TRTTRIAL = fields.TRTTRIAL,
                NCTNUM = fields.NCTNUM,
                STARTMO = fields.STARTMO,
                STARTYEAR = fields.STARTYEAR,
                ENDMO = fields.ENDMO,
                ENDYEAR = fields.ENDYEAR,
                CARETRIAL = fields.CARETRIAL,
                TRIALGRP = fields.TRIALGRP
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
                CANCERACTV = fields.CANCERACTV,
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
                OTHERCOND = fields.OTHERCOND,
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
                WAIST1 = fields.WAIST1,
                WAIST2 = fields.WAIST2,
                HIP1 = fields.HIP1,
                HIP2 = fields.HIP2,
                BPSYSL1 = fields.BPSYSL1,
                BPDIASL1 = fields.BPDIASL1,
                BPSYSL2 = fields.BPSYSL2,
                BPDIASL2 = fields.BPDIASL2,
                BPSYSR1 = fields.BPSYSR1,
                BPDIASR1 = fields.BPDIASR1,
                BPSYSR2 = fields.BPSYSR2,
                BPDIASR2 = fields.BPDIASR2,
                HRATE = fields.HRATE
            };
        }

        public static B3 ToVM(this B3FormFields fields, int formId)
        {
            return new B3()
            {
                Id = formId,
                PDNORMAL = fields.PDNORMAL,
                SPEECH = fields.SPEECH,
                SPEECHX = fields.SPEECHX,
                FACEXP = fields.FACEXP,
                FACEXPX = fields.FACEXPX,
                TRESTFAC = fields.TRESTFAC,
                TRESTFAX = fields.TRESTFAX,
                TRESTRHD = fields.TRESTRHD,
                TRESTRHX = fields.TRESTRHX,
                TRESTLHD = fields.TRESTLHD,
                TRESTLHX = fields.TRESTLHX,
                TRESTRFT = fields.TRESTRFT,
                TRESTRFX = fields.TRESTRFX,
                TRESTLFT = fields.TRESTLFT,
                TRESTLFX = fields.TRESTLFX,
                TRACTRHD = fields.TRACTRHD,
                TRACTRHX = fields.TRACTRHX,
                TRACTLHD = fields.TRACTLHD,
                TRACTLHX = fields.TRACTLHX,
                RIGDNECK = fields.RIGDNECK,
                RIGDNEX = fields.RIGDNEX,
                RIGDUPRT = fields.RIGDUPRT,
                RIGDUPRX = fields.RIGDUPRX,
                RIGDUPLF = fields.RIGDUPLF,
                RIGDUPLX = fields.RIGDUPLX,
                RIGDLORT = fields.RIGDLORT,
                RIGDLORX = fields.RIGDLORX,
                RIGDLOLF = fields.RIGDLOLF,
                RIGDLOLX = fields.RIGDLOLX,
                TAPSRT = fields.TAPSRT,
                TAPSRTX = fields.TAPSRTX,
                TAPSLF = fields.TAPSLF,
                TAPSLFX = fields.TAPSLFX,
                HANDMOVR = fields.HANDMOVR,
                HANDMVRX = fields.HANDMVRX,
                HANDMOVL = fields.HANDMOVL,
                HANDMVLX = fields.HANDMVLX,
                HANDALTR = fields.HANDALTR,
                HANDATRX = fields.HANDATRX,
                HANDALTL = fields.HANDALTL,
                HANDATLX = fields.HANDATLX,
                LEGRT = fields.LEGRT,
                LEGRTX = fields.LEGRTX,
                LEGLF = fields.LEGLF,
                LEGLFX = fields.LEGLFX,
                ARISING = fields.ARISING,
                ARISINGX = fields.ARISINGX,
                POSTURE = fields.POSTURE,
                POSTUREX = fields.POSTUREX,
                GAIT = fields.GAIT,
                GAITX = fields.GAITX,
                POSSTAB = fields.POSSTAB,
                POSSTABX = fields.POSSTABX,
                BRADYKIN = fields.BRADYKIN,
                BRADYKIX = fields.BRADYKIX,
                TOTALUPDRS = fields.TOTALUPDRS
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
                NEUREXAM = fields.NEUREXAM,
                NORMNREXAM = fields.NORMNREXAM.HasValue ? (fields.NORMNREXAM == true ? 1 : 0) : null,
                PARKSIGN = fields.PARKSIGN,
                SLOWINGFM = fields.SLOWINGFM,
                TREMREST = fields.TREMREST,
                TREMPOST = fields.TREMPOST,
                TREMKINE = fields.TREMKINE,
                RIGIDARM = fields.RIGIDARM,
                RIGIDLEG = fields.RIGIDLEG,
                DYSTARM = fields.DYSTARM,
                DYSTLEG = fields.DYSTLEG,
                CHOREA = fields.CHOREA,
                AMPMOTOR = fields.AMPMOTOR,
                AXIALRIG = fields.AXIALRIG,
                POSTINST = fields.POSTINST,
                MASKING = fields.MASKING,
                STOOPED = fields.STOOPED,
                OTHERSIGN = fields.OTHERSIGN,
                LIMBAPRAX = fields.LIMBAPRAX,
                UMNDIST = fields.UMNDIST,
                LMNDIST = fields.LMNDIST,
                VFIELDCUT = fields.VFIELDCUT,
                LIMBATAX = fields.LIMBATAX,
                MYOCLON = fields.MYOCLON,
                UNISOMATO = fields.UNISOMATO,
                APHASIA = fields.APHASIA,
                ALIENLIMB = fields.ALIENLIMB,
                HSPATNEG = fields.HSPATNEG,
                PSPOAGNO = fields.PSPOAGNO,
                SMTAGNO = fields.SMTAGNO,
                OPTICATAX = fields.OPTICATAX,
                APRAXGAZE = fields.APRAXGAZE,
                VHGAZEPAL = fields.VHGAZEPAL,
                DYSARTH = fields.DYSARTH,
                APRAXSP = fields.APRAXSP,
                GAITABN = fields.GAITABN,
                GAITFIND = fields.GAITFIND,
                GAITOTHRX = fields.GAITOTHRX
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

