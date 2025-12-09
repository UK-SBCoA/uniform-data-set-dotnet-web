using UDS.Net.Dto;

namespace UDS.Net.Services.DomainModels.Forms.FollowUp
{
    public class A3FollowUpFormFields : A3FormFields
    {
        public int? NWINFPAR { get; set; }
        public int? NWINFSIB { get; set; }
        public int? NWINFKID { get; set; }

        public A3FollowUpFormFields() : base()
        {
        }

        public A3FollowUpFormFields(FormDto dto) : base(dto)
        {
            if (dto is A3Dto)
            {
                var a3Dto = ((A3Dto)dto);
                NWINFPAR = a3Dto.NWINFPAR;
                NWINFSIB = a3Dto.NWINFSIB;
                NWINFKID = a3Dto.NWINFKID;
            }
        }
    }
}
