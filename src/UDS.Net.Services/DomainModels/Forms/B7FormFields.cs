using System;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class B7FormFields : IFormFields
    {
        public int? BILLS { get; set; }
        public int? TAXES { get; set; }
        public int? SHOPPING { get; set; }
        public int? GAMES { get; set; }
        public int? STOVE { get; set; }
        public int? MEALPREP { get; set; }
        public int? EVENTS { get; set; }
        public int? PAYATTN { get; set; }
        public int? REMDATES { get; set; }
        public int? TRAVEL { get; set; }

        public B7FormFields()
        {
        }
        public B7FormFields(FormDto dto)
        {
            if (dto is B7Dto)
            {
                var b7Dto = ((B7Dto)dto);
                BILLS = b7Dto.BILLS;
                TAXES = b7Dto.TAXES;
                SHOPPING = b7Dto.SHOPPING;
                GAMES = b7Dto.GAMES;
                STOVE = b7Dto.STOVE;
                MEALPREP = b7Dto.MEALPREP;
                EVENTS = b7Dto.EVENTS;
                PAYATTN = b7Dto.PAYATTN;
                REMDATES = b7Dto.REMDATES;
                TRAVEL = b7Dto.TRAVEL;
            }
        }
        public string GetDescription()
        {
            return "NACC Functional Assessment Scale";
        }

        public string GetVersion()
        {
            return "4.0";
        }
    }
}

