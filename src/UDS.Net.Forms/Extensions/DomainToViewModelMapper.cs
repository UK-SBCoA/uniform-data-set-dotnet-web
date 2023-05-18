using System;
using System.Net.NetworkInformation;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.UDS3;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;

namespace UDS.Net.Forms.Extensions
{
    public static class DomainToViewModelMapper
    {
        private static void SetBaseProperties(Form form, FormModel vm)
        {
            vm.VisitId = form.VisitId;
            vm.Version = form.Version;
            vm.Status = form.Status; // TODO
            vm.Kind = form.Kind;
            vm.Title = form.Title;
            vm.Description = form.Description;
            vm.IsRequiredForVisitKind = form.IsRequiredForVisitKind;
            vm.IncludeInPacketSubmission = form.IsIncluded.HasValue ? form.IsIncluded.Value : false;
            vm.ReasonNotIncluded = form.ReasonCode;
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
                VisitCount = participation.Visits.Count(),
                Visits = participation.Visits.ToVM()
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
            var formModel = new FormModel()
            {
                Id = form.Id,
                VisitId = form.VisitId,
                Version = form.Version,
                Kind = form.Kind,
                Status = form.Status,
                Title = form.Title,
                Description = form.Description,
                IsRequiredForVisitKind = false,
                IncludeInPacketSubmission = false,
                CreatedAt = form.CreatedAt,
                CreatedBy = form.CreatedBy,
                ModifiedBy = form.ModifiedBy,
                DeletedBy = form.DeletedBy,
                IsDeleted = form.IsDeleted
            };

            if (form.Fields is A1FormFields)
            {
                var fields = (A1FormFields)form.Fields;

                var vm = new A1()
                {
                    Id = form.Id,
                    BIRTHMO = fields.BIRTHMO,
                    BIRTHYR = fields.BIRTHYR,
                    SEX = fields.SEX,
                    MARISTAT = fields.MARISTAT,
                    LIVSITUA = fields.LIVSITUA,
                    INDEPEND = fields.INDEPEND,
                    RESIDENC = fields.RESIDENC,
                    REASON = fields.REASON,
                    REFERSC = fields.REFERSC,
                    LEARNED = fields.LEARNED,
                    PRESTAT = fields.PRESTAT,
                    PRESPART = fields.PRESPART,
                    SOURCENW = fields.SOURCENW,
                    HISPANIC = fields.HISPANIC,
                    HISPOR = fields.HISPOR,
                    HISPORX = fields.HISPORX,
                    RACE = fields.RACE,
                    RACEX = fields.RACEX,
                    RACESEC = fields.RACESEC,
                    RACESECX = fields.RACESECX,
                    RACETER = fields.RACETER,
                    RACETERX = fields.RACETERX,
                    PRIMLANG = fields.PRIMLANG,
                    PRIMLANX = fields.PRIMLANX,
                    EDUC = fields.EDUC,
                    ZIP = fields.ZIP,
                    HANDED = fields.HANDED
                };

                SetBaseProperties(form, vm);

                return vm;
            }
            else if (form.Fields is A2FormFields)
            {
                var fields = (A2FormFields)form.Fields;

                var vm = new A2()
                {
                    Id = form.Id,
                    INBIRMO = fields.INBIRMO,
                    INBIRYR = fields.INBIRYR,
                    INSEX = fields.INSEX,
                    INHISP = fields.INHISP,
                    INHISPOR = fields.INHISPOR,
                    INHISPOX = fields.INHISPOX,
                    INRACE = fields.INRACE,
                    INRACEX = fields.INRACEX,
                    INRASEC = fields.INRASEC,
                    INRASECX = fields.INRASECX,
                    INRATER = fields.INRATER,
                    INRATERX = fields.INRATERX,
                    INEDUC = fields.INEDUC,
                    INRELTO = fields.INRELTO,
                    INKNOWN = fields.INKNOWN,
                    INLIVWTH = fields.INLIVWTH,
                    INVISITS = fields.INVISITS,
                    INCALLS = fields.INCALLS,
                    INRELY = fields.INRELY
                };

                SetBaseProperties(form, vm);

                return vm;
            }

            return formModel;
        }

    }
}

