using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B3Record(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdateb3")]
        public string FrmDate { get; init; } = form.FRMDATE.ToString("dd-MM-yyyy");

        [Name("initialsb3")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langb3")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("modeb3")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("b3not")]
        public int? Not { get; set; } = form.NOT.HasValue ? (int)form.NOT.Value : null;
    }
}

