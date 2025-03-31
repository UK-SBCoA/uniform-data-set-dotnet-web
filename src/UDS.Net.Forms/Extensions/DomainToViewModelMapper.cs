using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.UDS4;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;
using UDS.Net.Services.DomainModels.Submission;
using UDS.Net.Services.LookupModels;

namespace UDS.Net.Forms.Extensions
{
    public static class DomainToViewModelMapper
    {
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
                LastVisitNumber = participation.LastVisitNumber,
                Status = participation.Status
            };
        }

        public static ParticipationModel ToShallowVM(this Participation participation)
        {
            return new ParticipationModel()
            {
                Id = participation.Id,
                LegacyId = participation.LegacyId,
                VisitCount = participation.Visits == null ? participation.VisitCount : participation.Visits.Count(), // TODO possibly use visitcount on the object??
                LastVisitNumber = participation.LastVisitNumber,
                Status = participation.Status
            };
        }

        public static VisitsPaginatedModel ToVM(this IEnumerable<Visit> visits, int pageSize, int pageIndex, int total, string search)
        {
            VisitsPaginatedModel visitPaginatedModel = new VisitsPaginatedModel
            {
                List = visits.Select(v => v.ToVM()).ToList(),
                PageSize = pageSize,
                PageIndex = pageIndex,
                Total = total,
                Search = search,
            };

            return visitPaginatedModel;
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
            var vm = new VisitModel()
            {
                Id = visit.Id,
                ParticipationId = visit.ParticipationId,
                VISITNUM = visit.VISITNUM,
                PACKET = visit.PACKET,
                FORMVER = visit.FORMVER,
                VISIT_DATE = visit.VISIT_DATE,
                INITIALS = visit.INITIALS,
                Status = visit.Status,
                CreatedAt = visit.CreatedAt,
                CreatedBy = visit.CreatedBy,
                ModifiedBy = visit.ModifiedBy,
                DeletedBy = visit.DeletedBy,
                IsDeleted = visit.IsDeleted,
                CanBeFinalized = visit.TryUpdateStatus(Services.Enums.PacketStatus.Finalized),
                CanBeEdited = visit.TryUpdateStatus(Services.Enums.PacketStatus.Pending),
                Forms = visit.Forms.ToVM(),
                TotalUnresolvedErrorCount = visit.UnresolvedErrorCount
            };

            if (visit.UnresolvedErrors != null)
                vm.UnresolvedErrors = visit.UnresolvedErrors.ToVM();

            if (visit.Participation != null && visit.ParticipationId == visit.Participation.Id)
                vm.Participation = visit.Participation.ToShallowVM();

            return vm;
        }

        public static PacketsPaginatedModel ToVM(this IEnumerable<Packet> packets, int pageSize, int pageIndex, int total, string search)
        {
            return new PacketsPaginatedModel
            {
                List = packets.Select(p => p.ToVM()).ToList(),
                PageSize = pageSize,
                PageIndex = pageIndex,
                Total = total,
                Search = search
            };
        }


        public static PacketModel ToVM(this Packet packet)
        {
            return new PacketModel()
            {
                Id = packet.Id,
                ParticipationId = packet.ParticipationId,
                VISITNUM = packet.VISITNUM,
                PACKET = packet.PACKET,
                FORMVER = packet.FORMVER,
                VISIT_DATE = packet.VISIT_DATE,
                INITIALS = packet.INITIALS,
                Status = packet.Status,
                CreatedAt = packet.CreatedAt,
                CreatedBy = packet.CreatedBy,
                ModifiedBy = packet.ModifiedBy,
                DeletedBy = packet.DeletedBy,
                IsDeleted = packet.IsDeleted,
                CanBeFinalized = packet.TryUpdateStatus(Services.Enums.PacketStatus.Finalized),
                CanBeEdited = packet.TryUpdateStatus(Services.Enums.PacketStatus.Pending),
                Forms = packet.Forms.ToVM(),
                PacketSubmissions = packet.Submissions.ToVM()
            };
        }

        public static List<PacketSubmissionModel> ToVM(this IReadOnlyList<PacketSubmission> packetSubmissions)
        {
            List<PacketSubmissionModel> vm = new List<PacketSubmissionModel>();

            if (packetSubmissions != null && packetSubmissions.Count() > 0)
                vm = packetSubmissions.Select(p => p.ToVM()).ToList();

            return vm;
        }

        public static PacketSubmissionModel ToVM(this PacketSubmission packetSubmission)
        {
            PacketSubmissionModel vm = new PacketSubmissionModel();

            if (packetSubmission != null)
            {
                vm.Id = packetSubmission.Id;
                vm.SubmissionDate = packetSubmission.SubmissionDate;
                vm.CreatedAt = packetSubmission.CreatedAt;
                vm.CreatedBy = packetSubmission.CreatedBy;
                vm.ModifiedBy = packetSubmission.ModifiedBy;
                vm.ErrorCount = packetSubmission.ErrorCount;

                if (packetSubmission.Errors != null)
                {
                    vm.Errors = packetSubmission.Errors.ToVM();
                }
            }

            return vm;
        }

        public static List<PacketSubmissionErrorModel> ToVM(this IList<PacketSubmissionError> packetSubmissionErrors)
        {
            List<PacketSubmissionErrorModel> vm = new List<PacketSubmissionErrorModel>();

            if (packetSubmissionErrors != null)
            {
                foreach (var error in packetSubmissionErrors)
                {
                    vm.Add(error.ToVM());
                }
            }

            return vm;
        }

        public static PacketSubmissionErrorModel ToVM(this PacketSubmissionError packetSubmissionError)
        {
            return new PacketSubmissionErrorModel
            {
                Id = packetSubmissionError.Id,
                PacketSubmissionId = packetSubmissionError.PacketSubmissionId,
                FormKind = packetSubmissionError.FormKind,
                Message = packetSubmissionError.Message,
                AssignedTo = packetSubmissionError.AssignedTo,
                Level = packetSubmissionError.Level,
                ResolvedBy = packetSubmissionError.ResolvedBy,
                CreatedBy = packetSubmissionError.CreatedBy,
                CreatedAt = packetSubmissionError.CreatedAt,
                ModifiedBy = packetSubmissionError.ModifiedBy,
                DeletedBy = packetSubmissionError.DeletedBy,
                IsDeleted = packetSubmissionError.IsDeleted
            };
        }

        public static MilestoneModel ToVM(this Milestone milestone)
        {
            var vm = new MilestoneModel()
            {
                Id = milestone.Id,
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
                MILESTONETYPE = milestone.MILESTONETYPE
            };

            if (milestone.Participation != null)
                vm.Participation = milestone.Participation.ToShallowVM();

            return vm;
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

        private static void SetFormBaseProperties(Form form, FormModel vm)
        {
            vm.VisitId = form.VisitId;
            vm.FORMVER = form.FORMVER;
            vm.Status = form.Status;
            vm.Kind = form.Kind;
            vm.Title = form.Title;
            vm.Description = form.Description;
            vm.IsRequiredForPacketKind = form.IsRequiredForPacketKind;
            vm.LANG = form.LANG;
            vm.NOT = form.NOT;
            vm.MODE = form.MODE;
            vm.RMREAS = form.RMREAS;
            vm.RMMODE = form.RMMODE;
            vm.INITIALS = form.INITIALS;
            vm.FRMDATE = form.FRMDATE;
            vm.CreatedAt = form.CreatedAt;
            vm.CreatedBy = form.CreatedBy;
            vm.ModifiedBy = form.ModifiedBy;
            vm.DeletedBy = form.DeletedBy;
            vm.IsDeleted = form.IsDeleted;

            if (form.UnresolvedErrors != null && form.UnresolvedErrors.Count() > 0)
            {
                vm.UnresolvedErrors = form.UnresolvedErrors.ToVM();
                vm.UnresolvedErrorCount = form.UnresolvedErrors.Count();
            }
        }

        public static FormModel ToVM(this Form form)
        {
            var vm = new FormModel()
            {
                Id = form.Id
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
                else if (form.Fields is C2FormFields)
                {
                    vm = ((C2FormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is D1aFormFields)
                {
                    vm = ((D1aFormFields)form.Fields).ToVM(form.Id);
                }
                else if (form.Fields is D1bFormFields)
                {
                    vm = ((D1bFormFields)form.Fields).ToVM(form.Id);
                }
            }

            SetFormBaseProperties(form, vm);

            return vm;
        }

        public static A1 ToVM(this A1FormFields fields, int formId)
        {
            return new A1()
            {
                Id = formId,
                AllowedFormModes = fields.FormModes.Select(f => (int)f).ToList(),
                AllowedRemoteModalities = fields.RemoteModalities.Select(f => (int)f).ToList(),
                AllowedNotIncludedReasonCodes = fields.NotIncludedReasonCodes.Select(f => (int)f).ToList(),
                BIRTHMO = fields.BIRTHMO,
                BIRTHYR = fields.BIRTHYR,
                CHLDHDCTRY = fields.CHLDHDCTRY,
                RACEWHITE = fields.RACEWHITE.HasValue ? fields.RACEWHITE.Value != 0 : false,
                ETHGERMAN = fields.ETHGERMAN.HasValue && fields.ETHGERMAN.Value == true ? true : false,
                ETHIRISH = fields.ETHIRISH.HasValue ? fields.ETHIRISH.Value != 0 : false,
                ETHENGLISH = fields.ETHENGLISH.HasValue ? fields.ETHENGLISH.Value != 0 : false,
                ETHITALIAN = fields.ETHITALIAN.HasValue && fields.ETHITALIAN.Value == true ? true : false,
                ETHPOLISH = fields.ETHPOLISH.HasValue && fields.ETHPOLISH.Value == true ? true : false,
                ETHSCOTT = fields.ETHSCOTT.HasValue ? fields.ETHSCOTT.Value != 0 : false,
                ETHWHIOTH = fields.ETHWHIOTH.HasValue && fields.ETHWHIOTH.Value == true ? true : false,
                ETHWHIOTHX = fields.ETHWHIOTHX,
                ETHISPANIC = fields.ETHISPANIC.HasValue && fields.ETHISPANIC.Value == true ? true : false,
                ETHMEXICAN = fields.ETHMEXICAN.HasValue && fields.ETHMEXICAN.Value == true ? true : false,
                ETHPUERTO = fields.ETHPUERTO.HasValue && fields.ETHPUERTO.Value == true ? true : false,
                ETHCUBAN = fields.ETHCUBAN.HasValue && fields.ETHCUBAN.Value == true ? true : false,
                ETHSALVA = fields.ETHSALVA.HasValue && fields.ETHSALVA.Value == true ? true : false,
                ETHDOMIN = fields.ETHDOMIN.HasValue && fields.ETHDOMIN.Value == true ? true : false,
                ETHGUATEM = fields.ETHGUATEM.HasValue && fields.ETHGUATEM.Value == true ? true : false,
                ETHHISOTH = fields.ETHHISOTH.HasValue && fields.ETHHISOTH.Value == true ? true : false,
                ETHHISOTHX = fields.ETHHISOTHX,
                RACEBLACK = fields.RACEBLACK.HasValue ? fields.RACEBLACK.Value != 0 : false,
                ETHAFAMER = fields.ETHAFAMER.HasValue && fields.ETHAFAMER.Value == true ? true : false,
                ETHJAMAICA = fields.ETHJAMAICA.HasValue && fields.ETHJAMAICA.Value == true ? true : false,
                ETHHAITIAN = fields.ETHHAITIAN.HasValue && fields.ETHHAITIAN.Value == true ? true : false,
                ETHNIGERIA = fields.ETHNIGERIA.HasValue && fields.ETHNIGERIA.Value == true ? true : false,
                ETHETHIOP = fields.ETHETHIOP.HasValue && fields.ETHETHIOP.Value == true ? true : false,
                ETHSOMALI = fields.ETHSOMALI.HasValue && fields.ETHSOMALI.Value == true ? true : false,
                ETHBLKOTH = fields.ETHBLKOTH.HasValue && fields.ETHBLKOTH.Value == true ? true : false,
                ETHBLKOTHX = fields.ETHBLKOTHX,
                RACEASIAN = fields.RACEASIAN.HasValue ? fields.RACEASIAN.Value != 0 : false,
                ETHCHINESE = fields.ETHCHINESE.HasValue && fields.ETHCHINESE.Value == true ? true : false,
                ETHFILIP = fields.ETHFILIP.HasValue && fields.ETHFILIP.Value == true ? true : false,
                ETHINDIA = fields.ETHINDIA.HasValue && fields.ETHINDIA.Value == true ? true : false,
                ETHVIETNAM = fields.ETHVIETNAM.HasValue && fields.ETHVIETNAM.Value == true ? true : false,
                ETHKOREAN = fields.ETHKOREAN.HasValue && fields.ETHKOREAN.Value == true ? true : false,
                ETHJAPAN = fields.ETHJAPAN.HasValue && fields.ETHJAPAN.Value == true ? true : false,
                ETHASNOTH = fields.ETHASNOTH.HasValue && fields.ETHASNOTH.Value == true ? true : false,
                ETHASNOTHX = fields.ETHASNOTHX,
                RACEAIAN = fields.RACEAIAN.HasValue ? fields.RACEAIAN.Value != 0 : false,
                RACEAIANX = fields.RACEAIANX,
                RACEMENA = fields.RACEMENA.HasValue ? fields.RACEMENA.Value != 0 : false,
                ETHLEBANON = fields.ETHLEBANON.HasValue && fields.ETHLEBANON.Value == true ? true : false,
                ETHIRAN = fields.ETHIRAN.HasValue && fields.ETHIRAN.Value == true ? true : false,
                ETHEGYPT = fields.ETHEGYPT.HasValue && fields.ETHEGYPT.Value == true ? true : false,
                ETHSYRIA = fields.ETHSYRIA.HasValue && fields.ETHSYRIA.Value == true ? true : false,
                ETHIRAQI = fields.ETHIRAQI.HasValue ? fields.ETHIRAQI.Value != 0 : false,
                ETHISRAEL = fields.ETHISRAEL.HasValue && fields.ETHISRAEL.Value == true ? true : false,
                ETHMENAOTH = fields.ETHMENAOTH.HasValue && fields.ETHMENAOTH.Value == true ? true : false,
                ETHMENAOTX = fields.ETHMENAOTX,
                RACENHPI = fields.RACENHPI.HasValue ? fields.RACENHPI.Value != 0 : false,
                ETHHAWAII = fields.ETHHAWAII.HasValue && fields.ETHHAWAII.Value == true ? true : false,
                ETHSAMOAN = fields.ETHSAMOAN.HasValue && fields.ETHSAMOAN.Value == true ? true : false,
                ETHCHAMOR = fields.ETHCHAMOR.HasValue && fields.ETHCHAMOR.Value == true ? true : false,
                ETHTONGAN = fields.ETHTONGAN.HasValue && fields.ETHTONGAN.Value == true ? true : false,
                ETHFIJIAN = fields.ETHFIJIAN.HasValue && fields.ETHFIJIAN.Value == true ? true : false,
                ETHMARSHAL = fields.ETHMARSHAL.HasValue && fields.ETHMARSHAL.Value == true ? true : false,
                ETHNHPIOTH = fields.ETHNHPIOTH.HasValue && fields.ETHNHPIOTH.Value == true ? true : false,
                ETHNHPIOTX = fields.ETHNHPIOTX,
                RACEUNKN = fields.RACEUNKN.HasValue ? fields.RACEUNKN.Value != 0 : false,
                GENMAN = fields.GENMAN.HasValue && fields.GENMAN.Value == true ? true : false,
                GENWOMAN = fields.GENWOMAN.HasValue ? fields.GENWOMAN.Value != 0 : false,
                GENTRMAN = fields.GENTRMAN.HasValue && fields.GENTRMAN.Value == true ? true : false,
                GENTRWOMAN = fields.GENTRWOMAN.HasValue && fields.GENTRWOMAN.Value == true ? true : false,
                GENNONBI = fields.GENNONBI.HasValue && fields.GENNONBI.Value == true ? true : false,
                GENTWOSPIR = fields.GENTWOSPIR.HasValue && fields.GENTWOSPIR.Value == true ? true : false,
                GENOTH = fields.GENOTH.HasValue && fields.GENOTH.Value == true ? true : false,
                GENOTHX = fields.GENOTHX,
                GENDKN = fields.GENDKN.HasValue && fields.GENDKN.Value == true ? true : false,
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
                AllowedFormModes = fields.FormModes.Select(f => (int)f).ToList(),
                AllowedRemoteModalities = fields.RemoteModalities.Select(f => (int)f).ToList(),
                AllowedNotIncludedReasonCodes = fields.NotIncludedReasonCodes.Select(f => (int)f).ToList(),
                OWNSCAR = fields.OWNSCAR,
                TRSPACCESS = fields.TRSPACCESS,
                TRANSPROB = fields.TRANSPROB,
                TRANSWORRY = fields.TRANSWORRY,
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
                GUARDEDU = fields.GUARDEDU,
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
                AllowedFormModes = fields.FormModes.Select(f => (int)f).ToList(),
                AllowedRemoteModalities = fields.RemoteModalities.Select(f => (int)f).ToList(),
                AllowedNotIncludedReasonCodes = fields.NotIncludedReasonCodes.Select(f => (int)f).ToList(),
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
                AllowedFormModes = fields.FormModes.Select(f => (int)f).ToList(),
                AllowedRemoteModalities = fields.RemoteModalities.Select(f => (int)f).ToList(),
                AllowedNotIncludedReasonCodes = fields.NotIncludedReasonCodes.Select(f => (int)f).ToList(),
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
                AllowedFormModes = fields.FormModes.Select(f => (int)f).ToList(),
                AllowedRemoteModalities = fields.RemoteModalities.Select(f => (int)f).ToList(),
                AllowedNotIncludedReasonCodes = fields.NotIncludedReasonCodes.Select(f => (int)f).ToList(),
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
                AllowedFormModes = fields.FormModes.Select(f => (int)f).ToList(),
                AllowedRemoteModalities = fields.RemoteModalities.Select(f => (int)f).ToList(),
                AllowedNotIncludedReasonCodes = fields.NotIncludedReasonCodes.Select(f => (int)f).ToList(),
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

        public static A5D2 ToVM(this A5D2FormFields fields, int formId)
        {
            return new A5D2()
            {
                Id = formId,
                AllowedFormModes = fields.FormModes.Select(f => (int)f).ToList(),
                AllowedRemoteModalities = fields.RemoteModalities.Select(f => (int)f).ToList(),
                AllowedNotIncludedReasonCodes = fields.NotIncludedReasonCodes.Select(f => (int)f).ToList(),
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
                DIABGLP1 = fields.DIABGLP1,
                DIABRECACT = fields.DIABRECACT,
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
                AllowedFormModes = fields.FormModes.Select(f => (int)f).ToList(),
                AllowedRemoteModalities = fields.RemoteModalities.Select(f => (int)f).ToList(),
                AllowedNotIncludedReasonCodes = fields.NotIncludedReasonCodes.Select(f => (int)f).ToList(),
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
                AllowedFormModes = fields.FormModes.Select(f => (int)f).ToList(),
                AllowedRemoteModalities = fields.RemoteModalities.Select(f => (int)f).ToList(),
                AllowedNotIncludedReasonCodes = fields.NotIncludedReasonCodes.Select(f => (int)f).ToList(),
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
                AllowedFormModes = fields.FormModes.Select(f => (int)f).ToList(),
                AllowedRemoteModalities = fields.RemoteModalities.Select(f => (int)f).ToList(),
                AllowedNotIncludedReasonCodes = fields.NotIncludedReasonCodes.Select(f => (int)f).ToList(),
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
                AllowedFormModes = fields.FormModes.Select(f => (int)f).ToList(),
                AllowedRemoteModalities = fields.RemoteModalities.Select(f => (int)f).ToList(),
                AllowedNotIncludedReasonCodes = fields.NotIncludedReasonCodes.Select(f => (int)f).ToList(),
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
                AllowedFormModes = fields.FormModes.Select(f => (int)f).ToList(),
                AllowedRemoteModalities = fields.RemoteModalities.Select(f => (int)f).ToList(),
                AllowedNotIncludedReasonCodes = fields.NotIncludedReasonCodes.Select(f => (int)f).ToList(),
                NOGDS = fields.NOGDS.HasValue && fields.NOGDS.Value == true ? true : false,
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
                AllowedFormModes = fields.FormModes.Select(f => (int)f).ToList(),
                AllowedRemoteModalities = fields.RemoteModalities.Select(f => (int)f).ToList(),
                AllowedNotIncludedReasonCodes = fields.NotIncludedReasonCodes.Select(f => (int)f).ToList(),
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
                AllowedFormModes = fields.FormModes.Select(f => (int)f).ToList(),
                AllowedRemoteModalities = fields.RemoteModalities.Select(f => (int)f).ToList(),
                AllowedNotIncludedReasonCodes = fields.NotIncludedReasonCodes.Select(f => (int)f).ToList(),
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
                AllowedFormModes = fields.FormModes.Select(f => (int)f).ToList(),
                AllowedRemoteModalities = fields.RemoteModalities.Select(f => (int)f).ToList(),
                AllowedNotIncludedReasonCodes = fields.NotIncludedReasonCodes.Select(f => (int)f).ToList(),
                DECCOG = fields.DECCOG,
                DECMOT = fields.DECMOT,
                PSYCHSYM = fields.PSYCHSYM,
                DECCOGIN = fields.DECCOGIN,
                DECMOTIN = fields.DECMOTIN,
                PSYCHSYMIN = fields.PSYCHSYMIN,
                DECCLIN = fields.DECCLIN,
                DECCLCOG = fields.DECCLCOG,
                COGMEM = fields.COGMEM,
                COGORI = fields.COGORI,
                COGJUDG = fields.COGJUDG,
                COGLANG = fields.COGLANG,
                COGVIS = fields.COGVIS,
                COGATTN = fields.COGATTN,
                COGFLUC = fields.COGFLUC,
                COGOTHR = fields.COGOTHR,
                COGOTHRX = fields.COGOTHRX,
                COGAGE = fields.COGAGE,
                COGMODE = fields.COGMODE,
                COGMODEX = fields.COGMODEX,
                DECCLBE = fields.DECCLBE,
                BEAPATHY = fields.BEAPATHY,
                BEDEP = fields.BEDEP,
                BEANX = fields.BEANX,
                BEEUPH = fields.BEEUPH,
                BEIRRIT = fields.BEIRRIT,
                BEAGIT = fields.BEAGIT,
                BEHAGE = fields.BEHAGE,
                BEVHALL = fields.BEVHALL,
                BEVPATT = fields.BEVPATT,
                BEVWELL = fields.BEVWELL,
                BEAHALL = fields.BEAHALL,
                BEAHSIMP = fields.BEAHSIMP,
                BEAHCOMP = fields.BEAHCOMP,
                BEDEL = fields.BEDEL,
                BEAGGRS = fields.BEAGGRS,
                PSYCHAGE = fields.PSYCHAGE,
                BEDISIN = fields.BEDISIN,
                BEPERCH = fields.BEPERCH,
                BEEMPATH = fields.BEEMPATH,
                BEOBCOM = fields.BEOBCOM,
                BEANGER = fields.BEANGER,
                BESUBAB = fields.BESUBAB,
                ALCUSE = fields.ALCUSE,
                SEDUSE = fields.SEDUSE,
                OPIATEUSE = fields.OPIATEUSE,
                COCAINEUSE = fields.COCAINEUSE,
                CANNABUSE = fields.CANNABUSE,
                OTHSUBUSE = fields.OTHSUBUSE,
                OTHSUBUSEX = fields.OTHSUBUSEX,
                PERCHAGE = fields.PERCHAGE,
                BEREM = fields.BEREM,
                BEREMAGO = fields.BEREMAGO,
                BEREMCONF = fields.BEREMCONF,
                BEOTHR = fields.BEOTHR,
                BEOTHRX = fields.BEOTHRX,
                BEMODE = fields.BEMODE,
                BEMODEX = fields.BEMODEX,
                DECCLMOT = fields.DECCLMOT,
                MOGAIT = fields.MOGAIT,
                MOFALLS = fields.MOFALLS,
                MOSLOW = fields.MOSLOW,
                MOTREM = fields.MOTREM,
                MOLIMB = fields.MOLIMB,
                MOFACE = fields.MOFACE,
                MOSPEECH = fields.MOSPEECH,
                MOTORAGE = fields.MOTORAGE,
                MOMODE = fields.MOMODE,
                MOMODEX = fields.MOMODEX,
                MOMOPARK = fields.MOMOPARK,
                MOMOALS = fields.MOMOALS,
                COURSE = fields.COURSE,
                FRSTCHG = fields.FRSTCHG,
            };
        }

        public static C2 ToVM(this C2FormFields fields, int formId)
        {
            return new C2()
            {
                Id = formId,
                AllowedFormModes = fields.FormModes.Select(f => (int)f).ToList(),
                AllowedRemoteModalities = fields.RemoteModalities.Select(f => (int)f).ToList(),
                AllowedNotIncludedReasonCodes = fields.NotIncludedReasonCodes.Select(f => (int)f).ToList(),
                MOCACOMP = fields.MOCACOMP,
                MOCAREAS = fields.MOCAREAS,
                MOCALOC = fields.MOCALOC,
                MOCALAN = fields.MOCALAN,
                MOCALANX = fields.MOCALANX,
                MOCAVIS = fields.MOCAVIS,
                MOCAHEAR = fields.MOCAHEAR,
                MOCATOTS = fields.MOCATOTS,
                MOCBTOTS = fields.MOCBTOTS,
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
                VERBALTEST = fields.VERBALTEST,
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
                REYBREC = fields.REYBREC,
                REYBINT = fields.REYBINT,
                REY6REC = fields.REY6REC,
                REY6INT = fields.REY6INT,
                REYDREC = fields.REYDREC,
                REYDINT = fields.REYDINT,
                REYDTI = fields.REYDTI,
                REYMETHOD = fields.REYMETHOD,
                REYTCOR = fields.REYTCOR,
                REYFPOS = fields.REYFPOS,
                CERAD1REC = fields.CERAD1REC,
                CERAD1READ = fields.CERAD1READ,
                CERAD1INT = fields.CERAD1INT,
                CERAD2REC = fields.CERAD2REC,
                CERAD2READ = fields.CERAD2READ,
                CERAD2INT = fields.CERAD2INT,
                CERAD3REC = fields.CERAD3REC,
                CERAD3READ = fields.CERAD3READ,
                CERAD3INT = fields.CERAD3INT,
                CERADDTI = fields.CERADDTI,
                CERADJ6REC = fields.CERADJ6REC,
                CERADJ6INT = fields.CERADJ6INT,
                CERADJ7YES = fields.CERADJ7YES,
                CERADJ7NO = fields.CERADJ7NO,
                OTRAILA = fields.OTRAILA,
                OTRLARR = fields.OTRLARR,
                OTRLALI = fields.OTRLALI,
                OTRAILB = fields.OTRAILB,
                OTRLBRR = fields.OTRLBRR,
                OTRLBLI = fields.OTRLBLI,
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
        public static D1a ToVM(this D1aFormFields fields, int formId)
        {
            return new D1a()
            {
                Id = formId,
                AllowedFormModes = fields.FormModes.Select(f => (int)f).ToList(),
                AllowedRemoteModalities = fields.RemoteModalities.Select(f => (int)f).ToList(),
                AllowedNotIncludedReasonCodes = fields.NotIncludedReasonCodes.Select(f => (int)f).ToList(),
                DXMETHOD = fields.DXMETHOD,
                NORMCOG = fields.NORMCOG,
                SCD = fields.SCD,
                SCDDXCONF = fields.SCDDXCONF,
                DEMENTED = fields.DEMENTED,
                MCICRITCLN = fields.MCICRITCLN,
                MCICRITIMP = fields.MCICRITIMP,
                MCICRITFUN = fields.MCICRITFUN,
                MCI = fields.MCI,
                IMPNOMCIFU = fields.IMPNOMCIFU,
                IMPNOMCICG = fields.IMPNOMCICG,
                IMPNOMCLCD = fields.IMPNOMCLCD,
                IMPNOMCIO = fields.IMPNOMCIO,
                IMPNOMCIOX = fields.IMPNOMCIOX,
                IMPNOMCI = fields.IMPNOMCI.HasValue ? (fields.IMPNOMCI == true ? 1 : 0) : null,
                CDOMMEM = fields.CDOMMEM,
                CDOMLANG = fields.CDOMLANG,
                CDOMATTN = fields.CDOMATTN,
                CDOMEXEC = fields.CDOMEXEC,
                CDOMVISU = fields.CDOMVISU,
                CDOMBEH = fields.CDOMBEH,
                CDOMAPRAX = fields.CDOMAPRAX,
                MBI = fields.MBI,
                BDOMMOT = fields.BDOMMOT,
                BDOMAFREG = fields.BDOMAFREG,
                BDOMIMP = fields.BDOMIMP,
                BDOMSOCIAL = fields.BDOMSOCIAL,
                BDOMTHTS = fields.BDOMTHTS,
                PREDOMSYN = fields.PREDOMSYN,
                AMNDEM = fields.AMNDEM,
                DYEXECSYN = fields.DYEXECSYN,
                PCA = fields.PCA,
                PPASYN = fields.PPASYN,
                PPASYNT = fields.PPASYNT,
                FTDSYN = fields.FTDSYN,
                LBDSYN = fields.LBDSYN,
                LBDSYNT = fields.LBDSYNT,
                NAMNDEM = fields.NAMNDEM,
                PSPSYN = fields.PSPSYN,
                PSPSYNT = fields.PSPSYNT,
                CTESYN = fields.CTESYN,
                CBSSYN = fields.CBSSYN,
                MSASYN = fields.MSASYN,
                MSASYNT = fields.MSASYNT,
                OTHSYN = fields.OTHSYN,
                OTHSYNX = fields.OTHSYNX,
                SYNINFCLIN = fields.SYNINFCLIN,
                SYNINFCTST = fields.SYNINFCTST,
                SYNINFBIOM = fields.SYNINFBIOM,
                MAJDEPDX = fields.MAJDEPDX,
                MAJDEPDIF = fields.MAJDEPDIF,
                OTHDEPDX = fields.OTHDEPDX,
                OTHDEPDIF = fields.OTHDEPDIF,
                BIPOLDX = fields.BIPOLDX,
                BIPOLDIF = fields.BIPOLDIF,
                SCHIZOP = fields.SCHIZOP,
                SCHIZOIF = fields.SCHIZOIF,
                ANXIET = fields.ANXIET,
                ANXIETIF = fields.ANXIETIF,
                GENANX = fields.GENANX,
                PANICDISDX = fields.PANICDISDX,
                OCDDX = fields.OCDDX,
                OTHANXD = fields.OTHANXD,
                OTHANXDX = fields.OTHANXDX,
                PTSDDX = fields.PTSDDX,
                PTSDDXIF = fields.PTSDDXIF,
                NDEVDIS = fields.NDEVDIS,
                NDEVDISIF = fields.NDEVDISIF,
                DELIR = fields.DELIR,
                DELIRIF = fields.DELIRIF,
                OTHPSY = fields.OTHPSY,
                OTHPSYIF = fields.OTHPSYIF,
                OTHPSYX = fields.OTHPSYX,
                TBIDX = fields.TBIDX,
                TBIDXIF = fields.TBIDXIF,
                EPILEP = fields.EPILEP,
                EPILEPIF = fields.EPILEPIF,
                HYCEPH = fields.HYCEPH,
                HYCEPHIF = fields.HYCEPHIF,
                NEOP = fields.NEOP,
                NEOPIF = fields.NEOPIF,
                NEOPSTAT = fields.NEOPSTAT,
                HIV = fields.HIV,
                HIVIF = fields.HIVIF,
                POSTC19 = fields.POSTC19,
                POSTC19IF = fields.POSTC19IF,
                APNEADX = fields.APNEADX,
                APNEADXIF = fields.APNEADXIF,
                OTHCOGILL = fields.OTHCOGILL,
                OTHCILLIF = fields.OTHCILLIF,
                OTHCOGILLX = fields.OTHCOGILLX,
                ALCDEM = fields.ALCDEM,
                ALCDEMIF = fields.ALCDEMIF,
                IMPSUB = fields.IMPSUB,
                IMPSUBIF = fields.IMPSUBIF,
                MEDS = fields.MEDS,
                MEDSIF = fields.MEDSIF,
                COGOTH = fields.COGOTH,
                COGOTHIF = fields.COGOTHIF,
                COGOTHX = fields.COGOTHX,
                COGOTH2 = fields.COGOTH2,
                COGOTH2F = fields.COGOTH2F,
                COGOTH2X = fields.COGOTH2X,
                COGOTH3 = fields.COGOTH3,
                COGOTH3F = fields.COGOTH3F,
                COGOTH3X = fields.COGOTH3X
            };
        }

        public static D1b ToVM(this D1bFormFields fields, int formId)
        {
            return new D1b()
            {
                Id = formId,
                AllowedFormModes = fields.FormModes.Select(f => (int)f).ToList(),
                AllowedRemoteModalities = fields.RemoteModalities.Select(f => (int)f).ToList(),
                AllowedNotIncludedReasonCodes = fields.NotIncludedReasonCodes.Select(f => (int)f).ToList(),
                BIOMARKDX = fields.BIOMARKDX,
                FLUIDBIOM = fields.FLUIDBIOM,
                BLOODAD = fields.BLOODAD,
                BLOODFTLD = fields.BLOODFTLD,
                BLOODLBD = fields.BLOODLBD,
                BLOODOTH = fields.BLOODOTH,
                BLOODOTHX = fields.BLOODOTHX,
                CSFAD = fields.CSFAD,
                CSFFTLD = fields.CSFFTLD,
                CSFLBD = fields.CSFLBD,
                CSFOTH = fields.CSFOTH,
                CSFOTHX = fields.CSFOTHX,
                IMAGINGDX = fields.IMAGINGDX,
                PETDX = fields.PETDX,
                AMYLPET = fields.AMYLPET,
                TAUPET = fields.TAUPET,
                FDGPETDX = fields.FDGPETDX,
                FDGAD = fields.FDGAD,
                FDGFTLD = fields.FDGFTLD,
                FDGLBD = fields.FDGLBD,
                FDGOTH = fields.FDGOTH,
                FDGOTHX = fields.FDGOTHX,
                DATSCANDX = fields.DATSCANDX,
                TRACOTHDX = fields.TRACOTHDX,
                TRACOTHDXX = fields.TRACOTHDXX,
                TRACERAD = fields.TRACERAD,
                TRACERFTLD = fields.TRACERFTLD,
                TRACERLBD = fields.TRACERLBD,
                TRACEROTH = fields.TRACEROTH,
                TRACEROTHX = fields.TRACEROTHX,
                STRUCTDX = fields.STRUCTDX,
                STRUCTAD = fields.STRUCTAD,
                STRUCTFTLD = fields.STRUCTFTLD,
                STRUCTCVD = fields.STRUCTCVD,
                IMAGLINF = fields.IMAGLINF,
                IMAGLAC = fields.IMAGLAC,
                IMAGMACH = fields.IMAGMACH,
                IMAGMICH = fields.IMAGMICH,
                IMAGWMH = fields.IMAGWMH,
                IMAGWMHSEV = fields.IMAGWMHSEV,
                OTHBIOM1 = fields.OTHBIOM1,
                OTHBIOMX1 = fields.OTHBIOMX1,
                BIOMAD1 = fields.BIOMAD1,
                BIOMFTLD1 = fields.BIOMFTLD1,
                BIOMLBD1 = fields.BIOMLBD1,
                BIOMOTH1 = fields.BIOMOTH1,
                BIOMOTHX1 = fields.BIOMOTHX1,
                OTHBIOM2 = fields.OTHBIOM2,
                OTHBIOMX2 = fields.OTHBIOMX2,
                BIOMAD2 = fields.BIOMAD2,
                BIOMFTLD2 = fields.BIOMFTLD2,
                BIOMLBD2 = fields.BIOMLBD2,
                BIOMOTH2 = fields.BIOMOTH2,
                BIOMOTHX2 = fields.BIOMOTHX2,
                OTHBIOM3 = fields.OTHBIOM3,
                OTHBIOMX3 = fields.OTHBIOMX3,
                BIOMAD3 = fields.BIOMAD3,
                BIOMFTLD3 = fields.BIOMFTLD3,
                BIOMLBD3 = fields.BIOMLBD3,
                BIOMOTH3 = fields.BIOMOTH3,
                BIOMOTHX3 = fields.BIOMOTHX3,
                AUTDOMMUT = fields.AUTDOMMUT,
                ALZDIS = fields.ALZDIS,
                ALZDISIF = fields.ALZDISIF,
                LBDIS = fields.LBDIS,
                LBDIF = fields.LBDIF,
                FTLD = fields.FTLD,
                PSP = fields.PSP,
                PSPIF = fields.PSPIF,
                CORT = fields.CORT,
                CORTIF = fields.CORTIF,
                FTLDMO = fields.FTLDMO,
                FTLDMOIF = fields.FTLDMOIF,
                FTLDNOS = fields.FTLDNOS,
                FTLDNOIF = fields.FTLDNOIF,
                FTLDSUBT = fields.FTLDSUBT,
                FTLDSUBX = fields.FTLDSUBX,
                CVD = fields.CVD,
                CVDIF = fields.CVDIF,
                MSA = fields.MSA,
                MSAIF = fields.MSAIF,
                CTE = fields.CTE,
                CTEIF = fields.CTEIF,
                CTECERT = fields.CTECERT,
                DOWNS = fields.DOWNS,
                DOWNSIF = fields.DOWNSIF,
                HUNT = fields.HUNT,
                HUNTIF = fields.HUNTIF,
                PRION = fields.PRION,
                PRIONIF = fields.PRIONIF,
                CAA = fields.CAA,
                CAAIF = fields.CAAIF,
                LATE = fields.LATE,
                LATEIF = fields.LATEIF,
                OTHCOG = fields.OTHCOG,
                OTHCOGIF = fields.OTHCOGIF,
                OTHCOGX = fields.OTHCOGX

            };
        }
    }
}

