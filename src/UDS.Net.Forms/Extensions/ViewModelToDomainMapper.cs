using System;
using UDS.Net.Dto;
using UDS.Net.Forms.Models;
using UDS.Net.Forms.Models.UDS3;
using UDS.Net.Services.DomainModels;
using UDS.Net.Services.DomainModels.Forms;

namespace UDS.Net.Forms.Extensions
{
    public static class ViewModelToDomainMapper
    {
        public static Participation ToEntity(this ParticipationModel vm)
        {
            return new Participation
            {
                Id = vm.Id,
                LegacyId = vm.LegacyId
            };
        }

        public static Visit ToEntity(this VisitModel vm)
        {
            return new Visit(vm.Id, vm.Number, vm.ParticipationId, vm.Version, vm.Kind, vm.StartDateTime, vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, vm.Forms.ToEntity());
        }

        public static List<Form> ToEntity(this IList<FormModel> vm)
        {
            return vm.Select(v => v.ToEntity()).ToList();
        }

        public static Form ToEntity(this FormModel vm)
        {
            if (vm is A1)
            {
                return ((A1)vm).ToEntity();
            }
            else
                return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, null);
        }

        public static Form ToEntity(this A1 vm)
        {
            var fields = new A1FormFields
            {
                REASON = vm.REASON,
                REFERSC = vm.REFERSC,
                LEARNED = vm.LEARNED,
                PRESTAT = vm.PRESTAT,
                PRESPART = vm.PRESPART,
                SOURCENW = vm.SOURCENW,
                BIRTHMO = vm.BIRTHMO,
                BIRTHYR = vm.BIRTHYR,
                SEX = vm.SEX,
                MARISTAT = vm.MARISTAT,
                LIVSITUA = vm.LIVSITUA,
                INDEPEND = vm.INDEPEND,
                RESIDENC = vm.RESIDENC,
                HISPANIC = vm.HISPANIC,
                HISPOR = vm.HISPOR,
                HISPORX = vm.HISPORX,
                RACE = vm.RACE,
                RACEX = vm.RACEX,
                RACESEC = vm.RACESEC,
                RACESECX = vm.RACESECX,
                RACETER = vm.RACETER,
                PRIMLANG = vm.PRIMLANG,
                PRIMLANX = vm.PRIMLANX,
                EDUC = vm.EDUC,
                ZIP = vm.ZIP,
                HANDED = vm.HANDED
            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }

        public static Form ToEntity(this A2 vm)
        {
            var fields = new A2FormFields
            {
                INBIRMO = vm.INBIRMO,
                INBIRYR = vm.INBIRYR,
                INSEX = vm.INSEX,
                INHISP = vm.INHISP,
                INHISPOR = vm.INHISPOR,
                INHISPOX = vm.INHISPOX,
                INRACE = vm.INRACE,
                INRACEX = vm.INRACEX,
                INRASEC = vm.INRASEC,
                INRASECX = vm.INRASECX,
                INRATER = vm.INRATER,
                INRATERX = vm.INRATERX,
                INEDUC = vm.INEDUC,
                INRELTO = vm.INRELTO,
                INKNOWN = vm.INKNOWN,
                INLIVWTH = vm.INLIVWTH,
                INVISITS = vm.INVISITS,
                INCALLS = vm.INCALLS,
                INRELY = vm.INRELY
            };

            return new Form(vm.VisitId, vm.Id, vm.Title, vm.Kind, vm.Status, vm.Language, vm.IncludeInPacketSubmission, vm.ReasonCodeNotIncluded.ToString(), vm.CreatedAt, vm.CreatedBy, vm.ModifiedBy, vm.DeletedBy, vm.IsDeleted, fields);
        }
    }
}

