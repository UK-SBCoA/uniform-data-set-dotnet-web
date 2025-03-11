﻿using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record C2Record(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdatec2ct2")]
        public string FrmDate { get; init; } = form.FRMDATE.ToShortDateString();

        [Name("initialsc2ct2")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langc2ct2")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("modec2ct2")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("rmreasc2ct2")]
        public int? RmReas { get; init; } = form.RMREAS.HasValue ? (int)form.RMREAS.Value : null;

        [Name("rmmodec2ct2")]
        public int? RmMode { get; init; } = form.RMMODE.HasValue ? (int)form.RMMODE.Value : null;
    }
}

