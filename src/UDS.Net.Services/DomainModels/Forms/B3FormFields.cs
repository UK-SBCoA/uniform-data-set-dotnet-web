using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class B3FormFields : IFormFields
    {
        public bool? PDNORMAL { get; set; }
        public int? SPEECH { get; set; }
        public string SPEECHX { get; set; }
        public int? FACEXP { get; set; }
        public string FACEXPX { get; set; }
        public int? TRESTFAC { get; set; }
        public string TRESTFAX { get; set; }
        public int? TRESTRHD { get; set; }
        public string TRESTRHX { get; set; }
        public int? TRESTLHD { get; set; }
        public string TRESTLHX { get; set; }
        public int? TRESTRFT { get; set; }
        public string TRESTRFX { get; set; }
        public int? TRESTLFT { get; set; }
        public string TRESTLFX { get; set; }
        public int? TRACTRHD { get; set; }
        public string TRACTRHX { get; set; }
        public int? TRACTLHD { get; set; }
        public string TRACTLHX { get; set; }
        public int? RIGDNECK { get; set; }
        public string RIGDNEX { get; set; }
        public int? RIGDUPRT { get; set; }
        public string RIGDUPRX { get; set; }
        public int? RIGDUPLF { get; set; }
        public string RIGDUPLX { get; set; }
        public int? RIGDLORT { get; set; }
        public string RIGDLORX { get; set; }
        public int? RIGDLOLF { get; set; }
        public string RIGDLOLX { get; set; }
        public int? TAPSRT { get; set; }
        public string TAPSRTX { get; set; }
        public int? TAPSLF { get; set; }
        public string TAPSLFX { get; set; }
        public int? HANDMOVR { get; set; }
        public string HANDMVRX { get; set; }
        public int? HANDMOVL { get; set; }
        public string HANDMVLX { get; set; }
        public int? HANDALTR { get; set; }
        public string HANDATRX { get; set; }
        public int? HANDALTL { get; set; }
        public string HANDATLX { get; set; }
        public int? LEGRT { get; set; }
        public string LEGRTX { get; set; }
        public int? LEGLF { get; set; }
        public string LEGLFX { get; set; }
        public int? ARISING { get; set; }
        public string ARISINGX { get; set; }
        public int? POSTURE { get; set; }
        public string POSTUREX { get; set; }
        public int? GAIT { get; set; }
        public string GAITX { get; set; }
        public int? POSSTAB { get; set; }
        public string POSSTABX { get; set; }
        public int? BRADYKIN { get; set; }
        public string BRADYKIX { get; set; }
        public int? TOTALUPDRS { get; set; }

        public B3FormFields()
        { }

        public B3FormFields(FormDto dto)
        {

        }

        public string GetDescription()
        {
            return "Neurological Examination Findings";
        }

        public string GetVersion()
        {
            return "4.0";
        }
    }


}
