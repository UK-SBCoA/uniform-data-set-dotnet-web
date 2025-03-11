using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B1Record(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdateb1")]
        public string FrmDate { get; init; } = form.FRMDATE.ToShortDateString();

        [Name("initialsb1")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langb1")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("modeb1")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("b1not")]
        public int? Not { get; set; } = form.NOT.HasValue ? (int)form.NOT.Value : null;
    }
}

