using System;
using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms
{
    public class B8FormFields : IFormFields
    {
        public int? NORMEXAM { get; set; }
        public int? PARKSIGN { get; set; }
        public int? RESTTRL { get; set; }
        public int? RESTTRR { get; set; }
        public int? SLOWINGL { get; set; }
        public int? SLOWINGR { get; set; }
        public int? RIGIDL { get; set; }
        public int? RIGIDR { get; set; }
        public int? BRADY { get; set; }
        public int? PARKGAIT { get; set; }
        public int? POSTINST { get; set; }
        public int? CVDSIGNS { get; set; }
        public int? CORTDEF { get; set; }
        public int? SIVDFIND { get; set; }
        public int? CVDMOTL { get; set; }
        public int? CVDMOTR { get; set; }
        public int? CORTVISL { get; set; }
        public int? CORTVISR { get; set; }
        public int? SOMATL { get; set; }
        public int? SOMATR { get; set; }
        public int? POSTCORT { get; set; }
        public int? PSPCBS { get; set; }
        public int? EYEPSP { get; set; }
        public int? DYSPSP { get; set; }
        public int? AXIALPSP { get; set; }
        public int? GAITPSP { get; set; }
        public int? APRAXSP { get; set; }
        public int? APRAXL { get; set; }
        public int? APRAXR { get; set; }
        public int? CORTSENL { get; set; }
        public int? CORTSENR { get; set; }
        public int? ATAXL { get; set; }
        public int? ATAXR { get; set; }
        public int? ALIENLML { get; set; }
        public int? ALIENLMR { get; set; }
        public int? DYSTONL { get; set; }
        public int? DYSTONR { get; set; }
        public int? MYOCLLT { get; set; }
        public int? MYOCLRT { get; set; }
        public int? ALSFIND { get; set; }
        public int? GAITNPH { get; set; }
        public int? OTHNEUR { get; set; }
        public string OTHNEURX { get; set; }

        public B8FormFields()
        {
        }
        public B8FormFields(FormDto dto)
        {
            if (dto is B8Dto)
            {
                var b8Dto = ((B8Dto)dto);
                NORMEXAM = b8Dto.NORMEXAM;
                PARKSIGN = b8Dto.PARKSIGN;
                RESTTRL = b8Dto.RESTTRL;
                RESTTRR = b8Dto.RESTTRR;
                SLOWINGL = b8Dto.SLOWINGL;
                SLOWINGR = b8Dto.SLOWINGR;
                RIGIDL = b8Dto.RIGIDL;
                RIGIDR = b8Dto.RIGIDR;
                BRADY = b8Dto.BRADY;
                PARKGAIT = b8Dto.PARKGAIT;
                POSTINST = b8Dto.POSTINST;
                CVDSIGNS = b8Dto.CVDSIGNS;
                CORTDEF = b8Dto.CORTDEF;
                SIVDFIND = b8Dto.SIVDFIND;
                CVDMOTL = b8Dto.CVDMOTL;
                CVDMOTR = b8Dto.CVDMOTR;
                CORTVISL = b8Dto.CORTVISL;
                CORTVISR = b8Dto.CORTVISR;
                SOMATL = b8Dto.SOMATL;
                SOMATR = b8Dto.SOMATR;
                POSTCORT = b8Dto.POSTCORT;
                PSPCBS = b8Dto.PSPCBS;
                EYEPSP = b8Dto.EYEPSP;
                DYSPSP = b8Dto.DYSPSP;
                AXIALPSP = b8Dto.AXIALPSP;
                GAITPSP = b8Dto.GAITPSP;
                APRAXSP = b8Dto.APRAXSP;
                APRAXL = b8Dto.APRAXL;
                APRAXR = b8Dto.APRAXR;
                CORTSENL = b8Dto.CORTSENL;
                CORTSENR = b8Dto.CORTSENR;
                ATAXL = b8Dto.ATAXL;
                ATAXR = b8Dto.ATAXR;
                ALIENLML = b8Dto.ALIENLML;
                ALIENLMR = b8Dto.ALIENLMR;
                DYSTONL = b8Dto.DYSTONL;
                DYSTONR = b8Dto.DYSTONR;
                MYOCLLT = b8Dto.MYOCLLT;
                MYOCLRT = b8Dto.MYOCLRT;
                ALSFIND = b8Dto.ALSFIND;
                GAITNPH = b8Dto.GAITNPH;
                OTHNEUR = b8Dto.OTHNEUR;
                OTHNEURX = b8Dto.OTHNEURX;
            }
        }
        public string GetDescription()
        {
            return "Neurological Examination Findings";
        }

        public string GetVersion()
        {
            return "3.0";
        }
    }
}

