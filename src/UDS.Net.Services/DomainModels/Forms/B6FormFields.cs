﻿using System;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class B6FormFields : IFormFields
    {
        public int? NOGDS { get; set; }
        public int? SATIS { get; set; }
        public int? DROPACT { get; set; }
        public int? EMPTY { get; set; }
        public int? BORED { get; set; }
        public int? SPIRITS { get; set; }
        public int? AFRAID { get; set; }
        public int? HAPPY { get; set; }
        public int? HELPLESS { get; set; }
        public int? STAYHOME { get; set; }
        public int? MEMPROB { get; set; }
        public int? WONDRFUL { get; set; }
        public int? WRTHLESS { get; set; }
        public int? ENERGY { get; set; }
        public int? HOPELESS { get; set; }
        public int? BETTER { get; set; }
        public int? GDS { get; set; }

        public B6FormFields()
        {
        }
        public B6FormFields(FormDto dto)
        {
            if (dto is B6Dto)
            {
                var b6Dto = ((B6Dto)dto);
                NOGDS = b6Dto.NOGDS;
                SATIS = b6Dto.SATIS;
                DROPACT = b6Dto.DROPACT;
                EMPTY = b6Dto.EMPTY;
                BORED = b6Dto.BORED;
                SPIRITS = b6Dto.SPIRITS;
                AFRAID = b6Dto.AFRAID;
                HAPPY = b6Dto.HAPPY;
                HELPLESS = b6Dto.HELPLESS;
                STAYHOME = b6Dto.STAYHOME;
                MEMPROB = b6Dto.MEMPROB;
                WONDRFUL = b6Dto.WONDRFUL;
                WRTHLESS = b6Dto.WRTHLESS;
                ENERGY = b6Dto.ENERGY;
                HOPELESS = b6Dto.HOPELESS;
                BETTER = b6Dto.BETTER;
                GDS = b6Dto.GDS;
            }
        }
        public string GetDescription()
        {
            return "Geriatric Depression Scale";
        }

        public string GetVersion()
        {
            return "3.0";
        }
    }
}

