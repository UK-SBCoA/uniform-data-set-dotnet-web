using System;
using CsvHelper.Configuration.Attributes;
using UDS.Net.Services.DomainModels;

namespace UDS.Net.Forms.Records
{
    public record B1Record(Form form)
    {
        internal Form form { get; init; }

        [Name("frmdateb1")]
        public string FrmDate { get; init; } = form.FRMDATE.ToString(RecordConstants.dateFormatString);

        [Name("initialsb1")]
        public string Initials { get; init; } = form.INITIALS;

        [Name("langb1")]
        public int Lang { get; init; } = (int)form.LANG;

        [Name("modeb1")]
        public int Mode { get; init; } = (int)form.MODE;

        [Name("b1not")]
        public int? Not { get; set; } = form.NOT.HasValue ? (int)form.NOT.Value : null;

        public IEnumerable<string?> GetExportProperties()
        {
            var b1RecordProps = typeof(B1Record).GetProperties();

            foreach (var recordProp in b1RecordProps)
            {
                if (recordProp.Name == "Mode")
                {
                    yield return Mode.ToString();
                }
                else if (recordProp.Name == "Not")
                {
                    yield return Not.ToString();
                }
                else
                {
                    yield return null;
                }
            }
        }
    }
}

